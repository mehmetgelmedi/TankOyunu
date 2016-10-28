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
        int x, y, curX = 1, curY = 1;
        string sag, sol, ust, alt, curYon, curFirca;
        int[,] kararArr;
        Bitmap imgBos;
        Bitmap imgDuvar;
        Bitmap imgTarayici;

        public void KararKontrol()
        {
            int solKarar, sagKarar, ustKarar, altKarar;
            Bitmap bmsolKarar, bmsagKarar, bmustKarar, bmaltKarar;
            ustKarar = Convert.ToInt32(dgvPanel.Rows[curY - 1].Cells[curX].ToolTipText);
            sagKarar = Convert.ToInt32(dgvPanel.Rows[curY].Cells[curX + 1].ToolTipText);
            altKarar = Convert.ToInt32(dgvPanel.Rows[curY + 1].Cells[curX].ToolTipText);
            solKarar = Convert.ToInt32(dgvPanel.Rows[curY].Cells[curX - 1].ToolTipText);
            bmustKarar = (Bitmap)dgvPanel.Rows[curY - 1].Cells[curX].Value;
            bmsagKarar = (Bitmap)dgvPanel.Rows[curY].Cells[curX + 1].Value;
            bmaltKarar = (Bitmap)dgvPanel.Rows[curY + 1].Cells[curX].Value;
            bmsolKarar = (Bitmap)dgvPanel.Rows[curY].Cells[curX - 1].Value;


            MessageBox.Show("Ust :" + ustKarar + "Sag :" + sagKarar + "Alt :" + altKarar + "Sol :" + solKarar);

            if (ustKarar < solKarar && ustKarar < sagKarar && ustKarar < altKarar)
            {
                if (bmustKarar != imgDuvar && bmustKarar == imgBos)
                    curYon = ust;
            }
            else if (solKarar < ustKarar && solKarar < sagKarar && solKarar < altKarar)
            {
                if (bmsolKarar != imgDuvar && bmsolKarar == imgBos)
                    curYon = sol;
            }
            else if (sagKarar < ustKarar && sagKarar < solKarar && sagKarar < altKarar)
            {
                if (bmsagKarar != imgDuvar && bmsagKarar == imgBos)
                    curYon = sag;
            }
            else if (altKarar < ustKarar && altKarar < solKarar && altKarar < ustKarar)
            {
                if (bmaltKarar != imgDuvar && bmaltKarar == imgBos)
                    curYon = alt;
            }
            else
                MessageBox.Show("Hatali yön");
        }
        private void frmTank_Load(object sender, EventArgs e)
        {
            imgBos = new Bitmap(@"bos.png");
            imgDuvar = new Bitmap(@"duvar.png");
            imgTarayici = new Bitmap(@"tarayici.png");
            
            //imgPasif = new Bitmap(@"pasif.png");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int iX = 1, iY = 1, z = 0, b = 0, c = 0, v = 0;
            if (curYon == sag && curX != x - 1)
            {
                z++;
                dgvPanel.Rows[curY].Cells[curX].ToolTipText = z + "";
                curX += iX;
                dgvPanel.Rows[curY].Cells[curX].Value = imgTarayici;
            }
            if (curYon == sol && curX != 0)
            {
                b++;
                dgvPanel.Rows[curY].Cells[curX].ToolTipText = b + "";
                curX -= iX;
                dgvPanel.Rows[curY].Cells[curX].Value = imgTarayici;
            }
            if (curYon == alt && curY != y - 1)
            {
                c++;
                dgvPanel.Rows[curY].Cells[curX].ToolTipText = c + "";
                curY += iY;
                dgvPanel.Rows[curY].Cells[curX].Value = imgTarayici;
            }
            if (curYon == ust && curY != 0)
            {
                v++;
                dgvPanel.Rows[curY].Cells[curX].ToolTipText = v + "";
                curY -= iY;
                dgvPanel.Rows[curY].Cells[curX].Value = imgTarayici;
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            x = int.Parse(txtX.Text);
            y = int.Parse(txtY.Text);
            try
            {
                if (x > 3 && y > 3)
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
                                cell.ToolTipText = "999";
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

                    //karar dizisi oluşturuluyor
                    kararArr = new int[x, y];
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
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Test
            KararKontrol();
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
                        dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "999";
                    }
                    else
                    {
                        dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = imgBos;
                        dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "0";
                    }
        }
    }
}
