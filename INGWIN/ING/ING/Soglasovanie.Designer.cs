namespace ING
{
    partial class Soglasovanie
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
            this.dgObrabotkaZakaz = new System.Windows.Forms.DataGridView();
            this.btRedakt = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgObrabotkaZakaz)).BeginInit();
            this.SuspendLayout();
            // 
            // dgObrabotkaZakaz
            // 
            this.dgObrabotkaZakaz.AllowUserToAddRows = false;
            this.dgObrabotkaZakaz.AllowUserToDeleteRows = false;
            this.dgObrabotkaZakaz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgObrabotkaZakaz.Location = new System.Drawing.Point(17, 16);
            this.dgObrabotkaZakaz.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dgObrabotkaZakaz.Name = "dgObrabotkaZakaz";
            this.dgObrabotkaZakaz.ReadOnly = true;
            this.dgObrabotkaZakaz.Size = new System.Drawing.Size(769, 246);
            this.dgObrabotkaZakaz.TabIndex = 1;
            // 
            // btRedakt
            // 
            this.btRedakt.Location = new System.Drawing.Point(17, 335);
            this.btRedakt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btRedakt.Name = "btRedakt";
            this.btRedakt.Size = new System.Drawing.Size(196, 44);
            this.btRedakt.TabIndex = 10;
            this.btRedakt.Text = "Редактирования договоров и накладных\r\n\r\n";
            this.btRedakt.UseVisualStyleBackColor = true;
            this.btRedakt.Click += new System.EventHandler(this.btRedakt_Click);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(686, 409);
            this.btBack.Margin = new System.Windows.Forms.Padding(4);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(100, 28);
            this.btBack.TabIndex = 11;
            this.btBack.Text = "Назад";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // Soglasovanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.btRedakt);
            this.Controls.Add(this.dgObrabotkaZakaz);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Soglasovanie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Согласование условий доставки с клиентом";
            this.Load += new System.EventHandler(this.Soglasovanie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgObrabotkaZakaz)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgObrabotkaZakaz;
        private System.Windows.Forms.Button btRedakt;
        private System.Windows.Forms.Button btBack;
    }
}