using DarkWolfCraftSys;
using System;
using System.Windows;

namespace DWC_Calculator
{
   public partial class MainWindow : Window
   {

      public static MainWindow mainWindow;

      public MainWindow()
      {
         InitializeComponent();
         mainWindow = this;
         WindowOverlayManager.updateAllWindowContent(mainWindow.DWC_Calculator);
         new handler.WindowControler();

      }

   }
}
