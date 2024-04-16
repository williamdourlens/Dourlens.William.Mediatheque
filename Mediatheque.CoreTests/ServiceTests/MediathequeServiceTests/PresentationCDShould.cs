using Mediatheque.Core.Model;
using Mediatheque.Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Mediatheque.Core;

namespace Mediatheque.CoreTests.ServiceTests.MediathequeServiceTests
{
    [TestClass()]
    public class PresentationCDShould
    {
        [TestMethod()]
        public void ReturnEmptyList_WhenNoCD()
        {
            //Arrange
            MediathequeService mediathequeService = new MediathequeService(null);

            //Act
            List<string> actual = mediathequeService.PresentationCD();

            //Assert
            List<string> expected = new List<string> { "Pas de CD" };
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod()]
        public void ReturnCDList_When2CDs()
        {
            //Arrange
            var mockNotationService = new Mock<INotationService>();
            mockNotationService.Setup(x => x.GetNoteAlbum("Spice world")).Returns(1);
            mockNotationService.Setup(x => x.GetNoteAlbum("Smash")).Returns(5);
            
            MediathequeService mediathequeService = new MediathequeService(null);

            CD cd1 = new CD("Spice world", "Spice");
            CD cd2 = new CD("Smash", "Offspring");

            cd1.Note = mockNotationService.Object.GetNoteAlbum(cd1.TitreDeLObjet);
            cd2.Note = mockNotationService.Object.GetNoteAlbum(cd2.TitreDeLObjet);

            mediathequeService.AddObjet(cd1);
            mediathequeService.AddObjet(cd2);

            //Act
            List<string> actual = mediathequeService.PresentationCD();

            //Assert
            List<string> expected = new List<string> { "Spice world par Spice, noté 1", "Smash par Offspring, noté 5" };
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}