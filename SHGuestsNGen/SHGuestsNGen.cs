using NextGenGuests.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace SHGuestsNGen
{
    public partial class SHGuestsNGen : Form
    {
        #region Variables and Constants

        public enum pivot_rpt_type { Normal = 0, MonthlyReport = 2, Worker = 3 };

        public pivot_rpt_type report_type;
        public bool rs = true, repopc = false, repopd = false, statistical_report = true, repopulate = false, readmit = false;
        private NextGenGuestsDal dal = new NextGenGuestsDal ( );
        public List<Guest> theGuestList = new List<Guest> ( );
        public List<Visit> theVisitList = new List<Visit> ( );
        public List<string> current_combo, discharged_combo;
        public static Font lbl_Font = new Font ( "Tahoma", 10F, FontStyle.Regular, GraphicsUnit.Point );
        public static Font status_Font = new Font ( "Tahoma", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point );
        public static Font combo_Font = new Font ( "Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point );
        public Query_Results rpt_dlg;
        public DialogResult res;
        public int num_rows = 0;

        #endregion Variables and Constants

        #region Constructor

        public SHGuestsNGen ( )
        {
            InitializeComponent ( );
        }

        #endregion Constructor

        #region Methods

        #region Form Loading

        private void NewNextGenGuestProcess_Load ( object sender, EventArgs e )
        {
            this.BackColor = ColorTranslator.FromHtml ( "#FFF8E7" );
            Load_the_ComboBoxes ( );
            Do_Totals ( );
        }

        public void Do_Totals ( )
        {
            label_CurrentCount.Font = lbl_Font;
            label_DischargedCount.Font = lbl_Font;
            label_MultiVisits.Font = lbl_Font;
            label_SingleVisits.Font = lbl_Font;
            label_TotalVisits.Font = lbl_Font;
            label_ParkRoadVisits.Font = lbl_Font;
            label_NoReturnCount.Font = lbl_Font;
            toolStripStatusLabel_statusLabel.Font = status_Font;
            toolStripStatusLabel_statusLabel.ForeColor = Color.DarkBlue;

            var db = new NextGenEntity ( );
            int currentcount = db.Guests.Count ( g => g.Roster == "C" );
            int dischcount = db.Guests.Count ( g => g.Roster == "D" );
            int totalvisits = db.Visits.Count ( );
            int singlevisits = db.Visits.Count ( v => v.VisitNumber == 1 );
            int multivisits = db.Visits.Count ( v => v.VisitNumber > 1 );
            int parkrdvisits = db.Visits.Count ( v => v.Discharged < new DateTime ( 2011, 06, 05 ) );
            int no_returns = db.Visits.Count ( v => !v.CanReturn && ! v.Deceased && !v.DischargeReason.Contains("No Show"));

            label_CurrentCount.Text = ( currentcount > 9 ) ? $"{currentcount,9:N0} Current Guests" : $"{currentcount,10:N0} Current Guests";
            label_DischargedCount.Text = $"{dischcount,7:N0} Discharged Guests";
            label_MultiVisits.Text = $"{multivisits,8:N0} Guests Here More Than Once";
            label_SingleVisits.Text = $"{singlevisits,7:N0} Total Guests";
            label_TotalVisits.Text = $"{totalvisits,7:N0} Total Guest Visits";
            label_ParkRoadVisits.Text = $"{parkrdvisits,8:N0} Park Road Guest Visits";
            label_NoReturnCount.Text = $"{no_returns,8:N0} Guests Ineligible to Return";
            Version myver = new Version ( );
            myver = typeof ( SHGuestsNGen ).Assembly.GetName ( ).Version;
            String [ ] cmd_line = Environment.GetCommandLineArgs ( );
            String cmd_ln = String.Join ( "", cmd_line );
            string filepath = Path.GetFileNameWithoutExtension ( cmd_ln );
            toolStripStatusLabel_statusLabel.Text = $"Program: {filepath} Version {myver.Major}.{myver.Minor}.{myver.MajorRevision}.{myver.MinorRevision} " +
                                                    $"Database: {dal.connection.Database}";
            statusStrip_mainStatusStrip.Update ( );
            statusStrip_mainStatusStrip.Show ( );
            this.Update ( );
            return;
        }

        public void Load_the_ComboBoxes ( )
        {
            comboBox_Currents.Items.Clear ( );
            comboBox_Dischargeds.Items.Clear ( );
            current_combo = new List<string> ( );
            discharged_combo = new List<string> ( );
            theGuestList = dal.GuestsAlphabetically ( );
            foreach (Guest item in theGuestList)
            {
                string Name = string.Concat ( item.LastName, ", ", item.FirstName );
                string Guestid = item.GuestID.ToString ( "00000" );
                foreach (Visit v in item.Visits1)
                {
                    switch (v.Roster)
                    {
                        case "C":
                            current_combo.Add ( string.Concat ( Name, ", ", Guestid, ", ", v.VisitNumber.ToString ( ) ) );
                            break;

                        case "D":
                            discharged_combo.Add ( string.Concat ( Name, ", ", Guestid, ", ", v.VisitNumber.ToString ( ), ", ",
                                ( v.CanReturn ) ? "Yes" : "No " ) );
                            break;

                        default:
                            break;
                    }
                }
            }
            foreach (string st in current_combo)
            {
                comboBox_Currents.Items.Add ( st );
            }
            foreach (string st in discharged_combo)
            {
                comboBox_Dischargeds.Items.Add ( st );
            }
        }

        #endregion Form Loading

        #region Event Handlers

        #region Non-Report Menu Selections

        private void aboutToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            //Console.WriteLine ( $"{DateTime.UtcNow.ToString("u")} About Item on Menu Selected" );
            About_this_App ata = new About_this_App ( );
            Hide ( );
            ata.ShowDialog ( );
            Show ( );
            return;
        }

        private void addANewGuestToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            bool readmit = false;
            Add_Current_Guest add_guest = new Add_Current_Guest ( readmit, 0 );
            Hide ( );
            add_guest.ShowDialog ( );
            add_guest.Close ( );
            Load_the_ComboBoxes ( );
            Refresh ( );
            Show ( );
            return;
        }

        private void toolStripMenuItem_AddFormerGuest_Click ( object sender, EventArgs e )
        {
            DialogResult res = MessageBox.Show ( "This should only be used for a former guest is not yet on the database." + Environment.NewLine +
                                                 "For an existing guest, Re Admit and then discharge",
                                                 "Information",
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxIcon.Information );
            if (res == DialogResult.OK)
            {
                SHGuestAdd shga = new SHGuestAdd ( );
                Hide ( );
                shga.ShowDialog ( );
                Show ( );
            }
            return;
        }

        #endregion Non-Report Menu Selections

        #region ComboBox Selections

        private void comboBox_Currents_SelectedIndexChanged ( object sender, EventArgs e )
        {
            string dlg_header_str = null;
            string [ ] pass_parms = null;
            string [ ] delimiter = { ", " };
            string selected = comboBox_Currents.GetItemText ( comboBox_Currents.SelectedItem );
            int count = 4;
            // Passed Parameters are as follow: [0] = Last Name, [1] = First Name, [2] = Date of
            // Birth, [3] = Number of Visits 3rd level of key to table
            pass_parms = selected.Split ( delimiter, count, System.StringSplitOptions.None );
            string guestID = pass_parms [ 2 ];
            string last_name = pass_parms [ 0 ];
            string first_name = pass_parms [ 1 ];
            string visit_num = pass_parms [ 3 ];
            int.TryParse ( guestID, out int GiD );
            int.TryParse ( visit_num, out int visit_int );
            dlg_header_str = DateTime.Now.ToString ( "dddd, MMMM dd, yyyy @ HH:mm" );
            current_guest_display cgd = new current_guest_display ( GiD, visit_int, dlg_header_str );
            Hide ( );
            cgd.ShowDialog ( );
            Load_the_ComboBoxes ( );
            Refresh ( );
            Show ( );
            return;
        }

        private void comboBox_Dischargeds_SelectedIndexChanged ( object sender, EventArgs e )
        {
            string dlg_header_str = null;
            string [ ] pass_parms = null;
            string [ ] delimiter = { ", " };
            string selected = comboBox_Dischargeds.GetItemText ( comboBox_Dischargeds.SelectedItem );
            int count = 5;
            // Passed Parameters are as follow: [0] = Last Name, [1] = First Name, [2] = Date of
            // Birth, [3] = Number of Visits 3rd level of key to table
            pass_parms = selected.Split ( delimiter, count, System.StringSplitOptions.None );
            string guestID = pass_parms [ 2 ];
            string last_name = pass_parms [ 0 ];
            string first_name = pass_parms [ 1 ];
            string visit_num = pass_parms [ 3 ];
            int.TryParse ( guestID, out int GiD );
            int.TryParse ( visit_num, out int visit_int );
            dlg_header_str = DateTime.Now.ToString ( "dddd, MMMM dd, yyyy @ HH:mm" );
            SHGuestDisplay gd = new SHGuestDisplay ( GiD, visit_int, dlg_header_str );
            Hide ( );
            gd.ShowDialog ( );
            Load_the_ComboBoxes ( );
            Refresh ( );
            Show ( );
            return;
        }

        #endregion ComboBox Selections

        #region SQL Pivot Reporting (Native SQL Queries)

        private void monthlyAdmissionsToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            FileInfo sql_file = new FileInfo ( "admits_by_month.sql" );
            string str_sql = sql_file.OpenText ( ).ReadToEnd ( );
            using (var db = new NextGenEntity ( ))
            {
                SqlConnection en_conn = new SqlConnection ( db.Database.Connection.ConnectionString );
                if (en_conn.State != ConnectionState.Open)
                {
                    en_conn.Open ( );
                }
                SqlCommand sql_cmnd = new SqlCommand ( str_sql, en_conn );
                SqlDataAdapter sql_da = new SqlDataAdapter ( str_sql, en_conn );
                DataTable sql_dt = new DataTable ( );
                sql_da.SelectCommand = sql_cmnd;
                sql_da.Fill ( sql_dt );
                DataTableReader sql_dtr = sql_dt.CreateDataReader ( );
                if (sql_dtr.HasRows)
                {
                    SQLPivotTableForm sptf = new SQLPivotTableForm ( sql_dt, sql_dtr );
                    string query_title = $"Samaritan House Monthly Admissions Since 06/05/2011 as of: {DateTime.Today.ToString ( "MM/dd/yyyy" )}";
                    sptf.report_type = pivot_rpt_type.MonthlyReport;
                    sptf.Text = query_title;
                    sptf.referring_switch = true;
                    Hide ( );
                    sptf.ShowDialog ( );
                    Show ( );
                    sql_dtr.Close ( );
                }
                en_conn.Close ( );
            }
            return;
        }

        private void annualAdmissionsToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            FileInfo sql_file = new FileInfo ( "admit_by_months.sql" );
            string str_sql = sql_file.OpenText ( ).ReadToEnd ( );
            using (var db = new NextGenEntity ( ))
            {
                SqlConnection en_conn = new SqlConnection ( db.Database.Connection.ConnectionString );
                if (en_conn.State != ConnectionState.Open)
                {
                    en_conn.Open ( );
                }
                SqlCommand sql_cmnd = new SqlCommand ( str_sql, en_conn );
                SqlDataAdapter sql_da = new SqlDataAdapter ( str_sql, en_conn );
                DataTable sql_dt = new DataTable ( );
                sql_da.SelectCommand = sql_cmnd;
                sql_da.Fill ( sql_dt );
                DataTableReader sql_dtr = sql_dt.CreateDataReader ( );
                if (sql_dtr.HasRows)
                {
                    SQLPivotTableForm sptf = new SQLPivotTableForm ( sql_dt, sql_dtr );
                    string query_title = $"Samaritan House Yearly Admissions Since 06/05/2011 as of: {DateTime.Today.ToString ( "MM/dd/yyyy" )}";
                    sptf.report_type = pivot_rpt_type.Normal;
                    sptf.Text = query_title;
                    sptf.referring_switch = true;
                    Hide ( );
                    sptf.ShowDialog ( );
                    Show ( );
                    sql_dtr.Close ( );
                }
                en_conn.Close ( );
            }
            return;
        }

        private void monthlyDischargesToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            FileInfo sql_file = new FileInfo ( "discharges_by_month.sql" );
            string str_sql = sql_file.OpenText ( ).ReadToEnd ( );
            using (var db = new NextGenEntity ( ))
            {
                SqlConnection en_conn = new SqlConnection ( db.Database.Connection.ConnectionString );
                if (en_conn.State != ConnectionState.Open)
                {
                    en_conn.Open ( );
                }
                SqlCommand sql_cmnd = new SqlCommand ( str_sql, en_conn );
                SqlDataAdapter sql_da = new SqlDataAdapter ( str_sql, en_conn );
                DataTable sql_dt = new DataTable ( );
                sql_da.SelectCommand = sql_cmnd;
                sql_da.Fill ( sql_dt );
                DataTableReader sql_dtr = sql_dt.CreateDataReader ( );
                if (sql_dtr.HasRows)
                {
                    SQLPivotTableForm sptf = new SQLPivotTableForm ( sql_dt, sql_dtr );
                    string query_title = $"Samaritan House Yearly Discharges SInce 06/05/2011 as of: {DateTime.Today.ToString ( "MM/dd/yyyy" )}";
                    sptf.report_type = pivot_rpt_type.MonthlyReport;
                    sptf.Text = query_title;
                    sptf.referring_switch = true;
                    Hide ( );
                    sptf.ShowDialog ( );
                    Show ( );
                    sql_dtr.Close ( );
                }
                en_conn.Close ( );
            }
            return;
        }

        private void annualDischargesToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            FileInfo sql_file = new FileInfo ( "discharges_by_months.sql" );
            string str_sql = sql_file.OpenText ( ).ReadToEnd ( );
            using (var db = new NextGenEntity ( ))
            {
                SqlConnection en_conn = new SqlConnection ( db.Database.Connection.ConnectionString );
                if (en_conn.State != ConnectionState.Open)
                {
                    en_conn.Open ( );
                }
                SqlCommand sql_cmnd = new SqlCommand ( str_sql, en_conn );
                SqlDataAdapter sql_da = new SqlDataAdapter ( str_sql, en_conn );
                DataTable sql_dt = new DataTable ( );
                sql_da.SelectCommand = sql_cmnd;
                sql_da.Fill ( sql_dt );
                DataTableReader sql_dtr = sql_dt.CreateDataReader ( );
                if (sql_dtr.HasRows)
                {
                    SQLPivotTableForm sptf = new SQLPivotTableForm ( sql_dt, sql_dtr );
                    string query_title = $"Samaritan House Yearly Discharges by Month Since 06/05/2011 as of: {DateTime.Today.ToString ( "MM/dd/yyyy" )}";
                    sptf.report_type = pivot_rpt_type.Normal;
                    sptf.Text = query_title;
                    sptf.referring_switch = true;
                    Hide ( );
                    sptf.ShowDialog ( );
                    Show ( );
                    sql_dtr.Close ( );
                }
                en_conn.Close ( );
            }
            return;
        }

        private void agencyAnnualAdmissionsToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            FileInfo sql_file = new FileInfo ( "agency_admissions_by_year.sql" );
            string str_sql = sql_file.OpenText ( ).ReadToEnd ( );
            using (var db = new NextGenEntity ( ))
            {
                SqlConnection en_conn = new SqlConnection ( db.Database.Connection.ConnectionString );
                if (en_conn.State != ConnectionState.Open)
                {
                    en_conn.Open ( );
                }
                SqlCommand sql_cmnd = new SqlCommand ( str_sql, en_conn );
                SqlDataAdapter sql_da = new SqlDataAdapter ( str_sql, en_conn );
                DataTable sql_dt = new DataTable ( );
                sql_da.SelectCommand = sql_cmnd;
                sql_da.Fill ( sql_dt );
                DataTableReader sql_dtr = sql_dt.CreateDataReader ( );
                if (sql_dtr.HasRows)
                {
                    SQLPivotTableForm sptf = new SQLPivotTableForm ( sql_dt, sql_dtr );
                    string query_title = $"Samaritan House Admissions by Hospital Since 06/05/2011 as of: {DateTime.Today.ToString ( "MM/dd/yyyy" )}";
                    sptf.report_type = pivot_rpt_type.Normal;
                    sptf.Text = query_title;
                    sptf.referring_switch = true;
                    Hide ( );
                    sptf.ShowDialog ( );
                    Show ( );
                    sql_dtr.Close ( );
                }
                en_conn.Close ( );
            }
            return;
        }

        private void agencySocialWorkerAnnualAdmissionsToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            FileInfo sql_file = new FileInfo ( "annual_worker_admissions.sql" );
            string str_sql = sql_file.OpenText ( ).ReadToEnd ( );
            using (var db = new NextGenEntity ( ))
            {
                SqlConnection en_conn = new SqlConnection ( db.Database.Connection.ConnectionString );
                if (en_conn.State != ConnectionState.Open)
                {
                    en_conn.Open ( );
                }
                SqlCommand sql_cmnd = new SqlCommand ( str_sql, en_conn );
                SqlDataAdapter sql_da = new SqlDataAdapter ( str_sql, en_conn );
                DataTable sql_dt = new DataTable ( );
                sql_da.SelectCommand = sql_cmnd;
                sql_da.Fill ( sql_dt );
                DataTableReader sql_dtr = sql_dt.CreateDataReader ( );
                if (sql_dtr.HasRows)
                {
                    SQLPivotTableForm sptf = new SQLPivotTableForm ( sql_dt, sql_dtr );
                    string query_title = $"Samaritan House Yearly Admissions by Agency and Social Worker Since 06-05-2011 as of: {DateTime.Today:D}";
                    sptf.report_type = pivot_rpt_type.Worker;
                    sptf.Text = query_title;
                    sptf.referring_switch = false;
                    Hide ( );
                    sptf.ShowDialog ( );
                    Show ( );
                    sql_dtr.Close ( );
                }
                en_conn.Close ( );
            }
            return;
        }

        private void socialWorkerCanReturnReportToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            FileInfo sql_file = new FileInfo ( "sw_returns_report.sql" );
            string str_sql = sql_file.OpenText ( ).ReadToEnd ( );
            using (var db = new NextGenEntity ( ))
            {
                SqlConnection en_conn = new SqlConnection ( db.Database.Connection.ConnectionString );
                if (en_conn.State != ConnectionState.Open)
                {
                    en_conn.Open ( );
                }
                SqlCommand sql_cmnd = new SqlCommand ( str_sql, en_conn );
                SqlDataAdapter sql_da = new SqlDataAdapter ( str_sql, en_conn );
                DataTable sql_dt = new DataTable ( );
                sql_da.SelectCommand = sql_cmnd;
                sql_da.Fill ( sql_dt );
                DataTableReader sql_dtr = sql_dt.CreateDataReader ( );
                if (sql_dtr.HasRows)
                {
                    SQLPivotTableForm sptf = new SQLPivotTableForm ( sql_dt, sql_dtr );
                    string query_title = $"Samaritan House Social Worker Can Return Report as of: {DateTime.Today:D}";
                    sptf.report_type = pivot_rpt_type.Worker;
                    sptf.Text = query_title;
                    sptf.referring_switch = false;
                    Hide ( );
                    sptf.ShowDialog ( );
                    Show ( );
                    sql_dtr.Close ( );
                }
                en_conn.Close ( );
            }
            return;
        }

        #endregion SQL Pivot Reporting (Native SQL Queries)

        #region LINQ Reporting

        private void rosterToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            Func<DateTime, DateTime, int> myMethod = CalcDays;
            DateTime to_Date = DateTime.Today;
            string [ ] colHeadings = new string [ ]
            {
                "InDate", "Name", "Gender", "Reason", "Agency (Worker)", "Bed Days", "Visit"
            };
            Type [ ] colTypes = new Type [ ]
            {
                typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(int), typeof(int)
            };
            DataTable dt = new DataTable ( "roster" );
            for (int i = 0; i < colHeadings.Count ( ); i++)
            {
                dt.Columns.Add ( colHeadings [ i ], colTypes [ i ] );
            }
            using (var db = new NextGenEntity ( ))
            {
                var roster = ( from jd in db.Guests.AsEnumerable ( )
                               join vd in db.Visits on jd.GuestID equals vd.GuestID
                               orderby vd.AdmitDate, jd.LastName, jd.FirstName
                               where vd.Roster == "C"
                               select new
                               {
                                   Admitted = vd.AdmitDate,
                                   Name = string.Concat ( jd.LastName, ", ", jd.FirstName ),
                                   Gender = ( jd.Gender == "M" ) ? "Male" : "Female",
                                   Reason = vd.AdmitReason,
                                   AgencyWorker = string.Concat ( vd.Agency, " (", vd.Worker, ")" ),
                                   Days = myMethod ( DateTime.Today, vd.AdmitDate ),
                                   Visit = vd.VisitNumber
                               } ).ToList ( );
                var new_list = new List<dynamic> ( );
                foreach (var rr in roster)
                {
                    DataRow dr = dt.NewRow ( );
                    dt.Rows.Add ( rr.Admitted, rr.Name, rr.Gender, rr.Reason, rr.AgencyWorker, rr.Days, rr.Visit );
                    new_list.Add ( rr );
                }
                string query_title = $"Samaritan House Current Guest List: {new_list.Count:N0} records as of: {DateTime.Today:D}";
                statistical_report = false;
                ViewReport ( dt, query_title, statistical_report );
            }
        }

        private void guestsHere45DaysToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            Func<DateTime, DateTime, int> myMethod = CalcDays;
            DateTime to_Date = DateTime.Today;

            using (var db = new NextGenEntity ( ))
            {
                var roster = ( from jd in db.Guests.AsEnumerable ( )
                               join vd in db.Visits on jd.GuestID equals vd.GuestID
                               orderby vd.AdmitDate, jd.LastName, jd.FirstName
                               where vd.Roster == "C"
                               select new
                               {
                                   Name = string.Concat ( jd.LastName, ", ", jd.FirstName ),
                                   Gender = ( jd.Gender == "M" ) ? "Male" : "Female",
                                   InDate = vd.AdmitDate,
                                   Days = myMethod ( DateTime.Today, vd.AdmitDate ),
                                   Reason = vd.AdmitReason,
                                   Agency = vd.Agency
                               } ).ToList ( );
                var new_list = new List<dynamic> ( );
                foreach (var rr in roster)
                {
                    if (rr.Days > 44)
                    {
                        new_list.Add ( rr );
                    }
                }
                string query_title = $"Samaritan House Guest with > 45 Days: {new_list.Count:N0} records as of: {DateTime.Today:D}";
                statistical_report = false;
                ViewReport ( new_list, query_title, statistical_report );
            }
            return;
        }

        private void guestWithQuestionableInformationToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            Func<DateTime, DateTime, int> myMethod = CalcDays;
            DateTime to_Date = new DateTime ( 1980, 01, 01 );
            using (var db = new NextGenEntity ( ))
            {
                var roster = ( from jd in db.Guests
                               join vd in db.Visits on jd.GuestID equals vd.GuestID
                               where ( ( vd.Worker.Contains ( "No file" ) || vd.Worker.Contains ( "Signature Ill" ) ) ||
                                      ( jd.SSN == 999999999 || jd.BirthDate == to_Date )
                                      && vd.Roster == "D" )
                               orderby jd.LastName, jd.FirstName, vd.VisitNumber
                               select new
                               {
                                   Name = string.Concat ( jd.LastName, ", ", jd.FirstName ),
                                   BirthDate = jd.BirthDate,
                                   SSNorW7 = jd.SSN,
                                   InDate = vd.AdmitDate,
                                   OutDate = vd.Discharged,
                                   Days = vd.VisitDays,
                                   Agency_Worker = string.Concat ( vd.Agency, " (", vd.Worker, ")" )
                               } ).ToList ( );

                var new_list = new List<dynamic> ( );
                foreach (var item in roster)
                {
                    new_list.Add ( item );
                }
                string query_title = $"Samaritan House Guests with Questionable Information: {new_list.Count:N0} records as of: {DateTime.Today:D}";
                statistical_report = false;
                ViewReport ( new_list, query_title, statistical_report );
            }
            return;
        }

        private void inelegibleForReturnToSamaritanHouseToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            using (var db = new NextGenEntity ( ))
            {
                var roster = ( from jd in db.Guests
                               join vd in db.Visits on jd.GuestID equals vd.GuestID
                               where ( !vd.CanReturn ) && ( !vd.Deceased && !vd.DischargeReason.Contains ( "No Show" ) ) 
                               orderby jd.LastName, jd.FirstName, vd.Discharged
                               select new
                               {
                                   Name = string.Concat ( jd.LastName, ", ", jd.FirstName ),
                                   InDate = vd.AdmitDate,
                                   //InReason = vd.AdmitReason,
                                   OutDate = vd.Discharged,
                                   Days = vd.VisitDays,
                                   OutReason = vd.DischargeReason,
                                   Agency_Worker = string.Concat ( vd.Agency, " (", vd.Worker, ")" )
                               } ).ToList ( );

                var new_list = new List<dynamic> ( );
                foreach (var item in roster)
                {
                    new_list.Add ( item );
                }
                string query_title = $"Samaritan House Guests Ineligible for Return: {new_list.Count:N0} records as of: {DateTime.Today:D}";
                statistical_report = false;
                ViewReport ( new_list, query_title, statistical_report );
            }
            return;
        }

        private void completeGuestListToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            using (var db = new NextGenEntity ( ))
            {
                Func<DateTime, DateTime, int> myMethod = CalcDays;
                DateTime to_Date = DateTime.Today;
                var curr_roster = ( from nc in db.Guests.AsEnumerable ( )
                                    orderby nc.LastName, nc.FirstName
                                    where ( nc.Roster == "D" )
                                    select nc ).ToList ( );

                var new_list = new List<dynamic> ( );
                foreach (var new_item in curr_roster)
                {
                    foreach (Visit vd in new_item.Visits1)
                    {
                        //if (vd.VisitNumber == new_item.Visits)
                        //{
                            var tmp_list = new
                            {
                                Name = string.Concat ( new_item.LastName, ", ", new_item.FirstName ),
                                //Roster = "Discharged",
                                Visit = vd.VisitNumber,
                                Admitted = vd.AdmitDate,
                                Discharged = vd.Discharged,
                                Days = vd.VisitDays,
                                DischargeReason = vd.DischargeReason,
                                Return = ( vd.CanReturn ) ? "Yes" : "No"
                            };
                            new_list.Add ( tmp_list );
                        //}
                    }
                }
                int guest_count = new_list.Count ( nl => nl.Visit == 1 );
                string query_title = $"Samaritan House Discharged Guest Listing of {guest_count:N0} Guests As of: {DateTime.Today:D}"; ;
                statistical_report = false;
                ViewReport ( new_list, query_title, statistical_report );
            }
            return;
        }

        private void roomAssignmentsToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            using (var db = new NextGenEntity ( ))
            {
                Func<DateTime, DateTime, int> myMethod = CalcDays;
                DateTime to_Date = DateTime.Today;
                var roster = ( from jd in db.Guests.AsEnumerable ( )
                               join vd in db.Visits on jd.GuestID equals vd.GuestID
                               orderby vd.Room, vd.Bed
                               where jd.Roster == "C" && vd.Roster == "C"
                               select new
                               {
                                   Room = ( int )vd.Room,
                                   Bed = ( int )vd.Bed,
                                   Name = string.Concat ( jd.LastName, ", ", jd.FirstName ),
                                   Gender = ( jd.Gender == "M" ) ? "Male" : "Female",
                                   InDate = vd.AdmitDate,
                                   Days = myMethod ( DateTime.Today, vd.AdmitDate ),
                                   Reason = vd.AdmitReason,
                                   Agency = vd.Agency
                               } ).ToList ( );

                var new_list = new List<dynamic> ( );
                foreach (var item in roster)
                {
                    new_list.Add ( item );
                }
                string query_title = $"Samaritan House Current Guest Room Assignments As of: {DateTime.Today:D}"; ;
                statistical_report = false;
                ViewReport ( new_list, query_title, statistical_report );
            }
            return;
        }

        private void deceasedGuestsToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            using (var db = new NextGenEntity ( ))
            {
                Func<DateTime, DateTime, int> myMethod = CalcDays;
                DateTime to_Date = DateTime.Today;
                var roster = from jd in db.Guests
                             join vd in db.Visits on jd.GuestID equals vd.GuestID
                             orderby jd.LastName, jd.FirstName
                             where vd.Roster == "D" && vd.Deceased
                             select new
                             {
                                 Name = string.Concat ( jd.LastName, ", ", jd.FirstName ),
                                 Visit = vd.VisitNumber,
                                 InDate = vd.AdmitDate,
                                 OutDate = vd.Discharged,
                                 AdmitReason = vd.AdmitReason,
                                 DischargeReason = vd.DischargeReason
                             };
                var new_list = new List<dynamic> ( );
                foreach (var item in roster)
                {
                    new_list.Add ( item );
                }
                string query_title = $"Samaritan House  - {new_list.Count:N0} Former Guests Listed as Deceased As of: {DateTime.Today:D}"; ;
                statistical_report = false;
                ViewReport ( new_list, query_title, statistical_report );
            }
            return;
        }

        private void totalVisitStatisticsToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            Func<DateTime, DateTime, int> myMethod = CalcDays;
            DateTime to_Date = DateTime.Today;
            using (var db = new NextGenEntity ( ))
            {
                var query4group = ( from v in db.Visits.AsEnumerable ( )
                                    orderby v.Roster, v.VisitNumber
                                    select new
                                    {
                                        Roster = ( v.Roster == "D" ) ? "Discharged" : "Current",
                                        Visit = v.VisitNumber.ToString ( "N0" ),
                                        Days = ( v.Roster == "D" ) ? v.VisitDays : myMethod ( to_Date, v.AdmitDate )
                                    } ).ToList ( );

                var grouped = ( from vd in query4group
                                group vd by new
                                {
                                    vd.Roster,
                                    vd.Visit
                                }
                                into gcs
                                select new
                                {
                                    Roster = gcs.Key.Roster,
                                    Visit = gcs.Key.Visit,
                                    Guests = gcs.Count ( ),
                                    BedDays = gcs.Sum ( v => v.Days ),
                                    Minimum = gcs.Min ( vd => vd.Days ),
                                    Maximum = gcs.Max ( vd => vd.Days ),
                                    Average = gcs.Average ( vd => vd.Days )
                                } ).ToList ( );

                List<dynamic> new_lst = new List<dynamic> ( );
                int j = 0;
                foreach (var item in grouped)
                {
                    if (( item.Roster.Equals ( "Discharged" ) ) && j == 0)
                    {
                        var total_item = new
                        {
                            Roster = "Current Guest",
                            Visit = "Totals",
                            Guests = grouped.Where ( g => g.Roster.Equals ( "Current" ) ).Sum ( tg => tg.Guests ),
                            BedDays = grouped.Where ( g => g.Roster.Equals ( "Current" ) ).Sum ( td => td.BedDays ),
                            Minimum = query4group.Where ( g => g.Roster.Equals ( "Current" ) ).Min ( mn => mn.Days ),
                            Maximum = query4group.Where ( g => g.Roster.Equals ( "Current" ) ).Max ( mx => mx.Days ),
                            Average = query4group.Where ( g => g.Roster.Equals ( "Current" ) ).Average ( av => av.Days )
                        };
                        new_lst.Add ( total_item );
                        j++;
                    }
                    new_lst.Add ( item );
                }
                var totl_item = new
                {
                    Roster = "Discharged Guest",
                    Visit = "Totals",
                    Guests = grouped.Where ( g => g.Roster.Equals ( "Discharged" ) ).Sum ( tg => tg.Guests ),
                    BedDays = grouped.Where ( g => g.Roster.Equals ( "Discharged" ) ).Sum ( td => td.BedDays ),
                    Minimum = query4group.Where ( g => g.Roster.Equals ( "Discharged" ) ).Min ( mn => mn.Days ),
                    Maximum = query4group.Where ( g => g.Roster.Equals ( "Discharged" ) ).Max ( mx => mx.Days ),
                    Average = query4group.Where ( g => g.Roster.Equals ( "Discharged" ) ).Average ( av => av.Days )
                };
                new_lst.Add ( totl_item );
                var totals_item = new
                {
                    Roster = string.Empty,
                    Visit = "Grand Totals",
                    Guests = grouped.Sum ( tg => tg.Guests ),
                    BedDays = grouped.Sum ( td => td.BedDays ),
                    Minimum = query4group.Min ( mn => mn.Days ),
                    Maximum = query4group.Max ( mx => mx.Days ),
                    Average = query4group.Average ( av => av.Days )
                };
                new_lst.Add ( totals_item );

                string query_title = $"Samaritan House Visit Statistics as of: {DateTime.Today:D}";
                statistical_report = true;
                ViewReport ( new_lst, query_title, statistical_report );
            }
                return;
        }

        private void totalBedDaysByRosterAndGenderToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            Func<DateTime, DateTime, int> myMethod = CalcDays;
            DateTime to_Date = DateTime.Today;
            using (var db = new NextGenEntity ( ))
            {
                var query4group = ( from g in db.Guests.AsEnumerable ( )
                                    join v in db.Visits.AsEnumerable ( )
                                    on g.GuestID equals v.GuestID
                                    orderby v.Roster, g.Gender
                                    select new
                                    {
                                        Roster = ( v.Roster == "D" ) ? "Discharged" : "Current",
                                        Gender = ( g.Gender == "M" ) ? "Male" : "Female",
                                        Days = ( v.Roster == "D" ) ? v.VisitDays : myMethod ( to_Date, v.AdmitDate )
                                    } ).ToList ( );

                var grouped = ( from vd in query4group
                                group vd by new
                                {
                                    vd.Roster,
                                    vd.Gender
                                }
                                into gcs
                                select new
                                {
                                    Roster = gcs.Key.Roster,
                                    Gender = gcs.Key.Gender,
                                    Guests = gcs.Count ( ),
                                    BedDays = gcs.Sum ( v => v.Days ),
                                    Minimum = gcs.Min ( vd => vd.Days ),
                                    Maximum = gcs.Max ( vd => vd.Days ),
                                    Average = gcs.Average ( vd => vd.Days )
                                } ).ToList ( );

                List<dynamic> new_lst = new List<dynamic> ( );
                int j = 0;
                foreach (var item in grouped)
                {
                    if (item.Roster.Equals("Discharged") && j == 0)
                    {
                        var tot_item = new
                        {
                            Roster = string.Empty,
                            Gender = "Total",
                            Guests = grouped.Where ( tg => tg.Roster.Equals ( "Current" ) ).Sum ( sg => sg.Guests ),
                            BedDays = grouped.Where ( tg => tg.Roster.Equals ( "Current" ) ).Sum ( sg => sg.BedDays ),
                            Minimum = query4group.Where ( tm => tm.Roster.Equals ( "Current" ) ).Min ( tm => tm.Days ),
                            Maximum = query4group.Where ( tm => tm.Roster.Equals ( "Current" ) ).Max ( tm => tm.Days ),
                            Average = query4group.Where ( tm => tm.Roster.Equals ( "Current" ) ).Average ( tm => tm.Days ),
                        };
                        new_lst.Add ( tot_item );
                        j++;
                    }
                    new_lst.Add ( item );
                }

                var sub_item = new
                {
                    Roster = string.Empty,
                    Gender = "Total",
                    Guests = grouped.Where ( tg => tg.Roster.Equals ( "Discharged" ) ).Sum ( sg => sg.Guests ),
                    BedDays = grouped.Where ( tg => tg.Roster.Equals ( "Discharged" ) ).Sum ( sg => sg.BedDays ),
                    Minimum = query4group.Where ( tm => tm.Roster.Equals ( "Discharged" ) ).Min ( tm => tm.Days ),
                    Maximum = query4group.Where ( tm => tm.Roster.Equals ( "Discharged" ) ).Max ( tm => tm.Days ),
                    Average = query4group.Where ( tm => tm.Roster.Equals ( "Discharged" ) ).Average ( tm => tm.Days ),
                };
                new_lst.Add ( sub_item );

                var totals_item = new
                {
                    Roster = "Grand Total",
                    Gender = string.Empty,
                    Guests = grouped.Sum ( tg => tg.Guests ),
                    BedDays = grouped.Sum ( td => td.BedDays ),
                    Minimum = query4group.Min ( mn => mn.Days ),
                    Maximum = query4group.Max ( mx => mx.Days ),
                    Average = query4group.Average ( av => av.Days )
                };
                new_lst.Add ( totals_item );

                string query_title = $"Samaritan House Bed Days Statistics as of: {DateTime.Today:D}";
                statistical_report = true;
                ViewReport ( new_lst, query_title, statistical_report );
            }
            return;
        }

        private void Social_Worker_Guest_List_Click ( object sender, EventArgs e )
        {
            using (var db = new NextGenEntity ( ))
            {
                Func<DateTime, DateTime, int> myMethod = CalcDays;
                DateTime to_Date = DateTime.Today;
                var roster = ( from g in db.Guests.AsEnumerable ( )
                               join v in db.Visits.AsEnumerable ( )
                               on g.GuestID equals v.GuestID
                               orderby v.Agency, v.Worker, g.LastName, g.FirstName, v.AdmitDate
                               select new
                               {
                                   Agency = v.Agency,
                                   Worker = v.Worker,
                                   Name = string.Concat ( g.LastName, ", ", g.FirstName ),
                                   InDate = v.AdmitDate,
                                   OutDate = v.Discharged,
                                   AdmitReason = v.AdmitReason,
                               } ).ToList ( );

                var new_list = new List<dynamic> ( roster );
                string query_title = $"Samaritan House Social Worker Guest(s) List ({new_list.Count:N0} Records) As of: {DateTime.Today:D}"; ;
                statistical_report = false;
                ViewReport ( new_list, query_title, statistical_report );
            }
            return;

        }

        private void hospitalNoShowsToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            using (var db = new NextGenEntity ( ))
            {
                Func<DateTime, DateTime, int> myMethod = CalcDays;
                DateTime to_Date = DateTime.Today;
                var roster = from jd in db.Guests
                             join vd in db.Visits on jd.GuestID equals vd.GuestID
                             orderby jd.LastName, jd.FirstName
                             where vd.Roster == "D" && vd.DischargeReason.Contains("No Show")
                             select new
                             {
                                 Name = string.Concat ( jd.LastName, ", ", jd.FirstName ),
                                 //Visit = vd.VisitNumber,
                                 InDate = vd.AdmitDate,
                                 OutDate = vd.Discharged,
                                 BedDays = vd.VisitDays,
                                 AdmitReason = vd.AdmitReason,
                                 DischargeReason = vd.DischargeReason
                             };
                var new_list = new List<dynamic> ( );
                foreach (var item in roster)
                {
                    new_list.Add ( item );
                }
                string query_title = $"Samaritan House Hospital No Show List ({new_list.Count:N0} Records) As of: {DateTime.Today:D}"; ;
                statistical_report = false;
                ViewReport ( new_list, query_title, statistical_report );
            }
            return;
        }

        private void guestWalkOffsToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            using (var db = new NextGenEntity ( ))
            {
                Func<DateTime, DateTime, int> myMethod = CalcDays;
                DateTime to_Date = DateTime.Today;
                var roster = from jd in db.Guests
                             join vd in db.Visits on jd.GuestID equals vd.GuestID
                             orderby jd.LastName, jd.FirstName
                             where vd.Roster == "D" && (vd.DischargeReason.Contains ( "Walk off" ) || vd.DischargeReason.Contains("Walked off"))
                             select new
                             {
                                 Name = string.Concat ( jd.LastName, ", ", jd.FirstName ),
                                 //Visit = vd.VisitNumber,
                                 InDate = vd.AdmitDate,
                                 OutDate = vd.Discharged,
                                 BedDays = vd.VisitDays,
                                 AdmitReason = vd.AdmitReason,
                                 DischargeReason = vd.DischargeReason
                             };
                var new_list = new List<dynamic> ( );
                foreach (var item in roster)
                {
                    new_list.Add ( item );
                }
                string query_title = $"Samaritan House Walk-Offs List ({new_list.Count:N0} Records) As of: {DateTime.Today:D}"; ;
                statistical_report = false;
                ViewReport ( new_list, query_title, statistical_report );
            }
            return;
        }

        #endregion LINQ Reporting

        #region Results Reporting

        private void ViewReport ( List<dynamic> theList, string title, bool rpt_type )
        {
            rpt_dlg = new Query_Results ( theList, rpt_type );
            try
            {
                Hide ( );
                num_rows = rpt_dlg.NumberofRows;
                if (num_rows > 0)
                {
                    rpt_dlg.Text = title;
                    rpt_dlg.ShowDialog ( );
                    rpt_dlg.ResetFont ( );
                }
                Show ( );
            }
            catch (Exception exc)
            {
                MessageBox.Show ( "Error " + exc.Message );
            }
            return;
        }

        private void ViewReport ( DataTable theList, string title, bool rpt_type )
        {
            rpt_dlg = new Query_Results ( theList, rpt_type );
            try
            {
                Hide ( );
                num_rows = rpt_dlg.NumberofRows;
                if (num_rows > 0)
                {
                    rpt_dlg.Text = title;
                    rpt_dlg.ShowDialog ( );
                    rpt_dlg.ResetFont ( );
                }
                Show ( );
            }
            catch (Exception exc)
            {
                MessageBox.Show ( "Error " + exc.Message );
            }
            return;
        }

        #endregion Results Reporting

        private void button_QuitApp_Click ( object sender, EventArgs e )
        {
            Application.Exit ( );
        }

        #endregion Event Handlers

        #region My Functions for LINQ

        public int CalcDays ( DateTime from, DateTime to )
        {
            TimeSpan ts = new TimeSpan ( 0, 0, 0 );
            ts = from.AddDays ( 1 ) - to;
            return ts.Days;
        }

        #endregion My Functions for LINQ

        #endregion Methods
    }
}