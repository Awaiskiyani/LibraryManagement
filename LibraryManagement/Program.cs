using LibraryManagement;
using LibraryManagement.Models;
using LibraryManagement.Repo;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;

internal class Program
{


    public static void Main(string[] args)
    {

        var collection = new ServiceCollection();
        collection.AddScoped<IServices, Services>();
         collection.BuildServiceProvider();




        while (true)
        {
            IServices services = new Services();

            Console.Clear();
            Console.WriteLine("Library Manangement");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Exit");
            Console.WriteLine("Choose any option");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    services.Login();
                    
                    
                    break;
                case "2":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Input! Please Try again");
                    break;

            }
            
            Console.ReadKey();
        
        }

    }
}