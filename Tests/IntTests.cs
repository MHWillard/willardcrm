﻿using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using willardcrm.DataModel;
using willardcrm.Services;
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
            List<string> contactProps = new List<string>() {"Bill Grogs", "Friend", "roleplaying games, history", "bill@billgrognard.com", "555.782.9843", "Bill's website is billgrognard.com. Interesting articles about programming, roleplaying games, and why he hates traffic."};

            //act
            //add contact function: event fires from button click and gets info in fields gathered from form
            //installs fields accordingly

            //clicks Add New Contact
            //sees the form come up: new window, with fields for Name, Relationship, Interests, Email, Phone, and Notes to get started
            //they fill out the form about their RPG gaming friend: Bill Grogs, who is a Friend, whose Interests include roleplaying games and history, whose email is bill@billgrognard.com, whose phone number is 555.782.9843. A starting note includes Bill's website, billgrognard.com, and how cool it is
            //they click Save and the contact gets saved. It's saved in the local directory so he can go in there and edit the text file if he wants to.
            //the Add Contact window closes and now he's back on the main screen. Bill's contact shows up in the lefthand pane. 
            //to verify, he clicks on Bill's name. It's highlighted, and the right pane changes to display the loaded contact information in a neat column.

            ContactItem testContact = contactBuilder.BuildContact(contactProps);
            //"Bill Grogs";"Friend";"roleplaying games, history""bill@billgrognard.com";"555.782.9843";"Bill's website is billgrognard.com. Interesting articles about programming, roleplaying games, and why he hates traffic.";


            contactHandler.saveContact(testContact);

            string testJSON = contactHandler.GetContactJSON("Bill Grogs");


            //assert
            testJSON.Should().Be("{\"_name\":\"Bill Grogs\",\"_relationship\":\"Friend\",\"_interests\":\"roleplaying games, history\",\"_email\":\"bill@billgrognard.com\",\"_phone\":\"555.782.9843\",\"_notes\":\"Bill's website is billgrognard.com. Interesting articles about programming, roleplaying games, and why he hates traffic.\"}");

        }
    }
}
