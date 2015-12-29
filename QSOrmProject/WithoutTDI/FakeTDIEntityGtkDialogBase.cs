﻿using System;
using QSTDI;
using System.Linq;
using QSProjectsLib;
using System.ComponentModel;

namespace QSOrmProject
{
	public abstract class FakeTDIEntityGtkDialogBase<TEntity> : FakeTDITabGtkDialogBase, ITdiDialog, IOrmDialog
		where TEntity : IDomainObject, new()
	{
		public IUnitOfWork UoW {
			get
			{
				return UoWGeneric;
			}
		}

		private IUnitOfWorkGeneric<TEntity> uowGeneric;

		public IUnitOfWorkGeneric<TEntity> UoWGeneric {
			get
			{
				return uowGeneric;
			}
			protected set
			{
				uowGeneric = value;
				Title = TabName;
				OnTabNameChanged();
			}
		}


		//FIXME Временно для совместимости
		[Obsolete("Используйте UnitOfWork, это свойство будет удалено.")]
		public NHibernate.ISession Session
		{
			get
			{
				return UoW.Session;
			}
		}

		public virtual bool HasChanges { 
			get { return UoWGeneric.HasChanges; }
		}

		public object EntityObject {
			get { return UoWGeneric.Root; }
		}

		public TEntity Entity {
			get { return UoWGeneric.Root; }
		}

		public override string TabName {
			get {
				if(!String.IsNullOrWhiteSpace(base.TabName))
					return TabName;
				if (UoW != null && UoW.RootObject != null)
				{
					var att = typeof(TEntity).GetCustomAttributes (typeof(OrmSubjectAttribute), true);
					OrmSubjectAttribute subAtt = (att.FirstOrDefault () as OrmSubjectAttribute);

					if(UoW.IsNew)
					{
						if (subAtt != null && !String.IsNullOrWhiteSpace(subAtt.ObjectName))
						{
							switch(subAtt.AllNames.Gender){
							case GrammaticalGender.Masculine: 
								return "Новый " + subAtt.ObjectName;
							case GrammaticalGender.Feminine :
								return "Новая " + subAtt.ObjectName;
							case GrammaticalGender.Neuter :
								return "Новое " + subAtt.ObjectName;
							default:
								return "Новый(ая) " + subAtt.ObjectName;
							}
						}
					}
					else
					{
						var notifySubject = UoW.RootObject as INotifyPropertyChanged;

						var prop = UoW.RootObject.GetType ().GetProperty ("Title");
						if (prop != null) {
							if(notifySubject != null)
							{
								notifySubject.PropertyChanged -= Subject_TitlePropertyChanged;
								notifySubject.PropertyChanged += Subject_TitlePropertyChanged;
							}
							return prop.GetValue (UoW.RootObject, null).ToString();
						}

						prop = UoW.RootObject.GetType ().GetProperty ("Name");
						if (prop != null) {
							if (notifySubject != null) {
								notifySubject.PropertyChanged -= Subject_NamePropertyChanged;
								notifySubject.PropertyChanged += Subject_NamePropertyChanged;
							}
							return prop.GetValue (UoW.RootObject, null).ToString();
						}

						if(subAtt != null && !String.IsNullOrWhiteSpace(subAtt.ObjectName))
							return StringWorks.StringToTitleCase (subAtt.ObjectName);
					}
					return UoW.RootObject.ToString ();
				}
				return String.Empty;
			}
			set {
				if (base.TabName == value)
					return;
				base.TabName = value;
			}

		}

		void Subject_NamePropertyChanged (object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Name")
			{
				Title = TabName;
				OnTabNameChanged ();
			}
		}

		void Subject_TitlePropertyChanged (object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Title")
			{
				Title = TabName;
				OnTabNameChanged ();
			}
		}

		public abstract bool Save ();

		protected void OnButtonSaveClicked (object sender, EventArgs e)
		{
			if (!this.HasChanges || Save ())
			{
				OnEntitySaved (true);
				OnCloseTab (false);
			}
		}

		protected void OnButtonCancelClicked (object sender, EventArgs e)
		{
			OnCloseTab (false);
		}

		protected void OnEntitySaved (bool tabClosed = false)
		{
			OnEntitySaved (Entity, tabClosed);
		}

		public override void Destroy ()
		{
			UoWGeneric.Dispose();
			base.Destroy ();
		}

		public FakeTDIEntityGtkDialogBase ()
		{
		}
	}
}
