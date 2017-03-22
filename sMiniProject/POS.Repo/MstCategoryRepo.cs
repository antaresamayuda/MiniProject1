using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.ViewModel;
using POS.Model;

namespace POS.Repo
{
    public class MstCategoryRepo
    {
        public static List<MstCategoryViewModel> Getdata()
        {
            List<MstCategoryViewModel> result = new List<MstCategoryViewModel>();
            POSContext context = new POSContext();

            result = context.MstCategorys.Where(x => x.active==true).Select(x => new MstCategoryViewModel()
            {
                id = x.id,
                name = x.name,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                ModifiedBy = x.ModifiedBy,
                ModifiedOn = x.ModifiedOn,
                active = x.active,
            }
            ).ToList();

            return result;
        }


        public static MstCategoryViewModel GetDataByID(int id)
        {
            MstCategoryViewModel result = new MstCategoryViewModel();
            using (POSContext context = new POSContext())
            {
                result = context.MstCategorys.Where(x => x.id == id)
                    .Select(x => new MstCategoryViewModel()
                    {
                        id = x.id,
                        name = x.name,
                        CreatedBy = x.CreatedBy,
                        CreatedOn = x.CreatedOn,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedOn = x.ModifiedOn,
                        active = x.active,
                    }).Take(1).FirstOrDefault();
            }
            return result;
        }

        public static MstCategoryViewModel CariID(int id)
        {
            MstCategoryViewModel hasilID = new MstCategoryViewModel();
            using (POSContext context = new POSContext())
            {
                hasilID = (from x in context.MstCategorys
                           where x.id == id
                           select new MstCategoryViewModel
                           {
                               id = x.id,
                               name = x.name,
                               CreatedBy = x.CreatedBy,
                               CreatedOn = x.CreatedOn,
                               ModifiedBy = x.ModifiedBy,
                               ModifiedOn = x.ModifiedOn,
                               active = x.active
                           }
                           ).FirstOrDefault();
            }
            return hasilID;
        }

        public static bool Add(MstCategoryViewModel x)
        {
            MstCategory Category = new MstCategory();
            Category.id = x.id;
            Category.name = x.name;
            Category.CreatedBy = x.CreatedBy;
            Category.CreatedOn = DateTime.Now;
            Category.active = true;

            using (POSContext context = new POSContext())
            {
                context.MstCategorys.Add(Category);
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


        public static bool Update(MstCategoryViewModel x)
        {
            using (POSContext context = new POSContext())
            {

                MstCategory Category = context.MstCategorys.Where(s => s.id == x.id).FirstOrDefault();

                Category.id = x.id;
                Category.name = x.name;
                Category.ModifiedBy = x.ModifiedBy;
                Category.ModifiedOn = DateTime.Now;

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


        public static bool Delete(MstCategoryViewModel IsiData)
        {
            using (POSContext context = new POSContext())
            {
                MstCategory category = context.MstCategorys.Where(s => s.id == IsiData.id).FirstOrDefault();
                context.MstCategorys.Remove(category);
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



        public static List<MstCategoryViewModel> GetAllSearch(string strSearch)
        {
            List<MstCategoryViewModel> result = new List<MstCategoryViewModel>();
            using (var context = new POSContext())
            {
                result = (
                          from Ctg in context.MstCategorys
                          where Ctg.name.Contains(strSearch) && Ctg.active==true
                          select new MstCategoryViewModel
                          {
                              id = Ctg.id,
                              name = Ctg.name,
                              active = Ctg.active                              
                          }
                    ).ToList();
            }
            return result;
        }

        public static List<MstItemViewModel> GetCountItem(int id)
        {
            List<MstItemViewModel> result = new List<MstItemViewModel>();
            using (var context = new POSContext())
            {
                var purchCount = (from purchase in context.MstItems
                                  where purchase.categoryId == id
                                  select new MstItemViewModel()
                                  ).Count();

                result = context.MstItems.Where(x => x.categoryId == id)
                    .Select(x => new MstItemViewModel()
                    {
                        countItem = purchCount
                    }).Take(1).ToList();
            }
            return result;
        }
    }
}
