   M S B A M L   `   `   `  ����A  =Return, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ReturnReturn  5   	       Return.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Return     5   	     � Title$  Return a Book��5   	   $	��800��6   $	��800��6,   .��5	      � .+�5
   
   �� -   5         ��Name$ customerIDLabel��5
      $��Customer ID��5      $
��Left=�5      $��	41,28,0,0q�5      $	��Top=�5      �� 5   
   -   5         ��Name$ customerIDTextBox��5      $
��Left=�5      $��
120,33,0,0q�5      $�� ��5       �� TextWrapping$
 Wrap=�5      $	��Top=�5      $	��120��5      �� 5   
   -   5         ��Name$ searchCustomerButton��5      $��Search��5      $
��Left=�5      $��
250,33,0,0q�5      $	��Top=�5      5      �� 5   
   -   5        $ getBorrowDetailsButton��5      $��Get Borrow Details��5      $
��Left=�5      $��
350,69,0,0q�5      $	��Top=�5       5!      �� 5"   
   -   5        $ customerNameLabel��5"      $��Customer Name��5#      $
��Left=�5$      $��	41,65,0,0q�5%      $	��Top=�5&      �� 5'   
   -   5        $ customerNameTextBox��5'      $
��Left=�5(      $��
142,70,0,0q�5)      $�� ��5*      $
 Wrap=�5+      $	��Top=�5,       �� 
IsReadOnly$
 True��5-      $	��200��5.      �� 5/   
   -   5        $ errorMessageBarLabel��5/      $�� ��50      $
��Left=�51      $��
41,657,0,0q�52      $	��Top=�53      
���  ��54      �� 55   
   -   5        $ infoMessageBarLabel��55      $�� ��56      $
��Left=�57      $��
41,657,0,0q�58      $	��Top=�59      
��� � �5:      &   System.Windows.Controls.DataGrid  5;   
   -	   5        $��dgBookCollection��5;         AutoGenerateColumns$ False��5<         CanUserResizeColumns$
 True��5=         CanUserSortColumns$
 True��5>      $��41,130,41,269q�5?      	   Columns	 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Book ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *	Book_ID+  5B      $
 	Book Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 6V    68   �� *	Book_Name+6V     5C      $
 
Issue Date��6%   $	 100 6X    69   �� *
Issue_Date+6X     5D      $
 Due Date��6%   $	 100 6T    67   �� *
Due_Date+6T   4  .System.Windows.Controls.DataGridCheckBoxColumn  5E      $
 Delete��6)   6;   5G      �� 5I   
   -
   5        $ processReturn��5I      $��Accept All Books��5J      $
��Left=�5K      $��
41,530,0,0q�5L      $	��Top=�5M       J� RenderTransformOrigin$ 0.303,0.553&�5N      5O      5P      5Q      