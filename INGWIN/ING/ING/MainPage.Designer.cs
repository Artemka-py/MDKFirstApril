namespace ING
{
    partial class MainPage
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
            this.tlpMainPage = new System.Windows.Forms.TableLayoutPanel();
            this.btSchetOtZavoda = new System.Windows.Forms.Button();
            this.btObrabotkaZakaza = new System.Windows.Forms.Button();
            this.btSoglasovanie = new System.Windows.Forms.Button();
            this.btPriemTovara = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btPogruzkaTovara = new System.Windows.Forms.Button();
            this.btLogOut = new System.Windows.Forms.Button();
            this.btExitAppl = new System.Windows.Forms.Button();
            this.lblFIO = new System.Windows.Forms.Label();
            this.tlpMainPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMainPage
            // 
            this.tlpMainPage.ColumnCount = 4;
            this.tlpMainPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMainPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMainPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMainPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMainPage.Controls.Add(this.btSchetOtZavoda, 0, 2);
            this.tlpMainPage.Controls.Add(this.btObrabotkaZakaza, 3, 1);
            this.tlpMainPage.Controls.Add(this.btSoglasovanie, 2, 1);
            this.tlpMainPage.Controls.Add(this.btPriemTovara, 1, 1);
            this.tlpMainPage.Controls.Add(this.label1, 0, 0);
            this.tlpMainPage.Controls.Add(this.btPogruzkaTovara, 0, 1);
            this.tlpMainPage.Controls.Add(this.btLogOut, 2, 3);
            this.tlpMainPage.Controls.Add(this.btExitAppl, 3, 3);
            this.tlpMainPage.Controls.Add(this.lblFIO, 1, 3);
            this.tlpMainPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainPage.Location = new System.Drawing.Point(0, 0);
            this.tlpMainPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpMainPage.Name = "tlpMainPage";
            this.tlpMainPage.RowCount = 4;
            this.tlpMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMainPage.Size = new System.Drawing.Size(800, 450);
            this.tlpMainPage.TabIndex = 0;
            // 
            // btSchetOtZavoda
            // 
            this.btSchetOtZavoda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btSchetOtZavoda.Location = new System.Drawing.Point(23, 251);
            this.btSchetOtZavoda.Name = "btSchetOtZavoda";
            this.btSchetOtZavoda.Size = new System.Drawing.Size(153, 57);
            this.btSchetOtZavoda.TabIndex = 5;
            this.btSchetOtZavoda.Text = "Счет от завода";
            this.btSchetOtZavoda.UseVisualStyleBackColor = true;
            this.btSchetOtZavoda.Click += new System.EventHandler(this.btSchetOtZavoda_Click);
            // 
            // btObrabotkaZakaza
            // 
            this.btObrabotkaZakaza.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btObrabotkaZakaza.Location = new System.Drawing.Point(623, 139);
            this.btObrabotkaZakaza.Name = "btObrabotkaZakaza";
            this.btObrabotkaZakaza.Size = new System.Drawing.Size(153, 57);
            this.btObrabotkaZakaza.TabIndex = 4;
            this.btObrabotkaZakaza.Text = "Обработка заказа";
            this.btObrabotkaZakaza.UseVisualStyleBackColor = true;
            this.btObrabotkaZakaza.Click += new System.EventHandler(this.btObrabotkaZakaza_Click);
            // 
            // btSoglasovanie
            // 
            this.btSoglasovanie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btSoglasovanie.Location = new System.Drawing.Point(423, 139);
            this.btSoglasovanie.Name = "btSoglasovanie";
            this.btSoglasovanie.Size = new System.Drawing.Size(153, 57);
            this.btSoglasovanie.TabIndex = 3;
            this.btSoglasovanie.Text = "Согласование";
            this.btSoglasovanie.UseVisualStyleBackColor = true;
            this.btSoglasovanie.Click += new System.EventHandler(this.btSoglasovanie_Click);
            // 
            // btPriemTovara
            // 
            this.btPriemTovara.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btPriemTovara.Location = new System.Drawing.Point(223, 139);
            this.btPriemTovara.Name = "btPriemTovara";
            this.btPriemTovara.Size = new System.Drawing.Size(153, 57);
            this.btPriemTovara.TabIndex = 2;
            this.btPriemTovara.Text = "Прием товара";
            this.btPriemTovara.UseVisualStyleBackColor = true;
            this.btPriemTovara.Click += new System.EventHandler(this.btPriemTovara_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.tlpMainPage.SetColumnSpan(this.label1, 4);
            this.label1.Location = new System.Drawing.Point(341, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Главное меню";
            // 
            // btPogruzkaTovara
            // 
            this.btPogruzkaTovara.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btPogruzkaTovara.Location = new System.Drawing.Point(23, 139);
            this.btPogruzkaTovara.Name = "btPogruzkaTovara";
            this.btPogruzkaTovara.Size = new System.Drawing.Size(153, 57);
            this.btPogruzkaTovara.TabIndex = 1;
            this.btPogruzkaTovara.Text = "Погрузка товара";
            this.btPogruzkaTovara.UseVisualStyleBackColor = true;
            this.btPogruzkaTovara.Click += new System.EventHandler(this.btPogruzkaTovara_Click);
            // 
            // btLogOut
            // 
            this.btLogOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btLogOut.Location = new System.Drawing.Point(423, 364);
            this.btLogOut.Name = "btLogOut";
            this.btLogOut.Size = new System.Drawing.Size(153, 57);
            this.btLogOut.TabIndex = 7;
            this.btLogOut.Text = "Выйти из аккаунта";
            this.btLogOut.UseVisualStyleBackColor = true;
            this.btLogOut.Click += new System.EventHandler(this.btLogOut_Click);
            // 
            // btExitAppl
            // 
            this.btExitAppl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btExitAppl.Location = new System.Drawing.Point(623, 364);
            this.btExitAppl.Name = "btExitAppl";
            this.btExitAppl.Size = new System.Drawing.Size(153, 57);
            this.btExitAppl.TabIndex = 8;
            this.btExitAppl.Text = "Выход из приложения";
            this.btExitAppl.UseVisualStyleBackColor = true;
            this.btExitAppl.Click += new System.EventHandler(this.btExitAppl_Click);
            // 
            // lblFIO
            // 
            this.lblFIO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFIO.AutoSize = true;
            this.lblFIO.Location = new System.Drawing.Point(274, 383);
            this.lblFIO.Name = "lblFIO";
            this.lblFIO.Size = new System.Drawing.Size(51, 20);
            this.lblFIO.TabIndex = 9;
            this.lblFIO.Text = "label2";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpMainPage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная страница";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.tlpMainPage.ResumeLayout(false);
            this.tlpMainPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMainPage;
        private System.Windows.Forms.Button btSchetOtZavoda;
        private System.Windows.Forms.Button btObrabotkaZakaza;
        private System.Windows.Forms.Button btSoglasovanie;
        private System.Windows.Forms.Button btPriemTovara;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btPogruzkaTovara;
        private System.Windows.Forms.Button btLogOut;
        private System.Windows.Forms.Button btExitAppl;
        private System.Windows.Forms.Label lblFIO;
    }
}