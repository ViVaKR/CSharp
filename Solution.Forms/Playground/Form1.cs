using System.Data;

namespace Playground
{
    public partial class Form1 : Form
    {
        private readonly DataGridView dataGridView1;

        private readonly List<Control> ControlList = [];

        public Form1()
        {
            InitializeComponent();

            Width = 1600;
            Height = 1200;
            StartPosition = FormStartPosition.CenterScreen;

            //**** (1) 부모 메인 폼에 ImeMode 지정 ****//
            ImeMode = ImeMode.Alpha; // 영문
            // ImeMode = ImeMode.Hangul; // 한글(반자)

            // 테스트 용 텍스트 박스 컨트롤
            var textbox = new TextBox { Dock = DockStyle.Top, Height = 50 };
            Controls.Add(textbox);

            // 테스트 용 그리드 뷰 컨트롤
            Controls.Add(dataGridView1 = new DataGridView { Dock = DockStyle.Fill});
            CreateDataGridView();
            dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;

            // 폼 내부의 모든 텍스트 박스 컨트롤 가져오기
            GetAllControls(this);

            // (3) 테스트 박스 ImeMode 부모 폼으로 부터 상속 박기
            foreach (Control control in ControlList)
                control.ImeMode = ImeMode.Inherit;
        }

        /// <summary>
        /// 그리드뷰 편집 컨트롤(그리드 뷰 내 컬럼의 텍스트박스)
        /// ImeMode 상속 박기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (sender is not DataGridView view) return;

            if (view.CurrentCell.EditType == typeof(DataGridViewTextBoxEditingControl))
            {
                // (4) 그리드 뷰의 텍스트 박스 셀 ImeMode 상속받기
                ((TextBox)dataGridView1.EditingControl).ImeMode = ImeMode.Inherit;
            }
        }

        /// <summary>
        /// (리커시브하게) 모든 텍스트 박스 가져오기
        /// </summary>
        /// <param name="container"></param>
        private void GetAllControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                GetAllControls(c);
                if (c is TextBox) ControlList.Add(c); // 텍스트 박스
            }
        }

        /// <summary>
        /// 그리드뷰 가상 컬럼 행 구성 및 시드 데이터 구성
        /// </summary>
        private void CreateDataGridView()
        {
            // 테스트 용 그리드뷰 데이터 바인딩

            DataTable datatable = new();
            datatable.Columns.Add("No", typeof(int));
            datatable.Columns.Add("Item", typeof(string));
            datatable.Columns.Add("quantity", typeof(int));
            datatable.Columns.Add("Price", typeof(decimal));

            for (int i = 0; i < 5; i++)
            {
                string no = $"{i + 1}";
                string item = $"Item_{i + 1}";
                string A_qty = $"{i * 12 + 1}";
                string price = $"{i * 1200}";

                datatable.Rows.Add(no, item, A_qty, price);
            }

            // 그리드 뷰의 컬럼을 텍스트 박스로 셀 에디터 특정 열에 추가
            // ImeMode Test 용
            var textboxColumn = new DataGridViewTextBoxColumn();
            dataGridView1.DataSource = datatable;
            dataGridView1.Columns.Add(textboxColumn);
        }
    }
}
