using Kibexinhos.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Kibexinhos.Controllers;
public static class EmailProvider
{
    public static async Task SendEmail(Pedido pedido, Cliente cliente, List<string> img, string apiKey)
    {
        Pedido teste = new Pedido();
        var nomeCliente = cliente?.NomeCliente ?? throw new ArgumentNullException("Algo deu errado");
        var idCompra = pedido.Id;
        var dataCompra = pedido.CriadoEm;
        double? subTotal = pedido.Total;
        var valorFrete = pedido.Frete;
        var valorDesconto = pedido.Desconto;
        double? valorTotal = pedido.Total - pedido.Desconto + pedido.Frete;

        string emailCliente = cliente?.Email ?? throw new ArgumentNullException("Algo deu errado");

        var email = new EmailBuilder()
            .AdicionarNomeDoCliente(nomeCliente)
            .AdicionarNumeroDaCompra(idCompra)
            .AdicionarDataDaCompra(dataCompra)
            .AdicionarValorSubTotal(subTotal)
            .AdicionarValorFrete(valorFrete)
            .AdicionarValorDesconto(valorDesconto)
            .AdicionarValorTotal(valorTotal)
            .AdicionarProdutos(img, pedido.PedidoItem)
            .BuildEmail();

        // var apiKey = Environment.GetEnvironmentVariable("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");

        //Environment.SetEnvironmentVariable("SENDGRID_API_KEY", "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");

        //var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");

        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("kibexinhos-etec-tcc@hotmail.com", "Kibexinhos");
        var subject = "Sending with SendGrid is Fun";
        var to = new EmailAddress(emailCliente, "Example User");
        var plainTextContent = "and easy to do anywhere, even with C#";
        var htmlContent = email;
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg);
    }
}