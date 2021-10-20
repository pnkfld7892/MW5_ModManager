
namespace MW5_MM_UI
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
            this.gridInstalledMods = new System.Windows.Forms.DataGridView();
            this.lblModGrid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridInstalledMods)).BeginInit();
            this.SuspendLayout();
            // 
            // gridInstalledMods
            // 
            this.gridInstalledMods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInstalledMods.Location = new System.Drawing.Point(12, 86);
            this.gridInstalledMods.Name = "gridInstalledMods";
            this.gridInstalledMods.RowTemplate.Height = 25;
            this.gridInstalledMods.Size = new System.Drawing.Size(776, 352);
            this.gridInstalledMods.TabIndex = 0;
            // 
            // lblModGrid
            // 
            this.lblModGrid.AutoSize = true;
            this.lblModGrid.Location = new System.Drawing.Point(13, 65);
            this.lblModGrid.Name = "lblModGrid";
            this.lblModGrid.Size = new System.Drawing.Size(84, 15);
            this.lblModGrid.TabIndex = 1;
            this.lblModGrid.Text = "Installed Mods";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblModGrid);
            this.Controls.Add(this.gridInstalledMods);
            this.Name = "MainForm";
            this.Text = "MechWarrior 5 Mod Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridInstalledMods)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridInstalledMods;
        private System.Windows.Forms.Label lblModGrid;
    }
}

