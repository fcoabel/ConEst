namespace ConEst.UI
{
    partial class SesionUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SesionUI));
            UsuarioTB = new TextBox();
            ContraseñaTB = new TextBox();
            AceptarB = new Button();
            CancelarB = new Button();
            errorProvider1 = new ErrorProvider(components);
            MensajeL = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // UsuarioTB
            // 
            UsuarioTB.Location = new Point(22, 12);
            UsuarioTB.Name = "UsuarioTB";
            UsuarioTB.PlaceholderText = "Usuario";
            UsuarioTB.Size = new Size(158, 23);
            UsuarioTB.TabIndex = 0;
            UsuarioTB.Validating += UsuarioTB_Validating;
            UsuarioTB.Validated += UsuarioTB_Validated;
            // 
            // ContraseñaTB
            // 
            ContraseñaTB.Location = new Point(22, 41);
            ContraseñaTB.Name = "ContraseñaTB";
            ContraseñaTB.PlaceholderText = "Contraseña";
            ContraseñaTB.Size = new Size(158, 23);
            ContraseñaTB.TabIndex = 1;
            ContraseñaTB.UseSystemPasswordChar = true;
            ContraseñaTB.Validating += ContraseñaTB_Validating;
            ContraseñaTB.Validated += ContraseñaTB_Validated;
            // 
            // AceptarB
            // 
            AceptarB.BackColor = Color.FromArgb(192, 255, 192);
            AceptarB.Location = new Point(122, 108);
            AceptarB.Name = "AceptarB";
            AceptarB.Size = new Size(75, 23);
            AceptarB.TabIndex = 2;
            AceptarB.Text = "Aceptar";
            AceptarB.UseVisualStyleBackColor = false;
            AceptarB.Click += AceptarB_Click;
            // 
            // CancelarB
            // 
            CancelarB.BackColor = Color.FromArgb(255, 192, 192);
            CancelarB.CausesValidation = false;
            CancelarB.Location = new Point(203, 108);
            CancelarB.Name = "CancelarB";
            CancelarB.Size = new Size(75, 23);
            CancelarB.TabIndex = 3;
            CancelarB.Text = "Cancelar";
            CancelarB.UseVisualStyleBackColor = false;
            CancelarB.Click += CancelarB_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // MensajeL
            // 
            MensajeL.AutoSize = true;
            MensajeL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            MensajeL.Location = new Point(22, 81);
            MensajeL.Name = "MensajeL";
            MensajeL.Size = new Size(0, 15);
            MensajeL.TabIndex = 4;
            // 
            // SesionUI
            // 
            AcceptButton = AceptarB;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelarB;
            ClientSize = new Size(290, 143);
            Controls.Add(MensajeL);
            Controls.Add(CancelarB);
            Controls.Add(AceptarB);
            Controls.Add(ContraseñaTB);
            Controls.Add(UsuarioTB);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "SesionUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sesion";
            Shown += SesionUI_Shown;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UsuarioTB;
        private TextBox ContraseñaTB;
        private Button AceptarB;
        private Button CancelarB;
        private ErrorProvider errorProvider1;
        private Label MensajeL;
    }
}