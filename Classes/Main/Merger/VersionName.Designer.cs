namespace OsuHelperTool.Classes.Main.Merger
{
    partial class VersionName
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
            this.Label = new System.Windows.Forms.Label();
            this.Ok = new System.Windows.Forms.Button();
            this.VersionNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Location = new System.Drawing.Point(134, 50);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(118, 13);
            this.Label.TabIndex = 0;
            this.Label.Text = "Please insert  Diff name";
            // 
            // Ok
            // 
            this.Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok.Location = new System.Drawing.Point(151, 92);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 1;
            this.Ok.Text = "Proceed...";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // VersionNameTextBox
            // 
            this.VersionNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.VersionNameTextBox.Location = new System.Drawing.Point(102, 66);
            this.VersionNameTextBox.Name = "VersionNameTextBox";
            this.VersionNameTextBox.Size = new System.Drawing.Size(177, 20);
            this.VersionNameTextBox.TabIndex = 2;
            // 
            // VersionName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 176);
            this.Controls.Add(this.VersionNameTextBox);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VersionName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VersionName";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.TextBox VersionNameTextBox;
    }
}