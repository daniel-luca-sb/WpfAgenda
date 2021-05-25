using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentiApp1
{
    public class MainViewModel
    {
        private StudentiEntities context;

        public ObservableCollection<Studenti> StudentList { get; set; }
        public ObservableCollection<Materii> MateriiList { get; set; }

        public ICommand SaveCommand { get; set; }
        public ICommand ShowMateriiCommand { get; set; }

        public MainViewModel()
        {
            context = new StudentiEntities();

            context.Studenti.Load();
            StudentList = context.Studenti.Local;

            context.Materii.Load();
            MateriiList = context.Materii.Local;

            SaveCommand = new DelegateCommand(OnSaveCommand);
            ShowMateriiCommand = new DelegateCommand(OnShowMaterii);
        }

        private void OnShowMaterii(object obj)
        {
            ViewManager.ShowView("MateriiView", this);
        }

        private void OnSaveCommand(object obj)
        {
            context.SaveChanges();
        }
    }
}
