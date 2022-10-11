using ExpenseTracker.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpenseTracker.Controllers
{
    public class TransactionController : Controller
    {

        private readonly ApplicationDbContext _db;

        public TransactionController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Transaction> objTransactionList = _db.Transactions;
            return View(objTransactionList);
        }

        //GET
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Category = new SelectList(_db.Categories.ToList(), "Guid", "Name");
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Transaction transaction)
        {
            if(ModelState.IsValid)
            {
                transaction.Guid = Guid.NewGuid();
                transaction.Date = DateTime.Now;

                _db.Transactions.Add(transaction);
                _db.SaveChanges();
                TempData["success"] = "Transaction created successfully!";

                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(_db.Categories.ToList(), "Guid", "Name");

            return View(transaction);
        }

        //GET
        public IActionResult Edit(Guid? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Transaction transaction = _db.Transactions.First(t => t.Guid == id);
            
            if (transaction == null)
            {
                return NotFound();
            }
            ViewBag.Category = new SelectList(_db.Categories.ToList(), "Guid", "Name");
            return View(transaction);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _db.Transactions.Update(transaction);
                _db.SaveChanges();
                TempData["success"] = "Transaction updated successfully!";
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(_db.Categories.ToList(), "Guid", "Name");

            return View(transaction);
        }

        //GET
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Transaction transaction = _db.Transactions.First(t => t.Guid == id);

            if (transaction == null)
            {
                return NotFound();
            }
            ViewBag.Category = new SelectList(_db.Categories.ToList(), "Guid", "Name");
            return View(transaction);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Guid? id)
        {
            Transaction transaction = _db.Transactions.First(t => t.Guid == id);
            if(transaction == null)
            {
                return NotFound();
            }
            _db.Transactions.Remove(transaction);
            _db.SaveChanges();
            TempData["success"] = "Transaction deleted successfully!";
            return RedirectToAction("Index");
        }

    }
}
