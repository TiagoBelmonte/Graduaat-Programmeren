   M S B A M L   `   `   `  ����  
FitnessWPF&     FitnessWPF.WindowSelectEquipment   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Select Equipment��5   	   $	��450��5   	   $	��800��5   	   
�������.��5      � $��20q�6    � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $%��Select Equipment for Time Slots��6   $��20(�5      $
��Bold"�5      ���#34495E$��Center=�5      $��0,0,0,20q�5      $��0��5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5!      �� $��0��6   $��0,0,20,0q�6)   .+�5"      �� $��Time Slot 1��6   $��16(�6/   $
��Bold"�6=   ���#2C3E50$��0,0,0,10q�6d   �� 5#      $��Available Equipment:��6   $��14(�67   ���#5665736E   �� 5$      -   5         ��Name$ listboxEquipment1��5$      $	��120��5%      ���#BDC3C7$��0,0,0,10q�5(      �� 5)      $��Selected Equipment:��6   $��14(�66   ���#5665736D   �� 5*      -   5        $ listboxSelectedEquipment1��5*      $	��100��5+      ���#BDC3C75,      5-      �� 50      $��1��6   $��2��51      ���#BDC3C7$��Stretch=�53      $��	0,10,0,10q�54      �� 57      $��2��6   $��20,0,0,0q�6)   .+�58      �� $��Time Slot 2��6   $��16(�6/   $
��Bold"�6=   ���#2C3E50$��0,0,0,10q�6d   �� 59      $��Available Equipment:��6   $��14(�67   ���#5665736E   �� 5:      -   5        $ listboxEquipment2��5:      $	��120��5;      ���#BDC3C7$��0,0,0,10q�5>      �� 5?      $��Selected Equipment:��6   $��14(�66   ���#5665736D   �� 5@      -   5        $ listboxSelectedEquipment2��5@      $	��100��5A      ���#BDC3C75B      5C      5D      �� 5G   
   -   5         ��Name$ buttonSaveEquipment��5G      $��Save Equipment��5H      ���#5DADE2
�������$
��Bold"�5K      $	��150��5L      $��40��5M      $��Center=�5N      $��0,20,0,0q�5O      $��2��5P      5Q      5R      5S      