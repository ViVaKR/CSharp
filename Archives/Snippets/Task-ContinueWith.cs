var task1 = Task<int>.Run(() => LongCalc2(10));

task1.ContinueWith(x => {
  this.label1.Text = "Sum = " + task1.Result;
  this.button1.Enabled = true;      
}, TaskScheduler.FromCurrentSynchronizationContext());
