using System;
using System.Collections.Generic;
using System.Linq;

/*Airline booking system
 
      Works out how many families of 3 can sit in an aircraft. All members of the family need to sit together and can not straddle Aisles. 
      Number of rows in the aircraft in configurable.

    Seats in each row are labled as follows

    ABC     DEFG    HJK


    Examp le (1 is a reserved seat)

        ABC         DEFG        HJK
        001         0001        000

    In the above example only 1 family of 3 could fit in HJK




    ABC     DEFG    HJK
    001     0000    000
    110     0001    000

    In the above example 3 families in total could fit on the aircraft. 2 in row 1 and 1 in row 2. 
    
    Please see the test project for test cases and also visualization of the airplane seating arrangements 
    
 */

namespace AirLineBooking
{
    public partial class AirLineBookingSystem
    {
        private readonly Dictionary<string, int> _seatMap = new Dictionary<string, int>() { { "A", 0 }, { "B", 1 }, { "C", 2 }, { "D", 3 }, { "E", 4 }, { "F", 5 }, { "G", 6 }, { "H", 7 }, { "J", 8 }, { "K", 9 } };

        public int[,] SeatConfiguration;

        public AirLineBookingSystem(int numberOfAirPlaneRows, string reservations)
        {
            SeatConfiguration = SetupAirPlaneSeatConfiguration(numberOfAirPlaneRows, reservations);
        }

        private int[,] SetupAirPlaneSeatConfiguration(int rows, string reservations)
        {
            SeatConfiguration = new int[rows, 10];

            if (string.IsNullOrEmpty(reservations))
            {
                return SeatConfiguration;
            }

            var allReservations = reservations.Split(' ');

            foreach (var reservedSeat in allReservations)
            {
                var seatRow = int.Parse(reservedSeat.Substring(0, reservedSeat.Length - 1)) - 1;
                var seatLetter = _seatMap[reservedSeat.Substring(reservedSeat.Length - 1).ToUpper()];
                SeatConfiguration[seatRow, seatLetter] = Seat.Reserved;
            }
            return SeatConfiguration;
        }

        public int CalculateNumberOfFamilies()
        {
            return CalculateTotalNumberOfFamilies(SeatConfiguration);
        }

        private int CalculateTotalNumberOfFamilies(int[,] seatConfiguration)
        {
            var rows = seatConfiguration.GetLength(0);
            var totalNumberOfFamilies = 0;

            for (var row = 0; row < rows; row++)
            {

                var isLeftAisleFree = CheckLeftAisle(row);

                var isMiddleAisleFree = CheckMiddleAisle(row);

                var isRightAisleFree = CheckRightAisle(row);

                totalNumberOfFamilies += Convert.ToInt16(isLeftAisleFree) + Convert.ToInt16(isMiddleAisleFree) + Convert.ToInt16(isRightAisleFree);
            }
            return totalNumberOfFamilies;
        }

        private bool CheckLeftAisle(int row)
        {
            var rules = new List<Func<Dictionary<int, bool>>>();

            return IsAisleFree(row, new Dictionary<int, int>() { { Seat.A, Seat.NotReserved }, { Seat.B, Seat.NotReserved }, { Seat.C, Seat.NotReserved } });
        }
        private bool CheckMiddleAisle(int row)
        {
            var q=new List<Func<Dictionary<int, int>,bool>>();

            

            return (IsAisleFree(row, new Dictionary<int, int>() { { Seat.D, Seat.NotReserved }, { Seat.G, Seat.NotReserved } })
                    || IsAisleFree(row, new Dictionary<int, int>() { { Seat.D, Seat.Reserved }, { Seat.G, Seat.NotReserved } })
                    || IsAisleFree(row, new Dictionary<int, int>() { { Seat.D, Seat.NotReserved }, { Seat.G, Seat.Reserved } }))
                   && IsAisleFree(row, new Dictionary<int, int>() { { Seat.E, Seat.NotReserved }, { Seat.F, Seat.NotReserved } });
        }

        private bool CheckRightAisle(int row)
        {
            return IsAisleFree(row, new Dictionary<int, int>() { { Seat.H, Seat.NotReserved }, { Seat.J, Seat.NotReserved }, { Seat.K, Seat.NotReserved } });
        }


        private bool IsAisleFree(int row, Dictionary<int, int> rule)
        {
            return rule.Select(key => SeatConfiguration[row, key.Key] == key.Value).All(seatValue => seatValue);
        }

    }
}

