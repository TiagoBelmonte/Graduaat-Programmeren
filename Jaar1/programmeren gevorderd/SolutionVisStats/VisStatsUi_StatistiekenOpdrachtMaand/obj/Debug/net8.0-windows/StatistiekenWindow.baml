   M S B A M L   `   `   `  ����_  [VisStatsUi_StatistiekenOpdrachtMaand, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:VisStatsUi_StatistiekenVisStatsUi_Statistieken  5   	   0    *VisStatsUi_Statistieken.StatistiekenWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:VisStatsUi_Statistieken     5   	     � Title$  StatistiekenWindow��5   	   $	��450��6$   $	��800��61   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��Vissoort��6-   $��5q�6@   �� 5   
   -   5        $��VissoortTextBox��5   1   $��0��6   $��1��6!   $��5q�6H   ${�False��6S   �� 5   
   $��0��6   $��2��6   $
��Jaar��6-   $��5q�6<   �� 5   
   -   5        $��JaarTextBox��5   1   $��0��6   $��3��6!   $��5q�6D   ${�False��6O   �� 5   
   $��0��6   $��4��6   $��Eenheid��6-   $��5q�6?   �� 5   
   -   5        $��EenheidTextBox��5   1   $��0��6   $��5��6!   $��5q�6G   ${�False��6R   &   System.Windows.Controls.DataGrid  5   
   -   5        $��StatistiekenDataGrid��5   D   $��1��6   $��0��6    $��6��60   $��5q�6a      
IsReadOnly$
 True��6l      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$   6~   5      5      