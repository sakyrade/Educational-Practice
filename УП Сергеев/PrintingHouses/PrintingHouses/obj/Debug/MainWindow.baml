   M S B A M L   `   `   `  ����L  HPrintingHousesApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PrintingHousesAppPrintingHousesApp  5   	   "    PrintingHousesApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PrintingHousesApp     5   	   ?md0http://materialdesigninxaml.net/winfx/xaml/theme     5   	   -   5          �Name$  
mainWindow��5	   n    � Icon$ icons/newspaper.png��5   	   $	��500��5	      $	��900��6'    � 
ResizeMode$ NoResize=�63    � WindowStartupLocation$ CenterScreen=�6I    � Title$7 1Цербер: Отслеживание газет��6�   .��5
      �  � RowDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5      �� $ 
Horizontal=�6   $
��10,0q�62   $��Center=�6@   .+�5      �� $��icons/newspaper.png��6   �� 5      $��10q�6   $��Center=�6)   $��Center=�6F   .+�5      ��    HegvalDisplayRegular#��[  6   $��Цербер��6O   $��20(�6`   $��Center=�6n   �� 5      #��[  6   $)��#Отслеживание газет��6O   $��Center=�6l   5      5      o� 5      $��10, 0, 10, 0q�6   $��Center=�6)   $��Center=�6F   .@�5      m� $��0q�6   $��Center=�6&   #��[  6A   
���   �$��Газеты��6�   
������ .@�5      m� -   5        $��10q�5      $��Center=�6+   #��[  6^   
���   �
������ $��О газетах��6�   m� 5      -   5        $��10q�5      $��Center=�6+   #��[  6a   
������ $"��Газеты в печати��6�   m� 5      -   5        $��10q�5      $��Center=�6+   #��[  6d   
������ $��Газеты в пути��6�   5      m� 5      -   5        $��0q�5      $��Center=�6&   #��[  6X   
���   �$��Типографии��6�   
������ 6�   m� 5       -   5        $��0q�5       $��Center=�6&   #��[  6U   
���   �
������ $)��#Почтовые отделения��6�   5!      5"      &   System.Windows.Controls.DataGrid  5#   
   -   5          Name$ dataGrid��5#   Z   $y�Hidden=�6   #��[  6'      SelectionMode$ Extended=�6l   	   SelectionUnit$	 FullRow=�6�   
   CanUserAddRows
 .     CanUserDeleteRows .     AutoGenerateColumns .  $��1��6+  ��6�   ��  �� ElementName$ 
mainWindow�� �� Path$ TargetTable�5$      �� 5%   
   -   5         ��Name$ defaultLabel��5%      $@��:Выберите таблицу на панели выше��6&   $��Center=�6P   $��Center=�6k   #��[  6�   ���#666666$��1��6�   �� 5&   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   .+�5'      �� -	   5        
������ $��10q�5'   /   #��[  6N   $��20, 0, 20, 0q�6�   ���#E56C44
�������$��Добавить��6�   �� 5(      -
   5        
������ $��10q�5(   /   #��[  6N   $��20, 0, 20, 0q�6�   ���#E56C44
�������$��Обновить��6�   �� 5)      -   5        
������ $��10q�5)   /   #��[  6N   $��20, 0, 20, 0q�6�   ���#E56C44
�������$��Удалить��6�   5*      5+      5,      