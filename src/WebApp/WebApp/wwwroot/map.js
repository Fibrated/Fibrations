function initializeMap() {
    const map = L.map(mapElement).setView([51.505, -0.09], 13);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    L.marker([51.5, -0.09]).addTo(map)
        .bindPopup('A pretty CSS3 popup.<br> Easily customizable.')
        .openPopup();
}

function addMarker(name, latitude, longitude) { /*TODO*/
    L.marker([latitude, longitude]).addTo(map)
        .bindPopup(name)
        .openPopup();
}


window.addMarker = addMarker;


window.initializeMap = initializeMap;
