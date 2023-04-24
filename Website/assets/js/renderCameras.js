function renderData(data) {
  const column3 = document.getElementById('column3').getElementsByTagName('tbody')[0];
  const column5 = document.getElementById('column5').getElementsByTagName('tbody')[0];
  const column15 = document.getElementById('column15').getElementsByTagName('tbody')[0];
  const columnOther = document.getElementById('columnOther').getElementsByTagName('tbody')[0];

  // Loop through the data and append rows to the appropriate columns
  for (let i = 0; i < data.length; i++) {
    const number = data[i].number;
    const name = data[i].name;
    const latitude = data[i].latitude;
    const longitude = data[i].longitude;

    // Determine which column to append the row based on the number
    if (number % 3 === 0 && number % 5 === 0) {
      const row = document.createElement('tr');
      row.innerHTML = `<td>${number}</td><td>${name}</td><td>${latitude}</td><td>${longitude}</td>`;
      column15.appendChild(row);
    } else if (number % 3 === 0) {
      const row = document.createElement('tr');
      row.innerHTML = `<td>${number}</td><td>${name}</td><td>${latitude}</td><td>${longitude}</td>`;
      column3.appendChild(row);
    } else if (number % 5 === 0) {
      const row = document.createElement('tr');
      row.innerHTML = `<td>${number}</td><td>${name}</td><td>${latitude}</td><td>${longitude}</td>`;
      column5.appendChild(row);
    } else {
      const row = document.createElement('tr');
      row.innerHTML = `<td>${number}</td><td>${name}</td><td>${latitude}</td><td>${longitude}</td>`;
      columnOther.appendChild(row);
    }
  }
}
async function fetchData(searchTerm="") {
  let param = "";
  if (searchTerm !== "") {
    param = `/search?searchTerm=${searchTerm}`;
  }

  try {
    const response = await fetch(`https://localhost:7063/api/cameras${param}`);
    const data = await response.json();
    renderData(data);
    renderMarkers(data);
  } catch (error) {
    console.error(`Error fetching data: ${error}`);
  }
}

function renderMarkers(data) {
  const map = L.map('map').setView([52.0914, 5.1115], 14); // Set initial map view to Utrecht
  L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '© OpenStreetMap contributors'
  }).addTo(map);

  // Loop through the data and add markers to the map
  for (let i = 0; i < data.length; i++) {
    const number = data[i].number;
    const name = data[i].name;
    const latitude = data[i].latitude;
    const longitude = data[i].longitude;

    if(number!=""){
      const marker = L.marker([latitude, longitude]).addTo(map)
        .bindPopup(`<b>Camera ${number}</b><br>Name: ${name}<br>Latitude: ${latitude}<br>Longitude: ${longitude}`)
        .openPopup();
    }
  }
  
}


let searchCameraName = ""; // In case you want to look on camera 
fetchData(searchCameraName);