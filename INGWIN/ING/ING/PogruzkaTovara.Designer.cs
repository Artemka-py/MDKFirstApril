namespace ING
{
    partial class PogruzkaTovara
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
            this.dgPriemka = new System.Windows.Forms.DataGridView();
            this.btBack = new System.Windows.Forms.Button();
            this.nudNomerDog = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgPriemka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNomerDog)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPriemka
            // 
            this.dgPriemka.AllowUserToAddRows = false;
            this.dgPriemka.AllowUserToDeleteRows = false;
            this.dgPriemka.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPriemka.Location = new System.Drawing.Point(13, 13);
            this.dgPriemka.Margin = new System.Windows.Forms.Padding(4);
            this.dgPriemka.Name = "dgPriemka";
            this.dgPriemka.ReadOnly = true;
            this.dgPriemka.Size = new System.Drawing.Size(774, 247);
            this.dgPriemka.TabIndex = 2;
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(687, 409);
            this.btBack.Margin = new System.Windows.Forms.Padding(4);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(100, 28);
            this.btBack.TabIndex = 11;
            this.btBack.Text = "Назад";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // nudNomerDog
            // 
            this.nudNomerDog.Location = new System.Drawing.Point(320, 294);
            this.nudNomerDog.Name = "nudNomerDog";
            this.nudNomerDog.Size = new System.Drawing.Size(120, 23);
            this.nudNomerDog.TabIndex = 12;
            this.nudNomerDog.ValueChanged += new System.EventHandler(this.nudNomerDog_ValueChanged);
            // 
            // PogruzkaTovara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nudNomerDog);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.dgPriemka);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PogruzkaTovara";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Погрузка товара";
            this.Load += new System.EventHandler(this.PogruzkaTovara_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPriemka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNomerDog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPriemka;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.NumericUpDown nudNomerDog;
    }
}