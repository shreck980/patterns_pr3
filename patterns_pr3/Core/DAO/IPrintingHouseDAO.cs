using patterns_pr3.Core.Entities;
using patterns_pr3.Core.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_pr3.Core.DAO
{
    public interface IPrintingHouseDAO : ISubject
    {
        void AddPrintingHouse(PrintingHouse printingHouse);
        void UpdatePrintingHouse(PrintingHouse printingHouse);
        PrintingHouse GetPrintingHouse(int id);
        PrintingHouse GetPrintingHouseByName(string name);
        List<PrintingHouse> GetPrintingHouseByCountry(string country);
        List<PrintingHouse> GetAllPrintingHouse();
    }
}
