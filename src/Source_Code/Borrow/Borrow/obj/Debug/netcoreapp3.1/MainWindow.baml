   M S B A M L   `   `   `  ����A  =Borrow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BorrowBorrow  5   	       Borrow.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Borrow     5   	     � Title$  Borrow a Book��5   	   $	��800��6   $	��800��6,   .��5	      � -   5         �Name$ bookGrid��5	      .+�5
   
   �� -   5         ��Name$ bookIDLabel��5
      $��Book ID��5      $
��Left=�5      $��	41,28,0,0q�5      $	��Top=�5      �� 5   
   -   5         ��Name$ bookIDTextBox��5      $
��Left=�5      $��
105,33,0,0q�5      $�� ��6&    �� TextWrapping$
 Wrap=�5      $	��Top=�5      $	��120��5      �� 5   
   -   5         ��Name$ searchBookButton��5      $��Search��5      $
��Left=�5      $��
240,33,0,0q�5      $	��Top=�5      5      �� 5   
   -   5        $ bookNameLabel��5      $��	Book Name��5      $
��Left=�5      $��	41,79,0,0q�5      $	��Top=�5       J� RenderTransformOrigin$ 0.483,0.014&�5       �� 5!   
   -   5        $ bookNameTextBox��5!      $
��Left=�5"      $��
140,84,0,0q�5#      $�� ��5$      $
 Wrap=�5%      $	��Top=�5&      $	��500��5'       �� 
IsReadOnly$
 True��5(      �� 5)   
   -   5        $ authorNameLabel��5)      $��	Author(s)��5*      $
��Left=�5+      $��
41,121,0,0q�5,      $	��Top=�5-      �� 5.   
   -   5        $ authorNamesTextBox��5.      $
��Left=�5/      $��140,127,0,0q�50      $�� ��51      $
 Wrap=�52      $	��Top=�53      $	��500��54      $
 True��55      �� 56   
   -	   5        $ copiesAvailablLabel��56      $��Copies Available��57      $
��Left=�58      $��
41,164,0,0q�59      $	��Top=�5:      $ -1.116,-0.579&�5;      �� 5<   
   -
   5        $ copiesAvailableTextBox��5<      $
��Left=�5=      $��140,169,0,0q�5>      $�� ��5?      $
 Wrap=�5@      $	��Top=�5A      $��30��5B      $
 True��5C      �� 5D   
   -   5        $ errorMessageBarLabel��5D      $�� ��5E      $
��Left=�5F      $��
41,657,0,0q�5G      $	��Top=�5H      
���  ��5I      �� 5J   
   -   5        $ infoMessageBarLabel��5J      $�� ��5K      $
��Left=�5L      $��
41,657,0,0q�5M      $	��Top=�5N      
��� � �5O      �� 5P   
   -   5        $ addBookButton��5P      $��Add Book��5Q      $
��Left=�5R      $��200,169,0,0q�5S      $	��Top=�5T      5U      �� 5V   
   -   5        $ clearButton��5V      $��Clear��5W      $
��Left=�5X      $��300,169,0,0q�5Y      $	��Top=�5Z      5[      �� 5\   
   -   5        $ checkoutButton��5\      $��Issue Books��5]      $
��Left=�5^      $��
41,624,0,0q�5_      $	��Top=�5`      5a      &   System.Windows.Controls.DataGrid  5b   
   -   5        $��dgBookCollection��5b         AutoGenerateColumns$ False��5c      	   CanUserResizeColumns$
	 True��5d      
   CanUserSortColumns$

 True��5e      $��41,201,41,269q�5f         Columns 5h      0  *System.Windows.Controls.DataGridTextColumn  5i      ,  &System.Windows.Controls.DataGridColumn   Header$ Book ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *	Book_ID+  5j      $ 	Book Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 6V    68   �� *	Book_Name+6V     5k      $ 	Author(s)��6%   $	 300 6Y    68   �� *Author_Names+6Y   4  .System.Windows.Controls.DataGridCheckBoxColumn  5l      $ Delete��6)   6;   5n      �� 5o   
   -   5        $ deleteBooksButton��5o      $��Delete Selected Books��5p      $
��Left=�5q      $��
41,547,0,0q�5r      $	��Top=�5s      $ 0.303,0.553&�5t      5u      �� 5v   
   -   5        $ customerIDLabel��5v      $��Customer ID��5w      $
��Left=�5x      $��200,544,0,0q�5y      $	��Top=�5z      �� 5{   
   -   5        $ customerIDTextBok��5{      $
��Left=�5|      $��288,549,0,0q�5}      $�� ��5~      $
 Wrap=�5      $	��Top=�5�      $��70��5�      �� 5�   
   -   5        $ customerSearchButton��5�      $��Search��5�      $��Center=�5�      $��	0,547,0,0q�5�      $	��Top=�5�      $ -0.433,0.47&�5�      �� 5�   
   -   5        $ customerNameLabel��5�      $��Customer Name��5�      $
��Left=�5�      $��
41,585,0,0q�5�      $	��Top=�5�      �� 5�   
   -   5        $ customerNameTextBox��5�      $
��Left=�5�      $��142,589,0,0q�5�      $�� ��5�      $
 Wrap=�5�      $	��Top=�5�      $
 True��5�      $	��200��5�      5�      5�      