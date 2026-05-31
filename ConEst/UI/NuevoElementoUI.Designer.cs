namespace ConEst.UI
{
    partial class NuevoElementoUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevoElementoUI));
            NombreTB = new TextBox();
            DescripcionTB = new TextBox();
            TipoCB = new ComboBox();
            AceptarB = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // NombreTB
            // 
            NombreTB.Location = new Point(68, 34);
            NombreTB.Name = "NombreTB";
            NombreTB.PlaceholderText = "Nombre";
            NombreTB.Size = new Size(166, 23);
            NombreTB.TabIndex = 0;
            NombreTB.Validating += NombreTB_Validating;
            NombreTB.Validated += NombreTB_Validated;
            // 
            // DescripcionTB
            // 
            DescripcionTB.Location = new Point(68, 63);
            DescripcionTB.Name = "DescripcionTB";
            DescripcionTB.PlaceholderText = "Descripcion";
            DescripcionTB.Size = new Size(166, 23);
            DescripcionTB.TabIndex = 1;
            DescripcionTB.Validating += DescripcionTB_Validating;
            DescripcionTB.Validated += DescripcionTB_Validated;
            // 
            // TipoCB
            // 
            TipoCB.FormattingEnabled = true;
            TipoCB.Location = new Point(68, 92);
            TipoCB.Name = "TipoCB";
            TipoCB.Size = new Size(166, 23);
            TipoCB.TabIndex = 2;
            // 
            // AceptarB
            // 
            AceptarB.Location = new Point(173, 160);
            AceptarB.Name = "AceptarB";
            AceptarB.Size = new Size(75, 23);
            AceptarB.TabIndex = 3;
            AceptarB.Text = "Aceptar";
            AceptarB.UseVisualStyleBackColor = true;
            AceptarB.Click += AceptarB_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // NuevoElementoUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(297, 204);
            Controls.Add(AceptarB);
            Controls.Add(TipoCB);
            Controls.Add(DescripcionTB);
            Controls.Add(NombreTB);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "NuevoElementoUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NuevoElemento";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NombreTB;
        private TextBox DescripcionTB;
        private ComboBox TipoCB;
        private Button AceptarB;
        private ErrorProvider errorProvider1;
    }
}