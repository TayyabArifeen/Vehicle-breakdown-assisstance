// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


   
        var x = document.getElementById("demo");

function getLocation()
{
    if (navigator.geolocation)
    {
             navigator.geolocation.getCurrentPosition(showPosition);
       
  } else {
            x.innerHTML = "Geolocation is not supported by this browser.";
      }
    }
    
function showPosition(position)
{
     x.innerHTML = "Latitude: " + position.coords.latitude +
        "<br>Longitude: " + position.coords.longitude;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "InsertDataintoDatabase.aspx/InsertData",
        data: "{'username':'" + name + "','subj':'" + subject + "','desc':'" + body + "'}",
        dataType: "json"
    });
}



