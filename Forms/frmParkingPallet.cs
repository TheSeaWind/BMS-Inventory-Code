using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Business;
using BMS.Model;

namespace BMS
{
    public partial class frmParkingPallet : _Forms
    {
        private bool _isAdd;
        public frmParkingPallet()
        {
            InitializeComponent();
        }

        private void frmParkingPallet_Load(object sender, EventArgs e)
        {
            loadBlock();

        }

        #region Methods
        
        private void setInterface(bool isEdit)
        {
            txtCode.ReadOnly = !isEdit;

            grdPallet.Enabled = !isEdit;

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
                MessageBox.Show("Xin hãy điền mã của vị trí.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (!_isAdd)
                {
                    int strID = TextUtils.ToInt(grvPallet.GetFocusedRowCellValue("ID"));
                    dt = TextUtils.Select("select Code from ParkingPallet where Code = '" + txtCode.Text.Trim() + "' and ID <> " + strID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from ParkingPallet where Code = '" + txtCode.Text.Trim() + "'");
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
                MessageBox.Show("Xin hãy điền tên của vị trí.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (TextUtils.ToInt(TextUtils.ToInt(grvData.GetFocusedRowCellValue("ID"))) == 0)
            {
                MessageBox.Show("Xin hãy chọn block cho vị trí.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        private void loadData(int parkingBlockID)
        {
            try
            {
                DataTable tbl = TextUtils.Select("SELECT * FROM ParkingPallet where ParkingBlockID = " + parkingBlockID);
                grdPallet.DataSource = tbl;
            }
            catch (Exception)
            {
            }
        }

        private void loadBlock()
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
        #endregion

        #region Buttons Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            setInterface(true);
            _isAdd = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!grvPallet.IsDataRow(grvData.FocusedRowHandle))
                return;
            setInterface(true);
            _isAdd = false;
            txtName.Text = TextUtils.ToString(grvPallet.GetFocusedRowCellValue("Name"));
            txtCode.Text = TextUtils.ToString(grvPallet.GetFocusedRowCellValue("Code"));
            chkActive.Checked = TextUtils.ToBoolean(grvPallet.GetFocusedRowCellValue("Active"));            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvPallet.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvPallet.GetFocusedRowCellValue("ID"));

            string strName = TextUtils.ToString(grvPallet.GetFocusedRowCellValue("Name"));

            //if (ParkingAreaBO.Instance.CheckExist("ParkingLotID", strID))
            //{
            //    MessageBox.Show("Bãi này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa [{0}] không?", strName), TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ParkingLotBO.Instance.Delete(Convert.ToInt32(strID));
                    loadData(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
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
                    ParkingPalletModel dModel;
                    if (_isAdd)
                    {
                        dModel = new ParkingPalletModel();
                    }
                    else
                    {
                        int ID = Convert.ToInt32(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID"));
                        dModel = (ParkingPalletModel)ParkingPalletBO.Instance.FindByPK(ID);
                    }
                    dModel.Code = txtCode.Text.Trim();
                    dModel.Name = txtName.Text.Trim();
                    dModel.Active = chkActive.Checked;
                    dModel.ParkingBlockID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));

                    if (_isAdd)
                    {
                        dModel.Empty = true;
                        ParkingPalletBO.Instance.Insert(dModel);
                    }
                    else
                        ParkingPalletBO.Instance.Update(dModel);

                    loadData(dModel.ParkingBlockID);
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

        private void grdPallet_DoubleClick(object sender, EventArgs e)
        {
            if (grvPallet.RowCount > 0 && btnEdit.Enabled == true)
                btnEdit_Click(null, null);
        }

        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            loadData(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
        }
    }
}
