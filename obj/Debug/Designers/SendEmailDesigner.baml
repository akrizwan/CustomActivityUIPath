   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      e aSystem.Activities.Presentation, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35wTclr-namespace:System.Activities.Presentation;assembly=System.Activities.PresentationSystem.Activities.Presentation 5      �Yclr-namespace:System.Activities.Presentation.View;assembly=System.Activities.Presentation#System.Activities.Presentation.View 5      �_clr-namespace:System.Activities.Presentation.Converters;assembly=System.Activities.Presentation)System.Activities.Presentation.Converters 5       CustomActivity&    CustomActivity.SendEmailDesigner   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      4s&clr-namespace:System;assembly=mscorlib     5      dsapTclr-namespace:System.Activities.Presentation;assembly=System.Activities.Presentation     5      jsapvYclr-namespace:System.Activities.Presentation.View;assembly=System.Activities.Presentation     5      psapc_clr-namespace:System.Activities.Presentation.Converters;assembly=System.Activities.Presentation     5        � 	Resources  5      M  GSystem.Activities.Presentation.Converters.ArgumentToExpressionConverter !  ArgumentToExpressionConverter�� 5	   
   %   &	          5
      61   5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $
��auto��6   $	��0,5q�5      $��0��5      $��0��5      .��6   Host:6$   ;  5System.Activities.Presentation.View.ExpressionTextBox  5    
   -   5          Name$ hostTextBox��5    !      HintText$ Script��5!         ExpressionType" ��5#      $	��110��5%      $	��0,5q�5&      $��0��5'      $��1��5(         
Expression 5"      ��  �� Path$ ModelItem.Host� �� Mode$ TwoWay=�	 �� 	Converter#	 [  
 �� ConverterParameter$
 In��   OwnerActivity 5$      �� $ 	ModelItem�5(      �� 5*   
   $
��auto��6   $	��0,5q�5+      $��0��5,      $��1��5-      .��6   From:6$     5.   
   -   5        $ fromTextBox��5.   !   $ From Address��5/      " ��51      $	��110��53      $	��0,5q�54      $��1��55      $��1��56       50      �� $ ModelItem.From�$ TwoWay=�#	 [  $
 In�� 52      �� $ 	ModelItem�56      �� 58   
   $
��auto��6   $	��0,5q�59      $��0��5:      $��2��5;      .��6   To:6"     5<   
   -   5        $ 	toTextBox��5<   !   $ 
To Address��5=      " ��5?      $	��110��5A      $	��0,5q�5B      $��2��5C      $��1��5D       5>      �� $ ModelItem.To�$ TwoWay=�#	 [  $
 In�� 5@      �� $ 	ModelItem�5D      �� 5F   
   $
��auto��6   $	��0,5q�5G      $��0��5H      $��3��5I      .��6   
Subject:6'     5J   
   -   5        $ subjectTextBox��5J   !   $ Script��5K      " ��5M      $	��110��5O      $	��0,5q�5P      $��3��5Q      $��1��5R       5L      �� $ ModelItem.Subject�$ TwoWay=�#	 [  $
 In�� 5N      �� $ 	ModelItem�5R      �� 5T   
   $
��auto��6   $	��0,5q�5U      $��0��5V      $��4��5W      .��6   Body:6$     5X   
   -   5        $ bodyTextBox��5X   !   $ Script��5Y      " ��5[      $	��110��5]      $	��0,5q�5^      $��4��5_      $��1��5`       5Z      �� $ ModelItem.Body�$ TwoWay=�#	 [  $
 In�� 5\      �� $ 	ModelItem�5`      �� 5b   
   $
��auto��6   $	��0,5q�5c      $��0��5d      $��5��5e      .��6   AttachmentLink:6.     5f   
   -   5        $ attachmentLinkTextBox��5f   !   $ Attachment Link��5g      " ��5i      $	��110��5k      $	��0,5q�5l      $��5��5m      $��1��5n       5h      �� $ ModelItem.AttachmentLink�$ TwoWay=�#	 [  $
 In�� 5j      �� $ 	ModelItem�5n      5o      5p      