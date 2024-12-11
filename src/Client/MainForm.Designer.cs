namespace Client;

partial class MainForm
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
		splitContainer1 = new SplitContainer();
		tableLayoutPanel1 = new TableLayoutPanel();
		textBoxPasscode = new TextBox();
		textBoxUser = new TextBox();
		buttonShow = new Button();
		label1 = new Label();
		label2 = new Label();
		label3 = new Label();
		textBoxHost = new TextBox();
		tableLayoutPanel2 = new TableLayoutPanel();
		buttonAdd = new Button();
		buttonUpdate = new Button();
		dataGridViewPass = new DataGridView();
		((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
		splitContainer1.Panel1.SuspendLayout();
		splitContainer1.Panel2.SuspendLayout();
		splitContainer1.SuspendLayout();
		tableLayoutPanel1.SuspendLayout();
		tableLayoutPanel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)dataGridViewPass).BeginInit();
		SuspendLayout();
		// 
		// splitContainer1
		// 
		splitContainer1.Dock = DockStyle.Fill;
		splitContainer1.FixedPanel = FixedPanel.Panel1;
		splitContainer1.IsSplitterFixed = true;
		splitContainer1.Location = new Point(0, 0);
		splitContainer1.Name = "splitContainer1";
		// 
		// splitContainer1.Panel1
		// 
		splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
		// 
		// splitContainer1.Panel2
		// 
		splitContainer1.Panel2.Controls.Add(dataGridViewPass);
		splitContainer1.Size = new Size(800, 450);
		splitContainer1.SplitterDistance = 250;
		splitContainer1.TabIndex = 0;
		// 
		// tableLayoutPanel1
		// 
		tableLayoutPanel1.ColumnCount = 2;
		tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
		tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
		tableLayoutPanel1.Controls.Add(textBoxPasscode, 1, 2);
		tableLayoutPanel1.Controls.Add(textBoxUser, 1, 1);
		tableLayoutPanel1.Controls.Add(buttonShow, 0, 6);
		tableLayoutPanel1.Controls.Add(label1, 0, 0);
		tableLayoutPanel1.Controls.Add(label2, 0, 1);
		tableLayoutPanel1.Controls.Add(label3, 0, 2);
		tableLayoutPanel1.Controls.Add(textBoxHost, 1, 0);
		tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 7);
		tableLayoutPanel1.Dock = DockStyle.Fill;
		tableLayoutPanel1.Location = new Point(0, 0);
		tableLayoutPanel1.Name = "tableLayoutPanel1";
		tableLayoutPanel1.RowCount = 8;
		tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
		tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
		tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
		tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
		tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
		tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
		tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
		tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
		tableLayoutPanel1.Size = new Size(250, 450);
		tableLayoutPanel1.TabIndex = 3;
		// 
		// textBoxPasscode
		// 
		textBoxPasscode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBoxPasscode.Location = new Point(73, 63);
		textBoxPasscode.Name = "textBoxPasscode";
		textBoxPasscode.Size = new Size(174, 23);
		textBoxPasscode.TabIndex = 10;
		// 
		// textBoxUser
		// 
		textBoxUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBoxUser.Location = new Point(73, 33);
		textBoxUser.Name = "textBoxUser";
		textBoxUser.Size = new Size(174, 23);
		textBoxUser.TabIndex = 9;
		// 
		// buttonShow
		// 
		buttonShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		tableLayoutPanel1.SetColumnSpan(buttonShow, 2);
		buttonShow.Location = new Point(3, 393);
		buttonShow.Name = "buttonShow";
		buttonShow.Size = new Size(244, 24);
		buttonShow.TabIndex = 3;
		buttonShow.Text = "Show";
		buttonShow.UseVisualStyleBackColor = true;
		buttonShow.Click += ButtonShow_ClickAsync;
		// 
		// label1
		// 
		label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label1.Location = new Point(3, 0);
		label1.Name = "label1";
		label1.Padding = new Padding(0, 5, 0, 5);
		label1.Size = new Size(64, 23);
		label1.TabIndex = 4;
		label1.Text = "Host";
		label1.TextAlign = ContentAlignment.MiddleRight;
		// 
		// label2
		// 
		label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label2.Location = new Point(3, 30);
		label2.Name = "label2";
		label2.Padding = new Padding(0, 5, 0, 5);
		label2.Size = new Size(64, 23);
		label2.TabIndex = 5;
		label2.Text = "User";
		label2.TextAlign = ContentAlignment.MiddleRight;
		// 
		// label3
		// 
		label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label3.Location = new Point(3, 60);
		label3.Name = "label3";
		label3.Padding = new Padding(0, 5, 0, 5);
		label3.Size = new Size(64, 23);
		label3.TabIndex = 6;
		label3.Text = "Passcode";
		label3.TextAlign = ContentAlignment.MiddleRight;
		// 
		// textBoxHost
		// 
		textBoxHost.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBoxHost.Location = new Point(73, 3);
		textBoxHost.Name = "textBoxHost";
		textBoxHost.Size = new Size(174, 23);
		textBoxHost.TabIndex = 7;
		// 
		// tableLayoutPanel2
		// 
		tableLayoutPanel2.ColumnCount = 2;
		tableLayoutPanel1.SetColumnSpan(tableLayoutPanel2, 2);
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
		tableLayoutPanel2.Controls.Add(buttonAdd, 0, 0);
		tableLayoutPanel2.Controls.Add(buttonUpdate, 1, 0);
		tableLayoutPanel2.Dock = DockStyle.Fill;
		tableLayoutPanel2.Location = new Point(0, 420);
		tableLayoutPanel2.Margin = new Padding(0);
		tableLayoutPanel2.Name = "tableLayoutPanel2";
		tableLayoutPanel2.RowCount = 1;
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
		tableLayoutPanel2.Size = new Size(250, 30);
		tableLayoutPanel2.TabIndex = 8;
		// 
		// buttonAdd
		// 
		buttonAdd.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		buttonAdd.Location = new Point(3, 3);
		buttonAdd.Name = "buttonAdd";
		buttonAdd.Size = new Size(119, 24);
		buttonAdd.TabIndex = 1;
		buttonAdd.Text = "Add";
		buttonAdd.UseVisualStyleBackColor = true;
		buttonAdd.Click += ButtonAdd_ClickAsync;
		// 
		// buttonUpdate
		// 
		buttonUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		buttonUpdate.Location = new Point(128, 3);
		buttonUpdate.Name = "buttonUpdate";
		buttonUpdate.Size = new Size(119, 24);
		buttonUpdate.TabIndex = 2;
		buttonUpdate.Text = "Update";
		buttonUpdate.UseVisualStyleBackColor = true;
		buttonUpdate.Click += ButtonUpdate_ClickAsync;
		// 
		// dataGridViewPass
		// 
		dataGridViewPass.AllowUserToAddRows = false;
		dataGridViewPass.AllowUserToDeleteRows = false;
		dataGridViewPass.AllowUserToOrderColumns = true;
		dataGridViewPass.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridViewPass.Dock = DockStyle.Fill;
		dataGridViewPass.Location = new Point(0, 0);
		dataGridViewPass.Name = "dataGridViewPass";
		dataGridViewPass.ReadOnly = true;
		dataGridViewPass.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridViewPass.Size = new Size(546, 450);
		dataGridViewPass.TabIndex = 0;
		dataGridViewPass.SelectionChanged += DataGridViewPass_SelectionChangedAsync;
		// 
		// MainForm
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(800, 450);
		Controls.Add(splitContainer1);
		Name = "MainForm";
		Text = "Main Form";
		Load += MainForm_LoadAsync;
		splitContainer1.Panel1.ResumeLayout(false);
		splitContainer1.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
		splitContainer1.ResumeLayout(false);
		tableLayoutPanel1.ResumeLayout(false);
		tableLayoutPanel1.PerformLayout();
		tableLayoutPanel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)dataGridViewPass).EndInit();
		ResumeLayout(false);
	}

	#endregion

	private SplitContainer splitContainer1;
	private DataGridView dataGridViewPass;
	private Button buttonAdd;
	private Button buttonUpdate;
	private TableLayoutPanel tableLayoutPanel1;
	private Button buttonShow;
	private Label label1;
	private Label label2;
	private Label label3;
	private TextBox textBoxHost;
	private TextBox textBoxPasscode;
	private TextBox textBoxUser;
	private TableLayoutPanel tableLayoutPanel2;
}
