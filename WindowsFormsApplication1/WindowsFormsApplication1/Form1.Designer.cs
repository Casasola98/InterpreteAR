namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Menus = new System.Windows.Forms.MenuStrip();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agrupaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.naturalJoinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renombrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.divisiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intersecciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productoCartesianoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diferenciaDeConjuntosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uniónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proyecciónGeneralizadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selecciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Menus.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menus
            // 
            this.Menus.BackColor = System.Drawing.Color.DarkGray;
            this.Menus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Menus.Enabled = false;
            this.Menus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operacionesToolStripMenuItem});
            this.Menus.Location = new System.Drawing.Point(0, 460);
            this.Menus.Name = "Menus";
            this.Menus.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Menus.Size = new System.Drawing.Size(819, 24);
            this.Menus.TabIndex = 0;
            this.Menus.Text = "Menus";
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agrupaciónToolStripMenuItem,
            this.agregaciónToolStripMenuItem,
            this.naturalJoinToolStripMenuItem,
            this.joinToolStripMenuItem,
            this.renombrarToolStripMenuItem,
            this.divisiónToolStripMenuItem,
            this.intersecciónToolStripMenuItem,
            this.productoCartesianoToolStripMenuItem,
            this.diferenciaDeConjuntosToolStripMenuItem,
            this.uniónToolStripMenuItem,
            this.proyecciónGeneralizadaToolStripMenuItem,
            this.selecciónToolStripMenuItem});
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            this.operacionesToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.operacionesToolStripMenuItem.Text = "Operaciones";
            // 
            // agrupaciónToolStripMenuItem
            // 
            this.agrupaciónToolStripMenuItem.Name = "agrupaciónToolStripMenuItem";
            this.agrupaciónToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.agrupaciónToolStripMenuItem.Text = "Agrupación";
            this.agrupaciónToolStripMenuItem.Click += new System.EventHandler(this.agrupaciónToolStripMenuItem_Click);
            // 
            // agregaciónToolStripMenuItem
            // 
            this.agregaciónToolStripMenuItem.Name = "agregaciónToolStripMenuItem";
            this.agregaciónToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.agregaciónToolStripMenuItem.Text = "Agregación";
            this.agregaciónToolStripMenuItem.Click += new System.EventHandler(this.agregaciónToolStripMenuItem_Click);
            // 
            // naturalJoinToolStripMenuItem
            // 
            this.naturalJoinToolStripMenuItem.Name = "naturalJoinToolStripMenuItem";
            this.naturalJoinToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.naturalJoinToolStripMenuItem.Text = "Natural Join";
            this.naturalJoinToolStripMenuItem.Click += new System.EventHandler(this.naturalJoinToolStripMenuItem_Click);
            // 
            // joinToolStripMenuItem
            // 
            this.joinToolStripMenuItem.Name = "joinToolStripMenuItem";
            this.joinToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.joinToolStripMenuItem.Text = "Join";
            this.joinToolStripMenuItem.Click += new System.EventHandler(this.joinToolStripMenuItem_Click);
            // 
            // renombrarToolStripMenuItem
            // 
            this.renombrarToolStripMenuItem.Name = "renombrarToolStripMenuItem";
            this.renombrarToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.renombrarToolStripMenuItem.Text = "Renombrar";
            this.renombrarToolStripMenuItem.Click += new System.EventHandler(this.renombrarToolStripMenuItem_Click);
            // 
            // divisiónToolStripMenuItem
            // 
            this.divisiónToolStripMenuItem.Name = "divisiónToolStripMenuItem";
            this.divisiónToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.divisiónToolStripMenuItem.Text = "División";
            this.divisiónToolStripMenuItem.Click += new System.EventHandler(this.divisiónToolStripMenuItem_Click);
            // 
            // intersecciónToolStripMenuItem
            // 
            this.intersecciónToolStripMenuItem.Name = "intersecciónToolStripMenuItem";
            this.intersecciónToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.intersecciónToolStripMenuItem.Text = "Intersección";
            this.intersecciónToolStripMenuItem.Click += new System.EventHandler(this.intersecciónToolStripMenuItem_Click);
            // 
            // productoCartesianoToolStripMenuItem
            // 
            this.productoCartesianoToolStripMenuItem.Name = "productoCartesianoToolStripMenuItem";
            this.productoCartesianoToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.productoCartesianoToolStripMenuItem.Text = "Producto Cartesiano";
            this.productoCartesianoToolStripMenuItem.Click += new System.EventHandler(this.productoCartesianoToolStripMenuItem_Click);
            // 
            // diferenciaDeConjuntosToolStripMenuItem
            // 
            this.diferenciaDeConjuntosToolStripMenuItem.Name = "diferenciaDeConjuntosToolStripMenuItem";
            this.diferenciaDeConjuntosToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.diferenciaDeConjuntosToolStripMenuItem.Text = "Diferencia de Conjuntos";
            this.diferenciaDeConjuntosToolStripMenuItem.Click += new System.EventHandler(this.diferenciaDeConjuntosToolStripMenuItem_Click);
            // 
            // uniónToolStripMenuItem
            // 
            this.uniónToolStripMenuItem.Name = "uniónToolStripMenuItem";
            this.uniónToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.uniónToolStripMenuItem.Text = "Unión";
            this.uniónToolStripMenuItem.Click += new System.EventHandler(this.uniónToolStripMenuItem_Click);
            // 
            // proyecciónGeneralizadaToolStripMenuItem
            // 
            this.proyecciónGeneralizadaToolStripMenuItem.Name = "proyecciónGeneralizadaToolStripMenuItem";
            this.proyecciónGeneralizadaToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.proyecciónGeneralizadaToolStripMenuItem.Text = "Proyección Generalizada";
            this.proyecciónGeneralizadaToolStripMenuItem.Click += new System.EventHandler(this.proyecciónGeneralizadaToolStripMenuItem_Click);
            // 
            // selecciónToolStripMenuItem
            // 
            this.selecciónToolStripMenuItem.Name = "selecciónToolStripMenuItem";
            this.selecciónToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.selecciónToolStripMenuItem.Text = "Selección";
            this.selecciónToolStripMenuItem.Click += new System.EventHandler(this.selecciónToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkGreen;
            this.label1.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 87);
            this.label1.TabIndex = 1;
            this.label1.Text = "Interpretador \r\nde \r\nÁlgebra Relacional";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.YellowGreen;
            this.btnLogin.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(384, 322);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 41);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(388, 240);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(388, 268);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(388, 296);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre\r\nBD";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(339, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Usuario";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(321, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Contraseña";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.fondo1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(819, 484);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Menus);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainMenuStrip = this.Menus;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "I.A.R";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Menus.ResumeLayout(false);
            this.Menus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menus;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selecciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agrupaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem naturalJoinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem joinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renombrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem divisiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intersecciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productoCartesianoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diferenciaDeConjuntosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proyecciónGeneralizadaToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem uniónToolStripMenuItem;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

