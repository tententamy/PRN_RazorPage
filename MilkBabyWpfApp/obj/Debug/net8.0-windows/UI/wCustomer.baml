   M S B A M L   `   `   `  ����I  EMilkBabyWpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MilkBabyWpfApp.UIMilkBabyWpfApp.UI  5   	   !    MilkBabyWpfApp.UI.wCustomer   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MilkBabyWpfApp.UI     5   	     � Title$  	wCustomer��5   	   $	��450��6   $
��1000��6(   .��5	      � .+�5
   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $��Customer Form��6   $��10q�6.   .��5      �  � ColumnDefinitions 5      �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+    � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $��* �6(   .+�5!      �� -   5         ��Name$ txtCustomerID��5!   ;   $��0��6   $��0��6.   $y�	Collapsed=�6�   ��6R   ��  �� Path$ Customer.ID� �� Mode$ TwoWay=�6�   �� 5$      $��0��6   $��0��6,   $
��Name��69   $
��Left=�6H   $��Center=�6c   $��5q�6~   �� 5%      -   5        $ txtCustomerName��5%   ;   $��1��6   $��0��6.   $��25��6T   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6`   �� $ CustomerName�$ TwoWay=�6�   �� 5'      $��2��6   $��0��6,   $��Email��69   $
��Left=�6I   $��Center=�6d   $��5q�6   �� 5(      -   5        $ txtCustomerEmail��5(   ;   $��3��6   $��0��6.   $��25��6U   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6a   �� $ CustomerEmail�$ TwoWay=�6�   �� 5*      $��4��6   $��0��6,   $��Address��69   $
��Left=�6K   $��Center=�6f   $��5q�6�   �� 5+      -   5        $ txtCustomerAddress��5+   ;   $��5��6   $��0��6.   $��25��6W   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6c   �� $ CustomerAddress�$ TwoWay=�6�   �� 5.      $��0��6   $��1��6,   $��Phone��69   $
��Left=�6I   $��Center=�6d   $��5q�6   �� 5/      -   5        $ txtCustomerPhone��5/   ;   $��1��6   $��1��6.   $��25��6U   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6a   �� $ CustomerPhone�$ TwoWay=�6�   �� 51      $��2��6   $��1��6,   $	��Img��69   $
��Left=�6G   $��Center=�6b   $��5q�6}   �� 52      -   5        $ txtCustomerImg��52   ;   $��3��6   $��1��6.   $��25��6S   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6_   �� $ CustomerImg�$ TwoWay=�6�   �� 54      $��4��6   $��1��6,   $��Password��69   $
��Left=�6L   $��Center=�6g   $��5q�6�   �� 55      -   5        $ txtCustomerPassword��55   ;   $��5��6   $��1��6.   $��25��6X   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6d   �� $ CustomerPassword�$ TwoWay=�6�   �� 58      $��0��6   $��2��6,   $��
Birth Date��69   $
��Left=�6N   $��Center=�6i   $��5q�6�   (  "System.Windows.Controls.DatePicker  59      -   5          Name$ dpCustomerBirthDate��59   >   $��1��6!   $��2��61   $��5q�6�   $	��180��6�   $
��Left=�6�      SelectedDate 6[   �� $ CustomerBirthDate�$ TwoWay=�6�   �� 5;      $��2��6   $��2��6,   $��Gender��69   $
��Left=�6J   $��Center=�6e   $��5q�6�   �� 5<      -	   5        	 ��Name$	 cbCustomerGender��5<   <   $��3��6   $��2��6/   $��5q�6�   $	��180��6�   $
��Left=�6�   
 �� SelectedValue
 6V   �� $ CustomerGender�$ TwoWay=�.@�5=      �� $
��Male��6'   �� 5>      $��Female��6'   �� 5?      $��Other��6'   5@      �� 5B      $��4��6   $��2��6,   $��Status��69   $
��Left=�6J   $��Center=�6e   $��5q�6�   �� 5C      -
   5         ��Name$ chkCustomerStatus��5C   <   $��5��6   $��2��6/   $��5q�6�   $	��180��6�   $
��Left=�6�    d� 	IsChecked 6W   �� $ CustomerStatus�$ TwoWay=�6�   5D      5E      �� 5G      $��40��6   $ 
Horizontal=�6%   $��Right=�6>   .+�5H      �� -   5         ��Name$ 
ButtonSave��5H      $
��Save��6-   $��30��6<   $��80��6H   6S   �� 5I      -   5        $ ButtonCancel��5I      $��Cancel��6/   $��30��6@   $��80��6L   6W   5J      �� 5L      $	��210��6   .+�5M      &   System.Windows.Controls.DataGrid  -   5          Name$ grdCustomer��5M         AutoGenerateColumns$ False��60      CanUserAddRows$ False��6m   $	��200��6�   $��10q�6�      SelectionMode$ Single=�6�      SelectionUnit$ FullRow=�6�   ��6L   �� *
Customer+   Columns 5N      0  *System.Windows.Controls.DataGridTextColumn  5O      ,  &System.Windows.Controls.DataGridColumn   Header$
 Code��6-      
Visibility$ Visible=�6_   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� $ 
CustomerId�6_     5P      $
 Name��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6a      
IsReadOnly$
 True��6m    6;   �� $ CustomerName�6m     5Q      $ Email��6-   $	 100 6c   $
 True��6o    6<   �� $ CustomerEmail�6o     5R      $ Phone��6-   $	 100 6c   $
 True��6o    6<   �� $ CustomerPhone�6o     5S      $ Address��6-   $	 100 6g   $
 True��6s    6>   �� $ CustomerAddress�6s     5T      $ Image��6-   $	 100 6a   $
 True��6m    6<   �� $ CustomerImg�6m     5U      $ Password��6-   $	 100 6i   $
 True��6u    6?   �� $ CustomerPassword�6u     5V      $ 
Birth Date��6-   $	 100 6l   $
 True��6x    6A   �� $ CustomerBirthDate�6x     5W      $ Gender��6-   $	 100 6e   $
 True��6q    6=   �� $ CustomerGender�6q     5X      $ Create Date��6-   $	 100 6o   $
 True��6{    6B   �� $ CustomerCreatedDate�6{     5Y      $ Update Date��6-   $	 100 6o   $
 True��6{    6B   �� $ CustomerUpdatedDate�6{   4  .System.Windows.Controls.DataGridCheckBoxColumn  5Z      $ Status��61   $	 100 6i   $
 True��6u    6A   �� $ CustomerStatus�6u   4  .System.Windows.Controls.DataGridTemplateColumn  5[      $ 50 61      CellTemplate 5\      �� 5]   "   .R�5^   &   �� $ ButtonDelete��69   -   5        $��X��5^   -   ��6O   �� $ 
CustomerId�6|   5_   #   5a      5c      5d      5e      5f      5h      