# WillardCRM

willardCRM is a small desktop personal contact manager using Avalonia UI. I'm piggybacking off of [Avalonia's tutorial for a to-do list application](https://docs.avaloniaui.net/docs/next/tutorials/todo-list-app/) to jumpstart it for use as a CRM. This is the final version for now - it can be built and distributed as normal, but more features could be added.

## Features
* Contacts stored on disk as JSON files.
* Can add contacts via form.
* Can select contact and delete with Delete button.
* Select a contact on the left pane to see the details on the right pane.

Features that would be nice to add over time:
* Ability to edit contacts.
* Ability to add regular successive notes to each contact.
* Built-in reminder system to touch base with a contact.
* Better UI organization.

## Installation

Clone the repo, then build the project. I built this in Visual Studio with the CRMRelease configuration. Then, just run the willardcrm.exe file.

## Usage

Click Add to add a contact. Fill out the form, then click OK. The contact will show up in the left-hand column. Clicking a name will present the contact details in the right-hand column. While a contact is highlighted, click the Delete button to delete the contact. Contacts are all saved on the hard drive in the app's Contacts folder.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)