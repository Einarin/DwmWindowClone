using System.Windows.Forms;
using System;
using System.Drawing;
using System.Text;

namespace DWMWindowClone
{
    partial class CloneWindow
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
            this.windowList = new System.Windows.Forms.ListBox();
            this.cloneButton = new System.Windows.Forms.Button();
            this.mmcss = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // windowList
            // 
            this.windowList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.windowList.BackColor = System.Drawing.SystemColors.Control;
            this.windowList.FormattingEnabled = true;
            this.windowList.Location = new System.Drawing.Point(0, 0);
            this.windowList.Name = "windowList";
            this.windowList.Size = new System.Drawing.Size(664, 407);
            this.windowList.TabIndex = 0;
            // 
            // cloneButton
            // 
            this.cloneButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cloneButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cloneButton.Location = new System.Drawing.Point(0, 409);
            this.cloneButton.Name = "cloneButton";
            this.cloneButton.Size = new System.Drawing.Size(492, 73);
            this.cloneButton.TabIndex = 1;
            this.cloneButton.Text = "Clone";
            this.cloneButton.UseVisualStyleBackColor = true;
            this.cloneButton.Click += new System.EventHandler(this.cloneButton_Click);
            // 
            // mmcss
            // 
            this.mmcss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mmcss.Location = new System.Drawing.Point(498, 409);
            this.mmcss.Name = "mmcss";
            this.mmcss.Size = new System.Drawing.Size(166, 73);
            this.mmcss.TabIndex = 2;
            this.mmcss.Text = "Enable MMCSS";
            this.mmcss.UseVisualStyleBackColor = true;
            this.mmcss.Click += new System.EventHandler(this.mmcss_Click);
            // 
            // CloneWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::DWMWindowClone.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(664, 483);
            this.Controls.Add(this.mmcss);
            this.Controls.Add(this.cloneButton);
            this.Controls.Add(this.windowList);
            this.DoubleBuffered = true;
            this.Name = "CloneWindow";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "DWM Window Duplicator";
            this.TransparencyKey = System.Drawing.Color.White;
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox windowList;
        private Button cloneButton;
        private Button mmcss;

    }
}

