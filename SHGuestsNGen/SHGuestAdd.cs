using NextGenGuests.DAL;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;
using System.Windows.Forms;

namespace NewNextGenGuestsProcess
	{
	/// <summary>
	/// Description of SHGuestAdd.
	/// </summary>
	public partial class SHGuestAdd : Form
	{
        public DateTime dob, last_visit_date, admit_date;
		public int num_of_visits, ssn_in;
		public Boolean yes_return = true,  can_return = false, deceased = false;
		public string denial_reason, admit_reason, str_ssn, gender, lname, fname,
                      connStr, l_name, f_name, birthday, last_visit, refer_sw, refer_hosp;

 
        public NextGenGuestsDal dal = new NextGenGuestsDal ( );
        public Guest discharged_guest = new Guest ( );
        public Visit vd = new Visit ( );

		public SHGuestAdd()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Add_guest_buttonClick(object sender, EventArgs e)
		{
			discharged_guest.BirthDate = dob_date_picker.Value;
			discharged_guest.LastName= lastname_entry.Text;
			discharged_guest.FirstName= firstname_entry.Text;
			discharged_guest.Gender = gender_box.Text.ToUpper();
            discharged_guest.Roster = "D";
            vd.Roster = discharged_guest.Roster;
            if (!discharged_guest.Gender.Contains("M") && !discharged_guest.Gender.Contains("F"))
			{
				MessageBox.Show("Gender must be M or F. Please try again.");
				this.ActiveControl = gender_box;
				return;
			}
            // DO NOT Store the time in Admit or Discharge Dates. It messes with the Bed days calculation
            vd.Discharged = new DateTime ( lastvisit_datepicker.Value.Year, lastvisit_datepicker.Value.Month, lastvisit_datepicker.Value.Day, 0, 0, 0 );
            vd.AdmitDate = new DateTime ( admit_date_picker.Value.Year, admit_date_picker.Value.Month, admit_date_picker.Value.Day, 0, 0, 0 );
            vd.VisitDays = ( vd.Discharged.AddDays ( 1 ) - vd.AdmitDate ).Days;
            //
			if (!int.TryParse(numvisits_textbox.Text,  out num_of_visits))
			{
				MessageBox.Show("Invalid number in number of visits. Try Again");
				this.ActiveControl = numvisits_textbox;
				return;
			}
            vd.VisitNumber = num_of_visits;
            discharged_guest.Visits = num_of_visits;
			vd.DischargeReason = " ";
			if (!nonreturn_reason_text.Text.Equals(null))
		    {
				vd.DischargeReason = nonreturn_reason_text.Text;    	
		    }
			vd.Deceased = deceased_checkbox.Checked;
			vd.CanReturn = canreturn_checkBox.Checked;
			if ((ssn_id_no_box.Text.Length < 9) && (ssn_id_no_box.Text.Contains("N/A")))
			{
				MessageBox.Show("Incorrect information in field. Please try again");
				this.ActiveControl = ssn_id_no_box;
				return;
			}

            str_ssn = ( ssn_id_no_box.Text.Contains ( "-" ) ) ?
                       ssn_id_no_box.Text.Substring ( 0, 3 )
                     + ssn_id_no_box.Text.Substring ( 4, 2 )
                     + ssn_id_no_box.Text.Substring ( 7, 4 ) :
                       ssn_id_no_box.Text;

            if (!int.TryParse(str_ssn,  out ssn_in))
			{
				MessageBox.Show("Incorrect information in field. Please try again");
				this.ActiveControl = ssn_id_no_box;
				return;
			}
            discharged_guest.SSN = ssn_in;
			vd.AdmitReason = admit_reason_box.Text;
            vd.Worker = referring_sw.Text;
            if (vd.Worker.Length == 0 || vd.Worker.Equals(null))
            {
                MessageBox.Show("Referring Social Worker may not be blank. Please try again");
                this.ActiveControl = referring_sw;
                return;

            }
            vd.Agency = referring_hospital.Text;
            if (vd.Agency.Length == 0 || vd.Agency.Equals(null))
            {
                MessageBox.Show("Referring Social Worker may not be blank. Please try again");
                this.ActiveControl = referring_hospital;
                return;

            }
            discharged_guest.LastVisitDate = vd.AdmitDate;
            vd.EditDate = DateTime.Now.ToUniversalTime ( );
            vd.VisitKey = BuildVisitKey ( discharged_guest, discharged_guest.Visits );
			try
			{
                using (var db = new NextGenEntity ( ))
                {
                    db.Entry ( discharged_guest ).State = EntityState.Added;
                    db.SaveChanges ( );
                    vd.GuestID = discharged_guest.GuestID;
                    db.Entry ( vd ).State = EntityState.Added;
                    db.SaveChanges ( );
                    MessageBox.Show ( "Record was successfully added." + Environment.NewLine + discharged_guest.ToString() );
                }
                Close ();
			}
			catch (DbUnexpectedValidationException ex)
			{
				MessageBox.Show("Error " + ex.HResult.ToString() + " " + ex.Message);
			}
			Close();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			Close();
		}
        private string BuildVisitKey ( Guest item_in, int visit_in )
        {
            StringBuilder sb = new StringBuilder ( );
            string tmp_ssn = item_in.SSN.ToString ( "000000000" );
            sb.Append ( item_in.BirthDate.ToString ( "yyyyMMdd" ) );
            if (item_in.LastName.Length < 5)
            {
                sb.Append ( item_in.LastName.PadRight ( 5 ).ToUpper ( ) );
            }
            else
            {
                sb.Append ( item_in.LastName.Substring ( 0, 5 ).ToUpper ( ) );
            }
            if (item_in.FirstName.Length < 4)
            {
                sb.Append ( item_in.FirstName.PadRight ( 4 ).ToUpper ( ) );
            }
            else
            {
                sb.Append ( item_in.FirstName.Substring ( 0, 4 ).ToUpper ( ) );
            }
            sb.Append ( tmp_ssn.Substring ( 5, 4 ) );
            sb.Append ( visit_in.ToString ( ) );
            string tmps = sb.ToString ( );
            return tmps;
        }
    }
}
