export let Geolocation = {

    getCurrentPosition: async function (options) {
        var result = { position: null, error: null };
        var getCurrentPositionPromise = new Promise((resolve, reject) => {
            if (!navigator.geolocation) {
                reject({ code: 0, message: 'This device does not support geolocation.' });
            } else {
                navigator.geolocation.getCurrentPosition(resolve, reject, options);
            }
        });
        await getCurrentPositionPromise.then(
            (position) => { this.mapPositionToResult(position, result) }
        ).catch(
            (error) => { this.mapErrorToResult(error, result) }
        );
        return result;
    },

    watchPosition: async function (dotNetCallbackRef, callbackMethod, options) {
        if (!navigator.geolocation) return null;

        return navigator.geolocation.watchPosition(
            (position) => {
                let result = { position: null, error: null };
                this.mapPositionToResult(position, result);
                dotNetCallbackRef.invokeMethodAsync(callbackMethod, result);
            },
            (error) => {
                let result = { position: null, error: null };
                this.mapErrorToResult(error, result);
                dotNetCallbackRef.invokeMethodAsync(callbackMethod, result);
            },
            options);
    },

    clearWatch: function (id) {
        if (navigator.geolocation) {
            navigator.geolocation.clearWatch(id);
        }
    },

    mapPositionToResult: function (position, result) {
        result.position = {
            coords: {
                latitude: position.coords.latitude,
                longitude: position.coords.longitude,
                altitude: position.coords.altitude,
                accuracy: position.coords.accuracy,
                altitudeAccuracy: position.coords.altitudeAccuracy,
                heading: position.coords.heading,
                speed: position.coords.speed
            },
            timestamp: position.timestamp
        }
    },

    mapErrorToResult: function (error, result) {
        result.error = {
            code: error.code,
            message: error.message
        }
    }

}

window.getGeolocation = (latitudeId, longitudeId) => {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition((position) => {
            document.getElementById(latitudeId).value = position.coords.latitude;
            document.getElementById(longitudeId).value = position.coords.longitude;
        });
    } else {
        alert("Geolocation is not supported by this browser.");
    }
};


/*function addMap() {
    var map = L.map('map').setView([51.505, -0.09], 13);
    L.titleLayer('http://tile.openweathermap.org/map/{layer}/{z}/{x}/{y}.png?appid={apikey}', {
        attribution: 'Map data &copy; <a href="http://openweathermap.org">OpenWeatherMap</a>',
        maxZoom: 18,
        layer: 'wind_new',
        apikey = 'f799f32ab495b987f4af22e1de392ba2'
    }).addTo(map);
}*/
