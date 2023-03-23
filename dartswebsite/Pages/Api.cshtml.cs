using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection.Extensions;


namespace dartswebsite.Pages
{
    public class ApiModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public void OnGet()
        {

        }

    }
}
