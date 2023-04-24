# CLI
## To use the code, follow these steps:
Open a console application in your IDE (Integrated Development Environment), such as Visual Studio.
Replace the Main method with the provided code.
Build and run the console application.
Pass command line arguments when running the application. For example:

```
myConsoleApp.exe -n Neude
```
or
```
myConsoleApp.exe --name Mariastraat
```
The code will process the provided arguments and display the camera data from a CSV file based on the argument provided. If no arguments are provided, it will display a message stating "No arguments provided." If an unrecognized argument is provided, it will display an error message.


# Camera API
RESTful API built using ASP.NET Core for retrieving camera data from a CSV file.
Installation: Clone repository, open in compatible IDE, build, and run with configured hosting method.
Endpoints:
GET /api/cameras: Retrieves list of cameras, optional searchTerm parameter for filtering.
Example:
```
GET https://localhost:7063/api/cameras?searchTerm=Neude
```

# Website (JavaScript)
## Camera Data Renderer 
renderData(data): Renders data onto HTML table columns based on the number property in each data item.
fetchData(searchTerm=""): Fetches data from an API endpoint, optionally filtered by search term, and calls renderData(data) and renderMarkers(data) functions.
renderMarkers(data): Renders markers on a Leaflet map based on fetched data, displaying camera details.
searchCameraName: Variable storing search term for data filtering.
fetchData(searchCameraName): Fetches and renders data based on searchCameraName, initially set as an empty string. Called on page load.


# CameraCsvDataReader library
CameraCsvDataReader contains a class for reading CSV data.
Class: CameraCsvDataReader reads CSV data and has methods for filtering and extracting camera data.
Method: ReadCsv(string cameraName = null) : List<CameraDto> reads CSV data and returns a list of CameraDto objects. Optional cameraName parameter can be used for filtering.
Method: RemoveNonNumeric(string value) : string removes non-numeric characters from a string using regex.
Enum: Cameras represents column indices in the CSV file.
Values: Name (index 0), Latitude (index 1), Longitude (index 2).

Note: Make sure that the API is running for the web application requirement.