namespace ConEst.UI
{
    partial class EstacionUI
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstacionUI));
            NombreTB = new TextBox();
            DescripcionTB = new TextBox();
            LatitudTB = new TextBox();
            LongitudTB = new TextBox();
            ElementosGB = new GroupBox();
            TablaElementosGV = new DataGridView();
            Menu = new ToolStrip();
            AñadirElementoB = new ToolStripButton();
            EliminarElementoB = new ToolStripButton();
            AceptarB = new Button();
            errorProvider1 = new ErrorProvider(components);
            EstacionGB = new GroupBox();
            CancelarB = new Button();
            ElementosGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TablaElementosGV).BeginInit();
            Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            EstacionGB.SuspendLayout();
            SuspendLayout();
            // 
            // NombreTB
            // 
            NombreTB.Location = new Point(76, 47);
            NombreTB.Name = "NombreTB";
            NombreTB.PlaceholderText = "Nombre";
            NombreTB.Size = new Size(172, 23);
            NombreTB.TabIndex = 0;
            NombreTB.Validating += NombreTB_Validating;
            NombreTB.Validated += NombreTB_Validated;
            // 
            // DescripcionTB
            // 
            DescripcionTB.Location = new Point(76, 91);
            DescripcionTB.Name = "DescripcionTB";
            DescripcionTB.PlaceholderText = "Descripción";
            DescripcionTB.Size = new Size(172, 23);
            DescripcionTB.TabIndex = 1;
            DescripcionTB.Validating += DescripcionTB_Validating;
            DescripcionTB.Validated += DescripcionTB_Validated;
            // 
            // LatitudTB
            // 
            LatitudTB.Location = new Point(348, 47);
            LatitudTB.Name = "LatitudTB";
            LatitudTB.PlaceholderText = "Latitud";
            LatitudTB.Size = new Size(178, 23);
            LatitudTB.TabIndex = 2;
            LatitudTB.KeyPress += LatitudTB_KeyPress;
            LatitudTB.Validating += LatitudTB_Validating;
            LatitudTB.Validated += LatitudTB_Validated;
            // 
            // LongitudTB
            // 
            LongitudTB.Location = new Point(348, 91);
            LongitudTB.Name = "LongitudTB";
            LongitudTB.PlaceholderText = "Longitud";
            LongitudTB.Size = new Size(178, 23);
            LongitudTB.TabIndex = 3;
            LongitudTB.KeyPress += LongitudTB_KeyPress;
            LongitudTB.Validating += LongitudTB_Validating;
            LongitudTB.Validated += LongitudTB_Validated;
            // 
            // ElementosGB
            // 
            ElementosGB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ElementosGB.Controls.Add(TablaElementosGV);
            ElementosGB.Controls.Add(Menu);
            ElementosGB.Location = new Point(12, 164);
            ElementosGB.Name = "ElementosGB";
            ElementosGB.Size = new Size(627, 309);
            ElementosGB.TabIndex = 1;
            ElementosGB.TabStop = false;
            ElementosGB.Text = "Elementos";
            // 
            // TablaElementosGV
            // 
            TablaElementosGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TablaElementosGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TablaElementosGV.Dock = DockStyle.Fill;
            TablaElementosGV.Location = new Point(3, 44);
            TablaElementosGV.MultiSelect = false;
            TablaElementosGV.Name = "TablaElementosGV";
            TablaElementosGV.ReadOnly = true;
            TablaElementosGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TablaElementosGV.Size = new Size(621, 262);
            TablaElementosGV.TabIndex = 0;
            TablaElementosGV.CellContentDoubleClick += TablaElementosGV_CellContentDoubleClick;
            // 
            // Menu
            // 
            Menu.Items.AddRange(new ToolStripItem[] { AñadirElementoB, EliminarElementoB });
            Menu.Location = new Point(3, 19);
            Menu.Name = "Menu";
            Menu.Size = new Size(621, 25);
            Menu.TabIndex = 1;
            Menu.Text = "toolStrip1";
            // 
            // AñadirElementoB
            // 
            AñadirElementoB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            AñadirElementoB.Image = Properties.Resources.plus;
            AñadirElementoB.ImageTransparentColor = Color.Magenta;
            AñadirElementoB.Name = "AñadirElementoB";
            AñadirElementoB.Size = new Size(23, 22);
            AñadirElementoB.Text = "Añadir Elemento";
            AñadirElementoB.Click += AñadirElementoB_Click;
            // 
            // EliminarElementoB
            // 
            EliminarElementoB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            EliminarElementoB.Image = Properties.Resources.bin;
            EliminarElementoB.ImageTransparentColor = Color.Magenta;
            EliminarElementoB.Name = "EliminarElementoB";
            EliminarElementoB.Size = new Size(23, 22);
            EliminarElementoB.Text = "Eliminar Elemento";
            EliminarElementoB.Click += EliminarElementoB_Click;
            // 
            // AceptarB
            // 
            AceptarB.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AceptarB.BackColor = Color.FromArgb(192, 255, 192);
            AceptarB.Location = new Point(561, 516);
            AceptarB.Name = "AceptarB";
            AceptarB.Size = new Size(75, 23);
            AceptarB.TabIndex = 2;
            AceptarB.Text = "Añadir";
            AceptarB.UseVisualStyleBackColor = false;
            AceptarB.Click += AceptarB_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // EstacionGB
            // 
            EstacionGB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            EstacionGB.Controls.Add(NombreTB);
            EstacionGB.Controls.Add(LatitudTB);
            EstacionGB.Controls.Add(LongitudTB);
            EstacionGB.Controls.Add(DescripcionTB);
            EstacionGB.Location = new Point(12, 12);
            EstacionGB.Name = "EstacionGB";
            EstacionGB.Size = new Size(627, 146);
            EstacionGB.TabIndex = 0;
            EstacionGB.TabStop = false;
            EstacionGB.Text = "Datos de la Estación";
            // 
            // CancelarB
            // 
            CancelarB.BackColor = Color.FromArgb(255, 192, 192);
            CancelarB.Location = new Point(12, 516);
            CancelarB.Name = "CancelarB";
            CancelarB.Size = new Size(75, 23);
            CancelarB.TabIndex = 3;
            CancelarB.Text = "Cancelar";
            CancelarB.UseVisualStyleBackColor = false;
            CancelarB.Click += CancelarB_Click;
            // 
            // EstacionUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(651, 571);
            Controls.Add(CancelarB);
            Controls.Add(EstacionGB);
            Controls.Add(AceptarB);
            Controls.Add(ElementosGB);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "EstacionUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Estacion";
            Shown += EstacionUI_Shown;
            ElementosGB.ResumeLayout(false);
            ElementosGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TablaElementosGV).EndInit();
            Menu.ResumeLayout(false);
            Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            EstacionGB.ResumeLayout(false);
            EstacionGB.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox NombreTB;
        private TextBox DescripcionTB;
        private TextBox LatitudTB;
        private TextBox LongitudTB;
        private GroupBox ElementosGB;
        private ToolStrip Menu;
        private ToolStripButton AñadirElementoB;
        private ToolStripButton EliminarElementoB;
        private Button AceptarB;
        private DataGridView TablaElementosGV;
        private ErrorProvider errorProvider1;
        private GroupBox EstacionGB;
        private Button CancelarB;
    }
}