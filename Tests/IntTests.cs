using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using willardcrm.DataModel;

namespace Tests
{
    public class IntTests
    {
        public void Test_CreateAndSaveNewContact() { 
        //arrange
        //act
        //assert

            //clicks Add New Contact
            //sees the form come up: new window, with fields for Name, Relationship, Interests, Email, Phone, and Notes to get started
            //they fill out the form about their RPG gaming friend: Bill Grogs, who is a Friend, whose Interests include roleplaying games and history, whose email is bill@billgrognard.com, whose phone number is 555.782.9843. A starting note includes Bill's website, billgrognard.com, and how cool it is
            //they click Save and the contact gets saved. It's saved in the local directory so he can go in there and edit the text file if he wants to.
            //the Add Contact window closes and now he's back on the main screen. Bill's contact shows up in the lefthand pane. 
            //to verify, he clicks on Bill's name. It's highlighted, and the right pane changes to display the loaded contact information in a neat column.

            ContactItem testContact = new ContactItem();
            testContact.setName("Bill Grogs");
            testContact.setRelationship("Friend");
            testContact.setInterests("roleplaying games, history");
            testContact.setEmail("bill@billgrognard.com");
            testContact.setNumber("555.782.9843");
            testContact.setNotes("Bill's website is billgrognard.com. Interesting articles about programming, roleplaying games, and why he hates traffic.");

            testContact.saveContact();

            string testJSON = ContactDirectory.getContactJSON("Bill Grogs");

            testJSON.Should().Be("{\"name\": \"Bill Grogs\",\"relationship\": \"Friend\",\"interests\": \"roleplaying games, history\",\"email:\"bill@billgrognard.com\",\"number\":\"555.782.9843\",\"notes\":\"Bill's website is billgrognard.com. Interesting articles about programming, roleplaying games, and why he hates traffic.\",\"updates:\" []}");

        }
    }
}
