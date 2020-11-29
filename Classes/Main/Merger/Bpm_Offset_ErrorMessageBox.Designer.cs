namespace OsuHelperTool.Classes.Main.Merger
{
    partial class Bpm_Offset_ErrorMessageBox
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
            this.CLBSelectToDelete = new System.Windows.Forms.CheckedListBox();
            this.ErrorMsg = new System.Windows.Forms.Label();
            this.DeleteSelected = new System.Windows.Forms.Button();
            this.ContinueWithoutDelete = new System.Windows.Forms.Button();
            this.tip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CLBSelectToDelete
            // 
            this.CLBSelectToDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CLBSelectToDelete.FormattingEnabled = true;
            this.CLBSelectToDelete.Location = new System.Drawing.Point(12, 54);
            this.CLBSelectToDelete.Name = "CLBSelectToDelete";
            this.CLBSelectToDelete.ScrollAlwaysVisible = true;
            this.CLBSelectToDelete.Size = new System.Drawing.Size(491, 124);
            this.CLBSelectToDelete.TabIndex = 0;
            this.CLBSelectToDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CLBSelectToDelete_KeyDown);
            // 
            // ErrorMsg
            // 
            this.ErrorMsg.AutoSize = true;
            this.ErrorMsg.Location = new System.Drawing.Point(12, 9);
            this.ErrorMsg.Name = "ErrorMsg";
            this.ErrorMsg.Size = new System.Drawing.Size(233, 13);
            this.ErrorMsg.TabIndex = 1;
            this.ErrorMsg.Text = "Would you like to delete any uninherited points?";
            // 
            // DeleteSelected
            // 
            this.DeleteSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteSelected.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.DeleteSelected.Location = new System.Drawing.Point(76, 203);
            this.DeleteSelected.Name = "DeleteSelected";
            this.DeleteSelected.Size = new System.Drawing.Size(101, 39);
            this.DeleteSelected.TabIndex = 2;
            this.DeleteSelected.Text = "Delete Points";
            this.DeleteSelected.UseVisualStyleBackColor = true;
            this.DeleteSelected.Click += new System.EventHandler(this.DeleteSelected_Click);
            // 
            // ContinueWithoutDelete
            // 
            this.ContinueWithoutDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ContinueWithoutDelete.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.ContinueWithoutDelete.Location = new System.Drawing.Point(329, 203);
            this.ContinueWithoutDelete.Name = "ContinueWithoutDelete";
            this.ContinueWithoutDelete.Size = new System.Drawing.Size(136, 39);
            this.ContinueWithoutDelete.TabIndex = 3;
            this.ContinueWithoutDelete.Text = "Continue Without Deleting";
            this.ContinueWithoutDelete.UseVisualStyleBackColor = true;
            this.ContinueWithoutDelete.Click += new System.EventHandler(this.ContinueWithoutDelete_Click);
            // 
            // tip
            // 
            this.tip.AutoSize = true;
            this.tip.Location = new System.Drawing.Point(217, 38);
            this.tip.Name = "tip";
            this.tip.Size = new System.Drawing.Size(286, 13);
            this.tip.TabIndex = 4;
            this.tip.Text = "Tip: You can ctrl + c after selecting to copy the offset value";
            // 
            // Bpm_Offset_ErrorMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 264);
            this.Controls.Add(this.tip);
            this.Controls.Add(this.ContinueWithoutDelete);
            this.Controls.Add(this.DeleteSelected);
            this.Controls.Add(this.ErrorMsg);
            this.Controls.Add(this.CLBSelectToDelete);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Bpm_Offset_ErrorMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Before merging...";
            this.Load += new System.EventHandler(this.Bpm_Offset_ErrorMessageBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox CLBSelectToDelete;
        private System.Windows.Forms.Label ErrorMsg;
        private System.Windows.Forms.Button DeleteSelected;
        private System.Windows.Forms.Button ContinueWithoutDelete;
        private System.Windows.Forms.Label tip;
    }
}