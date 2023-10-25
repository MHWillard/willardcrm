using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using willardcrm.DataModel;
using willardcrm.Services;
using willardcrm.ViewModels;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class IntTests
    {
        private readonly ITestOutputHelper output;

        public IntTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test_CreateAndSaveNewContact() {

            //arrange
            //prep items, empty Contacts folder
            ContactHandler contactHandler = new ContactHandler();
            ContactBuilder contactBuilder = new ContactBuilder();
            //=> add clearing the contacts folder

            //act
            //clicks Add New Contact
            //sees the form come up: new window, with fields for Name, Relationship, Interests, Email, Phone, and Notes to get started
            //they fill out the form about their RPG gaming friend: Bill Grogs, who is a Friend, whose Interests include roleplaying games and history, whose email is bill@billgrognard.com, whose phone number is 555.782.9843. A starting note includes Bill's website, billgrognard.com, and how cool it is
            Dictionary<string, string> contactProps = new Dictionary<string, string>() {
                {"name", "Bill Grogs"},{"relationship", "Friend"},{"interests", "roleplaying games, history"},{"email", "bill@billgrognard.com"},{"phone", "555.782.9843"},{"notes", "Bill's website is billgrognard.com. Interesting articles about programming, roleplaying games, and why he hates traffic."}
            };

            //they click Save and the contact gets saved. It's saved in the local directory so he can go in there and edit the text file if he wants to.
            ContactItem testContact = contactBuilder.BuildContact(contactProps);
            contactHandler.saveContact(testContact);

            //the Add Contact window closes and now he's back on the main screen. Bill's contact shows up in the lefthand pane. 
            //to verify, he clicks on Bill's name. It's highlighted, and the right pane changes to display the loaded contact information in a neat column.
            ContactItem billContact = contactHandler.GetContactItem("Bill Grogs");

            string testJSON = contactHandler.GetContactJSON("Bill Grogs");

            //assert
            testJSON.Should().Be("{\"_name\":\"Bill Grogs\",\"_relationship\":\"Friend\",\"_interests\":\"roleplaying games, history\",\"_email\":\"bill@billgrognard.com\",\"_phone\":\"555.782.9843\",\"_notes\":\"Bill's website is billgrognard.com. Interesting articles about programming, roleplaying games, and why he hates traffic.\"}");

            //assert contact item isn't null and it has expected properties
            billContact.Should().NotBeNull();
            billContact._name.Should().Be("Bill Grogs");
            billContact._interests.Should().Be("roleplaying games, history");
            billContact._notes.Should().Be("Bill's website is billgrognard.com. Interesting articles about programming, roleplaying games, and why he hates traffic.");

        }

        [Fact]
        public void Test_LoadContactListIntoLeftPane() {
            //given that I have a CRM application, whenever I first open the program or return to the main screen, then the left pane displays a list of all contacts in the Contacts folder by name

            //arrange
            ///clean out contacts folder
            ///create three dummy contacts in folder
            ContactHandler contactHandler = new ContactHandler();
            ContactBuilder contactBuilder = new ContactBuilder();
            
            string contactPath = contactHandler.GetContactPath();
            string[] files = Directory.GetFiles(contactPath);
            foreach (string file in files)
            {
                File.Delete(file);
            }

            ContactItem contactOne = contactBuilder.BuildContact(new Dictionary<string, string>() {
                {"name", "Bill Grogs"},{"relationship", "Friend"},{"interests", "roleplaying games, history"},{"email", "bill@billgrognard.com"},{"phone", "555.782.9843"},{"notes", "Bill's website is billgrognard.com. Interesting articles about programming, roleplaying games, and why he hates traffic."}
            });
            ContactItem contactTwo = contactBuilder.BuildContact(new Dictionary<string, string>() {
                {"name", "Frank Stone"},{"relationship", "Friend"},{"interests", "roleplaying games, history"},{"email", "frank@stonesthrow.com"},{"phone", "555.782.9843"},{"notes", "Confused him for Frank Stallone."}
            });
            ContactItem contactThree = contactBuilder.BuildContact(new Dictionary<string, string>() {
                {"name", "Bilbo Baggins"},{"relationship", "Friend"},{"interests", "roleplaying games, history"},{"email", "bilbobaggins@helloshire.com"},{"phone", "555.782.9843"},{"notes", "Gets a thousand yard stare whenever you mention any kind of ring - wedding, onion, Sonic, etc."}
            });

            ContactItem[] array = new ContactItem[3]; array[0] = contactOne; array[1] = contactTwo; array[2] = contactThree;
            foreach (ContactItem item in array)
            { 
                contactHandler.saveContact(item);
            }

            //act
            ///get list of contact items from local folder
            ///push to ContactListService
            ContactItem[] contactArray = contactHandler.GetAllContactItems();

            var service = new ContactListService();
            var model = new ContactListViewModel(service.GetItems());
            ObservableCollection<ContactItem> ListItems = model.ListItems;


            //assert
            /*
            -assert that list of items has names we expect in order we expect
            -assert that the view has generated the list in order as expected
            */

            ListItems.Should().HaveCount(3).And.OnlyHaveUniqueItems();
            ListItems.Should().ContainItemsAssignableTo<ContactItem>();
            ListItems.Should().SatisfyRespectively(
            first => {
                first._name.Should().Be("Bill Grogs");
                first._email.Should().Be("bill@billgrognard.com");
                first._notes.Should().Be("Bill's website is billgrognard.com. Interesting articles about programming, roleplaying games, and why he hates traffic.");
            },
            second => {
                second._name.Should().Be("Frank Stone");
                second._email.Should().Be("frank@stonesthrow.com");
                second._notes.Should().Be("Confused him for Frank Stallone.");
            },
            third => {
                third._name.Should().Be("Bilbo Baggins");
                third._email.Should().Be("bilbobaggins@helloshire.com");
                third._notes.Should().Be("Gets a thousand yard stare whenever you mention any kind of ring - wedding, onion, Sonic, etc.");
            });
            
        }
    }
}
