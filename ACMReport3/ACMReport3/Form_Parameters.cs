using NLog;
using Npgsql;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Collections.Generic;
using System.Globalization;

namespace ACMReport3
{
    public partial class Form_Parameters : Form
    {
        // Logger
        private static Logger log = LogManager.GetCurrentClassLogger();

        public Form_Parameters()
        {
            InitializeComponent();

        }

        private void Form_Parameters_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form_Parent)this.Owner).ShowStatusbarMessage("");
            log.Debug("Close parameters form");
            Array.Clear(sql_param, 0, sql_param.Length); 
        }

        private void ButtonRun_Click(object sender, EventArgs e)
        {
            string reportName = ((Form_Parent)this.Owner).reportName;
            ((Form_Parent)this.Owner).ShowStatusbarMessage("Building " + reportName);
            log.Debug("Building {0}", reportName);

            // prepare parameters for SQL query
            List<Control> ctrl = GetAllControls(gbFilter);
          
            for (int i = 0; i < sql_param.Length; i++)
            {
                string date = "";
                string time = "";
               
                foreach (Control c in ctrl)
                {
                    if (c.Name.EndsWith("_date"))
                        date = c.Text;

                    if (c.Name.EndsWith("_time"))
                        time = c.Text;

                    if (c.Name.EndsWith("_hidden"))
                    {
                        c.Text = date + " " + time;
                        string s = c.Name.ToString();
                        c.Name = s.Substring(0, s.Length-7);
                        //log.Debug("dt: {0}", c.Text);
                    }

                    if (sql_param[i] == c.Name)
                    {
                        sql_param[i] = c.Text;
                        //log.Debug("c.Name = {0}, res = {1}", c.Name, sql_param[i]);
                    }                    
                }
            }

            // Log final parameters array
            for (int j = 0; j < sql_param.Length; j++)
            {
                log.Trace("Parameter {0}: {1}", j, sql_param[j]);
            }

            //TODO: sql_param keep all parameters in right order
            // Ready send them to SqlCommend as Parameters.
            // Run Result into gridview of parent form.
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private AutoCompleteStringCollection GetAutoSourceCollectionFromTable(DataTable table)
        {
            AutoCompleteStringCollection autoSourceCollection = new AutoCompleteStringCollection();
            foreach (DataRow row in table.Rows)
            {
                // assuming required data is in the first column
                autoSourceCollection.Add(row[0].ToString());
            }
            return autoSourceCollection;
        }

        // Remove empty values from parameters array
        private string[] CleanArray(string[] arr)
        {
            // convert array into the list to remove empty items    
            List<string> temp = new List<string>();
            foreach (var s in arr)
            {
                if (!string.IsNullOrEmpty(s))
                    temp.Add(s);
            }
            return temp.ToArray();
        }


    private static List<Control> GetAllControls(Control control)
        {
            List<Control> list = new List<Control>();
            foreach (Control c in control.Controls)
            {
                if (c.Name != "")
                {
                    list.Add(c);
                    log.Trace("Get Control: {0}", c.Name);
                }

                if (c.Controls != null)
                {
                    GetAllControls(c);
                }
            }
            return list;
        }

        /// <summary>
        /// Gets the X-Path to a given Node
        /// </summary>
        /// <param name="node">The Node to get the X-Path from</param>
        /// <returns>The X-Path of the Node</returns>
        public string GetXPathToNode(XmlNode node)
        {
            if (node.NodeType == XmlNodeType.Attribute)
            {
                // attributes have an OwnerElement, not a ParentNode; also they have             
                // to be matched by name, not found by position             
                return String.Format("{0}/@{1}", GetXPathToNode(((XmlAttribute)node).OwnerElement), node.Name);
            }
            if (node.ParentNode == null)
            {
                // the only node with no parent is the root node, which has no path
                return "";
            }

            // Get the Index
            int indexInParent = 1;
            XmlNode siblingNode = node.PreviousSibling;
            // Loop thru all Siblings
            while (siblingNode != null)
            {
                // Increase the Index if the Sibling has the same Name
                if (siblingNode.Name == node.Name)
                {
                    indexInParent++;
                }
                siblingNode = siblingNode.PreviousSibling;
            }

            // the path to a node is the path to its parent, plus "/node()[n]", where n is its position among its siblings.         
            return String.Format("{0}/{1}[{2}]", GetXPathToNode(node.ParentNode), node.Name, indexInParent);
        }

        private static String pluginName;

        private static string[] sql_param = new string[20]; // SQL Parameters

        XmlNode param_index;
        XmlNode param_name;
        XmlNode param_type;
        XmlNode param_field;
        XmlNode param_label;

        private void Form_Parameters_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor; // change cursor to wait form
            ((Form_Parent)this.Owner).ShowStatusbarMessage("Loading data...");

            ((Form_Parent)this.Owner).OpenConnection();

            // init element position
            Point start_label = new Point(5, 23);
            Point start_element = new Point(185, 23);
            int vert_interval = 29;

            int i = 0; // control counter
            int cur_index = 0; // current parameter index

            // read and parse XML
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(((Form_Parent)this.Owner).fnPlugin);

            XmlElement xRoot = xDoc.DocumentElement; // get first root element

            // loop all elements in root
            foreach (XmlNode xnode in xRoot)
            {
                // loop all child nodes for element "plugin"
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    // get plugin name
                    if (childnode.Name == "name") pluginName = childnode.InnerText;
                    // read parameters only for selected plugin node
                    if (pluginName == ((Form_Parent)this.Owner).reportName) 
                    {
                        if (childnode.Name == "name")
                        {
                            log.Debug("plugin name: " + pluginName);
                        }
                        // if node is "query"
                        if (childnode.Name == "query")
                        {
                            log.Debug("query: " + childnode.InnerText);
                        }
                        // if node is "parameters"
                        if (childnode.Name == "parameters")
                        {
                            foreach (XmlNode paramnode in childnode)
                            {
                                // if node is "param"
                                if (paramnode.Name == "param")
                                {
                                    // get attributes
                                    if (paramnode.Attributes.Count > 0)
                                    {
                                        param_index = paramnode.Attributes.GetNamedItem("index");
                                        param_name = paramnode.Attributes.GetNamedItem("name");
                                        param_type = paramnode.Attributes.GetNamedItem("type");
                                        param_field = paramnode.Attributes.GetNamedItem("field");
                                        param_label = paramnode.Attributes.GetNamedItem("label");

                                        if (param_type != null)
                                            log.Debug("type: " + param_type.Value);
                                        if (param_field != null)
                                            log.Debug("field: " + param_field.Value);

                                        // parameter index
                                        if (param_index != null)
                                        {
                                            log.Debug("index: " + param_index.Value);
                                            // add empty paramter to the list to be used in SQL query
                                            try
                                            {
                                                Int32.TryParse(param_index.Value, out cur_index);
                                                sql_param[cur_index] = "---";
                                                log.Trace("Index parsed as {0}", cur_index);
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Error("Could not parse index attribute: {0}", ex.Message);
                                            }
                                        }

                                        // name
                                        if (param_name != null)
                                        {
                                            log.Debug("name: " + param_name.Value);
                                            sql_param[cur_index] = param_name.Value;
                                        }

                                        // label
                                        if (param_label != null)
                                        {
                                            Label lb = new Label();
                                            lb.Text = param_label.Value;
                                            lb.Location = new Point(start_label.X, start_label.Y + vert_interval * i);
                                            lb.Width = 170;
                                            gbFilter.Controls.Add(lb);
                                            log.Debug("label: " + param_label.Value);
                                        }

                                        // textbox
                                        if (param_type.Value == "string" && !paramnode.HasChildNodes)
                                        {
                                            TextBox tb = new TextBox();
                                            tb.Name = param_name.Value;
                                            tb.Width = 300;
                                            tb.TabIndex = i * 10;
                                            tb.Location = new Point(start_element.X, start_element.Y + vert_interval * i);
                                            gbFilter.Controls.Add(tb);
                                        }

                                        // date and time pickers
                                        if (param_type.Value == "datetime") {
                                            DateTimePicker dt_date = new DateTimePicker();
                                            dt_date.Name = param_name.Value + "_date";
                                            dt_date.Format = DateTimePickerFormat.Custom;
                                            dt_date.CustomFormat = "yyyy-MM-dd";
                                            dt_date.Width = 190;
                                            dt_date.TabIndex = i * 10;
                                            dt_date.MinDate =new DateTime(1900, 01, 01);
                                            dt_date.MaxDate = new DateTime(2100, 12, 31);
                                            dt_date.Location = new Point(start_element.X, start_element.Y + vert_interval * i);
                                            gbFilter.Controls.Add(dt_date);

                                            DateTimePicker dt_time = new DateTimePicker();
                                            dt_time.Name = param_name.Value + "_time";
                                            dt_time.Format = DateTimePickerFormat.Custom;
                                            dt_time.CustomFormat = "hh:mm:ss";
                                            dt_time.Width = 90;
                                            dt_time.TabIndex = i * 10 + 5;
                                            dt_time.ShowUpDown = true;
                                            dt_time.Location = new Point(start_element.X + 210, start_element.Y + vert_interval * i);
                                            gbFilter.Controls.Add(dt_time);

                                            // use hidden control to join date and time
                                            TextBox dt_hidden = new TextBox();
                                            dt_hidden.Name = param_name.Value + "_hidden";
                                            dt_hidden.Visible = false;
                                            gbFilter.Controls.Add(dt_hidden);
                                        }
                                    }

                                    // dropdown combobox
                                    foreach (XmlNode subquerynode in paramnode)
                                    {
                                        Boolean cache = (Boolean)Properties.Settings.Default["cache"];
                                        
                                        if (cache)
                                        {
                                            // read data with cache
                                            // Npgsql bulk copy: http://www.npgsql.org/doc/copy.html
                                            // PostgreSQL COPY command: https://www.postgresql.org/docs/current/static/sql-copy.html
                                            string query = @"COPY (" + paramnode.InnerText + ") TO STDOUT (FORMAT 'CSV')";
                                            //NpgsqlCommand cmdRemote = new NpgsqlCommand(query, ((Form_Parent)this.Owner).connRemote);
                                            using( var reader = ((Form_Parent)this.Owner).connRemote.BeginTextExport(query))
                                            {
                                                log.Trace(reader.ReadLine());
                                            }
                                            SqlCommand cmdLocal = new SqlCommand(query, ((Form_Parent)this.Owner).connLocal);
                                            // TODO: bulk copy to cache, try/catch reader, while reader -1
                                        }
                                        else
                                        {
                                            // read data without cache
                                            string query = paramnode.InnerText;
                                            var dt = new DataTable();
                                            try
                                            {
                                                NpgsqlCommand cmd = new NpgsqlCommand(query, ((Form_Parent)this.Owner).connRemote);
                                                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                                                dt = new DataTable();
                                                da.Fill(dt);
                                                log.Info("Combobox populated");
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Error("Could not connect to remote database while trying to populate combobox: {0}", ex.Message);
                                            }
                                            
                                            // fill dropbox content
                                            ComboBox cb = new ComboBox();
                                            cb.DataSource = dt;
                                            cb.Name = param_name.Value;
                                            cb.DisplayMember = param_field.Value;
                                            cb.ValueMember = param_field.Value;
                                            cb.AutoCompleteCustomSource = GetAutoSourceCollectionFromTable(dt);
                                            cb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                                            cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                                            cb.DropDownStyle = ComboBoxStyle.DropDown;
                                            cb.Width = 300;
                                            cb.TabIndex = i * 10;
                                            cb.Location = new Point(start_element.X, start_element.Y + vert_interval * i);
                                            gbFilter.Controls.Add(cb);
                                            log.Debug("sub-query: {0}", paramnode.InnerText);
                                        }                                       
                                    }
                                }
                                log.Debug("xml path: {0}", GetXPathToNode(paramnode));

                                i++;
                            }
                        }
                    }
                }

                ((Form_Parent)this.Owner).ShowStatusbarMessage("Data loaded");
                Cursor.Current = Cursors.Default; // change cursor back to default form
            }
            // resize form
            this.Height = i * vert_interval + 130;

            ((Form_Parent)this.Owner).CloseConnection();

            // Log raw sql parameters array
            sql_param = CleanArray(sql_param); // remove empty items
            for (int j = 0; j < sql_param.Length; j++)
            {
                log.Trace("P {0}: {1}", j, sql_param[j]);
            }
        }

    }
}
