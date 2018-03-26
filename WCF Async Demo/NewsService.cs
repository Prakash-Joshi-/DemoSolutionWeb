using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WCF_Async_Demo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NewsService" in both code and config file together.
    public class NewsService : INewsService
    {
        public List<string> GetGeneralNewsFeed()
        {
            //Delay a bit and return some sample news content
            //Consider the delay as the time taken for parsing the feed in real time
            Thread.Sleep(3000);
            return new List<string>() { "This is general news number 1", "This is general news number 2", "This is general news number 3" };
      
        }

        public List<string> GetSportNewsFeed()
        {
            //Delay a bit and return some sample news content
            //Consider the delay as the time taken for parsing the feed in real time
            Thread.Sleep(3000);
            return new List<string>() { "Some cricket news...", "Some soccer news..." };
       
        }
    }
}
