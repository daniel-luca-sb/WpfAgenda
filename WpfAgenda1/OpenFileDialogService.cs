using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace WpfAgenda1
{
    public class OpenFileDialogService : IOService
    {
        public string OpenFileDialog()
        {
            var openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "Imagine bitmap (*.bmp)|*.bmp|Imagine jpeg (*.jpg)|*.jpg|Imagine png (*.png)|*.png|Toate fisierele (*.*)|*.*";
            openFileDlg.CheckFileExists = true;
            openFileDlg.Title = "Image files";
            if ((bool)openFileDlg.ShowDialog())
                return openFileDlg.FileName;
            else
                return "";
        }
    }
}
