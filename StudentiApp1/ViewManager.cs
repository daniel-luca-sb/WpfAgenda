using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentiApp1
{
    public class ViewManager
    {
        public static Dictionary<string, Type> viewTypeList;

        static ViewManager()
        {
            viewTypeList = new Dictionary<string, Type>();

            viewTypeList.Add("MainWindow", typeof(MainWindow));
            viewTypeList.Add("MateriiView", typeof(MateriiView));
        }

        public static void ShowView(string viewName, object viewModel)
        {
            if(viewTypeList.ContainsKey(viewName))
            {
                var type = viewTypeList[viewName];
                var view = (Window)Activator.CreateInstance(type);
                view.DataContext = viewModel;

                view.Show();
            }
        }
    }
}
