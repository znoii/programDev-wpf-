   M S B A M L   `   `   `  ����  BookRent    BookRent.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Book Rental System��5   	    � WindowStartupLocation$ CenterScreen=�5   	   $	��600��5	   	   $	��800��6   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ CurrentUserTextBlock��5      $��1��62   $��10q�6?   $��14(�6K   �� 5   
   -   5         ��Name$ BooksListView��5      $��2��6*   $��10q�67   
������� �� View 5      �� 5      .P�5      �� $��Book ID��6%    �� Width$	 100��6^    �� DisplayMemberBinding 66   �� *BookId+6^   �� 5      $��Title��6%   $	 150��6[    64   �� *Title+6[   �� 5      $��Genre��6%   $	 100��6[    64   �� *Genre+6[   �� 5      $��Status��6%   $	 120��6i    65   �� *Status.StatusAvail+6i   �� 5      $
��User��6%   $	 150��6b    63   �� *User.FullName+6b   �� 5      $��
Date Start��6%   $	 100��6d    69   �� *	DateStart+6d   5      5      �� 5!   
   $��3��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�5"      �� -   5        $��Add Book��5"      $	��120��6(   $��5q�64   6?   �� 5#      -   5        $��	Edit Book��5#      $	��120��6)   $��5q�65   6@   �� 5$      -   5        $��Delete Book��5$      $	��120��6+   $��5q�67   6B   5%      5&      5'      