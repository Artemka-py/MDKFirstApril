namespace ING
{
    partial class PriemkaTovara
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
            this.tbcObrabotka = new System.Windows.Forms.TabControl();
            this.tbpTovar = new System.Windows.Forms.TabPage();
            this.dgTovar = new System.Windows.Forms.DataGridView();
            this.tbpTovarnayaNaklad = new System.Windows.Forms.TabPage();
            this.dgTovNakl = new System.Windows.Forms.DataGridView();
            this.btRedakt = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            this.tbcObrabotka.SuspendLayout();
            this.tbpTovar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTovar)).BeginInit();
            this.tbpTovarnayaNaklad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTovNakl)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcObrabotka
            // 
            this.tbcObrabotka.Controls.Add(this.tbpTovar);
            this.tbcObrabotka.Controls.Add(this.tbpTovarnayaNaklad);
            this.tbcObrabotka.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbcObrabotka.Location = new System.Drawing.Point(0, 0);
            this.tbcObrabotka.Name = "tbcObrabotka";
            this.tbcObrabotka.SelectedIndex = 0;
            this.tbcObrabotka.Size = new System.Drawing.Size(1047, 508);
            this.tbcObrabotka.TabIndex = 9;
            // 
            // tbpTovar
            // 
            this.tbpTovar.Controls.Add(this.dgTovar);
            this.tbpTovar.Location = new System.Drawing.Point(4, 25);
            this.tbpTovar.Name = "tbpTovar";
            this.tbpTovar.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTovar.Size = new System.Drawing.Size(1039, 479);
            this.tbpTovar.TabIndex = 0;
            this.tbpTovar.Text = "Товар";
            this.tbpTovar.UseVisualStyleBackColor = true;
            // 
            // dgTovar
            // 
            this.dgTovar.AllowUserToAddRows = false;
            this.dgTovar.AllowUserToDeleteRows = false;
            this.dgTovar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTovar.Location = new System.Drawing.Point(9, 7);
            this.dgTovar.Margin = new System.Windows.Forms.Padding(4);
            this.dgTovar.Name = "dgTovar";
            this.dgTovar.ReadOnly = true;
            this.dgTovar.Size = new System.Drawing.Size(1021, 462);
            this.dgTovar.TabIndex = 0;
            // 
            // tbpTovarnayaNaklad
            // 
            this.tbpTovarnayaNaklad.Controls.Add(this.dgTovNakl);
            this.tbpTovarnayaNaklad.Location = new System.Drawing.Point(4, 25);
            this.tbpTovarnayaNaklad.Name = "tbpTovarnayaNaklad";
            this.tbpTovarnayaNaklad.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTovarnayaNaklad.Size = new System.Drawing.Size(1039, 479);
            this.tbpTovarnayaNaklad.TabIndex = 1;
            this.tbpTovarnayaNaklad.Text = "Товарная накладная";
            this.tbpTovarnayaNaklad.UseVisualStyleBackColor = true;
            // 
            // dgTovNakl
            // 
            this.dgTovNakl.AllowUserToAddRows = false;
            this.dgTovNakl.AllowUserToDeleteRows = false;
            this.dgTovNakl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTovNakl.Location = new System.Drawing.Point(9, 7);
            this.dgTovNakl.Margin = new System.Windows.Forms.Padding(4);
            this.dgTovNakl.Name = "dgTovNakl";
            this.dgTovNakl.ReadOnly = true;
            this.dgTovNakl.Size = new System.Drawing.Size(1021, 462);
            this.dgTovNakl.TabIndex = 2;
            // 
            // btRedakt
            // 
            this.btRedakt.Location = new System.Drawing.Point(85, 573);
            this.btRedakt.Name = "btRedakt";
            this.btRedakt.Size = new System.Drawing.Size(183, 50);
            this.btRedakt.TabIndex = 11;
            this.btRedakt.Text = "Редактирования договоров и накладных\r\n\r\n";
            this.btRedakt.UseVisualStyleBackColor = true;
            this.btRedakt.Click += new System.EventHandler(this.btRedakt_Click);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(934, 646);
            this.btBack.Margin = new System.Windows.Forms.Padding(4);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(100, 28);
            this.btBack.TabIndex = 10;
            this.btBack.Text = "Назад";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click_1);
            // 
            // PriemTovara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 687);
            this.Controls.Add(this.btRedakt);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.tbcObrabotka);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PriemTovara";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Прием товара";
            this.Load += new System.EventHandler(this.PriemTovara_Load);
            this.tbcObrabotka.ResumeLayout(false);
            this.tbpTovar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTovar)).EndInit();
            this.tbpTovarnayaNaklad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTovNakl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcObrabotka;
        private System.Windows.Forms.TabPage tbpTovar;
        private System.Windows.Forms.DataGridView dgTovar;
        private System.Windows.Forms.TabPage tbpTovarnayaNaklad;
        private System.Windows.Forms.DataGridView dgTovNakl;
        private System.Windows.Forms.Button btRedakt;
        private System.Windows.Forms.Button btBack;
    }
}