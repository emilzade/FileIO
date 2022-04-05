using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Figgle;
using FileIO.Models;
using System.Text.Json.Serialization;

namespace FileIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        

        
        
        
        private static void Menu()
        {
            People people = new People();
            Console.Write("Please enter society name: ");
            string societyName = Console.ReadLine();
            Console.WriteLine(FiggleFonts.Standard.Render($"Welcome  to  {societyName}"));
            ConsoleMenu:
            Console.WriteLine("1.Create new person\n" +
                              "2.Show all existing people\n"+
                              "3.Find existing person by name\n" +
                              "4.Find people within age range\n" +
                              "5.Search people\n" +
                              "0.Exit");
            Console.Write("Enter command: ");
            string menuInput = Console.ReadLine();
            do
            {
                switch (menuInput)
                {
                    case "1":
                    {
                        Console.Clear();
                        people.CreateNewPerson();
                        
                        goto ConsoleMenu;
                    }
                    case "2":
                    {
                        Console.Clear();
                        people.ShowPeopleDetailed();
                        goto ConsoleMenu;
                    }
                    case "3":
                    {
                        Console.Clear();
                        Console.WriteLine("Enter person name you want to find: ");
                        string personName = Console.ReadLine();
                        people.FindPersonByName(personName);
                        goto ConsoleMenu;
                    }
                    case "4":
                    {
                        Console.Clear();
                        PointsInputs:
                        Console.WriteLine("Enter start and end point of page counts...");
                        Console.Write("Start point: ");
                        string startPointInput = Console.ReadLine();
                        Console.Write("End point: ");
                        string endPointInput = Console.ReadLine();
                        int startPoint;
                        int endPoint;
                        try
                        {
                            startPoint = Convert.ToInt32(startPointInput);
                            endPoint = Convert.ToInt32(endPointInput);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Please enter correct input...");
                            goto PointsInputs;
                        }
                        people.FindAllPersonsByAgeRange(startPoint,endPoint);
                        goto ConsoleMenu;
                    }
                    case "5":
                    {
                        Console.Clear();
                        Console.Write("Find in list: ");
                        string value = Console.ReadLine();
                        people.SearchPerson(value);
                        goto ConsoleMenu;
                    }
                        default:
                            Console.Clear();
                            goto ConsoleMenu;
                }
            } while (menuInput != "0");
        }
    }
}
