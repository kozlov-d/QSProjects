
// This file has been generated by the GUI designer. Do not modify.
namespace QSOrmProject
{
	public partial class DisableSpinButton
	{
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.CheckButton check;
		
		private global::Gtk.SpinButton spinbutton;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget QSOrmProject.DisableSpinButton
			global::Stetic.BinContainer.Attach (this);
			this.Name = "QSOrmProject.DisableSpinButton";
			// Container child QSOrmProject.DisableSpinButton.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.check = new global::Gtk.CheckButton ();
			this.check.CanFocus = true;
			this.check.Name = "check";
			this.check.Label = "";
			this.check.DrawIndicator = true;
			this.check.UseUnderline = true;
			this.hbox1.Add (this.check);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.check]));
			w1.Position = 0;
			w1.Expand = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.spinbutton = new global::Gtk.SpinButton (0, 100, 1);
			this.spinbutton.Sensitive = false;
			this.spinbutton.CanFocus = true;
			this.spinbutton.Name = "spinbutton";
			this.spinbutton.Adjustment.PageIncrement = 10;
			this.spinbutton.ClimbRate = 1;
			this.spinbutton.Numeric = true;
			this.hbox1.Add (this.spinbutton);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.spinbutton]));
			w2.Position = 1;
			this.Add (this.hbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.check.Toggled += new global::System.EventHandler (this.OnCheckToggled);
			this.spinbutton.ValueChanged += new global::System.EventHandler (this.OnSpinbuttonValueChanged);
		}
	}
}
