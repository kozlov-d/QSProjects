using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QSOrmProject;


namespace QSHistoryLog
{

	public class HistoryObjectDesc
	{
		public string ObjectName { get; set;}
		public Type ObjectType { get; set;}
		public string DisplayName { get; set;}

		public IEnumerable<HistoryFieldDesc> NamedProperties{
			get {
				foreach(var prop in ObjectType.GetProperties ())
				{
					var att = prop.GetCustomAttributes (typeof(DisplayAttribute), false);
					if(att.Length > 0)
					{
						yield return new HistoryFieldDesc {
							FieldName = prop.Name,
							DisplayName = (att [0] as DisplayAttribute).GetName ()
						};
					}
				}
				yield break;
			}
		}

		public HistoryObjectDesc(Type type)
		{
			ObjectType = type;
			ObjectName = type.Name;

			var att = type.GetCustomAttributes (typeof(OrmSubjectAttribute), true);
			if (att.Length > 0 && !String.IsNullOrWhiteSpace((att [0] as OrmSubjectAttribute).Name))
				DisplayName = (att [0] as OrmSubjectAttribute).Name;
			else
				DisplayName = ObjectName;
		}
			
	}

	public class HistoryFieldDesc
	{
		public string FieldName { get; set;}
		public string DisplayName { get; set;}
	}
}
