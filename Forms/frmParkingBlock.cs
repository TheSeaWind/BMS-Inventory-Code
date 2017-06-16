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
    public partial class frmParkingBlock : _Forms
    {
        private bool _isAdd;
        public frmParkingBlock()
        {
            InitializeComponent();
        }

        private void frmParkingBlock_Load(object sender, EventArgs e)
        {
            loadParkingLot();
            LoadData();
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
        }

        private bool checkValid()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền mã của block.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (!_isAdd)
                {
                    int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID"));
                    dt = TextUtils.Select("select Code from ParkingBlock where Code = '" + txtCode.Text.Trim() + "' and ID <> " + strID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from ParkingBlock where Code = '" + txtCode.Text.Trim() + "'");
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
                MessageBox.Show("Xin hãy điền tên của block.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        private void LoadData()
        {
            try
            {
                DataTable tbl = TextUtils.Select("SELECT * FROM vParkingBlock");
                grdData.DataSource = tbl;
            }
            catch
            {
            }
        }

        void loadParkingLot()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select * from ParkingLot with(nolock)");
                cboParkingLot.Properties.DataSource = tbl;
                cboParkingLot.Properties.DisplayMember = "Name";
                cboParkingLot.Properties.ValueMember = "ID";
            }
            catch
            {
            }  
        }

        void loadParkingArea(int parkingLotID)
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select * from ParkingArea with(nolock) where ParkingLotID = " + parkingLotID);
                cboArea.Properties.DataSource = tbl;
                cboArea.Properties.DisplayMember = "Name";
                cboArea.Properties.ValueMember = "ID";
            }
            catch
            {
            }  
        }


        #endregion

        #region Events
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
            txtName.Text = TextUtils.ToString(grvData.GetRowCellValue(grvData.FocusedRowHandle, "Name"));
            txtCode.Text = TextUtils.ToString(grvData.GetRowCellValue(grvData.FocusedRowHandle, "Code"));
            chkActive.Checked = TextUtils.ToBoolean(grvData.GetRowCellValue(grvData.FocusedRowHandle, "Active"));
            cboArea.EditValue = TextUtils.ToString(grvData.GetFocusedRowCellValue(colAreaID));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvData.GetFocusedRowCellValue("ID"));

            string strName = TextUtils.ToString(grvData.GetFocusedRowCellValue("Name"));

            if (ParkingPalletBO.Instance.CheckExist("ParkingBlockID", strID))
            {
                MessageBox.Show("Khu vực này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                    ParkingBlockModel dModel;
                    if (_isAdd)
                    {
                        dModel = new ParkingBlockModel();
                    }
                    else
                    {
                        int ID = Convert.ToInt32(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString());
                        dModel = (ParkingBlockModel)ParkingBlockBO.Instance.FindByPK(ID);
                    }

                    dModel.Code = txtCode.Text.Trim();
                    dModel.Name = txtName.Text.Trim();
                    dModel.Active = chkActive.Checked;
                    dModel.ParkingAreaID = TextUtils.ToInt(cboArea.EditValue);                    

                    if (_isAdd)
                    {
                        ParkingBlockBO.Instance.Insert(dModel);
                    }
                    else
                        ParkingBlockBO.Instance.Update(dModel);

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

        private void grdData_DoubleClick(object sender, EventArgs e)
        {
            if (grvData.RowCount > 0 && btnEdit.Enabled == true)
                btnEdit_Click(null, null);
        }
        #endregion

        private void cboParkingLot_EditValueChanged(object sender, EventArgs e)
        {
            loadParkingArea(TextUtils.ToInt(cboParkingLot.EditValue));
        }
    }
}
