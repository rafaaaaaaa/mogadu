   M S B A M L   `   `   `  ����A  =mogadu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:mogadu.Viewsmogadu.Views  5   	       mogadu.Views.LogInView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:mogadu.Views     5   	     � Title$  mogadu��5   	   $	��450��6   $	��550��6%    � DataContext$$ ~/Viewmodels/LoginViewModel.cs��61    � 	Resources 5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $I Cpack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml?�6%   �� 5      $F @pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml?�6%   �� 5      $G Apack://application:,,,/MahApps.Metro;component/Styles/Colors.xaml?�6%   �� 5      $M Gpack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml?�6%   �� 5      $R Lpack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $	��60* �6   6+   �� 5      $��25 �6   6*   �� 5      $	��18* �6   6+   �� 5      $	��18* �6   6+   �� 5      $	��15* �6   6+   �� 5      $
��20px �6   6,   .+�5!   
   �� $��/Resources/icon.png��6   $��0��6-   �� 5"   
   $��mogadu��6   $��1��6!   $��Center=�6.   $
��13px(�6K   $��242,0,242,58q�6[   $��58��6q   
�������$��2��6�   6�   � 5#   
   $��2��6    5$      �� 5%      $
��1.3* �6    60   �� 5&      $��2* �6    6.   .+�5(      �� $��	Benutzer:��6   $��Center=�6(   $��0��6E   6T   �� 5)      $��1��6   $
��30px��6v   $��270px��6�   $��0��6�   ��6$   �� *Mitarbeiters+ �� SelectedItem 6I   �� *SelectedMitarbeiter+��5*      �� 5+      .R�5,      ��  �� Orientation$ 
Horizontal=�6%   .+�5-      �� ��6(   �� *Name+6@   5.      5/      52      53      � 54   
   $��3��6    55      �� 56      $
��1.3* �6    60   �� 57      $��2* �6    6.   .+�59      �� $��	Password:��6   $��Center=�6(   6G   �� 5:      $ 
Horizontal=�6   $��1��62   $��Center=�6?   $��32,0,0,0q�6\   .+�5;      G� -   5         G�Name$ PasswortBox��5;   \   $��1��6   
�������$
��30px��6B   $	��267��6P   $��1��6q   5=      �� 5>      $��10,0,0,0q�6   $2��,pack://application:,,,/Resources/warning.png��6*   $��22��6`   y�6l   �� *
HasError+6�   5?      5@      �� 5A   
   $��2��6   $��4��6   $��Login��6+   $��100px��6;   $
��24px��6I   
���������6m   �� *LoginCommand+��6�   �� 	 �� ElementName$	 PasswortBox��6�   5B      5C      