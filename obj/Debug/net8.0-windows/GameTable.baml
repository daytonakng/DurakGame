   M S B A M L   `   `   `  ����D  @DurakGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DurakGame	DurakGame  5          DurakGame.GameTable   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:DurakGame     5        N� Title$  	GameTable��5	       � 	Resources 5
         FocusVisual �� Property �� Value �� StrokeDashArray!  System.Windows.SystemColors   ControlTextBrushKey J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Foreground  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background 	 Button.Disabled.Border 
 Button.Disabled.Foreground  ButtonStyle1 �� 
TargetType	 �� 
TargetType
 ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName   HighlightBrushKey��%T  &	        &	 �     &	 �     &	 �     &	     &	 7    &	 \    &	     &	 �    &		 �    &	
 �    &	     7   7  7  7  7  7  7 	 7 
 �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #���  6E   $
 true��6�   $��1��6�   5      5      5      �� 5   
   $ 	#FF8B5B43��6;   �� 5   
   $ White��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ White��6>   �� 5   
   $ ForestGreen��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ ForestGreen��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6%   .�5      ��  �@�FocusVisualStyle8   61   �� 5        � ��8  6+   �� 5!       � ��8  6,   �� 5"       � ��$ 3q�60   �� 5#       � ��$ Center=�6;   �� 5$       � ��$ Center=�69   �� 5%       � ��$ Monotype Corsiva)�6+   �� 5&       � ��
 �����6+   �� 5'       � ��$ 20(�6)   �� 5(       �@�Cursor$
 Hand��6'   �� 5)       � ��$ 1q�6(   �� 5+       � �� 5,      �� 5-      "	 ��6&   .R�5.      �� $
 border��6!   $ 17��61   #��z��6C   #��z��6m   #��z��6�   $
 true��6�   ._�5/      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  50       51      P� 52       �@��IsDefaulted$
 true��6=   . �53   "   �� $ border��6@   # �  6T    � ��54      P� 55       �@J�IsMouseOver$
 true��6=   . �56   "   �� $ border��6?    � �� �	#FF8B5B436S   �� 57   "   $ border��6@   8   � ��6T   58      P� 59       � ��$
 true��6;   . �5:   "   �� $ border��6?    � �� �	#FF8B5B436S   �� 5;   "   $ border��6@   8   � ��6T   5<      P� 5=       � {�$ false��6;   . �5>   "   �� $ border��6?   8   � ��6S   �� 5?   "   $ border��6@   8   � ��6T   �� 5@   "   $ contentPresenter��6K   8   � ��6i   5A      5C      5E      5F      5G      .��5I      � -   5         �Name$ mainGrid��5I      ��5J   
   �� 5K       �� ImageSource$ /img/tabletop.jpg��6   6;   .+�5N   
   �� -   5         ��Name$ durakLogoImage��5N      $��Center=�6-   $��Center=�6J   $	��800��6e   $	��400��6q    �� Orientation$ 
Horizontal=�6~   $y�Hidden=�6�   .+�5O      �� $
��Left=�6   $	��300��6/   $	��300��6;   $��img/cards.png��6H   6a   �� 5P      $
��Left=�6   $	��500��6/   $	��300��6;   $��img/durak.png��6H   6a   5Q      �� 5S   
   -   5         ��Name$ secondPlayerText��5S      $��Игрок 2��6.   $��Monotype Corsiva)�6=   $��80(�6[   $	��Top=�6i   $��Center=�6�   
�������$��	0,100,0,0q�6�   �� 5T   
   -   5        $ firstPlayerText��5T      $��Игрок 1��6-   $��Monotype Corsiva)�6<   $��80(�6Z   $��Bottom=�6h   $��Center=�6�   
�������$��0,0,0,85q�6�   �� 5V   
   -   5         ��Name$ changeTextOnScreen��5V      $��40��6-   $��40��68   $��905,-690,50,130q�6D    J� Opacity$ 0Q�6]   6i   �� 5Z   
   -   5        $ startButton��5Z   8   #���  6   $	��100��6M   $��50��6Y   $��Right=�6e   $��Bottom=�6�   $	��100q�6�   $��Играть��6�   $y�Visible=�6�   �� 5\   
   -   5        $ 
exitButton��5\   8   #���  6   $	��100��6L   $��50��6X   $
��Left=�6d   $	��100q�6   $��Bottom=�6�   $��
Выйти��6�   6�   �� 5^   
   -   5         ��Name$ 
logTextBox��5^      $	��400��6&   $	��150��62   $
��Left=�6?   $��
390,20,0,0q�6Z    �� 
IsReadOnly$
 True��6n   
������ $��0q�6�    �� TextWrapping$ WrapWithOverflow=�6�    �� TextAlignment$ Center=�6�   $��Center=�6�   $��Monotype Corsiva)�6  $��20(�6$  
�������$��Hidden=�6E   �� AcceptsReturn$
 True��6w  .��6�   5_      ��%E   '��       �� 5`      " ��6   .�5a      -	   5        5b      5c      .��6!   5d      � 5h   
   -
   5        $ gameAreaGrid��5h      $	��900��6%   $	��720��61   $��0,25,0,0q�6>   $��Center=�6P   $��Center=�6m    � RowDefinitions 5i      �� 5j      $��1* �6    �� 5k      $��1* �6    �� 5l      $��1* �6    �� 5m      $��1* �6    �� 5n      $��1* �6    �� 5o      $��1* �6    �� 5p      $��1* �6    �� 5q      $��1* �6     � ColumnDefinitions 5s      �� 5t      $��1* �6#   �� 5u      $��1* �6#   �� 5v      $��1* �6#   �� 5w      $��1* �6#   �� 5x      $��1* �6#   �� 5y      $��1* �6#   �� 5z      $��1* �6#   �� 5{      $��1* �6#   .+�5�      �� -   5        $ secondPlayerHandCount��5�      $��2��67   $��0��6D   $��70(�6T   $��Center=�6b   $��Center=�6   
�������$y�Hidden=�6�   �� 5�      -   5          ��Name$  card0Player2Image��5�      $��1��6/   $��1��6<   $��img/cards/back-black.png��6L   ! � Cursor$
! Hand��6�   �� 5�      -   5        $  card1Player2Image��5�      $��1��6/   $��2��6<   $��img/cards/back-black.png��6L   $
! Hand��6�   �� 5�      -   5        $  card2Player2Image��5�      $��1��6/   $��3��6<   $��img/cards/back-black.png��6L   $
! Hand��6�   �� 5�      -   5        $  card3Player2Image��5�      $��1��6/   $��4��6<   $��img/cards/back-black.png��6L   $
! Hand��6�   �� 5�      -   5        $  card4Player2Image��5�      $��1��6/   $��5��6<   $��img/cards/back-black.png��6L   $
! Hand��6�   �� 5�      -   5        $  card5Player2Image��5�      $��1��6/   $��6��6<   $��img/cards/back-black.png��6L   $
! Hand��6�   �� 5�      -   5        $ nextSecondHandButton��5�      #���  63   $��70��6Z   $��40��6e   $��0��6q   $��6��6~   $��>��6�   $y�Hidden=�6�   �� 5�      -   5        $ prevSecondHandButton��5�      #���  63   $��70��6Z   $��40��6e   $��0��6q   $��1��6~   $��<��6�   $y�Hidden=�6�   �� 5�      -   5        $ firstPlayerHandCount��5�      $��5��66   $��0��6C   $��70(�6S   $��Center=�6a   $��Center=�6~   
�������$y�Hidden=�6�   �� 5�      -   5        $  card0Player1Image��5�      $��6��6/   $��1��6<   $��img/cards/back-black.png��6L   $
! Hand��6�   �� 5�      -   5        $  card1Player1Image��5�      $��6��6/   $��2��6<   $��img/cards/back-black.png��6L   $
! Hand��6�   �� 5�      -   5        $  card2Player1Image��5�      $��6��6/   $��3��6<   $��img/cards/back-black.png��6L   $
! Hand��6�   �� 5�      -   5        $  card3Player1Image��5�      $��6��6/   $��4��6<   $��img/cards/back-black.png��6L   $
! Hand��6�   �� 5�      -   5        $  card4Player1Image��5�      $��6��6/   $��5��6<   $��img/cards/back-black.png��6L   $
! Hand��6�   �� 5�      -   5        $  card5Player1Image��5�      $��6��6/   $��6��6<   $��img/cards/back-black.png��6L   $
! Hand��6�   �� 5�      -   5        $ nextFirstHandButton��5�      #���  62   $��70��6Y   $��40��6d   $��7��6p   $��6��6}   $��>��6�   $y�Hidden=�6�   �� 5�      -   5        $ prevFirstHandButton��5�      #���  62   $��70��6Y   $��40��6d   $��7��6p   $��1��6}   $��<��6�   $y�Hidden=�6�   5�      �� 5�   
   -   5        $
 hideFirstCardsBorder��5�      $	��650��6/   $	��100��6;   $��Center=�6H   $��	0,470,0,0q�6e   
���   �$y�Hidden=�6�   �� 5�   
   -   5        $
 hideSecondCardsBorder��5�      $	��650��60   $	��100��6<   $��Center=�6I   $��
0,-420,0,0q�6f   
���   �$y�Hidden=�6�   � 5�   
   $	��120��6   $	��550��6   $��Right=�6(   $��	0,0,350,0q�6D    5�      �� 5�      $��1* �6    6.   �� 5�      $��1* �6    6.   �� 5�      $��1* �6    6.   �� 5�      $��1* �6    6.   �� 5�      $��1* �6    6.    5�      �� 5�      $��1* �6#   60   .+�5�      �� -   5        " ��Name$" leaveCardsGroupBox��5�      $��Бито��63   $��Monotype Corsiva)�6A   $��20(�6_   $��1��6m   $��0��6z   $��Center=�6�   $��Center=�6�   $��90��6�   $	��120��6�   
����������	#FF8B5B43.��5�      �� $ 
Horizontal=�6   $��Center=�66   .+�5�      �� -    5        $  leaveCardsImage��5�      $
��Left=�65   $��50��6P   $��60��6[   $��img/cards/back-black.png��6g   $
! Hand��6�   $y�Hidden=�6�   �� 5�      -!   5        $ leaveCardsCount��5�       $��50��69   $��40��6E   $��40(�6P   $��Bottom=�6^   $��Right=�6y   5�      5�      �� 5�      -"   5        $" trumpGroupBox��5�      $��Козырь��6.   $��2��6>   $��0��6K   $��Center=�6[   $��Center=�6v   $��90��6�   $	��120��6�   $��Monotype Corsiva)�6�   $��20(�6�   
����������	#FF8B5B43.��5�      �� $ 
Horizontal=�6   $��Center=�66   .+�5�      �� -#   5        $  trumpCardImage��5�      $
��Left=�64   $��55��6O   $��60��6Z   $��img/cards/back-black.png��6f   $y�Hidden=�6�   �� 5�      -$   5        $  
trumpImage��5�      $��35��60   $��35��6;   5�      5�      �� 5�      -%   5        $" deckGroupBox��5�      $��Колода��6-   $��3��6=   $��9��6J   $��Center=�6Z   $��Center=�6u   $��90��6�   $	��120��6�   $��Monotype Corsiva)�6�   $��20(�6�   
����������	#FF8B5B43.��5�      �� $ 
Horizontal=�6   $��Center=�66   .+�5�      �� -&   5        $  gameDeckImage��5�      $
��Left=�63   $��50��6N   $��60��6Y   $��img/cards/back-black.png��6e   $
! Hand��6�   $y�Hidden=�6�   �� 5�      -'   5        $ gameDeckCount��5�       $��50��67   $��40��6C   $��40(�6N   $��Bottom=�6\   $��Right=�6w   5�      5�      �� 5�      -(   5        $ 
takeButton��5�   �   #���  6   $	��100��6<   $��50��6H   $��Беру��6T   $��5��6c   $��9��6p   $��Center=�6�   $��Center=�6�   $
! Hand��6�   6�   5�      �� 5�   
   -)   5        $  	specImage��5�      $
��1600��6#   $��img/Uw6lH_tX8w0.jpg��60   $��Center=�6M   $y�Hidden=�6j   6�   5�      5�      