"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/publisherHub").build();

connection.on("Update", function (data) {

    var ul = document.getElementById("updatesList");
    ul.innerHTML = "";

    data.forEach(function(d) {
        var li = document.createElement("li");

        if (d.status === false) {
            li.className = "list-group-item list-group-item-danger";
        }
        else {
            li.className = "list-group-item list-group-item-success";
        }

        var msg = d.name + " " + d.status;
        li.textContent = msg;
        document.getElementById("updatesList").appendChild(li);
    });

    $("#myToast").toast('show');
});

connection.start();