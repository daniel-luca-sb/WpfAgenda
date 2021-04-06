using System;
using System.Collections.Generic;
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
    public class Friend
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

    }
}
