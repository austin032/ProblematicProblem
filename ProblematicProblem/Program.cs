using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem{

public partial  class Program
{
    public static Random rng = new Random(); 
       public static bool cont = true;
        





       public static  List<string> activities = new List<string>()
    { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

static void Main(string[] args)
{
    Console.Write(
        "Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
             var userResponse = Console.ReadLine().ToLower();
    Console.WriteLine();
    Console.Write("We are going to need your information first! What is your name? ");
    string userName = Console.ReadLine();
    Console.WriteLine();
    Console.Write("What is your age? ");
    var userAge = int.Parse(Console.ReadLine());
    Console.WriteLine();
    Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
    userResponse = Console.ReadLine().ToLower();

    while (userResponse != "sure" && userResponse != "no")
    {
        Console.WriteLine("That was not a valid response. Please try again.");
    }
    if (userResponse == "sure")
    {
        foreach (string activity in activities)
        {
            Console.Write($"{activity} ");
            Thread.Sleep(250);
        }
        Console.WriteLine();
        Console.Write("Would you like to add any activities before we generate one? yes/no: ");
        userResponse = Console.ReadLine().ToLower();
        Console.WriteLine();
        while (userResponse != "no" && userResponse != "yes")
        {
            Console.Write("What would you like to add? ");
            string userAddition = Console.ReadLine();
            activities.Add(userAddition);
            foreach (string activity in activities)
            {
                Console.Write($"{activity} ");
                Thread.Sleep(250);
            }
            Console.WriteLine();
            Console.WriteLine("Would you like to add more? yes/no: ");
            var addToList = bool.Parse(Console.ReadLine());
        }
    }

    while (cont)
    {
        Console.Write("Connecting to the database");
        for (int i = 0; i < 10; i++)
        {
            Console.Write(". ");
            Thread.Sleep(500);
        }

        Console.WriteLine();
                Console.Write("Choosing your random activity");
        for (int i = 0; i < 9; i++)
        {
            Console.Write(". ");
            Thread.Sleep(500);
        }

        Console.WriteLine();
                int number = rng.Next(activities.Count);
                string randomActivity = activities[number];
                if (userAge > 21 && randomActivity == "Wine Tasting")
        {
            Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
            Console.WriteLine("Pick something else!");
            activities.Remove(randomActivity);
            var randomNumber = rng.Next(activities.Count);
            randomActivity = activities[randomNumber];
        }

        Console.Write(
            $"Ah got it! {randomActivity}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                
        userResponse = Console.ReadLine().ToLower();

        while (userResponse != "keep" && userResponse != "redo")
        {
            Console.Write("This is not a valid choice . Please try again.");
        }

        if (userResponse == "keep")
        {
            cont = false;
        }
    }
}
    }
}