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
        Bitmap imgBos;
        Bitmap imgDuvar;
        Bitmap imgTarayici;
        Bitmap imgPasif;


        private void frmTank_Load(object sender, EventArgs e)
        {
            imgBos = new Bitmap(@"bos.png");
            imgDuvar = new Bitmap(@"duvar.png");
            imgTarayici = new Bitmap(@"tarayici.png");
            //imgPasif = new Bitmap(@"pasif.png");
        }

        private void dgvPanel_AllowUserToResizeColumnsChanged(object sender, EventArgs e)
        {

        }

        char yildiz = '*';
        int bos = 0;
        char[] arr;

        private void timer1_Tick(object sender, EventArgs e)
        {
            int iX = 1, iY = 1;
            if (curYon == sag && curX != x - 1)
            {
                dgvPanel.Rows[curY].Cells[curX].Value = 1;
                curX += iX;
                dgvPanel.Rows[curY].Cells[curX].Value = curYon + curFirca;
            }
            if (curYon == sol && curX != 0)
            {
                dgvPanel.Rows[curY].Cells[curX].Value = 1;
                curX -= iX;
                dgvPanel.Rows[curY].Cells[curX].Value = curYon + curFirca;
            }
            if (curYon == alt && curY != y - 1)
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
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            x = int.Parse(txtX.Text);
            y = int.Parse(txtY.Text);
            try
            {
                if (x > 3 && y> 3)
                {
                    dgvPanel.Rows.Clear();
                    dgvPanel.Columns.Clear();
                    for (int i = 0; i < x; i++)
                    {
                        DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                        dgvPanel.Columns.Add(imageCol);
                    }
                    for (int i = 0; i < y; i++)
                    {
                        dgvPanel.Rows.Add();
                    }

                    foreach (DataGridViewRow row in dgvPanel.Rows)
                    {
                        row.Height = 50;

                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.ColumnIndex == 0 || cell.ColumnIndex == x - 1 || cell.RowIndex == 0 || cell.RowIndex == y - 1)
                            {
                                cell.Value = imgDuvar;
                                cell.ToolTipText = "99";
                            }
                            else
                            {
                                cell.ToolTipText = "0";
                                cell.Value = imgBos;
                            }
                        }

                    }

                    foreach (DataGridViewColumn col in dgvPanel.Columns)
                    {
                        col.Width = 50;

                    }

                    
                  
                    dgvPanel.ColumnHeadersVisible = false;
                    dgvPanel.Rows[1].Cells[1].Value = imgTarayici;
                    dgvPanel.RowHeadersVisible = false;
                    dgvPanel.AutoSize = true;


                }
                else
                {
                    MessageBox.Show("En az 3 x 3 lük bir alan oluşturun.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("X değeri 0 100 arası olmalı");
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
        {
            if (!(e.ColumnIndex == 1 && e.RowIndex == 1))
                if (e.ColumnIndex != 0 && e.ColumnIndex != dgvPanel.Columns.Count - 1 && e.RowIndex != 0 && e.RowIndex != dgvPanel.Rows.Count - 1)
                    if (dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != imgDuvar)
                    {
                        dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = imgDuvar;
                        dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "99";
                    }
                    else
                    {
                        dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = imgBos;
                        dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "0";
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
