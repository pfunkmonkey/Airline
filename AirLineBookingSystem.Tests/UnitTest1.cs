using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AirLineBooking.AirLineBookingSystem;

namespace AirLineBookingSystem.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SetupSeatConfiguration_When1RowAndNoSeatsReserved_ConfirmAllSeatsAreUnreserved()
        {
            var bookingSystem = new AirLineBooking.AirLineBookingSystem(1, string.Empty);
            Assert.AreEqual(Seat.NotReserved, bookingSystem.SeatConfiguration[0, Seat.A]);
            Assert.AreEqual(Seat.NotReserved, bookingSystem.SeatConfiguration[0, Seat.B]);
            Assert.AreEqual(Seat.NotReserved, bookingSystem.SeatConfiguration[0, Seat.C]);
            Assert.AreEqual(Seat.NotReserved, bookingSystem.SeatConfiguration[0, Seat.D]);
            Assert.AreEqual(Seat.NotReserved, bookingSystem.SeatConfiguration[0, Seat.E]);
            Assert.AreEqual(Seat.NotReserved, bookingSystem.SeatConfiguration[0, Seat.F]);
            Assert.AreEqual(Seat.NotReserved, bookingSystem.SeatConfiguration[0, Seat.G]);
            Assert.AreEqual(Seat.NotReserved, bookingSystem.SeatConfiguration[0, Seat.H]);
            Assert.AreEqual(Seat.NotReserved, bookingSystem.SeatConfiguration[0, Seat.J]);
            Assert.AreEqual(Seat.NotReserved, bookingSystem.SeatConfiguration[0, Seat.K]);
        }

        [TestMethod]
        public void SetupSeatConfiguration_When1RowAndSeatsReserved_ConfirmArrayIsSetupCorrectly()
        {
            var bookingSystem = new AirLineBooking.AirLineBookingSystem(1, "1A 1F 1H");
            Assert.AreEqual(Seat.Reserved, bookingSystem.SeatConfiguration[0,  Seat.A]);
            Assert.AreEqual(Seat.NotReserved, bookingSystem.SeatConfiguration[0,  Seat.B]);
            Assert.AreEqual(Seat.NotReserved, bookingSystem.SeatConfiguration[0,  Seat.C]);
            Assert.AreEqual(Seat.NotReserved, bookingSystem.SeatConfiguration[0,  Seat.D]);
            Assert.AreEqual(Seat.NotReserved, bookingSystem.SeatConfiguration[0,  Seat.E]);
            Assert.AreEqual(Seat.Reserved, bookingSystem.SeatConfiguration[0,  Seat.F]);
            Assert.AreEqual(Seat.NotReserved, bookingSystem.SeatConfiguration[0,  Seat.G]);
            Assert.AreEqual(Seat.Reserved, bookingSystem.SeatConfiguration[0,  Seat.H]);
            Assert.AreEqual(Seat.NotReserved, bookingSystem.SeatConfiguration[0,  Seat.J]);
            Assert.AreEqual(Seat.NotReserved, bookingSystem.SeatConfiguration[0, Seat.K]);
        }

        [TestMethod]
        public void CalculateNumberOfFamilies_ForGivenSeatingConfig_Returns4Families()
        {
            var bookingSystem = new AirLineBooking.AirLineBookingSystem(2, "1A 2F 1C");
            var numberOfFamilies = bookingSystem.CalculateNumberOfFamilies();
            Assert.AreEqual(4, numberOfFamilies);
        }

        [TestMethod]
        public void CalculateNumberOfFamilies_ForGivenSeatingConfig_Returns12()
        {
            var bookingSystem = new AirLineBooking.AirLineBookingSystem(8, "1A 1D 1E 2C 2G 2H 2J 3D 4A 4J 5D 6E 6F 6J 7F 7J 8A 8B 8C 8D 8J");

            var numberOfFamilies = bookingSystem.CalculateNumberOfFamilies();
            Assert.AreEqual(12, numberOfFamilies);
        }

        [TestMethod]
        public void CalculateNumberOfFamilies_ForGivenSeatingConfig_Returns150Families()
        {
            var bookingSystem = new AirLineBooking.AirLineBookingSystem(50, "50g");
            var numberOfFamilies = bookingSystem.CalculateNumberOfFamilies();
            Assert.AreEqual(150, numberOfFamilies);
        }

        [TestMethod]
        public void CalculateNumberOfFamilies_ForGivenSeatingConfig_Returns215()
        {
            var bookingSystem = new AirLineBooking.AirLineBookingSystem(40, "1A 3C 2B 40G 5A");
            var numberOfFamilies = bookingSystem.CalculateNumberOfFamilies();
            Assert.AreEqual(116, numberOfFamilies);
        }
    }
}
