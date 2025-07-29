using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MergeDatagridviewCells
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData();
            //MergeCells();
        }

        void LoadData()
        {
            List<ProduceData> produceDatas = new List<ProduceData>();
            produceDatas.Add(new ProduceData { ProduceModel = "AA", ProducePart = "AAS10", ProduceSpec = "TON1" });
            produceDatas.Add(new ProduceData { ProduceModel = "AA", ProducePart = "AAS10", ProduceSpec = "TON1" });
            produceDatas.Add(new ProduceData { ProduceModel = "AA", ProducePart = "AAS10", ProduceSpec = "TON1" });
            produceDatas.Add(new ProduceData { ProduceModel = "AA", ProducePart = "AAS10", ProduceSpec = "TON1" });
            produceDatas.Add(new ProduceData { ProduceModel = "AA", ProducePart = "AAS10", ProduceSpec = "TON1" });
            produceDatas.Add(new ProduceData { ProduceModel = "AB", ProducePart = "ABS10", ProduceSpec = "TON2" });
            produceDatas.Add(new ProduceData { ProduceModel = "AB", ProducePart = "ABS10", ProduceSpec = "TON2" });
            produceDatas.Add(new ProduceData { ProduceModel = "AB", ProducePart = "ABS10", ProduceSpec = "TON2" });
            produceDatas.Add(new ProduceData { ProduceModel = "AB", ProducePart = "ABS10", ProduceSpec = "TON2" });
            dgv.RowCount = produceDatas.Count();
            for (int i = 0; i < produceDatas.Count(); i++)
            {
                dgv.Rows[i].Cells[0].Value = produceDatas[i].ProduceModel;
                dgv.Rows[i].Cells[1].Value = produceDatas[i].ProducePart;
                dgv.Rows[i].Cells[2].Value = produceDatas[i].ProduceSpec;
            }

        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // 只對第0欄進行處理（可自行調整）
            if ((e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2) && e.RowIndex >= 0)
            {
                DataGridView dgv = sender as DataGridView;
                string currValue = e.Value?.ToString();
                if (string.IsNullOrEmpty(currValue)) return;

                // 是否是第一列或與前一列不同
                bool isFirstRow = e.RowIndex == 0 ||
                    dgv.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value?.ToString() != currValue;

                if (isFirstRow)
                {
                    int rowSpan = 1;
                    int totalHeight = dgv.Rows[e.RowIndex].Height;

                    // 計算有幾列要合併
                    for (int i = e.RowIndex + 1; i < dgv.Rows.Count; i++)
                    {
                        string nextValue = dgv.Rows[i].Cells[e.ColumnIndex].Value?.ToString();
                        if (nextValue != currValue)
                            break;

                        rowSpan++;
                        totalHeight += dgv.Rows[i].Height;
                    }

                    // 畫背景
                    e.Graphics.FillRectangle(new SolidBrush(e.CellStyle.BackColor),
                        new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, totalHeight));

                    // 畫邊框
                    using (Pen gridLinePen = new Pen(dgv.GridColor))
                    {
                        e.Graphics.DrawRectangle(gridLinePen,
                            new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, totalHeight - 1));
                    }

                    // 畫文字（垂直 + 水平置中）
                    TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.WordBreak;
                    Rectangle mergedRect = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, totalHeight);
                    TextRenderer.DrawText(e.Graphics, currValue, e.CellStyle.Font, mergedRect, e.CellStyle.ForeColor, flags);

                    e.Handled = true;
                }
                else
                {
                    // 非起始列不繪製任何內容，讓它顯示合併視覺效果
                    e.Handled = true;
                }
            }
        }

        //private void MergeCells()
        //    {
        //        int RowCount = dgv.Rows.Count;
        //        int ColCount = dgv.Columns.Count;
        //        int startIdx = 0;
        //        int endIdx = 0;
        //        object currVal = null;
        //        object nextVal = null;
        //        if (RowCount > 0)
        //        {
        //            for (int c = 0; c < ColCount; c++)
        //            {
        //                for (int r = 0 ; r < RowCount; r++)
        //                {
        //                    if (r != RowCount - 1)
        //                    {
        //                        currVal = dgv[c, r].Value;
        //                        nextVal = dgv[c, r + 1].Value;
        //                        if (currVal == nextVal)
        //                        {
        //                            dgv[c, r].Value = null;
        //                            dgv.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.Single;
        //                            dgv.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Single;
        //                            endIdx++;
        //                            continue;
        //                        }
        //                    }
        //                    int midIdx = ((endIdx - startIdx) + 1) / 2;
        //                    midIdx += startIdx;
        //                    dgv[c, midIdx].Value = dgv[c, endIdx].Value;
        //                    dgv[c, r].Value = null;
        //                    endIdx++;
        //                    startIdx = endIdx;

        //                }
        //                startIdx = 0;
        //                endIdx = 0;
        //            }
        //        }
        //    }
        //}

        public class ProduceData
        {
            public string ProduceModel { get; set; }
            public string ProducePart { get; set; }
            public string ProduceSpec { get; set; }
        }
    }
}
