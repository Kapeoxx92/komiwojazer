using Newtonsoft.Json;
using System.Drawing;


namespace komiwojazer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w komiwojazer");
            string Path = @"C:\Users\K1\Desktop\data.json";

            ReadJson readerJson = new ReadJson(Path);
            List<city> citiesToVisit = readerJson.ReadJsonToList();

            Console.WriteLine(citiesToVisit[0].name);
            Console.WriteLine(citiesToVisit.Count);


            ///*w pętli
            // * citiesToVisit[i].printcity();
            // * 
            // * 
            // */
            //int i = 0;
            //while (i <= 99)
            //{
            //    citiesToVisit[i].printcity();

            //    i++;
            //}
            //for (int y = 0; y < citiesToVisit.Count; y++)
            //{
            //    citiesToVisit[y].printcity();
            //}

            /*
             * int odleglosc = cityToVisit[0].calculateDistance(4,3);
             * Console.WriteLine(odleglosc.ToString())*/
            //double distance12 = citiesToVisit[1].countDistance(27, -8);
            double distance12 = citiesToVisit[1].countDistance(citiesToVisit[2]);
            citiesToVisit[0].fillDistanceList(citiesToVisit);
            citiesToVisit[0].printDistanceList();

            Console.WriteLine(distance12);
        }

        public class city
        {
            public string name = string.Empty;
            public int x;
            public int y;
            public List<double> distanceList = new List<double>();
            //Console.WriteLine(city.);

            public void fillDistanceList(List<city> cities)
            {
                int i = 0;
                while(i < cities.Count())
                {
                    this.distanceList.Add(this.countDistance(cities[i]));
                    i++;
                }
                
            }

            public void printDistanceList()
            {
                int i = 0;
                while(i < this.distanceList.Count())
                {
                    Console.WriteLine(this.distanceList[i]);
                    i++;
                }
            }

            public void printcity()
            {
                string city_data = "name: " + this.name + "\n x: " + this.x.ToString() + "\n y: " + this.y .ToString();
                Console.WriteLine(city_data);
            }

            public double countDistance(int x_secondCity,int y_secondCity)
            {
                double distance = 0;
                //double x_secondCity_double, y_secondCity_double, x_this_city, y_this_city;
                //x_secondCity_double = (double)x_secondCity;
                //y_secondCity_double = (double)y_secondCity;
                //x_this_city = (double)this.x;
                //y_this_city = (double)this.y;
                distance = Math.Sqrt(Math.Pow(x_secondCity - this.x, 2) + Math.Pow(y_secondCity - this.y, 2));

                return distance;
            }


            public double countDistance(city cityName)
            {
                double distance = 0;
                distance = Math.Sqrt(Math.Pow(cityName.x - this.x, 2) + Math.Pow(cityName.y - this.y, 2));


                return distance;
            }

        }

        public class ReadJson
        {
            private readonly string JsonPath;

            public ReadJson(string path)
            {
                JsonPath = path;
            }

            public List<city> ReadJsonToList()
            {
                using StreamReader reader = new(JsonPath);
                var json = reader.ReadToEnd();
                List<city> result = JsonConvert.DeserializeObject<List<city>>(json);
                return result;
            }
        
        }
    }
}
