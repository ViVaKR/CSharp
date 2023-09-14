protected void Paste_Click (object sender, System.EventArgs e)  
{  
   Form activeChild = this.ParentForm.ActiveMdiChild;  
   if (activeChild != null)  
   {  
      try   
      {  
         RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;  
         if (theBox != null)  
         {  
            IDataObject data = Clipboard.GetDataObject();  

            if (data.GetDataPresent(DataFormats.Text))  
            {  
               theBox.SelectedText = data.GetData(DataFormats.Text).ToString();                 
            }  
         }  
      }  
      catch   
      {  
         MessageBox.Show("You need to select a RichTextBox.");  
      }  
   }  
} 
