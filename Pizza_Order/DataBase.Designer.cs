namespace Pizza_Order
{
    partial class DataBase
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
            this.OrdersDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ToppingTextBox = new System.Windows.Forms.TextBox();
            this.PizzaSizeComboBox = new System.Windows.Forms.ComboBox();
            this.ApplyFiltersButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // OrdersDataGridView
            // 
            this.OrdersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrdersDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OrdersDataGridView.Location = new System.Drawing.Point(0, 199);
            this.OrdersDataGridView.Name = "OrdersDataGridView";
            this.OrdersDataGridView.Size = new System.Drawing.Size(800, 251);
            this.OrdersDataGridView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Список заказов";
            // 
            // ToppingTextBox
            // 
            this.ToppingTextBox.Location = new System.Drawing.Point(19, 84);
            this.ToppingTextBox.Name = "ToppingTextBox";
            this.ToppingTextBox.Size = new System.Drawing.Size(100, 20);
            this.ToppingTextBox.TabIndex = 2;
            // 
            // PizzaSizeComboBox
            // 
            this.PizzaSizeComboBox.FormattingEnabled = true;
            this.PizzaSizeComboBox.Location = new System.Drawing.Point(214, 84);
            this.PizzaSizeComboBox.Name = "PizzaSizeComboBox";
            this.PizzaSizeComboBox.Size = new System.Drawing.Size(121, 21);
            this.PizzaSizeComboBox.TabIndex = 3;
            // 
            // ApplyFiltersButton
            // 
            this.ApplyFiltersButton.Location = new System.Drawing.Point(19, 150);
            this.ApplyFiltersButton.Name = "ApplyFiltersButton";
            this.ApplyFiltersButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyFiltersButton.TabIndex = 4;
            this.ApplyFiltersButton.Text = "button1";
            this.ApplyFiltersButton.UseVisualStyleBackColor = true;
            this.ApplyFiltersButton.Click += new System.EventHandler(this.ApplyFiltersButton_Click);
            // 
            // DataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ApplyFiltersButton);
            this.Controls.Add(this.PizzaSizeComboBox);
            this.Controls.Add(this.ToppingTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OrdersDataGridView);
            this.Name = "DataBase";
            this.Text = "DataBase";
            this.Load += new System.EventHandler(this.DataBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrdersDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView OrdersDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ToppingTextBox;
        private System.Windows.Forms.ComboBox PizzaSizeComboBox;
        private System.Windows.Forms.Button ApplyFiltersButton;
    }
}