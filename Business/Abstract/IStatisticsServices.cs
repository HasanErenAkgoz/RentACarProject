using Entity.DashBoardEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IStatisticsServices
    {
        public int TotolCarCount();
        public string MostExpensiveCarPlate();
        public string CheapestCarPlate();
        public string TopSellingVehiclePlate();
        public int TotalNumberofCustomers();
        public int NumberofRentedVehicles();
        public List<NameStock> NameStock();


    }
}
