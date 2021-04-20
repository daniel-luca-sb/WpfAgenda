using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAgenda1.Model
{
    [Serializable]
    public class Friends
    {
        public Friend[] MyFriends { get; set; }
    }
    
    [Serializable]
    public class Friend : IDataErrorInfo
    {

        /// <summary>
        /// Prenumele
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Numele
        /// </summary>
        public string Lastname { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string ImagePath { get; set; }

        public string Error => null;
        public string this[string columnName]
        {
            get
            {
                if(columnName == "Name")
                {
                    if (string.IsNullOrEmpty(Name))
                        return "Numele nu trebuie sa lipseasca";
                }
                return null;
            }
        }
    }
}
