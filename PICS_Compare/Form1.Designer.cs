using System;
using System.Windows.Forms;

namespace PICS_Compare
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.te_textBox = new System.Windows.Forms.TextBox();
            this.te_file = new System.Windows.Forms.Label();
            this.PICS_Excel = new System.Windows.Forms.Label();
            this.pics_textBox = new System.Windows.Forms.TextBox();
            this.result_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.run_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // te_textBox
            // 
            this.te_textBox.AllowDrop = true;
            this.te_textBox.Location = new System.Drawing.Point(128, 36);
            this.te_textBox.Name = "te_textBox";
            this.te_textBox.Size = new System.Drawing.Size(414, 21);
            this.te_textBox.TabIndex = 0;
            this.te_textBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.te_textBox_DragDrop);
            this.te_textBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.te_textBox_DragEnter);
            // 
            // te_file
            // 
            this.te_file.AutoSize = true;
            this.te_file.Location = new System.Drawing.Point(29, 39);
            this.te_file.Name = "te_file";
            this.te_file.Size = new System.Drawing.Size(45, 12);
            this.te_file.TabIndex = 1;
            this.te_file.Text = "TE File";
            // 
            // PICS_Excel
            // 
            this.PICS_Excel.AutoSize = true;
            this.PICS_Excel.Location = new System.Drawing.Point(29, 94);
            this.PICS_Excel.Name = "PICS_Excel";
            this.PICS_Excel.Size = new System.Drawing.Size(93, 12);
            this.PICS_Excel.TabIndex = 2;
            this.PICS_Excel.Text = "PICS Excel File";
            // 
            // pics_textBox
            // 
            this.pics_textBox.AllowDrop = true;
            this.pics_textBox.Location = new System.Drawing.Point(128, 91);
            this.pics_textBox.Name = "pics_textBox";
            this.pics_textBox.Size = new System.Drawing.Size(414, 21);
            this.pics_textBox.TabIndex = 3;
            this.pics_textBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.pics_textBox_DragDrop);
            this.pics_textBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.pics_textBox_DragEnter);
            // 
            // result_textBox
            // 
            this.result_textBox.Location = new System.Drawing.Point(31, 170);
            this.result_textBox.Multiline = true;
            this.result_textBox.Name = "result_textBox";
            this.result_textBox.Size = new System.Drawing.Size(736, 268);
            this.result_textBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Results";
            // 
            // run_button
            // 
            this.run_button.Location = new System.Drawing.Point(598, 52);
            this.run_button.Name = "run_button";
            this.run_button.Size = new System.Drawing.Size(75, 23);
            this.run_button.TabIndex = 6;
            this.run_button.Text = "Run";
            this.run_button.UseVisualStyleBackColor = true;
            this.run_button.Click += new System.EventHandler(this.run_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.run_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.result_textBox);
            this.Controls.Add(this.pics_textBox);
            this.Controls.Add(this.PICS_Excel);
            this.Controls.Add(this.te_file);
            this.Controls.Add(this.te_textBox);
            this.Name = "Form1";
            this.Text = "PICS Compare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox te_textBox;
        private System.Windows.Forms.Label te_file;
        private System.Windows.Forms.Label PICS_Excel;
        private System.Windows.Forms.TextBox pics_textBox;
        private System.Windows.Forms.TextBox result_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button run_button;
    }
}

