   M S B A M L   `   `   `  ����  AsteroidsAttempt2"    AsteroidsAttempt2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  
GameWindow��5   	    � Title$ 	Asteroids��5   	   $
��1000��6   $
��1000��6(   $
��Left=�66   $��Center=�6m    � WindowStartupLocation$ CenterScreen=�6�    � WindowState$ 	Maximized=�6�    � Cursor$ Arrow��6�   ���	#FF363535.��5      � .+�5      �� -   5         ��Name$ 
GameCanvas��5   *   $��1��6   $��1��6   |�. {�. $��Stretch=�6`   $��Stretch=�6    J� RenderTransformOrigin$ 0.5,0.5&�6�   $
��1000��6�   $
��1000��6   ��5   
   �� 5       �� ImageSource$Y SD:\CPIT\BCPR283\Asteroids\Asteroids\AsteroidsAttempt2\Resources\SpaceBackground.jpg��6    j� Stretch$
 Fill=�6{   5
      �� 5   
   -   5        	 ��Name$	 border��5   .   $��1��6   $��1��6   $��70q�6>   $
��1060��6S   $
��1060��6`   ���	#FF171717
 �� CornerRadius$
 5��6�   �� 5   
   -   5         ��Name$ lblScore��5      $��5��6"   $��2��6/   $��Score��6?   $��3,0,0,0q�6O   $
��Bold"�6`   $��
Tekton Pro)�6r   $��24(�6�   $	��100��6�   $��50��6�   $
��Left=�6�   $	��Top=�6�   ���	#FFF0EDED6�   �� 5   
   -   5        $ tbxScore��5      $��5��6"   $��2��6/   $��2,50,0,0q�6?   $
��Bold"�6Q   $��
Tekton Pro)�6c   $��24(�6{   $	��100��6�   $��35��6�   $
��Left=�6�   $	��Top=�6�   ���	#FFF0EDED���	#FF363535���	#FF3635356  �� 5   
   -   5        $ lblLives��5      $��5��6"   $��2��6/   $��Lives ��6?   $��	3,100,0,0q�6P   $
��Bold"�6c   $��
Tekton Pro)�6u   $��24(�6�   $	��100��6�   $��50��6�   $
��Left=�6�   $	��Top=�6�   ���	#FFF0EDED6�   �� 5   
   -   5        $ tbxLives��5      $��5��6"   $��2��6/   $��	2,150,0,0q�6?   $
��Bold"�6R   $��
Tekton Pro)�6d   $��24(�6|   $	��100��6�   $��35��6�   $
��Left=�6�   $	��Top=�6�   ���	#FFF0EDED���	#FF363535���	#FF3635356  �� 5   
   -   5        $ 
lblYouLose��5      $��5��6$   $��2��61   $��
Game Over!��6A   $��0q�6V   $
��Bold"�6a   $��
Tekton Pro)�6s   $��48(�6�   $	��300��6�   $��70��6�   $��Center=�6�   $��Center=�6�   ���	#FFF0EDED$y�Hidden=�6   5      5      