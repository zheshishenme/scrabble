/* Create MenuBar:
	  * all submenu, 
	  * menuitems 
	  * connections to GTK (like icons)
 * I wrote tutorial (in Czech):
 * http://anilinux.org/~keddie/index.php?page=Csharp+GtkSharp+Menu
 */

using System;
using Gtk;

namespace Scrabble.GUI {
	
	public class MenuHover {
		
		UIManager uim;							// 
		ActionGroup ag;							// ActionGroup - some important GTK stuf (group menu widget)
		Scrabble.GUI.ScrabbleWindow parrent;
		
		/* Popdown menu */
		Gtk.Action game;
		Gtk.Action dictionary;
		Gtk.Action settings;
		Gtk.Action help;
		
		/* Items in menu */
		Gtk.Action newG;
		Gtk.Action loadG;
		Gtk.Action saveG;
		Gtk.Action endG;
		
		Gtk.Action infoD;
		Gtk.Action checkD;	
		Gtk.Action addD;
		Gtk.Action loadD;
		
		Gtk.Action optionS;
		
		Gtk.Action about;
				
		/* Menu BAR - public, for another class (like Window) */
		public MenuBar menuBar;
		
		public MenuHover( ScrabbleWindow par ) {
			this.parrent = par;
			this.uim = new UIManager();
			this.ag = new ActionGroup("Default");
			
			this.game = new Gtk.Action("game", "Hra", null, null);
			this.dictionary = new Gtk.Action("dictionary", "Slovník", null, null);
			this.settings = new Gtk.Action("settings", "Nastavení", null, null);
			this.help = new Gtk.Action("help", "Nápověda", null, null);
			this.ag.Add( game );
			this.ag.Add( dictionary );
			this.ag.Add( settings );
			this.ag.Add( help );
			
			this.newG  = new Gtk.Action("newG", "Nová",   null, "gtk-open");
			this.newG.ShortLabel = "Nová";
			this.loadG = new Gtk.Action("loadG","Načíst", "Načíst hru" , "gtk-load");
			this.saveG = new Gtk.Action("saveG","Uložit", "Uložit hru", "gtk-save");
			this.endG  = new Gtk.Action("endG", "Konec",  "Ukončí program", "gtk-quit");
			this.endG.Activated += (sender, e) => Application.Quit();
			this.infoD = new Gtk.Action("infoD", "Info", "Informace o slovníku", "gtk-info");
			this.infoD.Activated += StaticWindows.DictionaryInfoDialog;
			this.addD = new Gtk.Action("addD", "Přidat slovo", null, "gtk-add");
			this.addD.Activated += StaticWindows.AddNewWordToDic;
			this.checkD = new Gtk.Action( "checkD", "Ověř slovo", "Ověří zda je slovo v aktuálním slovníku.", "gtk-load");
			this.checkD.Activated += StaticWindows.CheckWordDialog;
			this.loadD = new Gtk.Action( "loadD", "Načti slovník", "Načti slovník" , "gtk-load");
			this.loadD.Activated += StaticWindows.LoadNewDictionaryDialog;
			this.optionS = new Gtk.Action("optionS", "Volby", null, "gtk-prefernces");
			this.about = new Gtk.Action("about", "O aplikaci", null, "gtk-info");
			this.about.Activated += StaticWindows.AboutProgramDialog;
			
			this.ag.Add( newG, null);
			this.ag.Add( loadG, null);
			this.ag.Add( saveG, null);
			this.ag.Add( endG, "<Control><Mod2>q");
			this.ag.Add( infoD, "<Control><Mod2>i");
			this.ag.Add( addD , "<Control><Mod2>a" );
			this.ag.Add( checkD, "<Mod2>F5" );
			this.ag.Add( loadD, null);
			this.ag.Add( optionS, null);
			this.ag.Add( about, null);
					
			this.uim.InsertActionGroup( ag, 0);
			parrent.AddAccelGroup( uim.AccelGroup );
			uim.AddUiFromFile("./GUI/menu.xml");		
			this.menuBar = (MenuBar) uim.GetWidget("/menubar");
		}
	}
}