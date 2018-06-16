using System;
using System.Windows.Forms;
using NLog;

namespace ACMReport3
{
    public partial class Form_Report : Form
    {
        // Logger
        private static Logger log = LogManager.GetCurrentClassLogger();

        public Form_Report()
        {
            InitializeComponent();
        }


        private void Form_Report_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "acmreportDataSet.query". При необходимости она может быть перемещена или удалена.
            this.queryTableAdapter.Fill(this.acmreportDataSet.query);
        }

        private void SaveChanges()
        {
            try
            {
                if (queryTableAdapter != null && acmreportDataSet.query.GetChanges() != null)
                    queryTableAdapter.Update(acmreportDataSet.query);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //Validate();
            //    //queryBindingSource.EndEdit();
            //    //queryTableAdapter.Update(acmreportDataSet.query);
            //    //((Form_Parent)ParentForm).ShowStatusbarMessage("обновление выполнено.");

            //    //acmreportDataSet.query.LoadDataRow(new object[] { cb_query.SelectedValue, cb_query.SelectedText }, false);
            //    //acmreportDataSet.query.EndLoadData();
            //    //((Form_Parent)ParentForm).ShowStatusbarMessage("save. ");
            //}
            //catch
            //{
            //    ((Form_Parent)ParentForm).ShowStatusbarMessage("не могу обновить.");
            //}

            // В DataSet работает, надо, чтобы данные изменялись в базе данных
            //acmreportDataSet.query.LoadDataRow(new object[] { (int)cb_query.SelectedValue, "eee", "rrr" }, true);
            //acmreportDataSet.query.EndLoadData();

            ((Form_Parent)ParentForm).ShowStatusbarMessage("save.");
        }

        private void Button_Reset_Click(object sender, EventArgs e)
        {
            //cb_query.ResetText();
            //tb_query.ResetText();
            //queryTableAdapter.Fill(acmreportDataSet.query);
        }

        private void Button_Delete_Click(object sender, EventArgs e)
        {
            //this.queryTableAdapter.Delete((int)cb_query.SelectedValue, cb_query.SelectedText);
            //((Form_Parent)ParentForm).ShowStatusbarMessage(cb_query.SelectedValue.ToString());
        }

        private void button_Add_Click(object sender, EventArgs e)
        {

        }

        private void Cb_query_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)cb_query.SelectedValue;
            tb_query.Text = this.acmreportDataSet.query.FindById(id).query_sql;
            ((Form_Parent)ParentForm).ShowStatusbarMessage(id.ToString());
        }
    }
}
