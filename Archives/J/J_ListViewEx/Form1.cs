using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace J_ListViewEx
{
    public partial class Form1 : Form
    {
        // Db Connection String
        private const string connStr =
                "Data Source=192.168.219.103,59273;" +
                "Initial Catalog=Member;" +
                "User id=Member;" +
                "Password=B9037!m8947#;";

        /// <summary>
        /// ListView Selected Index Number
        /// </summary>
        public int SelectedIndex { get; set; }

        public Form1()
        {
            InitializeComponent();

            SelectedIndex = 0;
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitListView();
        }

        /// <summary>
        /// ListView Initialize
        /// </summary>
        private void InitListView()
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.HeaderStyle = ColumnHeaderStyle.Clickable;
            listView1.Enabled = true;
            listView1.SelectedIndexChanged += ListView1_SelectedIndexChanged;

            listView1.Columns.Add("아이디", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("이름", 200, HorizontalAlignment.Center);
            listView1.Columns.Add("이메일", 300, HorizontalAlignment.Right);
            listView1.Columns.Add("출생연도", 200, HorizontalAlignment.Center);
        }

        /// <summary>
        /// ListView Selected Index Changed Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is ListView view)) return;
            if (view.SelectedItems.Count > 0)
            {
                ListViewItem item = view.SelectedItems[0];
                SelectedIndex = item.Index;
                MessageBox.Show(item.SubItems[2].Text + Environment.NewLine + SelectedIndex);
            }
        }

        /// <summary>
        /// 목록 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_DbConnect_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from members", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                listView1.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader.GetInt32(0).ToString());
                    item.SubItems.Add(reader.GetString(1));
                    item.SubItems.Add(reader.GetString(2));
                    item.SubItems.Add(reader.GetDateTime(3).ToString("yyyy-MM-dd"));
                    listView1.Items.Add(item);
                }
                cmd.Dispose();
            }
        }
    }
}
