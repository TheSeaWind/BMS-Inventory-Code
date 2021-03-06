using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using BMS.Utils;
using System.Diagnostics;
using System.Net;
using System.Data;
using Microsoft.VisualBasic.Devices;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using BMS.Model;
using BMS.Business;
using Microsoft.Win32;
using DevExpress.Utils;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;

namespace BMS
{
    public partial class frmMain : _Forms
    {
        private const string CURRENT_VERSION = "14.07.2014";
        //bool _loginOK = false;
        bool _isUpdated = false;
        bool _logOut = false;

        public frmMain()
        {
            if (!_isUpdated)// && ConnectdToBD)
            {
                frmLogin frm = new frmLogin();
                frm.ShowDialog();
                //_loginOK = frm.loginSuccess;
                if (frm.loginSuccess == false)
                { Application.Exit(); return; }
            }            
           
            InitializeComponent();            
        }

        #region Các sụ kiện liên quan đến phím tắt.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool handled = false;
            //if (keyData.ToString().Equals("Escape"))
            //    return true;
            if (keyData.ToString().Equals("Alt + F4"))
                Application.Exit();
            ShortcutKey.LoadFormShortcutKey(this, keyData.ToString(), ref handled);
            //return base.ProcessCmdKey(ref msg, keyData);
            return (handled || base.ProcessCmdKey(ref msg, keyData));
        }
        #endregion

        private void Main_Load(object sender, EventArgs e)
        {
            if (Application.StartupPath.Contains("Share"))
            {
                _isUpdated = false;
                this.Close();
            }

            if (_isUpdated)
            {
                this.Close();
            }

            //timer1.Enabled = notifyIconPartWarning.Visible = notifyYCMVTwarning.Visible = Global.DepartmentID == 6;

            #region Thông báo
            //notifyIconPartWarning.Visible = Global.DepartmentID == 1;
            //if (Global.DepartmentID == 1)//phòng thiết kế
            //{
            //    //Theo dõi vật tư
            //    frmMainVatTu frm = new frmMainVatTu();
            //    frm.WindowState = FormWindowState.Minimized;
            //    TextUtils.OpenForm(frm);
            //    frm.Hide();
            //}

            ////Theo dõi công việc
            ////frmTheoDoiCongViec frm1 = new frmTheoDoiCongViec();
            //frmWorkDiaryManager frm1 = new frmWorkDiaryManager();
            //frm1.WindowState = FormWindowState.Minimized;
            //TextUtils.OpenForm(frm1);
            //frm1.Hide();
            #endregion

            PopupInformationSys();
            SetMainView();

            try
            {
                RegistryKey rkey = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);
                if (!rkey.GetValue("sShortDate", "MM/dd/yy").ToString().Contains("M/yyyy"))
                {
                    //if (MessageBox.Show("Định dạng ngày tháng trên máy của bạn không phải là định dạng của Việt Nam (ngày/tháng/năm - dd/MM/yyyy)\n Bạn có muốn đổi lại định dạng ngày tháng không ?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //{
                    rkey.SetValue("sShortDate", "dd/MM/yyyy");
                    //}
                }
                rkey.Close();
            }
            catch
            {                
            }            

            DefValues.Sql_MinDate = new DateTime(1900, 01, 01);            
        }       

        private void CheckAutoUpdate()
        {
            try
            {
                if (!_isUpdated)
                    return;
                try
                {
                    this.Hide();
                    MessageBox.Show("Đã có phiên bản mới của phần mềm để cập nhật.\nBạn hãy chắc chắn rằng mình đang đăng nhập vào Windows với quyền Admin để update phần mềm", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    using (Process compiler = new Process())
                    {
                        compiler.StartInfo.FileName = Application.StartupPath + @"\AutoUpdater.exe";
                        compiler.StartInfo.UseShellExecute = false;
                        compiler.StartInfo.RedirectStandardOutput = false;
                        compiler.Start();
                    }
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("Kết nối tới máy chủ thất bại!\nHãy liên hệ với quản trị hệ thống để được trợ giúp", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetMainView()
        {
            //switch (TextUtils.ToInt(Global.MainViewID))
            //{
                //case 2:
                //    ribbonControl1.SelectedPage = ribbonAccounting;
                //    break;
                //case 3:
                //    ribbonControl1.SelectedPage = ribbonBuildingManage;
                //    break;
                //default: //case 4:
                    //ribbonControl1.SelectedPage = ribbonWareHouse;
                    //break;
                //case 5:
                    ribbonControl1.SelectedPage = ribbonCSKH;
                //    break;
                //case 6:
                //    ribbonControl1.SelectedPage = ribbonHKP;
                //    break;
                //default:
                //     ribbonControl1.SelectedPage = ribbonDefault;
                //     break;
            //}
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }


        public void PopupInformationSys()
        {
            try
            {
                lblVersion.Text = string.Format("Phiên bản : {0}   |   ", CURRENT_VERSION);
                // Get Connection string.
                string[] _Conn = Global.ConnectionString.Split(';');
                lblServer.Text = _Conn[0].Split('=')[1].ToString().Trim() + " / " + _Conn[1].Split('=')[1].ToString().Trim() + "   |   ";

                lblBusinessDate.Text = "System Date: " + TextUtils.GetSystemDate().ToString("dd/MM/yyyy") + "   |  ";
                if (Global.IsNotCreateSession) { lblUser.Text = "Login By: " + Global.AppFullName + "  |  "; }
                else { lblUser.Text = "Login By: " + Global.AppFullName + " (Shift ID: " + Global.ShiftID + ")   |  "; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
        }

        private void btnExit_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
            else
                return;
        }


        private void btnStaffManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmStaffManager frm = new frmStaffManager();
            TextUtils.OpenForm(frm); //TextUtils.TextUtils.OpenForm();
        }
       
     

        private void btnDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDepartment frm = new frmDepartment();
            TextUtils.OpenForm(frm);
        }

        private void btnPermission_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPermissionManager frm = new frmPermissionManager();
            TextUtils.OpenForm(frm);
        }

        private void btnMakeRole_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmRole frm = new frmRole();
            TextUtils.OpenForm(frm);
        }

        bool _update = false;
        private void cậpNhậtPhầnMềmAutoUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn update phần mềm không?",TextUtils.Caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _update = true;
                this.Close();
            }            
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.ShowDialog();
        }

        private void btnPermission_Click(object sender, EventArgs e)
        {
            frmPermissionManager frm = new frmPermissionManager();
            TextUtils.OpenForm(frm);
        }

        private void btnMakeRole_Click(object sender, EventArgs e)
        {
            frmRole frm = new frmRole();
            TextUtils.OpenForm(frm);
        }

     

        private void btnModuleManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmModuleManager frm = new frmModuleManager();
            //TextUtils.OpenForm(frm);
        }       

        private void ConfigSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfigSystem frm = new frmConfigSystem();
            TextUtils.OpenForm(frm);
        }

        private void btnSuppliers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmCustomer frm = new frmCustomer();
            //TextUtils.OpenForm(frm);
        }
       
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _logOut = true;
            this.Close();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void pHÂNQUYỀNTHEONHÓMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextUtils.OpenForm(new frmPermissionGroup());
        }

        private void btnArea_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TextUtils.OpenForm(new frmParkingArea());
        }

        private void btnUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TextUtils.OpenForm(new frmStaffManager());
        }

        private void btnDepartment_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TextUtils.OpenForm(new frmStaffGroup());
        }

        private void btnParkingLot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TextUtils.OpenForm(new frmParkingLot());
        }

        private void btnBlock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TextUtils.OpenForm(new frmParkingBlock());
        }

        private void btnBuidlingM_Vehicle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TextUtils.OpenForm(new frmParking());
        }

        private void btnSlot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TextUtils.OpenForm(new frmParkingPallet());
        }

        private void btnCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TextUtils.OpenForm(new frmCustomer());
        }

        private void btnVehicleType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TextUtils.OpenForm(new frmVehicleType());
        }

        private void btnCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TextUtils.OpenForm(new frmParkingCard());
        }

        private void btnCamera_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TextUtils.OpenForm(new frmCamera());
        }

        private void btnReader_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TextUtils.OpenForm(new frmReader());
        }
    }
}