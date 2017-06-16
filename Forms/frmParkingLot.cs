using BMS.Business;
using BMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMS
{
    public partial class frmParkingLot : _Forms
    {
        private bool _isAdd;
        public frmParkingLot()
        {
            InitializeComponent();
        }

        private void frmParkingLot_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        }

        #region Methods
        private void SetInterface(bool isEdit)
        {
            txtCode.ReadOnly = !isEdit;

            grdData.Enabled = !isEdit;

            btnSave.Visible = isEdit;
            btnCancel.Visible = isEdit;

            btnNew.Visible = !isEdit;
            btnEdit.Visible = !isEdit;
            btnDelete.Visible = !isEdit;
        }

        private void ClearInterface()
        {
            txtName.Text = "";
            txtCode.Text = "";
            txtAddress.Text = "";
            txtPhoneNumber.Text = "";
        }

        private bool checkValid()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Xin hãy điền mã của bãi xe.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (!_isAdd)
                {
                    int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID"));
                    dt = TextUtils.Select("select Code from ParkingLot where Code = '" + txtCode.Text.Trim() + "' and ID <> " + strID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from ParkingLot where Code = '" + txtCode.Text.Trim() + "'");
                }
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Xin hãy điền tên của bãi xe.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
          
            return true;
        }

        private void LoadData()
        {
            try
            {
                DataTable tbl = TextUtils.Select("SELECT * FROM ParkingLot");
                grdData.DataSource = tbl;
            }
            catch (Exception)
            {
            }

        }
        #endregion
        
        #region Buttons Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetInterface(true);
            _isAdd = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;
            SetInterface(true);
            _isAdd = false;
            txtName.Text =TextUtils.ToString(grvData.GetRowCellValue(grvData.FocusedRowHandle, "Name"));
            txtCode.Text = TextUtils.ToString(grvData.GetRowCellValue(grvData.FocusedRowHandle, "Code"));
            chkActive.Checked = TextUtils.ToBoolean(grvData.GetRowCellValue(grvData.FocusedRowHandle, "Active"));
            txtPhoneNumber.Text = TextUtils.ToString(grvData.GetFocusedRowCellValue(colPhoneNumber));
            txtAddress.Text = TextUtils.ToString(grvData.GetFocusedRowCellValue(colAddress));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvData.GetFocusedRowCellValue("ID"));

            string strName = TextUtils.ToString(grvData.GetFocusedRowCellValue("Name"));

            if (ParkingAreaBO.Instance.CheckExist("ParkingLotID", strID))
            {
                MessageBox.Show("Bãi này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa [{0}] không?", strName), TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ParkingLotBO.Instance.Delete(Convert.ToInt32(strID));
                    LoadData();
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkValid())
                {
                    ParkingLotModel dModel;
                    if (_isAdd)
                    {
                        dModel = new ParkingLotModel();
                    }
                    else
                    {
                        int ID = Convert.ToInt32(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString());
                        dModel = (ParkingLotModel)ParkingLotBO.Instance.FindByPK(ID);
                    }
                    dModel.Code = txtCode.Text.Trim();
                    dModel.Name = txtName.Text.Trim();
                    dModel.Active = chkActive.Checked;
                    dModel.Address = txtAddress.Text.Trim();
                    dModel.PhoneNumber = txtPhoneNumber.Text.Trim();

                    if (_isAdd)
                    {
                        ParkingLotBO.Instance.Insert(dModel);
                    }
                    else
                        ParkingLotBO.Instance.Update(dModel);

                    LoadData();
                    SetInterface(false);
                    ClearInterface();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetInterface(false);
            ClearInterface();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void grdData_DoubleClick(object sender, EventArgs e)
        {
            if (grvData.RowCount > 0 && btnEdit.Enabled == true)
                btnEdit_Click(null, null);
        }
    }
}
