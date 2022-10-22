namespace Gerente.Compras
{
    partial class ComprasAdmin
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
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.Separator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Separator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnGenerarCompra = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnProveedor = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.AutoSize = true;
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 65);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(848, 525);
            this.panelContenedor.TabIndex = 165;
            this.panelContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenedor_Paint);
            // 
            // Separator1
            // 
            this.Separator1.BackColor = System.Drawing.Color.Transparent;
            this.Separator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.Separator1.LineThickness = 6;
            this.Separator1.Location = new System.Drawing.Point(0, 55);
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(424, 10);
            this.Separator1.TabIndex = 2;
            this.Separator1.Transparency = 255;
            this.Separator1.Vertical = false;
            this.Separator1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Separator2);
            this.panel1.Controls.Add(this.btnGenerarCompra);
            this.panel1.Controls.Add(this.Separator1);
            this.panel1.Controls.Add(this.btnProveedor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 65);
            this.panel1.TabIndex = 164;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Separator2
            // 
            this.Separator2.BackColor = System.Drawing.Color.Transparent;
            this.Separator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.Separator2.LineThickness = 6;
            this.Separator2.Location = new System.Drawing.Point(424, 55);
            this.Separator2.Name = "Separator2";
            this.Separator2.Size = new System.Drawing.Size(424, 10);
            this.Separator2.TabIndex = 4;
            this.Separator2.Transparency = 255;
            this.Separator2.Vertical = false;
            this.Separator2.Visible = false;
            // 
            // btnGenerarCompra
            // 
            this.btnGenerarCompra.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.btnGenerarCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            this.btnGenerarCompra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerarCompra.BorderRadius = 0;
            this.btnGenerarCompra.ButtonText = "Generar Compra";
            this.btnGenerarCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarCompra.DisabledColor = System.Drawing.Color.Gray;
            this.btnGenerarCompra.Iconcolor = System.Drawing.Color.Transparent;
            this.btnGenerarCompra.Iconimage = global::Gerente.Properties.Resources.generarCompra;
            this.btnGenerarCompra.Iconimage_right = null;
            this.btnGenerarCompra.Iconimage_right_Selected = null;
            this.btnGenerarCompra.Iconimage_Selected = null;
            this.btnGenerarCompra.IconMarginLeft = 0;
            this.btnGenerarCompra.IconMarginRight = 0;
            this.btnGenerarCompra.IconRightVisible = true;
            this.btnGenerarCompra.IconRightZoom = 0D;
            this.btnGenerarCompra.IconVisible = true;
            this.btnGenerarCompra.IconZoom = 50D;
            this.btnGenerarCompra.IsTab = true;
            this.btnGenerarCompra.Location = new System.Drawing.Point(424, 0);
            this.btnGenerarCompra.Name = "btnGenerarCompra";
            this.btnGenerarCompra.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            this.btnGenerarCompra.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.btnGenerarCompra.OnHoverTextColor = System.Drawing.Color.White;
            this.btnGenerarCompra.selected = false;
            this.btnGenerarCompra.Size = new System.Drawing.Size(424, 65);
            this.btnGenerarCompra.TabIndex = 5;
            this.btnGenerarCompra.Text = "Generar Compra";
            this.btnGenerarCompra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGenerarCompra.Textcolor = System.Drawing.Color.White;
            this.btnGenerarCompra.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarCompra.Click += new System.EventHandler(this.btnGenerarCompra_Click);
            // 
            // btnProveedor
            // 
            this.btnProveedor.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.btnProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            this.btnProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProveedor.BorderRadius = 0;
            this.btnProveedor.ButtonText = "Proveedor";
            this.btnProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProveedor.DisabledColor = System.Drawing.Color.Gray;
            this.btnProveedor.Iconcolor = System.Drawing.Color.Transparent;
            this.btnProveedor.Iconimage = global::Gerente.Properties.Resources.proveedor;
            this.btnProveedor.Iconimage_right = null;
            this.btnProveedor.Iconimage_right_Selected = null;
            this.btnProveedor.Iconimage_Selected = null;
            this.btnProveedor.IconMarginLeft = 0;
            this.btnProveedor.IconMarginRight = 0;
            this.btnProveedor.IconRightVisible = true;
            this.btnProveedor.IconRightZoom = 0D;
            this.btnProveedor.IconVisible = true;
            this.btnProveedor.IconZoom = 60D;
            this.btnProveedor.IsTab = true;
            this.btnProveedor.Location = new System.Drawing.Point(0, 0);
            this.btnProveedor.Name = "btnProveedor";
            this.btnProveedor.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            this.btnProveedor.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.btnProveedor.OnHoverTextColor = System.Drawing.Color.White;
            this.btnProveedor.selected = false;
            this.btnProveedor.Size = new System.Drawing.Size(424, 65);
            this.btnProveedor.TabIndex = 3;
            this.btnProveedor.Text = "Proveedor";
            this.btnProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnProveedor.Textcolor = System.Drawing.Color.White;
            this.btnProveedor.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedor.Click += new System.EventHandler(this.btnClienteAdmin_Click);
            // 
            // ComprasAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(848, 590);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ComprasAdmin";
            this.Text = "ComprasAdmin";
            this.Load += new System.EventHandler(this.ComprasAdmin_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelContenedor;
        private Bunifu.Framework.UI.BunifuSeparator Separator1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuSeparator Separator2;
        private Bunifu.Framework.UI.BunifuFlatButton btnGenerarCompra;
        private Bunifu.Framework.UI.BunifuFlatButton btnProveedor;
    }
}