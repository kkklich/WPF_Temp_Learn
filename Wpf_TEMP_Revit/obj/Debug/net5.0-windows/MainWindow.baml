   M S B A M L   `   `   `  ����I  EWpf_TEMP_Revit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Wpf_TEMP_RevitWpf_TEMP_Revit  5   	       Wpf_TEMP_Revit.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Wpf_TEMP_Revit     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5
      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $
��1.5* �6   �� 5      $
��1.5* �6   �� 5      $
��1.5* �6   �� 5      $
��1.5* �6   �� 5      $
��1.5* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $
��2.5* �6   .+�5   
   �� $��Tytul��6   �� 5      $�:��6    �� 5      
�������$�asdfasdf��62   5       �� 5"   
   $��Pole 1��6   $��0��6"   $��1��62   �� 5#      $�:��6   5$      �� 5%   
   -   5         ��Name$ 	cmb_Pole1��5%       �� DisplayMemberPath$
 Name��6D   $��1��6`   $��1��6p   ��6&   �� *Lista+6}   �� 5(   
   $��pole 2��6   $��0��6"   $��2��62   �� 5)      $�:��6   5*      �� 5+   
   -   5        $ 	cmb_Pole2��5+      $��1��6'   $��2��67   .@�5,      �� $��Green��6   �� 5-      $��Yellow��6   �� 5.      $��Orange��6   5/      �� 51   
   $��Text 1��6   $��0��6"   $��3��62   �� 52      $�:��6   53      �� 54   
   -   5        $ 	cmb_Pole3��54      $ SureName��6K   $��1��6�   $��3��6�   ��6&   �� *
ListPerson+ �� SelectedItem 6i   �� *SelectedPerson+6�   �� 56   
   $��20(�62   $��0��6@   $��5��6P   ��6   �� *TimeClockNow+�� 57      $�:��6   58      � 5:   
   $��6��6   $��4��6   $��2��6/   .+�5;      &   System.Windows.Controls.DataGrid  -   5          Name$ NbpdataGrid��5;      ��6-   �� *	RatesList+5<      �� 5>   
   -   5        $��Button��5>      $��1��6]   $��10��6m   {�6"   �� *ButtonUseEnabled+6m   (  "System.Windows.Controls.DatePicker  5?   
   -   5          Name$ DataPickerNbp��5?      $��1��6,   $
��Left=�6�   $��
179,10,0,0q�6�   $��5��6�   $	��Top=�6�      DisplayDate 6=   �� *	DateNow+	   SelectedDate	 6^   �� *SelectedDate+6�   5@      5A      