namespace Juice.Core.Migrations
{
    using Data.Brands;
    using Data.Category;
    using Data.Product;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<Juice.Core.Services.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationsEnabled = false;
            ContextKey = "Juice.Core.Services.DBContext";
        }

        protected override void Seed(Juice.Core.Services.DBContext context)
        {
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

            var p = new Product
            {
                ID = 1,
                Brand = b,
                SubCategory = s,
                ProductCode = "ProductCode",
                Description = "Description",
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
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
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
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
