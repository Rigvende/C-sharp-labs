   M S B A M L   `   `   `  ����  Multithreading Equation(    "Multithreading_Equation.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$!  Главная панель��5   	   $	��350��5   	   $	��525��6    � WindowStartupLocation$ CenterScreen=�5   	    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$	 New��5      6'   .��5
      �� .+�5   
   �� $��Center=�6   .��65   dbЗадача: вычислить интеграл по методу прямоугольников6k   �� 5   
   $<��6/Multithreading Equation;component/images/equation.jpg��6   $	��350��6P   $��35��6\   $��5q�6h   6u   �� 5   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5      �� $��Center=�6   $��30��68   .��6E   .,Индивидуальное задание:6^   �� 5      $8��2/Multithreading Equation;component/images/task.jpg��6   $	��100��6P   $��40��6\   6k   5      �� 5   
   $ 
Horizontal=�6   $��Center=�6.   .+�5      �� $��Center=�6   .��66   Результат:6B   �� 5      -   5         ��Name$ resultField��5   �   $	��100��6   $	��200��6%    �� 
IsReadOnly . $��Center=�6F   $��20��6h   $��10q�6t   6�   5      �� 5   
   -   5        $��setData��5   K   $��30��6   $	��200��6   $��10q�6)   
�������.��6o   .,Задать данные уравнения6�   �� 5   
   -   5        $��	getResult��5   W   $��30��6   $	��200��6   $��10q�6)   
�������$	��New��6h   .��6v   %#Вычислить интеграл6�   � 5   
   .+�5      � -   5         �Name$ progressBar��5       � Minimum$ 0Q�5      	 � Maximum$		 100Q�6&   $��5q�5      $��20��6%   $	��200��5      6+   �� 5      -   5        
 ��Name$
 textBar��5      $��0q�6%   $��Center=�60   $��Center=�6T   6s   5      5      5      