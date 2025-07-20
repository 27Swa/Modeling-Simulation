namespace project
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
            mul_text = new TextBox();
            mod_text = new TextBox();
            increment_text = new TextBox();
            seed_text = new TextBox();
            iter_num_text = new TextBox();
            cycle_text = new TextBox();
            random_num = new DataGridView();
            multiplier_label = new Label();
            seed = new Label();
            increment = new Label();
            mod = new Label();
            num_iterations = new Label();
            cycle_label = new Label();
            generate_button = new Button();
            ((System.ComponentModel.ISupportInitialize)random_num).BeginInit();
            SuspendLayout();
            // 
            // mul_text
            // 
            mul_text.Location = new Point(146, 81);
            mul_text.Name = "mul_text";
            mul_text.Size = new Size(173, 31);
            mul_text.TabIndex = 0;
            // 
            // mod_text
            // 
            mod_text.Location = new Point(146, 391);
            mod_text.Name = "mod_text";
            mod_text.Size = new Size(173, 31);
            mod_text.TabIndex = 1;
            // 
            // increment_text
            // 
            increment_text.Location = new Point(146, 292);
            increment_text.Name = "increment_text";
            increment_text.Size = new Size(173, 31);
            increment_text.TabIndex = 2;
            // 
            // seed_text
            // 
            seed_text.Location = new Point(146, 189);
            seed_text.Name = "seed_text";
            seed_text.Size = new Size(173, 31);
            seed_text.TabIndex = 3;
            // 
            // iter_num_text
            // 
            iter_num_text.Location = new Point(146, 510);
            iter_num_text.Name = "iter_num_text";
            iter_num_text.Size = new Size(173, 31);
            iter_num_text.TabIndex = 4;
            // 
            // cycle_text
            // 
            cycle_text.Location = new Point(485, 292);
            cycle_text.Name = "cycle_text";
            cycle_text.ReadOnly = true;
            cycle_text.Size = new Size(173, 31);
            cycle_text.TabIndex = 5;
            // 
            // random_num
            // 
            random_num.BackgroundColor = Color.LightSkyBlue;
            random_num.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            random_num.Location = new Point(759, 25);
            random_num.Name = "random_num";
            random_num.RowHeadersWidth = 62;
            random_num.Size = new Size(360, 604);
            random_num.TabIndex = 6;
            // 
            // multiplier_label
            // 
            multiplier_label.AutoSize = true;
            multiplier_label.Font = new Font("Modern No. 20", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            multiplier_label.ForeColor = SystemColors.MenuHighlight;
            multiplier_label.Location = new Point(37, 84);
            multiplier_label.Name = "multiplier_label";
            multiplier_label.Size = new Size(97, 21);
            multiplier_label.TabIndex = 7;
            multiplier_label.Text = "Multiplier";
            // 
            // seed
            // 
            seed.AutoSize = true;
            seed.Font = new Font("Modern No. 20", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            seed.ForeColor = SystemColors.MenuHighlight;
            seed.Location = new Point(37, 192);
            seed.Name = "seed";
            seed.Size = new Size(46, 21);
            seed.TabIndex = 8;
            seed.Text = "Seed";
            // 
            // increment
            // 
            increment.AutoSize = true;
            increment.Font = new Font("Modern No. 20", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            increment.ForeColor = SystemColors.MenuHighlight;
            increment.Location = new Point(37, 295);
            increment.Name = "increment";
            increment.Size = new Size(94, 21);
            increment.TabIndex = 9;
            increment.Text = "Increment";
            // 
            // mod
            // 
            mod.AutoSize = true;
            mod.Font = new Font("Modern No. 20", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mod.ForeColor = SystemColors.MenuHighlight;
            mod.Location = new Point(37, 394);
            mod.Name = "mod";
            mod.Size = new Size(79, 21);
            mod.TabIndex = 10;
            mod.Text = "Modulus";
            // 
            // num_iterations
            // 
            num_iterations.AutoSize = true;
            num_iterations.Font = new Font("Modern No. 20", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            num_iterations.ForeColor = SystemColors.MenuHighlight;
            num_iterations.Location = new Point(37, 513);
            num_iterations.Name = "num_iterations";
            num_iterations.Size = new Size(105, 21);
            num_iterations.TabIndex = 11;
            num_iterations.Text = "# Iterations";
            // 
            // cycle_label
            // 
            cycle_label.AutoSize = true;
            cycle_label.Font = new Font("Modern No. 20", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cycle_label.ForeColor = SystemColors.MenuHighlight;
            cycle_label.Location = new Point(388, 295);
            cycle_label.Name = "cycle_label";
            cycle_label.Size = new Size(74, 21);
            cycle_label.TabIndex = 12;
            cycle_label.Text = "# Cycles";
            // 
            // generate_button
            // 
            generate_button.Font = new Font("Modern No. 20", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            generate_button.ForeColor = SystemColors.MenuHighlight;
            generate_button.Location = new Point(289, 601);
            generate_button.Name = "generate_button";
            generate_button.Size = new Size(230, 76);
            generate_button.TabIndex = 13;
            generate_button.Text = "Generate numbers";
            generate_button.UseVisualStyleBackColor = true;
            this.generate_button.Click += new System.EventHandler(this.generate_button_Click);

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1173, 742);
            Controls.Add(generate_button);
            Controls.Add(cycle_label);
            Controls.Add(num_iterations);
            Controls.Add(mod);
            Controls.Add(increment);
            Controls.Add(seed);
            Controls.Add(multiplier_label);
            Controls.Add(random_num);
            Controls.Add(cycle_text);
            Controls.Add(iter_num_text);
            Controls.Add(seed_text);
            Controls.Add(increment_text);
            Controls.Add(mod_text);
            Controls.Add(mul_text);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)random_num).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox mul_text;
        private TextBox mod_text;
        private TextBox increment_text;
        private TextBox seed_text;
        private TextBox iter_num_text;
        private TextBox cycle_text;
        private DataGridView random_num;
        private Label multiplier_label;
        private Label seed;
        private Label increment;
        private Label mod;
        private Label num_iterations;
        private Label cycle_label;
        private Button generate_button;
    }
}
