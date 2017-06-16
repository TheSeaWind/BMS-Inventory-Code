using BMS.Business;
using BMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA_Utility;


namespace BMS
{
    public partial class frmParking : _Forms
    {
        VLCVideoPlay[] _vlcPlayer;
        LibCamera _libCam;
        public frmParking()
        {
            InitializeComponent();
        }

        private void frmParking_Load(object sender, EventArgs e)
        {
            InitCamera();
            _libCam = new LibCamera();
            loadData();
            loadcboParkingPalletData();
        }

        private void InitCamera()
        {
            string url = textBox1.Text;
            _vlcPlayer = new VLCVideoPlay[1];
            _vlcPlayer[0] = new VLCVideoPlay();
            _vlcPlayer[0].CameraName = "Cam " + (0 + 1);
            _vlcPlayer[0].ParkingLineLocation = "LEFT";
            _vlcPlayer[0].video_url = url;//"rtsp://admin:123@123a@192.168.20.240:1554/Streaming/Unicast/channels/" + (i + 1) + "01";
            _vlcPlayer[0].IsLPR = true;
            _vlcPlayer[0].IPCamPlayStart();

            _vlcPlayer[0].SetHandle(pictureBox1);
        }

        void loadData()
        {
            DataTable dt = TextUtils.Select("select * from vParking");
            grdData.DataSource = dt;
        }

        void loadcboParkingPalletData()
        {
            DataTable tbl = TextUtils.Select("Select ID, Code, Name, ParkingBlockCode, ParkingAreaCode from vParkingPallet where Active = 1 and Empty = 1");
            cboParkingPallet.Properties.DataSource = tbl;
            cboParkingPallet.Properties.DisplayMember = "Name";
            cboParkingPallet.Properties.ValueMember = "ID";

            cboParkingPallet.EditValue = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cboParkingPallet.EditValue == null)
            {
                MessageBox.Show("Chưa chọn vị trí");
                return;
            }
            string filePathImage = Application.StartupPath + string.Format("\\Images\\{0:yyMMddHHmmss}_{1}.jpg", DateTime.Now, _vlcPlayer[0].CameraName);
            _vlcPlayer[0].IPImageCapture(filePathImage);

            //Bitmap newBitmap = new Bitmap(filePathImage);
            //Bitmap newBitmap = new Bitmap(new Bitmap(filePathImage), 200, 200);
            //newBitmap.Save(@"D:\\a.jpg");
            //newBitmap.SetResolution(50, 50);
            //newBitmap.Save("file300.jpg", ImageFormat.Jpeg);
            //newBitmap.Width = 640;
            //newBitmap.Height = 480;
            
            string licensePlate = "";
            licensePlate = _libCam.NumberPlateRecognition(filePathImage);
            //licensePlate = _libCam.NumberPlateRecognition(newBitmap);
            this.picLeftLPRIn1.Image = _libCam.ImgNumberPlate;
            txtLeftLicensePlateIn1.Text = licensePlate;

            //DataTable dt = (DataTable)grdData.DataSource;
            //DataRow[] drs = dt.Select("InLicensePlate = '" + licensePlate + "'");
            //if (drs.Length > 0) return;

            ParkingModel m = new ParkingModel();
            m.InLicensePlate = licensePlate;
            m.ReadLicensePlateOk = m.InLicensePlate.Length >= 7 ? true : false;
            m.InTime = DateTime.Now;
            m.InImagePath1 = filePathImage;
            m.ParkingPalletID = TextUtils.ToInt(cboParkingPallet.EditValue);
            ParkingBO.Instance.Insert(m);

            ParkingPalletModel p = (ParkingPalletModel)ParkingPalletBO.Instance.FindByPK(m.ParkingPalletID);
            if(p != null)
            {
                p.Empty = false;
                ParkingPalletBO.Instance.Update(p);
            }

            loadData();
            loadcboParkingPalletData();
        }

        private void frmParking_FormClosed(object sender, FormClosedEventArgs e)
        {
            _vlcPlayer[0].DiskPlayStop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextUtils.OpenForm(new frmPreviewLed());
        }
    }
}
