using NextGenGuests.DAL;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace NewNextGenGuestsProcess
{
    /// <summary>
    /// Description of update_record. 
    /// </summary>
    public partial class discharge_guest : Form
    {
        public DateTime dob, admit_date, last_visit_date, edit_date;
        public object [ ] guestkey, vkey;
        public NextGenGuestsDal dal = new NextGenGuestsDal ( );
        public bool can_return, deceased = false;
        public int num_of_visits, ssn_in, in_GuestID = 0, in_VisitID = 0;

        public string lname, fname, discharge_reason, admit_reason, connStr,
                      str_ssn, l_name, f_name, gender,
                      birthday, lst_date, referring_hospital, refer_sw, refer_hosp;

        private Guest update_record = new Guest ( );
        private Visit vd = new Visit ( );
        public MailMessage m_Message = new MailMessage ( );
        public SmtpClient smtp_Client = new SmtpClient ( );
        public StringBuilder message_body;

        public discharge_guest ( int GuestID, int VisitID )
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            in_GuestID = GuestID;
            in_VisitID = VisitID;
            InitializeComponent ( );
        }

        private void Discharge_guestLoad ( object sender, EventArgs e )
        {
            StringBuilder sb = new StringBuilder ( );
            using (var db = new NextGenEntity ( ))
            {
                guestkey = new object [ ]
                {
                    in_GuestID
                };
                update_record = new Guest ( );
                update_record = db.Guests.Find ( guestkey );
                vkey = new object [ ] { in_VisitID };
                vd = db.Visits.Find ( vkey );
                build_the_display ( update_record, vd );
            }
            return;
        }

        private void build_the_display ( Guest rec_in, Visit vd_in )
        {
            last_name_box.Text = rec_in.LastName;
            first_name_box.Text = rec_in.FirstName;
            gender_box.Text = rec_in.Gender;
            dob_picker.Value = rec_in.BirthDate;
            admit_date_picker.Value = vd_in.AdmitDate;
            discharge_date_picker.Value = DateTime.Today;
            ssn_id_box.Text = rec_in.SSN.ToString ( "000-00-0000" );
            admit_reason_box.Text = vd_in.AdmitReason;
            visit_num_box.Text = vd_in.VisitNumber.ToString ( );
            referring_social_worker.Text = vd_in.Worker;
            admit_from.Text = vd_in.Agency;
            return;
        }

        private void Discharge_buttonClick ( object sender, EventArgs e )
        {
            using (var db = new NextGenEntity ( ))
            {
                object [ ] guestkey2 = new object [ ] { in_GuestID };
                update_record = db.Guests.Find ( guestkey2 );
                vkey = new object [ ] { in_VisitID };
                vd = db.Visits.Find ( vkey );

                update_record.Roster = "D";
                vd.Roster = update_record.Roster;
                vd.AdmitDate = new DateTime ( admit_date_picker.Value.Year, admit_date_picker.Value.Month, admit_date_picker.Value.Day, 0, 0, 0 );
                update_record.LastVisitDate = vd.AdmitDate;
                vd.Discharged = new DateTime ( discharge_date_picker.Value.Year, discharge_date_picker.Value.Month, discharge_date_picker.Value.Day, 0, 0, 0 );
                vd.DischargeReason = discharge_reason_box.Text;
                vd.VisitDays = ( vd.Discharged.AddDays ( 1 ) - vd.AdmitDate ).Days;
                vd.CanReturn = can_return_check.Checked;
                vd.Deceased = deceased_check.Checked;
                vd.EditDate = DateTime.Now.ToUniversalTime ( );
                db.Entry ( update_record ).State = EntityState.Modified;
                db.Entry ( vd ).State = EntityState.Modified;
                int recs_updated = db.SaveChanges ( );
                SendAutomatedEmail(update_record, vd);
                MessageBox.Show ( "Guest has been discharged" + Environment.NewLine + update_record.ToString ( ) );
            }
            Close ( );
            return;
        }

        private void Cancel_discharge_buttonClick ( object sender, EventArgs e )
        {
            Close ( );
        }

        #region Send the Email

        private void SendAutomatedEmail ( Guest guest_in, Visit vd_in )
        {
            try
            {
                string email_sender = Properties.Settings.Default.email_sender;
                string email_pswd = Properties.Settings.Default.email_pswd;
                string mainToAddress = Properties.Settings.Default.email_receiver;
                SecureString em_pass = new SecureString ( );
                MailMessage m_Message = new MailMessage ( );
                SmtpClient smtp = new SmtpClient ( "smtp.gmail.com", 587 );
                m_Message.From = new MailAddress ( email_sender );
                m_Message.To.Add ( new MailAddress ( mainToAddress ) );
                //*message.CC.Add(new MailAddress("bgoforth@thesamaritanhouse.org"));
                //*message.CC.Add(new MailAddress("gchapman@thesamaritanhouse.org"));
                m_Message.Subject = "Guest Discharged On: " + DateTime.Today.ToShortDateString ( );
                m_Message.IsBodyHtml = false;
                m_Message.Priority = MailPriority.High;
                Build_Message_Body ( guest_in, vd_in );
                m_Message.Body = message_body.ToString ( );
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                if (email_pswd.Length > 0)
                {
                    foreach (var c in email_pswd.ToCharArray ( )) em_pass.AppendChar ( c );
                }
                smtp.Credentials = new NetworkCredential ( email_sender, em_pass );
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //*
                //* Send the email async so the thread can continue processing. Notify user when email has been sent
                //*
                smtp.SendCompleted += new SendCompletedEventHandler ( SendCompletedCallback );
                smtp.SendMailAsync ( m_Message );
            }
            catch (Exception)
            { }
        }

        private void Build_Message_Body ( Guest rec_in, Visit vd_in )
        {
            message_body = new StringBuilder ( );
            message_body.AppendLine ( $"Name:\t\t\t{rec_in.FirstName} {rec_in.LastName} " );
            message_body.AppendLine ( $"Admitted On:\t\t{vd_in.AdmitDate.ToShortDateString ( )} for {vd_in.AdmitReason}" );
            message_body.AppendLine ( $"Referring Information:\t{vd_in.Agency} by {vd_in.Worker}" );
            message_body.AppendLine ( $"Discharged On:\t\t{vd_in.Discharged.ToShortDateString ( )} for {vd_in.DischargeReason}" );
            message_body.AppendLine ( $"Personal Information:" );
            message_body.AppendLine ( $"Date of Birth:\t\t{rec_in.BirthDate.ToShortDateString ( )} SSN: {rec_in.SSN.ToString ( "000-00-0000" )}" );
            message_body.AppendLine ( $"Stay (Bed Days):\t{vd_in.VisitDays:N0}");
            message_body.AppendLine ( $"Visit Number:\t\t{vd_in.VisitNumber:N0}" );
            return;
        }

        private void SendCompletedCallback ( object sender, AsyncCompletedEventArgs e )
        {
            MessageBox.Show ( "Email sent successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information );
            return;
        }

        #endregion Send the Email
    }
}