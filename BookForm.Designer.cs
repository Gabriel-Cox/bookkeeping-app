namespace Cox_Gabriel_Assign8
{
    partial class BookForm
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
            TitleTxbx = new TextBox();
            AuthorTxbx = new TextBox();
            YearTxbx = new TextBox();
            PriceTxbx = new TextBox();
            bookListBox = new ListBox();
            TitleTxbxLabel = new Label();
            AuthorTxbxLabel = new Label();
            YearTxbxLabel = new Label();
            PriceTxbxLabel = new Label();
            PrintChbx = new CheckBox();
            PrintChbxLabel = new Label();
            SaveButton = new Button();
            DeleteButton = new Button();
            DollarSignLabel = new Label();
            EditButton = new Button();
            SuspendLayout();
            // 
            // TitleTxbx
            // 
            TitleTxbx.Location = new Point(150, 34);
            TitleTxbx.Name = "TitleTxbx";
            TitleTxbx.Size = new Size(260, 31);
            TitleTxbx.TabIndex = 0;
            // 
            // AuthorTxbx
            // 
            AuthorTxbx.Location = new Point(150, 92);
            AuthorTxbx.Name = "AuthorTxbx";
            AuthorTxbx.Size = new Size(260, 31);
            AuthorTxbx.TabIndex = 1;
            // 
            // YearTxbx
            // 
            YearTxbx.Location = new Point(150, 151);
            YearTxbx.Name = "YearTxbx";
            YearTxbx.Size = new Size(260, 31);
            YearTxbx.TabIndex = 2;
            // 
            // PriceTxbx
            // 
            PriceTxbx.Location = new Point(150, 211);
            PriceTxbx.Name = "PriceTxbx";
            PriceTxbx.Size = new Size(260, 31);
            PriceTxbx.TabIndex = 3;
            // 
            // bookListBox
            // 
            bookListBox.FormattingEnabled = true;
            bookListBox.ItemHeight = 25;
            bookListBox.Location = new Point(442, 34);
            bookListBox.Name = "bookListBox";
            bookListBox.Size = new Size(634, 354);
            bookListBox.TabIndex = 7;
            bookListBox.SelectedIndexChanged += bookListBox_SelectedIndexChanged;
            // 
            // TitleTxbxLabel
            // 
            TitleTxbxLabel.AutoSize = true;
            TitleTxbxLabel.Location = new Point(28, 34);
            TitleTxbxLabel.Name = "TitleTxbxLabel";
            TitleTxbxLabel.Size = new Size(53, 25);
            TitleTxbxLabel.TabIndex = 8;
            TitleTxbxLabel.Text = "Title: ";
            // 
            // AuthorTxbxLabel
            // 
            AuthorTxbxLabel.AutoSize = true;
            AuthorTxbxLabel.Location = new Point(28, 92);
            AuthorTxbxLabel.Name = "AuthorTxbxLabel";
            AuthorTxbxLabel.Size = new Size(76, 25);
            AuthorTxbxLabel.TabIndex = 9;
            AuthorTxbxLabel.Text = "Author: ";
            // 
            // YearTxbxLabel
            // 
            YearTxbxLabel.AutoSize = true;
            YearTxbxLabel.Location = new Point(28, 151);
            YearTxbxLabel.Name = "YearTxbxLabel";
            YearTxbxLabel.Size = new Size(44, 25);
            YearTxbxLabel.TabIndex = 10;
            YearTxbxLabel.Text = "Year";
            // 
            // PriceTxbxLabel
            // 
            PriceTxbxLabel.AutoSize = true;
            PriceTxbxLabel.Location = new Point(28, 211);
            PriceTxbxLabel.Name = "PriceTxbxLabel";
            PriceTxbxLabel.Size = new Size(49, 25);
            PriceTxbxLabel.TabIndex = 11;
            PriceTxbxLabel.Text = "Price";
            // 
            // PrintChbx
            // 
            PrintChbx.AutoSize = true;
            PrintChbx.Location = new Point(150, 271);
            PrintChbx.Name = "PrintChbx";
            PrintChbx.Size = new Size(22, 21);
            PrintChbx.TabIndex = 4;
            PrintChbx.UseVisualStyleBackColor = true;
            // 
            // PrintChbxLabel
            // 
            PrintChbxLabel.AutoSize = true;
            PrintChbxLabel.Location = new Point(28, 267);
            PrintChbxLabel.Name = "PrintChbxLabel";
            PrintChbxLabel.Size = new Size(116, 25);
            PrintChbxLabel.TabIndex = 13;
            PrintChbxLabel.Text = "Out Of Print?";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(150, 308);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(218, 58);
            SaveButton.TabIndex = 5;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(150, 459);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(218, 58);
            DeleteButton.TabIndex = 6;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // DollarSignLabel
            // 
            DollarSignLabel.AutoSize = true;
            DollarSignLabel.Location = new Point(122, 217);
            DollarSignLabel.Name = "DollarSignLabel";
            DollarSignLabel.Size = new Size(22, 25);
            DollarSignLabel.TabIndex = 12;
            DollarSignLabel.Text = "$";
            // 
            // EditButton
            // 
            EditButton.Location = new Point(150, 386);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(218, 58);
            EditButton.TabIndex = 14;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // BookForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1115, 562);
            Controls.Add(EditButton);
            Controls.Add(DollarSignLabel);
            Controls.Add(DeleteButton);
            Controls.Add(SaveButton);
            Controls.Add(PrintChbxLabel);
            Controls.Add(PrintChbx);
            Controls.Add(PriceTxbxLabel);
            Controls.Add(YearTxbxLabel);
            Controls.Add(AuthorTxbxLabel);
            Controls.Add(TitleTxbxLabel);
            Controls.Add(bookListBox);
            Controls.Add(PriceTxbx);
            Controls.Add(YearTxbx);
            Controls.Add(AuthorTxbx);
            Controls.Add(TitleTxbx);
            Name = "BookForm";
            Text = "Book Inventory";
            Load += BookForm_Load;
            Click += BookForm_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TitleTxbx;
        private TextBox AuthorTxbx;
        private TextBox YearTxbx;
        private TextBox PriceTxbx;
        private ListBox bookListBox;
        private Label TitleTxbxLabel;
        private Label AuthorTxbxLabel;
        private Label YearTxbxLabel;
        private Label PriceTxbxLabel;
        private CheckBox PrintChbx;
        private Label PrintChbxLabel;
        private Button SaveButton;
        private Button DeleteButton;
        private Label DollarSignLabel;
        private Button EditButton;
    }
}
