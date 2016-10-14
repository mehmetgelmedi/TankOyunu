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
        int x = 10, y = 10, curX = 0, curY = 0;
        string komut = "1", sag = "→", sol = "←", ust = "¯", alt = "_", curYon = "", curFirca = "";
        char yildiz = '*';
        int bos = 0;
        char[] arr;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            dgvPanel.ColumnCount = x;
            dgvPanel.RowCount = y;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    dgvPanel.Rows[i].Cells[j].Value = bos;
                }
            }
            dgvPanel.Rows[curY].Cells[curX].Value = sag + ust;

            dgvPanel.ColumnHeadersVisible = false;
            dgvPanel.RowHeadersVisible = false;
            dgvPanel.AutoSize = true;
            dgvPanel.AutoResizeColumns();
            dgvPanel.AutoResizeRows();
            arr = komut.ToCharArray();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int iX = 1, iY = 1;
            if (curYon == sag && curX != 9)
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
            if (curYon == alt && curX != 9)
            {
                dgvPanel.Rows[curX].Cells[curY].Value = 1;
                curX += iY;
                dgvPanel.Rows[curX].Cells[curY].Value = curYon + curFirca;
            }
            if (curYon == ust && curX != 0)
            {
                dgvPanel.Rows[curX].Cells[curY].Value = 1;
                curX -= iY;
                dgvPanel.Rows[curX].Cells[curY].Value = curYon + curFirca;
            }
            if (curX == 9)
                curYon = sol;
            if (curX == 0)
                curYon = sag;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // engel durumuna göre aşağıda işlem yapılacak
            curYon = sag;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void dgvPanel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
