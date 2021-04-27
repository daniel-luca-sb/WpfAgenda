using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfAgenda1.Model;

namespace WpfAgenda1
{
    public class DataLayer : IDataLayer
    {
        public List<Friend> AllFriends { get; set; }

        public void SaveFriends(string file)
        {
            var friends = new Friends();
            friends.MyFriends = AllFriends.ToArray();

            var serializer = new XmlSerializer(typeof(Friends));
            using (var stream = new StreamWriter(file))
            {
                serializer.Serialize(stream, friends);
                stream.Close();
            }
        }

        public void LoadFriends(string xmlFile)
        {
            var serializer = new XmlSerializer(typeof(Friends));
            using (var stream = new StreamReader(xmlFile))
            {
                var obj = serializer.Deserialize(stream);
                var friends = (Friends)obj;
                AllFriends = friends.MyFriends.ToList();
            }
            return;

            AllFriends = new List<Friend>();

            var friend = new Friend
            {
                Name = "Ion",
                Lastname = "Popescu",
                Adress = "Hipodromului 25",
                City = "Sibiu",
                Country = "Romania",
                Birthday = DateTime.Today.AddYears(-25),
                Phone = "0712345678"
            };
            AllFriends.Add(friend);

            friend = new Friend
            {
                Name = "Alin",
                Lastname = "Gerogescu",
                Adress = "Sibiului 25",
                City = "Brasov",
                Country = "Romania",
                Birthday = DateTime.Today.AddYears(-25),
                Phone = "0712345678"
            };
            AllFriends.Add(friend);

            friend = new Friend
            {
                Name = "Henry",
                Lastname = "Ford",
                Adress = "Chicago ave 25",
                City = "San Francisco",
                Country = "USA",
                Birthday = DateTime.Today.AddYears(-25),
                Phone = "1212345678"
            };
            AllFriends.Add(friend);
        }
    }
}
