﻿﻿// ask for input
Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
string? resp = Console.ReadLine();
if (resp == "1")
{
        // create data file
    // ask a question
    Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    int weeks = Convert.ToInt32(Console.ReadLine());
        // determine start and end date
    DateTime today = DateTime.Now;
    // we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    // subtract # of weeks from endDate to get startDate
    DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
        // random number generator
    Random rnd = new();
    // create file
    StreamWriter sw = new("data.txt");

    // loop for the desired # of weeks
    while (dataDate < dataEndDate)
    {
        // 7 days in a week
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            // generate random number of hours slept between 4-12 (inclusive)
            hours[i] = rnd.Next(4, 13);
        }
        // M/d/yyyy,#|#|#|#|#|#|#
        // Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
        sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
        // add 1 week to date
        dataDate = dataDate.AddDays(7);
    }
    sw.Close();
}
else if (resp == "2")
{
    if (File.Exists("data.txt"))
    {
        string[] lines = File.ReadAllLines("data.txt");
        foreach (var line in lines)
        {
            //grabs info from data.txt and makes it usable
            string[] parts = line.Split(',');
            string date = parts[0];
            string hoursData = parts[1];
            string[] hours = hoursData.Split('|');

            DateTime sDate = DateTime.ParseExact(date, "M/d/yyyy", null);

            Console.WriteLine($"Week of {sDate:MMM}, {sDate:dd}, {sDate:yyyy}");
            Console.WriteLine(" Su Mo Tu We Th Fr Sa");
            Console.WriteLine(" -- -- -- -- -- -- --");

            foreach (var hour in hours)
            {
                Console.Write($" {hour,2}");
            }
            Console.WriteLine();
        }
    }
}
