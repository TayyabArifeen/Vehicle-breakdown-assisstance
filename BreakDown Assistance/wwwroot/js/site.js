// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


   
        var x = document.getElementById("demo");

function getLocation() {
  if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(showPosition);
       
  } else {
            x.innerHTML = "Geolocation is not supported by this browser.";
      }
    }
    
function showPosition(position) {
            x.innerHTML = "Latitude: " + position.coords.latitude +
            "<br>Longitude: " + position.coords.longitude;
      }

function initMap() {
    var x = 33.6295372;
    var y = 73.1169251;
    var mapProp = {
        
        center: new google.maps.LatLng(x, y),
        zoom: 5,
    };
    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
    //var marker=new google.maps.Marker({
    //position={x,y},
    //})
}

