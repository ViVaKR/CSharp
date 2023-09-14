
{
    Image msg;
    Thread staThread = new Thread(
    delegate ()
    {
        _ex.Rng.Copy(Type.Missing);
        Image img = Clipboard.GetImage();
        msg = Clipboard.GetImage();

        _ex.Points[0] = Convert.ToSingle(_ex.Rng.Left + 100);
        _ex.Shape = _ex.CreateRect(_ex.Points, "Hello", _바탕색, _선색);
        _ex.Shape.CopyPicture(Clipboard.GetImage());
    });
    staThread.SetApartmentState(ApartmentState.STA);
    staThread.Start();
    staThread.Join();
}