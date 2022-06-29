using DAL;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TryTwo.Models
{
    public class GameController : Controller
    {
        public async Task<ActionResult> Index(int playerID = -1, int sessionID = -1)
        {
            System.Diagnostics.Debug.WriteLine("Player/Session: " + playerID + "/" + sessionID);
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Account");
            }
            else if (playerID == -1 || sessionID == -1)
            {
                return RedirectToAction("Lobby", "Bowling");
            }
            else
            {
                ViewBag.sessionId = sessionID;
                ViewBag.playerId = playerID;
                return View();
            }
        }

        public async Task<ActionResult> JoinHost(int playerID, int sessionID)
        {
            var db = new DBContext();
            var session = db.GameSessions.FirstOrDefault(x => x.sessionId == sessionID);
            session.started = true;
            db.GameSessions.Update(session);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Game", new { playerID = playerID, sessionID = sessionID });
        }

        public async Task<ActionResult> CreateGame(int player1ID, int player2ID, int roomID)
        {
            var db = new DBContext();
            int pointsToWin = HitsToWin();
            var gameSession = new GameSession()
            {
                player1 = player1ID,
                player2 = player2ID,
            };
            var gameSessionEntry = db.GameSessions.Add(gameSession);
            await db.SaveChangesAsync();

            var sessionID = gameSessionEntry.Entity.sessionId;

            var lobbyRoom = db.OpenGames.First(x => x.GameID == roomID);
            lobbyRoom.sessionID = sessionID;
            db.OpenGames.Update(lobbyRoom);
            await db.SaveChangesAsync();
            
            var p1Map = CreateRandomShipMap();
            AddShipsToDatabase(p1Map, player1ID, sessionID);
            var p2Map = CreateRandomShipMap();
            AddShipsToDatabase(p2Map, player2ID, sessionID);

            return RedirectToAction("Index", new { playerID = player2ID, sessionID = sessionID });
        }

        [HttpPost]

        public bool MyTurn(int sessionID, int userID)
        {
            var db = new DBContext();
            var session = db.GameSessions.FirstOrDefault(x => x.sessionId == sessionID);
            return MyTurn(session, userID);
        }

        private bool MyTurn(GameSession session, int userID)
        {
            return session != null
                   && ((session.playerTurn == 1 && userID == session.player1)
                      || (session.playerTurn == 2 && userID == session.player2));
        }

        public bool GetWinStatus(int sessionID, int playerID)
        {
            var db = new DBContext();
            var session = db.GameSessions.First(
                x => x.sessionId == sessionID);
            return session.finished && session.winner == playerID;
        }

        private async void WinCheck(GameSession session)
        {
            int winner = -1;
            winner = session.p1Hits >= session.p1HitsForWin ? session.player1 : winner;
            winner = session.p2Hits >= session.p2HitsForWin ? session.player2 : winner;

            if (winner != -1 && session.winner == -1)
            {
                session.winner = winner;
                session.finished = true;
                var db = new DBContext();
                var winnerUser = db.Users.First(x => x.Id == winner);
                winnerUser.WinCount += 1;
                db.GameSessions.Update(session);
                db.Users.Update(winnerUser);

                var loserID = winner != session.player1 ? session.player1 : session.player2;
                var loserUser = db.Users.First(x => x.Id == loserID);
                loserUser.LoseCount += 1;
                db.Users.Update(loserUser);
                await db.SaveChangesAsync();
            }
        }

        public GameSession GetSessionInfo(int sessionID)
        {
            var db = new DBContext();
            return db.GameSessions.FirstOrDefault(x => x.sessionId == sessionID);
        }

        private const int CELL_EMPTY = 0;
        private const int CELL_WITH_SHIP = 1;
    }
}
