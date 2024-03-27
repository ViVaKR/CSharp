using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

namespace CustomerCare
{
    public partial class MainForm : Form
    {
        private Customer customer;

        private string scrName;

        public string ScrName
        {
            get => scrName;
            set
            {
                string checkPhone = string.IsNullOrEmpty(ScrPhone) ? null : $" And Phone = '{ScrPhone}'";
                string checkSex = ScrSex == Sex.Unknown ? null : $" And Sex = {(int)ScrSex}";
                WhereSql = !string.IsNullOrEmpty(scrName = value) ? $" Where Name = '{value}' {checkSex} {checkPhone}" : null;
            }
        }

        private Sex? scrSex;

        public Sex? ScrSex
        {
            get => scrSex;
            set
            {
                string checkName = string.IsNullOrEmpty(ScrName) ? null : $" And Name = '{ScrName}'";
                string checkPhone = string.IsNullOrEmpty(ScrPhone) ? null : $" And Phone = '{ScrPhone}'";
                WhereSql = (value != Sex.Unknown) ? $" Where Sex = {(int)value} {checkName} {checkPhone}" : null;
                scrSex = value;
            }
        }

        private string scrPhone;

        public string ScrPhone
        {
            get => scrPhone;
            set
            {
                string checkName = string.IsNullOrEmpty(ScrName) ? null : $" And Name = '{ScrName}'";
                string checkSex = ScrSex == Sex.Unknown ? null : $" And Sex = {(int)ScrSex}";
                WhereSql = !string.IsNullOrEmpty(scrPhone = value) ? $" Where Phone = '{value}' {checkSex} {checkName}" : null;
            }
        }

        private readonly string searchSql = "Select * From Customer";

        private string whereSql = string.Empty;

        public string WhereSql
        {
            get => whereSql;
            set => DataSearch(string.IsNullOrEmpty(whereSql = value) ? searchSql : $" {searchSql} {value}");
        }

        private int selectedId = -1;

        const string conStr =
             "Server=localhost,59273;" +
             "Database=ViV;" +
             "User ID=ViV;" +
             "Password=비밀번호!블라블라;" +
             "Encrypt=Yes;" +
             "TrustServerCertificate=Yes;";

        public MainForm()
        {
            InitializeComponent();

            Load += MainForm_Load;


            // 좌우 분리 컨테이너
            Splite_Panel.Resize += (s, e) =>
            {
                if (WindowState != FormWindowState.Minimized)
                {
                    Splite_Panel.SplitterDistance = Width / 2;
                }
            };


            // 검색
            Group_Search.Resize += (s, e) => Group_Search.Height = 80;


            // 버튼그룹
            Group_Buttons.Resize += (s, e) => Group_Buttons.Height = 110;

            Shown += (s, e) => WindowState = FormWindowState.Maximized;

            Grid_Customer.CellClick += Grid_Customer_CellClick;


            TxtScr_Name.TextChanged += (s, e) => ScrName = TxtScr_Name.Text;

            TxtScr_Phone.TextChanged += (s, e) => ScrPhone = TxtScr_Phone.Text;

            CmbScr_Sex.SelectedIndexChanged += (s, e) =>
            {
                var x = s as ComboBox;

                bool tf = Enum.TryParse(x.Text, out Sex sex);
                if (!tf) return;
                ScrSex = sex;
            };

            Grid_Customer.CellFormatting += (s, e) =>
                {
                    var view = s as DataGridView;
                    if (view.Columns[e.ColumnIndex].Index == 2)
                    {
                        Sex enumValue = (Sex)e.Value;

                        string str = string.Empty;
                        switch (enumValue)
                        {
                            case Sex.Male: str = "남성"; break;
                            case Sex.FeMale: str = "여성"; break;
                            case Sex.Unknown: str = "모름"; break;
                        }

                        e.Value = str;
                    }
                };
        }

        private void DataSearch(string queryString)
        {
            using (var conn = new SqlConnection(conStr))
            {
                try
                {
                    conn.Open();

                    var cmd = new SqlCommand(queryString, conn);

                    var da = new SqlDataAdapter(cmd);
                    var tb = new DataTable();

                    da.Fill(tb);

                    Grid_Customer.DataSource = tb;
                }
                catch (SqlException ex)
                {
                    Txt_Memo.Text = ex.Message;
                }
            }
        }

        private void Grid_Customer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            var view = sender as DataGridView;

            var id = view.Rows[e.RowIndex].Cells[0].Value.ToString();

            Txt_ID.Text = id;

            GetDataById(selectedId = Convert.ToInt32(id));

            SetButtonStatus(true, true, true);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetAllData();
            ConfigGridView();

            Cmb_Sex.DataSource = Enum.GetNames(typeof(Sex));
            Cmb_Sex.SelectedIndex = -1;
            CmbScr_Sex.DataSource = Enum.GetNames(typeof(Sex));
            CmbScr_Sex.SelectedIndex = 2;
            WhereSql = null;
            Txt_ID.Enabled = false;
            FilterClear();
        }

        /// <summary>
        /// 데이터 그리드뷰 기본 환경설정
        /// </summary>
        private void ConfigGridView()
        {

            PropertyInfo[] props = typeof(Customer).GetProperties();

            Dictionary<int, string> columns = new Dictionary<int, string>();
            foreach (var prop in props)
            {
                var p = prop.GetCustomAttributes();
                foreach (Attribute item in p)
                {
                    if (item.GetType() != typeof(DisplayAttribute)) continue;
                    var attr = (DisplayAttribute)prop.GetCustomAttribute(typeof(DisplayAttribute));

                    columns.Add(attr.Order, attr.Name);
                }
            }

            foreach (var col in columns)
            {
                Grid_Customer.Columns[col.Key].HeaderText = col.Value;
            }


        }

        /// <summary>
        /// 데이터 목록 갱신
        /// </summary>
        /// <param name="source"></param>
        private void GetAllData()
        {
            string sql = "Select * From Customer Order By Id Desc";

            using (var conn = new SqlConnection(conStr))
            {
                try
                {
                    conn.Open();
                    var cmd = new SqlCommand(sql, conn);


                    var da = new SqlDataAdapter(cmd);
                    var tb = new DataTable();
                    da.Fill(tb);

                    Grid_Customer.DataSource = tb;
                }
                catch (SqlException ex)
                {
                    Txt_Memo.Text = ex.Message;
                }
            }

            SetButtonStatus(true, false, false);
        }


        /// <summary>
        /// ID 값으로 데이터 추출
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="Exception"></exception>
        private async void GetDataById(int id)
        {
            string sql = "Select * From Customer Where Id = @id";

            using (var conn = new SqlConnection(conStr))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand(sql, conn))
                    {
                        comm.Parameters.AddWithValue("@id", id);

                        using (var reader = await comm.ExecuteReaderAsync())
                        {
                            if (!reader.Read())
                                throw new Exception("데이터 가져오기에 실패하였습니다.");

                            customer = new Customer
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Sex = (Sex)reader.GetInt32(2),
                                Phone = reader.GetString(3),
                                Region = reader.GetString(4),
                                Memo = reader.GetString(5)
                            };


                            Txt_ID.Text = customer.Id.ToString();
                            Txt_Name.Text = customer.Name;
                            Cmb_Sex.SelectedIndex = (int)customer.Sex;
                            Txt_Phone.Text = customer.Phone;
                            Txt_Region.Text = customer.Region;
                            Txt_Memo.Text = customer.Memo;

                        }
                    }

                }
                catch (SqlException ex)
                {
                    Txt_Memo.Text = ex.Message;
                }
            }
        }

        private void Delete(int id)
        {
            DialogResult ask = MessageBox.Show($"고객번호 {id} - 고객명 {customer.Name} 자료를 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (ask == DialogResult.Cancel) return;

            string sql = "Delete From Customer Where Id = @id";

            using (var conn = new SqlConnection(conStr))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        var result = cmd.ExecuteNonQueryAsync();
                        if (result.Result > 0)
                        {
                            MessageBox.Show($"고객번호 {id} 고객 삭제 완료", "삭제완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            GetAllData();
                        }
                    }

                }
                catch (SqlException ex)
                {
                    Txt_Memo.Text = ex.Message;
                }
            }
        }

        /// <summary>
        /// 필터지움
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ClearFilter_Click(object sender, EventArgs e)
        {
            FilterClear();
        }

        private void FilterClear()
        {
            TxtScr_Name.Text = string.Empty;
            TxtScr_Phone.Text = string.Empty;
            CmbScr_Sex.SelectedIndex = -1;
            Grid_Customer.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            SetButtonStatus(true, false, false);
            if (customer == null)
            {
                MessageBox.Show("삭제할 데이터를 선태하여 주세요", "삭제오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            Delete(customer.Id);
        }

        private void Btn_New_Click(object sender, EventArgs e)
        {
            SetButtonStatus(false, false, false);

            Txt_ID.Text = "-";
            Txt_Name.Text = string.Empty;
            Txt_Phone.Text = string.Empty;
            Cmb_Sex.SelectedIndex = -1;
            Txt_Region.Text = string.Empty;
            Txt_Memo.Text = string.Empty;

            MessageBox.Show("신규 자료를 모두 입력하신 후 Save Button 으로 저장하여 주세요.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Txt_Name.Focus();
        }

        /// <summary>
        ///  버튼상태 조절
        /// </summary>
        /// <param name="add">신규버튼</param>
        /// <param name="update">수정버튼</param>
        /// <param name="delete">삭제버트</param>
        /// <param name="save">저장버튼</param>
        private void SetButtonStatus(bool add, bool update, bool delete)
        {
            Btn_New.Enabled = add;
            Btn_Update.Enabled = update;
            Btn_Delete.Enabled = delete;
            Btn_Save.Enabled = !Btn_New.Enabled;
        }

        private void InsertUpdate(bool choice = true)
        {
            string name = Txt_Name.Text ?? null;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("이름은 필수 입력 사항입니다. 이름을 입력하여주세요", "이름 입력", MessageBoxButtons.OK);
                Txt_Name.Focus();
                return;
            }
            string phone = Txt_Phone.Text ?? string.Empty;
            string region = Txt_Region.Text ?? string.Empty;
            string memo = Txt_Memo.Text ?? string.Empty;
            string maxId = "Select MAX(Id) from Customer";

            string sql = choice
                 ? "Insert Into Customer (Id, Name, Sex, Phone, Region, Memo) Values (@id, @name, @sex, @phone, @region, @memo)"
                 : "Update Customer Set Name = @name, Sex = @sex, Phone = @phone, Region = @region, Memo = @memo Where Id = @id";

            using (var conn = new SqlConnection(conStr))
            {
                try
                {
                    conn.Open();

                    var cmd = new SqlCommand(maxId, conn);
                    var mId = cmd.ExecuteScalar();

                    using (cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", choice ? Convert.ToInt32(mId) + 1 : selectedId);
                        cmd.Parameters.AddWithValue("@name", name);
                        Sex sex = (Sex)Enum.Parse(typeof(Sex), Cmb_Sex.Text);
                        cmd.Parameters.AddWithValue("@sex", sex);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@region", region);
                        cmd.Parameters.AddWithValue("@memo", memo);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            GetAllData();
                            Grid_Customer.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                            var message = string.Format("{0}", choice ? "데이터 저장완료 되었습니다!" : "데이터 수정완료");
                            MessageBox.Show(message, "완료");
                        }
                    }


                }
                catch (SqlException ex)
                {
                    Txt_Memo.Text = ex.Message;
                }
            }

        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            SetButtonStatus(true, false, false);

            InsertUpdate();
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            SetButtonStatus(true, false, false);
            InsertUpdate(false);

        }
    }
}
