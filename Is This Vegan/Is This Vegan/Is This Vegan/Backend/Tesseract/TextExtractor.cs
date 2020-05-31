/*
 * Created by SharpDevelop.
 * User: W110
 * Date: 15/12/2013
 * Time: 8:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using SkiaSharp;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using Tesseract;
using Windows.Graphics.Imaging;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Is_This_Vegan.Backend.Tesseract
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public class TextExtractor
    {

        #region Data

        // input panel controls

        //protected Panel inputPanel;
        //protected HtmlInputFile imageFile;
        //protected HtmlButton submitFile;

        //// result panel controls
        //protected Panel resultPanel;
        //protected HtmlGenericControl meanConfidenceLabel;
        //protected HtmlTextArea resultText;
        //protected HtmlButton restartButton;


        #endregion

        public TextExtractor() { }

        public async System.Threading.Tasks.Task<bool> ExtractFromImageTestAsync(Bitmap image = null)
        {
                try
                {
                    var httpClient = new HttpClient();
                    var response = await httpClient.GetStringAsync("http://localhost:44378/api/textextractor/test");
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
        }

        private void OnSubmitFileClicked(object sender, EventArgs args)
        {
        //    if (imageFile.PostedFile != null && imageFile.PostedFile.ContentLength > 0)
        //    {
        //        // for now just fail hard if there's any error however in a propper app I would expect a full demo.

        //        using (var engine = new TesseractEngine("TesseractData", "eng", EngineMode.Default))
        //        {
        //            // have to load Pix via a bitmap since Pix doesn't support loading a stream.
        //            using (var image = new System.Drawing.Bitmap(imageFile.PostedFile.InputStream))
        //            {
        //                using (var pix = Pix.LoadFromFile(image))
        //                {
        //                    using (var page = engine.Process(pix))
        //                    {
        //                        meanConfidenceLabel.InnerText = String.Format("{0:P}", page.GetMeanConfidence());
        //                        resultText.InnerText = page.GetText();
        //                    }
        //                }
        //            }
        //        }
        //        inputPanel.Visible = false;
        //        resultPanel.Visible = true;
        //    }
        }
    }
}