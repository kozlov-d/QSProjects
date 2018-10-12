﻿using System;
using System.ComponentModel.DataAnnotations;
using QS.DomainModel.Entity;
using QSOrmProject;

namespace QSContacts
{
	[OrmSubject (Gender = GrammaticalGender.Feminine,
		NominativePlural = "должности",
		Nominative = "должность")]
	public class Post : PropertyChangedBase, IDomainObject
	{
		#region Свойства
		public virtual int Id { get; set; }

		private string name;

		[Display (Name = "Название")]
		public virtual string Name {
		    get { return name; }
		    set { SetField (ref name, value, () => Name); }
		}

		#endregion
		public Post()
		{
			Name = String.Empty;
		}
	}
}

