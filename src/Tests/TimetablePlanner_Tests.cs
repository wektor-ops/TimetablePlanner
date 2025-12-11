using TimetablePlanner;

namespace Tests
{
    [TestClass]
    public sealed class TimetablePlanner_Tests
    {
        [TestMethod]
        public void Constructor_RoomPlan_IsInitializedWithCorrectDimensions()
        {
            // Arrange
            int expectedDays = Timetable.Days;
            int expectedHours = Timetable.Hours;

            // Act
            Room room = new Room("Test");

            // Assert
            Assert.IsNotNull(room.RoomPlan, "RoomPlan should be initialised");
            Assert.AreEqual(expectedDays, room.RoomPlan.GetLength(0), "first dimension Day is wrong.");
            Assert.AreEqual(expectedHours, room.RoomPlan.GetLength(1), "second dimension hour ist wrong");
        }
        [TestMethod]
        public void Constructor_LongAbbreviation_LengthIsExactlyFour()
        {
            // Arrange
            string inputAbbreviation = "Roomtolong"; 
            int expectedLength = 4;

            // Act
            Room room = new Room(inputAbbreviation);


            Assert.AreEqual(expectedLength, room.Abbreviation.Length,
                "the abbrevation schould be four.");
        }
    }
}
