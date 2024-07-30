using MySqlConnector;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSAlertSys
{
    // Class which is responsible for the data grid view "Display" of data. 
    class DataGridViewClass : Form
    {
        private Button refreshBtn;
        private Button cancelBtn;
        private Button removeBtn;
        private Button saveNUpdateBtn;
        private DataGridView dataGridView1;

        private BindingSource bs = null;

        // Constructor which at the same time initializes all needed components for the method or other classes only to call ".Show()" to have the grid.
        public DataGridViewClass()
        {
            try
            {
                this.bs = new BindingSource();
                this.bs.DataSource = GlobalVars.cache;
                InitializeComponent();
                refreshGrid();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.saveNUpdateBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1268, 295);
            this.dataGridView1.TabIndex = 0;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(1124, 313);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshBtn.TabIndex = 1;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(1205, 313);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(171, 313);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(75, 23);
            this.removeBtn.TabIndex = 3;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // saveNUpdateBtn
            // 
            this.saveNUpdateBtn.Location = new System.Drawing.Point(12, 313);
            this.saveNUpdateBtn.Name = "saveNUpdateBtn";
            this.saveNUpdateBtn.Size = new System.Drawing.Size(153, 23);
            this.saveNUpdateBtn.TabIndex = 4;
            this.saveNUpdateBtn.Text = "Save and Upload";
            this.saveNUpdateBtn.UseVisualStyleBackColor = true;
            this.saveNUpdateBtn.Click += new System.EventHandler(this.saveNUpdateBtn_Click);
            // 
            // DataGridViewClass
            // 
            this.ClientSize = new System.Drawing.Size(1293, 345);
            this.Controls.Add(this.saveNUpdateBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataGridViewClass";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

        // Populates the grid with the cache being the binding source's Datasource and therefore being the DataSource of the datagridview.
        private void populateGrid()
        {
            try
            {
                dataGridView1.DataSource = this.bs;
                dataGridView1.AutoResizeRows(); 
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoResizeColumnHeadersHeight();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        // Closes the form
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // This is based on the same concept as the one when one refreshes a webpage.
        // A new request to the SQL server which gives back the current and actual database table.
        // The grid then gets populated again.
        private void refreshGrid()
        {
            GlobalVars.connection.Open();
            GlobalVars.cache = GlobalVars.sc.retrieveDbTbl();

            this.bs.DataSource = GlobalVars.cache;
            this.populateGrid();

            GlobalVars.connection.Close();
        }

        // Button for the method "refreshGrid()"
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }

        // Removes rows from the datagridview which in turn removes rows from the "cache" as well.
        // Algorithm got added which works in conjunction with another global variable: List GlobalVars.idxOfRemovedRows.
        // The list keeps track of the indices of the deleted rows which in turn is used for the DELETE query in the SQL class.
        private void removeBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                GlobalVars.idxOfRemovedRows.Add(row.Index);
                //GlobalVars.cache.Rows.RemoveAt(row.Index);
                dataGridView1.Rows.RemoveAt(row.Index);
            }
        }

        // Final button in this class which works together with SQL class and the method "removeBtn_Click" to update the table in the database.
        private void saveNUpdateBtn_Click(object sender, EventArgs e)
        {
            this.bs.DataSource = GlobalVars.cache;
            this.populateGrid();
            GlobalVars.cache.AcceptChanges();
            GlobalVars.sc.updateDbTbl();
        }
    }
}
