using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.DirectoryServices.AccountManagement;

public class LoginModel : PageModel
{
    [BindProperty] public string Username { get; set; }
    [BindProperty] public string Password { get; set; }

    public string ErrorMessage { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (ValidateUser(Username, Password))
        {
            // Authentifié — stocke en session (ou claims)
            HttpContext.Session.SetString("user", Username);
            return RedirectToPage("/Index");
        }

        ErrorMessage = "Échec de la connexion. Vérifiez vos identifiants.";
        return Page();
    }

    private bool ValidateUser(string username, string password)
    {
        try
        {
            // Connexion au domaine Active Directory
            using (var context = new PrincipalContext(
                ContextType.Domain,
                "domolia-ad.corp",        // Nom FQDN de ton domaine
                "192.168.1.10"          // IP de ton contrôleur AD (optionnel si DNS bien configuré)
            ))
            {
                return context.ValidateCredentials(username, password);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur AD : {ex.Message}");
            return false;
        }
    }


}
