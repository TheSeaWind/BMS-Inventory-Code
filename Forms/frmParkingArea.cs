using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Utils;
using BMS.Model;
using BMS.Business;
using BMS;

namespace BMS
{
    public partial class frmParkingArea : _Forms
    {
        private bool _isAdd;

        public frmParkingArea()
        {
            InitializeComponent();
        }

        private void frmParkingArea_Load(object sender, EventArgs e)
        {
            try
            {
                loadParkingLot();
                loadData();
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
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
        }

        private bool checkValid()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền mã của khu vực.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (!_isAdd)
                {
                    int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID"));
                    dt = TextUtils.Select("select Code from ParkingArea where Code = '" + txtCode.Text.Trim() + "' and ID <> " + strID);                    
                }
                else
                {
                    dt = TextUtils.Select("select Code from ParkingArea where Code = '" + txtCode.Text.Trim() + "'");                    
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
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền tên của khu vực.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboParkingLot.EditValue == null)
            {
                 MessageBox.Show("Xin hãy chọn một bãi xe.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
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
        private void loadData()
        {
            try
            {
                DataTable tbl = TextUtils.Select("SELECT * FROM vParkingArea");
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
            setInterface(true);
            _isAdd = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;
            setInterface(true);
            _isAdd = false;
            txtName.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "Name").ToString();
            txtCode.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "Code").ToString();
            chkActive.Checked = TextUtils.ToBoolean(grvData.GetRowCellValue(grvData.FocusedRowHandle, "Active"));
            cboParkingLot.EditValue = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colParkingLotID));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID"));

            string strName = TextUtils.ToString(grvData.GetRowCellValue(grvData.FocusedRowHandle, "Name"));

            if (ParkingBlockBO.Instance.CheckExist("ParkingAreaID", strID))
            {
                MessageBox.Show("Khu vực này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa [{0}] không?", strName), TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ParkingAreaBO.Instance.Delete(Convert.ToInt32(strID));
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
                if (checkValid())
                {
                    ParkingAreaModel dModel;
                    if (_isAdd)
                    {
                        dModel = new ParkingAreaModel();                       
                    }
                    else
                    {
                        int ID = Convert.ToInt32(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString());
                        dModel = (ParkingAreaModel)ParkingAreaBO.Instance.FindByPK(ID);
                    }
                    dModel.Code = txtCode.Text.Trim();
                    dModel.Name = txtName.Text.Trim();
                    dModel.Active = chkActive.Checked;
                    dModel.ParkingLotID = TextUtils.ToInt(cboParkingLot.EditValue);

                    if (_isAdd)
                    {
                        ParkingAreaBO.Instance.Insert(dModel);
                    }
                    else
                        ParkingAreaBO.Instance.Update(dModel);

                    loadData();
                    setInterface(false);
                    clearInterface();
                }
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

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
