   M S B A M L   `   `   `  ����I  EMilkBabyWpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MilkBabyWpfApp.UIMilkBabyWpfApp.UI  5   	       MilkBabyWpfApp.UI.wVendor   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MilkBabyWpfApp.UI     5   	     � Title$  wVendor��5   	   $	��450��6   $
��1400��6&   .��5	      � .+�5
   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $��Vendor Form��6   $��10q�6,   .��5      �  � ColumnDefinitions 5      �� 5      $
��Auto �6+   �� 5      $��* �6+   �� 5      $
��Auto �6+   �� 5      $��* �6+    � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   .+�5       �� -   5         ��Name$ txtVendorId��5    ;   $��0��6   $��0��6.   $y�	Collapsed=�6|   ��6P   ��  �� Path$ VendorId� �� Mode$ TwoWay=�6|   �� 5#      $��0��6   $��0��6,   $��Vendor Name��69   $
��Left=�6O   $��Center=�6j   $��5q�6�   �� 5$      -   5        $ txtVendorName��5$   ;   $��1��6   $��0��6.   $��25��6R   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6^   �� $ 
VendorName�$ TwoWay=�6�   �� 5&      $��2��6   $��0��6,   $��Contact Person��69   $
��Left=�6R   $��Center=�6m   $��5q�6�   �� 5'      -   5        $ txtVendorContactPerson��5'   ;   $��3��6   $��0��6.   $��25��6[   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6g   �� $ VendorContactPerson�$ TwoWay=�6�   �� 5*      $��0��6   $��1��6,   $��Vendor Address��69   $
��Left=�6R   $��Center=�6m   $��5q�6�   �� 5+      -   5        $ txtVendorAddress��5+   ;   $��1��6   $��1��6.   $��25��6U   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6a   �� $ VendorAddress�$ TwoWay=�6�   �� 5-      $��2��6   $��1��6,   $��Vendor Website��69   $
��Left=�6R   $��Center=�6m   $��5q�6�   �� 5.      -   5        $ txtVendorWebsite��5.   ;   $��3��6   $��1��6.   $��25��6U   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6a   �� $ VendorWebsite�$ TwoWay=�6�   �� 51      $��0��6   $��2��6,   $��Vendor Phone��69   $
��Left=�6P   $��Center=�6k   $��5q�6�   �� 52      -   5        $ txtVendorPhone��52   ;   $��1��6   $��2��6.   $��25��6S   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6_   �� $ VendorPhone�$ TwoWay=�6�   �� 54      $��2��6   $��2��6,   $��Vendor Status��69   $
��Left=�6Q   $��Center=�6l   $��5q�6�   �� 55      -   5         ��Name$ chkVendorStatus��55   <   $��3��6   $��2��6/   $
��Left=�6�   $��Center=�6�   $��5q�6�    d� 	IsChecked 6U   �� $ VendorStatus�$ TwoWay=�6�   �� 58      $��0��6   $��3��6,   $��Vendor Email��69   $
��Left=�6P   $��Center=�6k   $��5q�6�   �� 59      -   5        $ txtVendorEmail��59   ;   $��1��6   $��3��6.   $��25��6S   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6_   �� $ VendorEmail�$ TwoWay=�6�   �� 5;      $��2��6   $��3��6,   $��Created Date��69   $
��Left=�6P   $��Center=�6k   $��5q�6�   (  "System.Windows.Controls.DatePicker  5<      -	   5        	  Name$	 dpVendorCreatedDate��5<   >   $��3��6!   $��3��61   $��5q�6�   $
��Left=�6�   ${�False��6�   
   SelectedDate
 6[   �� $ VendorCreatedDate�$ TwoWay=�6�   �� 5>      $��2��6   $��4��6,   $��Updated Date��69   $
��Left=�6P   $��Center=�6k   $��5q�6�     5?      -
   5        $	 dpVendorUpdatedDate��5?   >   $��3��6!   $��4��61   $��5q�6�   $
��Left=�6�   ${�False��6�   
 6[   �� $ VendorUpdatedDate�$ TwoWay=�6�   �� 5B      $��0��6   $��4��6,   $��Vendor Note��69   $
��Left=�6O   $��Center=�6j   $��5q�6�   �� 5C      -   5        $ txtVendorNotes��5C   ;   $��1��6   $��4��6.   $��25��6S   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6_   �� $ VendorNotes�$ TwoWay=�6�   5F      5G      �� 5I      $��40��6   $ 
Horizontal=�6%   $��Right=�6>   .+�5J      �� -   5         ��Name$ ButtonSaveVendor��5J      $
��Save��63   $��30��6B   $��80��6N   6Y   �� 5K      -   5        $ ButtonCancelVendor��5K      $��Cancel��65   $��30��6F   $��80��6R   6]   5L      �� 5N      $	��210��6   .+�5O      &   System.Windows.Controls.DataGrid  -   5          Name$ 	grdVendor��5O         AutoGenerateColumns$ False��6.      CanUserAddRows$ False��6j   $	��200��6�   $��10q�6�      SelectionMode$ Single=�6�      SelectionUnit$ FullRow=�6�   ��6J   �� *	Vendors+   Columns 5P      0  *System.Windows.Controls.DataGridTextColumn  5R      ,  &System.Windows.Controls.DataGridColumn   Header$ Vendor Name��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6f      
IsReadOnly$
 True��6r   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� $ 
VendorName�6r     5S      $ Vendor Address��6-   $	 150 6l   $
 True��6x    6E   �� $ VendorAddress�6x     5T      $ Vendor Phone��6-   $	 100 6h   $
 True��6t    6C   �� $ VendorPhone�6t     5U      $ Vendor Email��6-   $	 150 6h   $
 True��6t    6C   �� $ VendorEmail�6t     5V      $ Vendor Contact Person��6-   $	 150 6y   $
 True��6�    6L   �� $ VendorContactPerson�6�     5W      $ Vendor Website��6-   $	 150 6l   $
 True��6x    6E   �� $ VendorWebsite�6x     5X      $ Vendor Status��6-   $	 100 6j   $
 True��6v    6D   �� $ VendorStatus�6v     5Y      $ Vendor Notes��6-   $	 150 6h   $
 True��6t    6C   �� $ VendorNotes�6t     5Z      $ Vendor CreatedDate��6-   $	 150 6t   $
 True��6�    6I   �� $ VendorCreatedDate�6�     5[      $ Vendor UpdatedDate��6-   $	 150 6t   $
 True��6�    6I   �� $ VendorUpdatedDate�6�   4  .System.Windows.Controls.DataGridTemplateColumn  5]      $ 50 61      CellTemplate 5^      �� 5_   "   .R�5`   &   �� $ ButtonDeleteVendor��69   -   5        $��X��5`   -   ��6U   �� $ VendorId�6�   5a   #   5c      5e      5f      5g      5h      5i      