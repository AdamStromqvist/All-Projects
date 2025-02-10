namespace ProjektOOSU2_Test.PresentationLayer
{
    partial class MainForm
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
            labelHeading = new Label();
            buttonViewAll = new Button();
            buttonPatientService = new Button();
            buttonDoctorAppointmentService = new Button();
            buttonDiagnosisService = new Button();
            buttonMedicinePrescriptionService = new Button();
            buttonExit = new Button();
            SuspendLayout();
            // 
            // labelHeading
            // 
            labelHeading.AutoSize = true;
            labelHeading.Font = new Font("Segoe UI Historic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelHeading.Location = new Point(314, 59);
            labelHeading.Name = "labelHeading";
            labelHeading.Size = new Size(137, 32);
            labelHeading.TabIndex = 0;
            labelHeading.Text = "Main menu";
            labelHeading.Click += labelHeading_Click;
            // 
            // buttonViewAll
            // 
            buttonViewAll.Location = new Point(314, 115);
            buttonViewAll.Name = "buttonViewAll";
            buttonViewAll.Size = new Size(137, 47);
            buttonViewAll.TabIndex = 1;
            buttonViewAll.Text = "View All";
            buttonViewAll.UseVisualStyleBackColor = true;
            buttonViewAll.Click += buttonViewAll_Click;
            // 
            // buttonPatientService
            // 
            buttonPatientService.Location = new Point(314, 178);
            buttonPatientService.Name = "buttonPatientService";
            buttonPatientService.Size = new Size(137, 51);
            buttonPatientService.TabIndex = 2;
            buttonPatientService.Text = "Patient Service";
            buttonPatientService.UseVisualStyleBackColor = true;
            buttonPatientService.Click += buttonPatientService_Click;
            // 
            // buttonDoctorAppointmentService
            // 
            buttonDoctorAppointmentService.Location = new Point(314, 246);
            buttonDoctorAppointmentService.Name = "buttonDoctorAppointmentService";
            buttonDoctorAppointmentService.Size = new Size(137, 46);
            buttonDoctorAppointmentService.TabIndex = 3;
            buttonDoctorAppointmentService.Text = "Doctor Appointment Service";
            buttonDoctorAppointmentService.UseVisualStyleBackColor = true;
            buttonDoctorAppointmentService.Click += buttonDoctorAppointmentService_Click;
            // 
            // buttonDiagnosisService
            // 
            buttonDiagnosisService.Location = new Point(314, 309);
            buttonDiagnosisService.Name = "buttonDiagnosisService";
            buttonDiagnosisService.Size = new Size(137, 49);
            buttonDiagnosisService.TabIndex = 4;
            buttonDiagnosisService.Text = "Diagnosis Service";
            buttonDiagnosisService.UseVisualStyleBackColor = true;
            buttonDiagnosisService.Click += buttonDiagnosisService_Click;
            // 
            // buttonMedicinePrescriptionService
            // 
            buttonMedicinePrescriptionService.Location = new Point(314, 377);
            buttonMedicinePrescriptionService.Name = "buttonMedicinePrescriptionService";
            buttonMedicinePrescriptionService.Size = new Size(137, 48);
            buttonMedicinePrescriptionService.TabIndex = 5;
            buttonMedicinePrescriptionService.Text = "Medicine Prescription Service";
            buttonMedicinePrescriptionService.UseVisualStyleBackColor = true;
            buttonMedicinePrescriptionService.Click += buttonMedicinePrescriptionService_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(314, 443);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(137, 46);
            buttonExit.TabIndex = 6;
            buttonExit.Text = "Exit";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += buttonExit_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(781, 567);
            Controls.Add(buttonExit);
            Controls.Add(buttonMedicinePrescriptionService);
            Controls.Add(buttonDiagnosisService);
            Controls.Add(buttonDoctorAppointmentService);
            Controls.Add(buttonPatientService);
            Controls.Add(buttonViewAll);
            Controls.Add(labelHeading);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelHeading;
        private Button buttonViewAll;
        private Button buttonPatientService;
        private Button buttonDoctorAppointmentService;
        private Button buttonDiagnosisService;
        private Button buttonMedicinePrescriptionService;
        private Button buttonExit;
    }
}