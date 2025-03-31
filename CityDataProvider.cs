using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConPop
{
    class CityDataProvider : ICityMethods
    {
        public List<City> cities = new List<City>();
        public void LoadFromCSV(string path)
        {
            cities.Clear();
            File.ReadAllLines(path).Skip(1).ToList().ForEach(x =>
            {
                string[] lines = x.Split(";");
                cities.Add( new City
                (
                    lines[0],
                    lines[1],
                    int.Parse(lines[2]),
                    int.Parse(lines[3]),
                    int.Parse(lines[4]),
                    int.Parse(lines[5]),
                    int.Parse(lines[6])
                ));
                
            });
        }
        public int CityCount()
        {
            return cities.Count;
        }

        public bool IsContinuousGrowing(List<int> populationDatas)
        {
            for (int i = 0; i < populationDatas.Count - 1; i++)
            {
                if (i <= i+1)
                {
                    return false;
                }
            }
            return true;
        }



        public void SaveToCSV(string path, List<City> cities, string charCode = "UTF-8")
        {
            string wr = "";

            foreach (var item in cities)
            {
                wr += $"{item.cityName};{item.cityCode};{item.y2010};{item.y2020};{item.y2030};{item.y2040};{item.y2050}\n";
            }

            File.WriteAllText(path, wr);
        }

        public List<City> Top10City(int year)
        {
            switch (year)
            {
                case 2010:
                   return cities.OrderByDescending(x => x.y2010).Take(10).ToList();
                case 2020:
                    return cities.OrderByDescending(x => x.y2020).Take(10).ToList();
                case 2030:
                    return cities.OrderByDescending(x => x.y2030).Take(10).ToList();
                case 2040:
                    return cities.OrderByDescending(x => x.y2040).Take(10).ToList();
                case 2050:
                    return cities.OrderByDescending(x => x.y2050).Take(10).ToList();
                default:
                    break;
            }

            return cities;
        }
    }
}
