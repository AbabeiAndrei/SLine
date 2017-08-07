using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleRDS.DataLayer.Controllers;
using SimpleRDS.DataLayer.Entities;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;
using System.Diagnostics;

namespace SimpleRDS.Utils
{
    public class Printer
    {
        private readonly SubscriptionRepository _subscriptionRepository;
        private readonly PlanRepository _planRepository;
        private readonly ClientsRepository _clientsRepository;

        public Printer(SubscriptionRepository subscriptionRepository, PlanRepository planRepository, ClientsRepository clientsRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _planRepository = planRepository;
            _clientsRepository = clientsRepository;
        }

        public void ToPdf(Invoice invoices, string path, bool open = true)
        {
            var htmlDocument = GenerateHtml(invoices);
            CreatePDF(htmlDocument, path);
            if(open)
                Process.Start(path);
        }

        private string GenerateHtml(Invoice invoice)
        {
            var client = _clientsRepository.GetById(invoice.ClientId);
            var subscription = _subscriptionRepository.GetById(invoice.SubscriptionId);
            var plan = _planRepository.GetById(subscription.PlanId);

            var items = new InvoiceItemParams[]
            {
                new InvoiceItemParams
                {
                    Name = plan.Name,
                    Price = plan.Price.ToString("N2") + " LEI"
                }
            };

            var invParams = new InvoiceParams
            {
                Serie = invoice.Serie,
                Numar = invoice.Numar,
                Issued = invoice.Date.ToString("d"),
                Due = invoice.Date.AddMonths(1).ToString("d"),
                Address = client.Address,
                City = client.City,
                FullName = client.FullName,
                Phone = client.Phone,
                Items = items,
                Total = "Total " + plan.Price.ToString("N2") + " LEI"
            };

            return GenerateHtml(invParams);
        }

        private string GenerateHtml(InvoiceParams invParams)
        {
            return string.Format(INVOICE_HTML_FORMAT,
                                 invParams.Serie,
                                 invParams.Numar,
                                 invParams.Issued,
                                 invParams.Due,
                                 invParams.Address,
                                 invParams.City,
                                 invParams.FullName,
                                 invParams.Phone,
                                 GenerateItems(invParams.Items),
                                 invParams.Total,
                                 string.Empty);
        }

        private string GenerateItems(IEnumerable<InvoiceItemParams> items)
        {
            return string.Join(string.Empty, items.Select(i => string.Format(INVOICE_HTML_ITEM_FORMAT, i.Name, i.Price)));
        }

        private void CreatePDF(string html, string path)
        {
            using (var memoryStream = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 50, 50, 60, 60);
                var writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                using (var cssMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(INVOICE_STYLE)))
                using (var htmlMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(html)))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, htmlMemoryStream, cssMemoryStream);
                }


                document.Close();

                var a = memoryStream.ToArray();

                File.WriteAllBytes(path, a);
            }
        }

        #region InvoiceHtml

        public const string INVOICE_HTML_FORMAT = "<!doctype html><html><head><meta charset=\"utf-8\"/>" +
                                                  "<title>SLine</title><style>{10}</style></head><body><div class=\"invoice-box\">" +
                                                  "<table cellpadding=\"0\" cellspacing=\"0\"><tr class=\"top\"><td colspan=\"2\">" +
                                                  "<table><tr><td class=\"title\">SLine</td><td>Factura : {0}/{1}<br/>Creata : {2}<br/>Limita : {3}</td>" +
                                                  "</tr></table></td></tr><tr class=\"information\"><td colspan=\"2\"><table><tr><td>{4}<br/>{5}</td>" +
                                                  "<td>{6}<br/>{7}</td></tr></table></td></tr><tr class=\"heading\"><td>Serviciu</td><td>Pret</td>" +
                                                  "</tr>{8}<tr class=\"total\"><td></td><td><b>{9}</b></td></tr></table></div></body></html>";

        public const string INVOICE_HTML_ITEM_FORMAT = "<tr class=\"item\"><td>{0}</td><td>{1}</td></tr>";

        public const string INVOICE_STYLE = ".invoice-box{ max-width:800px; margin:auto; padding:30px; border:1px solid #eee; box-shadow:0 0 10px rgba(0, 0, 0, .15); font-size:16px; line-height:24px; font-family:'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif; color:#555; }  .invoice-box table{ width:100%; line-height:inherit; text-align:left; }  .invoice-box table td{ padding:5px; vertical-align:top; }  .invoice-box table tr td:nth-child(2){ text-align:right; }  .invoice-box table tr.top table td{ padding-bottom:20px; }  .invoice-box table tr.top table td.title{ font-size:45px; line-height:45px; color:#333; }  .invoice-box table tr.information table td{ padding-bottom:40px; }  .invoice-box table tr.heading td{ background:#eee; border-bottom:1px solid #ddd; font-weight:bold; }  .invoice-box table tr.details td{ padding-bottom:20px; }  .invoice-box table tr.item td{ border-bottom:1px solid #eee; }  .invoice-box table tr.item.last td{ border-bottom:none; }  .invoice-box table tr.total td:nth-child(2){ border-top:2px solid #eee; font-weight:bold; }  @media only screen and (max-width: 600px) { .invoice-box table tr.top table td{ width:100%; display:block; text-align:center; }  .invoice-box table tr.information table td{ width:100%; display:block; text-align:center; } }";

        #endregion

        internal class InvoiceParams
        {
            public string Serie { get; set; }

            public string Numar { get; set; }

            public string Issued { get; set; }

            public string Due { get; set; }

            public string Address { get; set; }

            public string City { get; set; }

            public string FullName { get; set; }

            public string Phone { get; set; }

            public string Total { get; set; }

            public IEnumerable<InvoiceItemParams> Items { get; set; }
        }

        internal class InvoiceItemParams
        {
            public string Name { get; set; }

            public string Price { get; set; }
        }
    }

}
