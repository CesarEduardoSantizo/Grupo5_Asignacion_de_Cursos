namespace loginadmi
{
    partial class frmFacultades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacultades));
            this.pnl_home = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_codigoedi = new System.Windows.Forms.TextBox();
            this.lbl_edificio = new System.Windows.Forms.Label();
            this.txt_nombresfacu = new System.Windows.Forms.TextBox();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.btn_listaFacu = new System.Windows.Forms.Button();
            this.btn_registrarfacu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCursos = new System.Windows.Forms.Button();
            this.btnInscripcion = new System.Windows.Forms.Button();
            this.btnfacultades = new System.Windows.Forms.Button();
            this.btnNotas = new System.Windows.Forms.Button();
            this.btnCatedratico = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.picInscripcion = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pnl_home.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInscripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_home
            // 
            this.pnl_home.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_home.Controls.Add(this.panel2);
            this.pnl_home.Controls.Add(this.btn_listaFacu);
            this.pnl_home.Controls.Add(this.btn_registrarfacu);
            this.pnl_home.Controls.Add(this.panel1);
            this.pnl_home.Location = new System.Drawing.Point(255, -3);
            this.pnl_home.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_home.Name = "pnl_home";
            this.pnl_home.Size = new System.Drawing.Size(1057, 788);
            this.pnl_home.TabIndex = 101;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Menu;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txt_codigoedi);
            this.panel2.Controls.Add(this.lbl_edificio);
            this.panel2.Controls.Add(this.txt_nombresfacu);
            this.panel2.Controls.Add(this.lbl_nombre);
            this.panel2.Location = new System.Drawing.Point(162, 289);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(733, 192);
            this.panel2.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 29);
            this.label3.TabIndex = 13;
            this.label3.Text = "Datos de la Facultad";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txt_codigoedi
            // 
            this.txt_codigoedi.Location = new System.Drawing.Point(408, 119);
            this.txt_codigoedi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_codigoedi.Multiline = true;
            this.txt_codigoedi.Name = "txt_codigoedi";
            this.txt_codigoedi.Size = new System.Drawing.Size(289, 42);
            this.txt_codigoedi.TabIndex = 11;
            this.txt_codigoedi.TextChanged += new System.EventHandler(this.txt_codigoedi_TextChanged);
            // 
            // lbl_edificio
            // 
            this.lbl_edificio.AutoSize = true;
            this.lbl_edificio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_edificio.Location = new System.Drawing.Point(409, 86);
            this.lbl_edificio.Name = "lbl_edificio";
            this.lbl_edificio.Size = new System.Drawing.Size(173, 25);
            this.lbl_edificio.TabIndex = 2;
            this.lbl_edificio.Text = "Codigo del Edificio";
            this.lbl_edificio.Click += new System.EventHandler(this.lbl_edificio_Click);
            // 
            // txt_nombresfacu
            // 
            this.txt_nombresfacu.Location = new System.Drawing.Point(36, 119);
            this.txt_nombresfacu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_nombresfacu.Multiline = true;
            this.txt_nombresfacu.Name = "txt_nombresfacu";
            this.txt_nombresfacu.Size = new System.Drawing.Size(289, 42);
            this.txt_nombresfacu.TabIndex = 1;
            this.txt_nombresfacu.TextChanged += new System.EventHandler(this.txt_nombresfacu_TextChanged);
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nombre.Location = new System.Drawing.Point(33, 87);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(81, 25);
            this.lbl_nombre.TabIndex = 0;
            this.lbl_nombre.Text = "Nombre";
            // 
            // btn_listaFacu
            // 
            this.btn_listaFacu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btn_listaFacu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_listaFacu.ForeColor = System.Drawing.Color.White;
            this.btn_listaFacu.Location = new System.Drawing.Point(574, 544);
            this.btn_listaFacu.Margin = new System.Windows.Forms.Padding(4);
            this.btn_listaFacu.Name = "btn_listaFacu";
            this.btn_listaFacu.Size = new System.Drawing.Size(261, 66);
            this.btn_listaFacu.TabIndex = 48;
            this.btn_listaFacu.Text = "Lista Facultades";
            this.btn_listaFacu.UseVisualStyleBackColor = false;
            this.btn_listaFacu.Click += new System.EventHandler(this.btn_listaFacu_Click);
            // 
            // btn_registrarfacu
            // 
            this.btn_registrarfacu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btn_registrarfacu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_registrarfacu.ForeColor = System.Drawing.Color.White;
            this.btn_registrarfacu.Location = new System.Drawing.Point(229, 544);
            this.btn_registrarfacu.Margin = new System.Windows.Forms.Padding(4);
            this.btn_registrarfacu.Name = "btn_registrarfacu";
            this.btn_registrarfacu.Size = new System.Drawing.Size(261, 66);
            this.btn_registrarfacu.TabIndex = 47;
            this.btn_registrarfacu.Text = "Registrar Facultad";
            this.btn_registrarfacu.UseVisualStyleBackColor = false;
            this.btn_registrarfacu.Click += new System.EventHandler(this.btn_registrarfacu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-5, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1060, 94);
            this.panel1.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(368, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 69);
            this.label1.TabIndex = 0;
            this.label1.Text = "Facultades";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCursos
            // 
            this.btnCursos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btnCursos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCursos.ForeColor = System.Drawing.Color.White;
            this.btnCursos.Location = new System.Drawing.Point(119, 681);
            this.btnCursos.Margin = new System.Windows.Forms.Padding(4);
            this.btnCursos.Name = "btnCursos";
            this.btnCursos.Size = new System.Drawing.Size(111, 34);
            this.btnCursos.TabIndex = 116;
            this.btnCursos.Text = "Cursos";
            this.btnCursos.UseVisualStyleBackColor = false;
            this.btnCursos.Click += new System.EventHandler(this.btnCursos_Click);
            // 
            // btnInscripcion
            // 
            this.btnInscripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btnInscripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInscripcion.ForeColor = System.Drawing.Color.White;
            this.btnInscripcion.Location = new System.Drawing.Point(119, 607);
            this.btnInscripcion.Margin = new System.Windows.Forms.Padding(4);
            this.btnInscripcion.Name = "btnInscripcion";
            this.btnInscripcion.Size = new System.Drawing.Size(111, 34);
            this.btnInscripcion.TabIndex = 115;
            this.btnInscripcion.Text = "Inscripcion";
            this.btnInscripcion.UseVisualStyleBackColor = false;
            this.btnInscripcion.Click += new System.EventHandler(this.btnInscripcion_Click);
            // 
            // btnfacultades
            // 
            this.btnfacultades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btnfacultades.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfacultades.ForeColor = System.Drawing.Color.White;
            this.btnfacultades.Location = new System.Drawing.Point(119, 528);
            this.btnfacultades.Margin = new System.Windows.Forms.Padding(4);
            this.btnfacultades.Name = "btnfacultades";
            this.btnfacultades.Size = new System.Drawing.Size(111, 34);
            this.btnfacultades.TabIndex = 114;
            this.btnfacultades.Text = "Facultades";
            this.btnfacultades.UseVisualStyleBackColor = false;
            this.btnfacultades.Click += new System.EventHandler(this.btn_facus_Click);
            // 
            // btnNotas
            // 
            this.btnNotas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btnNotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotas.ForeColor = System.Drawing.Color.White;
            this.btnNotas.Location = new System.Drawing.Point(119, 441);
            this.btnNotas.Margin = new System.Windows.Forms.Padding(4);
            this.btnNotas.Name = "btnNotas";
            this.btnNotas.Size = new System.Drawing.Size(111, 34);
            this.btnNotas.TabIndex = 113;
            this.btnNotas.Text = "Notas";
            this.btnNotas.UseVisualStyleBackColor = false;
            this.btnNotas.Click += new System.EventHandler(this.btnNotas_Click);
            // 
            // btnCatedratico
            // 
            this.btnCatedratico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btnCatedratico.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatedratico.ForeColor = System.Drawing.Color.White;
            this.btnCatedratico.Location = new System.Drawing.Point(119, 354);
            this.btnCatedratico.Margin = new System.Windows.Forms.Padding(4);
            this.btnCatedratico.Name = "btnCatedratico";
            this.btnCatedratico.Size = new System.Drawing.Size(111, 34);
            this.btnCatedratico.TabIndex = 112;
            this.btnCatedratico.Text = "Catedratico";
            this.btnCatedratico.UseVisualStyleBackColor = false;
            this.btnCatedratico.Click += new System.EventHandler(this.btnCatedratico_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(119, 271);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(111, 34);
            this.button6.TabIndex = 111;
            this.button6.Text = "Estudiante";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(119, 192);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(111, 34);
            this.button7.TabIndex = 110;
            this.button7.Text = "Inicio";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // pictureBox14
            // 
            this.pictureBox14.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox14.Image")));
            this.pictureBox14.Location = new System.Drawing.Point(27, 340);
            this.pictureBox14.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(67, 62);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox14.TabIndex = 105;
            this.pictureBox14.TabStop = false;
            // 
            // pictureBox15
            // 
            this.pictureBox15.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox15.Image")));
            this.pictureBox15.Location = new System.Drawing.Point(27, 174);
            this.pictureBox15.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(67, 62);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox15.TabIndex = 104;
            this.pictureBox15.TabStop = false;
            // 
            // pictureBox16
            // 
            this.pictureBox16.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox16.Image")));
            this.pictureBox16.Location = new System.Drawing.Point(27, 256);
            this.pictureBox16.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(67, 62);
            this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox16.TabIndex = 103;
            this.pictureBox16.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(45, 13);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(156, 133);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 102;
            this.pictureBox5.TabStop = false;
            // 
            // picInscripcion
            // 
            this.picInscripcion.Image = ((System.Drawing.Image)(resources.GetObject("picInscripcion.Image")));
            this.picInscripcion.Location = new System.Drawing.Point(27, 588);
            this.picInscripcion.Margin = new System.Windows.Forms.Padding(4);
            this.picInscripcion.Name = "picInscripcion";
            this.picInscripcion.Size = new System.Drawing.Size(67, 62);
            this.picInscripcion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picInscripcion.TabIndex = 122;
            this.picInscripcion.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(27, 506);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(67, 62);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 121;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(27, 419);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(67, 62);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 120;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(27, 665);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(67, 62);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 119;
            this.pictureBox8.TabStop = false;
            // 
            // frmFacultades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1312, 783);
            this.Controls.Add(this.picInscripcion);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.btnCursos);
            this.Controls.Add(this.btnInscripcion);
            this.Controls.Add(this.btnfacultades);
            this.Controls.Add(this.btnNotas);
            this.Controls.Add(this.btnCatedratico);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.pictureBox14);
            this.Controls.Add(this.pictureBox15);
            this.Controls.Add(this.pictureBox16);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pnl_home);
            this.MaximizeBox = false;
            this.Name = "frmFacultades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facultades2";
            this.Load += new System.EventHandler(this.Facultades2_Load);
            this.pnl_home.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInscripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_home;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCursos;
        private System.Windows.Forms.Button btnInscripcion;
        private System.Windows.Forms.Button btnfacultades;
        private System.Windows.Forms.Button btnNotas;
        private System.Windows.Forms.Button btnCatedratico;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.PictureBox pictureBox16;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_codigoedi;
        private System.Windows.Forms.Label lbl_edificio;
        private System.Windows.Forms.TextBox txt_nombresfacu;
        private System.Windows.Forms.Label lbl_nombre;
        private System.Windows.Forms.Button btn_listaFacu;
        private System.Windows.Forms.Button btn_registrarfacu;
        private System.Windows.Forms.PictureBox picInscripcion;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
    }
}