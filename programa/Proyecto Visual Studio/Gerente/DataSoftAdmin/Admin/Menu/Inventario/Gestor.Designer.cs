namespace Gerente.Compras
{
    partial class Gestor
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
            this.btnCrearProducto = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnStock = new Bunifu.Framework.UI.BunifuFlatButton();
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
            this.panel1.Controls.Add(this.btnCrearProducto);
            this.panel1.Controls.Add(this.Separator1);
            this.panel1.Controls.Add(this.btnStock);
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
            // btnCrearProducto
            // 
            this.btnCrearProducto.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.btnCrearProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            this.btnCrearProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrearProducto.BorderRadius = 0;
            this.btnCrearProducto.ButtonText = "Crear Productos";
            this.btnCrearProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearProducto.DisabledColor = System.Drawing.Color.Gray;
            this.btnCrearProducto.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCrearProducto.Iconimage = global::Gerente.Properties.Resources.generarCompra;
            this.btnCrearProducto.Iconimage_right = null;
            this.btnCrearProducto.Iconimage_right_Selected = null;
            this.btnCrearProducto.Iconimage_Selected = null;
            this.btnCrearProducto.IconMarginLeft = 0;
            this.btnCrearProducto.IconMarginRight = 0;
            this.btnCrearProducto.IconRightVisible = true;
            this.btnCrearProducto.IconRightZoom = 0D;
            this.btnCrearProducto.IconVisible = true;
            this.btnCrearProducto.IconZoom = 50D;
            this.btnCrearProducto.IsTab = true;
            this.btnCrearProducto.Location = new System.Drawing.Point(424, 0);
            this.btnCrearProducto.Name = "btnCrearProducto";
            this.btnCrearProducto.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            this.btnCrearProducto.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.btnCrearProducto.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCrearProducto.selected = false;
            this.btnCrearProducto.Size = new System.Drawing.Size(424, 65);
            this.btnCrearProducto.TabIndex = 5;
            this.btnCrearProducto.Text = "Crear Productos";
            this.btnCrearProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCrearProducto.Textcolor = System.Drawing.Color.White;
            this.btnCrearProducto.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearProducto.Click += new System.EventHandler(this.btnCrearProducto_Click);
            // 
            // btnStock
            // 
            this.btnStock.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.btnStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            this.btnStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStock.BorderRadius = 0;
            this.btnStock.ButtonText = "Stock";
            this.btnStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStock.DisabledColor = System.Drawing.Color.Gray;
            this.btnStock.Iconcolor = System.Drawing.Color.Transparent;
            this.btnStock.Iconimage = global::Gerente.Properties.Resources.proveedor;
            this.btnStock.Iconimage_right = null;
            this.btnStock.Iconimage_right_Selected = null;
            this.btnStock.Iconimage_Selected = null;
            this.btnStock.IconMarginLeft = 0;
            this.btnStock.IconMarginRight = 0;
            this.btnStock.IconRightVisible = true;
            this.btnStock.IconRightZoom = 0D;
            this.btnStock.IconVisible = true;
            this.btnStock.IconZoom = 60D;
            this.btnStock.IsTab = true;
            this.btnStock.Location = new System.Drawing.Point(0, 0);
            this.btnStock.Name = "btnStock";
            this.btnStock.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            this.btnStock.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.btnStock.OnHoverTextColor = System.Drawing.Color.White;
            this.btnStock.selected = false;
            this.btnStock.Size = new System.Drawing.Size(424, 65);
            this.btnStock.TabIndex = 3;
            this.btnStock.Text = "Stock";
            this.btnStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStock.Textcolor = System.Drawing.Color.White;
            this.btnStock.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // Gestor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(848, 590);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Gestor";
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
        private Bunifu.Framework.UI.BunifuFlatButton btnCrearProducto;
        private Bunifu.Framework.UI.BunifuFlatButton btnStock;
    }
}