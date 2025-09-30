using Thinksoft.Patterns.Structural.Adapter.Model;

namespace Thinksoft.Patterns.Structural.Adapter.Adapter.Test
{
    [TestClass()]
    public class TrackIPLocByHttpTest
    {
        private TrackIPLocByHttp httpAdapter;

        [TestInitialize]
        public void Setup()
        {
            httpAdapter = new TrackIPLocByHttp();
        }

        [TestMethod()]
        public async Task TestHttpConnectionIsOK()
        {
            string ipAddr = "219.85.79.131";    // local
            //string ipAddr = "142.251.42.238";   // google.com
            //string ipAddr = "54.239.28.85";    // amazon.com

            var taskIPModel = httpAdapter.GetIPLocation(ipAddr);
            IPLocationModel locationModel = taskIPModel.Result;

            #region Console output
            Console.WriteLine("IP Address: {0}", locationModel.IP);
            Console.WriteLine("Country Code: {0}", locationModel.CountryCode);
            Console.WriteLine("Country Name: {0}", locationModel.CountryName);
            Console.WriteLine("Region Code: {0}", locationModel.RegionCode);
            Console.WriteLine("Region Name: {0}", locationModel.RegionName);
            Console.WriteLine("City: {0}", locationModel.City);
            Console.WriteLine("Zip Code: {0}", locationModel.ZipCode);
            Console.WriteLine("Time Zone: {0}", locationModel.TimeZone);
            Console.WriteLine("Latitude: {0}", locationModel.Latitude);
            Console.WriteLine("Longitude: {0}", locationModel.Longitude);            
            #endregion

            Assert.IsTrue(taskIPModel.IsCompleted);
        }
    }
}