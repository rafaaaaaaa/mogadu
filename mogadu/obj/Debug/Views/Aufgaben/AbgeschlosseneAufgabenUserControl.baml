   M S B A M L   `   `   `  ����A  =mogadu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:mogadu.Views.Aufgabenmogadu.Views.Aufgaben  5      =    7mogadu.Views.Aufgaben.AbgeschlosseneAufgabenUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:mogadu.Views.Aufgaben     5      .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid      
IsReadOnly  .    AutoGenerateColumns .  ��6   �� *
Aufgaben+   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Bezeichnung��6)      CellTemplate 5      �� 5      .R�5      �� $��5q�6%    � Cursor$
 Hand��6Q   $��1��6_   ��60   �� *Aufgabenname+��5   '   ��  �� RelativeSource ��  �� AncestorType" >� �� Mode$ FindAncestor=�	 �� Path$0	 *DataContext.NavigateToAufgabeDetailCommand���5      �� *
AufgabenId+��5   "   �� 5   &   
 �� 
TargetType"
 ��66   .R�5   *   �� $��	Underline{�64   �� 5      5   +   5   '   ��5   "   �� 5   &    �� 
TargetType" ��6,   .�5   *   ��  �� Property � �� �� Value
 ��� �6G    �� Triggers 5   *   P� 5   .    P� Property �@J�IsMouseOver P� Value . . �5   2   ��  � ��
 ��ح�6O   5    /   5"   '   5$      5%      5'      0  *System.Windows.Controls.DataGridTextColumn  5)      $ Beschreibung��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Aufgabenbeschreibung+  5+      $ Bezeichnung��6)    5,      �� 5-      .R�5.      �� $��5q�6%   $
 Hand��6Y   $��1��6g   ��60   �� *Mitarbeiter.FullName+��5/   '   ��  �� " >�$ FindAncestor=�$.	 (DataContext.NavigateToMitarbeiterCommand���50      �� *Mitarbeiter.MitarbeiterId+��51   "   �� 52   &   "
 ��66   .R�53   *   �� $��	Underline{�64   �� 54      55   +   56   '   ��58   "   �� 59   &   " ��6,   .�5:   *   ��  � ��
 ��� �6G    5<   *   P� 5=   .    �@J�IsMouseOver . . �5>   2   ��  � ��
 ��ح�6O   5?   /   5A   '   5C      5D      5F        5I      $ Erledigte Aufgaben��6)    5J      �� 5K      .R�5L      �� $��5q�6%   $
 Hand��6V   $��1��6d   ��60   �� *ErledigteAufgaben+��5M   '   ��  �� " >�$ FindAncestor=�$'	 !DataContext.NavigateToTeamCommand���5N      �� *
AuftragIdd+��5O   "   �� 5P   &   "
 ��66   .R�5Q   *   �� $��	Underline{�64   �� 5R      5S   +   5T   '   ��5V   "   �� 5W   &   " ��6,   .�5X   *   ��  � ��
 ��� �6G    5Z   *   P� 5[   .    �@J�IsMouseOver . . �5\   2   ��  � ��
 ��ح�6O   5]   /   5_   '   5a      5b      5d      5f      5g      5h      