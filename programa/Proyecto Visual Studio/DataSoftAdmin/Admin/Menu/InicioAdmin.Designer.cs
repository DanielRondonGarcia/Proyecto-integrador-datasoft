namespace Admin
{
    partial class InicioAdmin
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.HoraFecha = new System.Windows.Forms.Timer(this.components);
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.LbFecha = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.LbHora = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.GraficoVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GraficoVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // HoraFecha
            // 
            this.HoraFecha.Enabled = true;
            this.HoraFecha.Tick += new System.EventHandler(this.HoraFecha_Tick);
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.Gainsboro;
            this.panelContenedor.Controls.Add(this.GraficoVentas);
            this.panelContenedor.Controls.Add(this.bunifuCustomLabel2);
            this.panelContenedor.Controls.Add(this.bunifuCustomLabel1);
            this.panelContenedor.Controls.Add(this.LbFecha);
            this.panelContenedor.Controls.Add(this.LbHora);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(848, 590);
            this.panelContenedor.TabIndex = 21;
            this.panelContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenedor_Paint);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(142)))), ((int)(((byte)(242)))));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(18, 21);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(138, 36);
            this.bunifuCustomLabel2.TabIndex = 23;
            this.bunifuCustomLabel2.Text = "Sucursal:";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(129)))), ((int)(((byte)(147)))));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(162, 21);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(129, 36);
            this.bunifuCustomLabel1.TabIndex = 22;
            this.bunifuCustomLabel1.Text = "Nombre";
            // 
            // LbFecha
            // 
            this.LbFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LbFecha.AutoSize = true;
            this.LbFecha.BackColor = System.Drawing.Color.Transparent;
            this.LbFecha.Font = new System.Drawing.Font("Century Gothic", 38.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(129)))), ((int)(((byte)(147)))));
            this.LbFecha.Location = new System.Drawing.Point(63, 497);
            this.LbFecha.Name = "LbFecha";
            this.LbFecha.Size = new System.Drawing.Size(151, 62);
            this.LbFecha.TabIndex = 21;
            this.LbFecha.Text = "Date";
            this.LbFecha.Click += new System.EventHandler(this.LbFecha_Click);
            // 
            // LbHora
            // 
            this.LbHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LbHora.AutoSize = true;
            this.LbHora.BackColor = System.Drawing.Color.Transparent;
            this.LbHora.Font = new System.Drawing.Font("Century Gothic", 40F);
            this.LbHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(142)))), ((int)(((byte)(242)))));
            this.LbHora.Location = new System.Drawing.Point(497, 440);
            this.LbHora.Name = "LbHora";
            this.LbHora.Size = new System.Drawing.Size(153, 65);
            this.LbHora.TabIndex = 20;
            this.LbHora.Text = "Hora";
            this.LbHora.Click += new System.EventHandler(this.LbHora_Click);
            // 
            // GraficoVentas
            // 
            chartArea1.Name = "ChartArea1";
            this.GraficoVentas.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.GraficoVentas.Legends.Add(legend1);
            this.GraficoVentas.Location = new System.Drawing.Point(37, 121);
            this.GraficoVentas.Name = "GraficoVentas";
            this.GraficoVentas.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.GraficoVentas.Series.Add(series1);
            this.GraficoVentas.Size = new System.Drawing.Size(300, 300);
            this.GraficoVentas.TabIndex = 24;
            this.GraficoVentas.Text = "chart1";
            this.GraficoVentas.Visible = false;
            this.GraficoVentas.Click += new System.EventHandler(this.chart1_Click);
            // 
            // InicioAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(848, 590);
            this.Controls.Add(this.panelContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InicioAdmin";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GraficoVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer HoraFecha;
        private System.Windows.Forms.Panel panelContenedor;
        private Bunifu.Framework.UI.BunifuCustomLabel LbFecha;
        private Bunifu.Framework.UI.BunifuCustomLabel LbHora;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart GraficoVentas;
    }
}