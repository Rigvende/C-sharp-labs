   M S B A M L   `   `   `  ����?  ;Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GameGame  5          Game.GameWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      "lgcclr-namespace:Game     5        � 	Resources  5
       !  BooleanToVisibilityConverter1��%   &	        �� 5   
   6'   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ lgc:Settings.Start��5      6O     5   
   -   5        $ lgc:Settings.Pause��5      6O     5   
   -   5        $ lgc:Settings.Reset��5      6O     5   
   -   5        $ lgc:Settings.Action��5      6Q   .��5      � .+�5   
   �� }�.  � UseLayoutRounding .   � DataContext 5        Game.ObjectsState  5      -   5        Context��   Plane 5        
Game.Plane  5        Game.AbstractObject   
GameObject$ -200,550,200,70�6$      Tank 5        	Game.Tank  5      $ 550,30,150,70�6#      Missile 5        Game.Missile  5      $ 	0,0,50,50�6&   	   	IsEnabled	 .  6=   5!      
 � LayoutTransform
 5#      �� 5$       �� ScaleY$ -1Q�6!     5&       �� 
TargetType �� Property �� Value �� Path �� 	Converter��%  '��       7   �� 5'      " ��6   .�5(      ��  � �� 6/   �� *Image+�� 5)       �@��Left 64   �� $ GameObject.X��� 5*       �@��Top 63   �� $ GameObject.Y��� 5+       � �� 6.   �� $ GameObject.Width��� 5,       � �� 6/   �� $ GameObject.Height��� 5-       � ��$
 Fill=�60   �� 5.       � y� 63   �� $ 	IsEnabled�8   �� 5/       �@�LayoutTransform 50      �� 51      $ -1Q�6-   53      54      55      .+�56      �� -   5        $&�� /Game;component/images/plane.png��56   7    6a   �� $ Plane��� 57       6   �� $
 Tank��� 58      -   5         58   7   �� $ Missile�59      5:      5;      