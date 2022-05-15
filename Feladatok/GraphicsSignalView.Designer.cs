namespace Signals
{
    partial class GraphicsSignalView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.b_ZoomIn = new System.Windows.Forms.Button();
            this.b_ZoomOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_ZoomIn
            // 
            this.b_ZoomIn.Location = new System.Drawing.Point(15, 15);
            this.b_ZoomIn.Name = "b_ZoomIn";
            this.b_ZoomIn.Size = new System.Drawing.Size(40, 40);
            this.b_ZoomIn.TabIndex = 0;
            this.b_ZoomIn.Text = "+";
            this.b_ZoomIn.UseVisualStyleBackColor = true;
            // 
            // b_ZoomOut
            // 
            this.b_ZoomOut.Location = new System.Drawing.Point(61, 15);
            this.b_ZoomOut.Name = "b_ZoomOut";
            this.b_ZoomOut.Size = new System.Drawing.Size(40, 40);
            this.b_ZoomOut.TabIndex = 1;
            this.b_ZoomOut.Text = "-";
            this.b_ZoomOut.UseVisualStyleBackColor = true;
            // 
            // GraphicsSignalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.b_ZoomIn);
            this.Controls.Add(this.b_ZoomOut);
            this.Name = "GraphicsSignalView";
            this.ResumeLayout(false);

        }

        #endregion

        private Button b_ZoomIn;
        private Button b_ZoomOut;
    }
}
