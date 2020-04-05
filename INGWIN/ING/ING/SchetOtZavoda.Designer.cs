namespace ING
{
    partial class SchetOtZavoda
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
            this.dgSchetOtZavoda = new System.Windows.Forms.DataGridView();
            this.btSchetOtZavoda = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgSchetOtZavoda)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSchetOtZavoda
            // 
            this.dgSchetOtZavoda.AllowUserToAddRows = false;
            this.dgSchetOtZavoda.AllowUserToDeleteRows = false;
            this.dgSchetOtZavoda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSchetOtZavoda.Location = new System.Drawing.Point(13, 13);
            this.dgSchetOtZavoda.Margin = new System.Windows.Forms.Padding(4);
            this.dgSchetOtZavoda.Name = "dgSchetOtZavoda";
            this.dgSchetOtZavoda.ReadOnly = true;
            this.dgSchetOtZavoda.Size = new System.Drawing.Size(774, 247);
            this.dgSchetOtZavoda.TabIndex = 1;
            // 
            // btSchetOtZavoda
            // 
            this.btSchetOtZavoda.Location = new System.Drawing.Point(276, 330);
            this.btSchetOtZavoda.Name = "btSchetOtZavoda";
            this.btSchetOtZavoda.Size = new System.Drawing.Size(183, 50);
            this.btSchetOtZavoda.TabIndex = 6;
            this.btSchetOtZavoda.Text = "Обработка заказа";
            this.btSchetOtZavoda.UseVisualStyleBackColor = true;
            this.btSchetOtZavoda.Click += new System.EventHandler(this.btSchetOtZavoda_Click);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(687, 409);
            this.btBack.Margin = new System.Windows.Forms.Padding(4);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(100, 28);
            this.btBack.TabIndex = 7;
            this.btBack.Text = "Назад";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // SchetOtZavoda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.btSchetOtZavoda);
            this.Controls.Add(this.dgSchetOtZavoda);
            this.Name = "SchetOtZavoda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Счет от завода";
            this.Load += new System.EventHandler(this.SchetOtZavoda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSchetOtZavoda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSchetOtZavoda;
        private System.Windows.Forms.Button btSchetOtZavoda;
        private System.Windows.Forms.Button btBack;
    }
}