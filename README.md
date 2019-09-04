# Employee
A dll library for consuming csv file for employees

how to used the libray
TakeCSV() is a method that consuming the csv file, the user will be prompted to choose the path where the .csv file is located. The code will check if the .csv file contains three columns, the first and second columns are of string type while the third column for salary is of long type
ReadData() is an instance that read out the salary for an Employee, the instance require Employeeid as a parameter for parsing through the .csv file. The id accept only a string type.
Note:  
	namespace :  Employee
	class: Employees
