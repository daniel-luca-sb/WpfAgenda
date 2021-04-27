using System.Collections.Generic;
using WpfAgenda1.Model;

namespace WpfAgenda1
{
    public interface IDataLayer
    {
        List<Friend> AllFriends { get; set; }

        void LoadFriends(string xmlFile);
        void SaveFriends(string file);
    }
}