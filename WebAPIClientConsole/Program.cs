//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using WebAPIClientConsole;

Console.WriteLine("API CLIENT");
EmployeeAPIClient.CallGetAllEmployee().Wait();
Console.ReadLine();

