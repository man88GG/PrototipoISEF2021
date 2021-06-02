namespace CapaVista.Procesos.Facturacion
{
    partial class frmMostrarNumerosOrden
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
            this.lblReclutas = new System.Windows.Forms.Label();
            this.pnlDatosFiltro = new System.Windows.Forms.Panel();
            this.dgvMostrarReclutas = new System.Windows.Forms.DataGridView();
            this.btnIngresoFact = new System.Windows.Forms.Button();
            this.pnlDatosFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrarReclutas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReclutas
            // 
            this.lblReclutas.AutoSize = true;
            this.lblReclutas.BackColor = System.Drawing.Color.White;
            this.lblReclutas.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReclutas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblReclutas.Location = new System.Drawing.Point(428, 26);
            this.lblReclutas.Name = "lblReclutas";
            this.lblReclutas.Size = new System.Drawing.Size(247, 27);
            this.lblReclutas.TabIndex = 3;
            this.lblReclutas.Text = "Datos de Facturación";
            // 
            // pnlDatosFiltro
            // 
            this.pnlDatosFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(57)))), ((int)(((byte)(139)))));
            this.pnlDatosFiltro.BackgroundImage = global::CapaVista.Properties.Resources.fondo3;
            this.pnlDatosFiltro.Controls.Add(this.btnIngresoFact);
            this.pnlDatosFiltro.Controls.Add(this.dgvMostrarReclutas);
            this.pnlDatosFiltro.Controls.Add(this.lblReclutas);
            this.pnlDatosFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDatosFiltro.Location = new System.Drawing.Point(0, 0);
            this.pnlDatosFiltro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlDatosFiltro.Name = "pnlDatosFiltro";
            this.pnlDatosFiltro.Size = new System.Drawing.Size(1065, 640);
            this.pnlDatosFiltro.TabIndex = 11;
            // 
            // dgvMostrarReclutas
            // 
            this.dgvMostrarReclutas.AllowUserToAddRows = false;
            this.dgvMostrarReclutas.AllowUserToDeleteRows = false;
            this.dgvMostrarReclutas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMostrarReclutas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMostrarReclutas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvMostrarReclutas.Location = new System.Drawing.Point(0, 109);
            this.dgvMostrarReclutas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMostrarReclutas.Name = "dgvMostrarReclutas";
            this.dgvMostrarReclutas.RowHeadersVisible = false;
            this.dgvMostrarReclutas.RowHeadersWidth = 51;
            this.dgvMostrarReclutas.RowTemplate.Height = 24;
            this.dgvMostrarReclutas.Size = new System.Drawing.Size(1065, 531);
            this.dgvMostrarReclutas.TabIndex = 12;
            // 
            // btnIngresoFact
            // 
            this.btnIngresoFact.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnIngresoFact.Location = new System.Drawing.Point(856, 12);
            this.btnIngresoFact.Name = "btnIngresoFact";
            this.btnIngresoFact.Size = new System.Drawing.Size(179, 73);
            this.btnIngresoFact.TabIndex = 140;
            this.btnIngresoFact.Text = "Actualizar Tabla";
            this.btnIngresoFact.UseVisualStyleBackColor = true;
            this.btnIngresoFact.Click += new System.EventHandler(this.btnIngresoFact_Click);
            // 
            // frmMostrarNumerosOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(57)))), ((int)(((byte)(139)))));
            this.ClientSize = new System.Drawing.Size(1065, 640);
            this.Controls.Add(this.pnlDatosFiltro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMostrarNumerosOrden";
            this.Text = "Mostrar Datos de Facturacion";
            this.Load += new System.EventHandler(this.frmMostrarReclutas_Load);
            this.pnlDatosFiltro.ResumeLayout(false);
            this.pnlDatosFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMostrarReclutas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblReclutas;
        private System.Windows.Forms.Panel pnlDatosFiltro;
        private System.Windows.Forms.DataGridView dgvMostrarReclutas;
        private System.Windows.Forms.Button btnIngresoFact;
    }
}