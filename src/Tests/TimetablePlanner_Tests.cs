using TimetablePlanner;

namespace Tests
{
    [TestClass]
    public sealed class TimetablePlanner_Tests
    {
        [TestMethod]
        public void RoomPlan_IsInitializedWithCorrectDimensions()
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
        public void LongAbbreviation_LengthIsExactlyFour()
        {
            // Arrange
            string inputAbbreviation = "Roomtolong";
            int expectedLength = 4;

            // Act
            Room room = new Room(inputAbbreviation);


            Assert.AreEqual(expectedLength, room.Abbreviation.Length,
                "the abbrevation should be four.");
        }
        [TestMethod]
        public void TeacherAbreviationisFourlong()
        {
            //Arrage
            string inputfirstname = "Bob";
            string inputlastname = "Berhard";
            bool[,] inputAvailability = new bool[0,9];
            int expected = 3;

            //Act
            Teacher teacher = new Teacher(inputfirstname,inputlastname, inputAvailability);

            //Assert
            Assert.AreEqual(expected, teacher.Abbreviation.Length, "The Abbreviation should be four");
        }
        [TestMethod]
        public void AddStudenttoclass()
        {
            //Arrage
            string inputfirstname = "Freddy";
            string inputlastname = "Mercury";
            Student student = new Student(inputfirstname,inputlastname);
            Schoolclass expectedclass = Schoolclass.AllClasses.First();
            int expected = expectedclass.Students.Count + 1;

            //Act
            expectedclass.Students.Add(student);
            //Assert
            Assert.AreEqual(expected, expectedclass.Students.Count, "There was no student added");
        }
        [TestMethod]
        public void AbbreviationwithdateforSchoolclass()
        {
            //Arrage
            int acctualyear = DateTime.Now.Year % 100;
            string expectedabbreviation = "A" + acctualyear + "A";
            Schoolclass schoolclass = new Schoolclass();

            //Act
            string ActualAbb = Schoolclass.GenerateNewAbbreviation();

            //Assert
            Assert.AreEqual(expectedabbreviation, ActualAbb, "Wrong Abbreviation");
        }
    }
}
