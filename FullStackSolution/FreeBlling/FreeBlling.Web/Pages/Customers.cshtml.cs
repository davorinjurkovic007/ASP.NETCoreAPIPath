using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FreeBlling.Web.Pages
{
    [Authorize]
    public class CustomersModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
