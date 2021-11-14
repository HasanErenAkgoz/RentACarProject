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
        public string TotalBrandCount();
        public int TotalModelCount();
        public decimal TotalMoneyEarned();
        public string MostExpensiveCarPlate();
        public string CheapestCarPlate();
        public string TopSellingVehiclePlate();
        public int TotalNumberofCustomers();
        public string NumberofRentedVehicles();

        public List<NameStock> NameStock();


    }
}
