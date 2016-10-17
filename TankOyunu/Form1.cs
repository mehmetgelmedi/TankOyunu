using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TankOyunu
{
    public partial class frmTank : Form
    {
        Image image;
        public frmTank()
        {
            InitializeComponent();
            timer1.Interval = 300;    
            //image=Image.FromFile()
        }
        int x , y, curX = 1, curY = 1;
        string komut = "", sag = "→", sol = "←", ust = "↑", alt = "↓", curYon = "", curFirca = "";

        private void dgvPanel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPanel_AllowUserToResizeColumnsChanged(object sender, EventArgs e)
        {

        }

        char yildiz = '*';
        int bos = 0;
        char[] arr;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            x = int.Parse(txtX.Text);
            y = int.Parse(txtY.Text);
            //MessageBox.Show(x.ToString()+y.ToString());
            //dgvPanel.ColumnCount = x;
            //dgvPanel.RowCount = y;

            //for (int i = 0; i < x; i++)
            //{
            //    for (int j = 0; j < y; j++)
            //    {
            //        dgvPanel.Rows[i].Cells[j].Value = bos;
            //    }
            //}
            DataTable dt = new DataTable();
            for (int i = 0; i < x; i++)
            {
                dt.Columns.Add();
            }
            for (int i = 0; i < y; i++)
            {
                dt.Rows.Add();
            }
            // bos hatalı şuan
            
            dgvPanel.DataSource = dt;
            foreach (DataGridViewRow row in dgvPanel.Rows)
            {
                row.Height = 50;
                if (row.Index == 0 || row.Index == y - 1)
                {
                    row.DefaultCellStyle.BackColor = Color.Purple;
                }
            }
             foreach (DataGridViewColumn col in dgvPanel.Columns)
            {
                col.Width = 50;

                if (col.Index ==0 || col.Index == x-1)
                {
                    col.DefaultCellStyle.BackColor = Color.Purple;
                }

                dgvPanel.ColumnHeadersVisible = false;
                dgvPanel.RowHeadersVisible = false;
                dgvPanel.DefaultCellStyle.SelectionBackColor = dgvPanel.DefaultCellStyle.BackColor;
            }
            dgvPanel.Rows[curY].Cells[curX].Value = yildiz;

            dgvPanel.ColumnHeadersVisible = false;
            dgvPanel.RowHeadersVisible = false;
            
            dgvPanel.AutoSize = true;
          
            arr = komut.ToCharArray();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int iX = 1, iY = 1;
            if (curYon == sag && curX != x-1)
            {
                dgvPanel.Rows[curY].Cells[curX].Value =1;
                curX += iX;
                dgvPanel.Rows[curY].Cells[curX].Value = curYon + curFirca;
            }
            if (curYon == sol && curX != 0)
            {
                dgvPanel.Rows[curY].Cells[curX].Value =  1;
                curX -= iX;
                dgvPanel.Rows[curY].Cells[curX].Value = curYon + curFirca;
            }
            if (curYon == alt && curY != y-1)
            {
                dgvPanel.Rows[curY].Cells[curX].Value = 1;
                curY += iY;
                dgvPanel.Rows[curY].Cells[curX].Value = curYon + curFirca;
            }
            if (curYon == ust && curY != 0)
            {
                dgvPanel.Rows[curY].Cells[curX].Value = 1;
                curY -= iY;
                dgvPanel.Rows[curY].Cells[curX].Value = curYon + curFirca;
            }
            //TEST
            if (curY == 9)
                curYon = sag;
            if (curX == 9 && curY == 9)
                curYon = ust;
            if (curX == 9 && curY == 0)
                curYon = sol;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // engel durumuna göre aşağıda işlem yapılacak
            //TEST
            curYon = alt;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void dgvPanel_CellClick(object sender, DataGridViewCellEventArgs e)
        {  //  if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor != Color.Purple)
            if (dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor != Color.Yellow)
            {
                dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;
            }
            else
            {
                dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
            }
        }

        private void dgvPanel_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // if ((char)dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =='0')
            //{
            //    dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].
            //}
        }
    }
}
