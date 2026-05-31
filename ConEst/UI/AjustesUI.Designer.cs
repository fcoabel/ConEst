namespace ConEst.UI
{
    partial class AjustesUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AjustesUI));
            EnlaceTB = new TextBox();
            NombreBDTB = new TextBox();
            UsuarioGB = new GroupBox();
            toolStrip1 = new ToolStrip();
            AñadirB = new ToolStripButton();
            EliminarB = new ToolStripButton();
            RegistrosB = new ToolStripButton();
            UsuariosDGV = new DataGridView();
            AceptarB = new Button();
            UsuarioGB.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UsuariosDGV).BeginInit();
            SuspendLayout();
            // 
            // EnlaceTB
            // 
            EnlaceTB.Location = new Point(49, 44);
            EnlaceTB.Name = "EnlaceTB";
            EnlaceTB.PlaceholderText = "Direccion a la Base de Datos";
            EnlaceTB.Size = new Size(392, 23);
            EnlaceTB.TabIndex = 0;
            // 
            // NombreBDTB
            // 
            NombreBDTB.Location = new Point(49, 95);
            NombreBDTB.Name = "NombreBDTB";
            NombreBDTB.PlaceholderText = "Nombre de la Base de Datos";
            NombreBDTB.Size = new Size(392, 23);
            NombreBDTB.TabIndex = 1;
            // 
            // UsuarioGB
            // 
            UsuarioGB.Controls.Add(toolStrip1);
            UsuarioGB.Controls.Add(UsuariosDGV);
            UsuarioGB.Location = new Point(12, 155);
            UsuarioGB.Name = "UsuarioGB";
            UsuarioGB.Size = new Size(493, 315);
            UsuarioGB.TabIndex = 2;
            UsuarioGB.TabStop = false;
            UsuarioGB.Text = "Control de Usuarios";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { AñadirB, EliminarB, RegistrosB });
            toolStrip1.Location = new Point(3, 19);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(487, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // AñadirB
            // 
            AñadirB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            AñadirB.Image = Properties.Resources.plus;
            AñadirB.ImageTransparentColor = Color.Magenta;
            AñadirB.Name = "AñadirB";
            AñadirB.Size = new Size(23, 22);
            AñadirB.Text = "toolStripButton1";
            AñadirB.Click += AñadirB_Click;
            // 
            // EliminarB
            // 
            EliminarB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            EliminarB.Image = Properties.Resources.bin;
            EliminarB.ImageTransparentColor = Color.Magenta;
            EliminarB.Name = "EliminarB";
            EliminarB.Size = new Size(23, 22);
            EliminarB.Text = "toolStripButton2";
            EliminarB.Click += EliminarB_Click;
            // 
            // RegistrosB
            // 
            RegistrosB.Alignment = ToolStripItemAlignment.Right;
            RegistrosB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            RegistrosB.Image = Properties.Resources.history;
            RegistrosB.ImageTransparentColor = Color.Magenta;
            RegistrosB.Name = "RegistrosB";
            RegistrosB.Size = new Size(23, 22);
            RegistrosB.Text = "Historial de Acciones";
            RegistrosB.Click += RegistrosB_Click;
            // 
            // UsuariosDGV
            // 
            UsuariosDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UsuariosDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UsuariosDGV.Location = new Point(6, 50);
            UsuariosDGV.MultiSelect = false;
            UsuariosDGV.Name = "UsuariosDGV";
            UsuariosDGV.ReadOnly = true;
            UsuariosDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            UsuariosDGV.Size = new Size(481, 259);
            UsuariosDGV.TabIndex = 0;
            UsuariosDGV.DataBindingComplete += UsuariosDGV_DataBindingComplete;
            // 
            // AceptarB
            // 
            AceptarB.Location = new Point(420, 497);
            AceptarB.Name = "AceptarB";
            AceptarB.Size = new Size(75, 23);
            AceptarB.TabIndex = 3;
            AceptarB.Text = "Aceptar";
            AceptarB.UseVisualStyleBackColor = true;
            AceptarB.Click += AceptarB_Click;
            // 
            // AjustesUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 538);
            Controls.Add(AceptarB);
            Controls.Add(UsuarioGB);
            Controls.Add(NombreBDTB);
            Controls.Add(EnlaceTB);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AjustesUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ajustes";
            Shown += AjustesUI_Shown;
            UsuarioGB.ResumeLayout(false);
            UsuarioGB.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UsuariosDGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox EnlaceTB;
        private TextBox NombreBDTB;
        private GroupBox UsuarioGB;
        private ToolStrip toolStrip1;
        private ToolStripButton AñadirB;
        private ToolStripButton EliminarB;
        private DataGridView UsuariosDGV;
        private Button AceptarB;
        private ToolStripButton RegistrosB;
    }
}