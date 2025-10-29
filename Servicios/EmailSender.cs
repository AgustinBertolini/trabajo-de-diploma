using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
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
            this.smtpServer= "smtp.gmail.com";
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
            var fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            var nroComprobante = new Random().Next(100000, 999999); 

            var sb = new StringBuilder();

            sb.Append($@"
        <html>
        <body style='font-family: Arial, sans-serif; color: #333;'>
            <div style='border: 1px solid #ccc; padding: 20px; border-radius: 8px; max-width: 700px; margin: 0 auto;'>
                <h2 style='text-align: center; color: #1570EE;'>Comprobante de Venta</h2>

                <p style='text-align:center; margin-bottom: 30px;'>
                    <strong>RaiseApp S.R.L.</strong><br>
                    Fecha de emisión: {fecha}<br>
                    N° de comprobante: <strong>0001-{nroComprobante}</strong>
                </p>

                <p>Estimado/a <strong>{nombreCliente}</strong>,</p>
                <p>Tu compra ha sido procesada <strong>con éxito</strong>. Este comprobante tiene validez como constancia de la operación realizada.</p>

                <table style='border-collapse: collapse; width: 100%; margin-top: 15px;'>
                    <thead>
                        <tr style='background-color: #1570EE; color: white; text-align: left;'>
                            <th style='padding: 8px;'>Producto</th>
                            <th style='padding: 8px;'>Cantidad</th>
                            <th style='padding: 8px;'>Precio Unitario</th>
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
                            <td style='padding: 8px; border-bottom: 1px solid #ddd;'>${p.Precio:N2}</td>
                            <td style='padding: 8px; border-bottom: 1px solid #ddd;'>${subtotal:N2}</td>
                        </tr>");
            }

            decimal iva = total * 0.21m;
            decimal totalConIva = total + iva;

            sb.Append($@"
                    </tbody>
                </table>

                <div style='margin-top: 20px; text-align: right;'>
                    <h3 style='color: #1570EE;'>Total Final - IVA Incluido: ${total}</h3>
                </div>

                <hr style='margin-top: 30px; margin-bottom: 20px;'>
                <p style='font-size: 12px; color: #666; text-align: center;'>
                    Este comprobante fue emitido de manera electrónica y tiene validez ante posibles reclamos.<br>
                    Gracias por tu compra.<br>
                    <strong>RaiseApp</strong>
                </p>
            </div>
        </body>
        </html>");

            string cuerpoHtml = sb.ToString();

            await EnviarCorreoAsync(destinatario, "Comprobante de Venta - RaiseApp", cuerpoHtml);
        }

    }
}
