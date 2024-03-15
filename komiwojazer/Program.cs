using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;


namespace komiwojazer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w komiwojazer");
            string Path = @"C:\Users\K1\Desktop\data.json";
            List<int> visitedCities = new List<int>();

            ReadJson readerJson = new ReadJson(Path);
            List<city> citiesToVisit = readerJson.ReadJsonToList();

            //int minimumValueIndex = citiesToVisit.IndexOf(citiesToVisit.Min());

            //Console.WriteLine(citiesToVisit[0].name);
            // Console.WriteLine(citiesToVisit.Coun

            for (int y = 0; y < citiesToVisit.Count; y++)
            {
                //citiesToVisit[y].printcity();
                citiesToVisit[y].fillDistanceList(citiesToVisit);
            }

            Console.WriteLine("Wpisz miasto startowe");
            string startCity = Console.ReadLine();

            for (int y = 0; y < citiesToVisit.Count; y++)
            {
                if (startCity == citiesToVisit[y].name)
                {
                    //citiesToVisit[y].visited = true;
                    citiesToVisit[y].visitTheCity();
                    visitedCities.Add(y);
                }
            }

            while (citiesToVisit.Count != visitedCities.Count)
            {
                int next_city = citiesToVisit[visitedCities[visitedCities.Count() - 1]].FindCity(citiesToVisit); // 1. szukamy najbliższego miasta do ostatnio odwiedzonego
                citiesToVisit[next_city].visitTheCity();
                visitedCities.Add(next_city);

            }





            Console.WriteLine("stop");
            /*
             * int odleglosc = cityToVisit[0].calculateDistance(4,3);
             * Console.WriteLine(odleglosc.ToString())*/
            //double distance12 = citiesToVisit[1].countDistance(27, -8);
            //double distance12 = citiesToVisit[1].countDistance(citiesToVisit[2]);
            //citiesToVisit[0].fillDistanceList(citiesToVisit);
            //citiesToVisit[0].printDistanceList();

            //Console.WriteLine(distance12);
        }

        public class city
        {
            public string name = string.Empty;
            public int x;
            public int y;
            public List<double> distanceList = new List<double>();
            private bool visited = false;
            //Console.WriteLine(city.);

            public void visitTheCity()
            {
                this.visited = true;
                string comment = this.name + " has been visited";
                Console.WriteLine(comment);
            }

            public void fillDistanceList(List<city> cities)
            {
                int i = 0;
                while(i < cities.Count())
                {
                    this.distanceList.Add(this.countDistance(cities[i]));
                    i++;
                }
                
            }

            public int FindCity(List<city> otherCities)
            {
                int minimumValueIndex = 0;
                double minimum_value = this.distanceList[0];

                for(int i = 1; i < this.distanceList.Count(); i++)
                {
                    if (this.distanceList[i] < minimum_value  && this.distanceList[i] != 0)
                    {
                        if (otherCities[i].visited == false)
                        {
                            minimum_value = this.distanceList[i];
                            minimumValueIndex = i;
                        }

                    }
                }

                Console.WriteLine("Number miasta ");
                Console.WriteLine(minimumValueIndex);
                Console.WriteLine("odleglosc" );
                Console.WriteLine(distanceList[minimumValueIndex]);
                return minimumValueIndex;
                    
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
