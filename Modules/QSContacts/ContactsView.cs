﻿using System;
using System.Collections.Generic;
using System.Data.Bindings.Collections.Generic;
using NHibernate;
using QSOrmProject;
using QSTDI;

namespace QSContacts
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ContactsView : Gtk.Bin
	{
		private IContactOwn contactOwn;
		private GenericObservableList<Contact> contactsList;
		private ISession session;

		public ISession Session
		{
			get
			{
				return session;
			}
			set
			{
				session = value;
			}
		}

		public IContactOwn Contact
		{
			get
			{
				return contactOwn;
			}
			set
			{
				contactOwn = value;
				if(Contact.Contacts == null)
					Contact.Contacts = new List<Contact>();
				contactsList = new GenericObservableList<Contact>(Contact.Contacts);
				datatreeviewContacts.ItemsDataSource = contactsList;
			}
		}

		public ContactsView()
		{
			this.Build();
			OrmMain.ClassMapingList.Find(m => m.ObjectClass == typeof(Contact)).ObjectUpdated += OnContactUpdated;
			datatreeviewContacts.Selection.Changed += OnSelectionChanged;
		}

		void OnSelectionChanged (object sender, EventArgs e)
		{
			bool selected = datatreeviewContacts.Selection.CountSelectedRows() > 0;
			buttonEdit.Sensitive = buttonDelete.Sensitive = selected;
		}

		void OnContactUpdated (object sender, OrmObjectUpdatedEventArgs e)
		{
			if (Session == null || !Session.IsOpen)
				return;
			bool flag = false;
			for (int i = 0; i < contactsList.Count; i++) {
				try {
					Session.Refresh (contactsList[i]);
				}
				catch (NHibernate.UnresolvableObjectException) {
					contactsList.Remove (contactsList [i]);
					i--;
				}
				if ((e.Subject as Contact).Id == contactsList[i].Id)
					flag = true;
			}
			if (!flag) {
				Session.Load<Contact> ((e.Subject as Contact).Id);
				contactsList.Add(Session.Get<Contact>((e.Subject as Contact).Id));
			}
		}

		protected void OnButtonAddClicked(object sender, EventArgs e)
		{
			ITdiTab mytab = TdiHelper.FindMyTab(this);
			if (mytab == null)
				return;

			ContactDlg dlg = new ContactDlg(Session);
			contactsList.Add((Contact)dlg.Subject);
			mytab.TabParent.AddSlaveTab(mytab, dlg);
		}

		protected void OnButtonEditClicked(object sender, EventArgs e)
		{
			ITdiTab mytab = TdiHelper.FindMyTab(this);
			if (mytab == null)
				return;

		    ContactDlg dlg = new ContactDlg(Session, datatreeviewContacts.GetSelectedObjects()[0] as Contact);
			mytab.TabParent.AddSlaveTab(mytab, dlg);
		}

		protected void OnDatatreeviewAccountsRowActivated(object o, Gtk.RowActivatedArgs args)
		{
			buttonEdit.Click();
		}

		protected void OnButtonDeleteClicked (object sender, EventArgs e)
		{
			ITdiTab mytab = TdiHelper.FindMyTab(this);
			if (mytab == null)
				return;

			contactsList.Remove (datatreeviewContacts.GetSelectedObjects () [0] as Contact);
		}
	}
}
