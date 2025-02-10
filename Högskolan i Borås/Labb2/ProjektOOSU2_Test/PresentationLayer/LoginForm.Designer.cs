namespace ProjektOOSU2_Test.PresentationLayer
{
    partial class LoginForm
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
            buttonSignIn = new Button();
            textBoxPassword = new TextBox();
            textBoxUsername = new TextBox();
            labelHeading = new Label();
            labelUsername = new Label();
            labelPassword = new Label();
            SuspendLayout();
            // 
            // buttonSignIn
            // 
            buttonSignIn.Location = new Point(309, 345);
            buttonSignIn.Name = "buttonSignIn";
            buttonSignIn.Size = new Size(161, 23);
            buttonSignIn.TabIndex = 0;
            buttonSignIn.Text = "Sign in";
            buttonSignIn.UseVisualStyleBackColor = true;
            buttonSignIn.Click += buttonSignIn_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(309, 298);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(161, 23);
            textBoxPassword.TabIndex = 1;
            textBoxPassword.TextChanged += textBoxPassword_TextChanged;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(309, 255);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(161, 23);
            textBoxUsername.TabIndex = 2;
            textBoxUsername.TextChanged += textBoxUsername_TextChanged;
            // 
            // labelHeading
            // 
            labelHeading.AutoSize = true;
            labelHeading.Font = new Font("Segoe UI Symbol", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelHeading.Location = new Point(141, 111);
            labelHeading.Name = "labelHeading";
            labelHeading.Size = new Size(501, 47);
            labelHeading.TabIndex = 3;
            labelHeading.Text = "Welcome to PatientApplication";
            
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(234, 258);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(60, 15);
            labelUsername.TabIndex = 4;
            labelUsername.Text = "Username";
            
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(234, 301);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(57, 15);
            labelPassword.TabIndex = 5;
            labelPassword.Text = "Password";
            
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelPassword);
            Controls.Add(labelUsername);
            Controls.Add(labelHeading);
            Controls.Add(textBoxUsername);
            Controls.Add(textBoxPassword);
            Controls.Add(buttonSignIn);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSignIn;
        private TextBox textBoxPassword;
        private TextBox textBoxUsername;
        private Label labelHeading;
        private Label labelUsername;
        private Label labelPassword;
    }
}