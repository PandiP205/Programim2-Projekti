using System.Windows.Forms;
using System.Drawing;

namespace ExchangeShopApp
{
    partial class TransactionHistoryForm
    {
        private DataGridView dataGridViewTransactions;

        private void InitializeComponent()
        {
            this.dataGridViewTransactions = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).BeginInit();
            this.SuspendLayout();
           
            this.dataGridViewTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransactions.Dock = DockStyle.Fill;
            this.dataGridViewTransactions.Location = new Point(0, 0);
            this.dataGridViewTransactions.Name = "dataGridViewTransactions";
            this.dataGridViewTransactions.RowHeadersWidth = 51;
            this.dataGridViewTransactions.Size = new Size(800, 450);
            this.dataGridViewTransactions.TabIndex = 0;
            
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.dataGridViewTransactions);
            this.Name = "TransactionHistoryForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Transaction History";
            this.Load += new System.EventHandler(this.TransactionHistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).EndInit();
            this.ResumeLayout(false);
        }
    }
}