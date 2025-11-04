using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net;
using System.Net.Mail;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace Servicios
{
    public class EmailSender
    {
        private readonly string smtpServer;
        private readonly int smtpPort;
        private readonly string smtpUser;
        private readonly string smtpPassword;
        private readonly bool enableSsl;

        public EmailSender()
        {
            this.smtpServer = "smtp.gmail.com";
            this.smtpPort = 587;
            this.smtpUser = "soporte.mercado.clone@gmail.com";
            this.smtpPassword = "xhtd uoba itch hwwv";
            this.enableSsl = true;
        }

        public async Task EnviarCorreoAsync(string destinatario, string asunto, string cuerpoHtml, bool esHtml = true)
        {
            try
            {
                using (var mensaje = new MailMessage())
                {
                    mensaje.From = new MailAddress(smtpUser, "RaiseApp");
                    mensaje.To.Add(destinatario);
                    mensaje.Subject = asunto;
                    mensaje.Body = cuerpoHtml;
                    mensaje.IsBodyHtml = esHtml;

                    using (var cliente = new SmtpClient(smtpServer, smtpPort))
                    {
                        cliente.Credentials = new NetworkCredential(smtpUser, smtpPassword);
                        cliente.EnableSsl = enableSsl;

                        await cliente.SendMailAsync(mensaje);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EnviarPresupuestoAsync(
            string destinatario,
            string nombreCliente,
            List<(string Producto, decimal Precio, int Cantidad)> productos,
            decimal total)
        {
            var sb = new StringBuilder();

            sb.Append($@"
                <html>
                <body style='font-family: Arial, sans-serif; color: #333;'>
                    <h2>Presupuesto de RaiseApp</h2>
                    <p>Hola <strong>{nombreCliente}</strong>,</p>
                    <p>Te enviamos el detalle de tu presupuesto. Tenés 48 horas para convertirlo en una venta efectiva.</p>

                    <table style='border-collapse: collapse; width: 100%; margin-top: 15px;'>
                        <thead>
                            <tr style='background-color: #1570EE; color: white; text-align: left;'>
                                <th style='padding: 8px;'>Producto</th>
                                <th style='padding: 8px;'>Cantidad</th>
                                <th style='padding: 8px;'>Precio unitario</th>
                                <th style='padding: 8px;'>Subtotal</th>
                            </tr>
                        </thead>
                        <tbody>");

            foreach (var p in productos)
            {
                decimal subtotal = p.Precio * p.Cantidad;
                sb.Append($@"
                            <tr>
                                <td style='padding: 8px; border-bottom: 1px solid #ddd;'>{p.Producto}</td>
                                <td style='padding: 8px; border-bottom: 1px solid #ddd;'>{p.Cantidad}</td>
                                <td style='padding: 8px; border-bottom: 1px solid #ddd;'>${p.Precio:N0}</td>
                                <td style='padding: 8px; border-bottom: 1px solid #ddd;'>${subtotal:N0}</td>
                            </tr>");
            }

            sb.Append($@"
                        </tbody>
                    </table>

                    <h3 style='margin-top: 20px;'>Total: <span style='color: #1570EE;'>${total:N0}</span></h3>

                    <p>Gracias por confiar en nosotros.<br>
                    <strong>RaiseApp</strong></p>
                </body>
                </html>");

            string cuerpoHtml = sb.ToString();

            await EnviarCorreoAsync(destinatario, "Presupuesto - RaiseApp", cuerpoHtml);
        }

        public async Task EnviarComprobanteVentaAsync(
    string destinatario,
    string nombreCliente,
    List<(string Producto, decimal Precio, int Cantidad)> productos,
    decimal total)
        {
            byte[] pdfBytes;

            // 🔹 Crear PDF y guardarlo en memoria
            using (var ms = new MemoryStream())
            {
                using (var doc = new Document(PageSize.A4, 40, 40, 40, 40))
                {
                    PdfWriter.GetInstance(doc, ms);
                    doc.Open();

                    var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLUE);
                    var fuenteTexto = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK);

                    doc.Add(new Paragraph("Comprobante de Venta - RaiseApp", fuenteTitulo));
                    doc.Add(new Paragraph($"Cliente: {nombreCliente}", fuenteTexto));
                    doc.Add(new Paragraph($"Fecha: {System.DateTime.Now:dd/MM/yyyy HH:mm}", fuenteTexto));
                    doc.Add(new Paragraph(" "));

                    PdfPTable tabla = new PdfPTable(4) { WidthPercentage = 100 };
                    tabla.SetWidths(new float[] { 40f, 20f, 20f, 20f });

                    string[] headers = { "Producto", "Cantidad", "Precio Unitario", "Subtotal" };
                    foreach (var h in headers)
                    {
                        tabla.AddCell(new PdfPCell(new Phrase(h, fuenteTitulo))
                        {
                            BackgroundColor = new BaseColor(230, 230, 250),
                            HorizontalAlignment = Element.ALIGN_CENTER
                        });
                    }

                    foreach (var p in productos)
                    {
                        decimal subtotal = p.Precio * p.Cantidad;
                        tabla.AddCell(new Phrase(p.Producto, fuenteTexto));
                        tabla.AddCell(new Phrase(p.Cantidad.ToString(), fuenteTexto));
                        tabla.AddCell(new Phrase($"${p.Precio:N2}", fuenteTexto));
                        tabla.AddCell(new Phrase($"${subtotal:N2}", fuenteTexto));
                    }

                    doc.Add(tabla);
                    doc.Add(new Paragraph(" "));
                    var totalParrafo = new Paragraph($"Total: ${total:N2}", fuenteTitulo);
                    totalParrafo.Alignment = Element.ALIGN_RIGHT;
                    doc.Add(totalParrafo);

                    doc.Close();
                }

                // 🔹 Guardamos el contenido antes de que se cierre el stream
                pdfBytes = ms.ToArray();
            }

            // 🔹 Enviar por correo con nuevo MemoryStream
            using (var pdfStream = new MemoryStream(pdfBytes))
            using (var mensaje = new MailMessage())
            {
                mensaje.From = new MailAddress(smtpUser, "RaiseApp");
                mensaje.To.Add(destinatario);
                mensaje.Subject = "Comprobante de Venta - RaiseApp";
                mensaje.Body = "Adjunto comprobante de venta en formato PDF.";
                mensaje.IsBodyHtml = false;

                var adjunto = new Attachment(pdfStream, "ComprobanteVenta.pdf", "application/pdf");
                mensaje.Attachments.Add(adjunto);

                using (var cliente = new SmtpClient(smtpServer, smtpPort))
                {
                    cliente.Credentials = new NetworkCredential(smtpUser, smtpPassword);
                    cliente.EnableSsl = enableSsl;
                    await cliente.SendMailAsync(mensaje);
                }
            }
        }
    }
}