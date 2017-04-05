namespace Juice.Core.Services
{
    using Data.Category;
    using Juice.Core.Data.Brands;
    using Juice.Core.Data.Product;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Text;

    public class DBContext : DbContext, IDBContext
    {
        public DBContext() : base("name=DBConnectionString")
        {
            Database.SetInitializer(new XDatabaseInitializer());
        }
        public override DbSet<T> Set<T>()
        {
            return base.Set<T>();
        }
        public new DbEntityEntry<T> Entry<T>(T entity) where T : class
        {
            return base.Entry(entity);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Brand>().ToTable("Brand");

            //Database.SetInitializer<DBContext>(new DropCreateDatabaseIfModelChanges<DBContext>());

            //base.OnModelCreating(modelBuilder);
        }
    }

    public class XDatabaseInitializer : 
        //DropCreateDatabaseAlways<DBContext>
        DropCreateDatabaseIfModelChanges<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            /*
            var b = new Brand { ID = 1, BrandName = "Name", BrandCode = "Code" };
            var brands = new List<Brand>{
                b
            };
            brands.ForEach(x => context.Set<Brand>().Add(x));

            var c = new Category { ID = 1, Name = "Name", Code = "Code" };
            var cat = new List<Category>{
                c
            };
            cat.ForEach(x => context.Set<Category>().Add(x));

            var s = new SubCategory { ID = 1, Name = "Name", Code = "Code", CategoryID = 1 };
            var subcat = new List<SubCategory>{
                s
            };
            subcat.ForEach(x => context.Set<SubCategory>().Add(x));

            //	2
            var p = new Product
            {
                ID = 1,
                Brand = b,
                SubCategory = s,
                ProductCode = "ProductCode",
                Description = "Description",

                //FirstName = "admin",
                //LastName = "admin",
                //Email = "admin@g.com",
                //PhoneNumber = "",
                //Login = "admin",
                //Password = hash,                        //"admin",
                //ConfirmPassword = hash,                 //"admin",
                //CustomerInRole = new List<CustomerInRole>(),
                //IsDisabled = false,
                //CreatedDate = DateTime.Now,
                //Creator = "undefined",
                //ChangedDate = DateTime.Now,
                //Changer = "undefined",

            };

            var products = new List<Product>{
                p,
            };
            products.ForEach(x => context.Set<Product>().Add(x));


            StringBuilder str = new StringBuilder();
            try
            {
                context.SaveChanges();
                base.Seed(context);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var err in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in err.ValidationErrors)
                    {
                        System.Diagnostics.Trace.TraceInformation("Class: {0}, Property: {1}, Error: {2}",
                            err.Entry.Entity.GetType().FullName,
                            validationError.PropertyName,
                            validationError.ErrorMessage);

                        str.AppendFormat("Class: {0}, Property: {1}, Error: {2}",
                            err.Entry.Entity.GetType().FullName,
                            validationError.PropertyName,
                            validationError.ErrorMessage);

                        //Output(str);
                    }
                }

                throw;
            }*/
        }
    }
}
