
// This file has been generated by the GUI designer. Do not modify.
namespace QSCustomFields
{
	public partial class CustomFields
	{
		private global::Gtk.Table tableGrid;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget QSCustomFields.CustomFields
			global::Stetic.BinContainer.Attach (this);
			this.Name = "QSCustomFields.CustomFields";
			// Container child QSCustomFields.CustomFields.Gtk.Container+ContainerChild
			this.tableGrid = new global::Gtk.Table (((uint)(2)), ((uint)(2)), false);
			this.tableGrid.Name = "tableGrid";
			this.tableGrid.RowSpacing = ((uint)(6));
			this.tableGrid.ColumnSpacing = ((uint)(6));
			this.Add (this.tableGrid);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}
