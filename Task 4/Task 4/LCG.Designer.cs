namespace somaya_mod4
{
    partial class LCG
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
            this.components = new System.ComponentModel.Container();
            this.cycle_label = new System.Windows.Forms.Label();
            this.cycle_text = new System.Windows.Forms.TextBox();
            this.num_iterations = new System.Windows.Forms.Label();
            this.iter_num_text = new System.Windows.Forms.TextBox();
            this.mod = new System.Windows.Forms.Label();
            this.mod_text = new System.Windows.Forms.TextBox();
            this.increment = new System.Windows.Forms.Label();
            this.increment_text = new System.Windows.Forms.TextBox();
            this.seed = new System.Windows.Forms.Label();
            this.seed_text = new System.Windows.Forms.TextBox();
            this.multiplier_label = new System.Windows.Forms.Label();
            this.mul_text = new System.Windows.Forms.TextBox();
            this.generate_button = new System.Windows.Forms.Button();
            this.randomNumberBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.algorithmBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.random_num = new System.Windows.Forms.DataGridView();
            this.algorithmBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.randomNumberBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.algorithmBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.random_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.algorithmBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // cycle_label
            // 
            this.cycle_label.AutoSize = true;
            this.cycle_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cycle_label.Location = new System.Drawing.Point(376, 255);
            this.cycle_label.Name = "cycle_label";
            this.cycle_label.Size = new System.Drawing.Size(72, 19);
            this.cycle_label.TabIndex = 26;
            this.cycle_label.Text = "# Cycles";
            // 
            // cycle_text
            // 
            this.cycle_text.Location = new System.Drawing.Point(471, 253);
            this.cycle_text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cycle_text.Name = "cycle_text";
            this.cycle_text.ReadOnly = true;
            this.cycle_text.Size = new System.Drawing.Size(151, 28);
            this.cycle_text.TabIndex = 25;
            // 
            // num_iterations
            // 
            this.num_iterations.AutoSize = true;
            this.num_iterations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.num_iterations.Location = new System.Drawing.Point(44, 366);
            this.num_iterations.Name = "num_iterations";
            this.num_iterations.Size = new System.Drawing.Size(91, 19);
            this.num_iterations.TabIndex = 24;
            this.num_iterations.Text = "# Iterations";
            // 
            // iter_num_text
            // 
            this.iter_num_text.Location = new System.Drawing.Point(141, 364);
            this.iter_num_text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iter_num_text.Name = "iter_num_text";
            this.iter_num_text.Size = new System.Drawing.Size(151, 28);
            this.iter_num_text.TabIndex = 23;
            // 
            // mod
            // 
            this.mod.AutoSize = true;
            this.mod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mod.Location = new System.Drawing.Point(44, 300);
            this.mod.Name = "mod";
            this.mod.Size = new System.Drawing.Size(73, 19);
            this.mod.TabIndex = 22;
            this.mod.Text = "Modulus";
            // 
            // mod_text
            // 
            this.mod_text.Location = new System.Drawing.Point(141, 298);
            this.mod_text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mod_text.Name = "mod_text";
            this.mod_text.Size = new System.Drawing.Size(151, 28);
            this.mod_text.TabIndex = 21;
            // 
            // increment
            // 
            this.increment.AutoSize = true;
            this.increment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.increment.Location = new System.Drawing.Point(44, 231);
            this.increment.Name = "increment";
            this.increment.Size = new System.Drawing.Size(82, 19);
            this.increment.TabIndex = 20;
            this.increment.Text = "Increment";
            // 
            // increment_text
            // 
            this.increment_text.Location = new System.Drawing.Point(141, 227);
            this.increment_text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.increment_text.Name = "increment_text";
            this.increment_text.Size = new System.Drawing.Size(151, 28);
            this.increment_text.TabIndex = 19;
            // 
            // seed
            // 
            this.seed.AutoSize = true;
            this.seed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.seed.Location = new System.Drawing.Point(56, 168);
            this.seed.Name = "seed";
            this.seed.Size = new System.Drawing.Size(44, 19);
            this.seed.TabIndex = 18;
            this.seed.Text = "Seed";
            // 
            // seed_text
            // 
            this.seed_text.Location = new System.Drawing.Point(141, 166);
            this.seed_text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.seed_text.Name = "seed_text";
            this.seed_text.Size = new System.Drawing.Size(151, 28);
            this.seed_text.TabIndex = 17;
            // 
            // multiplier_label
            // 
            this.multiplier_label.AutoSize = true;
            this.multiplier_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.multiplier_label.Location = new System.Drawing.Point(56, 110);
            this.multiplier_label.Name = "multiplier_label";
            this.multiplier_label.Size = new System.Drawing.Size(82, 19);
            this.multiplier_label.TabIndex = 16;
            this.multiplier_label.Text = "Multiplier";
            // 
            // mul_text
            // 
            this.mul_text.Location = new System.Drawing.Point(141, 110);
            this.mul_text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mul_text.Name = "mul_text";
            this.mul_text.Size = new System.Drawing.Size(151, 28);
            this.mul_text.TabIndex = 15;
            // 
            // generate_button
            // 
            this.generate_button.Location = new System.Drawing.Point(282, 432);
            this.generate_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.generate_button.Name = "generate_button";
            this.generate_button.Size = new System.Drawing.Size(196, 60);
            this.generate_button.TabIndex = 14;
            this.generate_button.Text = "Generate numbers";
            this.generate_button.UseVisualStyleBackColor = true;
            this.generate_button.Click += new System.EventHandler(this.generate_button_Click);
            // 
            // randomNumberBindingSource
            // 
            this.randomNumberBindingSource.DataMember = "RandomNumber";
            this.randomNumberBindingSource.DataSource = this.algorithmBindingSource;
            // 
            // algorithmBindingSource
            // 
            this.algorithmBindingSource.DataSource = typeof(Task4.Algorithm);
            // 
            // random_num
            // 
            this.random_num.AllowUserToAddRows = false;
            this.random_num.AllowUserToDeleteRows = false;
            this.random_num.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.random_num.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.random_num.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.random_num.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.random_num.Location = new System.Drawing.Point(665, 14);
            this.random_num.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.random_num.Name = "random_num";
            this.random_num.RowHeadersWidth = 62;
            this.random_num.RowTemplate.Height = 28;
            this.random_num.Size = new System.Drawing.Size(187, 498);
            this.random_num.TabIndex = 27;
            // 
            // algorithmBindingSource1
            // 
            this.algorithmBindingSource1.DataSource = typeof(Task4.Algorithm);
            // 
            // LCG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 522);
            this.Controls.Add(this.random_num);
            this.Controls.Add(this.cycle_label);
            this.Controls.Add(this.cycle_text);
            this.Controls.Add(this.num_iterations);
            this.Controls.Add(this.iter_num_text);
            this.Controls.Add(this.mod);
            this.Controls.Add(this.mod_text);
            this.Controls.Add(this.increment);
            this.Controls.Add(this.increment_text);
            this.Controls.Add(this.seed);
            this.Controls.Add(this.seed_text);
            this.Controls.Add(this.multiplier_label);
            this.Controls.Add(this.mul_text);
            this.Controls.Add(this.generate_button);
            this.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LCG";
            this.Text = "LCG";
            ((System.ComponentModel.ISupportInitialize)(this.randomNumberBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.algorithmBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.random_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.algorithmBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label cycle_label;
        private System.Windows.Forms.TextBox cycle_text;
        private System.Windows.Forms.Label num_iterations;
        private System.Windows.Forms.TextBox iter_num_text;
        private System.Windows.Forms.Label mod;
        private System.Windows.Forms.TextBox mod_text;
        private System.Windows.Forms.Label increment;
        private System.Windows.Forms.TextBox increment_text;
        private System.Windows.Forms.Label seed;
        private System.Windows.Forms.TextBox seed_text;
        private System.Windows.Forms.Label multiplier_label;
        private System.Windows.Forms.TextBox mul_text;
        private System.Windows.Forms.Button generate_button;
        private System.Windows.Forms.BindingSource randomNumberBindingSource;
        private System.Windows.Forms.BindingSource algorithmBindingSource;
        private System.Windows.Forms.BindingSource algorithmBindingSource1;
        private System.Windows.Forms.DataGridView random_num;
    }
}