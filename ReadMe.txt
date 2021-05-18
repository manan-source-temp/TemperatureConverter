

Sorry for inconvenient name of the folder

I have put both project Angular (UI) and ASP.NET CORE in same project. Name of angular folder is EmployeManagement.
I have created End pont and business logic teste cases. Folder name is EmployeeManagementTest
Business logic put into EmployeManagement.BLL folder
API End points controller folder name is EmployeManagementDemo


I have used directive feature for allow only number in temperature value in angular.


I have created TemperatureConverterApp for end points
Thre is Get end points which has three paramter like temperatureValue, oldTemperatureType and currenTemperatureType
temperatureValue is user enter value from UI side
oldTemperatureType is old value which is selected from items
currenTemperatureType is value that is selected from temperature converter items list


URL - http://localhost:64206/api/Temperature/{temperatureValue}/{oldTemperatureType}/{currenTemperatureType}


Temperature
Celsius - c
Fahrenheit - f
Kelvin - k

1. Fahrenheit to Celsius 
http://localhost:64206/api/Temperature/11/f/c/
-11.666666666666668

2. Celsius to Fahrenheit
http://localhost:64206/api/Temperature/11/c/f/
51.8

3. Celsius to Kelvin
http://localhost:64206/api/Temperature/11/c/k/
284.15

4. Kelvin to Celsius 
http://localhost:64206/api/Temperature/11/k/c/
-262.15

5.Kelvin to Fahrenheit
http://localhost:64206/api/Temperature/11/k/f/
-439.86999999999995


6.Fahrenheit to Kelvin 
http://localhost:64206/api/Temperature/11/f/k/
261.48333333333329

If TemperatureType type is empty, it will throw below error
http://localhost:64206/api/Temperature/11/%22%22/k/
"Please select proper temperature converter type"


If TemperatureType type is same, it will throw below error
http://localhost:64206/api/Temperature/11/c/c/
"Temperature converter type cannot same"
