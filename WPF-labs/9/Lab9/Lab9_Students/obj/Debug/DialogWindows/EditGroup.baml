   M S B A M L   `   `   `  ����H  DLab9_Students, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Lab9_Students.DialogWindowsLab9_Students.DialogWindows  5   	   +    %Lab9_Students.DialogWindows.EditGroup   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Lab9_Students.DialogWindows     5   	     � Title$  	EditGroup��5   	   $	��300��6   $	��300��6(    � 	Resources 5
       �� 
TargetType �� Property �� Value��%�  '��       '�� �     �� 5   
   " ��6   �5      �� 5       � ��$
 Left=�68   �� 5       � ��$	 Top=�66   �� 5       � ��$ 26��6+   �� 5       � ��$ 80��6*   5      �� 5   
   " ��6   �5      �� 5       � ��$
 Left=�68   �� 5       � ��$	 Top=�66   �� 5       � ��$ 23��6+   �� 5       � ��$	 120��6*   5      5      .��5      � -   5         �Name$ 	gridGroup��5      $��0,0,2,0q�6   .+�5   
   �� $��Данные группы��6   $��Center=�6(   $��0,10,0,0q�6E   $	��Top=�6W   $	��152��6o   �� 5    
   $"��Специальность *��6   $��	22,50,0,0q�6*   $	��102��6=   �� 5!   
   -   5         ��Name$ textBoxSpecialty��5!      $��
130,50,0,0q�6,   $	��142��6\   ��6A   �� *	Specialty+6\   �� 5"   
   $#��Начало обучения��6   $��	22,90,0,0q�6*   $	��102��6=   (  "System.Windows.Controls.DatePicker  5#   
   -   5          Name$ datePickerStart��5#      $��
130,90,0,0q�6I      SelectedDateFormat$ Short=�6]   $
��Left=�6x   $	��Top=�6�   $	��142��6�   	   Text	 6.   �� *	StartDate+6�   �� 5$   
   $!��Конец обучения��6   $��
22,130,0,0q�6)   $	��102��6=     5%   
   -   5        $ datePickerEnd��5%      $��130,130,0,0q�6E   $ Short=�6Z   $
��Left=�6u   $	��Top=�6�   $	��142��6�   	 6,   �� *	EndDate+6�   �� 5&   
   $��Стоимость *��6   $��
22,170,0,0q�6&   $	��102��6:   �� 5'   
   -   5        $ textBoxPrice��5'      $��130,170,0,0q�6?   $	��142��6T   ��6(   �� *Price+6T   �� 5(   
   -   5        $
��ОК��5(      $
��Left=�6   $��
50,220,0,0q�69   $	��Top=�6M   $��75��6e   6p   �� 5)   
   -   5        $��Отмена��5)      $
��Left=�6"   $��150,220,0,0q�6=   $	��Top=�6R   $��75��6j   6u   5*      5+      