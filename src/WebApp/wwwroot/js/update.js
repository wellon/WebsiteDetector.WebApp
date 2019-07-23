"use strict";

const available = "is available";
const notavailable = "is not available";

var connection = new signalR.HubConnectionBuilder().withUrl("/publisherHub").build();

connection.on("Update", function (data) {

    var ul = document.getElementById("updatesList");
    ul.innerHTML = "";

    data.forEach(function(d) {
        var li = document.createElement("li");
        var status = "";

        if (d.status === false) {
            li.className = "list-group-item list-group-item-danger";
            status = notavailable;
        }
        else {
            li.className = "list-group-item list-group-item-success";
            status = available;
        }

        var msg = d.name + " " + status;
        li.textContent = msg;
        document.getElementById("updatesList").appendChild(li);
    });

    $("#myToast").toast('show');
});

connection.start();