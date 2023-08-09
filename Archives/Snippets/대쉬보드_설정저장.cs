using DevExpress.DashboardWin;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace FLEET.Utils
{
    public partial class 대쉬보드폼 : XtraForm
    {
        private readonly string _리소스파일;

        public 대쉬보드폼()
        {
            InitializeComponent();

            //_리소스파일 = @"‪..\..\Data\dmsdashboard.xml";
            //대쉬보드디자이너.LoadDashboard(_리소스파일);
        }

        private void 대쉬보드디자이너_DashboardSaving(object sender, DashboardSavingEventArgs e)
        {
            if (e.Command == DashboardSaveCommand.Save)
            {
                대쉬보드디자이너.Dashboard.SaveToXml(_리소스파일);

                e.Handled = true;
            }

            if (e.Command == DashboardSaveCommand.SaveAs)
            {
                DialogResult result = XtraMessageBox.Show("대쉬보드를 저장하시겠습니까?", "저장확인", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    대쉬보드디자이너.Dashboard.SaveToXml(_리소스파일);
                    e.Handled = true;

                    e.Saved = true;
                }
                if (result == DialogResult.Cancel)
                {
                    e.Handled = true;
                    e.Saved = false;
                }
            }
        }

        private void 대쉬보드디자이너_DashboardOpening(object sender, DashboardOpeningEventArgs e)
        {
            대쉬보드디자이너.LoadDashboard(_리소스파일);
            e.Handled = true;
        }

        private void 대쉬보드디자이너_DashboardSaved(object sender, DashboardSavedEventArgs e)
        {
        }
    }
}