namespace ModCajaBanco.Reportes.Movimientos
{
    partial class FiltroFrm
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
            this.L_SUCURSAL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_PROCESAR = new System.Windows.Forms.Button();
            this.CB_SUCURSAL = new System.Windows.Forms.ComboBox();
            this.DTP_HASTA = new System.Windows.Forms.DateTimePicker();
            this.DTP_DESDE = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BT_SALIR = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_DEPOSITO = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.desdeNumero = new System.Windows.Forms.NumericUpDown();
            this.hastaNumero = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.desdeNumero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hastaNumero)).BeginInit();
            this.SuspendLayout();
            // 
            // L_SUCURSAL
            // 
            this.L_SUCURSAL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.L_SUCURSAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_SUCURSAL.Location = new System.Drawing.Point(21, 183);
            this.L_SUCURSAL.Name = "L_SUCURSAL";
            this.L_SUCURSAL.Size = new System.Drawing.Size(111, 16);
            this.L_SUCURSAL.TabIndex = 21;
            this.L_SUCURSAL.Text = "Sucursal:";
            this.L_SUCURSAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.L_SUCURSAL.Click += new System.EventHandler(this.L_SUCURSAL_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Hasta La Fecha:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Desde La Fecha:";
            // 
            // BT_PROCESAR
            // 
            this.BT_PROCESAR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_PROCESAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_PROCESAR.Location = new System.Drawing.Point(2, 2);
            this.BT_PROCESAR.Name = "BT_PROCESAR";
            this.BT_PROCESAR.Size = new System.Drawing.Size(96, 33);
            this.BT_PROCESAR.TabIndex = 18;
            this.BT_PROCESAR.Text = "Procesar";
            this.BT_PROCESAR.UseVisualStyleBackColor = true;
            this.BT_PROCESAR.Click += new System.EventHandler(this.BT_PROCESAR_Click);
            // 
            // CB_SUCURSAL
            // 
            this.CB_SUCURSAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_SUCURSAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_SUCURSAL.FormattingEnabled = true;
            this.CB_SUCURSAL.Location = new System.Drawing.Point(149, 180);
            this.CB_SUCURSAL.Name = "CB_SUCURSAL";
            this.CB_SUCURSAL.Size = new System.Drawing.Size(238, 24);
            this.CB_SUCURSAL.TabIndex = 17;
            this.CB_SUCURSAL.SelectedIndexChanged += new System.EventHandler(this.CB_SUCURSAL_SelectedIndexChanged);
            // 
            // DTP_HASTA
            // 
            this.DTP_HASTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_HASTA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_HASTA.Location = new System.Drawing.Point(149, 96);
            this.DTP_HASTA.Name = "DTP_HASTA";
            this.DTP_HASTA.Size = new System.Drawing.Size(238, 22);
            this.DTP_HASTA.TabIndex = 16;
            this.DTP_HASTA.ValueChanged += new System.EventHandler(this.DTP_HASTA_ValueChanged);
            // 
            // DTP_DESDE
            // 
            this.DTP_DESDE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_DESDE.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_DESDE.Location = new System.Drawing.Point(149, 71);
            this.DTP_DESDE.Name = "DTP_DESDE";
            this.DTP_DESDE.Size = new System.Drawing.Size(238, 22);
            this.DTP_DESDE.TabIndex = 15;
            this.DTP_DESDE.ValueChanged += new System.EventHandler(this.DTP_DESDE_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 303);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(413, 43);
            this.panel1.TabIndex = 22;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(411, 41);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BT_PROCESAR);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(206, 2);
            this.panel3.Margin = new System.Windows.Forms.Padding(1);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2);
            this.panel3.Size = new System.Drawing.Size(100, 37);
            this.panel3.TabIndex = 24;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BT_SALIR);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(308, 2);
            this.panel4.Margin = new System.Windows.Forms.Padding(1);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2);
            this.panel4.Size = new System.Drawing.Size(101, 37);
            this.panel4.TabIndex = 25;
            // 
            // BT_SALIR
            // 
            this.BT_SALIR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_SALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_SALIR.Location = new System.Drawing.Point(2, 2);
            this.BT_SALIR.Name = "BT_SALIR";
            this.BT_SALIR.Size = new System.Drawing.Size(97, 33);
            this.BT_SALIR.TabIndex = 19;
            this.BT_SALIR.Text = "Salir";
            this.BT_SALIR.UseVisualStyleBackColor = true;
            this.BT_SALIR.Click += new System.EventHandler(this.BT_SALIR_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Yellow;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(413, 32);
            this.panel2.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(409, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Filtros";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CB_DEPOSITO
            // 
            this.CB_DEPOSITO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_DEPOSITO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_DEPOSITO.FormattingEnabled = true;
            this.CB_DEPOSITO.Location = new System.Drawing.Point(149, 210);
            this.CB_DEPOSITO.Name = "CB_DEPOSITO";
            this.CB_DEPOSITO.Size = new System.Drawing.Size(238, 24);
            this.CB_DEPOSITO.TabIndex = 24;
            this.CB_DEPOSITO.SelectedIndexChanged += new System.EventHandler(this.CB_DEPOSITO_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Depósito:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // desdeNumero
            // 
            this.desdeNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desdeNumero.Location = new System.Drawing.Point(149, 124);
            this.desdeNumero.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.desdeNumero.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.desdeNumero.Name = "desdeNumero";
            this.desdeNumero.Size = new System.Drawing.Size(158, 22);
            this.desdeNumero.TabIndex = 26;
            this.desdeNumero.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.desdeNumero.Leave += new System.EventHandler(this.desdeNumero_Leave);
            // 
            // hastaNumero
            // 
            this.hastaNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hastaNumero.Location = new System.Drawing.Point(149, 152);
            this.hastaNumero.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.hastaNumero.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hastaNumero.Name = "hastaNumero";
            this.hastaNumero.Size = new System.Drawing.Size(158, 22);
            this.hastaNumero.TabIndex = 27;
            this.hastaNumero.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hastaNumero.Leave += new System.EventHandler(this.hastaNumero_Leave);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "Desde El:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "Hasta El:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FiltroFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 346);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.hastaNumero);
            this.Controls.Add(this.desdeNumero);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CB_DEPOSITO);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.L_SUCURSAL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_SUCURSAL);
            this.Controls.Add(this.DTP_HASTA);
            this.Controls.Add(this.DTP_DESDE);
            this.DoubleBuffered = true;
            this.Name = "FiltroFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FiltroFrm_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.desdeNumero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hastaNumero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label L_SUCURSAL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_PROCESAR;
        private System.Windows.Forms.ComboBox CB_SUCURSAL;
        private System.Windows.Forms.DateTimePicker DTP_HASTA;
        private System.Windows.Forms.DateTimePicker DTP_DESDE;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BT_SALIR;
        private System.Windows.Forms.ComboBox CB_DEPOSITO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown desdeNumero;
        private System.Windows.Forms.NumericUpDown hastaNumero;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}