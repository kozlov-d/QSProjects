﻿using System;
using System.Collections.Generic;
using QSOrmProject;
using System.Data.Bindings.Collections.Generic;
using NHibernate;

namespace QSBanks
{
	public abstract class AccountOwnerBase : PropertyChangedBase, IAccountOwner
	{
		IList<Account> accounts;

		public virtual IList<Account> Accounts {
			get { return accounts; }
			set {
				if(SetField (ref accounts, value, () => Accounts))
				{
					UpdateDefault ();
					observableAccounts = null;
				}
			}
		}

		GenericObservableList<Account> observableAccounts;
		//FIXME Кослыль пока не разберемся как научить hibernate работать с обновляемыми списками.
		public GenericObservableList<Account> ObservableAccounts {
			get {
				if (observableAccounts == null)
					observableAccounts = new GenericObservableList<Account> (Accounts);
				return observableAccounts;
			}
		}

		Account defaultAccount;

		public virtual Account DefaultAccount {
			get { return defaultAccount; }
			set {
				defaultAccount = value;
				UpdateDefault ();
			}
		}

		public AccountOwnerBase ()
		{
			accounts = new List<Account> ();
		}

		private void UpdateDefault ()
		{
			if (Accounts == null || !NHibernateUtil.IsInitialized(Accounts))
				return;
			foreach (Account acc in Accounts) {
				acc.IsDefault = (acc == DefaultAccount);
			}
		}

		public void AddAccount(Account account)
		{
			ObservableAccounts.Add (account);
		}
	}

	public interface IAccountOwner
	{
		Account DefaultAccount { get; set; }

		IList<Account> Accounts { get;}

		GenericObservableList<Account> ObservableAccounts { get;}
	}
}

