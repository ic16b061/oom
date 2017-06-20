using System;
using NUnit.Framework;

namespace Task6
{
    [TestFixture]
    public class HeadphoneTests
    {
        [Test]
        public void CanSetHeadphoneReturned()
        {
            var x = new Headphone("Grado", "RS2e", "Grado RS2e", "0182092000905", 549.00m);
            x.SetReturned();

            Assert.IsTrue(x.Price == (549.00m * 0.9m));
        }

        [Test]
        public void CannotSetHeadphoneReturnedTwice()
        {
            var x = new Headphone("Grado", "RS2e", "Grado RS2e", "0182092000905", 549.00m);
            Assert.IsTrue(x.IsReturned == false);
            x.SetReturned();
            Assert.IsTrue(x.IsReturned == true);
            
            try
            {
                x.SetReturned();
                Assert.Fail();
            }
            catch
            {
            }
        }
    }
}
