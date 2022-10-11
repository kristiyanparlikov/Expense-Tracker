using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpenseTracker.Models.ViewModels
{
    public class CreateTransactionViewModel
    {
        public string Title { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }

        public string SelectedCategory { get; set; }

        // Display property
        public List<SelectListItem> CategorySelectList { get; set; }

    }
}
