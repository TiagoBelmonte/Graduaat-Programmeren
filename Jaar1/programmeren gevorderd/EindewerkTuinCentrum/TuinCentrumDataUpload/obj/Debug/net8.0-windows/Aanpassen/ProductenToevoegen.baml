   M S B A M L   `   `   `  ����H  DTuinCentrumUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TuinCentrumUI.AanpassenTuinCentrumUI.Aanpassen  5   	   0    *TuinCentrumUI.Aanpassen.ProductenToevoegen   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:TuinCentrumUI.Aanpassen     5   	     � Title$  ProductenToevoegen��5   	   $	��450��6$   $	��800��61   ���	#FFC0F3BF.��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   
�������$��1q�61   $��2q�6E   ._�5      � ���	#FFC0F3BF � ColumnDefinitions 5      �� 5      $
��auto �6'   �� 5      $��3* �6'   �� 5      $
��auto �6'   �� 5      $��* �6'   �� 5      $
��auto �6'   �� 5      $
��auto �6'   �� 5      $
��auto �6'   .+�5      �� $��0��6   $��Wetenschappelijke naam: ��6(   $��5q�6K   �� 5      -   5         ��Name$ TextboxWetNaam��5      $��1��62   $��5q�6B   6M   5      5       �� 5"   
   $��1��6   
�������$��1q�61   $��2q�6E   ._�5#      � ���	#FF184F1A 5$      �� 5%      $
��auto �6'   �� 5&      $��4* �6'   �� 5'      $��* �6'   �� 5(      $��4* �6'   .+�5+      �� $��0��6   $�� ��6(   $��5q�64   �� 5,      -   5        $��AlleProductenListBox��5,   *   $��1��6   $��5,56,5,5q�6F    �� SelectionMode$ Extended=�6X   �� 5-      $��2��6   $��5q�6-   $��Center=�68   .+�5.      �� -   5        $��VoegAlleProductenToe��5.      $��>>��69   $��5q�6u   �� 5/      -   5        $��VoegProductToe��5/      $��>��63   $��5q�6f   �� 50      -   5        $��VerwijderAlleProducten��50      $��<<��6;   $��5q�6z   �� 51      -   5        $��VerwijderProductToe��51      $��<��68   $��5q�6f   52      �� 53      -   5        $#��GeselecteerdeProductenListBox��53   *   $��3��6   $��5,56,5,5q�6O   $ Extended=�6a   54      55      �� 57   
   -   5        $��2��57      $��Volgende��6   $��5q�61   6<   58      59      