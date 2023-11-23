using FluentAssertions;
using System.Drawing.Printing;
using willardcrm.DataModel;
using willardcrm.Services;
using Xunit.Abstractions;

namespace Tests
{

    public class TestFiles
    {
        private readonly ITestOutputHelper output;

        public TestFiles(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test_ConvertContactToJSON()
        {
            //arrange
            ContactItem testContact = new ContactItem();
            testContact.Name = "Bill Grogs";
            testContact.Relationship = "Friend";
            testContact.Interests = "roleplaying games, history";
            testContact.Email = "bill@billgrognard.com";
            testContact.Phone = "555.782.9843";
            testContact.Notes = "Bill's website is billgrognard.com. Interesting articles about programming, roleplaying games, and why he hates traffic.";

            ContactHandler contactHandler = new ContactHandler();

            //act
            contactHandler.saveContact(testContact);
            string output = contactHandler.GetContactJSON("Bill Grogs");

            //assert
            output.Should().Be("{\"_name\":\"Bill Grogs\",\"_relationship\":\"Friend\",\"_interests\":\"roleplaying games, history\",\"_email\":\"bill@billgrognard.com\",\"_phone\":\"555.782.9843\",\"_notes\":\"Bill's website is billgrognard.com. Interesting articles about programming, roleplaying games, and why he hates traffic.\"}");

        }

        [Fact]
        public void Test_ContactPath()
        {
            //string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string baseDirectory = Directory.GetCurrentDirectory();
            output.WriteLine("baseDirectory: " + baseDirectory);
            string contactPath = Path.Combine(baseDirectory, "Contacts");
            output.WriteLine("contactPath: " + contactPath);
        }
    }
}