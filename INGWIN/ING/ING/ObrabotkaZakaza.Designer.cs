namespace ING
{
    partial class ObrabotkaZakaza
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
            this.btBack = new System.Windows.Forms.Button();
            this.dgTovNakl = new System.Windows.Forms.DataGridView();
            this.btSchetOtZavoda = new System.Windows.Forms.Button();
            this.btDogKupProdagProvodka = new System.Windows.Forms.Button();
            this.btTovarNaklProvod = new System.Windows.Forms.Button();
            this.tbcObrabotka = new System.Windows.Forms.TabControl();
            this.tbpDogovorKupli = new System.Windows.Forms.TabPage();
            this.tbpTovarnayaNaklad = new System.Windows.Forms.TabPage();
            this.btRedakt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgObrabotkaZakaz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTovNakl)).BeginInit();
            this.tbcObrabotka.SuspendLayout();
            this.tbpDogovorKupli.SuspendLayout();
            this.tbpTovarnayaNaklad.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgObrabotkaZakaz
            // 
            this.dgObrabotkaZakaz.AllowUserToAddRows = false;
            this.dgObrabotkaZakaz.AllowUserToDeleteRows = false;
            this.dgObrabotkaZakaz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgObrabotkaZakaz.Location = new System.Drawing.Point(9, 7);
            this.dgObrabotkaZakaz.Margin = new System.Windows.Forms.Padding(4);
            this.dgObrabotkaZakaz.Name = "dgObrabotkaZakaz";
            this.dgObrabotkaZakaz.ReadOnly = true;
            this.dgObrabotkaZakaz.Size = new System.Drawing.Size(1021, 462);
            this.dgObrabotkaZakaz.TabIndex = 0;
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(939, 649);
            this.btBack.Margin = new System.Windows.Forms.Padding(4);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(100, 28);
            this.btBack.TabIndex = 1;
            this.btBack.Text = "Назад";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
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
            // btSchetOtZavoda
            // 
            this.btSchetOtZavoda.Location = new System.Drawing.Point(436, 576);
            this.btSchetOtZavoda.Name = "btSchetOtZavoda";
            this.btSchetOtZavoda.Size = new System.Drawing.Size(183, 50);
            this.btSchetOtZavoda.TabIndex = 5;
            this.btSchetOtZavoda.Text = "Счет от завода\r\n";
            this.btSchetOtZavoda.UseVisualStyleBackColor = true;
            this.btSchetOtZavoda.Click += new System.EventHandler(this.btSchetOtZavoda_Click);
            // 
            // btDogKupProdagProvodka
            // 
            this.btDogKupProdagProvodka.Location = new System.Drawing.Point(432, 476);
            this.btDogKupProdagProvodka.Name = "btDogKupProdagProvodka";
            this.btDogKupProdagProvodka.Size = new System.Drawing.Size(183, 50);
            this.btDogKupProdagProvodka.TabIndex = 6;
            this.btDogKupProdagProvodka.Text = "Провести договор купли-продажи";
            this.btDogKupProdagProvodka.UseVisualStyleBackColor = true;
            this.btDogKupProdagProvodka.Click += new System.EventHandler(this.btDogKupProdagProvodka_Click);
            // 
            // btTovarNaklProvod
            // 
            this.btTovarNaklProvod.Location = new System.Drawing.Point(432, 476);
            this.btTovarNaklProvod.Name = "btTovarNaklProvod";
            this.btTovarNaklProvod.Size = new System.Drawing.Size(183, 50);
            this.btTovarNaklProvod.TabIndex = 7;
            this.btTovarNaklProvod.Text = "Провести товарную накладную\r\n";
            this.btTovarNaklProvod.UseVisualStyleBackColor = true;
            this.btTovarNaklProvod.Click += new System.EventHandler(this.btTovarNaklProvod_Click);
            // 
            // tbcObrabotka
            // 
            this.tbcObrabotka.Controls.Add(this.tbpDogovorKupli);
            this.tbcObrabotka.Controls.Add(this.tbpTovarnayaNaklad);
            this.tbcObrabotka.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbcObrabotka.Location = new System.Drawing.Point(0, 0);
            this.tbcObrabotka.Name = "tbcObrabotka";
            this.tbcObrabotka.SelectedIndex = 0;
            this.tbcObrabotka.Size = new System.Drawing.Size(1047, 561);
            this.tbcObrabotka.TabIndex = 8;
            // 
            // tbpDogovorKupli
            // 
            this.tbpDogovorKupli.Controls.Add(this.dgObrabotkaZakaz);
            this.tbpDogovorKupli.Controls.Add(this.btDogKupProdagProvodka);
            this.tbpDogovorKupli.Location = new System.Drawing.Point(4, 25);
            this.tbpDogovorKupli.Name = "tbpDogovorKupli";
            this.tbpDogovorKupli.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDogovorKupli.Size = new System.Drawing.Size(1039, 532);
            this.tbpDogovorKupli.TabIndex = 0;
            this.tbpDogovorKupli.Text = "Договор купли-продажи";
            this.tbpDogovorKupli.UseVisualStyleBackColor = true;
            // 
            // tbpTovarnayaNaklad
            // 
            this.tbpTovarnayaNaklad.Controls.Add(this.dgTovNakl);
            this.tbpTovarnayaNaklad.Controls.Add(this.btTovarNaklProvod);
            this.tbpTovarnayaNaklad.Location = new System.Drawing.Point(4, 25);
            this.tbpTovarnayaNaklad.Name = "tbpTovarnayaNaklad";
            this.tbpTovarnayaNaklad.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTovarnayaNaklad.Size = new System.Drawing.Size(1039, 532);
            this.tbpTovarnayaNaklad.TabIndex = 1;
            this.tbpTovarnayaNaklad.Text = "Товарная накладная";
            this.tbpTovarnayaNaklad.UseVisualStyleBackColor = true;
            // 
            // btRedakt
            // 
            this.btRedakt.Location = new System.Drawing.Point(90, 576);
            this.btRedakt.Name = "btRedakt";
            this.btRedakt.Size = new System.Drawing.Size(183, 50);
            this.btRedakt.TabIndex = 9;
            this.btRedakt.Text = "Редактирования договоров и накладных\r\n\r\n";
            this.btRedakt.UseVisualStyleBackColor = true;
            this.btRedakt.Click += new System.EventHandler(this.btRedakt_Click);
            // 
            // ObrabotkaZakaza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 687);
            this.Controls.Add(this.btRedakt);
            this.Controls.Add(this.tbcObrabotka);
            this.Controls.Add(this.btSchetOtZavoda);
            this.Controls.Add(this.btBack);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ObrabotkaZakaza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Обработка заказа";
            this.Load += new System.EventHandler(this.ObrabotkaZakaza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgObrabotkaZakaz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTovNakl)).EndInit();
            this.tbcObrabotka.ResumeLayout(false);
            this.tbpDogovorKupli.ResumeLayout(false);
            this.tbpTovarnayaNaklad.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgObrabotkaZakaz;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.DataGridView dgTovNakl;
        private System.Windows.Forms.Button btSchetOtZavoda;
        private System.Windows.Forms.Button btDogKupProdagProvodka;
        private System.Windows.Forms.Button btTovarNaklProvod;
        private System.Windows.Forms.TabControl tbcObrabotka;
        private System.Windows.Forms.TabPage tbpDogovorKupli;
        private System.Windows.Forms.TabPage tbpTovarnayaNaklad;
        private System.Windows.Forms.Button btRedakt;
    }
}