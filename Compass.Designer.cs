namespace VeryVisionControlLibrary
{
    partial class Compass
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pbxDialContainer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDialContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxDialContainer
            // 
            this.pbxDialContainer.Location = new System.Drawing.Point(278, 219);
            this.pbxDialContainer.Name = "pbxDialContainer";
            this.pbxDialContainer.Size = new System.Drawing.Size(250, 195);
            this.pbxDialContainer.TabIndex = 0;
            this.pbxDialContainer.TabStop = false;
            // 
            // Compass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(81)))), ((int)(((byte)(81)))));
            this.Controls.Add(this.pbxDialContainer);
            this.Name = "Compass";
            this.Size = new System.Drawing.Size(531, 417);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDialContainer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxDialContainer;

    }
}
