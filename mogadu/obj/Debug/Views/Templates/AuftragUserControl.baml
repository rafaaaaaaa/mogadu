   M S B A M L   `   `   `  ����A  =mogadu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:mogadu.Views.Templatesmogadu.Views.Templates  5      +    %mogadu.Views.Suche.AuftragUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:mogadu.Views.Templates     5      H DMahApps.Metro, Version=1.6.0.0, Culture=neutral, PublicKeyToken=null6mah,http://metro.mahapps.com/winfx/xaml/controls  5        � 	Resources  5
       �� MergedDictionaries �� Source�� 5       5      �� 5   
   $I Cpack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml?�6   �� 5   
   $F @pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml?�6   �� 5   
   $G Apack://application:,,,/MahApps.Metro;component/Styles/Colors.xaml?�6   �� 5   
   $M Gpack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml?�6   �� 5   
   $R Lpack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml?�6   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��* �6   6)   .+�5   
   �� $��	Aufträge��6   $��0��6$   ��5      �� 5      .�5      ��  �� Property � �� �� Value$ 20(�6;   �� 5        � �� �#5c616b6O   5!      5#      &   System.Windows.Controls.DataGrid  5$   
      
IsReadOnly .    AutoGenerateColumns .  $��1��6c   ��6   �� *	Auftraege+   Columns 5%      4  .System.Windows.Controls.DataGridTemplateColumn  5&      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Bezeichnung��6)   
   CellTemplate
 5'      �� 5(      .R�5)      �� $��5q�6%    � Cursor$
 Hand��6P   $��1��6^   ��60   �� *Auftragname+��5*   '   ��  �� RelativeSource ��  �� AncestorType" >� �� Mode$ FindAncestor=� �� Path$* $DataContext.NavigateToAuftragCommand���5+      �� *	AuftragId+��5,   "   �� 5-   &    �� 
TargetType" ��66   .R�5.   *   �� $��	Underline{�64   �� 5/      50   +   51   '   ��53   "   �� 54   &    �� 
TargetType" ��6,   .�55   *   ��  � ��
 ��� �6G    �� Triggers 57   *   P� 58   .    P� Property �@J�IsMouseOver P� Value . . �59   2   ��  � ��
 ��ح�6O   5:   /   5<   '   5>      5?      5A        5H      $
	 Team��6)   
 5I      �� 5J      .R�5K      �� $��5q�6%   $
 Hand��6Y   $��1��6g   ��60   �� *Team.Teambezeichnung+��5L   '   ��  �� " >�$ FindAncestor=�$' !DataContext.NavigateToTeamCommand���5M      �� *Team.TeamId+��5N   "   �� 5O   &   " ��66   .R�5P   *   �� $��	Underline{�64   �� 5Q      5R   +   5S   '   ��5U   "   �� 5V   &   " ��6,   .�5W   *   ��  � ��
 ��� �6G    5Y   *   P� 5Z   .    �@J�IsMouseOver . . �5[   2   ��  � ��
 ��ح�6O   5\   /   5^   '   5`      5a      5c      0  *System.Windows.Controls.DataGridTextColumn  5d      $	 Erledigte Aufgaben��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *ErledigteAufgaben+  5e      $	 Offene Aufgaben��6%    6>   �� *OffeneAufgaben+  5g      $	 Erledigte Aufgaben��6)   
 5h      �� 5i      .R�5j      �� $��5q�6%   $
 Hand��6V   $��1��6d   ��60   �� *ErledigteAufgaben+��5k   '   ��  �� " >�$ FindAncestor=�$' !DataContext.NavigateToTeamCommand���5l      �� *
AuftragIdd+��5m   "   �� 5n   &   " ��66   .R�5o   *   �� $��	Underline{�64   �� 5p      5q   +   5r   '   ��5t   "   �� 5u   &   " ��6,   .�5v   *   ��  � ��
 ��� �6G    5x   *   P� 5y   .    �@J�IsMouseOver . . �5z   2   ��  � ��
 ��ح�6O   5{   /   5}   '   5      5�      5�        5�      $	 
Priorität��6%    68   �� *
Priorität+  5�      $	 Erstelldatum��6%    6;   �� *ErstellDatum+ �� StringFormat$ {0:dd.MM.yyyy}��4  .System.Windows.Controls.DataGridCheckBoxColumn  5�         MetroDataGridCheckBox   ElementStyle# �   6)      EditingElementStyle# �   5�   )   $	 Abgeschlossen��5�   )    5�   )   ��  �� $ DataGridRowL�$ Abgeschlossen� �� Mode$ OneWay=�6�   5�      5�      5�      