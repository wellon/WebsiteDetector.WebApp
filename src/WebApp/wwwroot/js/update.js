"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/publisherHub").build();

document.getElementById("startButton").disabled = true;

connection.on("ReceiveMessage", function (message) {
    var li = document.createElement("li");
    li.textContent = message;
    document.getElementById("updatesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("startButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("startButton").addEventListener("click", function (event) {
    connection.invoke("PublishUpdate").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});