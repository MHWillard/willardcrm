using FluentAssertions;
using willardcrm.DataModel;

namespace Tests
{
    public class TestFiles
    {
        [Fact]
        public void Test_ConvertContactToJSON()
        {
            //arrange
            JSONContact testContact = new JSONContact();

            //act
            var testJSON = testContact.GetJSON();

            //assert
            testJSON.Should().Be("{\"name\": \"Joe Schmo\",\"relationship\": \"friend\",\"interests\": \"football, hockey\",\"updates:\" [{\"id\": 1,\"date\": \"10-09-2023\",\"comment\": \"met Joe\"},{\"id\": 2,\"date\": \"10-10-2023\",\"comment\": \"helped Joe move\"},]}");

        }
    }
}