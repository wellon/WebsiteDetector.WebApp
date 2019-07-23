"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/publisherHub").build();

connection.on("Update", function (data) {

    var ul = document.getElementById("updatesList");
    ul.innerHTML = "";

    data.forEach(function(d) {
        var li = document.createElement("li");
        var msg = d.name + " " + d.url;
        console.log(msg);
        li.textContent = msg;
        document.getElementById("updatesList").appendChild(li);
    });
});

connection.start();