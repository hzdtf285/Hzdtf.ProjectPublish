
namespace Hzdtf.ProjectPublish.WinForm
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLocalPublish = new System.Windows.Forms.Button();
            this.btnPublish = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbRemoteBakNo = new System.Windows.Forms.RadioButton();
            this.rbRemoteBakYes = new System.Windows.Forms.RadioButton();
            this.rbRemoteBakDefault = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rbLocalCompileNo = new System.Windows.Forms.RadioButton();
            this.rbLocalCompileYes = new System.Windows.Forms.RadioButton();
            this.rbLocalCompileDefault = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.rbFullUpdateNo = new System.Windows.Forms.RadioButton();
            this.rbFullUpdateYes = new System.Windows.Forms.RadioButton();
            this.rbFullUpdateDefault = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlEnviVar = new System.Windows.Forms.ComboBox();
            this.cbxRemoteWay = new System.Windows.Forms.ComboBox();
            this.cbxServer = new System.Windows.Forms.ComboBox();
            this.btnTestConn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxAllProject = new System.Windows.Forms.CheckBox();
            this.dgvProject = new System.Windows.Forms.DataGridView();
            this.IsSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxAllMachine = new System.Windows.Forms.CheckBox();
            this.dgvMachine = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanConnection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProject)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMachine)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLocalPublish);
            this.groupBox1.Controls.Add(this.btnPublish);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ddlEnviVar);
            this.groupBox1.Controls.Add(this.cbxRemoteWay);
            this.groupBox1.Controls.Add(this.cbxServer);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1209, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // btnLocalPublish
            // 
            this.btnLocalPublish.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLocalPublish.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLocalPublish.ForeColor = System.Drawing.Color.Black;
            this.btnLocalPublish.Location = new System.Drawing.Point(954, 11);
            this.btnLocalPublish.Name = "btnLocalPublish";
            this.btnLocalPublish.Size = new System.Drawing.Size(122, 38);
            this.btnLocalPublish.TabIndex = 18;
            this.btnLocalPublish.Text = "本地发布";
            this.btnLocalPublish.UseVisualStyleBackColor = false;
            this.btnLocalPublish.Click += new System.EventHandler(this.btnLocalPublish_Click);
            // 
            // btnPublish
            // 
            this.btnPublish.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPublish.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPublish.ForeColor = System.Drawing.Color.Black;
            this.btnPublish.Location = new System.Drawing.Point(1078, 11);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(122, 38);
            this.btnPublish.TabIndex = 17;
            this.btnPublish.Text = "一键发布";
            this.btnPublish.UseVisualStyleBackColor = false;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbRemoteBakNo);
            this.groupBox6.Controls.Add(this.rbRemoteBakYes);
            this.groupBox6.Controls.Add(this.rbRemoteBakDefault);
            this.groupBox6.Location = new System.Drawing.Point(555, 9);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(155, 42);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "远程备份";
            // 
            // rbRemoteBakNo
            // 
            this.rbRemoteBakNo.AutoSize = true;
            this.rbRemoteBakNo.Location = new System.Drawing.Point(112, 15);
            this.rbRemoteBakNo.Name = "rbRemoteBakNo";
            this.rbRemoteBakNo.Size = new System.Drawing.Size(38, 21);
            this.rbRemoteBakNo.TabIndex = 11;
            this.rbRemoteBakNo.Text = "否";
            this.rbRemoteBakNo.UseVisualStyleBackColor = true;
            // 
            // rbRemoteBakYes
            // 
            this.rbRemoteBakYes.AutoSize = true;
            this.rbRemoteBakYes.Location = new System.Drawing.Point(69, 15);
            this.rbRemoteBakYes.Name = "rbRemoteBakYes";
            this.rbRemoteBakYes.Size = new System.Drawing.Size(38, 21);
            this.rbRemoteBakYes.TabIndex = 11;
            this.rbRemoteBakYes.Text = "是";
            this.rbRemoteBakYes.UseVisualStyleBackColor = true;
            // 
            // rbRemoteBakDefault
            // 
            this.rbRemoteBakDefault.AutoSize = true;
            this.rbRemoteBakDefault.Checked = true;
            this.rbRemoteBakDefault.Location = new System.Drawing.Point(13, 15);
            this.rbRemoteBakDefault.Name = "rbRemoteBakDefault";
            this.rbRemoteBakDefault.Size = new System.Drawing.Size(50, 21);
            this.rbRemoteBakDefault.TabIndex = 10;
            this.rbRemoteBakDefault.TabStop = true;
            this.rbRemoteBakDefault.Text = "默认";
            this.rbRemoteBakDefault.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rbLocalCompileNo);
            this.groupBox7.Controls.Add(this.rbLocalCompileYes);
            this.groupBox7.Controls.Add(this.rbLocalCompileDefault);
            this.groupBox7.Location = new System.Drawing.Point(243, 8);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(150, 42);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "本地编译";
            // 
            // rbLocalCompileNo
            // 
            this.rbLocalCompileNo.AutoSize = true;
            this.rbLocalCompileNo.Location = new System.Drawing.Point(112, 15);
            this.rbLocalCompileNo.Name = "rbLocalCompileNo";
            this.rbLocalCompileNo.Size = new System.Drawing.Size(38, 21);
            this.rbLocalCompileNo.TabIndex = 11;
            this.rbLocalCompileNo.Text = "否";
            this.rbLocalCompileNo.UseVisualStyleBackColor = true;
            // 
            // rbLocalCompileYes
            // 
            this.rbLocalCompileYes.AutoSize = true;
            this.rbLocalCompileYes.Location = new System.Drawing.Point(69, 15);
            this.rbLocalCompileYes.Name = "rbLocalCompileYes";
            this.rbLocalCompileYes.Size = new System.Drawing.Size(38, 21);
            this.rbLocalCompileYes.TabIndex = 11;
            this.rbLocalCompileYes.Text = "是";
            this.rbLocalCompileYes.UseVisualStyleBackColor = true;
            // 
            // rbLocalCompileDefault
            // 
            this.rbLocalCompileDefault.AutoSize = true;
            this.rbLocalCompileDefault.Checked = true;
            this.rbLocalCompileDefault.Location = new System.Drawing.Point(13, 15);
            this.rbLocalCompileDefault.Name = "rbLocalCompileDefault";
            this.rbLocalCompileDefault.Size = new System.Drawing.Size(50, 21);
            this.rbLocalCompileDefault.TabIndex = 10;
            this.rbLocalCompileDefault.TabStop = true;
            this.rbLocalCompileDefault.Text = "默认";
            this.rbLocalCompileDefault.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.rbFullUpdateNo);
            this.groupBox8.Controls.Add(this.rbFullUpdateYes);
            this.groupBox8.Controls.Add(this.rbFullUpdateDefault);
            this.groupBox8.Location = new System.Drawing.Point(399, 9);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(150, 42);
            this.groupBox8.TabIndex = 16;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "全量更新";
            // 
            // rbFullUpdateNo
            // 
            this.rbFullUpdateNo.AutoSize = true;
            this.rbFullUpdateNo.Location = new System.Drawing.Point(112, 15);
            this.rbFullUpdateNo.Name = "rbFullUpdateNo";
            this.rbFullUpdateNo.Size = new System.Drawing.Size(38, 21);
            this.rbFullUpdateNo.TabIndex = 11;
            this.rbFullUpdateNo.Text = "否";
            this.rbFullUpdateNo.UseVisualStyleBackColor = true;
            // 
            // rbFullUpdateYes
            // 
            this.rbFullUpdateYes.AutoSize = true;
            this.rbFullUpdateYes.Location = new System.Drawing.Point(69, 15);
            this.rbFullUpdateYes.Name = "rbFullUpdateYes";
            this.rbFullUpdateYes.Size = new System.Drawing.Size(38, 21);
            this.rbFullUpdateYes.TabIndex = 11;
            this.rbFullUpdateYes.Text = "是";
            this.rbFullUpdateYes.UseVisualStyleBackColor = true;
            // 
            // rbFullUpdateDefault
            // 
            this.rbFullUpdateDefault.AutoSize = true;
            this.rbFullUpdateDefault.Checked = true;
            this.rbFullUpdateDefault.Location = new System.Drawing.Point(13, 15);
            this.rbFullUpdateDefault.Name = "rbFullUpdateDefault";
            this.rbFullUpdateDefault.Size = new System.Drawing.Size(50, 21);
            this.rbFullUpdateDefault.TabIndex = 10;
            this.rbFullUpdateDefault.TabStop = true;
            this.rbFullUpdateDefault.Text = "默认";
            this.rbFullUpdateDefault.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(716, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "环境变量组：";
            // 
            // ddlEnviVar
            // 
            this.ddlEnviVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlEnviVar.FormattingEnabled = true;
            this.ddlEnviVar.Location = new System.Drawing.Point(802, 19);
            this.ddlEnviVar.Name = "ddlEnviVar";
            this.ddlEnviVar.Size = new System.Drawing.Size(146, 25);
            this.ddlEnviVar.TabIndex = 12;
            // 
            // cbxRemoteWay
            // 
            this.cbxRemoteWay.DisplayMember = "Name";
            this.cbxRemoteWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRemoteWay.FormattingEnabled = true;
            this.cbxRemoteWay.Location = new System.Drawing.Point(176, 21);
            this.cbxRemoteWay.Margin = new System.Windows.Forms.Padding(2);
            this.cbxRemoteWay.Name = "cbxRemoteWay";
            this.cbxRemoteWay.Size = new System.Drawing.Size(63, 25);
            this.cbxRemoteWay.TabIndex = 6;
            this.cbxRemoteWay.ValueMember = "Id";
            // 
            // cbxServer
            // 
            this.cbxServer.DisplayMember = "ServerName";
            this.cbxServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServer.FormattingEnabled = true;
            this.cbxServer.Location = new System.Drawing.Point(13, 21);
            this.cbxServer.Margin = new System.Windows.Forms.Padding(2);
            this.cbxServer.Name = "cbxServer";
            this.cbxServer.Size = new System.Drawing.Size(155, 25);
            this.cbxServer.TabIndex = 0;
            this.cbxServer.ValueMember = "ServerId";
            this.cbxServer.SelectedIndexChanged += new System.EventHandler(this.cbxServer_SelectedIndexChanged);
            // 
            // btnTestConn
            // 
            this.btnTestConn.Location = new System.Drawing.Point(122, 11);
            this.btnTestConn.Margin = new System.Windows.Forms.Padding(2);
            this.btnTestConn.Name = "btnTestConn";
            this.btnTestConn.Size = new System.Drawing.Size(105, 29);
            this.btnTestConn.TabIndex = 1;
            this.btnTestConn.Text = "测试连接";
            this.btnTestConn.UseVisualStyleBackColor = true;
            this.btnTestConn.Click += new System.EventHandler(this.btnTestConn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxAllProject);
            this.groupBox2.Controls.Add(this.dgvProject);
            this.groupBox2.Location = new System.Drawing.Point(8, 80);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(349, 428);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "项目列表";
            // 
            // cbxAllProject
            // 
            this.cbxAllProject.AutoSize = true;
            this.cbxAllProject.Location = new System.Drawing.Point(57, 16);
            this.cbxAllProject.Margin = new System.Windows.Forms.Padding(2);
            this.cbxAllProject.Name = "cbxAllProject";
            this.cbxAllProject.Size = new System.Drawing.Size(51, 21);
            this.cbxAllProject.TabIndex = 1;
            this.cbxAllProject.Text = "全选";
            this.cbxAllProject.UseVisualStyleBackColor = true;
            this.cbxAllProject.CheckedChanged += new System.EventHandler(this.cbxAllProject_CheckedChanged);
            // 
            // dgvProject
            // 
            this.dgvProject.ColumnHeadersHeight = 34;
            this.dgvProject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsSelect,
            this.Id,
            this.ProjectName});
            this.dgvProject.Location = new System.Drawing.Point(13, 40);
            this.dgvProject.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProject.MultiSelect = false;
            this.dgvProject.Name = "dgvProject";
            this.dgvProject.RowHeadersWidth = 62;
            this.dgvProject.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProject.Size = new System.Drawing.Size(316, 376);
            this.dgvProject.TabIndex = 0;
            this.dgvProject.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProject_CellContentClick);
            // 
            // IsSelect
            // 
            this.IsSelect.DataPropertyName = "Selected";
            this.IsSelect.FalseValue = "false";
            this.IsSelect.HeaderText = "选择";
            this.IsSelect.IndeterminateValue = "true";
            this.IsSelect.MinimumWidth = 8;
            this.IsSelect.Name = "IsSelect";
            this.IsSelect.TrueValue = "true";
            this.IsSelect.Width = 50;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "ProjectId";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 50;
            // 
            // ProjectName
            // 
            this.ProjectName.DataPropertyName = "ProjectName";
            this.ProjectName.HeaderText = "名称";
            this.ProjectName.MinimumWidth = 8;
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.ReadOnly = true;
            this.ProjectName.Width = 150;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxAllMachine);
            this.groupBox3.Controls.Add(this.dgvMachine);
            this.groupBox3.Controls.Add(this.btnTestConn);
            this.groupBox3.Location = new System.Drawing.Point(368, 80);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(849, 428);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "物理机列表";
            // 
            // cbxAllMachine
            // 
            this.cbxAllMachine.AutoSize = true;
            this.cbxAllMachine.Location = new System.Drawing.Point(57, 16);
            this.cbxAllMachine.Margin = new System.Windows.Forms.Padding(2);
            this.cbxAllMachine.Name = "cbxAllMachine";
            this.cbxAllMachine.Size = new System.Drawing.Size(51, 21);
            this.cbxAllMachine.TabIndex = 1;
            this.cbxAllMachine.Text = "全选";
            this.cbxAllMachine.UseVisualStyleBackColor = true;
            this.cbxAllMachine.CheckedChanged += new System.EventHandler(this.cbxAllMachine_CheckedChanged);
            // 
            // dgvMachine
            // 
            this.dgvMachine.ColumnHeadersHeight = 34;
            this.dgvMachine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Port,
            this.CanConnection,
            this.Status});
            this.dgvMachine.Location = new System.Drawing.Point(13, 40);
            this.dgvMachine.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMachine.MultiSelect = false;
            this.dgvMachine.Name = "dgvMachine";
            this.dgvMachine.RowHeadersWidth = 62;
            this.dgvMachine.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMachine.Size = new System.Drawing.Size(826, 376);
            this.dgvMachine.TabIndex = 0;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Selected";
            this.dataGridViewCheckBoxColumn1.HeaderText = "选择";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 8;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MachineId";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ip";
            this.dataGridViewTextBoxColumn2.HeaderText = "Ip";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // Port
            // 
            this.Port.DataPropertyName = "Port";
            this.Port.HeaderText = "端口";
            this.Port.MinimumWidth = 8;
            this.Port.Name = "Port";
            this.Port.ReadOnly = true;
            this.Port.Width = 50;
            // 
            // CanConnection
            // 
            this.CanConnection.DataPropertyName = "CanConnection";
            this.CanConnection.HeaderText = "可连接";
            this.CanConnection.MinimumWidth = 8;
            this.CanConnection.Name = "CanConnection";
            this.CanConnection.ReadOnly = true;
            this.CanConnection.Width = 80;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "状态";
            this.Status.MinimumWidth = 8;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 330;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtStatus);
            this.groupBox4.Location = new System.Drawing.Point(8, 513);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(349, 279);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "状态";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(13, 21);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(2);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(334, 254);
            this.txtStatus.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtProgress);
            this.groupBox5.Location = new System.Drawing.Point(368, 513);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(843, 279);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "进度";
            // 
            // txtProgress
            // 
            this.txtProgress.Location = new System.Drawing.Point(13, 21);
            this.txtProgress.Margin = new System.Windows.Forms.Padding(2);
            this.txtProgress.Multiline = true;
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.ReadOnly = true;
            this.txtProgress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProgress.Size = new System.Drawing.Size(826, 254);
            this.txtProgress.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 803);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "Hzdtf项目发布";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProject)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMachine)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxServer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvProject;
        private System.Windows.Forms.CheckBox cbxAllProject;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbxAllMachine;
        private System.Windows.Forms.Button btnTestConn;
        private System.Windows.Forms.DataGridView dgvMachine;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtProgress;
        private System.Windows.Forms.ComboBox cbxRemoteWay;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Port;
        private System.Windows.Forms.DataGridViewTextBoxColumn CanConnection;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Button btnLocalPublish;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbRemoteBakNo;
        private System.Windows.Forms.RadioButton rbRemoteBakYes;
        private System.Windows.Forms.RadioButton rbRemoteBakDefault;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton rbLocalCompileNo;
        private System.Windows.Forms.RadioButton rbLocalCompileYes;
        private System.Windows.Forms.RadioButton rbLocalCompileDefault;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton rbFullUpdateNo;
        private System.Windows.Forms.RadioButton rbFullUpdateYes;
        private System.Windows.Forms.RadioButton rbFullUpdateDefault;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlEnviVar;
        private System.Windows.Forms.Button btnPublish;
    }
}

