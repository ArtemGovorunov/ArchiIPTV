   M S B A M L   `   `   `  ����K  GArchiIPTV_Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ArchiIPTV_Player.ViewModelArchiIPTV_Player.ViewModel  5   	   3clr-namespace:ArchiIPTV_PlayerArchiIPTV_Player  5   	   !    ArchiIPTV_Player.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7VM(clr-namespace:ArchiIPTV_Player.ViewModel     5   	   ;archiiptv_playerclr-namespace:ArchiIPTV_Player     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   $	��600��5
   	   $	��200��6    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType ��Name��%>  '��       �� 5   
   " ��6   .�5      ��  � ��$ Segoe MDL2 Assets)�6+   �� 5       � ��$ 0q�6'   �� 5       � ��$ 50��6&   �� 5       � ��$ 50��6'   �� 5       � ��$ 25(�6)   �� 5       � ��
 ���� 6+   �� 5       � ��
 ���� 6,   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      ._�5      � .+�5   "   �� $ 
background��6,   #��z��5   $   �� 5    "   #��z��5!   !   #��z��5"   !   5#      5$      5%      5'      5(      5)      .��5*      �  � RowDefinitions 5,   
   �� 5-      $��* �6   �� 5.      $
��auto �6   .+�50   
   � $��0��6    � ColumnDefinitions 51      �� 52      �� 53      $
��auto �6#   �� 54      $	��170 �6#   .+�5:         ArchiIPTV_Player.MyVLC  -   5        	  Name$	 myVLC��5:   %      ArchiIPTV_Player.MyVLC
   MouseLeftButtonDown$
 MyVLC_MouseLeftButtonDown��5=         MediaSource 5;      ��  �� ElementName$ ListBoxChanels�� �� Path$ SelectedItem� �� UpdateSourceTrigger$ PropertyChanged=�   Volume 5<      �� $ SliderVolume��$ Value�$ PropertyChanged=� � ContextMenu 5?      �� 5@      .@�5A      m� -   5         m� IsCheckable . $$��Поверх всех окон��5A   6   6P   5B      5D      �� 5E      -   5        $��PlaylistSplitter��5E      $��1��63    �� ShowsPreview .  $��3��6X   $��Center=�5F   	   $��Stretch=�6&   � 5H      -   5        $��PlaylistPanel��5H   #   $��3��6    � DataContext 5I      1  +ArchiIPTV_Player.ViewModel.ChanelsViewModel  5J       5L      �� 5M      $
��auto �6$   �� 5N      $��* �6$   .+�5P      �� $��25��6   $��0��6&   ��63   �� *FilterChanel+$ PropertyChanged=�.��6v   ��5Q      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5R   5   �� 6   6sys&clr-namespace:System;assembly=mscorlib     65   " ��6     �� 	Resources 5S         CueBannerBrush j� 
AlignmentX j� 
AlignmentY j� Stretch !� Visual��%�   &	        !� 5T   "   $
 Left=�6E   $ Center=�6W   $
 None=�6k    5U   &   �� 5V   *   $��Поиск каналов��60   
�������6H   5X   #   5Y       �� Triggers 5Z      P� 5[   "    P� Property � �� �� Empty P� Value# Z 6:   . �5\   &   ��  � ��# [  6C   5]   #   P� 5^   "    � �� 6:   Z� . �5_   &   ��  � ��# [  6C   5`   #   P� 5a   "    �@J�IsKeyboardFocused . . �5b   &   ��  � ��
 �����6C   5c   #   5e      .��5f   %   5g      �� 5h      -   5        $��ListBoxChanels��5h      $��1��5i       �� SelectionMode$ Single=�5m   "   ��5j   "   �� *ChanelCollection+ �� Mode$ TwoWay=� �� SelectedItem 5k   "   �� *SelectedChanel+  �� SelectedIndex  5l   "   �� *SelectedIndex+��5p      �� 5q      .R�5r      �� ��6(   �� *Title+5s      5u      5w      5x      � 5y   
   -   5        $��ButtomPanel��5y      $��1��6   ��5z      �� 5{      ! �� 
StartPoint$	! 0,1&�6&   " �� EndPoint$	" 0,0&�67   .��5|      � # � Color$
# Blue��6#   $ � Offset$$ 0Q�60   6=   � 5}      $# Transparent��6#   $$ 1Q�67   6D   5~      .+�5�   
   �� -   5        $��	DownPanel��5�   .   % �� Orientation$% 
Horizontal=�6   $
��Left=�6?   .+�5�      �� $	����6   $
��Play��6I   ��6(   �� *MediaCommand+6I   �� 5�      $	����6   $
��Stop��6I   ��6(   �� *MediaCommand+6I   �� 5�      $	����6   $
��Mute��6I   ��6(   �� *MediaCommand+6I   �� 5�      -   5        $��SliderVolume��5�      $��Center=�5�      $	��150��60   & � Minimum$& 0Q�5�      ' � Maximum$	' 100Q�6!   ( � Value$	( 100Q�6/   ) � SmallChange$) 5Q�5�      5�      �� 5�   
   $% 
Horizontal=�6   $��Right=�6.   .+�5�      �� -	   5        $��SettingsButton��5�   ,   $	����6   6B   �� 5�      -
   5        $��FullScreenButton��5�   ,   $	����6   6D   �� 5�      -   5        $	����5�      6,   5�      5�      5�      5�      