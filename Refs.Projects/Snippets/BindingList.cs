private void 바이딩리스트()
{
    using (_Db = new DmsContext())
    {
        List<기호> _기호 = new List<기호>();
        _기호 = _Db.기호.ToList();
        BindingList<기호> bindingList = new BindingList<기호>(_기호);
        BindingSource source = new BindingSource(bindingList, null);
        gridControl1.DataSource = source;
    }
}
