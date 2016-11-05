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
        bool dSonsuz = false;
        string curYon = "";
        Bitmap imgBos;
        Bitmap imgDuvar;
        Bitmap imgTarayici;

        private void txtX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
                e.Handled = false;
            else if ((int)e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;

        }

        Bitmap imgDolu;

        private void dgvPanel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kullanmış olduğunuz uygulama\nYazılım sınama dersi içine yapılmış.\nBir uygulamadır.");
        }

        public frmTank()
        {
            InitializeComponent();
            timer1.Interval = 300;
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
            if (ustKarar >= 999 && altKarar >= 999 && sagKarar >= 999 && solKarar >= 999)
            {
                dSonsuz = true;
            }

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
     
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtX.Text == "" || txtY.Text == "")
            {
                MessageBox.Show("Değerler Boş Geçilemez Lütfen Değerleri Doldurunuz.");
            }
            else
            {
                x = int.Parse(txtX.Text);
                y = int.Parse(txtY.Text);
                tamamlandiKontrol = (x - 2) * (y - 2) - 1;
                //MessageBox.Show(tamamlandiKontrol.ToString());
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
           
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnCreate.Enabled = false;
            dgvPanel.Enabled = false;
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
                        tamamlandiKontrol--;
                        //MessageBox.Show(tamamlandiKontrol+"");
                    }
                    else
                    {
                        dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = imgBos;
                        dgvPanel.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "0";
                        tamamlandiKontrol++;
                        //MessageBox.Show(tamamlandiKontrol + "");
                    }
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
                //sıfırlama
                btnCreate.Enabled = true;
                metinAlanTemizle();
                txtX.Enabled = true;
                txtY.Enabled = true;
                btnStart.Enabled = false;
                lblNot.Text = "Tekrar Oynaka İçin \n Değerleri Giriniz \n Sahneyi Oluşturunuz";
                txtX.Focus();
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
            //foreach (DataGridViewRow row in dgvPanel.Rows)
            //{
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        if (cell.ToolTipText == "998")
            //        {
            //            dSonsuz = true;
            //            break;
            //        }
            //    }
            //}
            //HATALI
            if (dSonsuz)
            {
                timer1.Enabled = false;
                MessageBox.Show("Sonsuz döngüye girdi.");
                x = 0; y = 0; curX = 1; curY = 1; z = 0; b = 0; c = 0; v = 0; tamamlandiKontrol = 0; sayac = 0;
                


            }
            BittiMi();
        }
    }
}
