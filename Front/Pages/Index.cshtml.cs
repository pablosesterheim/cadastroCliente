using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Clients.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [Required(ErrorMessage = "Nome é obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatorio")]
        public string Email { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

        }

        public void OnGet()
        {

        }
    }
}