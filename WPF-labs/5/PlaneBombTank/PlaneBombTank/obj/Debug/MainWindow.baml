   M S B A M L   `   `   `  ����?  ;Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null) clr-namespace:Game;assembly=GameGame  5   	    PlaneBombTank   PlaneBombTank.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   0lgc clr-namespace:Game;assembly=Game     5   	     � Title$"  Бомбардировщик��5   	    � SizeToContent$ WidthAndHeight=�6     � 
ResizeMode$ NoResize=�6?   ��5      �� 5   
    �� ImageSource$$ /Game;component/images/fon.jpg��6   .��5      ]� .+�5   
      Game.GameWindow  -   5        $��
GameWindow��5      $	��690��6+   $
��1000��68   �� 5   
   $��Right=�6   $	��250��6,   
������� � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5      " ��6   .�5      ��  � ��$	 200��6.   �� 5       � ��$ 10q�6/   �� 5       � ��$ 10q�60   5      5      .+�5      �� $
��Wrap=�6Y   $��50��6m   
������� �� TextAlignment$ Center=�6�   ��6   �� 	 �� ElementName$	 
GameWindow��
 �� Path$
 SelectedObjectInfo�6�   �� 5      $��Начать игру��6   
������$��lgc:Settings.Start��6C   ��6`   �� $	 
GameWindow���� 5      $!��Сбросить бомбу��6   
��� ���$��lgc:Settings.Action��6B   ��6`   �� $	 
GameWindow���� 5      $(��"Поставить на паузу��6   $��lgc:Settings.Pause��62   ��6O   �� $	 
GameWindow���� 5      $��Начать заново��6   $��lgc:Settings.Reset��6-   ��6J   �� $	 
GameWindow��5      5      5      