using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.ServiceModel;
using System.Diagnostics;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strError = string.Empty;
            try
            {
                EndpointAddress endpoint =new EndpointAddress("http://ncsibg.usasoftball.com/BGService.asmx");
                ServiceReference1.WebService1SoapClient webService1 = new ServiceReference1.WebService1SoapClient();
                
                string Status = String.Empty;
                Status = "<?xml version=\"1.0\"?>\r\n<BackgroundReports userId=\"optimuspri_xml\" password=\"St#7evs485rezExiv\" databaseset=\"\">\r\n  <BackgroundReportPackage>\r\n    <ReferenceId><![CDATA[1234567]]></ReferenceId>\r\n    <OrderId>9185891</OrderId>\r\n    <ScreeningStatus>\r\n      <OrderStatus flag=\"FALSE\">x:ready</OrderStatus>\r\n      <OrderDecision>(NCSI) Clear</OrderDecision>\r\n    </ScreeningStatus>\r\n    <Screenings>\r\n      <Screening>\r\n        <ScreeningResults type=\"result\" mediaType=\"PDF\" resultType=\"report\">\r\n          <InternetWebAddress><![CDATA[https://ncsi.instascreen.net/editor/viewReport.taz?file=9185891&format=pdf]]></InternetWebAddress>\r\n        </ScreeningResults>\r\n      </Screening>\r\n    </Screenings>\r\n  </BackgroundReportPackage>\r\n</BackgroundReports>";

                //string xml = string.Empty;
                //xml = "<?xml version='1.0'?><BackgroundReports userId='optimuspri_xml' password='St#7evs485rezExiv'><BackgroundReportPackage><ReferenceId>12345678</ReferenceId>";
                //xml = xml + "<OrderId>12358</OrderId><ScreeningStatus><OrderStatus flag='FALSE'>x:ready</OrderStatus><OrderDecision>Clear</OrderDecision></ScreeningStatus><Screening>";


                //xml = xml + "<ScreeningResults type='result' mediaType='html' resultType='report'><InternetWebAddress>https://demo.instascreen.net/s</InternetWebAddress>";
                //xml = xml + "</ScreeningResults></Screening></BackgroundReportPackage></BackgroundReports>";

               
                //XDocument doc = XDocument.Parse(xml);
                XDocument doc = XDocument.Parse(Status);

                var response = webService1.BGStatus(doc.ToString());
               Console.WriteLine("response: " + response);

                Console.Read(); //to keep window open, for debugging only


            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string text = reader.ReadToEnd();
                    Console.WriteLine(text);
                    // text will contain the response from the server
                    if (ex.Message != null)
                    {
                        strError = ex.Message;
                    }
                    throw;
                }
            }


        }
    }
}
