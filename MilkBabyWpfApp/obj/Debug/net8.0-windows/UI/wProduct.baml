   M S B A M L   `   `   `  ����I  EMilkBabyWpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MilkBabyWpfApp.UIMilkBabyWpfApp.UI  5   	        MilkBabyWpfApp.UI.wProduct   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MilkBabyWpfApp.UI     5   	     � Title$  wProduct��5   	   $	��700��6   $
��1200��6'   .��5
      � .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $��Product Form��6   $��10q�6-   $	��250��69   .��5      �  � RowDefinitions 5      �� 5      $��1* �6(   �� 5      $��1* �6(   �� 5      $��1* �6(   �� 5      $��1* �6(   �� 5      $��1* �6(    � ColumnDefinitions 5      �� 5      $	��100 �6+   �� 5      $	��200 �6+   �� 5      $	��100 �6+   �� 5      $	��200 �6+   �� 5      $	��100 �6+   �� 5      $	��200 �6+   �� 5      $	��100 �6+   �� 5      $��* �6+   .+�5!      �� $��0��6   $��0��6,   $��Id��69   $
��Left=�6F   $��Center=�6a   �� 5"      -   5         ��Name$ txtProductId��5"   ;   $��1��6   $��0��6.   $��25��6Q   ${�False��6]   $��5q�6o   $
��Left=�6z   $	��180��6�   �� 5#      $��2��6   $��0��6,   $
��Name��69   $
��Left=�6H   $��Center=�6c   �� 5$      -   5        $ txtName��5$   ;   $��0��6   $��3��6+   $��25��6L   $��5q�6�   $
��Left=�6�   $	��180��6�   ��6X   ��  �� Path$ Product.ProductName� �� Mode$ TwoWay=�6�   �� 5%      $��4��6   $��0��6,   $��Category��69   $
��Left=�6L   $��Center=�6g   �� 5&      -   5        $ txtCategory��5&   ;   $��5��6   $��0��6.   $��25��6P   $��5q�6�   $
��Left=�6�   $	��180��6�   ��6\   �� $ Product.ProductCategory�$ TwoWay=�6�   �� 5)      $��0��6   $��1��6,   $��Price��69   $
��Left=�6I   $��Center=�6d   �� 5*      -   5        $ txtPrice��5*   ;   $��1��6   $��1��6.   $��25��6M   $��5q�6�   $
��Left=�6�   $	��180��6�   ��6Y   �� $ Product.ProductPrice�$ TwoWay=�6�   �� 5+      $��2��6   $��1��6,   $��Quantity��69   $
��Left=�6L   $��Center=�6g   �� 5,      -   5        $ txtQuantity��5,   ;   $��3��6   $��1��6.   $��25��6P   $��5q�6�   $
��Left=�6�   $	��180��6�   ��6\   �� $ Product.ProductQuantity�$ TwoWay=�6�   �� 5-      $��4��6   $��1��6,   $��Weight��69   $
��Left=�6J   $��Center=�6e   �� 5.      -   5        $ 	txtWeight��5.   ;   $��5��6   $��1��6.   $��25��6N   $��5q�6�   $
��Left=�6�   $	��180��6�   ��6Z   �� $ Product.ProductWeight�$ TwoWay=�6�   �� 51      $��0��6   $��2��6,   $��
Date Start��69   $
��Left=�6N   $��Center=�6i   (  "System.Windows.Controls.DatePicker  52      -   5          Name$ dpDateStart��52   >   $��1��6!   $��2��61   $��5q�6�   $
��Left=�6�   $	��180��6�      SelectedDate 6S   �� $ Product.ProductDateStart�$ TwoWay=�6�   �� 53      $��2��6   $��2��6,   $��Date End��69   $
��Left=�6L   $��Center=�6g     54      -   5        $ 	dpDateEnd��54   >   $��3��6!   $��2��61   $��5q�6�   $
��Left=�6�   $	��180��6�    6Q   �� $ Product.ProductDateEnd�$ TwoWay=�6�   �� 55      $��4��6   $��2��6,   $��
Dimensions��69   $
��Left=�6N   $��Center=�6i   �� 56      -	   5        $ txtDimensions��56   ;   $��5��6   $��2��6.   $��25��6R   $��5q�6�   $
��Left=�6�   $	��180��6�   ��6^   �� $ Product.ProductDimensions�$ TwoWay=�6�   �� 59      $��0��6   $��3��6,   $��Status��69   $
��Left=�6J   $��Center=�6e   �� 5:      -
   5        	 ��Name$	 	chkStatus��5:   <   $��1��6   $��3��6/   $��Center=�6�   $��5q�6�   
 d� 	IsChecked
 6O   �� $ Product.ProductStatus�$ TwoWay=�6�   �� 5;      $��2��6   $��3��6,   $��	Image URL��69   $
��Left=�6M   $��Center=�6h   �� 5<      -   5        $ txtImageUrl��5<   O   $��3��6   $��3��6.   $��3��6;   $��25��6d   $��5q�6�   $��Stretch=�6�   ��6p   �� $ Product.ProductImg�$ TwoWay=�6�   �� 5?      $��0��6   $��4��6,   $��Description��69   $
��Left=�6O   $��Center=�6j   �� 5@      -   5        $ txtDescription��5@   O   $��1��6   $��4��6.   $��5��6;   $��25��6g   $��5q�6�   $��Stretch=�6�   ��6s   �� $  Product.ProductDescription�$ TwoWay=�6�   5A      5B      �� 5D      $��40��6   $ 
Horizontal=�6%   $��Right=�6>   .+�5E      �� -   5         ��Name$ 
ButtonSave��5E      $
��Save��6-   $��30��6<   $��80��6H   $��5q�6S   6^   �� 5F      -   5        $ ButtonCancel��5F      $��Cancel��6/   $��30��6@   $��80��6L   $��5q�6W   6b   5G      &   System.Windows.Controls.DataGrid  5I      -   5          Name$ 
grdProduct��5I         AutoGenerateColumns$ False��6+      CanUserAddRows$ False��6g   $	��300��6~   $��10q�6�      SelectionMode$ Single=�6�      SelectionUnit$ FullRow=�6�   ��6G   �� *	Product+   Columns 5J      0  *System.Windows.Controls.DataGridTextColumn  5K      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� $ ProductName�6\     5L      $ Category��6)   $	 100 6d    6;   �� $ ProductCategory�6d     5M      $ Price��6)   $ 80 6^    68   �� $ ProductPrice�6^     5N      $ Quantity��6)   $ 80 6d    6;   �� $ ProductQuantity�6d     5O      $ Weight��6)   $ 80 6`    69   �� $ ProductWeight�6`     5P      $ 
Dimensions��6)   $	 100 6h    6=   �� $ ProductDimensions�6h     5Q      $ 
Date Start��6)   $	 100 6g    6=   �� $ ProductDateStart�6g     5R      $ Date End��6)   $	 100 6c    6;   �� $ ProductDateEnd�6c   4  .System.Windows.Controls.DataGridCheckBoxColumn  5S      $ Status��6-   $ 60 6d    6=   �� $ ProductStatus�6d     5T      $ Description��6)   $	 150 6j    6>   �� $ ProductDescription�6j     5U      $ Image��6)   $	 120 6\    68   �� $ 
ProductImg�6\   4  .System.Windows.Controls.DataGridTemplateColumn  5V      $ 50 6-      CellTemplate 5W      �� 5X      .R�5Y   "   �� $ ButtonDelete��65   -   5        $��X��5Y   )   ��6K   �� $ 	ProductId�6w   5Z      5\      5^      5_      5`      5a      