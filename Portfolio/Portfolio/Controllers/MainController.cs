using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class MainController : Controller
{
    [HttpGet]
    public IActionResult Portfolio()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Submit(string name, string email, string subject, string message)
    {
        await SendEmail(name, email, subject, message);
        return RedirectToAction("Portfolio");
    }


    public async Task SendEmail(string name, string email, string subject, string message)
    {
        try
        {
            MailMessage sendMessage = new MailMessage();
            SmtpClient smtpClient = new SmtpClient
            {
                Port = 587,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("flowventory.business@gmail.com", "xvnx hgpc ipia wcdd "),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Timeout = 30000
            };

            sendMessage.From = new MailAddress("flowventory.business@gmail.com");
            sendMessage.To.Add("andrey.a.mutlu@gmail.com");
            sendMessage.Subject = subject;
            sendMessage.IsBodyHtml = true;
            sendMessage.Body = $"<p>Name: {name}</p><p>Subject: {subject}</p><p>Email: {email}</p><p>Message: {message}</p>";

            await smtpClient.SendMailAsync(sendMessage);
        }
        catch (SmtpException ex)
        {
            Console.WriteLine($"SMTP Error: {ex.Message}");
        }
    }

}