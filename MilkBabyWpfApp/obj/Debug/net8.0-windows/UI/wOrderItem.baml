   M S B A M L   `   `   `  ����I  EMilkBabyWpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MilkBabyWpfApp.UIMilkBabyWpfApp.UI  5   	   "    MilkBabyWpfApp.UI.wOrderItem   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MilkBabyWpfApp.UI     5   	     � Title$  
wOrderItem��5   	   $	��450��6   $
��1200��6)   .��5	      � .+�5
   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $��Order Item Form��6   $��10q�60   .��5      �  � ColumnDefinitions 5      �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+    � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $��* �6(   .+�5      �� -   5         ��Name$ txtOrderItemId��5   ;   $��0��6   $��0��6.   $y�	Collapsed=�6�   ��6S   ��  �� Path$ OrderItemId� �� Mode$ TwoWay=�6�   �� 5!      $��0��6   $��0��6,   $��Order ID��69   $
��Left=�6L   $��Center=�6g   $��5q�6�   �� 5"      -   5        $ 
txtOrderId��5"   ;   $��1��6   $��0��6.   $��25��6O   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6[   �� $ OrderId�$ TwoWay=�6�   �� 5$      $��2��6   $��0��6,   $��
Product ID��69   $
��Left=�6N   $��Center=�6i   $��5q�6�   �� 5%      -   5        $ txtProductId��5%   ;   $��3��6   $��0��6.   $��25��6Q   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6]   �� $ 	ProductId�$ TwoWay=�6�   �� 5(      $��0��6   $��1��6,   $��Quantity��69   $
��Left=�6L   $��Center=�6g   $��5q�6�   �� 5)      -   5        $ txtQuantity��5)   ;   $��1��6   $��1��6.   $��25��6P   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6\   �� $ Quantity�$ TwoWay=�6�   �� 5+      $��2��6   $��1��6,   $��Price��69   $
��Left=�6I   $��Center=�6d   $��5q�6   �� 5,      -   5        $ txtPrice��5,   ;   $��3��6   $��1��6.   $��25��6M   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6Y   �� $ Price�$ TwoWay=�6�   �� 5/      $��0��6   $��2��6,   $��Discount��69   $
��Left=�6L   $��Center=�6g   $��5q�6�   �� 50      -   5        $ txtDiscount��50   ;   $��1��6   $��2��6.   $��25��6P   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6\   �� $ Discount�$ TwoWay=�6�   �� 52      $��2��6   $��2��6,   $	��Tax��69   $
��Left=�6G   $��Center=�6b   $��5q�6}   �� 53      -   5        $ txtTax��53   ;   $��3��6   $��2��6.   $��25��6K   $��5q�6~   $	��180��6�   $
��Left=�6�   ��6W   �� $	 Tax�$ TwoWay=�6�   �� 56      $��0��6   $��3��6,   $��Total Price��69   $
��Left=�6O   $��Center=�6j   $��5q�6�   �� 57      -   5        $ txtTotalPrice��57   ;   $��1��6   $��3��6.   $��25��6R   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6^   �� $ 
TotalPrice�$ TwoWay=�6�   �� 5:      $��0��6   $��4��6,   $��Created Date��69   $
��Left=�6P   $��Center=�6k   $��5q�6�   �� 5;      -	   5        $ txtCreatedDate��5;   ;   $��1��6   $��4��6.   $��25��6S   $��5q�6�   $	��180��6�   $
��Left=�6�    �� 
IsReadOnly$
 True��6�   ��6_   �� $ OrderItemCreatedDate�$ TwoWay=�6�   �� 5=      $��2��6   $��4��6,   $��Updated Date��69   $
��Left=�6P   $��Center=�6k   $��5q�6�   �� 5>      -
   5        $ txtUpdatedDate��5>   ;   $��3��6   $��4��6.   $��25��6S   $��5q�6�   $	��180��6�   $
��Left=�6�   $
 True��6�   ��6_   �� $ OrderItemUpdatedDate�$ TwoWay=�6�   5?      5@      �� 5B      $��40��6   $ 
Horizontal=�6%   $��Right=�6>   .+�5C      �� -   5         ��Name$ ButtonSaveOrderItem��5C      $
��Save��66   $��30��6E   $��80��6Q   6\   �� 5D      -   5        $ ButtonCancelOrderItem��5D      $��Cancel��68   $��30��6I   $��80��6U   6`   5E      �� 5G      $	��210��6   .+�5H      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 grdOrderItem��5H      
   AutoGenerateColumns$
 False��61      CanUserAddRows$ False��6p   $	��200��6�   $��10q�6�      SelectionMode$ Single=�6�      SelectionUnit$ FullRow=�6�   ��6M   �� *
OrderItems+   Columns 5I      0  *System.Windows.Controls.DataGridTextColumn  5J      ,  &System.Windows.Controls.DataGridColumn   Header$ Order Item ID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6i      
IsReadOnly$
 True��6u   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   �� $ OrderItemId�6u     5K      $ Order ID��6-   $	 100 6`   $
 True��6l    6?   �� $ OrderId�6l     5L      $ 
Product ID��6-   $	 100 6d   $
 True��6p    6A   �� $ 	ProductId�6p     5M      $ Quantity��6-   $	 100 6a   $
 True��6m    6?   �� $ Quantity�6m     5N      $ Price��6-   $	 100 6[   $
 True��6g    6<   �� $ Price�6g     5O      $ Discount��6-   $	 100 6a   $
 True��6m    6?   �� $ Discount�6m     5P      $	 Tax��6-   $	 100 6W   $
 True��6c    6:   �� $	 Tax�6c     5Q      $ Total Price��6-   $	 100 6f   $
 True��6r    6B   �� $ 
TotalPrice�6r     5R      $ Created Date��6-   $	 100 6q   $
 True��6}    6C   �� $ OrderItemCreatedDate�6}     5S      $ Updated Date��6-   $	 100 6q   $
 True��6}    6C   �� $ OrderItemUpdatedDate�6}   4  .System.Windows.Controls.DataGridTemplateColumn  5T      $ 50 61      CellTemplate 5U      �� 5V   "   .R�5W   &   �� $ ButtonDeleteOrderItem��69   -   5        $��X��5W   -   ��6X   �� $ OrderItemId�6�   5X   #   5Z      5\      5]      5^      5_      5a      