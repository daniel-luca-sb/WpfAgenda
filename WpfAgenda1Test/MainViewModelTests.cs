using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using WpfAgenda1;
using WpfAgenda1.Model;
using Moq;

namespace WpfAgenda1Test
{
    [TestClass]
    public class MainViewModelTests
    {
        private Mock<IDataLayer> dataLayer = new Mock<IDataLayer>();
        private List<Friend> mockFriends = new List<Friend> { new Friend { Name = "a" }, new Friend { Name = "b" } };

        [TestInitialize]
        public void InitTests()
        {
            dataLayer.SetupGet(p => p.AllFriends).Returns(mockFriends);
            dataLayer.SetupSet(p => p.AllFriends).Callback(SaveFriends);
            dataLayer.Setup(p => p.LoadFriends(It.IsAny<string>()));

            //dataLayer = new FakeDataLayer();
            //dataLayer.AllFriends = new List<Friend> { new Friend { Name = "a" }, new Friend { Name = "b" } };
        }

        private void SaveFriends(List<Friend> obj)
        {
            mockFriends = obj;
        }

        [TestMethod]
        public void AddCommandTest_OK()
        {
            // Adapt
            var viewModel = new MainViewModel(dataLayer.Object);

            // Act
            viewModel.AddCommand.Execute(null);
            viewModel.SaveCommand.Execute(null);

            // Assert
            Assert.AreEqual(3, mockFriends.Count);
        }

        [TestMethod]
        public void DeleteCommandTest_Failed()
        {
            ResetDataLayer();
            var viewModel = new MainViewModel(dataLayer.Object);

            viewModel.DeleteCommand.Execute(null);
            viewModel.SaveCommand.Execute(null);

            Assert.AreEqual(2, mockFriends.Count);
        }

        [TestMethod]
        public void DeleteCommandTest_OK()
        {
            ResetDataLayer();
            var viewModel = new MainViewModel(dataLayer.Object);
            var friend = mockFriends.First();
            viewModel.SelectedFriend = friend;

            viewModel.DeleteCommand.Execute(null);
            viewModel.SaveCommand.Execute(null);

            Assert.AreEqual(1, mockFriends.Count);
        }

        [TestMethod]
        public void FilterTest_OK()
        {
            ResetDataLayer();
            var viewModel = new MainViewModel(dataLayer.Object);
            var friend = mockFriends[1];
            
            viewModel.Filter = "a";

            Assert.IsFalse(viewModel.FilteredFriends.Contains(friend));
        }

        private void ResetDataLayer()
        {
            dataLayer.SetupSet(p => p.AllFriends).Callback(SaveFriends);
        }
    }

    public class FakeDataLayer : IDataLayer
    {
        public List<Friend> AllFriends { get; set; }

        public void LoadFriends(string xmlFile)
        {
            //throw new NotImplementedException();
        }

        public void SaveFriends(string file)
        {
            //throw new NotImplementedException();
        }
    }
}
