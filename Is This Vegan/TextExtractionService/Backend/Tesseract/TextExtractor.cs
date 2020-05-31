using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Tesseract;
using TextExtractionService.Models;

namespace TextExtractionService.Backend.Tesseract
{
    public class TextExtractor
    {
        private string tessdataPath;
        private string mediaPath;
        public ExtractionModel extraction { get; private set; }
        public Exception exception { get; private set; }

        public TextExtractor(string tessdataPath, string mediaPath) 
        {
            this.tessdataPath = tessdataPath;
            this.mediaPath = mediaPath;
        }

        public bool ExtractFromImageTest(Bitmap image = null)
        { 
            try
            {
                using (var engine = new TesseractEngine(tessdataPath, "eng", EngineMode.Default))
                {
                    
                    // Extract text from test image
                    if (image is null)
                    {
                        image = new Bitmap(Image.FromFile(mediaPath + "\\test_ingredient_list_cropped.jpg"));
                    }

                    // have to load Pix via a bitmap since Pix doesn't support loading a stream.
                    using (var pix = PixConverter.ToPix(image))
                    {
                        using (var page = engine.Process(pix))
                        {
                            var meanConfidenceLabel = String.Format("{0:P}", page.GetMeanConfidence());
                            var resultText = page.GetText();
                            extraction = new ExtractionModel(meanConfidenceLabel, resultText);
                            return true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                exception = e;
                return false;
            }
        }
    }
}