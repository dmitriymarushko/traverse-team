namespace Juice.Web.Controllers
{
    using Core.Data.Brands;
    using Core.Data.Category;
    using Core.Services.ProductServices;
    using Juice.Core.Data.Product;
    using Juice.Core.Services;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    public class ProductsController : Controller
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }

        // GET: Products
        public ActionResult Index()
        {
            var products = _productService.GetProducts();
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = _productService.GetProduct(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(new Brand[] { new Brand { ID = 1, BrandName = "Brand1" } }, "ID", "BrandName");//db.Set<Brand>(), "Id", "BrandName");
            ViewBag.SubCategoryID = new SelectList(new SubCategory[] { new SubCategory { ID = 1, Name = "SubCategory1" } }, "ID", "Name"); //db.Set<SubCategory>(), "ID", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,FrontImage,ProductCode,IsActive,IsDeleted,Description,SubCategoryID,BrandID")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.InsertProduct(product);
                _productService.Save();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(new Brand[] { new Brand { ID = 1, BrandName = "Brand1" } }, "ID", "BrandName");//db.Set<Brand>(), "Id", "BrandName");
            ViewBag.SubCategoryID = new SelectList(new SubCategory[] { new SubCategory { ID = 1, Name = "SubCategory1" } }, "ID", "Name"); //db.Set<SubCategory>(), "ID", "Name");
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = this._productService.GetProduct(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.BrandID = new SelectList(new Brand[] { new Brand { ID = 1, BrandName = "Brand1" } }, "ID", "BrandName");//db.Set<Brand>(), "Id", "BrandName");
            ViewBag.SubCategoryID = new SelectList(new SubCategory[] { new SubCategory { ID = 1, Name = "SubCategory1" } }, "ID", "Name"); //db.Set<SubCategory>(), "ID", "Name");
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,FrontImage,ProductCode,IsActive,IsDeleted,Description,SubCategoryID,BrandID")] Product product)
        {
            if (ModelState.IsValid)
            {
                this._productService.UpdateProduct(product);
                this._productService.Save();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(new Brand[] { new Brand { ID = 1, BrandName = "Brand1" } }, "ID", "BrandName");//db.Set<Brand>(), "Id", "BrandName");
            ViewBag.SubCategoryID = new SelectList(new SubCategory[] { new SubCategory { ID = 1, Name = "SubCategory1" } }, "ID", "Name"); //db.Set<SubCategory>(), "ID", "Name");
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = this._productService.GetProduct(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            this._productService.DeleteProduct(id);
            this._productService.Save();
            return RedirectToAction("Index");
        }
    }
}
