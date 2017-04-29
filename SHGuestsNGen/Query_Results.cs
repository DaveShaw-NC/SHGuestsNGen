using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using DataGridPrinter.DataGridPrinter;

namespace SHGuestsNGen
{
    /// <summary>
    /// Description of Query_Results. 
    /// </summary>
    public partial class Query_Results : Form
    {
        #region Variables and Constants

        public int NumberofRows { get; set; }
        public bool stat_rpt;
        public List<dynamic> list_to_view = new List<dynamic> ( );
        public DataGridView results_view1;
        public DataTable dt, view_table = new DataTable ( ), disp_tab2 = new DataTable ( );
        public DataSet dts;
        public DataRow my_rows;
        public DataView my_view;
        public DataTableReader dtr;
        public string p_query = null, tableName = "Tables";
        public string [ ] cols_array;
        public int num_rows_returned = 0, num_cols_returned = 0;

        public Font hdr_font = new Font ( "Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Pixel ),
               cell_font = new Font ( "TImes New Roman", 14F, FontStyle.Regular, GraphicsUnit.Pixel );

        private GridPrinter gp;

        #endregion Variables and Constants

        #region Entry Points 1 List, 1 DataTable

        public Query_Results ( DataTable dt, bool stat_rpt_in )
        {
            // // The InitializeComponent() call is required for Windows Forms designer support.
            stat_rpt = stat_rpt_in;
            NumberofRows = dt.Rows.Count;
            InitializeComponent ( );
            results_view1 = new DataGridView ( );
            results_view1.Location = new Point ( 10, 5 );
            Size this_size = new Size ( );
            this_size = this.Size;
            //*
            //* We must make sure the DataGridView fits into the Main Form
            //*
            results_view1.Size = new Size ( this_size.Width - 40, this_size.Height - 150 );
            results_view1.MaximumSize = new Size ( this_size.Width - 40, this_size.Height - 150 );
            Layout_GridView ( results_view1 );
            this.Controls.Add ( results_view1 );
            results_view1.DataSource = dt;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            quit_the_query_button.ForeColor = Color.Red;
            return;
        }

        public Query_Results ( List<dynamic> dts, bool stat_rpt_in )
        {
            // // The InitializeComponent() call is required for Windows Forms designer support.
            stat_rpt = stat_rpt_in;
            NumberofRows = dts.Count;
            DataTable dt = Extensions.AsDataTable ( dts );
            list_to_view = dts;
            InitializeComponent ( );
            results_view1 = new DataGridView ( );
            results_view1.Location = new Point ( 10, 5 );
            Size this_size = new Size ( );
            this_size = this.Size;
            //*
            //* We must make sure the DataGridView fits into the Main Form
            //*
            results_view1.Size = new Size ( this_size.Width - 40, this_size.Height - 150 );
            results_view1.MaximumSize = new Size ( this_size.Width - 40, this_size.Height - 150 );
            Layout_GridView ( results_view1 );
            this.Controls.Add ( results_view1 );
            results_view1.DataSource = dt;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            quit_the_query_button.ForeColor = Color.Red;
            return;
        }

        #endregion Entry Points 1 List, 1 DataTable

        #region Main Form Load

        private void Query_Results_Load ( object sender, EventArgs e )
        {
            format_the_view ( results_view1 );
            NumberofRows = results_view1.RowCount;
            if (NumberofRows == 0)
            {
                MessageBox.Show ( "Nothing to display." );
                Close ( );
                return;
            }
            results_view1.Select ( );
            return;
        }

        #endregion Main Form Load

        #region Grid View Layout

        private void Layout_GridView ( DataGridView dgv )
        {
            string my_Fontfamily = "Microsoft Sans Serif";
            dgv.AutoGenerateColumns = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = true;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ShowCellToolTips = false;
            dgv.ColumnHeadersHeight = 40;
            dgv.BackgroundColor = Color.LightGray;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font ( my_Fontfamily, 10, FontStyle.Bold, GraphicsUnit.Point );
            dgv.DefaultCellStyle.Font = new Font ( my_Fontfamily, 9, FontStyle.Regular, GraphicsUnit.Point );
            dgv.ScrollBars = ScrollBars.Both;
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            return;
        }

        #endregion Grid View Layout

        #region Format DataGridView

        private void format_the_view ( DataGridView dv_to_fill )
        {
            string view_fn = results_view1.Font.Name;
            float view_fs = results_view1.Font.SizeInPoints;
            GraphicsUnit view_fgu = results_view1.Font.Unit;
            Font bld_font = new Font ( view_fn, view_fs, FontStyle.Bold, view_fgu );

            foreach (DataGridViewColumn col in dv_to_fill.Columns)
            {
                col.MinimumWidth = 50;
                col.FillWeight = 70;
                switch (col.ValueType.ToString ( ))
                {
                    case "System.String":
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                        col.MinimumWidth = 200;
                        col.Resizable = DataGridViewTriState.True;
                        if (col.Name == "Return" || col.Name == "Gender" || col.Name.Contains ( "Retn" ) || col.Name.Contains("Dead") )
                        {
                            col.MinimumWidth = 60;
                            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                            col.Resizable = DataGridViewTriState.False;
                        }
                        if (col.Name.Contains ( "Visit" ))
                        {
                            col.MinimumWidth = 60;
                            col.Resizable = DataGridViewTriState.False;
                            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                        }
                        if (col.Name.Contains ( "Roster" ))
                        {
                            col.MinimumWidth = 60;
                            col.Resizable = DataGridViewTriState.False;
                            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                        }
                        break;

                    case "System.DateTime":
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                        col.DefaultCellStyle.Format = "MM/dd/yyyy";
                        col.MinimumWidth = 30;
                        break;

                    case "System.Int32":
                    case "System.Int":
                    case "System.uint":
                    case "System.Int64":
                        col.DefaultCellStyle.Format = ( col.Name.Contains ( "SSN" ) ) ? "000-00-0000" : "N0";
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                        col.MinimumWidth = 30;
                        break;

                    case "System.Single":
                    case "System.Double":
                    case "System.float":
                        col.DefaultCellStyle.Format = "N4";
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                        col.MinimumWidth = 30;
                        break;

                    case "System.Decimal":
                        col.DefaultCellStyle.Format = "N4";
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                        col.MinimumWidth = 30;
                        break;

                    default:
                        break;
                }
            }
            dv_to_fill.ScrollBars = ScrollBars.Both;
            if (!stat_rpt)
            {
                dv_to_fill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                dv_to_fill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
                dv_to_fill.ScrollBars = ScrollBars.None;
            }
            dv_to_fill.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dv_to_fill.AutoResizeRows ( );
            dv_to_fill.AutoResizeColumns ( );
            dv_to_fill.Height = dv_to_fill.Rows.GetRowsHeight ( DataGridViewElementStates.None ) + dv_to_fill.ColumnHeadersHeight + 2;
            dv_to_fill.Width = dv_to_fill.Columns.GetColumnsWidth ( DataGridViewElementStates.None ) + dv_to_fill.RowHeadersWidth + 2;
            return;
        }

        #endregion Format DataGridView

        private void Quit_the_query_buttonClick ( object sender, EventArgs e )
        {
            Close ( );
        }

        #region Printing Area

        private void printtheDocumentButton_Click ( object sender, EventArgs e )
        {
            if (gp == null)
            {
                gp = new GridPrinter ( results_view1 );
            }
            gp.HeaderText = this.Text;
            gp.HeaderHeightPercent = 5;
            gp.FooterHeightPercent = 5;
            gp.InterSectionSpacingPercent = 2;
            PrintDocument pd = new PrintDocument ( );
            pd.DefaultPageSettings.Landscape = true;
            Font printFont = new Font ( "Microsoft Sans Serif", 10F );
            pd.DefaultPageSettings.Margins = new Margins ( 10, 10, 10, 10 );
            pd.OriginAtMargins = true;
            //pd.PrintPage += new PrintPageEventHandler(printtheDocument_PrintPage);
            PrintPreviewDialog ppDialog = new PrintPreviewDialog ( );
            gp.PrintDocument.DefaultPageSettings.Landscape = true;
            ppDialog.Document = gp.PrintDocument;
            ppDialog.AutoScaleMode = AutoScaleMode.Font;
            ppDialog.UseAntiAlias = true;
            DialogResult res = ppDialog.ShowDialog ( );
            if (res == DialogResult.OK)
            {
                //*pd.PrinterSettings = ppDialog.
                gp.Print ( );
            }
            //GridPrintDocument doc = new GridPrintDocument(results_view1, results_view1.Font, true);
            //doc.DocumentName = this.Text;
            //doc.StepForFit = 0.02f;
            //doc.DefaultPageSettings.Landscape = true;
            //frmPreviewDialog frmDialog = new frmPreviewDialog();
            //frmDialog.ShowUnit = PrinterUnit.TenthsOfAMillimeter;
            //frmDialog.printDocument = doc;
            //frmDialog.ShowDialog(this);
            //frmDialog.Dispose();
            //doc.Dispose();
            return;
        }

        private void printtheDocument_PrintPage ( object sender, PrintPageEventArgs e )
        {
            Font printFont = new Font ( "Arial", 12F );
            StringFormat sf = new StringFormat ( );
            sf.Alignment = StringAlignment.Center;
            string rpt_title = this.Text;
            e.PageSettings.Landscape = true;
            RectangleF rect = new RectangleF ( 0, 0, 1000, 1000 );
            CharacterRange [ ] chars = { new CharacterRange ( 0, rpt_title.Length ) };
            Region [ ] regs = new Region [ 1 ];
            sf.SetMeasurableCharacterRanges ( chars );
            regs = e.Graphics.MeasureCharacterRanges ( rpt_title, printFont, rect, sf );
            SizeF str_size = new SizeF ( rect.Right + 1.0F, rect.Height );
            PointF str_loc = new PointF ( 0F, 0F );
            RectangleF r2 = new RectangleF ( str_loc, str_size );
            e.Graphics.DrawString ( rpt_title, printFont, Brushes.Red, r2, sf );
            PrintToGraphics ( e.Graphics, e.MarginBounds, results_view1 );
            return;
        }

        public void PrintToGraphics ( Graphics graphics, Rectangle bounds, DataGridView lv_in )
        {
            Bitmap bitmap = new Bitmap ( lv_in.Width, lv_in.Height );
            lv_in.DrawToBitmap ( bitmap, new Rectangle ( 0, 0, bitmap.Width, bitmap.Height ) );
            Rectangle target = new Rectangle ( 5, 50, bounds.Width, bounds.Height );
            double xScale = ( double )bitmap.Width / bounds.Width;
            double yScale = ( double )bitmap.Height / bounds.Height;

            if (xScale < yScale)
                target.Width = ( int )( xScale * target.Width / yScale );
            else
                target.Height = ( int )( yScale * target.Height / xScale );

            graphics.PageUnit = GraphicsUnit.Display;
            graphics.DrawImage ( bitmap, target );
        }
    }

    #endregion Printing Area
}