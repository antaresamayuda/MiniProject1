using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.Repo
{
    public class MstEmployeeRepo
    {
        public static bool InsertData(Model.POSContext context, ViewModel.MstEmployeeViewModel model)
        {
            bool result = false;
            int HeaderID = 1;
            POSContext conn = new POSContext();
            var nilaiMaksimum = conn.MstEmployees.OrderByDescending(i => i.id).FirstOrDefault();
            HeaderID = 1 + int.Parse(nilaiMaksimum.id.ToString());
            context.MstEmployees.Add(new Model.MstEmployee()
            {
                id = HeaderID,
                firstName = model.firstName,
                lastName = model.lastName,
                email = model.email,
                haveAccount = model.haveAccount,
                title = model.title,
                active = true
            });
            
            if (model.haveAccount == true)
            {

                context.MstUsers.Add(new Model.MstUser()
                {
                    username = model.username,
                    password = model.password,
                    roleId = model.roleId,
                    employeeId = HeaderID,
                    createdOn = DateTime.Now,
                    active = true
                });
            }

            if (model.IDOutlet != null) {
                foreach (var item in model.IDOutlet)
                {
                    context.MstEmployeeOutlets.Add(new Model.MstEmployeeOutlet()
                    {
                        employeeId = HeaderID,
                        outletId = item,
                    });
                }
            }

            

            try
            {
                context.SaveChanges();
                result = true;
            }
            catch (Exception)
            {

            }
            return result;
        }

        public static List<MstEmployeeViewModel> GetAllSearch(string strSearch)
        {
            List<MstEmployeeViewModel> result = new List<MstEmployeeViewModel>();
            using (var context = new POSContext())
            {
                result = (
                          from EM in context.MstEmployees
                          where EM.firstName.Contains(strSearch) || EM.lastName.Contains(strSearch)
                          select new MstEmployeeViewModel
                          {
                              id = EM.id,
                              firstName = EM.firstName,
                              email = EM.email,
                              haveAccount = EM.haveAccount,
                              active = EM.active
                          }
                    ).ToList();
            }
            return result;
        }

        public static List<MstEmployeeViewModel> GetData()
        {
            List<MstEmployeeViewModel> result = new List<MstEmployeeViewModel>();
            POSContext context = new POSContext();
            result = context.MstEmployees.Select(x => new MstEmployeeViewModel()
            {
                id = x.id,
                firstName = x.firstName,
                lastName = x.lastName,
                email = x.email,
                title = x.title,
                haveAccount = x.haveAccount,
                createdBy = x.createdBy,
                createdOn = x.createdOn,
                modifiedBy = x.modifiedBy,
                modifiedOn = x.modifiedOn,
                active = x.active


            }).ToList();

            return result;
        }

        public static List<MstAllEmOuVM> GetAll(int id)
        {
            List<MstAllEmOuVM> result = new List<MstAllEmOuVM>();
            using (var context = new POSContext())
            {
                result = (
                          from EM in context.MstEmployees
                          from EO in context.MstEmployeeOutlets
                          from OU in context.MstOutlets

                          where EM.id == EO.employeeId && EO.outletId==OU.id && EM.id==id
                          select new MstAllEmOuVM
                          {
                              id = EM.id,
                              firstName = EM.firstName,
                              email = EM.email,
                              haveAccount = EM.haveAccount,
                              nameOu = OU.name,
                              active = EM.active
                          }
                    ).ToList();
            }
            return result;
        }

        public static List<MstEmployeeViewModel> GetRole(int id)
        {
            List<MstEmployeeViewModel> result = new List<MstEmployeeViewModel>();
            using (var context = new POSContext())
            {
                result = (
                          from EM in context.MstEmployees
                          from US in context.MstUsers
                          from RO in context.MstRoles

                          where EM.id == US.employeeId && US.roleId == RO.id && EM.id == id
                          select new MstEmployeeViewModel
                          {
                              nameRO = RO.name
                          }
                    ).ToList();
            }
            return result;
        }

        public static bool Add(MstEmployeeViewModel model)
        {
            MstEmployee employee = new MstEmployee();
            employee.firstName = model.firstName;
            employee.lastName = model.lastName;
            employee.email = model.email;
            employee.title = model.title;
            employee.haveAccount = model.haveAccount;

            employee.createdBy = model.createdBy;
            employee.createdOn = DateTime.Now;
            //employee.modifiedBy = model.createdBy;
            //employee.modifiedOn = DateTime.Now;
            employee.active = model.active;


            using (POSContext context = new POSContext())
            {
                context.MstEmployees.Add(employee);
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

        public static bool Update(MstEmployeeViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstEmployee employee = context.MstEmployees.Where(s => s.id == model.id).FirstOrDefault();
                employee.firstName = model.firstName;
                employee.lastName = model.lastName;
                employee.email = model.email;
                employee.title = model.title;
                employee.haveAccount = model.haveAccount;
                employee.modifiedBy = 1;
                employee.modifiedOn = DateTime.Now;

                MstUser user = context.MstUsers.Where(u => u.employeeId == model.id).FirstOrDefault();
                user.username = model.username;
                user.password = model.password;
                user.modifiedBy = 1;
                user.ModifiedOn = DateTime.Now;
                if (model.haveAccount == true)
                {
                    user.active = true;
                }
                else {
                    user.active = false;
                }

                var purchCount = (from purchase in context.MstEmployeeOutlets 
                                  where purchase.employeeId==model.id
                                  select new MstEmployeeOutletViewModel()
                                  ).Count();

                POSContext delete = new POSContext();
                for (int i = 0; i < purchCount; i++)
                {
                    MstEmployeeOutlet hOutlet = delete.MstEmployeeOutlets.Where(s => s.employeeId == model.id).FirstOrDefault();
                    delete.MstEmployeeOutlets.Remove(hOutlet);
                    delete.SaveChanges();
                }


                foreach (var item in model.IDOutlet)
                {
                    context.MstEmployeeOutlets.Add(new Model.MstEmployeeOutlet()
                    {
                        employeeId = model.id,
                        outletId = item,
                    });
                }

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


        public static bool UpdatePassword(MstEmployeeViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstEmployee employee = context.MstEmployees.Where(s => s.email == model.email && s.active==true).FirstOrDefault();
                var idEm = employee.id;
                if (employee.haveAccount == true)
                {
                    MstUser user = context.MstUsers.Where(u => u.employeeId == idEm).FirstOrDefault();
                    user.password = model.password;
                    user.modifiedBy = 1;
                    user.ModifiedOn = DateTime.Now;                    
                }                
                
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

        public static MstEmployeeViewModel CariBerdasarkanId(int id)
        {
            MstEmployeeViewModel ObjectHasilnya = new MstEmployeeViewModel();
            using (POSContext _posContext = new POSContext())
            {
                ObjectHasilnya = (from mstA in _posContext.MstEmployees
                                  from mstUS in _posContext.MstUsers
                                  where mstA.id == id && mstA.id==mstUS.employeeId
                                  select new MstEmployeeViewModel
                                  {
                                      id = mstA.id,
                                      firstName = mstA.firstName,
                                      lastName = mstA.lastName,
                                      email = mstA.email,
                                      title = mstA.title,
                                      haveAccount = mstA.haveAccount,
                                      active = mstA.active,
                                      username = mstUS.username,
                                      password = mstUS.password
                                  }
                                 ).FirstOrDefault();

            }
            return ObjectHasilnya;
        }

        public static bool Delete(MstEmployeeViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstEmployee employee = context.MstEmployees.Where(s => s.id == model.id).FirstOrDefault();
                context.MstEmployees.Remove(employee);

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

        public static List<MstEmployeeOutletViewModel> GetNameOutlet(int id)
        {
            List<MstEmployeeOutletViewModel> result = new List<MstEmployeeOutletViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from mstEO in context.MstEmployeeOutlets
                          join mstO in context.MstOutlets
                          on mstEO.outletId equals mstO.id
                          where mstEO.employeeId == id && mstO.active == true
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


        public static bool Aktifkan(MstEmployeeViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstEmployee employee = context.MstEmployees.Where(s => s.id == model.id).FirstOrDefault();
                employee.active = true;
                MstUser user = context.MstUsers.Where(u => u.employeeId == model.id).FirstOrDefault();
                user.active = true;

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

        public static bool NonAct(MstEmployeeViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                MstEmployee employee = context.MstEmployees.Where(s => s.id == model.id).FirstOrDefault();
                employee.active = false;
                MstUser user = context.MstUsers.Where(u => u.employeeId == model.id).FirstOrDefault();
                user.active = false;

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
