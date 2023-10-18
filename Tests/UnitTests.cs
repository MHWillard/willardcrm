using FluentAssertions;
using willardcrm.DataModel;
using willardcrm.Services;

namespace Tests
{
    public class TestFiles
    {
        [Fact]
        public void Test_ConvertContactToJSON()
        {
            //arrange
            ContactItem testContact = new ContactItem();
            testContact._name = "Bill Grogs";
            testContact._relationship = "Friend";
            testContact._interests = "roleplaying games, history";
            testContact._email = "bill@billgrognard.com";
            testContact._phone = "555.782.9843";
            testContact._notes = "Bill's website is billgrognard.com. Interesting articles about programming, roleplaying games, and why he hates traffic.";

            ContactHandler contactHandler = new ContactHandler();

            //act
            contactHandler.saveContact(testContact);
            string output = contactHandler.GetContactJSON("Bill Grogs");

            //assert
            output.Should().Be("{\"_name\":\"Bill Grogs\",\"_relationship\":\"Friend\",\"_interests\":\"roleplaying games, history\",\"_email\":\"bill@billgrognard.com\",\"_phone\":\"555.782.9843\",\"_notes\":\"Bill's website is billgrognard.com. Interesting articles about programming, roleplaying games, and why he hates traffic.\"}");

        }
    }
}