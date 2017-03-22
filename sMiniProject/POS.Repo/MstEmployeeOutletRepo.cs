using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.Repo
{
    public class MstEmployeeOutletRepo
    {
        public static List<MstEmployeeOutletViewModel> GetData()
        {
            List<MstEmployeeOutletViewModel> result = new List<MstEmployeeOutletViewModel>();
            using (POSContext context = new POSContext())
            {
                result = context.MstEmployeeOutlets.Select(x => new MstEmployeeOutletViewModel()
                {
                    id = x.id,
                    employeeId = x.employeeId,
                    outletId = x.outletId,                   

                }).ToList();
            }
            return result;
        }

        public static bool Tambah(MstEmployeeOutletViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstEmployeeOutlet EmployeeOutlet = new MstEmployeeOutlet();
                EmployeeOutlet.id = model.id;
                EmployeeOutlet.employeeId = model.employeeId;
                EmployeeOutlet.outletId = model.outletId;                

                context.MstEmployeeOutlets.Add(EmployeeOutlet);
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

        public static bool Update(MstEmployeeOutletViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstEmployeeOutlet EmployeeOutlet = context.MstEmployeeOutlets.Where(s => s.id == model.id).FirstOrDefault();

                EmployeeOutlet.id = model.id;
                EmployeeOutlet.employeeId = model.employeeId;
                EmployeeOutlet.outletId = model.outletId;
                
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

        public static MstEmployeeOutletViewModel CariBerdasarkanID(int id)
        {
            MstEmployeeOutletViewModel Objecthasilnya = new MstEmployeeOutletViewModel();
            using (POSContext _POSContext = new POSContext())
            {
                Objecthasilnya = (from mstA in _POSContext.MstEmployeeOutlets
                                  where mstA.id == id
                                  select new MstEmployeeOutletViewModel
                                  {
                                      id = mstA.id,
                                      employeeId = mstA.employeeId,
                                      outletId = mstA.outletId,
                                     
                                  }

                            ).FirstOrDefault();
            }
            return Objecthasilnya;
        }

        public static bool Hapus(MstEmployeeOutletViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstEmployeeOutlet EmployeeOutlet = context.MstEmployeeOutlets.Where(s => s.id == model.id).FirstOrDefault();
                context.MstEmployeeOutlets.Remove(EmployeeOutlet);

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

        public static List<MstEmployeeOutletViewModel> GetByProvId(int idx)
        {
            List<MstEmployeeOutletViewModel> result = new List<MstEmployeeOutletViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from mstEO in context.MstEmployeeOutlets
                          join mstO in context.MstOutlets
                          on mstEO.outletId equals mstO.id                          
                          where mstEO.employeeId == idx  && mstO.active == true                        
                          select new MstEmployeeOutletViewModel
                          {
                              id = mstEO.id,
                              employeeId = mstEO.employeeId,
                              outletId = mstEO.outletId,
                              name = mstO.name
                          }
                    ).ToList();
            }
            return result;
        }
    }
}
