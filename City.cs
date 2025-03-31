namespace ConPop
{
    public class City
    {



        public City(string cityCode, string cityName, int y2010, int y2020, int y2030, int y2040, int y2050)
        {
            this.cityCode = cityCode;
            this.cityName = cityName;
            this.y2010 = y2010;
            this.y2020 = y2020;
            this.y2030 = y2030;
            this.y2040 = y2040;
            this.y2050 = y2050;
        }

        public string cityCode { get; set; }
        public string cityName { get; set; }
        public int y2010 { get; set; }
        public int y2020 { get; set; }
        public int y2030 { get; set; }
        public int y2040 { get; set; }
        public int y2050 { get; set; }
    }
}