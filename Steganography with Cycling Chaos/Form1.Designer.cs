namespace Steganography_with_Cycling_Chaos
{
    partial class Form1
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.Pass = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.blocks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dec = new System.Windows.Forms.CheckBox();
            this.elapsed_time = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.I_text = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.CheckPathExists = false;
            this.saveFileDialog1.Filter = "text files|*.txt";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.Title = "store the Green Color";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Password:";
            // 
            // Pass
            // 
            this.Pass.Location = new System.Drawing.Point(128, 11);
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(100, 20);
            this.Pass.TabIndex = 44;
            this.Pass.Text = "lena1975";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(69, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 67;
            this.button1.Text = "Process";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(131, 91);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 69;
            this.button3.Text = "browse:";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // blocks
            // 
            this.blocks.Location = new System.Drawing.Point(128, 37);
            this.blocks.Name = "blocks";
            this.blocks.Size = new System.Drawing.Size(100, 20);
            this.blocks.TabIndex = 70;
            this.blocks.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "Image block size:";
            // 
            // dec
            // 
            this.dec.AutoSize = true;
            this.dec.Location = new System.Drawing.Point(131, 120);
            this.dec.Name = "dec";
            this.dec.Size = new System.Drawing.Size(85, 17);
            this.dec.TabIndex = 72;
            this.dec.Text = "is decryption";
            this.dec.UseVisualStyleBackColor = true;
            // 
            // elapsed_time
            // 
            this.elapsed_time.AutoSize = true;
            this.elapsed_time.Location = new System.Drawing.Point(90, 184);
            this.elapsed_time.Name = "elapsed_time";
            this.elapsed_time.Size = new System.Drawing.Size(35, 13);
            this.elapsed_time.TabIndex = 73;
            this.elapsed_time.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "Number of subintervals";
            // 
            // I_text
            // 
            this.I_text.Location = new System.Drawing.Point(131, 63);
            this.I_text.Name = "I_text";
            this.I_text.Size = new System.Drawing.Size(100, 20);
            this.I_text.TabIndex = 74;
            this.I_text.Text = "65536";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 76;
            this.label4.Text = "select a file:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 207);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.I_text);
            this.Controls.Add(this.elapsed_time);
            this.Controls.Add(this.dec);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.blocks);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pass);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Pass;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox blocks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox dec;
        private System.Windows.Forms.Label elapsed_time;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox I_text;
        private System.Windows.Forms.Label label4;
    }
}

