using SimpleLPR2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;//.Tasks;

namespace BMS
{
    public class LibCamera
    {
        // Fields
        private string _licenseFile;
        private ISimpleLPR _lpr;
        private string _version;
        private string _activeCode;
        private bool _brightBackground;
        private float _confidence;
        private Bitmap _imgMain;
        private Bitmap _imgNumberPlate;
        private bool _licenseValid;
        private TimeSpan _recognitionTime;
        private string _text;

        #region Properties
        public bool BrightBackground
        {
            get
            {
                bool bool1;

                bool1 = this._brightBackground;
                return bool1;

            }
        }

        public float Confidence
        {
            get
            {
                float num1;

                num1 = this._confidence;
                return num1;

            }
        }

        public Image ImgMain
        {
            get
            {
                Image image1;

                image1 = this._imgMain;
                return image1;

            }
        }

        public Image ImgNumberPlate
        {
            get
            {
                Image image1;

                image1 = this._imgNumberPlate;
                return image1;

            }
        }

        public int RecognitionTime
        {
            get
            {
                int num1;

                num1 = this._recognitionTime.Milliseconds;
                return num1;

            }
        }

        public string Text
        {
            get
            {
                string str1;

                str1 = this._text;
                return str1;

            }
        }

        public string Version
        {
            get
            {
                string str1;

                str1 = this._version;
                return str1;

            }
        }
        #endregion

        public LibCamera()
        {
            VersionNumber number1;
            Exception exception1;
            object[] objArray1;
            bool bool1;

            this._licenseFile = "AcsLPR.xml";
            this._version = "";
            this._activeCode = string.Empty;
            this._licenseValid = true;
            this._text = "";
            //this.ctor();
            try
            {
                this._licenseValid = true;
                this._lpr = SimpleLPR.Setup();
                number1 = this._lpr.versionNumber;
                objArray1 = new object[3];
                objArray1[0] = number1.A;
                objArray1[1] = number1.B;
                objArray1[2] = number1.C;
                objArray1[3] = number1.D;
                //        this._version = String.Format("{0}.{1}.{2}.{3}", objArray1);
                //        this._licenseValid = LicenseVtwUser.GetVtwLicense(1, Utils.TemplateParth);
                //        this._licenseFile = Utils.CurentRootParthTemp + this._licenseFile;
                //        bool1 = (this._licenseValid == false);
                //        if (bool1 == false)
                //        {
                //            this.CreateLicenseFile();
                //            goto Label_00F2;
                //        }
                //        this.DeleteLicenseFile();
                //Label_00F2:
                //        goto Label_0112;
            }
            catch (Exception exception2)
            {
                //exception1 = exception2;
                //WriteFileLogger.writeFileLog("Setup SimpleLPR: ", exception1.Message);
                //this.DeleteLicenseFile();
                //goto Label_0112;
            }
            //Label_0112:
            return;
        }

        public string NumberPlateRecognition(object imageFile)
        {
            DateTime time1;
            uint num1;
            IProcessor processor1;
            List<Candidate> list1;
            string str1;
            Image image1;
            Exception exception1;
            string str2;
            bool bool1;

            this._imgMain = null;
            this._imgNumberPlate = null;
            this._text = "";
            bool1 = ((imageFile == null) == false);
            if (bool1 == false)
            {
                str2 = this._text;
                goto Label_01A9;
            }
            //bool1 = (this._licenseValid == false);
            bool1 = false;
            if (bool1 == false)
            {
                //this.CreateLicenseFile();
                time1 = DateTime.Now;
                try
                {
                    num1 = 0;
                    //goto Label_006F;
                    //while (bool1 == true)
                    //{
                    //    this._lpr.set_countryWeight(num1, 0);
                    //    num1 = (num1 + 1);
                    //Label_006F:
                    //    bool1 = (num1 < this._lpr.numSupportedCountries);
                    //}

                    for (int i = 0; i < _lpr.numSupportedCountries; i++)
                    {
                        this._lpr.set_countryWeight((uint)i, 0);
                        //num1 = (num1 + i);
                    }

                    this._lpr.set_countryWeight("Vietnam", 1);
                    this._lpr.realizeCountryWeights();
                    this._lpr.set_productKey(this._licenseFile);
                    processor1 = this._lpr.createProcessor();
                    bool1 = ((imageFile.GetType().ToString() == "System.String") == false);
                    if (bool1 == false)
                    {
                        str1 = imageFile.ToString();
                        bool1 = File.Exists(str1);
                        if (bool1 == false)
                        {
                            str2 = "";
                            goto Label_01A9;
                        }
                        image1 = Image.FromFile(str1);
                        this._imgMain = new Bitmap(image1);
                        image1.Dispose();
                        list1 = processor1.analyze(str1, 120);
                        this.DumpCandidates(list1);
                        goto Label_017A;
                    }
                    bool1 = ((imageFile.GetType().ToString() == "System.Drawing.Bitmap") == false);
                    if (bool1 == false)
                    {
                        this._imgMain = ((Bitmap)imageFile);
                        list1 = processor1.analyze(this._imgMain, 120);
                        this.DumpCandidates(list1);
                    }
                Label_017A:
                    goto Label_0183;
                }
                catch (Exception exception2)
                {
                    exception1 = exception2;
                    goto Label_0183;
                }
            Label_0183:
                //this._recognitionTime = DateTime.op_Subtraction(DateTime.Now, time1);
                this._recognitionTime = DateTime.Now - time1;
                goto Label_019F;
            }
            //this.DeleteLicenseFile();
        Label_019F:
            str2 = this._text;
            goto Label_01A9;
        Label_01A9:
            return str2;

        }

        private void DumpCandidates1(IList<Candidate> cds)
        {
            Candidate candidate1;
            int num1;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            Element element1;
            Rectangle rectangle1;
            bool bool1;
            List<Element>.Enumerator enumerator1;
            Rectangle rectangle2;

            bool1 = ((cds.Count == 0) == false);
            if (bool1 == false)
            {
                this._text = "";
                goto Label_02D5;
            }
            //candidate1 = cds.Item[0];
            candidate1 = cds.ElementAt(0);
            num1 = 1;

            //goto Label_005E;
            //while (bool1 == true)
            //{
            //    //bool1 = ((cds.Item[num1].confidence > candidate1.confidence) == false);
            //    bool1 = ((cds.ElementAt(num1).confidence > candidate1.confidence) == false);
            //    if (bool1 == false)
            //    {
            //        //candidate1 = cds.Item[num1];
            //        candidate1 = cds.ElementAt(num1);
            //    }
            //    num1 = (num1 + 1);
            //Label_005E:
            //    bool1 = (num1 < cds.Count);
            //}

            for (int i = 1; i < cds.Count; i++)
            {
                bool1 = ((cds.ElementAt(i).confidence > candidate1.confidence) == false);
                if (bool1 == false)
                {
                    //candidate1 = cds.Item[num1];
                    candidate1 = cds.ElementAt(i);
                }
            }

            this._text = candidate1.text.Replace(".", "");
            this._confidence = candidate1.confidence;
            this._brightBackground = candidate1.brightBackground;
            //num2 = 99999;
            //num3 = 99999;

            num2 = 999;
            num3 = 999;

            num4 = 0;
            num5 = 0;
            num6 = 0;
            num7 = 0;
            
            enumerator1 = candidate1.elements.GetEnumerator();
            try
            {
                //goto Label_01F0;
                while (bool1 == true)
                {
                    //bool1 = enumerator1.MoveNext();
                    //if (bool1) break;
                        
                    element1 = enumerator1.Current;
                    rectangle2 = element1.bbox;
                    bool1 = ((num2 > rectangle2.X) == false);
                    if (bool1 == false)
                    {
                        rectangle2 = element1.bbox;
                        num2 = rectangle2.X;
                    }
                    rectangle2 = element1.bbox;
                    bool1 = ((num3 > rectangle2.Y) == false);
                    if (bool1 == false)
                    {
                        rectangle2 = element1.bbox;
                        num3 = rectangle2.Y;
                    }
                    rectangle2 = element1.bbox;
                    bool1 = ((num4 < rectangle2.X) == false);
                    if (bool1 == false)
                    {
                        rectangle2 = element1.bbox;
                        num4 = rectangle2.X;
                    }
                    rectangle2 = element1.bbox;
                    bool1 = ((num5 < rectangle2.Y) == false);
                    if (bool1 == false)
                    {
                        rectangle2 = element1.bbox;
                        num5 = rectangle2.Y;
                    }
                    rectangle2 = element1.bbox;
                    bool1 = ((num6 < rectangle2.Height) == false);
                    if (bool1 == false)
                    {
                        rectangle2 = element1.bbox;
                        num6 = rectangle2.Height;
                    }
                    rectangle2 = element1.bbox;
                    bool1 = ((num7 < rectangle2.Width) == false);
                    if (bool1 == false)
                    {
                        rectangle2 = element1.bbox;
                        num7 = rectangle2.Width;
                    }
                //Label_01F0:
                //    bool1 = enumerator1.MoveNext();                    
                }
                goto Label_0211;
            }
            finally
            {
                enumerator1.Dispose();
            }
        Label_0211:
            bool1 = ((num2 > 10) == false);
            if (bool1 == false)
            {
                num2 = (num2 - 10);
            }
            bool1 = ((num3 > 5) == false);
            if (bool1 == false)
            {
                num3 = (num3 - 5);
            }
            num4 = (num4 + num7);
            bool1 = (((this._imgMain.Width - num4) > 10) == false);
            if (bool1 == false)
            {
                num4 = (num4 + 10);
                goto Label_026E;
            }
            num4 = this._imgMain.Width;
        Label_026E:
            num5 = (num5 + num6);
            bool1 = (((this._imgMain.Height - num5) > 5) == false);
            if (bool1 == false)
            {
                num5 = (num5 + 5);
                goto Label_02A4;
            }
            num5 = this._imgMain.Height;
        Label_02A4:
            rectangle1 = new Rectangle(num2, num3, (num4 - num2), (num5 - num3));
            this._imgNumberPlate = this._imgMain.Clone(rectangle1, this._imgMain.PixelFormat);
        Label_02D5:
            return;
        }

        private void DumpCandidates2(IList<Candidate> cds)
        {
            Candidate candidate1;
            Rectangle rectangle1;

            if (cds.Count == 0) return;

            candidate1 = cds.ElementAt(0);

            for (int i = 1; i < cds.Count; i++)
            {
                if (cds.ElementAt(i).confidence < candidate1.confidence)
                {
                    candidate1 = cds.ElementAt(i);
                }
            }

            this._text = candidate1.text.Replace(".", "");
            this._confidence = candidate1.confidence;
            this._brightBackground = candidate1.brightBackground;

            int x =0;
            int y = 0;
            int width = 0;
            int height = 0;
            
            Element p0 = candidate1.elements[0];

            bool bienVuong = false;
            int xuongDong = 0;
            int dai = 0;
            for (int i = 1; i <  candidate1.elements.Count; i++)
            {
                Element e = candidate1.elements[i];
                if (Math.Abs(e.bbox.Y - p0.bbox.Y)>30)
                {
                    bienVuong = true;
                    xuongDong = i;
                    break;
                    //dai += e.bbox.Width;
                }
            }

            if (!bienVuong)
            {
                //Biển dài
                x = candidate1.elements[0].bbox.X - 5;
                y = candidate1.elements[0].bbox.Y - 5;
                width = candidate1.elements.Sum(o => o.bbox.Width) + p0.bbox.Width * 3;
                height = candidate1.elements.Max(o => (o.bbox.Height + 6));
            }
            else
            {
                //Biển vuông
                for (int i = xuongDong; i < candidate1.elements.Count; i++)
                {
                    dai += candidate1.elements[i].bbox.Width;
                }
                width = dai + p0.bbox.Width * 3;
                height = candidate1.elements.Max(o => (o.bbox.Height + 6));
                x = candidate1.elements[xuongDong].bbox.X - 6;
                y = candidate1.elements[xuongDong].bbox.Y - 6 - height;
               
                height = candidate1.elements.Max(o => (o.bbox.Height + 6))*2+20;
            }           
            
            rectangle1 = new Rectangle(x, y, width, height);
            this._imgNumberPlate = this._imgMain.Clone(rectangle1, this._imgMain.PixelFormat);

        }

        private void DumpCandidates(IList<Candidate> cds)
        {
            Candidate candidate1;
            Rectangle rectangle1;

            if (cds.Count == 0) return;

            candidate1 = cds.ElementAt(0);

            for (int i = 1; i < cds.Count; i++)
            {
                if (cds.ElementAt(i).confidence < candidate1.confidence)
                {
                    candidate1 = cds.ElementAt(i);
                }
            }

            this._text = candidate1.text.Replace(".", "");
            this._confidence = candidate1.confidence;
            this._brightBackground = candidate1.brightBackground;
            
            int ymin = candidate1.elements.Min(o => o.bbox.Y);
            int ymax = candidate1.elements.Max(o => o.bbox.Y);
            int xmin = candidate1.elements.Min(o => o.bbox.X);
            int xmax = candidate1.elements.Max(o => o.bbox.X);

            var eMin = candidate1.elements.FirstOrDefault(o => o.bbox.Y == ymin);
            var eMax = candidate1.elements.FirstOrDefault(o => o.bbox.Y == ymax);

            rectangle1 = new Rectangle(xmin, ymin, xmax + candidate1.elements.Max(o => o.bbox.Width) - xmin, ymax + candidate1.elements.Max(o => o.bbox.Height) - ymin);
            this._imgNumberPlate = this._imgMain.Clone(rectangle1, this._imgMain.PixelFormat);

        }
    }
}
