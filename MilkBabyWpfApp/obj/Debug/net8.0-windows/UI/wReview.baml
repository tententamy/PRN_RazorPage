   M S B A M L   `   `   `  ����I  EMilkBabyWpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MilkBabyWpfApp.UIMilkBabyWpfApp.UI  5   	       MilkBabyWpfApp.UI.wReview   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MilkBabyWpfApp.UI     5   	     � Title$  wReview��5   	   $	��600��6   $
��1200��6&   .��5	      � .+�5
   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $��Review Form��6   $��10q�6,   .��5      �  � ColumnDefinitions 5      �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+    � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $��* �6(   .+�5      �� -   5         ��Name$ txtReviewId��5   ;   $��0��6   $��0��6.   $y�	Collapsed=�6|   ��6P   ��  �� Path$ ReviewId� �� Mode$ TwoWay=�6|   �� 5!      $��0��6   $��0��6,   $��Product��69   $
��Left=�6K   $��Center=�6f   $��5q�6�   �� 5"      -   5         ��Name$ 	cbProduct��5"   <   $��1��6   $��0��6/    �� DisplayMemberPath$ ProductName��6p   	 �� SelectedValuePath$	 	ProductId��6�   $	��180��6�   $
��Left=�6�   $��5q�6�   ��6O   �� *
Products+6�   �� 5$      $��2��6   $��0��6,   $��Customer��69   $
��Left=�6L   $��Center=�6g   $��5q�6�   �� 5%      -   5        $ 
cbCustomer��5%   <   $��3��6   $��0��6/   $ CustomerName��6r   $	 
CustomerId��6�   $	��180��6�   $
��Left=�6�   $��5q�6�   ��6P   �� *	Customers+6�   �� 5(      $��0��6   $��1��6,   $��Rating��69   $
��Left=�6J   $��Center=�6e   $��5q�6�   �� 5)      -   5        $ 	txtRating��5)   ;   $��1��6   $��1��6.   $��25��6N   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6Z   �� $ Rating�$ TwoWay=�6�   �� 5+      $��2��6   $��1��6,   $��Review Text��69   $
��Left=�6O   $��Center=�6j   $��5q�6�   �� 5,      -   5        $ txtReviewText��5,   ;   $��3��6   $��1��6.   $��25��6R   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6^   �� $ 
ReviewText�$ TwoWay=�6�   �� 5/      $��0��6   $��2��6,   $��Review Image��69   $
��Left=�6P   $��Center=�6k   $��5q�6�   �� 50      -   5        $ txtReviewImage��50   ;   $��1��6   $��2��6.   $��25��6S   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6_   �� $ 	ReviewImg�$ TwoWay=�6�   �� 52      $��2��6   $��2��6,   $��Review Title��69   $
��Left=�6P   $��Center=�6k   $��5q�6�   �� 53      -   5        $ txtReviewTitle��53   ;   $��3��6   $��2��6.   $��25��6S   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6_   �� $ ReviewTitle�$ TwoWay=�6�   �� 56      $��0��6   $��3��6,   $��Helpful Count��69   $
��Left=�6Q   $��Center=�6l   $��5q�6�   �� 57      -   5        $ txtReviewHelpfulCount��57   ;   $��1��6   $��3��6.   $��25��6Z   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6f   �� $ ReviewHelpfulCount�$ TwoWay=�6�   �� 59      $��2��6   $��3��6,   $��Not Helpful Count��69   $
��Left=�6U   $��Center=�6p   $��5q�6�   �� 5:      -	   5        $ txtReviewNotHelpfulCount��5:   ;   $��3��6   $��3��6.   $��25��6]   $��5q�6�   $	��180��6�   $
��Left=�6�   ��6i   �� $ ReviewNotHelpfulCount�$ TwoWay=�6�   �� 5=      $��0��6   $��4��6,   $��Created Date��69   $
��Left=�6P   $��Center=�6k   $��5q�6�   (  "System.Windows.Controls.DatePicker  5>      -
   5        
  Name$
 dpReviewCreatedDate��5>   >   $��1��6!   $��4��61   $��5q�6�   $	��180��6�   $
��Left=�6�   ${�False��6�      SelectedDate 6[   �� $ ReviewCreatedDate�$ TwoWay=�6�   �� 5@      $��2��6   $��4��6,   $��Updated Date��69   $
��Left=�6P   $��Center=�6k   $��5q�6�     5A      -   5        $
 dpReviewUpdatedDate��5A   >   $��3��6!   $��4��61   $��5q�6�   $	��180��6�   $
��Left=�6�   ${�False��6�    6[   �� $ ReviewUpdatedDate�$ TwoWay=�6�   5B      5C      �� 5E      $��40��6   $ 
Horizontal=�6%   $��Right=�6>   .+�5F      �� -   5         ��Name$ ButtonSaveReview��5F      $
��Save��63   $��30��6B   $��80��6N   6Y   �� 5G      -   5        $ ButtonCancelReview��5G      $��Cancel��65   $��30��6F   $��80��6R   6]   5H      �� 5J      $	��210��6   .+�5K      &   System.Windows.Controls.DataGrid  -   5          Name$ 	grdReview��5K         AutoGenerateColumns$ False��6.      CanUserAddRows$ False��6j   $	��200��6�   $��10q�6�      SelectionMode$ Single=�6�      SelectionUnit$ FullRow=�6�   ��6J   �� *	Reviews+   Columns 5L      0  *System.Windows.Controls.DataGridTextColumn  5M      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Review ID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6b      
IsReadOnly$
 True��6n   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� $ ReviewId�6n     5N      $ 
Product ID��6-   $	 100 6d   $
 True��6p    6A   �� $ 	ProductId�6p     5O      $ Customer ID��6-   $	 100 6f   $
 True��6r    6B   �� $ 
CustomerId�6r     5P      $ Rating��6-   $	 100 6]   $
 True��6i    6=   �� $ Rating�6i     5Q      $ Review Text��6-   $	 100 6f   $
 True��6r    6B   �� $ 
ReviewText�6r     5R      $ Review Image��6-   $	 100 6f   $
 True��6r    6C   �� $ 	ReviewImg�6r     5S      $ Review Title��6-   $	 100 6h   $
 True��6t    6C   �� $ ReviewTitle�6t     5T      $ Helpful Count��6-   $	 100 6p   $
 True��6|    6D   �� $ ReviewHelpfulCount�6|     5U      $ Not Helpful Count��6-   $	 100 6w   $
 True��6�    6H   �� $ ReviewNotHelpfulCount�6�     5V      $ Created Date��6-   $	 100 6n   $
 True��6z    6C   �� $ ReviewCreatedDate�6z     5W      $ Updated Date��6-   $	 100 6n   $
 True��6z    6C   �� $ ReviewUpdatedDate�6z   4  .System.Windows.Controls.DataGridTemplateColumn  5Y      $ 50 61      CellTemplate 5Z      �� 5[   "   .R�5\   &   �� -   5        $��X��5\   -   69   5]   #   5_      5b      5c      5d      5e      5f      