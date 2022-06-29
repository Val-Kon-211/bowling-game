function pinger(lobbyID, playerID) {
    setInterval(() => {
        const request = new XMLHttpRequest();
        request.open("GET", `ActualGameID?lobbyID=${lobbyID}`, true);
        request.onload = function () {
            console.log(request.responseText);
            if (request.responseText != null && parseInt(request.responseText) != -1) {
                var url = window.location.href;
                var parentURL = url.split("/")[0]
                window.location.replace(
                    parentURL + `/Game/JoinHost?playerID=${playerID}&sessionID=${request.responseText}`
                );
            }
        };
        request.send();
    }, 3000);
}
