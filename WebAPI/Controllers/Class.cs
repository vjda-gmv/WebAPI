using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class Class
    {
        private const string V = "Esta clase genera cosas";
        public string Convert2Json()
        {
            try
            {
                int counter = 0;
                string line;

                // Read the file and display it line by line.  
                System.IO.StreamReader file =
                    new System.IO.StreamReader(@"C:\Users\VJDA\Desktop\ngx\WebAPI\WebAPI\News.txt");
                string data = string.Empty;
                while ((line = file.ReadLine()) != null)
                {
                    data += line + "??";
                    counter++;
                }

                file.Close();
                System.Console.WriteLine("There were {0} lines.", counter);
                // Suspend the screen.  
                //System.Console.ReadLine();

                var data2 = "\"Product\",\"Date\",\"Expiry\",\"Type\",\"Price\":\"ABC\",\"20-Jul-2019\",\"20-Jul-2022\",\"Supplement\",\"1300\":\"XYZ\",\"20-Jul-2019\",\"20-Jul-2022\",\"Supplement\",\"100\":\"AAA\",\"20-Jul-2019\",\"20-Jul-2022\",\"Supplement\",\"200\":\"XXX\",\"20-Jul-2019\",\"20-Jul-2022\",\"Supplement\",\"500\"";
                var datas = data.Split("??"); // string[] containing each line of the CSV
                var MemberNames = new string[3] {"title","link","text"};//.Split(','); // the first line, that contains the member names
                var MYObj = datas.Skip(1) // don't take the first line (member names)
                                 .Select((x) => x.Split("||") // split each lines
                                                             /*
                                                              * create an anonymous collection
                                                              * with object having 2 properties Key and Value
                                                              * (and removes the unneeded ")
                                                              */
                                                 .Select((y, i) => new {
                                                     Key = MemberNames[i].Trim('"'),
                                                     Value = y.Trim('"')
                                                 })
                                                 // convert it to a Dictionary
                                                 .ToDictionary(d => d.Key, d => d.Value));

                // MYObject is IEnumerable<Dictionary<string, string>>

                // serialize (remove indented if needed)
                var Json = JsonConvert.SerializeObject(MYObj, Formatting.Indented);
                return Json;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
       
        public string GenerarCosas => V;
    }
}
