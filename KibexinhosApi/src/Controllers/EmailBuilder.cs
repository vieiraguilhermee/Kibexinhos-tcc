using Kibexinhos.Models;
using System.Text;

namespace Kibexinhos.Controllers
{
    public class EmailBuilder
    {
        //private const string NOME_CLIENTE = "NOME_CLIENTE";
        private string? _nomeCliente;
        private string? _numeroCompra;
        private string? _dataCompra;
        private string? _valorSubTotal;
        private string? _valorFrete;
        private string? _valorDesconto;
        private string? _valorTotal;

        private List<string>? _images;
        private List<PedidoItem> _produtos = new List<PedidoItem>();

        #region Email
        private readonly string _email =
@"
<!DOCTYPE html>
<html lang='en' xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:v='urn:schemas-microsoft-com:vml'>
<head>
<title></title>
<meta content='text/html; charset=utf-8' http-equiv='Content-Type'/>
<meta content='width=device-width, initial-scale=1.0' name='viewport'/>
<!--[if mso]>
<xml>
<o:OfficeDocumentSettings>
<o:PixelsPerInch>96</o:PixelsPerInch>
<o:AllowPNG/>
</o:OfficeDocumentSettings>
</xml>
<![endif]-->
<!--[if !mso]><!-->
<link href='https://fonts.googleapis.com/css?family=Nunito' rel='stylesheet' type='text/css'/>
<link href='https://fonts.googleapis.com/css?family=Playfair+Display' rel='stylesheet' type='text/css'/>
<!--<![endif]-->
<style>
* {
box-sizing: border-box;
}
body {
margin: 0;
padding: 0;
}
a[x-apple-data-detectors] {
color: inherit !important;
text-decoration: inherit !important;
}
#MessageViewBody a {
color: inherit;
text-decoration: none;
}
p {
line-height: inherit
}
@media (max-width:700px) {
.icons-inner {
text-align: center;
}
.icons-inner td {
margin: 0 auto;
}
.row-content {
width: 100% !important;
}
.column .border,
.mobile_hide {
display: none;
}
.stack .column {
width: 100%;
display: block;
}
.mobile_hide {
min-height: 0;
max-height: 0;
max-width: 0;
overflow: hidden;
font-size: 0px;
}
}
</style>
</head>
<body style='background-color: #ffaf34; margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;'>
<table border='0' cellpadding='0' cellspacing='0' class='nl-container' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffaf34;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-1' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffaa00;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'>
<tbody>
<tr>
<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
<div class='spacer_block' style='height:1px;line-height:1px;font-size:1px;'> </div>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-2' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffaf34;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'>
<tbody>
<tr>
<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
<div class='spacer_block' style='height:5px;line-height:5px;font-size:1px;'> </div>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-3' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffaf34;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'>
<tbody>
<tr>
<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
<table border='0' cellpadding='0' cellspacing='0' class='image_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
<tr>
<td style='width:100%;padding-right:0px;padding-left:0px;'>
<div align='center' style='line-height:10px'><img alt='Light blue sphere with flowers' src='https://i.imgur.com/vPgzU0P.png' style='display: block; height: auto; border: 0; width: 272px; max-width: 100%;' title='Light blue sphere with flowers' width='272'/></div>
</td>
</tr>
</table>
<table border='0' cellpadding='10' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
<tr>
<td>
<div style='font-family: Verdana, sans-serif'>
<div style='font-size: 12px; font-family: Verdana, Geneva, sans-serif; mso-line-height-alt: 14.399999999999999px; color: #44464a; line-height: 1.2;'>
<p style='margin: 0; font-size: 14px; text-align: center;'><strong><span style='font-size:30px;color:#ffffff;'>Caro NOME_CLIENTE, obrigado pela compra!</span></strong></p>
</div>
</div>
</td>
</tr>
</table>
<table border='0' cellpadding='10' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
<tr>
<td>
<div style='font-family: sans-serif'>
<div style='font-size: 12px; mso-line-height-alt: 14.399999999999999px; color: #787771; line-height: 1.2; font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;'>
<p style='margin: 0; font-size: 14px; text-align: center;'><span style='color:#000000;'>Agradecemos por confiar na nossa jornada de oferecer o melhor para os pets</span></p>
</div>
</div>
</td>
</tr>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-4' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffaf34;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'>
<tbody>
<tr>
<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 10px; padding-right: 10px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='66.66666666666667%'>
<table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
<tr>
<td style='padding-bottom:10px;padding-left:10px;padding-right:10px;padding-top:25px;'>
<div style='font-family: sans-serif'>
<div style='font-size: 12px; mso-line-height-alt: 14.399999999999999px; color: #44464a; line-height: 1.2; font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;'>
<p style='margin: 0; font-size: 14px;'>N° Compra: <span style='color:#c4a07a;'><strong>NUMERO_COMPRA</strong></span></p>
</div>
</div>
</td>
</tr>
</table>
<table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
<tr>
<td style='padding-bottom:15px;padding-left:10px;padding-right:10px;padding-top:10px;'>
<div style='font-family: sans-serif'>
<div style='font-size: 12px; mso-line-height-alt: 14.399999999999999px; color: #44464a; line-height: 1.2; font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;'>
<p style='margin: 0; font-size: 14px;'>Data da compra: DATA_COMPRA</p>
</div>
</div>
</td>
</tr>
</table>
</td>
<td class='column column-2' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='33.333333333333336%'>
<div class='spacer_block' style='height:5px;line-height:5px;font-size:1px;'> </div>
<div class='spacer_block mobile_hide' style='height:15px;line-height:15px;font-size:1px;'> </div>
<table border='0' cellpadding='0' cellspacing='0' class='button_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
<tr>
<td style='padding-bottom:25px;padding-left:10px;padding-right:10px;padding-top:10px;text-align:center;'>
<div align='center'>
<!--[if mso]>
<v:roundrect xmlns:v='urn:schemas-microsoft-com:vml' xmlns:w='urn:schemas-microsoft-com:office:word' href='http://www.example.com' style='height:44px;width:121px;v-text-anchor:middle;' arcsize='64%' strokeweight='0.75pt' strokecolor='#393D47' fill='false'>
<w:anchorlock/>
<v:textbox inset='0px,0px,0px,0px'>
<center style='color:#393d47; font-family:Arial, sans-serif; font-size:16px'>
<![endif]--><a href='http://www.example.com' style='text-decoration:none;display:inline-block;color:#393d47;background-color:transparent;border-radius:28px;width:auto;border-top:1px solid #393D47;border-right:1px solid #393D47;border-bottom:1px solid #393D47;border-left:1px solid #393D47;padding-top:5px;padding-bottom:5px;font-family:Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;text-align:center;mso-border-alt:none;word-break:keep-all;' target='_blank'><span style='padding-left:20px;padding-right:20px;font-size:16px;display:inline-block;letter-spacing:normal;'><span style='font-size: 16px; line-height: 2; word-break: break-word; mso-line-height-alt: 32px;'>Ver pedido</span></span></a>
<!--[if mso]>
</center>
</v:textbox>
</v:roundrect>
<![endif]-->
</div>
</td>
</tr>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-5' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffaf34;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'>
<tbody>
<tr>
<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
<table border='0' cellpadding='0' cellspacing='0' class='divider_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
<tr>
<td>
<div align='center'>
<table border='0' cellpadding='0' cellspacing='0' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
<tr>
<td class='divider_inner' style='font-size: 1px; line-height: 1px; border-top: 1px solid #BBBBBB;'><span> </span></td>
</tr>
</table>
</div>
</td>
</tr>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-6' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffaf34;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'>
<tbody>
<tr>
<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; background-color: #f9feff; padding-left: 15px; padding-right: 15px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='50%'>
<table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
<tr>
<td style='padding-bottom:15px;padding-left:10px;padding-right:10px;padding-top:15px;'>
<div style='font-family: sans-serif'>
<div style='font-size: 12px; mso-line-height-alt: 14.399999999999999px; color: #c4a07a; line-height: 1.2; font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;'>
<p style='margin: 0; font-size: 14px; text-align: center;'><strong>Item</strong></p>
</div>
</div>
</td>
</tr>
</table>
</td>
<td class='column column-2' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; background-color: #f9feff; padding-left: 15px; padding-right: 15px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='25%'>
<table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
<tr>
<td style='padding-bottom:15px;padding-left:10px;padding-right:10px;padding-top:15px;'>
<div style='font-family: sans-serif'>
<div style='font-size: 12px; mso-line-height-alt: 14.399999999999999px; color: #c4a07a; line-height: 1.2; font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;'>
<p style='margin: 0; font-size: 14px; text-align: center;'><strong>Quantidade</strong></p>
</div>
</div>
</td>
</tr>
</table>
</td>
<td class='column column-3' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='25%'>
<table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
<tr>
<td style='padding-bottom:15px;padding-left:10px;padding-right:10px;padding-top:15px;'>
<div style='font-family: sans-serif'>
<div style='font-size: 12px; mso-line-height-alt: 14.399999999999999px; color: #c4a07a; line-height: 1.2; font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;'>
<p style='margin: 0; font-size: 14px; text-align: right;'><strong>Total</strong></p>
</div>
</div>
</td>
</tr>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-7' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffaf34;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'>
<tbody>
<tr>
<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
<table border='0' cellpadding='0' cellspacing='0' class='divider_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
<tr>
<td>
<div align='center'>
<table border='0' cellpadding='0' cellspacing='0' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
<tr>
<td class='divider_inner' style='font-size: 1px; line-height: 1px; border-top: 1px solid #BBBBBB;'><span> </span></td>
</tr>
</table>
</div>
</td>
</tr>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>




PRODUTOS







<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-9' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffaf34;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'>
<tbody>
<tr>
<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
<table border='0' cellpadding='0' cellspacing='0' class='divider_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
<tr>
<td>
<div align='center'>
<table border='0' cellpadding='0' cellspacing='0' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
<tr>
<td class='divider_inner' style='font-size: 1px; line-height: 1px; border-top: 1px solid #BBBBBB;'><span> </span></td>
</tr>
</table>
</div>
</td>
</tr>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-10' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffaf34;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'>
<tbody>
<tr>
<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 5px; padding-right: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='50%'>
<table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
<tr>
<td style='padding-bottom:15px;padding-left:10px;padding-right:10px;padding-top:15px;'>
<div style='font-family: sans-serif'>
<div style='font-size: 12px; mso-line-height-alt: 14.399999999999999px; color: #393d47; line-height: 1.2; font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;'>
<p style='margin: 0; font-size: 14px;'><span style='font-size:16px;'><strong>Subtotal</strong></span></p>
</div>
</div>
</td>
</tr>
</table>
</td>
<td class='column column-2' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 5px; padding-right: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='50%'>
<table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
<tr>
<td style='padding-bottom:15px;padding-left:10px;padding-right:10px;padding-top:15px;'>
<div style='font-family: sans-serif'>
<div style='font-size: 12px; mso-line-height-alt: 14.399999999999999px; color: #393d47; line-height: 1.2; font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;'>
<p style='margin: 0; font-size: 14px; text-align: right;'><span style='font-size:16px;'>SUB_TOTAL</span></p>
</div>
</div>
</td>
</tr>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-11' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffaf34;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'>
<tbody>
<tr>
<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 5px; padding-right: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='50%'>
<table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
<tr>
<td style='padding-bottom:15px;padding-left:10px;padding-right:10px;padding-top:15px;'>
<div style='font-family: sans-serif'>
<div style='font-size: 12px; mso-line-height-alt: 14.399999999999999px; color: #393d47; line-height: 1.2; font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;'>
<p style='margin: 0; font-size: 14px;'><span style='font-size:16px;'><strong>Frete</strong></span></p>
</div>
</div>
</td>
</tr>
</table>
</td>
<td class='column column-2' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 5px; padding-right: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='50%'>
<table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
<tr>
<td style='padding-bottom:15px;padding-left:10px;padding-right:10px;padding-top:15px;'>
<div style='font-family: sans-serif'>
<div style='font-size: 12px; mso-line-height-alt: 14.399999999999999px; color: #393d47; line-height: 1.2; font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;'>
<p style='margin: 0; font-size: 14px; text-align: right;'><span style='font-size:16px;'>VALOR_FRETE</span></p>
</div>
</div>
</td>
</tr>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-12' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffaf34;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'>
<tbody>
<tr>
<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
<table border='0' cellpadding='0' cellspacing='0' class='divider_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
<tr>
<td>
<div align='center'>
<table border='0' cellpadding='0' cellspacing='0' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
<tr>
<td class='divider_inner' style='font-size: 1px; line-height: 1px; border-top: 1px solid #BBBBBB;'><span> </span></td>
</tr>
</table>
</div>
</td>
</tr>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-13' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffaf34;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'>
<tbody>
<tr>
<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 5px; padding-right: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='50%'>
<table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
<tr>
<td style='padding-bottom:15px;padding-left:10px;padding-right:10px;padding-top:15px;'>
<div style='font-family: sans-serif'>
<div style='font-size: 12px; mso-line-height-alt: 14.399999999999999px; color: #393d47; line-height: 1.2; font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;'>
<p style='margin: 0; font-size: 14px;'><span style='font-size:16px;'><strong>Desconto</strong></span></p>
</div>
</div>
</td>
</tr>
</table>
</td>
<td class='column column-2' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 5px; padding-right: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='50%'>
<table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
<tr>
<td style='padding-bottom:15px;padding-left:10px;padding-right:10px;padding-top:15px;'>
<div style='font-family: sans-serif'>
<div style='font-size: 12px; mso-line-height-alt: 14.399999999999999px; color: #393d47; line-height: 1.2; font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;'>
<p style='margin: 0; font-size: 14px; text-align: right;'><strong><span style='font-size:16px;color:#bd2b2b;'>VALOR_DESCONTO</span></strong></p>
</div>
</div>
</td>
</tr>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-14' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffaf34;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'>
<tbody>
<tr>
<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
<table border='0' cellpadding='0' cellspacing='0' class='divider_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
<tr>
<td>
<div align='center'>
<table border='0' cellpadding='0' cellspacing='0' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
<tr>
<td class='divider_inner' style='font-size: 1px; line-height: 1px; border-top: 1px solid #E1ECEF;'><span> </span></td>
</tr>
</table>
</div>
</td>
</tr>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-15' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffaf34;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'>
<tbody>
<tr>
<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 5px; padding-right: 5px; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
<table border='0' cellpadding='10' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
<tr>
<td>
<div style='font-family: sans-serif'>
<div style='font-size: 12px; mso-line-height-alt: 14.399999999999999px; color: #68a0a9; line-height: 1.2; font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;'>
<p style='margin: 0; font-size: 14px; text-align: right;'><span style='font-size:22px;'><strong><span style=''><span style='color:#070707;'><span style='color:#393d47;'>Total</span> </span><span style='color:#ffa400;'>VALOR_TOTAL</span></span></strong></span></p>
</div>
</div>
</td>
</tr>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-16' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffaf34;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'>
<tbody>
<tr>
<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 15px; padding-bottom: 15px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
<table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
<tr>
<td style='padding-bottom:15px;padding-left:35px;padding-right:35px;padding-top:15px;'>
<div style='font-family: sans-serif'>
<div style='font-size: 12px; mso-line-height-alt: 18px; color: #44464a; line-height: 1.5; font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;'>
<p style='margin: 0; font-size: 14px; text-align: center;'>A menos que indicado de outra forma pelo produto ou oferta, qualquer produto comprado na Kibexinhos é elegível para reembolso no prazo de 14 dias após a compra. Veja nossa política de reembolso para saber os detalhes</p>
</div>
</div>
</td>
</tr>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-17' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffaf34;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'>
<tbody>
<tr>
<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
<table border='0' cellpadding='0' cellspacing='0' class='image_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
<tr>
<td style='padding-bottom:10px;padding-left:10px;padding-right:10px;padding-top:35px;width:100%;'>
<div align='center' style='line-height:10px'><img alt='Separator' src='images/istockphoto-1161680723-612x612-removebg-preview.png' style='display: block; height: auto; border: 0; width: 476px; max-width: 100%;' title='Separator' width='476'/></div>
</td>
</tr>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-18' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffaf34;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'>
<tbody>
<tr>
<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 15px; padding-bottom: 15px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
<table border='0' cellpadding='10' cellspacing='0' class='social_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='social-table' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='208px'>
<tr>
<td style='padding:0 10px 0 10px;'><a href='https://www.facebook.com/' target='_blank'><img alt='Facebook' height='32' src='images/facebook2x.png' style='display: block; height: auto; border: 0;' title='facebook' width='32'/></a></td>
<td style='padding:0 10px 0 10px;'><a href='https://www.twitter.com/' target='_blank'><img alt='Twitter' height='32' src='images/twitter2x.png' style='display: block; height: auto; border: 0;' title='twitter' width='32'/></a></td>
<td style='padding:0 10px 0 10px;'><a href='https://www.linkedin.com/' target='_blank'><img alt='Linkedin' height='32' src='images/linkedin2x.png' style='display: block; height: auto; border: 0;' title='linkedin' width='32'/></a></td>
<td style='padding:0 10px 0 10px;'><a href='https://www.instagram.com/' target='_blank'><img alt='Instagram' height='32' src='images/instagram2x.png' style='display: block; height: auto; border: 0;' title='instagram' width='32'/></a></td>
</tr>
</table>
</td>
</tr>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-19' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f5f5f5;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'>
<tbody>
<tr>
<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 10px; padding-bottom: 10px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
<table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
<tr>
<td style='padding-bottom:5px;padding-left:35px;padding-right:35px;padding-top:5px;'>
<div style='font-family: sans-serif'>
<div style='font-size: 12px; mso-line-height-alt: 18px; color: #b2b2b2; line-height: 1.5; font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;'>
<p style='margin: 0; font-size: 14px; text-align: center;'>Kibexinhos PetShop LTDA.</p>
<p style='margin: 0; font-size: 14px; text-align: center;'>Rua Dom Pedro Segundo, 327, Jaú - SP</p>
</div>
</div>
</td>
</tr>
</table>
<table border='0' cellpadding='10' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>
<tr>
<td>
<div style='font-family: sans-serif'>
<div style='font-size: 12px; mso-line-height-alt: 14.399999999999999px; color: #b2b2b2; line-height: 1.2; font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;'>
<p style='margin: 0; text-align: center;'>© Copyright 2022. Todos os direitos reservados.</p>
<p style='margin: 0; text-align: center; mso-line-height-alt: 14.399999999999999px;'> </p>
</div>
</div>
</td>
</tr>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-20' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
<tbody>
<tr>
<td>
<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content stack' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;' width='680'>
<tbody>
<tr>
<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='100%'>
<table border='0' cellpadding='0' cellspacing='0' class='icons_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
<tr>
<td style='vertical-align: middle; padding-bottom: 5px; padding-top: 5px; color: #9d9d9d; font-family: inherit; font-size: 15px; text-align: center;'>
<table cellpadding='0' cellspacing='0' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>
<tr>
<td style='vertical-align: middle; text-align: center;'>
<!--[if vml]>
<table align='left' cellpadding='0' cellspacing='0' role='presentation' style='display:inline-block;padding-left:0px;padding-right:0px;mso-table-lspace: 0pt;mso-table-rspace: 0pt;'>
<![endif]-->
<!--[if !vml]><!-->
<table cellpadding='0' cellspacing='0' class='icons-inner' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; display: inline-block; margin-right: -4px; padding-left: 0px; padding-right: 0px;'>
<!--<![endif]-->
<tr>
<td style='vertical-align: middle; text-align: center; padding-top: 5px; padding-bottom: 5px; padding-left: 5px; padding-right: 6px;'><a href='https://www.designedwithbee.com/' style='text-decoration: none;' target='_blank'><img align='center' alt='Designed with BEE' class='icon' height='32' src='images/bee.png' style='display: block; height: auto; margin: 0 auto; border: 0;' width='34'/></a></td>
<td style='font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif; font-size: 15px; color: #9d9d9d; vertical-align: middle; letter-spacing: undefined; text-align: center;'><a href='https://www.designedwithbee.com/' style='color: #9d9d9d; text-decoration: none;' target='_blank'>Designed with BEE</a></td>
</tr>
</table>
</td>
</tr>
</table>
</td>
</tr>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<!-- End -->
</body>
</html>
";
        #endregion

        public EmailBuilder AdicionarNomeDoCliente(string nomeDoCliente)
        {
            _nomeCliente = nomeDoCliente;
            return this;
        }

        public EmailBuilder AdicionarNumeroDaCompra(int numeroDaCompra)
        {
            _numeroCompra = numeroDaCompra.ToString();
            return this;
        }

        public EmailBuilder AdicionarDataDaCompra(DateTime dataCompra)
        {
            _dataCompra = dataCompra.ToString();
            return this;
        }

        public EmailBuilder AdicionarValorSubTotal(double? subTotal)
        {
            _valorSubTotal = subTotal.ToString();
            return this;
        }

        public EmailBuilder AdicionarValorFrete(double valorFrete)
        {
            _valorFrete = valorFrete.ToString();
            return this;
        }

        public EmailBuilder AdicionarValorDesconto(double valorDesconto)
        {
            _valorDesconto = valorDesconto.ToString();
            return this;
        }

        public EmailBuilder AdicionarValorTotal(double? valorTotal)
        {
            _valorTotal = valorTotal.ToString();
            return this;
        }

        public EmailBuilder AdicionarProdutos(List<string> img, params PedidoItem[] produtos)
        {
            _produtos.AddRange(produtos);
            _images = img;
            return this;
        }

        public EmailBuilder AdicionarProdutos(List<string> img, IEnumerable<PedidoItem> produtos)
        {
            _produtos.AddRange(produtos);
            _images = img;
            return this;
        }

        public string BuildEmail()
        {
            var builder = new StringBuilder(_email);
            builder.Replace("NOME_CLIENTE", _nomeCliente);
            builder.Replace("NUMERO_COMPRA", _numeroCompra);
            builder.Replace("DATA_COMPRA", _dataCompra);
            builder.Replace("SUB_TOTAL", _valorSubTotal);
            builder.Replace("VALOR_FRETE", _valorFrete);
            builder.Replace("VALOR_DESCONTO", _valorDesconto);
            builder.Replace("VALOR_TOTAL", _valorTotal);
            builder.Replace("PRODUTOS", FormatarProdutos(_produtos, _images!));

            return builder.ToString();
        }

        private static string FormatarProdutos(IEnumerable<PedidoItem> produtos, List<string> img)
        {
            var builder = new StringBuilder();
            var teste = produtos.Zip(img, (n, w) => new { Prod = n, Img = w});
            foreach (var y in teste)
            {
                builder.Append("<table align='center' border='0' cellpadding='0' cellspacing='0' class='row row-8' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffaf34;' width='100%'>");
                builder.Append("<tbody>");
                builder.Append("<tr>");
                builder.Append("<td>");
                builder.Append("<table align='center' border='0' cellpadding='0' cellspacing='0' class='row-content' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 680px;' width='680'>");
                builder.Append("<tbody>");
                builder.Append("<tr>");
                builder.Append("<td class='column column-1' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 5px; padding-right: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='25%'>");
                builder.Append("<table border='0' cellpadding='0' cellspacing='0' class='image_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt;' width='100%'>");
                builder.Append("<tr>");
                builder.Append("<td style='width:100%;padding-right:0px;padding-left:0px;padding-top:5px;padding-bottom:5px;'>");
                builder.Append($"<div align='center' style='line-height:10px'><img src='{y.Img}' style='display: block; height: auto; border: 0; width: 104px; max-width: 100%;' width='104'/></div>");
                builder.Append("</td>");
                builder.Append("</tr>");
                builder.Append("</table>");
                builder.Append("</td>");
                builder.Append("<td class='column column-2' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 5px; padding-right: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='25%'>");
                builder.Append("<table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>");
                builder.Append("<tr>");
                builder.Append("<td style='padding-bottom:15px;padding-left:10px;padding-top:45px;'>");
                builder.Append("<div style='font-family: sans-serif'>");
                builder.Append("<div style='font-size: 12px; mso-line-height-alt: 14.399999999999999px; color: #393d47; line-height: 1.2; font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;'>");
                builder.Append($"<p style='margin: 0; font-size: 14px;'>{y.Prod.Produto!.NomeProduto}</p>");
                builder.Append("</div>");
                builder.Append("</div>");
                builder.Append("</td>");
                builder.Append("</tr>");
                builder.Append("</table>");
                builder.Append("</td>");
                builder.Append("<td class='column column-3' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 5px; padding-right: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='25%'>");
                builder.Append("<table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>");
                builder.Append("<tr>");
                builder.Append("<td style='padding-bottom:15px;padding-left:5px;padding-right:5px;padding-top:45px;'>");
                builder.Append("<div style='font-family: sans-serif'>");
                builder.Append("<div style='font-size: 12px; mso-line-height-alt: 14.399999999999999px; color: #393d47; line-height: 1.2; font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;'>");
                builder.Append($"<p style='margin: 0; font-size: 14px; text-align: center;'>{y.Prod.Quantidade}</p>");
                builder.Append("</div>");
                builder.Append("</div>");
                builder.Append("</td>");
                builder.Append("</tr>");
                builder.Append("</table>");
                builder.Append("</td>");
                builder.Append("<td class='column column-4' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;' width='25%'>");
                builder.Append("<table border='0' cellpadding='0' cellspacing='0' class='text_block' role='presentation' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;' width='100%'>");
                builder.Append("<tr>");
                builder.Append("<td style='padding-bottom:15px;padding-right:10px;padding-top:45px;'>");
                builder.Append("<div style='font-family: sans-serif'>");
                builder.Append("<div style='font-size: 12px; mso-line-height-alt: 14.399999999999999px; color: #393d47; line-height: 1.2; font-family: Nunito, Arial, Helvetica Neue, Helvetica, sans-serif;'>");
                builder.Append($"<p style='margin: 0; font-size: 14px; text-align: right;'>R$ {y.Prod.Quantidade * y.Prod.PrecoUnit}</p>");
                builder.Append("</div>");
                builder.Append("</div>");
                builder.Append("</td>");
                builder.Append("</tr>");
                builder.Append("</table>");
                builder.Append("</td>");
                builder.Append("</tr>");
                builder.Append("</tbody>");
                builder.Append("</table>");
                builder.Append("</td>");
                builder.Append("</tr>");
                builder.Append("</tbody>");
                builder.Append("</table>");
            }


            return builder.ToString();
        }
    }
}
