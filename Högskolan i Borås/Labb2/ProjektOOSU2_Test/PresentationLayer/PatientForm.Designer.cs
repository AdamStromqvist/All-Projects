namespace ProjektOOSU2_Test.PresentationLayer
{
    partial class PatientForm
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
            listBoxPatients = new ListBox();
            listBoxPatientInformation = new ListBox();
            buttonDeletePatient = new Button();
            textBoxPatientName = new TextBox();
            textBoxSocialSecurityNr = new TextBox();
            textBoxAdress = new TextBox();
            textBoxPhoneNr = new TextBox();
            textBoxEmailAdress = new TextBox();
            buttonAddPatient = new Button();
            buttonUpdatePatient = new Button();
            labelPatientName = new Label();
            labelSocialSecurityNr = new Label();
            labelPatientAdress = new Label();
            labelPatientPhoneNr = new Label();
            labelPatientEmailAdress = new Label();
            labelPatientServiceHeading = new Label();
            SuspendLayout();
            // 
            // listBoxPatients
            // 
            listBoxPatients.FormattingEnabled = true;
            listBoxPatients.ItemHeight = 15;
            listBoxPatients.Location = new Point(12, 12);
            listBoxPatients.Name = "listBoxPatients";
            listBoxPatients.Size = new Size(210, 514);
            listBoxPatients.TabIndex = 0;
            listBoxPatients.SelectedIndexChanged += listBoxPatients_SelectedIndexChanged;
            // 
            // listBoxPatientInformation
            // 
            listBoxPatientInformation.FormattingEnabled = true;
            listBoxPatientInformation.ItemHeight = 15;
            listBoxPatientInformation.Location = new Point(562, 12);
            listBoxPatientInformation.Name = "listBoxPatientInformation";
            listBoxPatientInformation.Size = new Size(226, 514);
            listBoxPatientInformation.TabIndex = 1;
            listBoxPatientInformation.SelectedIndexChanged += listBoxPatientInformation_SelectedIndexChanged;
            // 
            // buttonDeletePatient
            // 
            buttonDeletePatient.Location = new Point(324, 479);
            buttonDeletePatient.Name = "buttonDeletePatient";
            buttonDeletePatient.Size = new Size(138, 44);
            buttonDeletePatient.TabIndex = 3;
            buttonDeletePatient.Text = "Delete Patient";
            buttonDeletePatient.UseVisualStyleBackColor = true;
            buttonDeletePatient.Click += buttonDeletePatient_Click;
            // 
            // textBoxPatientName
            // 
            textBoxPatientName.Location = new Point(323, 113);
            textBoxPatientName.Name = "textBoxPatientName";
            textBoxPatientName.Size = new Size(138, 23);
            textBoxPatientName.TabIndex = 4;
            textBoxPatientName.TextChanged += textBoxPatientName_TextChanged;
            // 
            // textBoxSocialSecurityNr
            // 
            textBoxSocialSecurityNr.Location = new Point(323, 157);
            textBoxSocialSecurityNr.Name = "textBoxSocialSecurityNr";
            textBoxSocialSecurityNr.Size = new Size(138, 23);
            textBoxSocialSecurityNr.TabIndex = 5;
            // 
            // textBoxAdress
            // 
            textBoxAdress.Location = new Point(323, 207);
            textBoxAdress.Name = "textBoxAdress";
            textBoxAdress.Size = new Size(138, 23);
            textBoxAdress.TabIndex = 6;
            textBoxAdress.TextChanged += textBoxAdress_TextChanged;
            // 
            // textBoxPhoneNr
            // 
            textBoxPhoneNr.Location = new Point(323, 253);
            textBoxPhoneNr.Name = "textBoxPhoneNr";
            textBoxPhoneNr.Size = new Size(138, 23);
            textBoxPhoneNr.TabIndex = 7;
            // 
            // textBoxEmailAdress
            // 
            textBoxEmailAdress.Location = new Point(324, 302);
            textBoxEmailAdress.Name = "textBoxEmailAdress";
            textBoxEmailAdress.Size = new Size(138, 23);
            textBoxEmailAdress.TabIndex = 8;
            // 
            // buttonAddPatient
            // 
            buttonAddPatient.Location = new Point(324, 343);
            buttonAddPatient.Name = "buttonAddPatient";
            buttonAddPatient.Size = new Size(138, 48);
            buttonAddPatient.TabIndex = 9;
            buttonAddPatient.Text = "Add Patient";
            buttonAddPatient.UseVisualStyleBackColor = true;
            buttonAddPatient.Click += buttonAddPatient_Click;
            // 
            // buttonUpdatePatient
            // 
            buttonUpdatePatient.Location = new Point(324, 413);
            buttonUpdatePatient.Name = "buttonUpdatePatient";
            buttonUpdatePatient.Size = new Size(138, 43);
            buttonUpdatePatient.TabIndex = 10;
            buttonUpdatePatient.Text = "Update Patient";
            buttonUpdatePatient.UseVisualStyleBackColor = true;
            buttonUpdatePatient.Click += buttonUpdatePatient_Click;
            // 
            // labelPatientName
            // 
            labelPatientName.AutoSize = true;
            labelPatientName.Location = new Point(323, 95);
            labelPatientName.Name = "labelPatientName";
            labelPatientName.Size = new Size(39, 15);
            labelPatientName.TabIndex = 11;
            labelPatientName.Text = "Name";
            // 
            // labelSocialSecurityNr
            // 
            labelSocialSecurityNr.AutoSize = true;
            labelSocialSecurityNr.Location = new Point(323, 139);
            labelSocialSecurityNr.Name = "labelSocialSecurityNr";
            labelSocialSecurityNr.Size = new Size(99, 15);
            labelSocialSecurityNr.TabIndex = 12;
            labelSocialSecurityNr.Text = "Social Security Nr";
            // 
            // labelPatientAdress
            // 
            labelPatientAdress.AutoSize = true;
            labelPatientAdress.Location = new Point(323, 189);
            labelPatientAdress.Name = "labelPatientAdress";
            labelPatientAdress.Size = new Size(42, 15);
            labelPatientAdress.TabIndex = 13;
            labelPatientAdress.Text = "Adress";
            // 
            // labelPatientPhoneNr
            // 
            labelPatientPhoneNr.AutoSize = true;
            labelPatientPhoneNr.Location = new Point(324, 235);
            labelPatientPhoneNr.Name = "labelPatientPhoneNr";
            labelPatientPhoneNr.Size = new Size(57, 15);
            labelPatientPhoneNr.TabIndex = 14;
            labelPatientPhoneNr.Text = "Phone Nr";
            // 
            // labelPatientEmailAdress
            // 
            labelPatientEmailAdress.AutoSize = true;
            labelPatientEmailAdress.Location = new Point(323, 282);
            labelPatientEmailAdress.Name = "labelPatientEmailAdress";
            labelPatientEmailAdress.Size = new Size(36, 15);
            labelPatientEmailAdress.TabIndex = 15;
            labelPatientEmailAdress.Text = "Email";
            // 
            // labelPatientServiceHeading
            // 
            labelPatientServiceHeading.AutoSize = true;
            labelPatientServiceHeading.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPatientServiceHeading.Location = new Point(308, 41);
            labelPatientServiceHeading.Name = "labelPatientServiceHeading";
            labelPatientServiceHeading.Size = new Size(170, 32);
            labelPatientServiceHeading.TabIndex = 16;
            labelPatientServiceHeading.Text = "Patient Service";
            // 
            // PatientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 601);
            Controls.Add(labelPatientServiceHeading);
            Controls.Add(labelPatientEmailAdress);
            Controls.Add(labelPatientPhoneNr);
            Controls.Add(labelPatientAdress);
            Controls.Add(labelSocialSecurityNr);
            Controls.Add(labelPatientName);
            Controls.Add(buttonUpdatePatient);
            Controls.Add(buttonAddPatient);
            Controls.Add(textBoxEmailAdress);
            Controls.Add(textBoxPhoneNr);
            Controls.Add(textBoxAdress);
            Controls.Add(textBoxSocialSecurityNr);
            Controls.Add(textBoxPatientName);
            Controls.Add(buttonDeletePatient);
            Controls.Add(listBoxPatientInformation);
            Controls.Add(listBoxPatients);
            Name = "PatientForm";
            Text = "PatientForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxPatients;
        private ListBox listBoxPatientInformation;
        private Button buttonDeletePatient;
        private TextBox textBoxPatientName;
        private TextBox textBoxSocialSecurityNr;
        private TextBox textBoxAdress;
        private TextBox textBoxPhoneNr;
        private TextBox textBoxEmailAdress;
        private Button buttonAddPatient;
        private Button buttonUpdatePatient;
        private Label labelPatientName;
        private Label labelSocialSecurityNr;
        private Label labelPatientAdress;
        private Label labelPatientPhoneNr;
        private Label labelPatientEmailAdress;
        private Label labelPatientServiceHeading;
    }
}