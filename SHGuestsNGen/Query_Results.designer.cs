/*
 * Created by SharpDevelop.
 * User: DaveShaw
 * Date: 8/26/2014
 * Time: 12:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace NewNextGenGuestsProcess
{
	partial class Query_Results
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Query_Results));
            this.quit_the_query_button = new System.Windows.Forms.Button();
            this.printtheDocumentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // quit_the_query_button
            // 
            resources.ApplyResources(this.quit_the_query_button, "quit_the_query_button");
            this.quit_the_query_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.quit_the_query_button.Name = "quit_the_query_button";
            this.quit_the_query_button.UseVisualStyleBackColor = true;
            this.quit_the_query_button.Click += new System.EventHandler(this.Quit_the_query_buttonClick);
            // 
            // printtheDocumentButton
            // 
            resources.ApplyResources(this.printtheDocumentButton, "printtheDocumentButton");
            this.printtheDocumentButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.printtheDocumentButton.Name = "printtheDocumentButton";
            this.printtheDocumentButton.UseVisualStyleBackColor = true;
            this.printtheDocumentButton.Click += new System.EventHandler(this.printtheDocumentButton_Click);
            // 
            // Query_Results
            // 
            this.AcceptButton = this.quit_the_query_button;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.quit_the_query_button;
            this.Controls.Add(this.printtheDocumentButton);
            this.Controls.Add(this.quit_the_query_button);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Query_Results";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Query_Results_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Button quit_the_query_button;
        private System.Windows.Forms.Button printtheDocumentButton;
    }
}
