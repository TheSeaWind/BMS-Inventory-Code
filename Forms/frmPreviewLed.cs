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
    public partial class frmPreviewLed : _Forms
    {
        private bool _isAdd;
        private bool _isParkingIn;
        private int _Selected;
        private int _selectedId;

        public frmPreviewLed()
        {
            InitializeComponent();


            timer1.Interval = 500;
            timer1.Enabled = true;
            timer1.Start();

            //DataTable data = TextUtils.Select("select ID, Code from ParkingBlock");
            //foreach(DataRow row in data.Rows)
            //{
            //    for (int i = 1; i < 18; i++)
            //    {
            //        ParkingPalletModel pallet = new ParkingPalletModel();
            //        pallet.Active = true;
            //        pallet.Name = pallet.Code = "1-" + row["Code"].ToString() + "-" + i;
            //        pallet.Empty = true;
            //        pallet.ParkingBlockID = TextUtils.ToInt(row["ID"]);
            //        pallet.VehicleTypeID = 1;
            //        ParkingPalletBO.Instance.Insert(pallet);
            //    }
            //}

            _isParkingIn = false;
        }

        private void frmParkingArea_Load(object sender, EventArgs e)
        {
            try
            {
                //loadParkingLot();
                //loadData();
                updateParkingList();
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
            //txtcameraCode.ReadOnly = !isEdit;

            //grdData.Enabled = !isEdit;

            //btnSave.Visible = isEdit;
            //btnCancel.Visible = isEdit;

            //btnNew.Visible = !isEdit;
            //btnEdit.Visible = !isEdit;
            //btnDelete.Visible = !isEdit;
        }

        private void clearInterface()
        {
            //txtCameraName.Text = "";
            //txtcameraCode.Text = "";
            //txtUrl.Text = "";
            //cboParkingLot.EditValue = null;
        }

        private bool checkValid()
        {
            //if (txtcameraCode.Text.Trim() == "")
            //{
            //    MessageBox.Show("Xin hãy điền mã của camera.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}
            //else
            //{
            //    DataTable dt;
            //    if (!_isAdd)
            //    {
            //        int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID"));
            //        dt = TextUtils.Select("select CameraCode from Camera where CameraCode = '" + txtcameraCode.Text.Trim() + "' and ID <> " + strID);                    
            //    }
            //    else
            //    {
            //        dt = TextUtils.Select("select CameraCode from Camera where CameraCode = '" + txtcameraCode.Text.Trim() + "'");                    
            //    }
            //    if (dt != null)
            //    {
            //        if (dt.Rows.Count > 0)
            //        {
            //            MessageBox.Show("Mã này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //            return false;
            //        }
            //    }
            //}
            //if (txtCameraName.Text.Trim() == "")
            //{
            //    MessageBox.Show("Xin hãy điền tên của camera.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            //if (txtUrl.Text.Trim() == "")
            //{
            //    MessageBox.Show("Xin hãy điền url của camera.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            //if (cboParkingLot.EditValue == null)
            //{
            //     MessageBox.Show("Xin hãy chọn một bãi xe.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}
            return true;
        }

        void loadParkingLot()
        {
            //try
            //{
            //    DataTable tblPL = TextUtils.Select("Select ID, Code, Name from ParkingLot with(nolock)");
            //    cboParkingLot.Properties.DataSource = tblPL;
            //    cboParkingLot.Properties.DisplayMember = "Name";
            //    cboParkingLot.Properties.ValueMember = "ID";
            //}
            //catch 
            //{
            //}           
        }
        private void loadData()
        {
            //try
            //{
            //    DataTable tbl = TextUtils.Select("SELECT * FROM vCamera");
            //    grdData.DataSource = tbl;
            //}
            //catch (Exception)
            //{
            //}
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
            //if (!grvData.IsDataRow(grvData.FocusedRowHandle))
            //    return;
            //setInterface(true);
            //_isAdd = false;
            //txtCameraName.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "CameraName").ToString();
            //txtcameraCode.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "CameraCode").ToString();
            //txtUrl.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "CameraUrl").ToString();
            //chkActive.Checked = TextUtils.ToBoolean(grvData.GetRowCellValue(grvData.FocusedRowHandle, "Active"));
            //chkIsLPR.Checked = TextUtils.ToBoolean(grvData.GetRowCellValue(grvData.FocusedRowHandle, "IsLPR"));
            //cboParkingLot.EditValue = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colParkingLotID));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (!grvData.IsDataRow(grvData.FocusedRowHandle))
            //    return;

            //int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID"));

            //string strName = TextUtils.ToString(grvData.GetRowCellValue(grvData.FocusedRowHandle, "CameraName"));

            ////if (CameraBO.Instance.CheckExist("CameraID", strID))
            ////{
            ////    MessageBox.Show("Khu vực này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            ////    return;
            ////}

            //if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa [{0}] không?", strName), TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    try
            //    {
            //        CameraBO.Instance.Delete(Convert.ToInt32(strID));
            //        loadData();
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
            //    }
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (checkValid())
            //    {
            //        CameraModel dModel;
            //        if (_isAdd)
            //        {
            //            dModel = new CameraModel();                       
            //        }
            //        else
            //        {
            //            int ID = Convert.ToInt32(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString());
            //            dModel = (CameraModel)CameraBO.Instance.FindByPK(ID);
            //        }
            //        dModel.CameraCode = txtcameraCode.Text.Trim();
            //        dModel.CameraName = txtCameraName.Text.Trim();
            //        dModel.CameraUrl = txtUrl.Text.Trim();
            //        dModel.Active = chkActive.Checked;
            //        dModel.IsLPR = chkIsLPR.Checked;
            //        dModel.ParkingLotID = TextUtils.ToInt(cboParkingLot.EditValue);

            //        if (_isAdd)
            //        {
            //            CameraBO.Instance.Insert(dModel);
            //        }
            //        else
            //            CameraBO.Instance.Update(dModel);

            //        loadData();
            //        setInterface(false);
            //        clearInterface();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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
            //if (grvData.RowCount > 0 && btnEdit.Enabled == true)
            //    btnEdit_Click(null, null);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void grdData_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateEmptyPallet();
            updateParkingList();
        }

        private void updateEmptyPallet()
        {
            int suvId = 0, sedanId = 1;

            int Block1ID = 1, Block2ID = 2, Block3ID = 3, Block4ID = 4, Block5ID = 5, Block6ID = 6;
            for (int i = 1; i < 7; i++)
            {
                DataTable data = TextUtils.Select("select top 1 ID, Code from ParkingBlock where Code = " + i);
                try
                {
                    switch (i)
                    {
                        case 1:
                            Block1ID = TextUtils.ToInt(data.Rows[0]["ID"]);
                            break;
                        case 2:
                            Block2ID = TextUtils.ToInt(data.Rows[0]["ID"]);
                            break;
                        case 3:
                            Block3ID = TextUtils.ToInt(data.Rows[0]["ID"]);
                            break;
                        case 4:
                            Block4ID = TextUtils.ToInt(data.Rows[0]["ID"]);
                            break;
                        case 5:
                            Block5ID = TextUtils.ToInt(data.Rows[0]["ID"]);
                            break;
                        case 6:
                            Block6ID = TextUtils.ToInt(data.Rows[0]["ID"]);
                            break;
                    }
                }
                catch { }
            }

            int m1_Suv = 0, m1_Sedan = 0, m2_Suv = 0, m2_Sedan = 0, m3_Suv = 0, m3_Sedan = 0, m4_Suv = 0, m4_Sedan = 0, m5_Suv = 0, m5_Sedan = 0, m6_Suv = 0, m6_Sedan = 0;
            DataTable tbl = TextUtils.Select("Select * from ParkingPallet where Active = 1 and Empty = 1");
            try
            {
                m1_Suv = tbl.Select("ParkingBlockID = " + Block1ID + " and VehicleTypeID = " + suvId).Length;
                m1_Sedan = tbl.Select("ParkingBlockID = " + Block1ID + " and VehicleTypeID = " + sedanId).Length;

                m2_Suv = tbl.Select("ParkingBlockID = " + Block2ID + " and VehicleTypeID = " + suvId).Length;
                m2_Sedan = tbl.Select("ParkingBlockID = " + Block2ID + " and VehicleTypeID = " + sedanId).Length;

                m3_Suv = tbl.Select("ParkingBlockID = " + Block3ID + " and VehicleTypeID = " + suvId).Length;
                m3_Sedan = tbl.Select("ParkingBlockID = " + Block3ID + " and VehicleTypeID = " + sedanId).Length;

                m4_Suv = tbl.Select("ParkingBlockID = " + Block4ID + " and VehicleTypeID = " + suvId).Length;
                m4_Sedan = tbl.Select("ParkingBlockID = " + Block4ID + " and VehicleTypeID = " + sedanId).Length;

                m5_Suv = tbl.Select("ParkingBlockID = " + Block5ID + " and VehicleTypeID = " + suvId).Length;
                m5_Sedan = tbl.Select("ParkingBlockID = " + Block5ID + " and VehicleTypeID = " + sedanId).Length;

                m6_Suv = tbl.Select("ParkingBlockID = " + Block6ID + " and VehicleTypeID = " + suvId).Length;
                m6_Sedan = tbl.Select("ParkingBlockID = " + Block6ID + " and VehicleTypeID = " + sedanId).Length;
            }
            catch { }

            labelM1Suv.Text = "" + m1_Suv;
            labelM1Sedan.Text = "" + m1_Sedan;

            labelM2Suv.Text = "" + m2_Suv;
            labelM2Sedan.Text = "" + m2_Sedan;

            labelM3Suv.Text = "" + m3_Suv;
            labelM3Sedan.Text = "" + m3_Sedan;

            labelM4Suv.Text = "" + m4_Suv;
            labelM4Sedan.Text = "" + m4_Sedan;

            labelM5Suv.Text = "" + m5_Suv;
            labelM5Sedan.Text = "" + m5_Sedan;

            labelM6Suv.Text = "" + m6_Suv;
            labelM6Sedan.Text = "" + m6_Sedan;
        }

        private void updateParkingList()
        {
            if (_isParkingIn) return;

            int parkingAreaCode = 1;

            DataTable data = TextUtils.Select("select top 5 InLicensePlate, ReadLicensePlateOk, ID, PalletCode from vParking where ParkingCardID < 1 and AreaCode like '" + parkingAreaCode +"' order by ID asc");
            for (int i = 0; i < 5; i++)
            {
                TextBox tbx = (TextBox)this.Controls.Find("textBoxParking" + (i + 1), true).FirstOrDefault();
                TextBox pix = (TextBox)this.Controls.Find("textBoxAlamp" + (i + 1), true).FirstOrDefault();
                if (i < data.Rows.Count)
                {
                    DataRow row = data.Rows[i];
                    tbx.Tag = TextUtils.ToString(row["ID"]);
                    try
                    {
                        tbx.Text = TextUtils.ToString(row["InLicensePlate"]);
                        pix.BackColor = TextUtils.ToBoolean(row["ReadLicensePlateOk"]) ? Color.Blue : Color.Red;
                        pix.Text = TextUtils.ToString(row["PalletCode"]);
                    }
                    catch { }
                }
                else
                {
                    tbx.Text = "";
                    tbx.Tag = "";
                    pix.BackColor = Color.White;
                    pix.Text = "";
                }

                Label lb = (Label)this.Controls.Find("labelSelect" + (i+1), true).FirstOrDefault();
                lb.BackColor = Color.White;
            }
        }

        private void buttonSelectPallet1_Click(object sender, EventArgs e)
        {
            if (_isParkingIn) return;
            _Selected = TextUtils.ToInt(((Control)sender).Text);
            TextBox tbx = (TextBox)this.Controls.Find("textBoxParking" + _Selected, true).FirstOrDefault();
            if (TextUtils.ToString(tbx.Tag) == "") return;
            Label lb = (Label)this.Controls.Find("labelSelect" + _Selected, true).FirstOrDefault();
            _isParkingIn = true;
            lb.BackColor = Color.Blue;
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
                DataTable card = TextUtils.Select("select * from ParkingCard where ParkingCardCode like '" + _CardNumber + "'");
                if (card.Rows.Count < 1)
                {
                    MessageBox.Show("Thẻ không thuộc hệ thống");
                }
                else if (!TextUtils.ToBoolean(card.Rows[0]["Active"]))
                {
                    MessageBox.Show("Thẻ chưa kích hoạt");
                }
                else
                {
                    int cardId = TextUtils.ToInt(card.Rows[0]["ID"]);
                    if (_isParkingIn)
                    {
                        TextBox tbx = (TextBox)this.Controls.Find("textBoxParking" + _Selected, true).FirstOrDefault();
                        int parkingId = TextUtils.ToInt(TextUtils.ToString(tbx.Tag));

                        DataTable parking = TextUtils.Select("select ID from Parking where OutTime IS NULL and ParkingCardID = " + cardId);
                        if (parking.Rows.Count > 0)
                        {
                            MessageBox.Show("Vé đã sử dụng");
                        }
                        else
                        {
                            TextUtils.UpdateByCommand("update Parking set ParkingCardID = " + cardId + " where ID = " + parkingId + "");
                        }

                        _Selected = 0;
                        _isParkingIn = false;
                    }
                    else
                    {
                        DataTable dtparking = TextUtils.Select("select ID, ParkingCardName from vParking where OutTime IS NULL and ParkingCardID = " + cardId);
                        if (dtparking.Rows.Count <= 0) return;
                        int id = TextUtils.ToInt(dtparking.Rows[0]["ID"]);
                        ParkingModel m = (ParkingModel)ParkingBO.Instance.FindByPK(id);
                        m.OutTime = DateTime.Now;
                        m.TotalTime = (int)((DateTime)m.OutTime - (DateTime)m.InTime).TotalHours;
                        m.TotalPrice = m.TotalTime * 20;
                        ParkingBO.Instance.Update(m);

                        TextUtils.UpdateByCommand("update ParkingPallet set Empty = 1 where ID = " + m.ParkingPalletID);

                        labelNumberPlate.Text = m.InLicensePlate;
                        labelCard.Text = TextUtils.ToString(dtparking.Rows[0]["ParkingCardName"]);
                        labelInTime.Text = m.InTime.Value.ToString("dd/MM/yyyy HH:ss");
                        labelOutTime.Text = m.OutTime.Value.ToString("dd/MM/yyyy HH:ss");
                        labelTimeToTal.Text = m.TotalTime + " giờ";
                        labelFee.Text = string.Format("{0:n0}", m.TotalPrice) + ",000đ";
                        //ParkingModel m1 = (ParkingModel)ParkingBO.Instance.FindByExpression(new Expression("ParkingCardID", cardId).And(new Expression("OutTime", "NULL", "IS")))[0];
                    }
                }
                if (_isParkingIn)
                {
                    
                }
                else
                {
                    
                }
            }
        }
        private void loadReader()
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

        private void frmPreviewLed_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            reader.Close();
        }
    }
}
