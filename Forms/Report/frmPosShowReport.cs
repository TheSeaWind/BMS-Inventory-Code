 using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using BMS.Utils;
using BMS.BO;
using BMS.Model;
using BMS.Facade;
using BMS.Exceptions;
using BMS.Business;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace BMS
{
    public partial class frmPosShowReport : Form
    {
        #region Khai bao bien dung chung

        public bool PrintA4 = false;
        public bool EnablePrint = true;

        public DataTable Source = null;
        public string SubReportName = "";
        public DataTable SubReportSource = null;
        public string ReportName = "";
        public string[] FormulaFields;
        public string[] FormulaFieldsValue;
        public string[] FormulaFieldsTip;
        public string[] FormulaFieldsValueTip;
        ReportDocument rpt = null;

        ToolStripButton PrintReportToolStripButton = new ToolStripButton();

        #endregion

        #region Load Form

        public frmPosShowReport()
        {
            InitializeComponent();
            // Count Report
            //Global.garbage.AddCount();
        }

        private void frmPosShowReport_Load(object sender, System.EventArgs e)
        {
            this.PrintReportToolStripButton.Click += new System.EventHandler(this.PrintReportToolStripButton_Click);
            ToolStrip ts = null;
            foreach(Control ctrl in crystalReportViewer1.Controls)
            {
                if (ctrl is ToolStrip)
                {
                    ts=(ToolStrip)ctrl;
                    break;
                }
            }
            PrintReportToolStripButton.ToolTipText = "Print Report";
            PrintReportToolStripButton.AutoSize = ((ToolStripButton)ts.Items[0]).AutoSize;
            PrintReportToolStripButton.ImageAlign = ((ToolStripButton)ts.Items[0]).ImageAlign;
            PrintReportToolStripButton.ImageScaling = ((ToolStripButton)ts.Items[0]).ImageScaling;
            ts.Items.RemoveAt(1);
            ts.Items.Insert(1, PrintReportToolStripButton);

            ((ToolStripButton)ts.Items[0]).Enabled = EnablePrint;
            ((ToolStripButton)ts.Items[1]).Enabled = EnablePrint;

            ((ToolStripButton)ts.Items[0]).Image = (Image)Forms.Properties.Resources.fileexport_32;
            ((ToolStripButton)ts.Items[1]).Image = (Image)Forms.Properties.Resources.Printer_32__1_;
            ((ToolStripButton)ts.Items[2]).Image = (Image)Forms.Properties.Resources.Gnome_View_Refresh_32;
            ((ToolStripButton)ts.Items[3]).Image = (Image)Forms.Properties.Resources.Content_Tree_32;
            ((ToolStripButton)ts.Items[4]).Image = (Image)Forms.Properties.Resources.Gnome_Go_First_32;
            ((ToolStripButton)ts.Items[5]).Image = (Image)Forms.Properties.Resources.Gnome_Go_Previous_32;
            ((ToolStripButton)ts.Items[6]).Image = (Image)Forms.Properties.Resources.Gnome_Go_Next_32;
            ((ToolStripButton)ts.Items[7]).Image = (Image)Forms.Properties.Resources.Gnome_Go_Last_32;


            ((ToolStripButton)ts.Items[8]).Image = (Image)Forms.Properties.Resources.Links_32;
            ((ToolStripButton)ts.Items[9]).Image = (Image)Forms.Properties.Resources.fileclose_32;
            ((ToolStripButton)ts.Items[10]).Image = (Image)Forms.Properties.Resources.Find_32;
            ((ToolStripDropDownButton)ts.Items[11]).Image = (Image)Forms.Properties.Resources.Gnome_Zoom_Fit_Best_32;
        }

        private void PrintReportToolStripButton_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ShowLastPage();
            int PageCount=crystalReportViewer1.GetCurrentPageNumber();
            rpt.PrintOptions.PrinterName = GetDefaultPrinter();
            rpt.PrintToPrinter(1, true, 1, PageCount);
        }

        #endregion

        #region Cac ham viet them

        public void BindData()
        {
            try
            {
                // Khai báo document
                rpt = new ReportDocument();
                rpt.Load(Application.StartupPath + "\\Reports\\" + ReportName);

                if(this.Source!=null)
                    rpt.SetDataSource(this.Source);
                if (this.SubReportSource != null)
                    rpt.Subreports[SubReportName].SetDataSource(SubReportSource);

                if (FormulaFieldsValue != null)
                {
                    for (int i = 0; i < FormulaFields.Length; i++)
                    {
                        rpt.DataDefinition.FormulaFields[FormulaFields[i]].Text = "\"" + FormulaFieldsValue[i] + "\"";
                    }
                }
                // Bind data source
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                frmGenMessageBox frm = new frmGenMessageBox("KienNT", this.Name, "ReportName", TextUtils.Caption,
                                                             "", ex.Message, MessageBoxIcon.Error);
                frm.ShowDialog();
                return;
            }
        }
        public void PrintTipReceive()
        {
            try
            {
                if (FormulaFieldsValueTip != null)
                {
                    ReportDocument rpt = new ReportDocument();
                    rpt.Load(Application.StartupPath + "\\Reports\\" + "PrintTip.rpt");
                    for (int i = 0; i < FormulaFieldsTip.Length; i++)
                    {
                        rpt.DataDefinition.FormulaFields[FormulaFieldsTip[i]].Text = "\"" + FormulaFieldsValueTip[i] + "\"";
                    }
                    rpt.PrintOptions.PrinterName = GetDefaultPrinter();
                    rpt.PrintToPrinter(1, true, 1, 1);
                }
            }
            catch (Exception ex)
            {
                frmGenMessageBox frm = new frmGenMessageBox("KienNT", this.Name, "ReportName", TextUtils.Caption,
                                                             "", ex.Message, MessageBoxIcon.Error);
                frm.ShowDialog();
                return;
            }
        }
        public void PrintReport()
        {
            if (PrintA4 == false)
            {
                // In hóa đơn.
                rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                // margins for the report.
                CrystalDecisions.Shared.PageMargins margins = rpt.PrintOptions.PageMargins;
                //margins.bottomMargin = 150;
                margins.leftMargin = 350;
                margins.rightMargin = 150;
                //margins.topMargin = 150;
                // Apply the page margins.
                rpt.PrintOptions.ApplyPageMargins(margins);
                rpt.PrintOptions.PrinterName = GetDefaultPrinter();
                crystalReportViewer1.ShowLastPage();
                rpt.PrintToPrinter(1, true, 1, crystalReportViewer1.GetCurrentPageNumber());
            }
            else
            {
                PrintDialog PrintDialog1 = new PrintDialog();
                DialogResult result = PrintDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                    rpt.PrintOptions.PrinterName = PrintDialog1.PrinterSettings.PrinterName;
                    crystalReportViewer1.ShowLastPage();
                    rpt.PrintToPrinter(1, true, 1, crystalReportViewer1.GetCurrentPageNumber()); 
                }
            }
        }

        public CrystalDecisions.Windows.Forms.CrystalReportViewer GetViewer()
        {
            try
            {
                return crystalReportViewer1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string GetDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                    return printer;
            }
            return string.Empty;
        }
        
        private void  PrintTextMode()
        {
            //StringBuilder sbContent = new StringBuilder();
            //sbContent.Append("\n\n");
            //sbContent.Append("\t\t Vinpearl Luxury \n");
            //sbContent.Append("\t\t     Nha Trang \n\n\n\n");
            //sbContent.Append("\t\t " + Global.RestaurantName + "\n");
            //sbContent.Append("\t\t Table"+FormulaFieldsValue[2]+"\n\n");//Table
            //sbContent.Append("Trans$:" + FormulaFieldsValue[4]+"\n");
            //sbContent.Append("Time:" + FormulaFieldsValue[6] + "\n");
            //sbContent.Append("Serv:" + FormulaFieldsValue[3]+ "\t"+FormulaFieldsValue[5]+"\n");
            //sbContent.Append("======================================\n\n");
            //sbContent.Append("Qty  Description                Amount\n");
            //sbContent.Append("======================================\n");
            //for (int i = 0; i < Source.Rows.Count;i++ )
            //{
            //    DataRow row = Source.Rows[i];
            //    string qty = row["Quantity"].ToString();
            //    string desc = row["Description"].ToString();
            //    string amount = row["Amount"].ToString();
            //    sbContent.Append(qty + "    " + desc.Trim() + "                " + amount + "\n");
            //}
            //sbContent.Append("======================================\n");
            //string[] title = FormulaFieldsValue[8].Split('&');
            //string[] value = FormulaFieldsValue[9].Split('&');
            //for (int i = 0; i < title.Length; i++) 
            //{
            //    sbContent.Append(title[i]+"    "+value[i]+"\n\n\n");
            //}
            //sbContent.Append("\t\t ====================\n");
            //Console.WriteLine(sbContent);
        }

        #endregion
    }
}