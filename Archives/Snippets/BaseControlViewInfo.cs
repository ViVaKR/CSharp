		private void simpleButton1_Click(object sender, EventArgs e)
		{
			BaseControlViewInfo controlViewInfo = textEdit1.GetViewInfo();
			Font font = controlViewInfo.DefaultAppearance.Font;

			MessageBox.Show(font.Name);
		}



		//private static bool CanCloseFunc(DialogResult parameter)
		//{
		//	return parameter != DialogResult.Cancel;
		//}


			//FlyoutAction action = new FlyoutAction() { Caption = "Ȯ��", Description = "���� ���� �����ðڽ��ϱ�?" };

			//Predicate<DialogResult> predicate = CanCloseFunc;

			//FlyoutCommand command1 = new FlyoutCommand() { Text = "�ݱ�", Result = DialogResult.Yes };
			//FlyoutCommand command2 = new FlyoutCommand() { Text = "���", Result = DialogResult.No };
			//action.Commands.Add(command1);
			//action.Commands.Add(command2);

			//var properties = new FlyoutProperties
			//{
			//	ButtonSize = new Size(100, 40),
			//	Style = FlyoutStyle.MessageBox,
				
			//};

			//if (FlyoutDialog.Show(this, action, properties, predicate) == DialogResult.Yes) e.Cancel = false;
			//else e.Cancel = true;