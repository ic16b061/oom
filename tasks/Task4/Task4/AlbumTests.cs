using System;
using NUnit.Framework;

namespace Task4
{
    [TestFixture]
    public class AlbumTests
    {
        [Test]
        public void CanCreateAlbum()
        {
            var x = new Album("El Cielo", "Dredg", "Dredg - El Cielo", "0606949343828", 14.99m);

            Assert.IsTrue(x.Artist == "Dredg");
            Assert.IsTrue(x.Name == "El Cielo");
            Assert.IsTrue(x.Description == "Dredg - El Cielo");
            Assert.IsTrue(x.EAN == "0606949343828");
            Assert.IsTrue(x.Price == 14.99m);
        }

        [Test]
        public void CannotCreateAlbumWithoutAlbumName()
        {
            Assert.Catch(() =>
            {
                var x = new Album("", "Dredg", "Dredg - El Cielo", "0606949343828", 14.99m);
            });
        }

        [Test]
        public void CannotCreateAlbumWithoutArtistName()
        {
            Assert.Catch(() =>
            {
                var x = new Album("El Cielo", "", "Dredg - El Cielo", "0606949343828", 14.99m);
            });
        }

        [Test]
        public void CannotCreateAlbumWithoutDescription()
        {
            Assert.Catch(() =>
            {
                var x = new Album("El Cielo", "Dredg", "", "0606949343828", 14.99m);
            });
        }

        [Test]
        public void CannotCreateAlbumWithoutEAN()
        {
            Assert.Catch(() =>
            {
                var x = new Album("El Cielo", "Dredg", "Dredg - El Cielo", "", 14.99m);
            });
        }

        [Test]
        public void CannotCreateAlbumWithNegativePrice()
        {
            Assert.Catch(() =>
            {
                var x = new Album("El Cielo", "", "Dredg - El Cielo", "0606949343828", -14.99m);
            });
        }

        [Test]
        public void CanUpdateAlbumPrice()
        {
            Assert.Catch(() =>
            {
                var x = new Album("El Cielo", "", "Dredg - El Cielo", "0606949343828", 14.99m);
                x.UpdatePrice(17.99m);

                Assert.IsTrue(x.Price == 17.99m);
            });
        }
    }
}
