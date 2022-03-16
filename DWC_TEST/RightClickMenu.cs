using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DWC_TEST
{
   class RightClickMenu
   {

      public static ContextMenu context;

      public static void loadRightClickMenuItems()
      {
      
         context = new ContextMenu();

         MenuItem menuItemCopy = new MenuItem();
         menuItemCopy.Header = "Copy";
         menuItemCopy.Click += copy;

         MenuItem menuItemPaste = new MenuItem();
         menuItemPaste.Header = "Paste";
         menuItemPaste.Click += paste;

         context.Items.Add(menuItemCopy);
         context.Items.Add(menuItemPaste);
         context.Items.Add("Item 3");
         context.Items.Add("Item 4");

      }

      public static void copy(object Sender, EventArgs e)
      {
         TextBox t = new TextBox();
         System.Windows.Clipboard.SetText(t.SelectedText);
      }

      public static void paste(object Sender, EventArgs e)
      {
         TextBox t = new TextBox();
         t.Text = System.Windows.Clipboard.GetText();
      }

   }
}
