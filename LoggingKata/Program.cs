using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Diagnostics;


namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");
               var lines = File.ReadAllLines(csvPath);
               if (lines.Length <= 0)
                {
                    logger.LogInfo("ERROR: Contains 1 or less lines from files");
                }
            logger.LogInfo($"Lines: {lines[0]}");
            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse).ToArray();
            ITrackable tacoBellStores1 = null;
            ITrackable taceBellStores2 = null;
            double distance = 0;
            for (var i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                GeoCoordinate corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    GeoCoordinate corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);
                    if (distance < corA.GetDistanceTo(corB))
                    {
                        distance = corA.GetDistanceTo(corB);
                        tacoBellStores1 = locA;
                        taceBellStores2 = locB;
                    }
                }
            }
            Console.WriteLine($"The two TacoBells that are furthest away from each other are {tacoBellStores1.Name} and {taceBellStores2.Name}");


        }
    }
}
