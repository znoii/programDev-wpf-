   M S B A M L   `   `   `  ����D  @RepairReq, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:RepairReq	RepairReq  5   	       RepairReq.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:RepairReq     5   	     � Title$  
MainWindow��5   	    � WindowStartupLocation$ CenterScreen=�6$   $	��600��5	   	   $	��800��6   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ CurrentUserTextBlock��5      $��1��62   $��10q�6?   $��14(�6K   �� 5   
   -   5         ��Name$ RequestsListView��5      $��2��6-   $��10q�6:   
������� �� View 5      �� 5      .P�5      �� $��ID��6%    �� Width$	 100��6U    �� DisplayMemberBinding 61   �� *Id+6U   �� 5      $��Description��6%   $	 150��6g    6:   �� *Description+6g   �� 5      $
��Type��6%   $	 100��6Y    63   �� *Type+6Y   �� 5      $��Problem��6%   $	 120��6j    66   �� *Status.StatusAvail+6j   �� 5      $��Master��6%   $	 150��6f    65   �� *Master.FullName+6f   �� 5      $��
Date Start��6%   $	 100��6d    69   �� *	CreatedAt+6d   5      5      �� 5!   
   $��3��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�5"      �� -   5        $��Add Book��5"      $	��120��6(   $��5q�64   6?   �� 5#      -   5        $��	Edit Book��5#      $	��120��6)   $��5q�65   6@   �� 5$      -   5        $��Delete Book��5$      $	��120��6+   $��5q�67   6B   5%      5&      5'      