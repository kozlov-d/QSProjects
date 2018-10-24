
// This file has been generated by the GUI designer. Do not modify.
namespace QSSupportLib
{
	public partial class ErrorMsg
	{
		private global::Gtk.HBox hbox1;

		private global::Gtk.Image image249;

		private global::Gtk.VBox vbox2;

		private global::Gtk.Label label1;

		private global::Gtk.Label labelUserMessage;

		private global::Gtk.Label label3;

		private global::Gtk.Table table1;

		private global::Gtk.Entry entryEmail;

		private global::Gtk.ScrolledWindow GtkScrolledWindow1;

		private global::Gtk.TextView textviewDescription;

		private global::Gtk.Label label2;

		private global::Gtk.Label label4;

		private global::Gtk.Label label5;

		private global::Gtk.HSeparator hseparator1;

		private global::Gtk.Expander expander1;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.TextView textviewError;

		private global::Gtk.Label GtkLabel1;

		private global::Gtk.Button buttonSendReport;

		private global::Gtk.Button buttonCopy;

		private global::Gtk.Button buttonOk;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget QSSupportLib.ErrorMsg
			this.WidthRequest = 1000;
			this.Name = "QSSupportLib.ErrorMsg";
			this.Title = global::Mono.Unix.Catalog.GetString("Ошибка");
			this.Icon = global::Stetic.IconLoader.LoadIcon(this, "gtk-dialog-error", global::Gtk.IconSize.Menu);
			this.TypeHint = ((global::Gdk.WindowTypeHint)(1));
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			// Internal child QSSupportLib.ErrorMsg.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.image249 = new global::Gtk.Image();
			this.image249.Name = "image249";
			this.image249.Xalign = 0F;
			this.image249.Yalign = 0F;
			this.image249.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-dialog-error", global::Gtk.IconSize.Dialog);
			this.hbox1.Add(this.image249);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.image249]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.Xalign = 0F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("К сожалению в программе произошла непредвиденная ошибка.");
			this.vbox2.Add(this.label1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.label1]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.labelUserMessage = new global::Gtk.Label();
			this.labelUserMessage.Name = "labelUserMessage";
			this.labelUserMessage.LabelProp = global::Mono.Unix.Catalog.GetString("label2");
			this.labelUserMessage.Wrap = true;
			this.labelUserMessage.Selectable = true;
			this.vbox2.Add(this.labelUserMessage);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.labelUserMessage]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.Xalign = 0F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Вы можете помочь нам улучшить программу и исправить данную проблему. \nДля этого в" +
					"оспользуйтесь формой отправки отчета об ошибке.\n");
			this.label3.Justify = ((global::Gtk.Justification)(3));
			this.vbox2.Add(this.label3);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.label3]));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table(((uint)(3)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.entryEmail = new global::Gtk.Entry();
			this.entryEmail.TooltipMarkup = "Для отправки отчета нам требуется ваш email. Мы будем использовать его для уточне" +
				"ния информации об ошибке, а также для оперативного информирования об устранении " +
				"данной проблемы.";
			this.entryEmail.CanFocus = true;
			this.entryEmail.Name = "entryEmail";
			this.entryEmail.IsEditable = true;
			this.entryEmail.InvisibleChar = '●';
			this.table1.Add(this.entryEmail);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.entryEmail]));
			w6.TopAttach = ((uint)(2));
			w6.BottomAttach = ((uint)(3));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.textviewDescription = new global::Gtk.TextView();
			this.textviewDescription.TooltipMarkup = "В этом поле опишите последовательность действий, которая привела к возникновению " +
				"ошибки.";
			this.textviewDescription.CanFocus = true;
			this.textviewDescription.Name = "textviewDescription";
			this.GtkScrolledWindow1.Add(this.textviewDescription);
			this.table1.Add(this.GtkScrolledWindow1);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1[this.GtkScrolledWindow1]));
			w8.TopAttach = ((uint)(1));
			w8.BottomAttach = ((uint)(2));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(2));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.TooltipMarkup = "В этом поле опишите последовательность действий, которая привела к возникновению " +
				"ошибки.";
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Описание:");
			this.table1.Add(this.label2);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1[this.label2]));
			w9.TopAttach = ((uint)(1));
			w9.BottomAttach = ((uint)(2));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label();
			this.label4.TooltipMarkup = "Для отправки отчета нам требуется ваш email. Мы будем использовать его, для уточн" +
				"ения информации об ошибке, а также для оперативного информирования об устранении" +
				" данной проблемы.";
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Ваш e-mail:");
			this.table1.Add(this.label4);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1[this.label4]));
			w10.TopAttach = ((uint)(2));
			w10.BottomAttach = ((uint)(3));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Для отправки отчета, пожалуйста, заполните следующие поля:");
			this.table1.Add(this.label5);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1[this.label5]));
			w11.RightAttach = ((uint)(2));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox2.Add(this.table1);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.table1]));
			w12.Position = 3;
			w12.Expand = false;
			w12.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hseparator1 = new global::Gtk.HSeparator();
			this.hseparator1.Name = "hseparator1";
			this.vbox2.Add(this.hseparator1);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hseparator1]));
			w13.Position = 4;
			w13.Expand = false;
			w13.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.expander1 = new global::Gtk.Expander(null);
			this.expander1.CanFocus = true;
			this.expander1.Name = "expander1";
			this.expander1.Expanded = true;
			// Container child expander1.Gtk.Container+ContainerChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.HeightRequest = 203;
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.textviewError = new global::Gtk.TextView();
			this.textviewError.CanFocus = true;
			this.textviewError.Name = "textviewError";
			this.textviewError.Editable = false;
			this.textviewError.WrapMode = ((global::Gtk.WrapMode)(2));
			this.GtkScrolledWindow.Add(this.textviewError);
			this.expander1.Add(this.GtkScrolledWindow);
			this.GtkLabel1 = new global::Gtk.Label();
			this.GtkLabel1.Name = "GtkLabel1";
			this.GtkLabel1.LabelProp = global::Mono.Unix.Catalog.GetString("Техническая информация");
			this.GtkLabel1.UseUnderline = true;
			this.expander1.LabelWidget = this.GtkLabel1;
			this.vbox2.Add(this.expander1);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.expander1]));
			w16.Position = 5;
			this.hbox1.Add(this.vbox2);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vbox2]));
			w17.Position = 1;
			w1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(w1[this.hbox1]));
			w18.Position = 0;
			// Internal child QSSupportLib.ErrorMsg.ActionArea
			global::Gtk.HButtonBox w19 = this.ActionArea;
			w19.Name = "dialog1_ActionArea";
			w19.Spacing = 10;
			w19.BorderWidth = ((uint)(5));
			w19.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonSendReport = new global::Gtk.Button();
			this.buttonSendReport.CanFocus = true;
			this.buttonSendReport.Name = "buttonSendReport";
			this.buttonSendReport.UseUnderline = true;
			this.buttonSendReport.Label = global::Mono.Unix.Catalog.GetString("Отправить отчет");
			global::Gtk.Image w20 = new global::Gtk.Image();
			w20.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("QSSupportLib.icons.send-error-report.png");
			this.buttonSendReport.Image = w20;
			w19.Add(this.buttonSendReport);
			global::Gtk.ButtonBox.ButtonBoxChild w21 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w19[this.buttonSendReport]));
			w21.Expand = false;
			w21.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCopy = new global::Gtk.Button();
			this.buttonCopy.TooltipMarkup = "Копирует сообщение в буфер обмена.";
			this.buttonCopy.CanFocus = true;
			this.buttonCopy.Name = "buttonCopy";
			this.buttonCopy.UseUnderline = true;
			this.buttonCopy.Label = global::Mono.Unix.Catalog.GetString("Скопировать");
			global::Gtk.Image w22 = new global::Gtk.Image();
			w22.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-copy", global::Gtk.IconSize.Menu);
			this.buttonCopy.Image = w22;
			w19.Add(this.buttonCopy);
			global::Gtk.ButtonBox.ButtonBoxChild w23 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w19[this.buttonCopy]));
			w23.Position = 1;
			w23.Expand = false;
			w23.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = global::Mono.Unix.Catalog.GetString("Понятно");
			global::Gtk.Image w24 = new global::Gtk.Image();
			w24.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-close", global::Gtk.IconSize.Menu);
			this.buttonOk.Image = w24;
			this.AddActionWidget(this.buttonOk, -7);
			global::Gtk.ButtonBox.ButtonBoxChild w25 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w19[this.buttonOk]));
			w25.Position = 2;
			w25.Expand = false;
			w25.Fill = false;
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 1553;
			this.DefaultHeight = 784;
			this.Show();
			this.buttonSendReport.Clicked += new global::System.EventHandler(this.OnButtonSendReportClicked);
			this.buttonCopy.Clicked += new global::System.EventHandler(this.OnButtonCopyClicked);
		}
	}
}
