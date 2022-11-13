AddCameras();

async function AddCameras() {
    var camerasResponse = null;
  
    var response = await fetch("https://localhost:7174/api/Cameras", {
      method: 'GET',
      headers: {
        accept: 'application/json',
      },
    }).then(function (response) {
      if (!response.ok) {
        throw new Error('Something went wrong.');
      }
      camerasResponse = response;
  
    }).catch(function () {
        throw new Error('Something went wrong.');
    });

    // var mapId = document.getElementById('map');

    // var map = L.map('map').setView([52.0921, 5.1195], 13);

    // L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
    //     maxZoom: 19,
    //     attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    // }).addTo(map);

    // mapId = map;

    if (camerasResponse != undefined) {
        const camerasJson = await camerasResponse.json();
        var cameraDivisibleBy3Table = document.getElementById('cameraDivisibleBy3Table');
        var cameraDivisibleBy5Table = document.getElementById('cameraDivisibleBy5Table');
        var cameraDivisibleBy3And5Table = document.getElementById('cameraDivisibleBy3And5Table');
        var cameraNotDivisibleBy3And5Table = document.getElementById('cameraNotDivisibleBy3And5Table');

        for (var i = 0; i < Object.keys(camerasJson.cameraListDivisibleBy3).length; i++) {
          var row = `<tr>
                      <td>${camerasJson.cameraListDivisibleBy3[i]?.number}</td>
                      <td>${camerasJson.cameraListDivisibleBy3[i]?.camera}</td>
                      <td>${camerasJson.cameraListDivisibleBy3[i]?.latitude}</td>
                      <td>${camerasJson.cameraListDivisibleBy3[i]?.longitude}</td>
                    </tr>`;
                    // L.marker([camerasJson.cameraListDivisibleBy3[i]?.latitude, camerasJson.cameraListDivisibleBy3[i]?.longitude]).addTo(map);
                    cameraDivisibleBy3Table.innerHTML += row;
        }

        for (var i = 0; i < Object.keys(camerasJson.cameraListDivisibleBy5).length; i++) {
            var row = `<tr>
                        <td>${camerasJson.cameraListDivisibleBy5[i]?.number}</td>
                        <td>${camerasJson.cameraListDivisibleBy5[i]?.camera}</td>
                        <td>${camerasJson.cameraListDivisibleBy5[i]?.latitude}</td>
                        <td>${camerasJson.cameraListDivisibleBy5[i]?.longitude}</td>
                      </tr>`;
                    //   L.marker([camerasJson.cameraListDivisibleBy5[i]?.latitude, camerasJson.cameraListDivisibleBy5[i]?.longitude]).addTo(map);
                      cameraDivisibleBy5Table.innerHTML += row;
          }

          for (var i = 0; i < Object.keys(camerasJson.cameraListDivisibleBy3And5).length; i++) {
            var row = `<tr>
                        <td>${camerasJson.cameraListDivisibleBy3And5[i]?.number}</td>
                        <td>${camerasJson.cameraListDivisibleBy3And5[i]?.camera}</td>
                        <td>${camerasJson.cameraListDivisibleBy3And5[i]?.latitude}</td>
                        <td>${camerasJson.cameraListDivisibleBy3And5[i]?.longitude}</td>
                      </tr>`;
                    //   L.marker([camerasJson.cameraListDivisibleBy3And5[i]?.latitude, camerasJson.cameraListDivisibleBy3And5[i]?.longitude]).addTo(map);
                      cameraDivisibleBy3And5Table.innerHTML += row;
          }

          for (var i = 0; i < Object.keys(camerasJson.cameraListNotDivisibleBy3And5).length; i++) {
            var row = `<tr>
                        <td>${camerasJson.cameraListNotDivisibleBy3And5[i]?.number}</td>
                        <td>${camerasJson.cameraListNotDivisibleBy3And5[i]?.camera}</td>
                        <td>${camerasJson.cameraListNotDivisibleBy3And5[i]?.latitude}</td>
                        <td>${camerasJson.cameraListNotDivisibleBy3And5[i]?.longitude}</td>
                      </tr>`;
                    //   L.marker([camerasJson.cameraListNotDivisibleBy3And5[i]?.latitude, camerasJson.cameraListNotDivisibleBy3And5[i]?.longitude]).addTo(map);
                      cameraNotDivisibleBy3And5Table.innerHTML += row;
          }
        }
    }