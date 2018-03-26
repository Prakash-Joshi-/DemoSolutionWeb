using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Async_Demo
{
    class Program
    {
        // http://www.codeguru.com/columns/experts/building-and-consuming-async-wcf-services-in-.net-framework-4.5.htm
        static void Main(string[] args)
        {
            FetcNewsAsync();
            Console.ReadLine();
        }

        private static async void FetcNewsAsync()
        {
            NewsService client = new NewsService();

            //Makes a first async service call
            var task1 = client.GetGeneralNewsFeedAsync();
            //Makes the second async service call and doesn't wait for task1 completion
            var task2 = client.GetSportsNewsFeedAsync();

            //Now awaits for task1
            string[] generalNews = await task1;
            //awaits for task2
            string[] generalSports = await task2;
        }
    }
}
