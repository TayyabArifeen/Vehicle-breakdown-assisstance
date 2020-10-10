// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


   
//        var x = document.getElementById("demo");

//function initMap(x, y) {
//    var mapProp = {
//        center: new google.maps.LatLng(x, y),
//        zoom: 5,
//    };
//    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

//function getLocation()
//{
//    if (navigator.geolocation)
//    {
//             navigator.geolocation.getCurrentPosition(showPosition);
       
//  } else {
//            x.innerHTML = "Geolocation is not supported by this browser.";
//      }
//    }
    
//function showPosition(position)
//{
//     x.innerHTML = "Latitude: " + position.coords.latitude +
//        "<br>Longitude: " + position.coords.longitude;
//    initMap(position.coords.latitude, position.coords.longitude);

    

    //jQuery.ajax({
    //    cache: false,
    //    type: "POST",
    //    url: "@Url.Action("GetNearByLocations")",
    //    dataType: "json",
    //    contentType: "application/json; charset=utf-8",
    //    data: JSON.stringify({ Currentlat: currentLatLng.latitude, Currentlng: currentLatLng.longitude }),
    //    success: function (data) {
    //        //Adding the marker of nearest locations
    //        if (data != undefined) {
    //            $.each(data, function (i, item) {
    //                // addMarker(item["lat"], item["lng"], item["Name"] + " & Distance: " + (Math.round(0.0 + item["Distance"] / 1000)) + " KM");
    //                addMarker(item["lat"], item["lng"], "Click to get directions");

    //            })
    //        }
    //    },

    //    failure: function (errMsg) {
    //        alert(errMsg);
    //    }
    //});
   
//}



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
    initMap(position.coords.latitude, position.coords.longitude);
}

function initMap(x, y) {
    var mapProp = {
        center: new google.maps.LatLng(x, y),
        zoom: 5,
    };
    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
    //var marker=new google.maps.Marker({
    //position={x,y},
    //})
}

    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBKTeuskfQ6-1x8cIMibRdeQ0PsXei6nfw&callback=initMap"
        type="text/javascript"></script>

    


