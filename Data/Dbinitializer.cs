using web.Models;
using System;
using System.Linq;
using web.StockSc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StockContext context)
        {

            

            context.Database.EnsureCreated();
            string[] stonks = new string[5];
            
            // OK, seprau ni mi ratal nardit da se ta koda izvede usake 12 sec, tko da bi lepo prosu, če mau na netu pogledaš kko se da narest.
            stonks = web.StockSc.StockSc.ScraperInnit("DAILY");
            string type = "DAILY";
            


            // Look for any students.
            if (context.Stocks.Any())
            {
                return;   // DB has been seeded
            }
            var c = 0;

            List<Stock> stocks = new List<Stock>();

            List<Stock2> stocks2 = new List<Stock2>();

            List<Stock3> stocks3 = new List<Stock3>();

            List<Stock4> stocks4 = new List<Stock4>();

            List<Stock5> stocks5= new List<Stock5>();

            foreach(string s in stonks)
            {   
                
                switch(c)
                {
                    case 0:

                        string[] lines;


                            lines = System.IO.File.ReadAllLines($@"C:\Users\Froze\Desktop\Faks\Inform. Sistemi\FRIexx\web\Data\Stocks\{c}{s}data{type}.csv");
                            
                            for(int i = 1;i < lines.Length;i++)
                            {    
                                string[] fields = lines[i].Split(",");
                                stocks.Add(new Stock{ID = fields[0],Open = Convert.ToDouble(fields[1]),Close = Convert.ToDouble(fields[4]), High = Convert.ToDouble(fields[2]),Low = Convert.ToDouble(fields[3]), Type =type});
                            }
                            foreach (Stock st in stocks)
                            {
                                context.Stocks.Add(st);
                            }
                            stocks.Clear();  
                            
                            c++;

                    break;
                    case 1:


                            lines = System.IO.File.ReadAllLines($@"C:\Users\Froze\Desktop\Faks\Inform. Sistemi\FRIexx\web\Data\Stocks\{c}{s}data{type}.csv");
                            
                            for(int i = 1;i < lines.Length;i++)
                            {    
                                string[] fields = lines[i].Split(",");
                                stocks2.Add(new Stock2{ID = fields[0],Open = Convert.ToDouble(fields[1]),Close = Convert.ToDouble(fields[4]), High = Convert.ToDouble(fields[2]),Low = Convert.ToDouble(fields[3]), Type =type});
                            }
                            foreach (Stock2 st in stocks2)
                            {
                                context.Stocks2.Add(st);
                            }
                            stocks2.Clear();  
                        
 
                    
                        c++;

                    break;
                    case 2:
                        

                            lines = System.IO.File.ReadAllLines($@"C:\Users\Froze\Desktop\Faks\Inform. Sistemi\FRIexx\web\Data\Stocks\{c}{s}data{type}.csv");
                            
                            for(int i = 1;i < lines.Length;i++)
                            {    
                                string[] fields = lines[i].Split(",");
                                stocks3.Add(new Stock3{ID = fields[0],Open = Convert.ToDouble(fields[1]),Close = Convert.ToDouble(fields[4]), High = Convert.ToDouble(fields[2]),Low = Convert.ToDouble(fields[3]), Type =type});
                            }
                            foreach (Stock3 st in stocks3)
                            {
                                context.Stocks3.Add(st);
                            }
                            stocks3.Clear();
                            
                        
                        c++;
                           
                    break;
                    case 3:
                        

                            lines = System.IO.File.ReadAllLines($@"C:\Users\Froze\Desktop\Faks\Inform. Sistemi\FRIexx\web\Data\Stocks\{c}{s}data{type}.csv");
                        
                            for(int i = 1;i < lines.Length;i++)
                            {    
                                string[] fields = lines[i].Split(",");
                                stocks4.Add(new Stock4{ID = fields[0],Open = Convert.ToDouble(fields[1]),Close = Convert.ToDouble(fields[4]), High = Convert.ToDouble(fields[2]),Low = Convert.ToDouble(fields[3]), Type =type});
                            }
                            foreach (Stock4 st in stocks4)
                            {
                                context.Stocks4.Add(st);
                            }
                            stocks4.Clear();  
                        
                        
                        c++;
                    break;

                    case 4:

                        
                        lines = System.IO.File.ReadAllLines($@"C:\Users\Froze\Desktop\Faks\Inform. Sistemi\FRIexx\web\Data\Stocks\{c}{s}data{type}.csv");
                        
                        for(int i = 1;i < lines.Length;i++)
                        {    
                            string[] fields = lines[i].Split(",");
                            stocks5.Add(new Stock5{ID = fields[0],Open = Convert.ToDouble(fields[1]),Close = Convert.ToDouble(fields[4]), High = Convert.ToDouble(fields[2]),Low = Convert.ToDouble(fields[3]), Type =type});
                        }
                        foreach (Stock5 st in stocks5)
                         {
                            context.Stocks5.Add(st);
                        }
                        stocks5.Clear();  


                       
                        c++;
                    break;
                }
                
           }
            
            context.SaveChanges();
        }
    }
}