   M S B A M L   `   `   `  ����H  DTuinCentrumUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:TuinCentrumUI.OfferteAanmakenTuinCentrumUI.OfferteAanmaken  5   	   7    1TuinCentrumUI.OfferteAanmaken.ProductenSelecteren   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:TuinCentrumUI.OfferteAanmaken     5   	     � Title$  ProductenSelecteren��5   	   $	��450��6%   $	��800��62   ���	#FFC0F3BF.��5	      �  � RowDefinitions 5
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
��auto �6'   .+�5      �� $��0��6   $7��1Onder Welke naam wilt u volgende Producten kopen?��6(   $��5q�6d   �� 5      -   5         ��Name$ TextBoxNaam��5      $��1��6/   $
��Naam��6?   $��5q�6K   5      5       �� 5"   
   $��1��6   
�������$��1q�61   $��2q�6E   ._�5#      � ���	#FF355E3B 5$      �� 5%      $
��auto �6'   �� 5&      $��4* �6'   �� 5'      $��* �6'   �� 5(      $��4* �6'   .+�5+      �� $��0��6   $�� ��6(   $��5q�64   �� 5,      -   5        $��AlleProductenListBox��5,   *   $��1��6   $��5,56,5,5q�6F    �� SelectionMode$ Extended=�6X   �� 5-      $��2��6   $��5q�6-   $��Center=�68   .+�5.      �� -   5        $��VoegAlleProductenToe��5.      $��>>��69   $��5q�6u   �� 5/      -   5        $��VoegProductToe��5/      $��>��63   $��5q�6f   �� 50      -   5        $��VerwijderAlleProducten��50      $��<<��6;   $��5q�6z   �� 51      -   5        $��VerwijderProductToe��51      $��<��68   $��5q�6f   52      �� 53      -   5        $#��GeselecteerdeProductenListBox��53   *   $��3��6   $��5,56,5,5q�6O   $ Extended=�6a   �� 54      -   5         ��Name$ LabelWetNaam��54      $��1��6.   $��Wetenschappelijke naam: ��6>   $
��Left=�6a   $��44��6|   $��7,7,0,0q�6�   $	��Top=�6�   $	��141��6�   ���	#FFF3F2F26�   �� 55      -	   5        $ TextboxWetNaam��55      $��1��62   $
��Left=�6D   $��25��6_   $��
150,10,0,0q�6k    �� TextWrapping$
 Wrap=�6   $	��Top=�6�   $	��193��6�   $��2��6�   6�   56      57      �� 59   
   -
   5        $��2��59      $��Volgende��6   $��5q�61   6<   5:      5;      