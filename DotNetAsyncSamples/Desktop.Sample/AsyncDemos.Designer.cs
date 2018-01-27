namespace Desktop.Sample
{
    partial class AsyncDemos
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
            this.syncData = new System.Windows.Forms.Button();
            this.AsyncData = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // syncData
            // 
            this.syncData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syncData.Location = new System.Drawing.Point(30, 61);
            this.syncData.Name = "syncData";
            this.syncData.Size = new System.Drawing.Size(301, 120);
            this.syncData.TabIndex = 0;
            this.syncData.Text = "Get Data Sync";
            this.syncData.UseVisualStyleBackColor = true;
            this.syncData.Click += new System.EventHandler(this.syncData_Click);
            // 
            // AsyncData
            // 
            this.AsyncData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AsyncData.Location = new System.Drawing.Point(459, 61);
            this.AsyncData.Name = "AsyncData";
            this.AsyncData.Size = new System.Drawing.Size(301, 120);
            this.AsyncData.TabIndex = 1;
            this.AsyncData.Text = "Get Data Async";
            this.AsyncData.UseVisualStyleBackColor = true;
            this.AsyncData.Click += new System.EventHandler(this.AsyncData_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(30, 267);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(730, 224);
            this.txtLog.TabIndex = 2;
            // 
            // AsyncDemos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 503);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.AsyncData);
            this.Controls.Add(this.syncData);
            this.Name = "AsyncDemos";
            this.Text = "Async Demonstrations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button syncData;
        private System.Windows.Forms.Button AsyncData;
        private System.Windows.Forms.TextBox txtLog;
    }
}

