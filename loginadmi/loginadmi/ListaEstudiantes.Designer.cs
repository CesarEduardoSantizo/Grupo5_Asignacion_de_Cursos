namespace loginadmi
{
    partial class ListaEstudiantes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaEstudiantes));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_Lista_estudiantes = new System.Windows.Forms.Label();
            this.pnl_home = new System.Windows.Forms.Panel();
            this.btn_EditarEstudiante = new System.Windows.Forms.Button();
            this.list_estudiantes = new System.Windows.Forms.DataGridView();
            this.btn_eliminarEstudiantes = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_usurio = new System.Windows.Forms.Label();
            this.txt_nocarnetestudiante = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picInscripcion = new System.Windows.Forms.PictureBox();
            this.btnCursos = new System.Windows.Forms.Button();
            this.btnInscripcion = new System.Windows.Forms.Button();
            this.btnFacultad = new System.Windows.Forms.Button();
            this.btnNotas = new System.Windows.Forms.Button();
            this.btnCatedratico = new System.Windows.Forms.Button();
            this.btnEstudiantes = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.picFacultades = new System.Windows.Forms.PictureBox();
            this.picNotas = new System.Windows.Forms.PictureBox();
            this.picCursos = new System.Windows.Forms.PictureBox();
            this.picCatedratico = new System.Windows.Forms.PictureBox();
            this.picInicio = new System.Windows.Forms.PictureBox();
            this.picEstudiante = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.pnl_home.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.list_estudiantes)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInscripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFacultades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNotas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCursos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCatedratico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEstudiante)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.panel2.Controls.Add(this.lbl_Lista_estudiantes);
            this.panel2.Location = new System.Drawing.Point(0, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1072, 94);
            this.panel2.TabIndex = 62;
            // 
            // lbl_Lista_estudiantes
            // 
            this.lbl_Lista_estudiantes.AutoSize = true;
            this.lbl_Lista_estudiantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Lista_estudiantes.ForeColor = System.Drawing.Color.White;
            this.lbl_Lista_estudiantes.Location = new System.Drawing.Point(173, 14);
            this.lbl_Lista_estudiantes.Name = "lbl_Lista_estudiantes";
            this.lbl_Lista_estudiantes.Size = new System.Drawing.Size(586, 69);
            this.lbl_Lista_estudiantes.TabIndex = 0;
            this.lbl_Lista_estudiantes.Text = "Lista de Estudiantes";
            this.lbl_Lista_estudiantes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Lista_estudiantes.Click += new System.EventHandler(this.lbl_Lista_estudiantes_Click);
            // 
            // pnl_home
            // 
            this.pnl_home.BackColor = System.Drawing.Color.White;
            this.pnl_home.Controls.Add(this.btn_EditarEstudiante);
            this.pnl_home.Controls.Add(this.list_estudiantes);
            this.pnl_home.Controls.Add(this.btn_eliminarEstudiantes);
            this.pnl_home.Controls.Add(this.panel1);
            this.pnl_home.Controls.Add(this.panel2);
            this.pnl_home.Location = new System.Drawing.Point(241, -2);
            this.pnl_home.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_home.Name = "pnl_home";
            this.pnl_home.Size = new System.Drawing.Size(1072, 788);
            this.pnl_home.TabIndex = 64;
            this.pnl_home.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_home_Paint);
            // 
            // btn_EditarEstudiante
            // 
            this.btn_EditarEstudiante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btn_EditarEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_EditarEstudiante.ForeColor = System.Drawing.Color.White;
            this.btn_EditarEstudiante.Location = new System.Drawing.Point(527, 690);
            this.btn_EditarEstudiante.Margin = new System.Windows.Forms.Padding(4);
            this.btn_EditarEstudiante.Name = "btn_EditarEstudiante";
            this.btn_EditarEstudiante.Size = new System.Drawing.Size(261, 66);
            this.btn_EditarEstudiante.TabIndex = 46;
            this.btn_EditarEstudiante.Text = "Editar Estudiante";
            this.btn_EditarEstudiante.UseVisualStyleBackColor = false;
            this.btn_EditarEstudiante.Click += new System.EventHandler(this.btn_EditarEstudiante_Click);
            // 
            // list_estudiantes
            // 
            this.list_estudiantes.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.list_estudiantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.list_estudiantes.Location = new System.Drawing.Point(76, 160);
            this.list_estudiantes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.list_estudiantes.Name = "list_estudiantes";
            this.list_estudiantes.RowHeadersWidth = 51;
            this.list_estudiantes.RowTemplate.Height = 24;
            this.list_estudiantes.Size = new System.Drawing.Size(903, 430);
            this.list_estudiantes.TabIndex = 45;
            this.list_estudiantes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.list_estudiantes_CellContentClick);
            // 
            // btn_eliminarEstudiantes
            // 
            this.btn_eliminarEstudiantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btn_eliminarEstudiantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminarEstudiantes.ForeColor = System.Drawing.Color.White;
            this.btn_eliminarEstudiantes.Location = new System.Drawing.Point(212, 690);
            this.btn_eliminarEstudiantes.Margin = new System.Windows.Forms.Padding(4);
            this.btn_eliminarEstudiantes.Name = "btn_eliminarEstudiantes";
            this.btn_eliminarEstudiantes.Size = new System.Drawing.Size(261, 66);
            this.btn_eliminarEstudiantes.TabIndex = 44;
            this.btn_eliminarEstudiantes.Text = "Eliminar Estudiante";
            this.btn_eliminarEstudiantes.UseVisualStyleBackColor = false;
            this.btn_eliminarEstudiantes.Click += new System.EventHandler(this.btn_eliminarEstudiantes_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.lbl_usurio);
            this.panel1.Controls.Add(this.txt_nocarnetestudiante);
            this.panel1.Location = new System.Drawing.Point(76, 601);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 82);
            this.panel1.TabIndex = 42;
            // 
            // lbl_usurio
            // 
            this.lbl_usurio.AutoSize = true;
            this.lbl_usurio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_usurio.Location = new System.Drawing.Point(35, 9);
            this.lbl_usurio.Name = "lbl_usurio";
            this.lbl_usurio.Size = new System.Drawing.Size(106, 25);
            this.lbl_usurio.TabIndex = 34;
            this.lbl_usurio.Text = "No. Carnet";
            // 
            // txt_nocarnetestudiante
            // 
            this.txt_nocarnetestudiante.Location = new System.Drawing.Point(39, 36);
            this.txt_nocarnetestudiante.Margin = new System.Windows.Forms.Padding(3, 2, 3, 4);
            this.txt_nocarnetestudiante.Multiline = true;
            this.txt_nocarnetestudiante.Name = "txt_nocarnetestudiante";
            this.txt_nocarnetestudiante.Size = new System.Drawing.Size(289, 42);
            this.txt_nocarnetestudiante.TabIndex = 32;
            this.txt_nocarnetestudiante.TextChanged += new System.EventHandler(this.txt_nocarnetestudiante_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(32, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            // 
            // picInscripcion
            // 
            this.picInscripcion.Image = ((System.Drawing.Image)(resources.GetObject("picInscripcion.Image")));
            this.picInscripcion.Location = new System.Drawing.Point(13, 587);
            this.picInscripcion.Margin = new System.Windows.Forms.Padding(4);
            this.picInscripcion.Name = "picInscripcion";
            this.picInscripcion.Size = new System.Drawing.Size(67, 62);
            this.picInscripcion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picInscripcion.TabIndex = 130;
            this.picInscripcion.TabStop = false;
            // 
            // btnCursos
            // 
            this.btnCursos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btnCursos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCursos.ForeColor = System.Drawing.Color.White;
            this.btnCursos.Location = new System.Drawing.Point(105, 680);
            this.btnCursos.Margin = new System.Windows.Forms.Padding(4);
            this.btnCursos.Name = "btnCursos";
            this.btnCursos.Size = new System.Drawing.Size(111, 34);
            this.btnCursos.TabIndex = 129;
            this.btnCursos.Text = "Cursos";
            this.btnCursos.UseVisualStyleBackColor = false;
            this.btnCursos.Click += new System.EventHandler(this.btnCursos_Click);
            // 
            // btnInscripcion
            // 
            this.btnInscripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btnInscripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInscripcion.ForeColor = System.Drawing.Color.White;
            this.btnInscripcion.Location = new System.Drawing.Point(105, 606);
            this.btnInscripcion.Margin = new System.Windows.Forms.Padding(4);
            this.btnInscripcion.Name = "btnInscripcion";
            this.btnInscripcion.Size = new System.Drawing.Size(111, 34);
            this.btnInscripcion.TabIndex = 128;
            this.btnInscripcion.Text = "Inscripción";
            this.btnInscripcion.UseVisualStyleBackColor = false;
            this.btnInscripcion.Click += new System.EventHandler(this.btnInscripcion_Click);
            // 
            // btnFacultad
            // 
            this.btnFacultad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btnFacultad.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacultad.ForeColor = System.Drawing.Color.White;
            this.btnFacultad.Location = new System.Drawing.Point(105, 527);
            this.btnFacultad.Margin = new System.Windows.Forms.Padding(4);
            this.btnFacultad.Name = "btnFacultad";
            this.btnFacultad.Size = new System.Drawing.Size(111, 34);
            this.btnFacultad.TabIndex = 127;
            this.btnFacultad.Text = "Facultades";
            this.btnFacultad.UseVisualStyleBackColor = false;
            this.btnFacultad.Click += new System.EventHandler(this.btnFacultad_Click);
            // 
            // btnNotas
            // 
            this.btnNotas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btnNotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotas.ForeColor = System.Drawing.Color.White;
            this.btnNotas.Location = new System.Drawing.Point(105, 436);
            this.btnNotas.Margin = new System.Windows.Forms.Padding(4);
            this.btnNotas.Name = "btnNotas";
            this.btnNotas.Size = new System.Drawing.Size(111, 34);
            this.btnNotas.TabIndex = 126;
            this.btnNotas.Text = "Notas";
            this.btnNotas.UseVisualStyleBackColor = false;
            this.btnNotas.Click += new System.EventHandler(this.btnNotas_Click);
            // 
            // btnCatedratico
            // 
            this.btnCatedratico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btnCatedratico.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatedratico.ForeColor = System.Drawing.Color.White;
            this.btnCatedratico.Location = new System.Drawing.Point(105, 348);
            this.btnCatedratico.Margin = new System.Windows.Forms.Padding(4);
            this.btnCatedratico.Name = "btnCatedratico";
            this.btnCatedratico.Size = new System.Drawing.Size(111, 34);
            this.btnCatedratico.TabIndex = 125;
            this.btnCatedratico.Text = "Catedratico";
            this.btnCatedratico.UseVisualStyleBackColor = false;
            this.btnCatedratico.Click += new System.EventHandler(this.btnCatedratico_Click);
            // 
            // btnEstudiantes
            // 
            this.btnEstudiantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btnEstudiantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstudiantes.ForeColor = System.Drawing.Color.White;
            this.btnEstudiantes.Location = new System.Drawing.Point(105, 270);
            this.btnEstudiantes.Margin = new System.Windows.Forms.Padding(4);
            this.btnEstudiantes.Name = "btnEstudiantes";
            this.btnEstudiantes.Size = new System.Drawing.Size(111, 34);
            this.btnEstudiantes.TabIndex = 124;
            this.btnEstudiantes.Text = "Estudiante";
            this.btnEstudiantes.UseVisualStyleBackColor = false;
            this.btnEstudiantes.Click += new System.EventHandler(this.btnEstudiantes_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btnInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.Location = new System.Drawing.Point(105, 191);
            this.btnInicio.Margin = new System.Windows.Forms.Padding(4);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(111, 34);
            this.btnInicio.TabIndex = 123;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // picFacultades
            // 
            this.picFacultades.Image = ((System.Drawing.Image)(resources.GetObject("picFacultades.Image")));
            this.picFacultades.Location = new System.Drawing.Point(13, 509);
            this.picFacultades.Margin = new System.Windows.Forms.Padding(4);
            this.picFacultades.Name = "picFacultades";
            this.picFacultades.Size = new System.Drawing.Size(67, 62);
            this.picFacultades.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFacultades.TabIndex = 122;
            this.picFacultades.TabStop = false;
            // 
            // picNotas
            // 
            this.picNotas.Image = ((System.Drawing.Image)(resources.GetObject("picNotas.Image")));
            this.picNotas.Location = new System.Drawing.Point(13, 422);
            this.picNotas.Margin = new System.Windows.Forms.Padding(4);
            this.picNotas.Name = "picNotas";
            this.picNotas.Size = new System.Drawing.Size(67, 62);
            this.picNotas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNotas.TabIndex = 121;
            this.picNotas.TabStop = false;
            // 
            // picCursos
            // 
            this.picCursos.Image = ((System.Drawing.Image)(resources.GetObject("picCursos.Image")));
            this.picCursos.Location = new System.Drawing.Point(13, 668);
            this.picCursos.Margin = new System.Windows.Forms.Padding(4);
            this.picCursos.Name = "picCursos";
            this.picCursos.Size = new System.Drawing.Size(67, 62);
            this.picCursos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCursos.TabIndex = 120;
            this.picCursos.TabStop = false;
            // 
            // picCatedratico
            // 
            this.picCatedratico.Image = ((System.Drawing.Image)(resources.GetObject("picCatedratico.Image")));
            this.picCatedratico.Location = new System.Drawing.Point(13, 338);
            this.picCatedratico.Margin = new System.Windows.Forms.Padding(4);
            this.picCatedratico.Name = "picCatedratico";
            this.picCatedratico.Size = new System.Drawing.Size(67, 62);
            this.picCatedratico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCatedratico.TabIndex = 119;
            this.picCatedratico.TabStop = false;
            // 
            // picInicio
            // 
            this.picInicio.Image = ((System.Drawing.Image)(resources.GetObject("picInicio.Image")));
            this.picInicio.Location = new System.Drawing.Point(13, 173);
            this.picInicio.Margin = new System.Windows.Forms.Padding(4);
            this.picInicio.Name = "picInicio";
            this.picInicio.Size = new System.Drawing.Size(67, 62);
            this.picInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picInicio.TabIndex = 118;
            this.picInicio.TabStop = false;
            // 
            // picEstudiante
            // 
            this.picEstudiante.Image = ((System.Drawing.Image)(resources.GetObject("picEstudiante.Image")));
            this.picEstudiante.Location = new System.Drawing.Point(13, 255);
            this.picEstudiante.Margin = new System.Windows.Forms.Padding(4);
            this.picEstudiante.Name = "picEstudiante";
            this.picEstudiante.Size = new System.Drawing.Size(67, 62);
            this.picEstudiante.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEstudiante.TabIndex = 117;
            this.picEstudiante.TabStop = false;
            // 
            // ListaEstudiantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1312, 783);
            this.Controls.Add(this.picInscripcion);
            this.Controls.Add(this.btnCursos);
            this.Controls.Add(this.btnInscripcion);
            this.Controls.Add(this.btnFacultad);
            this.Controls.Add(this.btnNotas);
            this.Controls.Add(this.btnCatedratico);
            this.Controls.Add(this.btnEstudiantes);
            this.Controls.Add(this.btnInicio);
            this.Controls.Add(this.picFacultades);
            this.Controls.Add(this.picNotas);
            this.Controls.Add(this.picCursos);
            this.Controls.Add(this.picCatedratico);
            this.Controls.Add(this.picInicio);
            this.Controls.Add(this.picEstudiante);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnl_home);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "ListaEstudiantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListaEstudiantes";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnl_home.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.list_estudiantes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInscripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFacultades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNotas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCursos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCatedratico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEstudiante)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_Lista_estudiantes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnl_home;
        private System.Windows.Forms.Button btn_eliminarEstudiantes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_usurio;
        private System.Windows.Forms.TextBox txt_nocarnetestudiante;
        private System.Windows.Forms.DataGridView list_estudiantes;
        private System.Windows.Forms.Button btn_EditarEstudiante;
        private System.Windows.Forms.PictureBox picInscripcion;
        private System.Windows.Forms.Button btnCursos;
        private System.Windows.Forms.Button btnInscripcion;
        private System.Windows.Forms.Button btnFacultad;
        private System.Windows.Forms.Button btnNotas;
        private System.Windows.Forms.Button btnCatedratico;
        private System.Windows.Forms.Button btnEstudiantes;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.PictureBox picFacultades;
        private System.Windows.Forms.PictureBox picNotas;
        private System.Windows.Forms.PictureBox picCursos;
        private System.Windows.Forms.PictureBox picCatedratico;
        private System.Windows.Forms.PictureBox picInicio;
        private System.Windows.Forms.PictureBox picEstudiante;
    }
}