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
                        button1 = new Button();
                        contextMenuStrip1 = new ContextMenuStrip(components);
                        sitelabel = new Label();
                        button2 = new Button();
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
                        panel1.Controls.Add(button2);
                        panel1.Controls.Add(button1);
                        panel1.Location = new Point(0, 0);
                        panel1.Name = "panel1";
                        panel1.Size = new Size(200, 456);
                        panel1.TabIndex = 1;
                        // 
                        // button1
                        // 
                        button1.Location = new Point(57, 21);
                        button1.Name = "button1";
                        button1.Size = new Size(75, 23);
                        button1.TabIndex = 1;
                        button1.Text = "jobscz";
                        button1.UseVisualStyleBackColor = true;
                        button1.Click += button1_Click_2;
                        // 
                        // contextMenuStrip1
                        // 
                        contextMenuStrip1.Name = "contextMenuStrip1";
                        contextMenuStrip1.Size = new Size(61, 4);
                        // 
                        // sitelabel
                        // 
                        sitelabel.AutoSize = true;
                        sitelabel.Location = new Point(230, 25);
                        sitelabel.Name = "sitelabel";
                        sitelabel.Size = new Size(50, 15);
                        sitelabel.TabIndex = 2;
                        sitelabel.Text = "sitelabel";
                        // 
                        // button2
                        // 
                        button2.Location = new Point(57, 379);
                        button2.Name = "button2";
                        button2.Size = new Size(75, 23);
                        button2.TabIndex = 2;
                        button2.Text = "start";
                        button2.UseVisualStyleBackColor = true;
                        button2.Click += button2_Click;
                        // 
                        // MainForm
                        // 
                        AutoScaleDimensions = new SizeF(7F, 15F);
                        AutoScaleMode = AutoScaleMode.Font;
                        ClientSize = new Size(800, 450);
                        Controls.Add(sitelabel);
                        Controls.Add(panel1);
                        Name = "MainForm";
                        Text = "MainForm";
                        Load += Form1_Load;
                        ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
                        panel1.ResumeLayout(false);
                        ResumeLayout(false);
                        PerformLayout();
                }

                #endregion
                private BindingSource bindingSource1;
                private Panel panel1;
                private ContextMenuStrip contextMenuStrip1;
                private Button button1;
                private Label sitelabel;
                private Button button2;
        }
}
