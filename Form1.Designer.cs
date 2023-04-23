namespace NewGraphicsPackage
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
            this.DrawingPanel = new System.Windows.Forms.Panel();
            this.txtBox_line_x1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBox_line_y1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBox_line_y2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBox_line_x2 = new System.Windows.Forms.TextBox();
            this.DrawLineDDA = new System.Windows.Forms.Button();
            this.DrawCircle = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBox_circle_r = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBox_circle_yc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBox_circle_xc = new System.Windows.Forms.TextBox();
            this.DrawLineBresenham = new System.Windows.Forms.Button();
            this.ClearDrawingPanel = new System.Windows.Forms.Button();
            this.DrawEllipse = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBox_ellipse_rx = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBox_ellipse_yc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBox_ellipse_xc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBox_ellipse_ry = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.MoveToTransformation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DrawingPanel
            // 
            this.DrawingPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.DrawingPanel.Location = new System.Drawing.Point(400, 37);
            this.DrawingPanel.Name = "DrawingPanel";
            this.DrawingPanel.Size = new System.Drawing.Size(953, 626);
            this.DrawingPanel.TabIndex = 0;
            this.DrawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingPanel_Paint);
            // 
            // txtBox_line_x1
            // 
            this.txtBox_line_x1.Location = new System.Drawing.Point(50, 68);
            this.txtBox_line_x1.Name = "txtBox_line_x1";
            this.txtBox_line_x1.Size = new System.Drawing.Size(98, 22);
            this.txtBox_line_x1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "X1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y1:";
            // 
            // txtBox_line_y1
            // 
            this.txtBox_line_y1.Location = new System.Drawing.Point(197, 68);
            this.txtBox_line_y1.Name = "txtBox_line_y1";
            this.txtBox_line_y1.Size = new System.Drawing.Size(98, 22);
            this.txtBox_line_y1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Y2:";
            // 
            // txtBox_line_y2
            // 
            this.txtBox_line_y2.Location = new System.Drawing.Point(197, 98);
            this.txtBox_line_y2.Name = "txtBox_line_y2";
            this.txtBox_line_y2.Size = new System.Drawing.Size(98, 22);
            this.txtBox_line_y2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "X2:";
            // 
            // txtBox_line_x2
            // 
            this.txtBox_line_x2.Location = new System.Drawing.Point(50, 98);
            this.txtBox_line_x2.Name = "txtBox_line_x2";
            this.txtBox_line_x2.Size = new System.Drawing.Size(98, 22);
            this.txtBox_line_x2.TabIndex = 5;
            // 
            // DrawLineDDA
            // 
            this.DrawLineDDA.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DrawLineDDA.Location = new System.Drawing.Point(50, 135);
            this.DrawLineDDA.Name = "DrawLineDDA";
            this.DrawLineDDA.Size = new System.Drawing.Size(245, 40);
            this.DrawLineDDA.TabIndex = 9;
            this.DrawLineDDA.Text = "Draw line (DDA)";
            this.DrawLineDDA.UseVisualStyleBackColor = false;
            this.DrawLineDDA.Click += new System.EventHandler(this.DrawLineDDA_Click);
            // 
            // DrawCircle
            // 
            this.DrawCircle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DrawCircle.Location = new System.Drawing.Point(50, 368);
            this.DrawCircle.Name = "DrawCircle";
            this.DrawCircle.Size = new System.Drawing.Size(245, 40);
            this.DrawCircle.TabIndex = 18;
            this.DrawCircle.Text = "Draw Circle";
            this.DrawCircle.UseVisualStyleBackColor = false;
            this.DrawCircle.Click += new System.EventHandler(this.DrawCircle_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Radius:";
            // 
            // txtBox_circle_r
            // 
            this.txtBox_circle_r.Location = new System.Drawing.Point(78, 331);
            this.txtBox_circle_r.Name = "txtBox_circle_r";
            this.txtBox_circle_r.Size = new System.Drawing.Size(215, 22);
            this.txtBox_circle_r.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(166, 304);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "YC:";
            // 
            // txtBox_circle_yc
            // 
            this.txtBox_circle_yc.Location = new System.Drawing.Point(197, 301);
            this.txtBox_circle_yc.Name = "txtBox_circle_yc";
            this.txtBox_circle_yc.Size = new System.Drawing.Size(98, 22);
            this.txtBox_circle_yc.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 304);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "XC:";
            // 
            // txtBox_circle_xc
            // 
            this.txtBox_circle_xc.Location = new System.Drawing.Point(50, 301);
            this.txtBox_circle_xc.Name = "txtBox_circle_xc";
            this.txtBox_circle_xc.Size = new System.Drawing.Size(98, 22);
            this.txtBox_circle_xc.TabIndex = 10;
            // 
            // DrawLineBresenham
            // 
            this.DrawLineBresenham.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DrawLineBresenham.Location = new System.Drawing.Point(50, 184);
            this.DrawLineBresenham.Name = "DrawLineBresenham";
            this.DrawLineBresenham.Size = new System.Drawing.Size(245, 40);
            this.DrawLineBresenham.TabIndex = 19;
            this.DrawLineBresenham.Text = "Draw Line (Bresenham)";
            this.DrawLineBresenham.UseVisualStyleBackColor = false;
            this.DrawLineBresenham.Click += new System.EventHandler(this.DrawLineBresenham_Click);
            // 
            // ClearDrawingPanel
            // 
            this.ClearDrawingPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearDrawingPanel.Location = new System.Drawing.Point(1182, 675);
            this.ClearDrawingPanel.Name = "ClearDrawingPanel";
            this.ClearDrawingPanel.Size = new System.Drawing.Size(171, 40);
            this.ClearDrawingPanel.TabIndex = 20;
            this.ClearDrawingPanel.Text = "Clear";
            this.ClearDrawingPanel.UseVisualStyleBackColor = false;
            this.ClearDrawingPanel.Click += new System.EventHandler(this.ClearDrawingPanel_Click);
            // 
            // DrawEllipse
            // 
            this.DrawEllipse.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DrawEllipse.Location = new System.Drawing.Point(50, 549);
            this.DrawEllipse.Name = "DrawEllipse";
            this.DrawEllipse.Size = new System.Drawing.Size(245, 40);
            this.DrawEllipse.TabIndex = 27;
            this.DrawEllipse.Text = "Draw Ellipse";
            this.DrawEllipse.UseVisualStyleBackColor = false;
            this.DrawEllipse.Click += new System.EventHandler(this.DrawEllipse_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 515);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "RadiusX:";
            // 
            // txtBox_ellipse_rx
            // 
            this.txtBox_ellipse_rx.Location = new System.Drawing.Point(80, 512);
            this.txtBox_ellipse_rx.Name = "txtBox_ellipse_rx";
            this.txtBox_ellipse_rx.Size = new System.Drawing.Size(68, 22);
            this.txtBox_ellipse_rx.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(166, 485);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "YC:";
            // 
            // txtBox_ellipse_yc
            // 
            this.txtBox_ellipse_yc.Location = new System.Drawing.Point(197, 482);
            this.txtBox_ellipse_yc.Name = "txtBox_ellipse_yc";
            this.txtBox_ellipse_yc.Size = new System.Drawing.Size(98, 22);
            this.txtBox_ellipse_yc.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 485);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "XC:";
            // 
            // txtBox_ellipse_xc
            // 
            this.txtBox_ellipse_xc.Location = new System.Drawing.Point(50, 482);
            this.txtBox_ellipse_xc.Name = "txtBox_ellipse_xc";
            this.txtBox_ellipse_xc.Size = new System.Drawing.Size(98, 22);
            this.txtBox_ellipse_xc.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(161, 516);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 16);
            this.label11.TabIndex = 29;
            this.label11.Text = "RadiusY:";
            // 
            // txtBox_ellipse_ry
            // 
            this.txtBox_ellipse_ry.Location = new System.Drawing.Point(229, 513);
            this.txtBox_ellipse_ry.Name = "txtBox_ellipse_ry";
            this.txtBox_ellipse_ry.Size = new System.Drawing.Size(66, 22);
            this.txtBox_ellipse_ry.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 25);
            this.label12.TabIndex = 30;
            this.label12.Text = "Line";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(16, 254);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 25);
            this.label13.TabIndex = 31;
            this.label13.Text = "Circle";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(18, 436);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 25);
            this.label14.TabIndex = 32;
            this.label14.Text = "Ellipse";
            // 
            // MoveToTransformation
            // 
            this.MoveToTransformation.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MoveToTransformation.Location = new System.Drawing.Point(23, 658);
            this.MoveToTransformation.Name = "MoveToTransformation";
            this.MoveToTransformation.Size = new System.Drawing.Size(272, 46);
            this.MoveToTransformation.TabIndex = 33;
            this.MoveToTransformation.Text = "Transformation";
            this.MoveToTransformation.UseVisualStyleBackColor = false;
            this.MoveToTransformation.Click += new System.EventHandler(this.MoveToTransformation_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1390, 727);
            this.Controls.Add(this.MoveToTransformation);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBox_ellipse_ry);
            this.Controls.Add(this.DrawEllipse);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBox_ellipse_rx);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBox_ellipse_yc);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtBox_ellipse_xc);
            this.Controls.Add(this.ClearDrawingPanel);
            this.Controls.Add(this.DrawLineBresenham);
            this.Controls.Add(this.DrawCircle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBox_circle_r);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBox_circle_yc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBox_circle_xc);
            this.Controls.Add(this.DrawLineDDA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBox_line_y2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBox_line_x2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBox_line_y1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBox_line_x1);
            this.Controls.Add(this.DrawingPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel DrawingPanel;
        private System.Windows.Forms.TextBox txtBox_line_x1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBox_line_y1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBox_line_y2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBox_line_x2;
        private System.Windows.Forms.Button DrawLineDDA;
        private System.Windows.Forms.Button DrawCircle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBox_circle_r;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBox_circle_yc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBox_circle_xc;
        private System.Windows.Forms.Button DrawLineBresenham;
        private System.Windows.Forms.Button ClearDrawingPanel;
        private System.Windows.Forms.Button DrawEllipse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBox_ellipse_rx;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBox_ellipse_yc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBox_ellipse_xc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBox_ellipse_ry;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button MoveToTransformation;
    }
}

