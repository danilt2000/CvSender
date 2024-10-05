namespace CvSender.WindowsFormsClient
{
        partial class MainForm
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
                        components = new System.ComponentModel.Container();
                        bindingSource1 = new BindingSource(components);
                        panel1 = new Panel();
                        jobscz = new Label();
                        contextMenuStrip1 = new ContextMenuStrip(components);
                        ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
                        panel1.SuspendLayout();
                        SuspendLayout();
                        // 
                        // bindingSource1
                        // 
                        bindingSource1.CurrentChanged += bindingSource1_CurrentChanged;
                        // 
                        // panel1
                        // 
                        panel1.BackColor = SystemColors.GradientInactiveCaption;
                        panel1.Controls.Add(jobscz);
                        panel1.Location = new Point(0, 0);
                        panel1.Name = "panel1";
                        panel1.Size = new Size(200, 456);
                        panel1.TabIndex = 1;
                        // 
                        // jobscz
                        // 
                        jobscz.AutoSize = true;
                        jobscz.Location = new Point(66, 18);
                        jobscz.Name = "jobscz";
                        jobscz.Size = new Size(40, 15);
                        jobscz.TabIndex = 0;
                        jobscz.Text = "jobscz";
                        // 
                        // contextMenuStrip1
                        // 
                        contextMenuStrip1.Name = "contextMenuStrip1";
                        contextMenuStrip1.Size = new Size(61, 4);
                        // 
                        // MainForm
                        // 
                        AutoScaleDimensions = new SizeF(7F, 15F);
                        AutoScaleMode = AutoScaleMode.Font;
                        ClientSize = new Size(800, 450);
                        Controls.Add(panel1);
                        Name = "MainForm";
                        Text = "MainForm";
                        Load += Form1_Load;
                        ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
                        panel1.ResumeLayout(false);
                        panel1.PerformLayout();
                        ResumeLayout(false);
                }

                #endregion
                private BindingSource bindingSource1;
                private Panel panel1;
                private Label jobscz;
                private ContextMenuStrip contextMenuStrip1;
        }
}
