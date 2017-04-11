﻿/*
 * Created by SharpDevelop.
 * User: DaveShaw
 * Date: 8/21/2014
 * Time: 12:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace NewNextGenGuestsProcess
{
	partial class SHGuestDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SHGuestDisplay));
            this.last_name = new System.Windows.Forms.TextBox();
            this.first_name = new System.Windows.Forms.TextBox();
            this.num_visits_textbox = new System.Windows.Forms.TextBox();
            this.last_name_label = new System.Windows.Forms.Label();
            this.first_name_label = new System.Windows.Forms.Label();
            this.dob_label = new System.Windows.Forms.Label();
            this.num_visits_label = new System.Windows.Forms.Label();
            this.exit_the_screen = new System.Windows.Forms.Button();
            this.return_denial_reason = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.delete_guest_button = new System.Windows.Forms.Button();
            this.can_return_checkbox = new System.Windows.Forms.CheckBox();
            this.dob_dt_picker = new System.Windows.Forms.DateTimePicker();
            this.last_time_discharged = new System.Windows.Forms.DateTimePicker();
            this.update_guest_button = new System.Windows.Forms.Button();
            this.deceased_checkbox = new System.Windows.Forms.CheckBox();
            this.ssn_id_no_box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.admit_reason_box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.admit_date_picker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.visit_days = new System.Windows.Forms.Label();
            this.gender_box = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.readmit_guest_button = new System.Windows.Forms.Button();
            this.referring_social_worker = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.referring_hospital = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.modified_box = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.guest_personal_info = new System.Windows.Forms.Label();
            this.guest_admit_info = new System.Windows.Forms.Label();
            this.guest_discharge_info = new System.Windows.Forms.Label();
            this.room_num_box = new System.Windows.Forms.TextBox();
            this.bed_num_box = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_GuestID = new System.Windows.Forms.TextBox();
            this.textBox_VisitID = new System.Windows.Forms.TextBox();
            this.label_GiD = new System.Windows.Forms.Label();
            this.label_ViD = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // last_name
            // 
            this.last_name.Location = new System.Drawing.Point(17, 79);
            this.last_name.Margin = new System.Windows.Forms.Padding(4);
            this.last_name.Name = "last_name";
            this.last_name.Size = new System.Drawing.Size(180, 26);
            this.last_name.TabIndex = 3;
            // 
            // first_name
            // 
            this.first_name.Location = new System.Drawing.Point(21, 139);
            this.first_name.Margin = new System.Windows.Forms.Padding(4);
            this.first_name.Name = "first_name";
            this.first_name.Size = new System.Drawing.Size(180, 26);
            this.first_name.TabIndex = 4;
            // 
            // num_visits_textbox
            // 
            this.num_visits_textbox.Location = new System.Drawing.Point(280, 328);
            this.num_visits_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.num_visits_textbox.Name = "num_visits_textbox";
            this.num_visits_textbox.Size = new System.Drawing.Size(25, 26);
            this.num_visits_textbox.TabIndex = 13;
            // 
            // last_name_label
            // 
            this.last_name_label.Location = new System.Drawing.Point(17, 54);
            this.last_name_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.last_name_label.Name = "last_name_label";
            this.last_name_label.Size = new System.Drawing.Size(177, 20);
            this.last_name_label.TabIndex = 21;
            this.last_name_label.Text = "Last Name";
            // 
            // first_name_label
            // 
            this.first_name_label.Location = new System.Drawing.Point(17, 115);
            this.first_name_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.first_name_label.Name = "first_name_label";
            this.first_name_label.Size = new System.Drawing.Size(181, 20);
            this.first_name_label.TabIndex = 22;
            this.first_name_label.Text = "First Name";
            // 
            // dob_label
            // 
            this.dob_label.Location = new System.Drawing.Point(26, 193);
            this.dob_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dob_label.Name = "dob_label";
            this.dob_label.Size = new System.Drawing.Size(133, 23);
            this.dob_label.TabIndex = 18;
            this.dob_label.Text = "Date of Birth";
            // 
            // num_visits_label
            // 
            this.num_visits_label.Location = new System.Drawing.Point(313, 328);
            this.num_visits_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.num_visits_label.Name = "num_visits_label";
            this.num_visits_label.Size = new System.Drawing.Size(68, 28);
            this.num_visits_label.TabIndex = 30;
            this.num_visits_label.Text = "Visits";
            // 
            // exit_the_screen
            // 
            this.exit_the_screen.Location = new System.Drawing.Point(603, 426);
            this.exit_the_screen.Name = "exit_the_screen";
            this.exit_the_screen.Size = new System.Drawing.Size(116, 41);
            this.exit_the_screen.TabIndex = 17;
            this.exit_the_screen.Text = "Exit";
            this.exit_the_screen.UseVisualStyleBackColor = true;
            this.exit_the_screen.Click += new System.EventHandler(this.Exit_the_screenClick);
            // 
            // return_denial_reason
            // 
            this.return_denial_reason.Location = new System.Drawing.Point(589, 139);
            this.return_denial_reason.Multiline = true;
            this.return_denial_reason.Name = "return_denial_reason";
            this.return_denial_reason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.return_denial_reason.Size = new System.Drawing.Size(279, 38);
            this.return_denial_reason.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(585, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 23);
            this.label1.TabIndex = 29;
            this.label1.Text = "Discharge Reason";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(589, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Discharge Date";
            // 
            // delete_guest_button
            // 
            this.delete_guest_button.Location = new System.Drawing.Point(428, 426);
            this.delete_guest_button.Name = "delete_guest_button";
            this.delete_guest_button.Size = new System.Drawing.Size(142, 41);
            this.delete_guest_button.TabIndex = 16;
            this.delete_guest_button.Text = "Delete this guest";
            this.delete_guest_button.UseVisualStyleBackColor = true;
            this.delete_guest_button.Click += new System.EventHandler(this.delete_guest_button_Click);
            // 
            // can_return_checkbox
            // 
            this.can_return_checkbox.Location = new System.Drawing.Point(589, 280);
            this.can_return_checkbox.Name = "can_return_checkbox";
            this.can_return_checkbox.Size = new System.Drawing.Size(186, 24);
            this.can_return_checkbox.TabIndex = 11;
            this.can_return_checkbox.Text = "Eligible for Return";
            this.can_return_checkbox.UseVisualStyleBackColor = true;
            // 
            // dob_dt_picker
            // 
            this.dob_dt_picker.CustomFormat = "MM-dd-yyyy";
            this.dob_dt_picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dob_dt_picker.Location = new System.Drawing.Point(26, 218);
            this.dob_dt_picker.Name = "dob_dt_picker";
            this.dob_dt_picker.Size = new System.Drawing.Size(175, 26);
            this.dob_dt_picker.TabIndex = 0;
            // 
            // last_time_discharged
            // 
            this.last_time_discharged.CustomFormat = "MM-dd-yyyy";
            this.last_time_discharged.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.last_time_discharged.Location = new System.Drawing.Point(589, 79);
            this.last_time_discharged.Name = "last_time_discharged";
            this.last_time_discharged.Size = new System.Drawing.Size(170, 26);
            this.last_time_discharged.TabIndex = 2;
            // 
            // update_guest_button
            // 
            this.update_guest_button.Location = new System.Drawing.Point(259, 426);
            this.update_guest_button.Name = "update_guest_button";
            this.update_guest_button.Size = new System.Drawing.Size(136, 41);
            this.update_guest_button.TabIndex = 15;
            this.update_guest_button.Text = "Update this Guest";
            this.update_guest_button.UseVisualStyleBackColor = true;
            this.update_guest_button.Click += new System.EventHandler(this.Update_guest_buttonClick);
            // 
            // deceased_checkbox
            // 
            this.deceased_checkbox.Location = new System.Drawing.Point(589, 306);
            this.deceased_checkbox.Name = "deceased_checkbox";
            this.deceased_checkbox.Size = new System.Drawing.Size(157, 24);
            this.deceased_checkbox.TabIndex = 12;
            this.deceased_checkbox.Text = "Deceased";
            this.deceased_checkbox.UseVisualStyleBackColor = true;
            // 
            // ssn_id_no_box
            // 
            this.ssn_id_no_box.Location = new System.Drawing.Point(26, 279);
            this.ssn_id_no_box.Name = "ssn_id_no_box";
            this.ssn_id_no_box.Size = new System.Drawing.Size(133, 26);
            this.ssn_id_no_box.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(26, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 23);
            this.label3.TabIndex = 25;
            this.label3.Text = "SSN/W7 ID Number";
            // 
            // admit_reason_box
            // 
            this.admit_reason_box.Location = new System.Drawing.Point(281, 139);
            this.admit_reason_box.Multiline = true;
            this.admit_reason_box.Name = "admit_reason_box";
            this.admit_reason_box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.admit_reason_box.Size = new System.Drawing.Size(279, 38);
            this.admit_reason_box.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(277, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Admission Reason";
            // 
            // admit_date_picker
            // 
            this.admit_date_picker.CustomFormat = "MM-dd-yyyy";
            this.admit_date_picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.admit_date_picker.Location = new System.Drawing.Point(285, 79);
            this.admit_date_picker.Name = "admit_date_picker";
            this.admit_date_picker.Size = new System.Drawing.Size(181, 26);
            this.admit_date_picker.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(286, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 23);
            this.label5.TabIndex = 19;
            this.label5.Text = "Admission date";
            // 
            // visit_days
            // 
            this.visit_days.Location = new System.Drawing.Point(589, 223);
            this.visit_days.Name = "visit_days";
            this.visit_days.Size = new System.Drawing.Size(274, 23);
            this.visit_days.TabIndex = 24;
            this.visit_days.Text = "Days Label";
            // 
            // gender_box
            // 
            this.gender_box.Location = new System.Drawing.Point(168, 279);
            this.gender_box.Name = "gender_box";
            this.gender_box.Size = new System.Drawing.Size(33, 26);
            this.gender_box.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(165, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 23;
            this.label6.Text = "Gender";
            // 
            // readmit_guest_button
            // 
            this.readmit_guest_button.Location = new System.Drawing.Point(85, 426);
            this.readmit_guest_button.Name = "readmit_guest_button";
            this.readmit_guest_button.Size = new System.Drawing.Size(141, 41);
            this.readmit_guest_button.TabIndex = 14;
            this.readmit_guest_button.Text = "Re-Admit this Guest";
            this.readmit_guest_button.UseVisualStyleBackColor = true;
            this.readmit_guest_button.Click += new System.EventHandler(this.Readmit_guest_buttonClick);
            // 
            // referring_social_worker
            // 
            this.referring_social_worker.Location = new System.Drawing.Point(280, 278);
            this.referring_social_worker.Name = "referring_social_worker";
            this.referring_social_worker.Size = new System.Drawing.Size(280, 26);
            this.referring_social_worker.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(278, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "Referring Social Worker";
            // 
            // referring_hospital
            // 
            this.referring_hospital.Location = new System.Drawing.Point(280, 220);
            this.referring_hospital.Name = "referring_hospital";
            this.referring_hospital.Size = new System.Drawing.Size(280, 26);
            this.referring_hospital.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(281, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 20);
            this.label8.TabIndex = 26;
            this.label8.Text = "Referring Hospital";
            // 
            // modified_box
            // 
            this.modified_box.Location = new System.Drawing.Point(589, 344);
            this.modified_box.Name = "modified_box";
            this.modified_box.Size = new System.Drawing.Size(175, 26);
            this.modified_box.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(585, 379);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 20);
            this.label9.TabIndex = 32;
            this.label9.Text = "Last Editted on";
            // 
            // guest_personal_info
            // 
            this.guest_personal_info.AutoSize = true;
            this.guest_personal_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guest_personal_info.Location = new System.Drawing.Point(11, 21);
            this.guest_personal_info.Name = "guest_personal_info";
            this.guest_personal_info.Size = new System.Drawing.Size(247, 25);
            this.guest_personal_info.TabIndex = 33;
            this.guest_personal_info.Text = "Guest Personal Information";
            // 
            // guest_admit_info
            // 
            this.guest_admit_info.AutoSize = true;
            this.guest_admit_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guest_admit_info.Location = new System.Drawing.Point(279, 21);
            this.guest_admit_info.Name = "guest_admit_info";
            this.guest_admit_info.Size = new System.Drawing.Size(261, 25);
            this.guest_admit_info.TabIndex = 34;
            this.guest_admit_info.Text = "Guest Admission Information";
            // 
            // guest_discharge_info
            // 
            this.guest_discharge_info.AutoSize = true;
            this.guest_discharge_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guest_discharge_info.Location = new System.Drawing.Point(583, 21);
            this.guest_discharge_info.Name = "guest_discharge_info";
            this.guest_discharge_info.Size = new System.Drawing.Size(258, 25);
            this.guest_discharge_info.TabIndex = 35;
            this.guest_discharge_info.Text = "Guest Discharge Information";
            // 
            // room_num_box
            // 
            this.room_num_box.Location = new System.Drawing.Point(280, 373);
            this.room_num_box.Name = "room_num_box";
            this.room_num_box.Size = new System.Drawing.Size(25, 26);
            this.room_num_box.TabIndex = 36;
            // 
            // bed_num_box
            // 
            this.bed_num_box.Location = new System.Drawing.Point(427, 373);
            this.bed_num_box.Name = "bed_num_box";
            this.bed_num_box.Size = new System.Drawing.Size(25, 26);
            this.bed_num_box.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(313, 379);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 20);
            this.label10.TabIndex = 38;
            this.label10.Text = "Room";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(458, 379);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 20);
            this.label11.TabIndex = 39;
            this.label11.Text = "Bed";
            // 
            // textBox_GuestID
            // 
            this.textBox_GuestID.Location = new System.Drawing.Point(26, 330);
            this.textBox_GuestID.Name = "textBox_GuestID";
            this.textBox_GuestID.ReadOnly = true;
            this.textBox_GuestID.Size = new System.Drawing.Size(60, 26);
            this.textBox_GuestID.TabIndex = 40;
            this.textBox_GuestID.TabStop = false;
            this.textBox_GuestID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_VisitID
            // 
            this.textBox_VisitID.Location = new System.Drawing.Point(141, 330);
            this.textBox_VisitID.Name = "textBox_VisitID";
            this.textBox_VisitID.ReadOnly = true;
            this.textBox_VisitID.Size = new System.Drawing.Size(60, 26);
            this.textBox_VisitID.TabIndex = 41;
            this.textBox_VisitID.TabStop = false;
            this.textBox_VisitID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_GiD
            // 
            this.label_GiD.AutoSize = true;
            this.label_GiD.Location = new System.Drawing.Point(26, 376);
            this.label_GiD.Name = "label_GiD";
            this.label_GiD.Size = new System.Drawing.Size(85, 20);
            this.label_GiD.TabIndex = 42;
            this.label_GiD.Text = "Guest ID#";
            // 
            // label_ViD
            // 
            this.label_ViD.AutoSize = true;
            this.label_ViD.Location = new System.Drawing.Point(137, 376);
            this.label_ViD.Name = "label_ViD";
            this.label_ViD.Size = new System.Drawing.Size(73, 20);
            this.label_ViD.TabIndex = 43;
            this.label_ViD.Text = "Visit ID#";
            // 
            // SHGuestDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 521);
            this.Controls.Add(this.label_ViD);
            this.Controls.Add(this.label_GiD);
            this.Controls.Add(this.textBox_VisitID);
            this.Controls.Add(this.textBox_GuestID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.bed_num_box);
            this.Controls.Add(this.room_num_box);
            this.Controls.Add(this.guest_discharge_info);
            this.Controls.Add(this.guest_admit_info);
            this.Controls.Add(this.guest_personal_info);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.modified_box);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.referring_hospital);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.referring_social_worker);
            this.Controls.Add(this.readmit_guest_button);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gender_box);
            this.Controls.Add(this.visit_days);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.admit_date_picker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.admit_reason_box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ssn_id_no_box);
            this.Controls.Add(this.deceased_checkbox);
            this.Controls.Add(this.update_guest_button);
            this.Controls.Add(this.last_time_discharged);
            this.Controls.Add(this.dob_dt_picker);
            this.Controls.Add(this.can_return_checkbox);
            this.Controls.Add(this.delete_guest_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.return_denial_reason);
            this.Controls.Add(this.exit_the_screen);
            this.Controls.Add(this.num_visits_label);
            this.Controls.Add(this.dob_label);
            this.Controls.Add(this.first_name_label);
            this.Controls.Add(this.last_name_label);
            this.Controls.Add(this.num_visits_textbox);
            this.Controls.Add(this.first_name);
            this.Controls.Add(this.last_name);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SHGuestDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Samaritan House Guest Display";
            this.Load += new System.EventHandler(this.SHGuestDisplayLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Button readmit_guest_button;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox gender_box;
		private System.Windows.Forms.Label visit_days;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker admit_date_picker;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox admit_reason_box;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox ssn_id_no_box;
		private System.Windows.Forms.CheckBox deceased_checkbox;
		private System.Windows.Forms.Button update_guest_button;
		private System.Windows.Forms.DateTimePicker last_time_discharged;
		private System.Windows.Forms.CheckBox can_return_checkbox;
		private System.Windows.Forms.Button delete_guest_button;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox return_denial_reason;
		private System.Windows.Forms.Button exit_the_screen;
		private System.Windows.Forms.Label num_visits_label;
		private System.Windows.Forms.Label dob_label;
		private System.Windows.Forms.Label first_name_label;
		private System.Windows.Forms.Label last_name_label;
		private System.Windows.Forms.TextBox num_visits_textbox;
		private System.Windows.Forms.DateTimePicker dob_dt_picker;
		private System.Windows.Forms.TextBox first_name;
		private System.Windows.Forms.TextBox last_name;
        private System.Windows.Forms.TextBox referring_social_worker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox referring_hospital;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox modified_box;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label guest_personal_info;
        private System.Windows.Forms.Label guest_admit_info;
        private System.Windows.Forms.Label guest_discharge_info;
        private System.Windows.Forms.TextBox room_num_box;
        private System.Windows.Forms.TextBox bed_num_box;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_GuestID;
        private System.Windows.Forms.TextBox textBox_VisitID;
        private System.Windows.Forms.Label label_GiD;
        private System.Windows.Forms.Label label_ViD;
    }
}
