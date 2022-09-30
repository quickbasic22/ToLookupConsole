using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLookupConsole.Models
{
    public class LookupPack
    {
        public static void LookupExample()
        {
            List<Package> packages = new List<Package>
            {
                new Package { Company = "Coho Vineyard", Weight = 25.2, TrackingNumber = 894533121L },
                new Package { Company = "Lucerne Publishing", Weight = 18.7, TrackingNumber = 89112755L },
                new Package { Company = "Wingtip Toys", Weight = 6.0, TrackingNumber = 299456122L },
                new Package { Company = "Wide World Importers", Weight = 33.8, TrackingNumber = 4665518773L }
            };
            Lookup<char, string> lookup = (Lookup<char, string>)packages.ToLookup(p => Convert.ToChar(p.Company.Substring(0, 1)),
                p => p.Company + " " + p.TrackingNumber);

            foreach (IGrouping<char, string> packageGroup in lookup)
            {
                Console.WriteLine(packageGroup.Key);
                foreach (string str in packageGroup)
                {
                    Console.WriteLine("     {0}", str);
                }
            }

            int count = lookup.Count;

            IEnumerable<string> cgroup = lookup['C'];

            Console.WriteLine("\nPackages that have a key of 'C':");
            foreach (string str in cgroup)
                Console.WriteLine(str);

            bool hasG = lookup.Contains('G');
        }
    }
}
