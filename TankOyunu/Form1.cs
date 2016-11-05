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
        int x, y, curX = 1, curY = 1, z = 0, b = 0, c = 0, v = 0, tamamlandiKontrol = 0, sayac = 0;
        string curYon = "";
        Bitmap imgBos;
        Bitmap imgDuvar;
        Bitmap imgTarayici;
        Bitmap imgDolu;
        public frmTank()
        {
            InitializeComponent();
            timer1.Interval = 300;
        }
        private void txtX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
                e.Handled = false;
            else if ((int)e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;

        }
        public void KararKontrol()
        {
            int solKarar = 0, sagKarar = 0, ustKarar = 0, altKarar = 0;
            Bitmap bmsolKarar = imgBos, bmsagKarar = imgBos, bmustKarar = imgBos, bmaltKarar = imgBos;
            if (curY - 1 >= 0)
            {
                ustKarar = Convert.ToInt32(dgvPanel.Rows[curY - 1].Cells[curX].ToolTipText);

                bmustKarar = (Bitmap)dgvPanel.Rows[curY - 1].Cells[curX].Value;
            }
            if (curX + 1 <= x)
            {
                sagKarar = Convert.ToInt32(dgvPanel.Rows[curY].Cells[curX + 1].ToolTipText);
                bmsagKarar = (Bitmap)dgvPanel.Rows[curY].Cells[curX + 1].Value;
            }
            if (curY + 1 <= y)
            {
                altKarar = Convert.ToInt32(dgvPanel.Rows[curY + 1].Cells[curX].ToolTipText);
                bmaltKarar = (Bitmap)dgvPanel.Rows[curY + 1].Cells[curX].Value;
            }
            if (curX - 1 >= 0)
            {
                solKarar = Convert.ToInt32(dgvPanel.Rows[curY].Cells[curX - 1].ToolTipText);
                bmsolKarar = (Bitmap)dgvPanel.Rows[curY].Cells[curX - 1].Value;
            }



            //MessageBox.Show("Ust :" + ustKarar + "Sag :" + sagKarar + "Alt :" + altKarar + "Sol :" + solKarar);
            if (ustKarar <= solKarar && ustKarar <= sagKarar && ustKarar <= altKarar)
            {
                if (bmustKarar != imgDuvar)
                    curYon = "ust";
            }
            else if (solKarar <= ustKarar && solKarar <= sagKarar && solKarar <= altKarar)
            {
                if (bmsolKarar != imgDuvar)
                    curYon = "sol";
            }
            else if (sagKarar <= ustKarar && sagKarar <= solKarar && sagKarar <= altKarar)
            {
                if (bmsagKarar != imgDuvar)
                    curYon = "sag";
            }
            else if (altKarar <= ustKarar && altKarar <= solKarar && altKarar <= ustKarar)
            {
                if (bmaltKarar != imgDuvar)
                    curYon = "alt";
            }

            else
                MessageBox.Show("Hatali yön");
        }



        private void frmTank_Load(object sender, EventArgs e)
        {

            imgBos = new Bitmap(@"bos.png");
            imgDuvar = new Bitmap(@"duvar.png");
            imgTarayici = new Bitmap(@"tarayici.png");
            imgDolu = new Bitmap(@"dolu.png");
            btnStart.Enabled = false;
        }

        private void oynanışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1.Oyuna başlamadan önce değerleri giriniz.\n2.Değerleri girdikten sonra oluştura işlemini gerçekleştiriniz.\n3.Başlamadan etrafı kapalı bir mayın bırakmayın bunun yanında tarayıcının etrafını kapatmayınız.", "Oynanış");
        }

        private void dgvPanel_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dgvPanel.Columns[e.Column.Index].Width = e.Column.Width;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            x = int.Parse(txtX.Text);
            y = int.Parse(txtY.Text);
            if (txtX.Text == "" || txtY.Text == "")
            {
                MessageBox.Show("Değerler Boş Geçilemez Lütfen Değerleri Doldurunuz.");
            }
            if (x <= 24 && y <= 14)
            {
                tamamlandiKontrol = (x - 2) * (y - 2) - 1;
                btnStart.Enabled = true;
                try
                {
                    if (x > 4 && y > 4)
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
                                    cell.ToolTipText = "9999";
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
                        btnCreate.Enabled = false;
                        txtX.Enabled = false;
                        txtY.Enabled = false;
                    }
                    else
                    {
                        
                        MessageBox.Show("En az 5 x 5 bir alan oluşturun.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("X değeri 5 - 100 arası olmalı");
                }
            }
            else
                MessageBox.Show("X için 24 Y için 14 ");



        }

        private void dgvPanel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.ColumnIndex == 1 && e.RowIndex == 1))
                if (e.ColumnIndex != 0 && e.ColumnIndex != dgvPanel.Columns.Count - 1 && e.RowIndex != 0 && e.RowIndex != dgvPanel.Rows.Count - 1)
                    if (dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != imgDuvar)
                    {
                        dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = imgDuvar;
                        dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "9999";
                        tamamlandiKontrol--;
                    }
                    else
                    {
                        dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = imgBos;
                        dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "0";
                        tamamlandiKontrol++;
                    }
            SonsuzKontrol();
        }
        public void BittiMi()
        {
            sayac = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (dgvPanel.Rows[j].Cells[i].Value == imgDolu)
                        sayac++;
                }
            }
            if (sayac >= tamamlandiKontrol)
            {
                timer1.Enabled = false;
                timer1.Stop();
                MessageBox.Show("Tarama Tamamlandı.");
                btnCreate.Enabled = true;
                metinAlanTemizle();
                txtX.Enabled = true;
                txtY.Enabled = true;
                btnStart.Enabled = false;
                MessageBox.Show("Yeni Sahne Açılıyor . . . ");
                Application.Restart();
            }
        }
        public void metinAlanTemizle()
        {
            foreach (TextBox txt in this.groupBox1.Controls.OfType<TextBox>())
            {
                txt.Text = "";
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            KararKontrol();
            int iX = 1, iY = 1;
            if (curYon == "sag" && curX != x - 1)
            {
                z++;
                dgvPanel.Rows[curY].Cells[curX].ToolTipText = z + "";
                dgvPanel.Rows[curY].Cells[curX].Value = imgDolu;
                curX += iX;
                dgvPanel.Rows[curY].Cells[curX].Value = imgTarayici;
            }
            if (curYon == "sol" && curX != 0)
            {
                b++;
                dgvPanel.Rows[curY].Cells[curX].ToolTipText = b + "";
                dgvPanel.Rows[curY].Cells[curX].Value = imgDolu;
                curX -= iX;
                dgvPanel.Rows[curY].Cells[curX].Value = imgTarayici;
            }
            if (curYon == "alt" && curY != y - 1)
            {
                c++;
                dgvPanel.Rows[curY].Cells[curX].ToolTipText = c + "";
                dgvPanel.Rows[curY].Cells[curX].Value = imgDolu;
                curY += iY;
                dgvPanel.Rows[curY].Cells[curX].Value = imgTarayici;
            }
            if (curYon == "ust" && curY != 0)
            {
                v++;
                dgvPanel.Rows[curY].Cells[curX].ToolTipText = v + "";
                dgvPanel.Rows[curY].Cells[curX].Value = imgDolu;
                curY -= iY;
                dgvPanel.Rows[curY].Cells[curX].Value = imgTarayici;
            }
            BittiMi();
        }
        public void SonsuzKontrol()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (dgvPanel.Rows[j].Cells[i].ToolTipText == "0")
                    {
                        if (dgvPanel.Rows[j - 1].Cells[i].ToolTipText == "9999" && dgvPanel.Rows[j + 1].Cells[i].ToolTipText == "9999" && dgvPanel.Rows[j].Cells[i + 1].ToolTipText == "9999" && dgvPanel.Rows[j].Cells[i - 1].ToolTipText == "9999")
                            MessageBox.Show("Bu alan oluşturulamaz!\nAlanı tekrardan düzenleyiniz.");
                    }
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Create and initialize a VScrollBar.
            VScrollBar vScrollBar1 = new VScrollBar();

            // Dock the scroll bar to the right side of the form.
            vScrollBar1.Dock = DockStyle.Right;

            // Add the scroll bar to the form.
            Controls.Add(vScrollBar1);
            btnCreate.Enabled = false;
            dgvPanel.Enabled = true;
            timer1.Enabled = true;
            timer1.Start();
            dgvPanel.Enabled = false;
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kullanmış olduğunuz uygulama\nYazılım sınama dersi için yapılmış.\nBir uygulamadır.", "Bilgi");
        }
    }
}
