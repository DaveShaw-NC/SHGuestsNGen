using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NextGenGuests.DAL;

namespace SHGuestsNGen
{
    /// <summary>
    /// Description of current_guest_display.
    /// </summary>
    public partial class current_guest_display : Form
    {
        public string rosteri;
        public DateTime dob, key_dob, admit_date, lst_vis_plus1, possDischDate, work_discharge, display_discharge, admit_date_no_time;
        public bool can_return, deceased = false, record_found = true;
        public int num_of_visits, ssn_in, room_number, bed_number, GiD;

        public string lname, fname, key_lname, denial_reason, admit_reason, connStr,
                     str_ssn, l_name, f_name, gender,
                     birthday, lst_date, referring_hospital, refer_sw;
        public Font do_font = new Font ( "Tahoma", 14F, FontStyle.Bold, GraphicsUnit.Pixel );
        public Font adFont = new Font ( "Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point );
        public Guest update_record = new Guest ( );
        public Visit vd;
        public object [ ] guestkey;

        public current_guest_display ( int GuestId, int VisitNum, string header_Text )
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            num_of_visits = VisitNum;
            GiD = GuestId;
            InitializeComponent ( );
            Text = $"Record as of {header_Text}";

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        private void Current_guest_displayLoad ( object sender, EventArgs e )
        {
            guestkey = new object [ ]
            {
                GiD
            };
            using (var db = new NextGenEntity ( ))
            {
                update_record = new Guest ( );
                update_record = db.Guests.Find ( guestkey );                       // Find a specific record using Primary Key Values 
                if (update_record != null)
                {
                    build_the_display ( update_record );
                    Show ( );
                }
                else
                {
                    MessageBox.Show ( "No record found for " + l_name + ", " + f_name );
                    record_found = false;
                    Close ( );
                }
                return;
            }
        }
        private void build_the_display ( Guest foundrec )
        {
            Func<DateTime, DateTime, int> myMethod = CalcDays;
            DateTime to_Date = DateTime.Today;
            vd = new Visit ( );
            foreach (Visit vvv in foundrec.Visits1)
            {
                if (vvv.VisitNumber == num_of_visits)
                {
                    vd = vvv;
                    break;
                }
            }
            admit_date_no_time = new DateTime ( vd.AdmitDate.Year, vd.AdmitDate.Month, vd.AdmitDate.Day, 0, 0, 0 );
            textBox_GiD.Text = foundrec.GuestID.ToString ( "N0" );
            textBox_ViD.Text = vd.VisitID.ToString ( "N0" );
            last_name_box.Text = foundrec.LastName;
            first_name_box.Text = foundrec.FirstName;
            gender_box.Text = foundrec.Gender;
            dob_datepicker.Value = foundrec.BirthDate;
            admit_datepicker.Value = vd.AdmitDate;

            str_ssn = ( foundrec.SSN != 0 ) ?
                       foundrec.SSN.ToString ( "000-00-0000" ) :
                       "999-99-9999";
            ssn_id_no_box.Text = str_ssn;

            admit_reason_box.Text = vd.AdmitReason;
            referring_hospital_box.Text = vd.Agency;
            referring_social_worker.Text = vd.Worker;
            visit_num_box.Text = foundrec.Visits.ToString ( );
            room_num_box.Text = vd.Room.ToString ( );
            bed_num_box.Text = vd.Bed.ToString ( );
            last_name_box.ReadOnly = true;
            dob_datepicker.Enabled = false;
            gender_box.ReadOnly = true;
            first_name_box.ReadOnly = true;
            visit_num_box.ReadOnly = true;
            if (!str_ssn.Contains ( "N/A" ) || ( str_ssn.Length == 12 ))
            {
                ssn_id_no_box.ReadOnly = true;
            }
            admit_datepicker.Focus ( );
            this.ActiveControl = admit_datepicker;

            days_here_label.Text = string.Empty;
            days_over_stay.Text = string.Empty;

            lst_vis_plus1 = DateTime.Now.AddDays ( 1 );
            TimeSpan visit_length = lst_vis_plus1 - vd.AdmitDate;
            //days_here_label.Text = $"{visit_length.Days} guest day(s)";
            int visit_length_Days = myMethod ( DateTime.Today, admit_date_no_time );
            days_here_label.Text = $"{visit_length_Days:N0} guest days";
            days_here_label.Font = adFont;

            TimeSpan dcharge = vd.Discharged - vd.AdmitDate;
            DateTime display_discharge = admit_date_no_time.AddDays ( 45 );
            work_discharge = admit_date_no_time.AddDays ( 10 );
            sugg_dischargeLabel.Text = $"Admit Date + 45 Days: {display_discharge.ToShortDateString ( )}";
            sugg_dischargeLabel.Font = adFont;
            calc_dischg_date.Text = $"Admit Date + 10 Days: {work_discharge.ToShortDateString ( )}";
            calc_dischg_date.Font = adFont;

            if (display_discharge <= DateTime.Today)
            {
                visit_length = lst_vis_plus1 - display_discharge;
                days_over_stay.Text = $"{visit_length.Days} Day(s) past maximum stay";
                days_over_stay.ForeColor = Color.DarkRed;
                days_over_stay.Font = do_font;
            }
            modified_box.Text = $"{vd.EditDate.ToString ( "dd MMM yyyy @ HH:mm:sss" )}";
            if (foundrec.Gender == "F")
            {
                this.BackColor = Color.LightYellow;
            }
            return;
        }

        void Exit_display_buttonClick ( object sender, EventArgs e )
        {
            Close ( );
        }

        void Discharge_guest_buttonClick ( object sender, EventArgs e )
        {
            Guest dcharge_Guest = new Guest ( );
            NextGenEntity db = new NextGenEntity ( );
            dcharge_Guest = db.Guests.Find ( guestkey );
            vd = new Visit ( );
            foreach (Visit vvv in dcharge_Guest.Visits1)
            {
                if (vvv.VisitNumber == num_of_visits)
                {
                    vd = vvv;
                    break;
                }
            }
            discharge_guest dgscrn = new discharge_guest(dcharge_Guest.GuestID, vd.VisitID);
            Hide ( );
            dgscrn.ShowDialog();
            Close ( );
        }

        void Update_guest_buttonClick ( object sender, EventArgs e )
        {
            StringBuilder sb = new StringBuilder ( );
            Visit vd = new Visit ( );
            NextGenEntity db = new NextGenEntity ( );
            update_record = new Guest ( );
            update_record = db.Guests.Find ( guestkey );                  // Find a specific record using Primary Key Values 
            foreach (Visit vvv in update_record.Visits1)
            {
                if (vvv.VisitNumber == num_of_visits)
                {
                    vd = vvv;
                    break;
                }
            }
            update_record.BirthDate = dob_datepicker.Value;
            update_record.LastName = last_name_box.Text;
            update_record.FirstName = first_name_box.Text;
            update_record.Gender = gender_box.Text.ToUpper ( );
            if (String.IsNullOrWhiteSpace ( gender_box.Text ))
            {
                MessageBox.Show ( "Gender MUST be Entered" );
                this.ActiveControl = gender_box;
                return;
            }
            if (!update_record.Gender.Contains ( "M" ) && !update_record.Gender.Contains ( "F" ))
            {
                MessageBox.Show ( "Gender must be M or F. Please try again." );
                return;
            }
            vd.AdmitDate = admit_datepicker.Value;
            vd.AdmitReason = admit_reason_box.Text;
            vd.Agency = referring_hospital_box.Text;
            if (!int.TryParse ( visit_num_box.Text, out num_of_visits ))
            {
                MessageBox.Show ( "Invalid number in number of visits. Try Again" );
                return;
            }
            update_record.Visits = num_of_visits;
            vd.VisitNumber = update_record.Visits;
            if (String.IsNullOrWhiteSpace ( ssn_id_no_box.Text ))
            {
                MessageBox.Show ( "SSN/W7 field may not be empty. Try Again." );
                return;
            }
            if (( ssn_id_no_box.Text.Length < 11 ) || ( ssn_id_no_box.Text.Contains ( "N/A" ) ))
            {
                MessageBox.Show ( "Incorrect information in field. Please try again" );
                this.ActiveControl = ssn_id_no_box;
                return;
            }
            str_ssn = ( ssn_id_no_box.Text.Contains ( "-" ) ) ?
                       ssn_id_no_box.Text.Substring ( 0, 3 )
                     + ssn_id_no_box.Text.Substring ( 4, 2 )
                     + ssn_id_no_box.Text.Substring ( 7, 4 ) :
                       ssn_id_no_box.Text;

            if (!int.TryParse ( str_ssn, out ssn_in ))
            {
                MessageBox.Show ( "Incorrect information in field. Please try again" );
                this.ActiveControl = ssn_id_no_box;
                return;
            }
            update_record.SSN = ssn_in;
            if (!int.TryParse ( room_num_box.Text, out room_number ))
            {
                MessageBox.Show ( "Incorrect information in field. Please try again" );
                this.ActiveControl = room_num_box;
                return;
            }
            vd.Room = room_number;
            if (!int.TryParse ( bed_num_box.Text, out bed_number ))
            {
                MessageBox.Show ( "Incorrect information in field. Please try again" );
                this.ActiveControl = bed_num_box;
                return;
            }
            vd.Bed = bed_number;
            vd.Worker = referring_social_worker.Text;
            if (String.IsNullOrWhiteSpace ( vd.Worker ) || vd.Worker.Length > 45)
            {
                MessageBox.Show ( "Referring Social Worker may not be blank. Please try again" );
                this.ActiveControl = referring_social_worker;
                return;
            }
            vd.EditDate = DateTime.Now.ToUniversalTime ( );
            db.Entry ( update_record ).State = System.Data.Entity.EntityState.Modified;
            db.Entry ( vd ).State = System.Data.Entity.EntityState.Modified;
            int recs_updated = db.SaveChanges ( );
            Close ( );
            return;
        }

        #region My Functions for LINQ

        public int CalcDays ( DateTime from, DateTime to )
        {
            TimeSpan ts = new TimeSpan ( 0, 0, 0 );
            ts = from.AddDays ( 1 ) - to;
            return ts.Days;
        }

        #endregion My Functions for LINQ


        private void edit_ssn_textbox ( object sender, EventArgs e )
        {
            if (ssn_id_no_box.Text.Length < 1)
            {
                MessageBox.Show ( "SSN/W7 field may not be empty. Try Again." );
                return;
            }
            if (( ssn_id_no_box.Text.Length < 9 ) || ( ssn_id_no_box.Text.Contains ( "N/A" ) ))
            {
                MessageBox.Show ( "Incorrect information in field. Please try again" );
                this.ActiveControl = ssn_id_no_box;
                return;
            }
            if (!int.TryParse ( ssn_id_no_box.Text, out ssn_in ))
            {
                MessageBox.Show ( "Incorrect information in field. Please try again" );
                this.ActiveControl = ssn_id_no_box;
                return;
            }

        }

    }
}
