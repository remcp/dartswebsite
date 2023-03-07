using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace dartswebsite.Pages
{
    public class ApiModel : PageModel
    {
        public void OnGet()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.adds();
        }
    }
}
