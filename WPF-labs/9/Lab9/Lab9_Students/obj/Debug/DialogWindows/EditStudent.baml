   M S B A M L   `   `   `  ����H  DLab9_Students, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Lab9_Students.DialogWindowsLab9_Students.DialogWindows  5   	   -    'Lab9_Students.DialogWindows.EditStudent   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Lab9_Students.DialogWindows     5   	     � Title$  Edit Student��5   	   $	��280��6   $	��280��6+    � 	Resources 5
       �� 
TargetType �� Property �� Value��%�  '��       '�� �     �� 5   
   " ��6   �5      �� 5       � ��$
 Left=�68   �� 5       � ��$	 Top=�66   �� 5       � ��$ 26��6+   �� 5       � ��$ 80��6*   5      �� 5   
   " ��6   �5      �� 5       � ��$
 Left=�68   �� 5       � ��$	 Top=�66   �� 5       � ��$ 23��6+   �� 5       � ��$	 120��6*   5      5      .��5      � -   5         �Name$ gridStudent��5      $��0,0,2,0q�6    .+�5   
   �� $#��Данные студента��6   $��Center=�6*   $��0, 10, 0, 0q�6G   $	��Top=�6\   $	��152��6t   �� 5   
   $��ФИО *��6   $��	22,50,0,0q�6    �� 5    
   -   5         ��Name$
 Name��5       $��
125,50,0,0q�6    ��65   �� *Name+�� 5!   
   $��Дата рождения��6   $��	22,85,0,0q�6(   $	��100��6;   (  "System.Windows.Controls.DatePicker  5"   
   -   5          Name$ datePickerBirth��5"         SelectedDateFormat$ Short=�6.   $
��Left=�6f   $��
127,86,0,0q�6�   $	��Top=�6�   $	��118��6�   	   Text	 6I   �� *DateOfBirth+6�   �� 5#   
   $��Есть скидка��6   $��
22,120,0,0q�6&   �� 5$   
   -   5        
 ��Name$
 checkBoxDiscount��5$      $�� ��6-   $
��Left=�68   $��125,126,0,0q�6S   $	��Top=�6h   �� 5%   
   $��Имя фото *��6   $��
22,155,0,0q�6%   �� 5&   
   -   5        $ Photo��5&      $��125,155,0,0q�6M   ��6b   �� *Photo+�� 5'   
   -   5        $��Сохранить��5'      $��Center=�6%   $��-100,200,0,0q�6B   $	��Top=�6X   $��75��6p   6{   �� 5(   
   -   5        $��Отмена��5(      $��Center=�6"   $��100,200,0,0q�6?   $	��Top=�6T   $��75��6l   6w   5)      5*      