   M S B A M L   `   `   `  ����I  EMilkBabyWpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MilkBabyWpfApp.UIMilkBabyWpfApp.UI  5   	       MilkBabyWpfApp.UI.wOrder   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MilkBabyWpfApp.UI     5   	     � Title$  wOrder��5   	   $	��450��6   $
��1200��6%   .��5	      � .+�5
   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $��
Order Form��6   $��10q�6+   .��5      �  � ColumnDefinitions 5      �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+    � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $��* �6(   .+�5      �� -   5         ��Name$ 
txtOrderID��5   ;   $��0��6   $��0��6.   $y�	Collapsed=�6z   ��6O   ��  �� Path$ OrderId� �� Mode$ TwoWay=�6z   �� 5!      $��0��6   $��0��6,   $��Customer ID��69   $
��Left=�6O   $��Center=�6j   $��5q�6�   �� 5"      -   5        $ txtOrderCustomerId��5"   ;   $��1��6   $��0��6.   $��25��6W   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6c   �� $ 
CustomerId�$ TwoWay=�6�   �� 5$      $��2��6   $��0��6,   $��
Order Date��69   $
��Left=�6N   $��Center=�6i   $��5q�6�   (  "System.Windows.Controls.DatePicker  5%      -   5          Name$ dpOrderDate��5%   >   $��3��6!   $��0��61   $��25��6S   $��5q�6�   $	��180��6�   $
��Left=�6�      SelectedDate 6_   �� $ 	OrderDate�$ TwoWay=�6�   �� 5(      $��0��6   $��1��6,   $��Total Amount��69   $
��Left=�6P   $��Center=�6k   $��5q�6�   �� 5)      -   5        $ txtTotalAmount��5)   ;   $��1��6   $��1��6.   $��25��6S   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6_   �� $ TotalAmount�$ TwoWay=�6�   �� 5+      $��2��6   $��1��6,   $��Voucher��69   $
��Left=�6K   $��Center=�6f   $��5q�6�   �� 5,      -   5        $ 
txtVoucher��5,   ;   $��3��6   $��1��6.   $��25��6O   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6[   �� $ Voucher�$ TwoWay=�6�   �� 5/      $��0��6   $��2��6,   $��Order Status��69   $
��Left=�6P   $��Center=�6k   $��5q�6�   �� 50      -   5        $ txtOrderStatus��50   ;   $��1��6   $��2��6.   $��25��6S   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6_   �� $ OrderStatus�$ TwoWay=�6�   �� 52      $��2��6   $��2��6,   $��Shipping Address��69   $
��Left=�6T   $��Center=�6o   $��5q�6�   �� 53      -   5        $ txtOrderShippingAddress��53   ;   $��3��6   $��2��6.   $��25��6\   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6h   �� $ OrderShippingAddress�$ TwoWay=�6�   �� 56      $��0��6   $��3��6,   $��Billing Address��69   $
��Left=�6S   $��Center=�6n   $��5q�6�   �� 57      -   5        $ txtOrderBillingAddress��57   ;   $��1��6   $��3��6.   $��25��6[   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6g   �� $ OrderBillingAddress�$ TwoWay=�6�   �� 59      $��2��6   $��3��6,   $��Payment Method��69   $
��Left=�6R   $��Center=�6m   $��5q�6�   �� 5:      -	   5        $ txtOrderPaymentMethod��5:   ;   $��3��6   $��3��6.   $��25��6Z   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6f   �� $ OrderPaymentMethod�$ TwoWay=�6�   �� 5=      $��0��6   $��4��6,   $��Shipping Method��69   $
��Left=�6S   $��Center=�6n   $��5q�6�   �� 5>      -
   5        $ txtOrderShippingMethod��5>   ;   $��1��6   $��4��6.   $��25��6[   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6g   �� $ OrderShippingMethod�$ TwoWay=�6�   �� 5@      $��2��6   $��4��6,   $��Tracking Number��69   $
��Left=�6S   $��Center=�6n   $��5q�6�   �� 5A      -   5        $ txtOrderTrackingNumber��5A   ;   $��3��6   $��4��6.   $��25��6[   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6g   �� $ OrderTrackingNumber�$ TwoWay=�6�   5B      5C      �� 5E      $��40��6   $ 
Horizontal=�6%   $��Right=�6>   .+�5F      �� -   5        	 ��Name$	 ButtonSaveOrder��5F      $
��Save��62   $��30��6A   $��80��6M   6X   �� 5G      -   5        $	 ButtonCancelOrder��5G      $��Cancel��64   $��30��6E   $��80��6Q   6\   5H      �� 5J      $	��210��6   .+�5K      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 grdOrder��5K         AutoGenerateColumns$ False��6-      CanUserAddRows$ False��6h   $	��200��6   $��10q�6�      SelectionMode$ Single=�6�      SelectionUnit$ FullRow=�6�   ��6I   �� *Orders+   Columns 5L      0  *System.Windows.Controls.DataGridTextColumn  5M      ,  &System.Windows.Controls.DataGridColumn   Header$ Order ID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6`      
IsReadOnly$
 True��6l   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� $ OrderId�6l     5N      $ Customer ID��6-   $	 100 6f   $
 True��6r    6B   �� $ 
CustomerId�6r     5O      $ 
Order Date��6-   $	 100 6d   $
 True��6p    6A   �� $ 	OrderDate�6p     5P      $ Total Amount��6-   $	 100 6h   $
 True��6t    6C   �� $ TotalAmount�6t     5Q      $ Voucher��6-   $	 100 6_   $
 True��6k    6>   �� $ Voucher�6k     5R      $ Order Status��6-   $	 100 6h   $
 True��6t    6C   �� $ OrderStatus�6t     5S      $ Shipping Address��6-   $	 100 6u   $
 True��6�    6G   �� $ OrderShippingAddress�6�     5T      $ Billing Address��6-   $	 100 6s   $
 True��6    6F   �� $ OrderBillingAddress�6     5U      $ Payment Method��6-   $	 100 6q   $
 True��6}    6E   �� $ OrderPaymentMethod�6}     5V      $ Shipping Method��6-   $	 100 6s   $
 True��6    6F   �� $ OrderShippingMethod�6     5W      $ Tracking Number��6-   $	 100 6s   $
 True��6    6F   �� $ OrderTrackingNumber�6   4  .System.Windows.Controls.DataGridTemplateColumn  5X      $ 50 61      CellTemplate 5Y      �� 5Z   "   .R�5[   &   �� $	 ButtonDeleteOrder��69   -   5        $��X��5[   -   ��6T   �� $ OrderId�6~   5\   #   5^      5`      5a      5b      5c      5e      