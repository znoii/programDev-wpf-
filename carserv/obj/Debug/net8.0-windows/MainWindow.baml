   M S B A M L   `   `   `  ����B  >carserv, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:carservcarserv  5   	       carserv.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:carserv     5   	     � Title$  
MainWindow��5   	   $	��600��6   $	��900��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��0.8* �6   �� 5      $
��0.2* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ RequestsList��5      $��4��6)   ��6=   �� *
Requests+ �� View 5      �� 5      .P�5      �� $	��№��6%    �� Width$ 40��6T    �� DisplayMemberBinding 60   �� *Id+6T   �� 5      $��Дата��6%   $ 80��6y    63   �� *CreatedDate+ �� StringFormat$ 
dd.MM.yyyy��6y   �� 5      $��Клиент��6%   $	 120��6a    65   �� *
ClientName+6a   �� 5      $��Телефон��6%   $	 100��6c    66   �� *PhoneNumber+6c   �� 5      $��Статус��6%   $	 120��6]    65   �� *Status+6]   �� 5      $ ��Ответственный��6%   $	 150��6o    6<   �� *Employee.FullName+6o   5      5!      �� 5$   
   -   5        $5��/Назначить ответственного��5$      $��5q�5%      $��1��6   $��2��6)   5&      5'      