namespace ConEst.UI
{
    partial class HistorialAccionesUI
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
            RegistrosDGV = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)RegistrosDGV).BeginInit();
            SuspendLayout();
            // 
            // RegistrosDGV
            // 
            RegistrosDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            RegistrosDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RegistrosDGV.Dock = DockStyle.Fill;
            RegistrosDGV.Location = new Point(0, 0);
            RegistrosDGV.Name = "RegistrosDGV";
            RegistrosDGV.ReadOnly = true;
            RegistrosDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RegistrosDGV.Size = new Size(763, 329);
            RegistrosDGV.TabIndex = 0;
            // 
            // HistorialAccionesUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(763, 329);
            Controls.Add(RegistrosDGV);
            Name = "HistorialAccionesUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historial de Acciones";
            ((System.ComponentModel.ISupportInitialize)RegistrosDGV).EndInit();
            ResumeLayout(false);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private DataGridView RegistrosDGV;
    }
}