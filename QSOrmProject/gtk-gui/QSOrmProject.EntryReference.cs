
// This file has been generated by the GUI designer. Do not modify.
namespace QSOrmProject
{
	public partial class EntryReference
	{
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Entry entryObject;
		
		private global::Gtk.Button buttonEdit;
		
		private global::Gtk.Button buttonOpen;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget QSOrmProject.EntryReference
			global::Stetic.BinContainer.Attach (this);
			this.Name = "QSOrmProject.EntryReference";
			// Container child QSOrmProject.EntryReference.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.entryObject = new global::Gtk.Entry ();
			this.entryObject.CanFocus = true;
			this.entryObject.Name = "entryObject";
			this.entryObject.IsEditable = false;
			this.entryObject.InvisibleChar = '●';
			this.hbox1.Add (this.entryObject);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.entryObject]));
			w1.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonEdit = new global::Gtk.Button ();
			this.buttonEdit.TooltipMarkup = "Выбрать из справочника";
			this.buttonEdit.CanFocus = true;
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.UseUnderline = true;
			global::Gtk.Image w2 = new global::Gtk.Image ();
			w2.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-index", global::Gtk.IconSize.Menu);
			this.buttonEdit.Image = w2;
			this.hbox1.Add (this.buttonEdit);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonEdit]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonOpen = new global::Gtk.Button ();
			this.buttonOpen.TooltipMarkup = "Открыть";
			this.buttonOpen.Sensitive = false;
			this.buttonOpen.CanFocus = true;
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.UseUnderline = true;
			global::Gtk.Image w4 = new global::Gtk.Image ();
			w4.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-edit", global::Gtk.IconSize.Menu);
			this.buttonOpen.Image = w4;
			this.hbox1.Add (this.buttonOpen);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonOpen]));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			this.Add (this.hbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.entryObject.KeyPressEvent += new global::Gtk.KeyPressEventHandler (this.OnEntryObjectKeyPressEvent);
			this.buttonEdit.Clicked += new global::System.EventHandler (this.OnButtonEditClicked);
			this.buttonOpen.Clicked += new global::System.EventHandler (this.OnButtonOpenClicked);
		}
	}
}
