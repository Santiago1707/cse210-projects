using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new StationaryBicycles(new DateTime(2022, 11, 3), 30, 9.7),
            new Swimming(new DateTime(2022, 11, 3), 30, 60)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}