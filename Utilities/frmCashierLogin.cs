using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CEFA.Business;
using CEFA.Model;
using CEFA.Facade;
using CEFA.Utils;
namespace CEFA
{
    public partial class frmCashierLogin : Form
    {
        #region Khai báo các biến dùng chung
        public bool IsProcess = false;
        #endregion

        #region Load Form
        public frmCashierLogin()
        {
            InitializeComponent();
        }
        #endregion

        #region các sự kiện cơ bản

        private void txtCashierNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        #endregion

        #region Các sự kiện phát sinh trên Form


        #endregion

        #region Các hàm viêt thêm

        /// <summary>
        /// Hàm không cho di chuyển Form
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 161;
            const int WM_SYSCOMMAND = 274;
            const int HTCAPTION = 2;
            const int SC_MOVE = 61456;

            if ((m.Msg == WM_SYSCOMMAND) && (m.WParam.ToInt32() == SC_MOVE))
                return;
            if ((m.Msg == WM_NCLBUTTONDOWN) && (m.WParam.ToInt32() == HTCAPTION))
                return;

            base.WndProc(ref m);
        }

        private void Login()
        {
            int UserID = 0;
            string UserName = "";
            int ShiftID = 0;
            string Err = "";

            try
            {
                if (TextUtils.CashierLogin(txtCashierNo.Text, txtPass.Text, ref UserID, ref ShiftID, ref Err) == true)
                {
                    UsersModel mU=((UsersModel)UsersBO.Instance.FindByPK(UserID));
                    Global.ShiftID = ShiftID;
                    Global.UserID = UserID;
                    Global.AppFullName = txtCashierNo.Text;
                    Global.AppFullName = mU.FirstName + " " + mU.MiddleName +" " + mU.LastName;
                    Global.CashierNo = mU.CashierNo.ToString();
                    DataTable dtRoot = TextUtils.Select("select KeyValue from ConfigSystem where KeyName='_ROOT_USER'");
                    if (dtRoot.Rows.Count == 0)
                        Global.IsRoot = false;
                    else
                    {
                        if (dtRoot.Rows[0][0].ToString().Trim().ToUpper()==Global.AppUserName.ToUpper())
                            Global.IsRoot = true;
                        else
                            Global.IsRoot = false;
                    }
                    IsProcess = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng !", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thống báo");
                //frmGenMessageBox frm = new frmGenMessageBox("KienNT", this.Name, "btnLogin_Click", TextUtils.Caption,
                //                                             MessageLibrary._SystemMessage, ex.Message, MessageBoxIcon.Error);
                //frm.ShowDialog();
                return;
            }
        }

        #endregion

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsProcess = false;
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Login();
        }
    }
}