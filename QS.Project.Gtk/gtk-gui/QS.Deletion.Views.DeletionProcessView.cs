
// This file has been generated by the GUI designer. Do not modify.
namespace QS.Deletion.Views
{
	public partial class DeletionProcessView
	{
		private global::Gtk.VBox vbox2;

		private global::Gamma.GtkWidgets.yLabel ylabelText;

		private global::Gamma.GtkWidgets.yProgressBar yprogressOperation;

		private global::Gtk.Button buttonCancel;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget QS.Deletion.Views.DeletionProcessView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "QS.Deletion.Views.DeletionProcessView";
			// Container child QS.Deletion.Views.DeletionProcessView.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.ylabelText = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelText.Name = "ylabelText";
			this.ylabelText.LabelProp = global::Mono.Unix.Catalog.GetString("ylabel1");
			this.vbox2.Add(this.ylabelText);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.ylabelText]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.yprogressOperation = new global::Gamma.GtkWidgets.yProgressBar();
			this.yprogressOperation.Name = "yprogressOperation";
			this.vbox2.Add(this.yprogressOperation);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.yprogressOperation]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.vbox2.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.buttonCancel]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			this.Add(this.vbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Show();
			this.buttonCancel.Clicked += new global::System.EventHandler(this.OnButtonCancelClicked);
		}
	}
}