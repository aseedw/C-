// Add a checkbox column to a datagridview
DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
checkColumn.Name = "X";
checkColumn.HeaderText = "X";
checkColumn.Width = 50;
checkColumn.ReadOnly = false;
checkColumn.FillWeight = 10; //if the datagridview is resized (on form resize) the checkbox won't take up too much; value is relative to the other columns' fill values
dataGridView1.Columns.Add(checkColumn);

// Add an event
dataGridView1.CellContentClick += dataGridView1_CellContentClick;

// Event when click DataGridViewCheckBoxColumn
private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
{
            MessageBox.Show(e.RowIndex.ToString() + " and " + e.ColumnIndex.ToString());
}

// Set checked/unchecked
dataGridView1.Rows[0].Cells[3].Value=true;
