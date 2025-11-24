namespace Restoran
{
    partial class Pocetna
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            IDRezervacije = new Label();
            Datum = new Label();
            VremeLabel = new Label();
            BrojOsoba = new Label();
            RezervacijaBOX = new TextBox();
            VremeBOX = new TextBox();
            BrojOsobaBOX = new TextBox();
            Izmeni = new Button();
            Unesi = new Button();
            ObrisiRezervaciju = new Button();
            PretraziRezervaciju = new Label();
            PretraziBox = new TextBox();
            DataGridView = new DataGridView();
            Potvrdi = new Button();
            Prikazi = new Button();
            dateTimePicker1 = new DateTimePicker();
            timer1 = new System.Windows.Forms.Timer(components);
            ImeGostaBOX = new TextBox();
            PrezimeGostaBOX = new TextBox();
            ImeGosta = new Label();
            PrezimeGosta = new Label();
            BrojStolalabel = new Label();
            BrojStolaBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(600, 35);
            label1.Name = "label1";
            label1.Size = new Size(300, 31);
            label1.TabIndex = 0;
            label1.Text = "Unos i brisanje rezervacija";
            // 
            // IDRezervacije
            // 
            IDRezervacije.AutoSize = true;
            IDRezervacije.BackColor = SystemColors.AppWorkspace;
            IDRezervacije.Location = new Point(303, 569);
            IDRezervacije.Name = "IDRezervacije";
            IDRezervacije.Size = new Size(103, 20);
            IDRezervacije.TabIndex = 1;
            IDRezervacije.Text = "ID Rezervacije";
            IDRezervacije.Click += label2_Click;
            // 
            // Datum
            // 
            Datum.AutoSize = true;
            Datum.BackColor = SystemColors.ActiveBorder;
            Datum.Location = new Point(494, 569);
            Datum.Name = "Datum";
            Datum.Size = new Size(54, 20);
            Datum.TabIndex = 2;
            Datum.Text = "Datum";
            // 
            // VremeLabel
            // 
            VremeLabel.AutoSize = true;
            VremeLabel.BackColor = SystemColors.ActiveBorder;
            VremeLabel.Location = new Point(683, 569);
            VremeLabel.Name = "VremeLabel";
            VremeLabel.Size = new Size(51, 20);
            VremeLabel.TabIndex = 3;
            VremeLabel.Text = "Vreme";
            VremeLabel.Click += label4_Click;
            // 
            // BrojOsoba
            // 
            BrojOsoba.AutoSize = true;
            BrojOsoba.BackColor = SystemColors.ActiveBorder;
            BrojOsoba.Location = new Point(795, 569);
            BrojOsoba.Name = "BrojOsoba";
            BrojOsoba.Size = new Size(79, 20);
            BrojOsoba.TabIndex = 4;
            BrojOsoba.Text = "BrojOsoba";
            // 
            // RezervacijaBOX
            // 
            RezervacijaBOX.BackColor = SystemColors.HighlightText;
            RezervacijaBOX.Location = new Point(291, 593);
            RezervacijaBOX.Margin = new Padding(3, 4, 3, 4);
            RezervacijaBOX.Name = "RezervacijaBOX";
            RezervacijaBOX.Size = new Size(114, 27);
            RezervacijaBOX.TabIndex = 7;
            // 
            // VremeBOX
            // 
            VremeBOX.Location = new Point(649, 593);
            VremeBOX.Margin = new Padding(3, 4, 3, 4);
            VremeBOX.Name = "VremeBOX";
            VremeBOX.Size = new Size(114, 27);
            VremeBOX.TabIndex = 9;
            // 
            // BrojOsobaBOX
            // 
            BrojOsobaBOX.Location = new Point(777, 593);
            BrojOsobaBOX.Margin = new Padding(3, 4, 3, 4);
            BrojOsobaBOX.Name = "BrojOsobaBOX";
            BrojOsobaBOX.Size = new Size(114, 27);
            BrojOsobaBOX.TabIndex = 10;
            // 
            // Izmeni
            // 
            Izmeni.BackColor = Color.FromArgb(255, 255, 128);
            Izmeni.Location = new Point(678, 653);
            Izmeni.Margin = new Padding(3, 4, 3, 4);
            Izmeni.Name = "Izmeni";
            Izmeni.Size = new Size(86, 31);
            Izmeni.TabIndex = 13;
            Izmeni.Text = "Izmeni";
            Izmeni.UseVisualStyleBackColor = false;
            Izmeni.Click += Izmeni_Click;
            // 
            // Unesi
            // 
            Unesi.BackColor = Color.DodgerBlue;
            Unesi.Location = new Point(334, 653);
            Unesi.Margin = new Padding(3, 4, 3, 4);
            Unesi.Name = "Unesi";
            Unesi.Size = new Size(173, 31);
            Unesi.TabIndex = 14;
            Unesi.Text = "Unesi novu rezervaciju";
            Unesi.UseVisualStyleBackColor = false;
            Unesi.Click += Unesi_Click;
            // 
            // ObrisiRezervaciju
            // 
            ObrisiRezervaciju.BackColor = Color.FromArgb(192, 0, 0);
            ObrisiRezervaciju.Location = new Point(513, 653);
            ObrisiRezervaciju.Margin = new Padding(3, 4, 3, 4);
            ObrisiRezervaciju.Name = "ObrisiRezervaciju";
            ObrisiRezervaciju.Size = new Size(144, 31);
            ObrisiRezervaciju.TabIndex = 15;
            ObrisiRezervaciju.Text = "Obrisi Rezervaciju";
            ObrisiRezervaciju.UseVisualStyleBackColor = false;
            ObrisiRezervaciju.Click += ObrisiRezervaciju_Click;
            // 
            // PretraziRezervaciju
            // 
            PretraziRezervaciju.AutoSize = true;
            PretraziRezervaciju.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PretraziRezervaciju.Location = new Point(34, 23);
            PretraziRezervaciju.Name = "PretraziRezervaciju";
            PretraziRezervaciju.Size = new Size(272, 41);
            PretraziRezervaciju.TabIndex = 16;
            PretraziRezervaciju.Text = "Pretrazi Rezervaciju";
            // 
            // PretraziBox
            // 
            PretraziBox.Location = new Point(14, 69);
            PretraziBox.Margin = new Padding(3, 4, 3, 4);
            PretraziBox.Name = "PretraziBox";
            PretraziBox.Size = new Size(313, 27);
            PretraziBox.TabIndex = 17;
            // 
            // DataGridView
            // 
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(34, 124);
            DataGridView.Margin = new Padding(3, 4, 3, 4);
            DataGridView.Name = "DataGridView";
            DataGridView.RowHeadersWidth = 51;
            DataGridView.Size = new Size(1342, 415);
            DataGridView.TabIndex = 18;
            DataGridView.CellContentClick += DataGrid_CellContentClick;
            // 
            // Potvrdi
            // 
            Potvrdi.Location = new Point(334, 69);
            Potvrdi.Margin = new Padding(3, 4, 3, 4);
            Potvrdi.Name = "Potvrdi";
            Potvrdi.Size = new Size(86, 31);
            Potvrdi.TabIndex = 19;
            Potvrdi.Text = "Potvrdi";
            Potvrdi.UseVisualStyleBackColor = true;
            Potvrdi.Click += Potvrdi_Click;
            // 
            // Prikazi
            // 
            Prikazi.Location = new Point(437, 68);
            Prikazi.Margin = new Padding(3, 4, 3, 4);
            Prikazi.Name = "Prikazi";
            Prikazi.Size = new Size(86, 31);
            Prikazi.TabIndex = 20;
            Prikazi.Text = "Prikazi";
            Prikazi.UseVisualStyleBackColor = true;
            Prikazi.Click += Prikazi_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(413, 593);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(228, 27);
            dateTimePicker1.TabIndex = 21;
            // 
            // ImeGostaBOX
            // 
            ImeGostaBOX.Location = new Point(34, 593);
            ImeGostaBOX.Margin = new Padding(3, 4, 3, 4);
            ImeGostaBOX.Name = "ImeGostaBOX";
            ImeGostaBOX.Size = new Size(114, 27);
            ImeGostaBOX.TabIndex = 22;
            // 
            // PrezimeGostaBOX
            // 
            PrezimeGostaBOX.Location = new Point(170, 593);
            PrezimeGostaBOX.Margin = new Padding(3, 4, 3, 4);
            PrezimeGostaBOX.Name = "PrezimeGostaBOX";
            PrezimeGostaBOX.Size = new Size(114, 27);
            PrezimeGostaBOX.TabIndex = 23;
            // 
            // ImeGosta
            // 
            ImeGosta.AutoSize = true;
            ImeGosta.BackColor = SystemColors.AppWorkspace;
            ImeGosta.Location = new Point(54, 569);
            ImeGosta.Name = "ImeGosta";
            ImeGosta.Size = new Size(72, 20);
            ImeGosta.TabIndex = 24;
            ImeGosta.Text = "ImeGosta";
            // 
            // PrezimeGosta
            // 
            PrezimeGosta.AutoSize = true;
            PrezimeGosta.BackColor = SystemColors.AppWorkspace;
            PrezimeGosta.Location = new Point(170, 569);
            PrezimeGosta.Name = "PrezimeGosta";
            PrezimeGosta.Size = new Size(100, 20);
            PrezimeGosta.TabIndex = 25;
            PrezimeGosta.Text = "PrezimeGosta";
            // 
            // BrojStolalabel
            // 
            BrojStolalabel.AutoSize = true;
            BrojStolalabel.BackColor = SystemColors.ActiveBorder;
            BrojStolalabel.Location = new Point(936, 569);
            BrojStolalabel.Name = "BrojStolalabel";
            BrojStolalabel.Size = new Size(68, 20);
            BrojStolalabel.TabIndex = 27;
            BrojStolalabel.Text = "Brojstola";
            // 
            // BrojStolaBox
            // 
            BrojStolaBox.AllowDrop = true;
            BrojStolaBox.DropDownStyle = ComboBoxStyle.DropDownList;
            BrojStolaBox.FormattingEnabled = true;
            BrojStolaBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            BrojStolaBox.Location = new Point(909, 595);
            BrojStolaBox.Name = "BrojStolaBox";
            BrojStolaBox.Size = new Size(151, 28);
            BrojStolaBox.TabIndex = 28;
            BrojStolaBox.SelectedIndexChanged += BrojStolaBox_SelectedIndexChanged;
            // 
            // Pocetna
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1403, 859);
            Controls.Add(BrojStolaBox);
            Controls.Add(BrojStolalabel);
            Controls.Add(PrezimeGosta);
            Controls.Add(ImeGosta);
            Controls.Add(PrezimeGostaBOX);
            Controls.Add(ImeGostaBOX);
            Controls.Add(dateTimePicker1);
            Controls.Add(Prikazi);
            Controls.Add(Potvrdi);
            Controls.Add(DataGridView);
            Controls.Add(PretraziBox);
            Controls.Add(PretraziRezervaciju);
            Controls.Add(ObrisiRezervaciju);
            Controls.Add(Unesi);
            Controls.Add(Izmeni);
            Controls.Add(BrojOsobaBOX);
            Controls.Add(VremeBOX);
            Controls.Add(RezervacijaBOX);
            Controls.Add(BrojOsoba);
            Controls.Add(VremeLabel);
            Controls.Add(Datum);
            Controls.Add(IDRezervacije);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Pocetna";
            Text = "Pocetna";
            Load += Pocetna_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label IDRezervacije;
        private Label Datum;
        private Label VremeLabel;
        private Label BrojOsoba;
        private TextBox RezervacijaBOX;
        private TextBox VremeBOX;
        private TextBox BrojOsobaBOX;
        private Button Izmeni;
        private Button Unesi;
        private Button ObrisiRezervaciju;
        private Label PretraziRezervaciju;
        private TextBox PretraziBox;
        private DataGridView DataGridView;
        private Button Potvrdi;
        private Button Prikazi;
        private DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Timer timer1;
        private TextBox ImeGostaBOX;
        private TextBox PrezimeGostaBOX;
        private Label ImeGosta;
        private Label PrezimeGosta;
        private Label BrojStolalabel;
        private ComboBox BrojStolaBox;
    }
}