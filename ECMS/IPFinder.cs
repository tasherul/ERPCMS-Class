using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ECMS.Cookies;
using ECMS.WebPage;
namespace ECMS
{
    public class IPFinder
    {
        
        public IPFinder()
        {
            IPDetails();
        }
        
        public string Status;
        public string Country;
        public string CountryCode;
        public string Region;
        public string RegionName;
        public string City;
        public string Zip;
        public string Lactitute;
        public string Longitude;
        public string TimeZone;
        public string ISP;
        public string Organization;
        public string As;
        public string IP;
        private string getIP()
        {
            
            string Address = "";
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = request.GetResponse())
            using (StreamReader stram = new StreamReader(response.GetResponseStream()))
            {
                Address = stram.ReadToEnd();
            }
            int first = Address.IndexOf("Address: ") + 9;
            int last = Address.IndexOf("</body>");
            Address = Address.Substring(first, last - first);
            return Address;
        }
        private string IPRequestHelper(string url)
        {
            HttpWebRequest objreq = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse objres = (HttpWebResponse)objreq.GetResponse();
            StreamReader responser = new StreamReader(objres.GetResponseStream());
            string responserd = responser.ReadToEnd();
            responser.Close();
            responser.Dispose();
            return responserd;
        }
        private void __IPDetails()
        {
            string ipaddress = getIP();
            string ipResponse = IPRequestHelper("http://ip-api.com/xml/" + ipaddress);
            XmlDocument ipInfoxml = new XmlDocument();
            ipInfoxml.LoadXml(ipResponse);
            XmlNodeList respnseXML = ipInfoxml.GetElementsByTagName("query");
            Status = respnseXML.Item(0).ChildNodes[0].InnerText.ToString();
            Country = respnseXML.Item(0).ChildNodes[1].InnerText.ToString();
            CountryCode = respnseXML.Item(0).ChildNodes[2].InnerText.ToString();
            Region = respnseXML.Item(0).ChildNodes[3].InnerText.ToString();
            RegionName = respnseXML.Item(0).ChildNodes[4].InnerText.ToString();
            City = respnseXML.Item(0).ChildNodes[5].InnerText.ToString();
            Zip = respnseXML.Item(0).ChildNodes[6].InnerText.ToString();
            Lactitute = respnseXML.Item(0).ChildNodes[7].InnerText.ToString();
            Longitude = respnseXML.Item(0).ChildNodes[8].InnerText.ToString();
            TimeZone = respnseXML.Item(0).ChildNodes[9].InnerText.ToString();
            ISP = respnseXML.Item(0).ChildNodes[10].InnerText.ToString();
            Organization = respnseXML.Item(0).ChildNodes[11].InnerText.ToString();
            As = respnseXML.Item(0).ChildNodes[12].InnerText.ToString();
            IP = respnseXML.Item(0).ChildNodes[13].InnerText.ToString();

        }
        private void __IPDetails(string IP)
        {
            string ipaddress = IP;
            string ipResponse = IPRequestHelper("http://ip-api.com/xml/" + ipaddress);
            XmlDocument ipInfoxml = new XmlDocument();
            ipInfoxml.LoadXml(ipResponse);
            XmlNodeList respnseXML = ipInfoxml.GetElementsByTagName("query");
            Status = respnseXML.Item(0).ChildNodes[0].InnerText.ToString();
            Country = respnseXML.Item(0).ChildNodes[1].InnerText.ToString();
            CountryCode = respnseXML.Item(0).ChildNodes[2].InnerText.ToString();
            Region = respnseXML.Item(0).ChildNodes[3].InnerText.ToString();
            RegionName = respnseXML.Item(0).ChildNodes[4].InnerText.ToString();
            City = respnseXML.Item(0).ChildNodes[5].InnerText.ToString();
            Zip = respnseXML.Item(0).ChildNodes[6].InnerText.ToString();
            Lactitute = respnseXML.Item(0).ChildNodes[7].InnerText.ToString();
            Longitude = respnseXML.Item(0).ChildNodes[8].InnerText.ToString();
            TimeZone = respnseXML.Item(0).ChildNodes[9].InnerText.ToString();
            ISP = respnseXML.Item(0).ChildNodes[10].InnerText.ToString();
            Organization = respnseXML.Item(0).ChildNodes[11].InnerText.ToString();
            As = respnseXML.Item(0).ChildNodes[12].InnerText.ToString();
            IP = respnseXML.Item(0).ChildNodes[13].InnerText.ToString();
        }


        public void IPDetails()
        {
            __IPDetails();
        }
        public void IPDetails(string IP)
        { __IPDetails(IP); }
        public string IPAddress()
        { return getIP(); }


    }
}
