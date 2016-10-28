using System;

public class Class1
{
	public Class1()
	{
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

            if (col.Index == 0 || col.Index == x - 1)
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
}

