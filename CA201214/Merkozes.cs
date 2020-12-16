using System;
using System.Linq;

namespace CA201214
{
    public struct Merkozes
    {
        public string HazaiCsapat; // hazai
        public string IdegenCsapat; // idegen
        public byte HazaiPont; // hazai_pont
        public byte IdegenPont; // idegen_pont
        public string Helyszin; // helyszín
        public DateTime Idopont; // időpont

        public static explicit operator Merkozes(string csvLine)
        {
            var lineValues = csvLine.Split(';');
            var dateArray = lineValues[5].Split('-').Select(int.Parse).ToArray();

            return new Merkozes()
            {
                HazaiCsapat = lineValues[0],
                IdegenCsapat = lineValues[1],
                HazaiPont = byte.Parse(lineValues[2]),
                IdegenPont = byte.Parse(lineValues[3]),
                Helyszin = lineValues[4],
                Idopont = new DateTime(dateArray[0], dateArray[1], dateArray[2])
            };
        }
    }
}