   M S B A M L   `   `   `  ����F  BOnlineStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:OnlineStoreOnlineStore  5   	        OnlineStore.SalesmanWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:OnlineStore     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Окно продовца��5	   	   $	��450��6   $	��800��6,    � 	Resources 5       
  Button �� 
TargetType �� 	Resources �� Property �� Value��%�   &	        �� 5   
   " ��6    5      ���� 5      '��       " ��6   .�5      ��  �@��CornerRadius$ 10��65   5      5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� ���#B0E5FD$��75��6)   $��Bottom=�65   $��0��6P   �� 5   
   ���#B0E5FD$��75��6)   $	��Top=�65   $��3��6M   �� 5!   
   -   5        $��IdUsers��5!   0   $�� ��6   $y�Hidden=�6   60   � 5#   
   $��Center=�6   $��Center=�61   .+�5$      �� $��0q�6   $��Продавец:��6#   $��25(�64   $��Center=�6B   $��Center=�6_   �� 5%      -   5        $
��User��5%   )   $��5,0,0,0q�6   $��25(�65   $��Center=�6C   $��Center=�6`   5&      �� 5)   
   $��1��6   $��Окно продавца��6!   $	��100(�66   $��Center=�6E   $��Center=�6b   �� 5*   
   -   5        $
��Back��5*   �   $��
Назад��6   $��2��6!   $��0��6.   $��2��6>   $��10q�6R   $��40(�6^   $��55��6l   ���#FDBD40#��[  6�   � 5,   
   $��3��6   $��Center=�6!   $��Center=�6>   $��4��6Y   .+�5-      �� $��Center=�6   $��Center=�65   $��25(�6P   $��Время сеанса: ��6^   �� 5.      -   5        $��timeTB��5.   P   $��Center=�6   $��Center=�65   $��25(�6^   5/      50      51      