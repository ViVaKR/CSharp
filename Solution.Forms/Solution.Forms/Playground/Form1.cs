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

            //**** (1) �θ� ���� ���� ImeMode ���� ****//
            ImeMode = ImeMode.Alpha; // ����
            // ImeMode = ImeMode.Hangul; // �ѱ�(����)

            // �׽�Ʈ �� �ؽ�Ʈ �ڽ� ��Ʈ��
            var textbox = new TextBox { Dock = DockStyle.Top, Height = 50 };
            Controls.Add(textbox);

            // �׽�Ʈ �� �׸��� �� ��Ʈ��
            Controls.Add(dataGridView1 = new DataGridView { Dock = DockStyle.Fill});
            CreateDataGridView();
            dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;

            // �� ������ ��� �ؽ�Ʈ �ڽ� ��Ʈ�� ��������
            GetAllControls(this);

            // (3) �׽�Ʈ �ڽ� ImeMode �θ� ������ ���� ��� �ڱ�
            foreach (Control control in ControlList)
                control.ImeMode = ImeMode.Inherit;
        }

        /// <summary>
        /// �׸���� ���� ��Ʈ��(�׸��� �� �� �÷��� �ؽ�Ʈ�ڽ�)
        /// ImeMode ��� �ڱ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (sender is not DataGridView view) return;

            if (view.CurrentCell.EditType == typeof(DataGridViewTextBoxEditingControl))
            {
                // (4) �׸��� ���� �ؽ�Ʈ �ڽ� �� ImeMode ��ӹޱ�
                ((TextBox)dataGridView1.EditingControl).ImeMode = ImeMode.Inherit;
            }
        }

        /// <summary>
        /// (��Ŀ�ú��ϰ�) ��� �ؽ�Ʈ �ڽ� ��������
        /// </summary>
        /// <param name="container"></param>
        private void GetAllControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                GetAllControls(c);
                if (c is TextBox) ControlList.Add(c); // �ؽ�Ʈ �ڽ�
            }
        }

        /// <summary>
        /// �׸���� ���� �÷� �� ���� �� �õ� ������ ����
        /// </summary>
        private void CreateDataGridView()
        {
            // �׽�Ʈ �� �׸���� ������ ���ε�

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

            // �׸��� ���� �÷��� �ؽ�Ʈ �ڽ��� �� ������ Ư�� ���� �߰�
            // ImeMode Test ��
            var textboxColumn = new DataGridViewTextBoxColumn();
            dataGridView1.DataSource = datatable;
            dataGridView1.Columns.Add(textboxColumn);
        }
    }
}
