   M S B A M L   `   `   `  ����  Signing    Signing.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��300��6   $	��550��6)    � WindowStyle$
 None=�65    � AllowsTransparency . ���	#FFEFF3F5 � 	Resources 5         ReturnButton �� 
TargetType ��Name �� Triggers P� Property P� Value	 �� 
TargetName
 �� Property �� Value :� RoutedEvent��%  &	        �� 5   
   " ��6/   .R�5      � $��0,0,-0.75,0q�6   .+�5	      �� $ image��6   $��images/return.jpg��6$   $
��Fill=�6?   $��4,0,0,0q�6N   $
��Left=�6_   $��96.084��6z   5       5      P� 5       �@J�IsMouseOver . . �5      �� $	 image��6+   
 �@J�OpacityMask �	#FFDE5B5B6>   �� 5      $	 image��6'   
 �@J�Opacity$
 0.85Q�6:   5      :� 5      $ FrameworkElement.Loaded��6   P� 5       �@��	IsDefault .  6)   5      5      .��5      � .+�5   
   o� $��	0,0,0,258q�6   ���	#FFEFF3F5.@�5      m� $��Посмотреть��6   $��40��6+   $��81��67   .@�5      m� -   5        $4��.Информации о регистрации��5      6Z   m� 5      -   5        $��Проживание��5      6F   m� 5      -   5        $��Бронирование��5      6I   m� 5      -   5        $'��!Категории номеров��5      6O   m� 5      -   5        $��
Места��5      6A   5      5      �� 5    
   -   5         ��Name$ ReturnButton��5       $
��Left=�6'   $��35.666��6B   $��10,254.334,0,0q�6R   $	��Top=�6j   $��102.5��6�   #���   6�    J� Opacity$	 0.8Q�6�    �� IsCancel . 6�   �� 5!   
   $����Вы зашли под администратором.
Здесь вы можете просматривать 
всю базу данных, заселять
гостей, редактировать таблицы,
содержащие информацию о
проживании, удалять бронь и
зарегистрированных пользователей.��6   $
��Left=�6  $��	10,68,0,0q�6  $	��Top=�61  $	��219��6I  $	��149��6U  &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ 	DataGrid1��5"         AutoGenerateColumns . $
��Left=�6B   $��
234,42,0,0q�6]   $	��Top=�6q   $	��161��6�   $	��306��6�   6�   �� 5#   
   -   5        $��	AddLiving��5#      $��Заселить��6"   $
��Left=�65   $��234,222,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5$   
   -	   5        $��Change��5$      $��Изменить��6   $
��Left=�62   $��337,222,0,0q�6M   $	��Top=�6b   $��75��6z   6�   �� 5%   
   -
   5        $��	DeleteReg��5%      $-��'Удалить пользователя��6"   $
��Left=�6A   $��234,222,0,0q�6\   $	��Top=�6q   $	��134��6�   6�   �� 5&   
   -   5        $ 
DeleteBook��5&      $��Удалить бронь��6%   $
��Left=�6=   $��234,222,0,0q�6X   $	��Top=�6m   $	��134��6�   6�   5'      5(      