namespace ConPop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //A kapott CSV állomány Európa nagyobb városainak a korábbi és a jövőbeli becsült népességszámait tartalmazza.
            // CITY_CODE;CITY_NAME;Y2010;Y2020;Y2030;Y2040;Y2050
            CityDataProvider cityDataProvider = new();
            cityDataProvider.LoadFromCSV("pop_city.csv");


            //todo: 1F Készítsen osztályt egy város adatainak tárolására! (City)
            //todo: 2F Készítsen (CityDataProvider) néven osztályt a városok adatainak kezelésére, ami a megadott (CitiesMethods) interfészt implementálja!

            //todo: Válaszoljon a következő kérdésekre a korábban létrehozott osztályok felhasználásával!

            //todo: 3F Hány város adatait tartalmazza a CSV fájl? (CityCount)

            Console.WriteLine(cityDataProvider.CityCount());
            //todo: 4F Melyik 10 város volt a legnépesebb 2020-ban? (Top10City)

            Console.WriteLine(cityDataProvider.Top10City(2020));

            //todo: 5F Kérje be billentyűzetről egy város nevét! Ha nem létezik, akkor jelezze azt és kérje be újra! 
            //         Miután létező nevet adott meg, döntse el, hogy a város lakossága folyamatosan növekedett-e az évek alatt? (IsContinuousGrowing)
            string varosnev = "";
            do
            {
                Console.Write("Kérek egy város nevet:");

                varosnev = Console.ReadLine();
            }
            while (cityDataProvider.cities.FirstOrDefault(x => x.cityName.ToLower() == varosnev.ToLower()) == null);
            var cityData = cityDataProvider.cities.FirstOrDefault(x => x.cityName.ToLower() == varosnev.ToLower());
            List<int> cityPop = new List<int>([cityData.y2010, cityData.y2020, cityData.y2030, cityData.y2040, cityData.y2050]);
            bool isGrowing = cityDataProvider.IsContinuousGrowing(cityPop);

            if (isGrowing)
            {
                Console.WriteLine("Növekszik");
            }
            else
            {
                Console.WriteLine("Nem növekszik");
            }

            //todo: 6F Írja (bigCities.CSV) fájlba a 2020-ban 1 millió főnél nagyobb népességgel rendelkező városokat! (SaveToCSV)
            var filteredList = cityDataProvider.cities.Where(x => x.y2020 >= 1000000).ToList();
            cityDataProvider.SaveToCSV("bigCities.csv",filteredList);

            //todo: 7F Írassa képernyőre azoknak a városoknak a nevét és népességváltozását, ahol 2050-ben kevesebben lesznek mint 2010-ben voltak!
            //todo:    A kiíratás népességcsökkenés szerint növevően rendezetten történjen! 
            //todo:    Tipp: Érdemes megfelelő metódussal vagy property-vel bővíteni az osztályt! (CityDataProvider)
        }
    }
}
