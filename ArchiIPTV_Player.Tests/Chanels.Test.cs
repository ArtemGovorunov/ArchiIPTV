using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArchiIPTV_Player.Tests
{
    [TestClass]
    public class ChanelsTests
    {
        [TestMethod]
        public void GetChanelsFromM3U_DefaultSource_ChanelListReturns()
        {
            string input = @"#EXTM3U m3uautoload=1 cache=1000 deinterlace=1
                            #EXTINF:-1,1+1
                            http://tv.lan.ua/get_stream.php?id=1
                            # EXTINF:-1,2+2
                            http://tv.lan.ua/get_stream.php?id=2
                            # EXTINF:-1,ПлюсПлюс
                            http://tv.lan.ua/get_stream.php?id=3";

            List<Chanel> expected = new List<Chanel> { new Chanel("1+1", "http://tv.lan.ua/get_stream.php?id=1"),
                                  new Chanel("2+2","http://tv.lan.ua/get_stream.php?id=2"),
                                  new Chanel("ПлюсПлюс","http://tv.lan.ua/get_stream.php?id=3")
                                };

            List<Chanel> chanels = Chanels.GetChanelsFromM3U(input);
            Assert.ReferenceEquals(expected, chanels);
        }
        [TestMethod]
        public void GetChanelsFromM3U_EmpySource_Exception()
        {
            string input = "";
            try
            {
                List<Chanel> expected = Chanels.GetChanelsFromM3U(input);
            }
            catch (Exception)
            {
                
                Assert.IsTrue(true);
            }            
        }
    }
}
