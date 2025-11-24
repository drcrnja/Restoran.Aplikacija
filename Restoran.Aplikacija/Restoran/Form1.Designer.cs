namespace Restoran
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            Korisnickoime = new TextBox();
            Sifra = new TextBox();
            Potvrdi = new Button();
            Odustani = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Times New Roman", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(275, 47);
            label1.Name = "label1";
            label1.Size = new Size(192, 42);
            label1.TabIndex = 0;
            label1.Text = "Ulogujte se";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(149, 208);
            label2.Name = "label2";
            label2.Size = new Size(152, 25);
            label2.TabIndex = 1;
            label2.Text = "Korisnicko ime";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(214, 251);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 2;
            label3.Text = "Lozinka";
            // 
            // Korisnickoime
            // 
            Korisnickoime.Location = new Point(307, 210);
            Korisnickoime.Name = "Korisnickoime";
            Korisnickoime.Size = new Size(220, 23);
            Korisnickoime.TabIndex = 3;
            // 
            // Sifra
            // 
            Sifra.Location = new Point(307, 251);
            Sifra.Name = "Sifra";
            Sifra.Size = new Size(220, 23);
            Sifra.TabIndex = 4;
            // 
            // Potvrdi
            // 
            Potvrdi.Location = new Point(316, 328);
            Potvrdi.Name = "Potvrdi";
            Potvrdi.Size = new Size(75, 23);
            Potvrdi.TabIndex = 5;
            Potvrdi.Text = "Potvrdi";
            Potvrdi.UseVisualStyleBackColor = true;
            Potvrdi.Click += button1_Click;
            // 
            // Odustani
            // 
            Odustani.Location = new Point(425, 328);
            Odustani.Name = "Odustani";
            Odustani.Size = new Size(75, 23);
            Odustani.TabIndex = 6;
            Odustani.Text = "Odustani";
            Odustani.UseVisualStyleBackColor = true;
            Odustani.Click += Odustani_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(Odustani);
            Controls.Add(Potvrdi);
            Controls.Add(Sifra);
            Controls.Add(Korisnickoime);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox Korisnickoime;
        private TextBox Sifra;
        private Button Potvrdi;
        private Button Odustani;
    }
}
