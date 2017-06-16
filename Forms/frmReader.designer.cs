namespace BMS
{
    partial class frmReader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReader));
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReaderCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReaderName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numCOMPort = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cboParkingLot = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvCboParkingLot = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCboID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCboParkingLotCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCboParkingLotName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtPortMode = new System.Windows.Forms.TextBox();
            this.txtReaderCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReaderName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colParkingLotID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPakingLotName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colCOMPort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPortMode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.mnuMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCOMPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboParkingLot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboParkingLot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnEdit,
            this.btnDelete,
            this.btnSave,
            this.btnCancel});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(738, 42);
            this.mnuMenu.TabIndex = 17;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnNew
            // 
            this.btnNew.AutoSize = false;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(55, 40);
            this.btnNew.Tag = "";
            this.btnNew.Text = "&Thêm";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = false;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(55, 40);
            this.btnEdit.Tag = "";
            this.btnEdit.Text = "Sửa";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 40);
            this.btnDelete.Tag = "";
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 40);
            this.btnSave.Text = "Ghi";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCancel.AutoSize = false;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 40);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatus.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStatus.AppearanceHeader.Options.UseFont = true;
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.Caption = "Hoạt động";
            this.colStatus.FieldName = "Active";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;
            this.colStatus.Width = 83;
            // 
            // colReaderCode
            // 
            this.colReaderCode.AppearanceCell.Options.UseTextOptions = true;
            this.colReaderCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colReaderCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colReaderCode.AppearanceHeader.Options.UseFont = true;
            this.colReaderCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colReaderCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReaderCode.Caption = "Mã";
            this.colReaderCode.FieldName = "ReaderCode";
            this.colReaderCode.Name = "colReaderCode";
            this.colReaderCode.Visible = true;
            this.colReaderCode.VisibleIndex = 0;
            this.colReaderCode.Width = 65;
            // 
            // colReaderName
            // 
            this.colReaderName.AppearanceCell.Options.UseTextOptions = true;
            this.colReaderName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colReaderName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colReaderName.AppearanceHeader.Options.UseFont = true;
            this.colReaderName.AppearanceHeader.Options.UseTextOptions = true;
            this.colReaderName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReaderName.Caption = "Tên";
            this.colReaderName.FieldName = "ReaderName";
            this.colReaderName.Name = "colReaderName";
            this.colReaderName.Visible = true;
            this.colReaderName.VisibleIndex = 1;
            this.colReaderName.Width = 173;
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colID.AppearanceHeader.Options.UseFont = true;
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.groupBox1.Controls.Add(this.numCOMPort);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboParkingLot);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chkActive);
            this.groupBox1.Controls.Add(this.txtPortMode);
            this.groupBox1.Controls.Add(this.txtReaderCode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtReaderName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 90);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // numCOMPort
            // 
            this.numCOMPort.Location = new System.Drawing.Point(343, 12);
            this.numCOMPort.Name = "numCOMPort";
            this.numCOMPort.Size = new System.Drawing.Size(208, 20);
            this.numCOMPort.TabIndex = 239;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 238;
            this.label3.Text = "COMPort";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cboParkingLot
            // 
            this.cboParkingLot.Location = new System.Drawing.Point(343, 38);
            this.cboParkingLot.Name = "cboParkingLot";
            this.cboParkingLot.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboParkingLot.Properties.NullText = "";
            this.cboParkingLot.Properties.View = this.grvCboParkingLot;
            this.cboParkingLot.Size = new System.Drawing.Size(208, 20);
            this.cboParkingLot.TabIndex = 237;
            // 
            // grvCboParkingLot
            // 
            this.grvCboParkingLot.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCboID,
            this.colCboParkingLotCode,
            this.colCboParkingLotName});
            this.grvCboParkingLot.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboParkingLot.Name = "grvCboParkingLot";
            this.grvCboParkingLot.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboParkingLot.OptionsView.ShowGroupedColumns = true;
            this.grvCboParkingLot.OptionsView.ShowGroupPanel = false;
            // 
            // colCboID
            // 
            this.colCboID.Caption = "ID";
            this.colCboID.FieldName = "ID";
            this.colCboID.Name = "colCboID";
            // 
            // colCboParkingLotCode
            // 
            this.colCboParkingLotCode.Caption = "Mã";
            this.colCboParkingLotCode.FieldName = "Code";
            this.colCboParkingLotCode.Name = "colCboParkingLotCode";
            this.colCboParkingLotCode.Visible = true;
            this.colCboParkingLotCode.VisibleIndex = 0;
            this.colCboParkingLotCode.Width = 192;
            // 
            // colCboParkingLotName
            // 
            this.colCboParkingLotName.Caption = "Tên";
            this.colCboParkingLotName.FieldName = "Name";
            this.colCboParkingLotName.Name = "colCboParkingLotName";
            this.colCboParkingLotName.Visible = true;
            this.colCboParkingLotName.VisibleIndex = 1;
            this.colCboParkingLotName.Width = 150;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 238;
            this.label4.Text = "Bãi xe";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(343, 66);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(77, 17);
            this.chkActive.TabIndex = 2;
            this.chkActive.Text = "Hoạt động";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtPortMode
            // 
            this.txtPortMode.Location = new System.Drawing.Point(56, 64);
            this.txtPortMode.Name = "txtPortMode";
            this.txtPortMode.Size = new System.Drawing.Size(208, 20);
            this.txtPortMode.TabIndex = 0;
            // 
            // txtReaderCode
            // 
            this.txtReaderCode.Location = new System.Drawing.Point(56, 11);
            this.txtReaderCode.Name = "txtReaderCode";
            this.txtReaderCode.Size = new System.Drawing.Size(208, 20);
            this.txtReaderCode.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "PortMode";
            // 
            // txtReaderName
            // 
            this.txtReaderName.Location = new System.Drawing.Point(56, 38);
            this.txtReaderName.Name = "txtReaderName";
            this.txtReaderName.Size = new System.Drawing.Size(208, 20);
            this.txtReaderName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã";
            // 
            // grvData
            // 
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colReaderName,
            this.colReaderCode,
            this.colStatus,
            this.colParkingLotID,
            this.colPakingLotName,
            this.colCOMPort,
            this.colPortMode});
            this.grvData.GridControl = this.grdData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvData.OptionsBehavior.Editable = false;
            this.grvData.OptionsView.ColumnAutoWidth = false;
            this.grvData.OptionsView.ShowGroupPanel = false;
            // 
            // colParkingLotID
            // 
            this.colParkingLotID.AppearanceCell.Options.UseTextOptions = true;
            this.colParkingLotID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colParkingLotID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colParkingLotID.AppearanceHeader.Options.UseFont = true;
            this.colParkingLotID.AppearanceHeader.Options.UseTextOptions = true;
            this.colParkingLotID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colParkingLotID.Caption = "ParkingLotID";
            this.colParkingLotID.FieldName = "ParkingLotID";
            this.colParkingLotID.Name = "colParkingLotID";
            // 
            // colPakingLotName
            // 
            this.colPakingLotName.AppearanceCell.Options.UseTextOptions = true;
            this.colPakingLotName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPakingLotName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPakingLotName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPakingLotName.AppearanceHeader.Options.UseFont = true;
            this.colPakingLotName.AppearanceHeader.Options.UseTextOptions = true;
            this.colPakingLotName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPakingLotName.Caption = "Bãi xe";
            this.colPakingLotName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colPakingLotName.FieldName = "Name";
            this.colPakingLotName.Name = "colPakingLotName";
            this.colPakingLotName.Visible = true;
            this.colPakingLotName.VisibleIndex = 4;
            this.colPakingLotName.Width = 202;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colCOMPort
            // 
            this.colCOMPort.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCOMPort.AppearanceHeader.Options.UseFont = true;
            this.colCOMPort.Caption = "COM Port";
            this.colCOMPort.FieldName = "COMPort";
            this.colCOMPort.Name = "colCOMPort";
            this.colCOMPort.Visible = true;
            this.colCOMPort.VisibleIndex = 2;
            this.colCOMPort.Width = 72;
            // 
            // colPortMode
            // 
            this.colPortMode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPortMode.AppearanceHeader.Options.UseFont = true;
            this.colPortMode.Caption = "Port Mode";
            this.colPortMode.FieldName = "PortMode";
            this.colPortMode.Name = "colPortMode";
            this.colPortMode.Visible = true;
            this.colPortMode.VisibleIndex = 3;
            this.colPortMode.Width = 113;
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Location = new System.Drawing.Point(2, 138);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.grdData.Size = new System.Drawing.Size(734, 319);
            this.grdData.TabIndex = 19;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            this.grdData.Click += new System.EventHandler(this.grdData_Click);
            this.grdData.DoubleClick += new System.EventHandler(this.grdData_DoubleClick);
            // 
            // frmReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 463);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdData);
            this.Name = "frmReader";
            this.Text = "QUẢN LÝ ĐẦU ĐỌC THẺ";
            this.Load += new System.EventHandler(this.frmParkingArea_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCOMPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboParkingLot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboParkingLot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colReaderCode;
        private DevExpress.XtraGrid.Columns.GridColumn colReaderName;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtReaderCode;
        private System.Windows.Forms.TextBox txtReaderName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.GridControl grdData;
        private System.Windows.Forms.CheckBox chkActive;
        private DevExpress.XtraEditors.SearchLookUpEdit cboParkingLot;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCboParkingLot;
        private DevExpress.XtraGrid.Columns.GridColumn colCboID;
        private DevExpress.XtraGrid.Columns.GridColumn colCboParkingLotCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCboParkingLotName;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.Columns.GridColumn colParkingLotID;
        private DevExpress.XtraGrid.Columns.GridColumn colPakingLotName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMPort;
        private DevExpress.XtraGrid.Columns.GridColumn colPortMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPortMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numCOMPort;
    }
}