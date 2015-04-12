namespace VehiculoSoft.Registros
{
    partial class rCobros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rCobros));
            this.CancelarButton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.LimpiarButton = new System.Windows.Forms.Button();
            this.AbonoButton = new System.Windows.Forms.Button();
            this.FinanzaComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BuscarButtom = new System.Windows.Forms.Button();
            this.IdtextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CobrosDataGridView = new System.Windows.Forms.DataGridView();
            this.IdCobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdFInanciamiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BalanceTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CobrosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelarButton
            // 
            this.CancelarButton.Location = new System.Drawing.Point(400, 293);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 23);
            this.CancelarButton.TabIndex = 5;
            this.CancelarButton.Text = "Eliminar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(319, 293);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(75, 23);
            this.GuardarButton.TabIndex = 4;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // LimpiarButton
            // 
            this.LimpiarButton.Location = new System.Drawing.Point(238, 293);
            this.LimpiarButton.Name = "LimpiarButton";
            this.LimpiarButton.Size = new System.Drawing.Size(75, 23);
            this.LimpiarButton.TabIndex = 3;
            this.LimpiarButton.Text = "Limpiar";
            this.LimpiarButton.UseVisualStyleBackColor = true;
            this.LimpiarButton.Click += new System.EventHandler(this.LimpiarButton_Click);
            // 
            // AbonoButton
            // 
            this.AbonoButton.Location = new System.Drawing.Point(253, 67);
            this.AbonoButton.Name = "AbonoButton";
            this.AbonoButton.Size = new System.Drawing.Size(156, 23);
            this.AbonoButton.TabIndex = 10;
            this.AbonoButton.Text = "Nuevo Abono";
            this.AbonoButton.UseVisualStyleBackColor = true;
            this.AbonoButton.Click += new System.EventHandler(this.AbonoButton_Click);
            // 
            // FinanzaComboBox
            // 
            this.FinanzaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FinanzaComboBox.FormattingEnabled = true;
            this.FinanzaComboBox.Location = new System.Drawing.Point(113, 42);
            this.FinanzaComboBox.Name = "FinanzaComboBox";
            this.FinanzaComboBox.Size = new System.Drawing.Size(116, 21);
            this.FinanzaComboBox.TabIndex = 11;
            this.FinanzaComboBox.SelectionChangeCommitted += new System.EventHandler(this.FinanzaComboBox_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Financiamiento";
            // 
            // BuscarButtom
            // 
            this.BuscarButtom.Image = ((System.Drawing.Image)(resources.GetObject("BuscarButtom.Image")));
            this.BuscarButtom.Location = new System.Drawing.Point(195, 7);
            this.BuscarButtom.Name = "BuscarButtom";
            this.BuscarButtom.Size = new System.Drawing.Size(34, 29);
            this.BuscarButtom.TabIndex = 35;
            this.BuscarButtom.UseVisualStyleBackColor = true;
            this.BuscarButtom.Click += new System.EventHandler(this.BuscarButtom_Click);
            // 
            // IdtextBox
            // 
            this.IdtextBox.Location = new System.Drawing.Point(113, 12);
            this.IdtextBox.MaxLength = 5;
            this.IdtextBox.Name = "IdtextBox";
            this.IdtextBox.Size = new System.Drawing.Size(67, 20);
            this.IdtextBox.TabIndex = 34;
            this.IdtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdtextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Id:";
            // 
            // CobrosDataGridView
            // 
            this.CobrosDataGridView.AllowUserToAddRows = false;
            this.CobrosDataGridView.AllowUserToDeleteRows = false;
            this.CobrosDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CobrosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CobrosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdCobro,
            this.IdDetalle,
            this.IdFInanciamiento,
            this.Cantidad});
            this.CobrosDataGridView.Location = new System.Drawing.Point(32, 113);
            this.CobrosDataGridView.Name = "CobrosDataGridView";
            this.CobrosDataGridView.ReadOnly = true;
            this.CobrosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CobrosDataGridView.Size = new System.Drawing.Size(443, 152);
            this.CobrosDataGridView.TabIndex = 36;
            // 
            // IdCobro
            // 
            this.IdCobro.HeaderText = "IdCobro";
            this.IdCobro.Name = "IdCobro";
            this.IdCobro.ReadOnly = true;
            // 
            // IdDetalle
            // 
            this.IdDetalle.HeaderText = "IdDetalle";
            this.IdDetalle.Name = "IdDetalle";
            this.IdDetalle.ReadOnly = true;
            this.IdDetalle.Visible = false;
            // 
            // IdFInanciamiento
            // 
            this.IdFInanciamiento.HeaderText = "IdFinanciamiento";
            this.IdFInanciamiento.Name = "IdFInanciamiento";
            this.IdFInanciamiento.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Abono";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // CantidadTextBox
            // 
            this.CantidadTextBox.Location = new System.Drawing.Point(293, 42);
            this.CantidadTextBox.MaxLength = 8;
            this.CantidadTextBox.Name = "CantidadTextBox";
            this.CantidadTextBox.Size = new System.Drawing.Size(116, 20);
            this.CantidadTextBox.TabIndex = 38;
            this.CantidadTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CantidadTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Cantidad";
            // 
            // BalanceTextBox
            // 
            this.BalanceTextBox.Location = new System.Drawing.Point(113, 69);
            this.BalanceTextBox.MaxLength = 8;
            this.BalanceTextBox.Name = "BalanceTextBox";
            this.BalanceTextBox.ReadOnly = true;
            this.BalanceTextBox.Size = new System.Drawing.Size(116, 20);
            this.BalanceTextBox.TabIndex = 40;
            this.BalanceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BalanceTextBox_KeyPress_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Balance";
            // 
            // rCobros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 328);
            this.Controls.Add(this.BalanceTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CantidadTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CobrosDataGridView);
            this.Controls.Add(this.BuscarButtom);
            this.Controls.Add(this.IdtextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FinanzaComboBox);
            this.Controls.Add(this.AbonoButton);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.LimpiarButton);
            this.Name = "rCobros";
            this.Text = "rCobros";
            this.Load += new System.EventHandler(this.rCobros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CobrosDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button LimpiarButton;
        private System.Windows.Forms.Button AbonoButton;
        private System.Windows.Forms.ComboBox FinanzaComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BuscarButtom;
        private System.Windows.Forms.TextBox IdtextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView CobrosDataGridView;
        private System.Windows.Forms.TextBox CantidadTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BalanceTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCobro;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdFInanciamiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
    }
}