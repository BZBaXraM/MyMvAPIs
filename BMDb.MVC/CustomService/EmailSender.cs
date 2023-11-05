using Microsoft.AspNetCore.Identity.UI.Services;

namespace BMDbMvcUI.CustomService;

public class EmailSender : IEmailSender
{
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        await Task.CompletedTask;
    }
}