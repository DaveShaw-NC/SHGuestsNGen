/*
 * Created by SharpDevelop.
 * User: DaveShaw
 * Date: 9/3/2014
 * Time: 12:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace NewNextGenGuestsProcess
{
	partial class current_guest_display
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.dob_datepicker = new System.Windows.Forms.DateTimePicker();
            this.last_name_box = new System.Windows.Forms.TextBox();
            this.first_name_box = new System.Windows.Forms.TextBox();
            this.ssn_id_no_box = new System.Windows.Forms.TextBox();
            this.admit_datepicker = new System.Windows.Forms.DateTimePicker();
            this.admit_reason_box = new System.Windows.Forms.TextBox();
            this.referring_hospital_box = new System.Windows.Forms.TextBox();
            this.visit_num_box = new System.Windows.Forms.TextBox();
            this.exit_display_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.days_here_label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.discharge_guest_button = new System.Windows.Forms.Button();
            this.update_guest_button = new System.Windows.Forms.Button();
            this.gender_box = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.room_num_box = new System.Windows.Forms.TextBox();
            this.bed_num_box = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.calc_dischg_date = new System.Windows.Forms.Label();
            this.days_over_stay = new System.Windows.Forms.Label();
            this.referring_social_worker = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.modified_box = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.guest_personals = new System.Windows.Forms.Label();
            this.guest_admit_info = new System.Windows.Forms.Label();
            this.guest_discharge_info = new System.Windows.Forms.Label();
            this.sugg_dischargeLabel = new System.Windows.Forms.Label();
            this.textBox_GiD = new System.Windows.Forms.TextBox();
            this.textBox_ViD = new System.Windows.Forms.TextBox();
            this.label_GiD = new System.Windows.Forms.Label();
            this.label_ViD = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dob_datepicker
            // 
            this.dob_datepicker.CustomFormat = "MM-dd-yyyy";
            this.dob_datepicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dob_datepicker.Location = new System.Drawing.Point(39, 89);
            this.dob_datepicker.Name = "dob_datepicker";
            this.dob_datepicker.Size = new System.Drawing.Size(200, 26);
            this.dob_datepicker.TabIndex = 0;
            // 
            // last_name_box
            // 
            this.last_name_box.Location = new System.Drawing.Point(39, 159);
            this.last_name_box.Name = "last_name_box";
            this.last_name_box.Size = new System.Drawing.Size(210, 26);
            this.last_name_box.TabIndex = 1;
            // 
            // first_name_box
            // 
            this.first_name_box.Location = new System.Drawing.Point(39, 224);
            this.first_name_box.Name = "first_name_box";
            this.first_name_box.Size = new System.Drawing.Size(210, 26);
            this.first_name_box.TabIndex = 2;
            // 
            // ssn_id_no_box
            // 
            this.ssn_id_no_box.Location = new System.Drawing.Point(102, 287);
            this.ssn_id_no_box.Name = "ssn_id_no_box";
            this.ssn_id_no_box.Size = new System.Drawing.Size(147, 26);
            this.ssn_id_no_box.TabIndex = 4;
            // 
            // admit_datepicker
            // 
            this.admit_datepicker.CustomFormat = "MM-dd-yyyy";
            this.admit_datepicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.admit_datepicker.Location = new System.Drawing.Point(313, 89);
            this.admit_datepicker.Name = "admit_datepicker";
            this.admit_datepicker.Size = new System.Drawing.Size(200, 26);
            this.admit_datepicker.TabIndex = 5;
            // 
            // admit_reason_box
            // 
            this.admit_reason_box.Location = new System.Drawing.Point(309, 159);
            this.admit_reason_box.Multiline = true;
            this.admit_reason_box.Name = "admit_reason_box";
            this.admit_reason_box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.admit_reason_box.Size = new System.Drawing.Size(259, 26);
            this.admit_reason_box.TabIndex = 6;
            // 
            // referring_hospital_box
            // 
            this.referring_hospital_box.Location = new System.Drawing.Point(309, 224);
            this.referring_hospital_box.Name = "referring_hospital_box";
            this.referring_hospital_box.Size = new System.Drawing.Size(259, 26);
            this.referring_hospital_box.TabIndex = 7;
            // 
            // visit_num_box
            // 
            this.visit_num_box.Location = new System.Drawing.Point(312, 323);
            this.visit_num_box.Name = "visit_num_box";
            this.visit_num_box.Size = new System.Drawing.Size(33, 26);
            this.visit_num_box.TabIndex = 9;
            // 
            // exit_display_button
            // 
            this.exit_display_button.Location = new System.Drawing.Point(701, 416);
            this.exit_display_button.Name = "exit_display_button";
            this.exit_display_button.Size = new System.Drawing.Size(172, 41);
            this.exit_display_button.TabIndex = 14;
            this.exit_display_button.Text = "Exit";
            this.exit_display_button.UseVisualStyleBackColor = true;
            this.exit_display_button.Click += new System.EventHandler(this.Exit_display_buttonClick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(39, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "Date of Birth";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(41, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 23);
            this.label2.TabIndex = 16;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(35, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 23);
            this.label3.TabIndex = 17;
            this.label3.Text = "First Name";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(98, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 23);
            this.label4.TabIndex = 19;
            this.label4.Text = "SSN/W7";
            // 
            // days_here_label
            // 
            this.days_here_label.Location = new System.Drawing.Point(628, 111);
            this.days_here_label.Name = "days_here_label";
            this.days_here_label.Size = new System.Drawing.Size(275, 23);
            this.days_here_label.TabIndex = 25;
            this.days_here_label.Text = "x3";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(309, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 23);
            this.label5.TabIndex = 20;
            this.label5.Text = "Admission Date";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(309, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(290, 23);
            this.label6.TabIndex = 23;
            this.label6.Text = "Admission Reason";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(305, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "Referring Hospital";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(310, 352);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 23);
            this.label8.TabIndex = 26;
            this.label8.Text = "Visit";
            // 
            // discharge_guest_button
            // 
            this.discharge_guest_button.Location = new System.Drawing.Point(369, 416);
            this.discharge_guest_button.Name = "discharge_guest_button";
            this.discharge_guest_button.Size = new System.Drawing.Size(172, 41);
            this.discharge_guest_button.TabIndex = 13;
            this.discharge_guest_button.Text = "Discharge This Guest";
            this.discharge_guest_button.UseVisualStyleBackColor = true;
            this.discharge_guest_button.Click += new System.EventHandler(this.Discharge_guest_buttonClick);
            // 
            // update_guest_button
            // 
            this.update_guest_button.Location = new System.Drawing.Point(37, 416);
            this.update_guest_button.Name = "update_guest_button";
            this.update_guest_button.Size = new System.Drawing.Size(172, 41);
            this.update_guest_button.TabIndex = 12;
            this.update_guest_button.Text = "Change/Update Guest";
            this.update_guest_button.UseVisualStyleBackColor = true;
            this.update_guest_button.Click += new System.EventHandler(this.Update_guest_buttonClick);
            // 
            // gender_box
            // 
            this.gender_box.Location = new System.Drawing.Point(36, 287);
            this.gender_box.Name = "gender_box";
            this.gender_box.Size = new System.Drawing.Size(36, 26);
            this.gender_box.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(28, 262);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 23);
            this.label9.TabIndex = 18;
            this.label9.Text = "Gender";
            // 
            // room_num_box
            // 
            this.room_num_box.Location = new System.Drawing.Point(403, 323);
            this.room_num_box.Name = "room_num_box";
            this.room_num_box.Size = new System.Drawing.Size(31, 26);
            this.room_num_box.TabIndex = 10;
            // 
            // bed_num_box
            // 
            this.bed_num_box.Location = new System.Drawing.Point(480, 323);
            this.bed_num_box.Name = "bed_num_box";
            this.bed_num_box.Size = new System.Drawing.Size(30, 26);
            this.bed_num_box.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(400, 352);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 23);
            this.label10.TabIndex = 27;
            this.label10.Text = "Room";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(477, 352);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 23);
            this.label11.TabIndex = 28;
            this.label11.Text = "Bed";
            // 
            // calc_dischg_date
            // 
            this.calc_dischg_date.Location = new System.Drawing.Point(628, 63);
            this.calc_dischg_date.Name = "calc_dischg_date";
            this.calc_dischg_date.Size = new System.Drawing.Size(275, 23);
            this.calc_dischg_date.TabIndex = 21;
            this.calc_dischg_date.Text = "x1";
            // 
            // days_over_stay
            // 
            this.days_over_stay.Location = new System.Drawing.Point(628, 135);
            this.days_over_stay.Name = "days_over_stay";
            this.days_over_stay.Size = new System.Drawing.Size(275, 23);
            this.days_over_stay.TabIndex = 22;
            this.days_over_stay.Text = "x2";
            // 
            // referring_social_worker
            // 
            this.referring_social_worker.Location = new System.Drawing.Point(309, 291);
            this.referring_social_worker.Name = "referring_social_worker";
            this.referring_social_worker.Size = new System.Drawing.Size(259, 26);
            this.referring_social_worker.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(305, 262);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(188, 20);
            this.label12.TabIndex = 25;
            this.label12.Text = "Referring Social Worker";
            // 
            // modified_box
            // 
            this.modified_box.Location = new System.Drawing.Point(632, 291);
            this.modified_box.Name = "modified_box";
            this.modified_box.Size = new System.Drawing.Size(210, 26);
            this.modified_box.TabIndex = 31;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(628, 265);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(158, 20);
            this.label14.TabIndex = 32;
            this.label14.Text = "Record Last Editted";
            // 
            // guest_personals
            // 
            this.guest_personals.AutoSize = true;
            this.guest_personals.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guest_personals.Location = new System.Drawing.Point(34, 28);
            this.guest_personals.Name = "guest_personals";
            this.guest_personals.Size = new System.Drawing.Size(247, 25);
            this.guest_personals.TabIndex = 33;
            this.guest_personals.Text = "Guest Personal Information";
            // 
            // guest_admit_info
            // 
            this.guest_admit_info.AutoSize = true;
            this.guest_admit_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guest_admit_info.Location = new System.Drawing.Point(307, 28);
            this.guest_admit_info.Name = "guest_admit_info";
            this.guest_admit_info.Size = new System.Drawing.Size(261, 25);
            this.guest_admit_info.TabIndex = 34;
            this.guest_admit_info.Text = "Guest Admission Information";
            // 
            // guest_discharge_info
            // 
            this.guest_discharge_info.AutoSize = true;
            this.guest_discharge_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guest_discharge_info.Location = new System.Drawing.Point(631, 28);
            this.guest_discharge_info.Name = "guest_discharge_info";
            this.guest_discharge_info.Size = new System.Drawing.Size(258, 25);
            this.guest_discharge_info.TabIndex = 35;
            this.guest_discharge_info.Text = "Guest Discharge Information";
            // 
            // sugg_dischargeLabel
            // 
            this.sugg_dischargeLabel.Location = new System.Drawing.Point(628, 87);
            this.sugg_dischargeLabel.Name = "sugg_dischargeLabel";
            this.sugg_dischargeLabel.Size = new System.Drawing.Size(275, 23);
            this.sugg_dischargeLabel.TabIndex = 36;
            this.sugg_dischargeLabel.Text = "x1";
            // 
            // textBox_GiD
            // 
            this.textBox_GiD.Location = new System.Drawing.Point(32, 323);
            this.textBox_GiD.Name = "textBox_GiD";
            this.textBox_GiD.ReadOnly = true;
            this.textBox_GiD.Size = new System.Drawing.Size(78, 26);
            this.textBox_GiD.TabIndex = 37;
            this.textBox_GiD.TabStop = false;
            this.textBox_GiD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_ViD
            // 
            this.textBox_ViD.Location = new System.Drawing.Point(171, 323);
            this.textBox_ViD.Name = "textBox_ViD";
            this.textBox_ViD.ReadOnly = true;
            this.textBox_ViD.Size = new System.Drawing.Size(78, 26);
            this.textBox_ViD.TabIndex = 38;
            this.textBox_ViD.TabStop = false;
            this.textBox_ViD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_GiD
            // 
            this.label_GiD.AutoSize = true;
            this.label_GiD.Location = new System.Drawing.Point(28, 367);
            this.label_GiD.Name = "label_GiD";
            this.label_GiD.Size = new System.Drawing.Size(85, 20);
            this.label_GiD.TabIndex = 39;
            this.label_GiD.Text = "Guest ID#";
            // 
            // label_ViD
            // 
            this.label_ViD.AutoSize = true;
            this.label_ViD.Location = new System.Drawing.Point(167, 367);
            this.label_ViD.Name = "label_ViD";
            this.label_ViD.Size = new System.Drawing.Size(73, 20);
            this.label_ViD.TabIndex = 40;
            this.label_ViD.Text = "Visit ID#";
            // 
            // current_guest_display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 492);
            this.Controls.Add(this.label_ViD);
            this.Controls.Add(this.label_GiD);
            this.Controls.Add(this.textBox_ViD);
            this.Controls.Add(this.textBox_GiD);
            this.Controls.Add(this.sugg_dischargeLabel);
            this.Controls.Add(this.guest_discharge_info);
            this.Controls.Add(this.guest_admit_info);
            this.Controls.Add(this.guest_personals);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.modified_box);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.referring_social_worker);
            this.Controls.Add(this.days_over_stay);
            this.Controls.Add(this.calc_dischg_date);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.bed_num_box);
            this.Controls.Add(this.room_num_box);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.gender_box);
            this.Controls.Add(this.update_guest_button);
            this.Controls.Add(this.discharge_guest_button);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.days_here_label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exit_display_button);
            this.Controls.Add(this.visit_num_box);
            this.Controls.Add(this.referring_hospital_box);
            this.Controls.Add(this.admit_reason_box);
            this.Controls.Add(this.admit_datepicker);
            this.Controls.Add(this.ssn_id_no_box);
            this.Controls.Add(this.first_name_box);
            this.Controls.Add(this.last_name_box);
            this.Controls.Add(this.dob_datepicker);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "current_guest_display";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Current Guest Information";
            this.Load += new System.EventHandler(this.Current_guest_displayLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox gender_box;
		private System.Windows.Forms.Button update_guest_button;
		private System.Windows.Forms.Button discharge_guest_button;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label days_here_label;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button exit_display_button;
		private System.Windows.Forms.TextBox visit_num_box;
		private System.Windows.Forms.TextBox referring_hospital_box;
		private System.Windows.Forms.TextBox admit_reason_box;
		private System.Windows.Forms.DateTimePicker admit_datepicker;
		private System.Windows.Forms.TextBox ssn_id_no_box;
		private System.Windows.Forms.TextBox first_name_box;
		private System.Windows.Forms.TextBox last_name_box;
		private System.Windows.Forms.DateTimePicker dob_datepicker;
		private System.Windows.Forms.TextBox room_num_box;
		private System.Windows.Forms.TextBox bed_num_box;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label calc_dischg_date;
		private System.Windows.Forms.Label days_over_stay;
        private System.Windows.Forms.TextBox referring_social_worker;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox modified_box;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label guest_personals;
        private System.Windows.Forms.Label guest_admit_info;
        private System.Windows.Forms.Label guest_discharge_info;
        private System.Windows.Forms.Label sugg_dischargeLabel;
        private System.Windows.Forms.TextBox textBox_GiD;
        private System.Windows.Forms.TextBox textBox_ViD;
        private System.Windows.Forms.Label label_GiD;
        private System.Windows.Forms.Label label_ViD;
    }
}
