namespace ConEst
{
    partial class EstacionesUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstacionesUI));
            Menu = new ToolStrip();
            AñadirTSB = new ToolStripButton();
            EliminarTSB = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            CerrarSesionTSB = new ToolStripButton();
            AjustesTSB = new ToolStripButton();
            EstacionesDGV = new DataGridView();
            Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)EstacionesDGV).BeginInit();
            SuspendLayout();
            // 
            // Menu
            // 
            resources.ApplyResources(Menu, "Menu");
            Menu.Items.AddRange(new ToolStripItem[] { AñadirTSB, EliminarTSB, toolStripSeparator1, CerrarSesionTSB, AjustesTSB });
            Menu.Name = "Menu";
            // 
            // AñadirTSB
            // 
            resources.ApplyResources(AñadirTSB, "AñadirTSB");
            AñadirTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            AñadirTSB.Image = Properties.Resources.plus;
            AñadirTSB.Name = "AñadirTSB";
            AñadirTSB.Click += AñadirTSB_Click;
            // 
            // EliminarTSB
            // 
            resources.ApplyResources(EliminarTSB, "EliminarTSB");
            EliminarTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            EliminarTSB.Image = Properties.Resources.bin;
            EliminarTSB.Name = "EliminarTSB";
            EliminarTSB.Click += EliminarTSB_Click;
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // CerrarSesionTSB
            // 
            resources.ApplyResources(CerrarSesionTSB, "CerrarSesionTSB");
            CerrarSesionTSB.Alignment = ToolStripItemAlignment.Right;
            CerrarSesionTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            CerrarSesionTSB.Image = Properties.Resources.logout__1_;
            CerrarSesionTSB.Name = "CerrarSesionTSB";
            CerrarSesionTSB.Click += CerrarSesionTSB_Click;
            // 
            // AjustesTSB
            // 
            resources.ApplyResources(AjustesTSB, "AjustesTSB");
            AjustesTSB.Alignment = ToolStripItemAlignment.Right;
            AjustesTSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            AjustesTSB.Image = Properties.Resources.cogwheel;
            AjustesTSB.Name = "AjustesTSB";
            AjustesTSB.Click += AjustesTSB_Click;
            // 
            // EstacionesDGV
            // 
            resources.ApplyResources(EstacionesDGV, "EstacionesDGV");
            EstacionesDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            EstacionesDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EstacionesDGV.MultiSelect = false;
            EstacionesDGV.Name = "EstacionesDGV";
            EstacionesDGV.ReadOnly = true;
            EstacionesDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            EstacionesDGV.CellDoubleClick += EstacionesDGV_CellDoubleClick;
            // 
            // EstacionesUI
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(EstacionesDGV);
            Controls.Add(Menu);
            Name = "EstacionesUI";
            Shown += EstacionesUI_Shown;
            Menu.ResumeLayout(false);
            Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)EstacionesDGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip Menu;
        private DataGridView EstacionesDGV;
        private ToolStripButton AñadirTSB;
        private ToolStripButton EliminarTSB;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton CerrarSesionTSB;
        private ToolStripButton AjustesTSB;
    }
}
