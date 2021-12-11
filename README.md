# AcmeConsole

The company ACME offers their employees the flexibility to work the hours they want. 
But due to some external circumstances they need to know what employees have been at the office within the same time frame
The goal of this exercise is to output a table containing pairs of employees and how often they have coincided in the office.

## Solution overview🚀

_For the solution, a repository was implemented to read the txt file simulating a database, using the File class of the NameSpace System.IO, we read the lines of the file and with this we make a list of strings (List of lines of the file) We will iterate this list to generate a dictionary in order to separate the name of the employee and the time, taking into account the empty lines._

_If it finds the data, it proceeds to convert that dictionary into an object list to be able to map the properties, this also divides each schedule to create a list of schedules in each employee object, this in order to eterrate between the employees to validate their schedule if they are similar using the day, the start time and the end time._

See **Pre requirements** to know how run the program.


### Pre requirements 📋

Change url path in * Acme.Repository\TxtRepository.cs * file and put path where the project is located.
Inside the Acme.Repository directory there is a "Data" folder that contains the database.txt file

```
private static readonly string _url_txt = @"C:\{project location}\CONSOLE_ACME\Acme.Repository\Data\database.txt";
```

## Author ✒️
* **Randy Dominguez* - [randydmz](https://github.com/SoyRandyDominguez)


---
⌨️ with ❤️ by [randydmz](https://github.com/SoyRandyDominguez)
