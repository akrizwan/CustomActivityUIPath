   M S B A M L   `   `   `  ����I  ECustomActivity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CustomActivityCustomActivity  5      *    $CustomActivity.StoredProcedureWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:CustomActivity     5      -   5           CustomWindowStyle#��[  5        � WindowStartupLocation$  CenterScreen=�5	      $	��450��5
      $	��450��6   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��0��6   $	��Top=�6-   $��Stretch=�6F   $��	10 10 0 0q�6d   $��Stored Procedure Name:��6w   6�   �� 5   
   -   5         ��Name$ txtStoredProcedureName��5      $��Consolas)�62   $��0��6H   $��1��6U   $��Center=�6e   $��Stretch=�6�   $	��Top=�6�   $��	10 0 10 0q�6�    �� 
AcceptsTab .  �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6�   6  �� 5   
   -   5         ��Name$ btnFetchParameters��5      $��1��6-   $��1��6:   $��Center=�6J   $��Center=�6e   $	��100��6�   $��5q�6�   $��Fetch Parameters��6�   6�   � 5   
   -   5         �Name$ procedureParameterGrid��5      $��2��6/   $��0��6<   $��2��6L    5       �� 5!      �� 5"       5%      5(      �� 5+   
   -   5        $ btnOK��5+      $��3��6    $��0��6-   $��Center=�6=   $��Center=�6X   $	��100��6u   $��5q�6�   $��OK��6�   6�   �� 5,   
   -   5        $ 	btnCancel��5,      	 �� IsCancel	 . $��3��64   $��1��6A   $��Center=�6Q   $��Center=�6l   $	��100��6�   $��5q�6�   $��Cancel��6�   6�   5-      5.      