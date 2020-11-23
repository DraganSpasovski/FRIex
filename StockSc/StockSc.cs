using System;
using HtmlAgilityPack;
using System.IO;
using System.Net;
using Microsoft.Data.Analysis;

namespace web.StockSc
{
    class StockSc
    {
        public static string[] ScraperInnit(string type)
        {
                    var url = @"https://finance.yahoo.com/gainers/";
                    string[] topstocks = new string[5];
                    HtmlWeb web = new HtmlWeb();
                    var htmlDoc = web.Load(url);
                    var c = 0;
                    foreach(var item in htmlDoc.DocumentNode.SelectNodes("//a[@class = 'Fw(600) C($linkColor)']")){
                    if(c<5)
                    {
                        Scraper(item.InnerHtml,c,type);
                        topstocks[c] = item.InnerHtml;
                        c++;
                    }
            }
            return topstocks;
        }
        public static void Scraper(string stockName,int i,string type){
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://" + $@"www.alphavantage.co/query?function=TIME_SERIES_{type}&symbol={stockName}&apikey=JE0YWX3K4SH49TG2&datatype=csv");
                    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                    StreamReader sr = new StreamReader(resp.GetResponseStream());
                    string results = sr.ReadToEnd();
                    File.WriteAllText($@"C:\Users\Froze\Desktop\Faks\Inform. Sistemi\FRIexx\web\Data\Stocks\{i}{stockName}data{type}.csv", results);
                    sr.Close();

        }
                    
        }
    }
