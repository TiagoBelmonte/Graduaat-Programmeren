   M S B A M L   `   `   `  ����  
FitnessWPF&     FitnessWPF.WindowMakeReservation   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Make Reservation��5   	   $	��450��5   	   $	��800��5   	   
�������.��5      � $��20q�6    � ColumnDefinitions 5	   
   �� 5
      $��2* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��2��6   $��Make a Reservation��6(   $��20(�5      $
��Bold"�6"   $��Center=�5      $��0,0,0,20q�61   �� 5   
   $��1��6   $��0��6"   $��0,0,10,0q�62   .+�5      �� $��Date:��6   $
��Bold"�6$   &   System.Windows.Controls.Calendar  5      -   5          Name$ calendar��5      $	��200��6)   $��0,0,0,20q�66   5      �� 5      $��Time Slots:��6   $
��Bold"�6*   �� 5      -   5         ��Name$ listboxTimeSlots��5      $	��150��60   $��0,10,0,0q�6=   5       5!      �� 5$   
   $��1��6   $��1��6"   $��10,0,0,0q�62   .+�5%      �� $��Selected Date:��6   $
��Bold"�6-   �� 5&      -   5         ��Name$ lblSelectedDate��5&      $��0,0,0,20q�61   �� 5(      $��Selected Time Slots:��6   $
��Bold"�63   �� 5)      -   5        $ lblSelectedTimeSlot��5)      $
��Wrap=�65   $��50��6I   $��0,0,0,10q�6U   �� 5+      -   5         ��Name$ checkBoxExtraTimeSlot��5+      $��Add Next Time Slot��66   5,   7   �� 5.      $��
Equipment:��6   $
��Bold"�6)   $��0,20,0,0q�6;   �� 5/      -   5        $��Find Equipment��5/      $	��120��6.   $��0,10,0,0q�6:   50      �� 51      -   5        $ lblEquipmentTS1��51      $��0,10,0,0q�61   �� 52      -   5        $ lblEquipmentTS2��52      $��0,10,0,0q�61   53      �� 56   
   -	   5         ��Name$ buttonMakeReservation��56      $��Make Reservation��60   $��2��57      $��2��6   $��Center=�58      $	��150��6.   $��40��6:   
����=H�
�������$
��Bold"�59   ?   5:      5;      5<      