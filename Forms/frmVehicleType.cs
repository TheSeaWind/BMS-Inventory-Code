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
    public partial class frmVehicleType : _Forms
    {
        private bool _isAdd;
        public frmVehicleType()
        {
            InitializeComponent();
        }

        private void frmVehicleType_Load(object sender, EventArgs e)
        {
            loadParkingLot();
            loadData();
        }
        #region Methods
        private void setInterface(bool isEdit)
        {
            txtCode.ReadOnly = !isEdit;

            grdData.Enabled = !isEdit;

            btnSave.Visible = isEdit;
            btnCancel.Visible = isEdit;

            btnNew.Visible = !isEdit;
            btnEdit.Visible = !isEdit;
            btnDelete.Visible = !isEdit;
        }

        private void clearInterface()
        {
            txtName.Text = "";
            txtCode.Text = "";
            txtHeight.EditValue = 0;
            txtLength.EditValue = 0;
            txtWeight.EditValue = 0;
            txtWidth.EditValue = 0;
        }

        private bool checkValid()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Xin hãy điền mã của loại xe.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (!_isAdd)
                {
                    int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID"));
                    dt = TextUtils.Select("select Code from VehicleType where Code = '" + txtCode.Text.Trim() + "' and ID <> " + strID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from VehicleType where Code = '" + txtCode.Text.Trim() + "'");
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
                MessageBox.Show("Xin hãy điền tên của loại xe.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboParkingLot.EditValue == null)
            {
                MessageBox.Show("Xin hãy chọn một bãi xe.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        private void loadData()
        {
            try
            {
                DataTable tbl = TextUtils.Select("SELECT * FROM VehicleType");
                grdData.DataSource = tbl;
            }
            catch (Exception)
            {
            }

        }

        void loadParkingLot()
        {
            try
            {
                DataTable tblPL = TextUtils.Select("Select ID, Code, Name from ParkingLot with(nolock)");
                cboParkingLot.Properties.DataSource = tblPL;
                cboParkingLot.Properties.DisplayMember = "Name";
                cboParkingLot.Properties.ValueMember = "ID";
            }
            catch
            {
            }
        }
        #endregion

        #region Buttons Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            setInterface(true);
            _isAdd = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;
            setInterface(true);
            _isAdd = false;
            txtName.Text = TextUtils.ToString(grvData.GetFocusedRowCellValue("Name"));
            txtCode.Text = TextUtils.ToString(grvData.GetFocusedRowCellValue("Code"));
            chkActive.Checked = TextUtils.ToBoolean(grvData.GetFocusedRowCellValue("Active"));
            txtWidth.EditValue = TextUtils.ToString(grvData.GetFocusedRowCellValue("Width"));
            txtWeight.EditValue = TextUtils.ToString(grvData.GetFocusedRowCellValue("Weight"));
            txtLength.EditValue = TextUtils.ToString(grvData.GetFocusedRowCellValue("Length"));
            txtHeight.EditValue = TextUtils.ToString(grvData.GetFocusedRowCellValue("Height"));
            cboParkingLot.EditValue = TextUtils.ToInt(grvData.GetFocusedRowCellValue("ParkingLotID"));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvData.GetFocusedRowCellValue("ID"));

            string strName = TextUtils.ToString(grvData.GetFocusedRowCellValue("Name"));

            //if (ParkingAreaBO.Instance.CheckExist("ParkingLotID", strID))
            //{
            //    MessageBox.Show("Bãi này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa [{0}] không?", strName), TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    CustomerBO.Instance.Delete(Convert.ToInt32(strID));
                    loadData();
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
                if (!checkValid()) return;

                VehicleTypeModel dModel;
                if (_isAdd)
                {
                    dModel = new VehicleTypeModel();
                }
                else
                {
                    int ID = Convert.ToInt32(grvData.GetFocusedRowCellValue("ID"));
                    dModel = (VehicleTypeModel)VehicleTypeBO.Instance.FindByPK(ID);
                }
                dModel.Code = txtCode.Text.Trim();
                dModel.Name = txtName.Text.Trim();
                dModel.Active = chkActive.Checked;

                dModel.Height = TextUtils.ToDecimal(txtHeight.EditValue);
                dModel.Length = TextUtils.ToDecimal(txtLength.EditValue);
                dModel.Weight = TextUtils.ToDecimal(txtWeight.EditValue);
                dModel.Width = TextUtils.ToDecimal(txtWidth.EditValue);

                dModel.ParkingLotID = TextUtils.ToInt(cboParkingLot.EditValue);

                if (_isAdd)
                {
                    VehicleTypeBO.Instance.Insert(dModel);
                }
                else
                    VehicleTypeBO.Instance.Update(dModel);

                loadData();
                setInterface(false);
                clearInterface();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setInterface(false);
            clearInterface();
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
