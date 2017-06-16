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
    public partial class frmParkingCard : _Forms
    {
        private bool _isAdd;

        public frmParkingCard()
        {
            InitializeComponent();
        }

        private void frmParkingArea_Load(object sender, EventArgs e)
        {
            try
            {
                loadParkingLot();
                loadData();
                loadReader();
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        }

        #region Methods
        private void setInterface(bool isEdit)
        {
            grdData.Enabled = !isEdit;

            btnSave.Visible = isEdit;
            btnCancel.Visible = isEdit;

            btnNew.Visible = !isEdit;
            btnEdit.Visible = !isEdit;
            btnDelete.Visible = !isEdit;
        }

        private void clearInterface()
        {
            txtParkingCardName.Text = "";
            txtParkingCardCode.Text = "";
            cboParkingLot.EditValue = null;
        }

        private bool checkValid()
        {
            if (txtParkingCardCode.Text.Trim() == "")
            {
                MessageBox.Show("Chưa quẹt thẻ", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (!_isAdd)
                {
                    int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID"));
                    dt = TextUtils.Select("select ParkingCardCode from ParkingCard where ParkingCardCode = '" + txtParkingCardCode.Text.Trim() + "' and ID <> " + strID);                    
                }
                else
                {
                    dt = TextUtils.Select("select ParkingCardCode from ParkingCard where ParkingCardCode = '" + txtParkingCardCode.Text.Trim() + "'");                    
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
            if (txtParkingCardName.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền tên của thẻ.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        void loadReader()
        {
            try
            {
                DataTable tblRr = TextUtils.Select("Select ID, ReaderCode, ReaderName, COMPort, PortMode from Reader with(nolock)");
                cboReader.Properties.DataSource = tblRr;
                cboReader.Properties.DisplayMember = "ReaderName";
                cboReader.Properties.ValueMember = "ID";
            }
            catch
            {
            }
        }

        private void loadData()
        {
            try
            {
                DataTable tbl = TextUtils.Select("SELECT * FROM vParkingCard");
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
            txtParkingCardName.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "ParkingCardName").ToString();
            txtParkingCardCode.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "ParkingCardCode").ToString();
            chkActive.Checked = TextUtils.ToBoolean(grvData.GetRowCellValue(grvData.FocusedRowHandle, "Active"));
            cboParkingLot.EditValue = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colParkingLotID));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID"));

            string strName = TextUtils.ToString(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ParkingCardName"));

            //if (CameraBO.Instance.CheckExist("CameraID", strID))
            //{
            //    MessageBox.Show("Khu vực này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa [{0}] không?", strName), TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ParkingCardBO.Instance.Delete(Convert.ToInt32(strID));
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
                    ParkingCardModel dModel;
                    if (_isAdd)
                    {
                        dModel = new ParkingCardModel();                       
                    }
                    else
                    {
                        int ID = Convert.ToInt32(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString());
                        dModel = (ParkingCardModel)ParkingCardBO.Instance.FindByPK(ID);
                    }
                    dModel.ParkingCardCode = txtParkingCardCode.Text.Trim();
                    dModel.ParkingCardName = txtParkingCardName.Text.Trim();
                    dModel.Active = chkActive.Checked;
                    dModel.ParkingLotID = TextUtils.ToInt(cboParkingLot.EditValue);

                    if (_isAdd)
                    {
                        CameraBO.Instance.Insert(dModel);
                    }
                    else
                        CameraBO.Instance.Update(dModel);

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

        private void grdData_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        RfidReader reader = new RfidReader("", "");
        private void cboReader_EditValueChanged(object sender, EventArgs e)
        {
            reader.Close();
            if (cboReader.EditValue == null) return;
            string comport = TextUtils.ToString(grvCboReader.GetFocusedRowCellValue("COMPort"));
            string portmode = TextUtils.ToString(grvCboReader.GetFocusedRowCellValue("PortMode"));
            reader = new RfidReader("COM" + comport, portmode);
            reader.OnGetValue += reader_OnGetValue;
            if (reader.Start())
            {
                reader.timer.Start();
            }
            else
            {
                MessageBox.Show("Không khởi tạo được đầu đọc thẻ");
            }
        }
        private void reader_OnGetValue(string _ReaderName, string _ParkingLineLocation, string _CardNumber)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate () { reader_OnGetValue(_ReaderName, _ParkingLineLocation, _CardNumber); }));
            }
            else
            {
                txtParkingCardCode.Text = _CardNumber;
            }
        }

        private void frmParkingCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            reader.Close();
        }
    }
}
