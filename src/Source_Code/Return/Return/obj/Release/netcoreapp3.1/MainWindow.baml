   M S B A M L   `   `   `  ���� A  =Return, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ReturnReturn      Return.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:Return       � Title$  Return a Book��$	��800��$	��800��.��� .+��� -    ��Name$ customerIDLabel��$��Customer ID��$
��Left=�$��	41,28,0,0q�$	��Top=��� -    ��Name$ customerIDTextBox��$
��Left=�$��
120,33,0,0q�$�� �� �� TextWrapping$
 Wrap=�$	��Top=�$	��120���� -    ��Name$ searchCustomerButton��$��Search��$
��Left=�$��
250,33,0,0q�$	��Top=��� -   $ getBorrowDetailsButton��$��Get Borrow Details��$
��Left=�$��
350,69,0,0q�$	��Top=��� -   $ customerNameLabel��$��Customer Name��$
��Left=�$��	41,65,0,0q�$	��Top=��� -   $ customerNameTextBox��$
��Left=�$��
142,70,0,0q�$�� ��$
 Wrap=�$	��Top=� �� 
IsReadOnly$
 True��$	��200���� -   $ errorMessageBarLabel��$�� ��$
��Left=�$��
41,657,0,0q�$	��Top=�
���  ���� -   $ infoMessageBarLabel��$�� ��$
��Left=�$��
41,657,0,0q�$	��Top=�
��� � �&   System.Windows.Controls.DataGrid  -	   $��dgBookCollection��   AutoGenerateColumns$ False��   CanUserResizeColumns$
 True��   CanUserSortColumns$
 True��$��41,130,41,269q�	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 Book ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	Book_ID+  $
 	Book Name��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 300  �� *	Book_Name+  $
 
Issue Date��$	 100  �� *
Issue_Date+  $
 Due Date��$	 100  �� *
Due_Date+4  .System.Windows.Controls.DataGridCheckBoxColumn  $
 Delete���� -
   $ processReturn��$��Accept All Books��$
��Left=�$��
41,530,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.303,0.553&�