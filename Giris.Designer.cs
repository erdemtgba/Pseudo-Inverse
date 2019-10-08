namespace pseudoInverse
{
    partial class Giris
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_random = new System.Windows.Forms.Button();
            this.rich_txt_matris = new System.Windows.Forms.RichTextBox();
            this.btn_mxn = new System.Windows.Forms.Button();
            this.lbl_uyari = new System.Windows.Forms.Label();
            this.lbl_N = new System.Windows.Forms.Label();
            this.lbl_M = new System.Windows.Forms.Label();
            this.txt_N = new System.Windows.Forms.TextBox();
            this.txt_M = new System.Windows.Forms.TextBox();
            this.btn_matris_olustur = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_random
            // 
            this.btn_random.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_random.Location = new System.Drawing.Point(128, 395);
            this.btn_random.Name = "btn_random";
            this.btn_random.Size = new System.Drawing.Size(166, 26);
            this.btn_random.TabIndex = 4;
            this.btn_random.Text = "Random oluştur";
            this.btn_random.UseVisualStyleBackColor = true;
            this.btn_random.Click += new System.EventHandler(this.btn_random_Click);
            // 
            // rich_txt_matris
            // 
            this.rich_txt_matris.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rich_txt_matris.Location = new System.Drawing.Point(12, 12);
            this.rich_txt_matris.Name = "rich_txt_matris";
            this.rich_txt_matris.Size = new System.Drawing.Size(447, 369);
            this.rich_txt_matris.TabIndex = 5;
            this.rich_txt_matris.Text = "";
            // 
            // btn_mxn
            // 
            this.btn_mxn.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mxn.Location = new System.Drawing.Point(578, 51);
            this.btn_mxn.Name = "btn_mxn";
            this.btn_mxn.Size = new System.Drawing.Size(275, 26);
            this.btn_mxn.TabIndex = 6;
            this.btn_mxn.Text = "M(satır) x N(sütun) oluştur";
            this.btn_mxn.UseVisualStyleBackColor = true;
            this.btn_mxn.Click += new System.EventHandler(this.btn_mxn_Click);
            // 
            // lbl_uyari
            // 
            this.lbl_uyari.AutoSize = true;
            this.lbl_uyari.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_uyari.Location = new System.Drawing.Point(478, 395);
            this.lbl_uyari.Name = "lbl_uyari";
            this.lbl_uyari.Size = new System.Drawing.Size(40, 18);
            this.lbl_uyari.TabIndex = 7;
            this.lbl_uyari.Text = "uyarı";
            // 
            // lbl_N
            // 
            this.lbl_N.AutoSize = true;
            this.lbl_N.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_N.Location = new System.Drawing.Point(714, 24);
            this.lbl_N.Name = "lbl_N";
            this.lbl_N.Size = new System.Drawing.Size(33, 18);
            this.lbl_N.TabIndex = 17;
            this.lbl_N.Text = "N : ";
            // 
            // lbl_M
            // 
            this.lbl_M.AutoSize = true;
            this.lbl_M.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_M.Location = new System.Drawing.Point(571, 23);
            this.lbl_M.Name = "lbl_M";
            this.lbl_M.Size = new System.Drawing.Size(31, 18);
            this.lbl_M.TabIndex = 16;
            this.lbl_M.Text = "M :";
            // 
            // txt_N
            // 
            this.txt_N.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_N.Location = new System.Drawing.Point(753, 20);
            this.txt_N.Name = "txt_N";
            this.txt_N.Size = new System.Drawing.Size(100, 25);
            this.txt_N.TabIndex = 15;
            this.txt_N.TextChanged += new System.EventHandler(this.txt_N_TextChanged);
            this.txt_N.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_M_KeyPress);
            // 
            // txt_M
            // 
            this.txt_M.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_M.Location = new System.Drawing.Point(608, 20);
            this.txt_M.Name = "txt_M";
            this.txt_M.Size = new System.Drawing.Size(100, 25);
            this.txt_M.TabIndex = 14;
            this.txt_M.TextChanged += new System.EventHandler(this.txt_M_TextChanged);
            this.txt_M.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_M_KeyPress);
            // 
            // btn_matris_olustur
            // 
            this.btn_matris_olustur.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_matris_olustur.Location = new System.Drawing.Point(578, 329);
            this.btn_matris_olustur.Name = "btn_matris_olustur";
            this.btn_matris_olustur.Size = new System.Drawing.Size(275, 29);
            this.btn_matris_olustur.TabIndex = 20;
            this.btn_matris_olustur.Text = "Matris Oluştur";
            this.btn_matris_olustur.UseVisualStyleBackColor = true;
            this.btn_matris_olustur.Click += new System.EventHandler(this.btn_matris_olustur_Click);
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 446);
            this.Controls.Add(this.btn_matris_olustur);
            this.Controls.Add(this.lbl_N);
            this.Controls.Add(this.lbl_M);
            this.Controls.Add(this.txt_N);
            this.Controls.Add(this.txt_M);
            this.Controls.Add(this.lbl_uyari);
            this.Controls.Add(this.btn_mxn);
            this.Controls.Add(this.rich_txt_matris);
            this.Controls.Add(this.btn_random);
            this.Name = "Giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giris";
            this.Load += new System.EventHandler(this.Giris_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_random;
        private System.Windows.Forms.RichTextBox rich_txt_matris;
        private System.Windows.Forms.Button btn_mxn;
        private System.Windows.Forms.Label lbl_uyari;
        private System.Windows.Forms.Label lbl_N;
        private System.Windows.Forms.Label lbl_M;
        private System.Windows.Forms.TextBox txt_N;
        private System.Windows.Forms.TextBox txt_M;
        private System.Windows.Forms.Button btn_matris_olustur;
    }
}

