﻿

using Darnton.Blazor.DeviceInterop.Geolocation;
using Darnton.Blazor.Leaflet.LeafletMap;

namespace SailView.Geolocation
{
    public static class GeolocationPositionExtension
    {
        public static LatLng ToLeafletLatLng(this GeolocationPosition position)
        {
            var coords = position.Coords;
            return new LatLng(coords.Latitude, coords.Longitude);
        }
    }
}
