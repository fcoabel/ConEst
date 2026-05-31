namespace ConEst.UI
{
    partial class NuevoUsuarioUI
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
            NombreTB = new TextBox();
            ContraseñaTB = new TextBox();
            RolCB = new ComboBox();
            AceptarB = new Button();
            CancelarB = new Button();
            ConfirmarConTB = new TextBox();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // NombreTB
            // 
            NombreTB.Location = new Point(55, 33);
            NombreTB.Name = "NombreTB";
            NombreTB.PlaceholderText = "Nombre";
            NombreTB.Size = new Size(154, 23);
            NombreTB.TabIndex = 0;
            NombreTB.Validating += NombreTB_Validating;
            NombreTB.Validated += NombreTB_Validated;
            // 
            // ContraseñaTB
            // 
            ContraseñaTB.Location = new Point(55, 62);
            ContraseñaTB.Name = "ContraseñaTB";
            ContraseñaTB.PlaceholderText = "Contraseña";
            ContraseñaTB.Size = new Size(154, 23);
            ContraseñaTB.TabIndex = 1;
            ContraseñaTB.UseSystemPasswordChar = true;
            ContraseñaTB.Validating += ContraseñaTB_Validating;
            ContraseñaTB.Validated += ContraseñaTB_Validated;
            // 
            // RolCB
            // 
            RolCB.FormattingEnabled = true;
            RolCB.Location = new Point(55, 122);
            RolCB.Name = "RolCB";
            RolCB.Size = new Size(154, 23);
            RolCB.TabIndex = 3;
            RolCB.Text = "Administrador";
            
            // 
            // AceptarB
            // 
            AceptarB.BackColor = Color.FromArgb(192, 255, 192);
            AceptarB.Location = new Point(166, 184);
            AceptarB.Name = "AceptarB";
            AceptarB.Size = new Size(75, 23);
            AceptarB.TabIndex = 4;
            AceptarB.Text = "Aceptar";
            AceptarB.UseVisualStyleBackColor = false;
            AceptarB.Click += AceptarB_Click;
            // 
            // CancelarB
            // 
            CancelarB.BackColor = Color.FromArgb(255, 192, 192);
            CancelarB.Location = new Point(33, 184);
            CancelarB.Name = "CancelarB";
            CancelarB.Size = new Size(75, 23);
            CancelarB.TabIndex = 5;
            CancelarB.Text = "Cancelar";
            CancelarB.UseVisualStyleBackColor = false;
            CancelarB.Click += CancelarB_Click;
            // 
            // ConfirmarConTB
            // 
            ConfirmarConTB.Location = new Point(55, 91);
            ConfirmarConTB.Name = "ConfirmarConTB";
            ConfirmarConTB.PlaceholderText = "Confirmar Contraseña";
            ConfirmarConTB.Size = new Size(154, 23);
            ConfirmarConTB.TabIndex = 2;
            ConfirmarConTB.UseSystemPasswordChar = true;
            ConfirmarConTB.Validating += ConfirmarConTB_Validating;
            ConfirmarConTB.Validated += ConfirmarConTB_Validated;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // NuevoUsuarioUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(274, 232);
            Controls.Add(ConfirmarConTB);
            Controls.Add(CancelarB);
            Controls.Add(AceptarB);
            Controls.Add(RolCB);
            Controls.Add(ContraseñaTB);
            Controls.Add(NombreTB);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NuevoUsuarioUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NuevoUsuario";
            Shown += NuevoUsuarioUI_Shown;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NombreTB;
        private TextBox ContraseñaTB;
        private ComboBox RolCB;
        private Button AceptarB;
        private Button CancelarB;
        private TextBox ConfirmarConTB;
        private ErrorProvider errorProvider;
    }
}