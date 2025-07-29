namespace MergeDatagridviewCells
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv = new System.Windows.Forms.DataGridView();
            this.ProduceModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProducePart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProduceSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProduceModel,
            this.ProducePart,
            this.ProduceSpec});
            this.dgv.Location = new System.Drawing.Point(12, 77);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 27;
            this.dgv.Size = new System.Drawing.Size(713, 342);
            this.dgv.TabIndex = 0;
            this.dgv.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            // 
            // ProduceModel
            // 
            this.ProduceModel.HeaderText = "產品類";
            this.ProduceModel.MinimumWidth = 6;
            this.ProduceModel.Name = "ProduceModel";
            this.ProduceModel.ReadOnly = true;
            this.ProduceModel.Width = 125;
            // 
            // ProducePart
            // 
            this.ProducePart.HeaderText = "產品料號";
            this.ProducePart.MinimumWidth = 6;
            this.ProducePart.Name = "ProducePart";
            this.ProducePart.ReadOnly = true;
            this.ProducePart.Width = 125;
            // 
            // ProduceSpec
            // 
            this.ProduceSpec.HeaderText = "產品規格";
            this.ProduceSpec.MinimumWidth = 6;
            this.ProduceSpec.Name = "ProduceSpec";
            this.ProduceSpec.ReadOnly = true;
            this.ProduceSpec.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 487);
            this.Controls.Add(this.dgv);
            this.Name = "Form1";
            this.Text = "合併 Datagridview 儲存格";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProduceModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProducePart;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProduceSpec;
    }
}

