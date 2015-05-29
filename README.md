# DanishHolidays.NET
A small library that calculates the danish holidays based on a given year.

##Getting Started
DanishHolidays.NET is available on NuGet.
```
Install-Package DanishHolidays-NET 
```

Or 

you can [download](https://github.com/VisualBean/DanishHolidays.NET/archive/master.zip "download") this project as a zip and add src/DanishHolidays.Net.dll as a reference to your project
##Usage

Get list of holidays for current year
```c#
var holidays = DanishHolidays.GetHolidays();
```

Get list of holidays for year ```Int```
```c#
var holidays = DanishHolidays.GetHolidays(1997);
```

Check if date is a holiday
```c#
var date = new DateTime(1997,12,24);
if(date.Isholiday())
{
 //Its a holiday
}
```

Check if date is a holiday & Get holiday out
```c#
var date = new DateTime(1997,12,24);
var holiday = new HolidayModel();
if(date.Isholiday(out holiday)) //Returns True
{
 Console.WriteLine(holiday.Name); //Returns "Juleaften"
}
```