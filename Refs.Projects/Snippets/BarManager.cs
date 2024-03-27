private BarButtonItem CreateBarButtonItem(string caption, string name, int imageIndex)
{
	BarButtonItem item = new BarButtonItem();
	item.Caption = caption;
	item.Id = this.barManager1.GetNewItemId();
	item.ImageOptions.ImageIndex = imageIndex;
	item.Name = name;
	return item;
}

private DropDownButton CreateDropDownButton(string caption, string name, Size size)
{
	DropDownButton dropDownButton = new DropDownButton() { Dock = DockStyle.Top };
	dropDownButton.Name = name;
	dropDownButton.Text = caption;
	dropDownButton.Size = size;
	dropDownButton.ImageOptions.Image = Auto.Properties.Resources.house;
	this.Controls.Add(dropDownButton);
	return dropDownButton;
}

private PopupMenu CreatePopupMenu(BarItem[] items, BarManager manager, string name)
{
	PopupMenu menu = new PopupMenu(manager);
	menu.Name = name;
	menu.AddItems(items);
	return menu;
}
barManager1 = new BarManager();

DropDownButton dropDownButton = CreateDropDownButton("Button created at runtime", "MyButton",버튼_목록.Size);
dropDownButton.BringToFront();

//create menu items
BarButtonItem item1 = CreateBarButtonItem("Item 1", "item1", 0);
BarButtonItem item2 = CreateBarButtonItem("Item 2", "item2", 1);

//create and assign PopupMenu
dropDownButton.DropDownControl = CreatePopupMenu(new BarItem[] { item1, item2 }, this.barManager1, "MyPopupMenu");
