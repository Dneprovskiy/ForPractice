   M S B A M L   `   `   `  ����F  BOnlineStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:OnlineStoreOnlineStore  5   	       OnlineStore.CaptchaWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:OnlineStore     5   	     � Title$  CaptchaWindow��5   	   $	��350��6   $	��400��6,    � WindowStartupLocation$ CenterScreen=�68    � 
ResizeMode$ NoResize=�6]    � WindowStyle$
 None=�6s    � 	Resources 5	       
  Button �� 
TargetType �� 	Resources �� Property �� Value��%�   &	        �� 5
   
   " ��6    5      ���� 5      '��       " ��6   .�5      ��  �@��CornerRadius$ 10��65   5      5      5      5      .��5      � ���#FFFFFF	 � RowDefinitions	 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� ���#B0E5FD$��50��6)   $��Bottom=�65   $��0��6P   $��2��6]   �� 5   
   ���#B0E5FD$��50��6)   $	��Top=�65   $��5��6M   $��2��6Z   �� 5!   
   $��Введите капчу��6   $��1��6)   $��2��69   $��Center=�6M   $��Center=�6j   $��30(�6�   $
��Bold"�6�   �� 5#   
   -   5        $��CaptchaCanvas��5#   B   $��1��6   $��10q�6   $��65��6*   $	��250��66   6B   �� 5$   
   -   5        $��Captcha��5$   e   $��1��6   $��10q�6!   $��50(�6-   $
��Bold"�6;   $��45��6M   $	��200��6Y   
 �� TextAlignment$
 Center=�6t   $��Chiller)�6�   �� 5&   
   -   5        $��GenerateCapcha��5&   w   $+��%Сгенерировать капчу��6   $��3��6/   $��10q�6<   $��16(�6H   $��25��6V   ���#FDBD40#��[  6�   �� 5(   
   -   5        $��EnterCaptcha��5(   P   $��2��6   $��5q�6   $��16(�6*   $��25��68   $	��200��6D   6P   �� 5)   
   -   5        $��Continue��5)   n   $��Продолжить��6   $��4��6&   $��10q�63   $��16(�6?   $��25��6M   ���#FDBD40#��[  6�   �� 5+   
   -   5        $��block��5+   !   $��5��6   $��Center=�6.   $��Center=�6I   $��16(�6f   
���  ��6t   5,      5-      