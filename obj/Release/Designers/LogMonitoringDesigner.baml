   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  I ECustomActivity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CustomActivityCustomActivity e aSystem.Activities.Presentation, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35wTclr-namespace:System.Activities.Presentation;assembly=System.Activities.PresentationSystem.Activities.Presentation �Yclr-namespace:System.Activities.Presentation.View;assembly=System.Activities.Presentation#System.Activities.Presentation.View �_clr-namespace:System.Activities.Presentation.Converters;assembly=System.Activities.Presentation)System.Activities.Presentation.Converters *   $CustomActivity.LogMonitoringDesigner   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     4s&clr-namespace:System;assembly=mscorlib     *cclr-namespace:CustomActivity     dsapTclr-namespace:System.Activities.Presentation;assembly=System.Activities.Presentation     jsapvYclr-namespace:System.Activities.Presentation.View;assembly=System.Activities.Presentation     psapc_clr-namespace:System.Activities.Presentation.Converters;assembly=System.Activities.Presentation       � 	Resources  M  GSystem.Activities.Presentation.Converters.ArgumentToExpressionConverter !  ArgumentToExpressionConverter*  $CustomActivity.ComboBoxItemConverter  comboBoxItemConverter  	Collapsed  Expanded � ColumnDefinitions � RowDefinitions;  5System.Activities.Presentation.View.ExpressionTextBox  Name   HintText   ExpressionType   MaxLines   
Expression �� Path	 �� Mode
 �� 	Converter �� ConverterParameter   OwnerActivity   
AcceptsTab �� SelectedValue �� 
IsSelected  ExpandOrCollapsedStyle �� 
TargetType �� Property �� Value �� Triggers �� Binding �� Value�� %  &	        &	      &	 
     &	 D     7   7   7   7   7   7   7  &	 i        �� .R��� .+��� $��Italic$�.��Double tap to view�� .R��  �� ��  �� �� �� �� �� �� �� .+��� $
��auto��$	��0,5q�$��0��$��0��.��
Keyword:  $ keywordTextBox��$ Keyword��" ��$	��110��$	��0,5q�$��0��$��1��$ 1�� �� $ ModelItem.Keyword�$	 TwoWay=�8
   $ In�� �� $ 	ModelItem��� $
��auto��$	��0,5q�$��0��$��1��.��	Log Path:  $ logPathTextBox��$ LogPath��" ��$	��110��$	��0,5q�$��1��$��1��$ 1�� �� $ ModelItem.Log_Path�$	 TwoWay=�8
  $ In�� �� $ 	ModelItem��� $
��auto��$	��0,5q�$��0��$��2��.��Start Identifier:  $��startIdentifierTextBox��$ Start Identifier��" ��$	��110��$	��0,5q�$��2��$��1��$ 1�� �� $  ModelItem.Start_Identifier�$	 TwoWay=�8
  $ In�� �� $ 	ModelItem��� $
��auto��$	��0,5q�$��0��$��3��.��End Identifier:  $��endIdentifierTextBox��$ End Identifier��" ��$	��110��$	��0,5q�$��3��$��1��$ 1�� �� $ ModelItem.End_Identifier�$	 TwoWay=�8
  $ In�� �� $ 	ModelItem��� $
��auto��$	��0,5q�$��0��$��4��.��
Seperator:  $��seperatorTextBox��$ Leave blank if space��" ��$	��110��$	��0,5q�$��4��$��1��$ 1�� .  �� $ ModelItem.Seperator�$	 TwoWay=�8
  $ In�� �� $ 	ModelItem��� $
��auto��$	��0,5q�$��0��$��5��.��Date Location:  $��dateLocationTextBox��$ Location of Date��" ��$	��110��$	��0,5q�$��5��$��1��$ 1�� �� $ ModelItem.Date_Location�$	 TwoWay=�8
  $ In�� �� $ 	ModelItem��� $
��auto��$	��0,5q�$��0��$��6��.��Date Time Format:�� $��commandTypeComboBox��$��1��$��6��$	��0,5q� �� $  ModelItem.Date_Time_Format�$	 TwoWay=�8
  ���� .@���  . .��
YYYY-MM-DD�� .��
DD-MM-YYYY�� .��
MM-DD-YYYY�� " ��.���  � ��# �   ��  �� $ ShowExpanded� true.a���  � ��# �  .��� .+��� #���  ���� 