using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            //Assert.IsTrue(result);
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_UserIsNotAdminAndSameUser_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation();
            var user = new User { IsAdmin = false };

            // Act
            reservation.MadeBy = user;
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_UserIsNotAdminAndNotSameUser_ReturnsFalse()
        {
            // Arrange
            var reservation = new Reservation() { MadeBy = new User()};

            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = false });

            // Assert
            Assert.IsFalse(result);
        }

    }
}
