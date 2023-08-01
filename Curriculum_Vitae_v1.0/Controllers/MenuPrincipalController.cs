using QRCoder;
using System.Drawing;
using System.IO;
using System.Web.Mvc;

namespace Curriculum_Vitae.Controllers
{
    public class MenuPrincipalController : Controller
    {
        // GET: MenuPrincipal
        [HttpGet]
        public ActionResult Inicio()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Inicio(string txtQRCode)
        {
            ViewBag.txtqRCode = txtQRCode;

            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(txtQRCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(qRCodeData);

            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();

            imgBarCode.Height = 3;
            imgBarCode.Width = 3;

            using (Bitmap bitmap = qRCode.GetGraphic(3))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    ViewBag.imageBytes = ms.ToArray();
                }
            }

            return View();
        }
        public ActionResult HistorialAcademico()
        {
            return View();
        }
        public ActionResult HistorialProfesional()
        {
            return View();
        }
        public ActionResult Descarga()
        {
            return View();
        }
        public ActionResult Contactame()
        {
            return View();
        }

    }
}