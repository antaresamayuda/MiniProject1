using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.ViewModel;
using POS.Model;

namespace POS.Repo
{
    public class MstCustomerRepo
    {
        public static List<MstCustomerViewModel> Getdata()
        {
            List<MstCustomerViewModel> result = new List<MstCustomerViewModel>();
            POSContext context = new POSContext();

            result = context.MstCustomers.Select(x => new MstCustomerViewModel()
            {
                id = x.id,
                name = x.name,
                email = x.email,
                phone = x.phone,
                address = x.address,
                provinceid = x.provinceid,
                regionid = x.regionid,
                districtid = x.districtid,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                ModifiedBy = x.ModifiedBy,
                ModifiedOn = x.ModifiedOn,
                active = x.active,
            }
            ).ToList();

            return result;
        }


        public static MstCustomerViewModel GetDataByID(int id)
        {
            MstCustomerViewModel result = new MstCustomerViewModel();
            using (POSContext context = new POSContext())
            {
                result = context.MstCustomers.Where(x => x.id == id)
                    .Select(x => new MstCustomerViewModel()
                    {
                        id = x.id,
                        name = x.name,
                        email = x.email,
                        phone = x.phone,
                        address = x.address,
                        provinceid = x.provinceid,
                        regionid = x.regionid,
                        districtid = x.districtid,
                        CreatedBy = x.CreatedBy,
                        CreatedOn = x.CreatedOn,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedOn = x.ModifiedOn,
                        active = x.active,
                    }).FirstOrDefault();
            }
            return result;
        }

        public static MstCustomerViewModel CariID(int id)
        {
            MstCustomerViewModel hasilID = new MstCustomerViewModel();
            using (POSContext context = new POSContext())
            {
                hasilID = (from x in context.MstCustomers
                           where x.id == id
                           select new MstCustomerViewModel
                           {
                               id = x.id,
                               name = x.name,
                               email = x.email,
                               phone = x.phone,
                               address = x.address,
                               provinceid = x.provinceid,
                               regionid = x.regionid,
                               districtid = x.districtid,
                               CreatedBy = x.CreatedBy,
                               CreatedOn = x.CreatedOn,
                               ModifiedBy = x.ModifiedBy,
                               ModifiedOn = x.ModifiedOn,
                               active = x.active,
                           }
                           ).FirstOrDefault();
            }
            return hasilID;
        }

        public static bool Add(MstCustomerViewModel x)
        {
            MstCustomer Customer = new MstCustomer();
            Customer.id = x.id;
            Customer.name = x.name;
            Customer.CreatedBy = x.CreatedBy;
            Customer.CreatedOn = DateTime.Now;
            Customer.active = x.active;

            using (POSContext context = new POSContext())
            {
                context.MstCustomers.Add(Customer);
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }


        public static bool Update(MstCustomerViewModel x)
        {
            using (POSContext context = new POSContext())
            {

                MstCustomer Customer = context.MstCustomers.Where(s => s.id == x.id).FirstOrDefault();

                Customer.id = x.id;
                Customer.name = x.name;
                Customer.ModifiedBy = x.ModifiedBy;
                Customer.ModifiedOn = DateTime.Now;
                Customer.active = x.active;

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }


        public static bool Delete(MstCustomerViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                MstCustomer Customer = context.MstCustomers.Where(s => s.id == IsiData.id).FirstOrDefault();
                context.MstCustomers.Remove(Customer);
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }
    }
}
