   M S B A M L   `   `   `  ����F  BEggPlantGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:EggplantGUIEggplantGUI  5   	   T PAvalonDock, Version=1.3.3571.0, Culture=neutral, PublicKeyToken=85a1e0ada7ec13e4;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock 5          EggplantGUI.MainWindow   5   	    myclr-namespace:EggplantGUI  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     5        � Title$  Eggplant��5       J� Opacity$ 1Q�6    � AllowsTransparency .   � Icon$7 1/EggPlantGUI;component/Images/egg%20plant%202.png��6>    � WindowState$ 	Maximized=�6w   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      6   .+�5   
   o� -   5        $��lo��5   ,   $��0��6   $��0��6   .@�5      m� -   5        $
��File��5      .@�5      m� -   5        $��New Sequence��5      6F   m� 5      -   5        $��Load Sequence��5      6L   m� 5      -   5        $��savemenu��5   Y   $
��Save��6    m� InputGestureText$ Ctrl+S��6?   6k   m� 5      -   5        $��
saveasmenu��5   E   $��Save as��6   6Y   m� 5      -   5        $��	closemenu��5   >   $��Close��6   6Q   �� 5      m� 5      -   5        $
��Quit��5      6C   5      m� 5      $
��Edit��6   .@�5      m� -	   5        $��_undo��5   @   MenuItem_52��{�.  m� Command$
 Undo��6M   $��_Undo��5   =   5      m� 5       -
   5        $��_redo��5    @   MenuItem_53��{�. $
 Redo��6M   $��_Redo��5!   =   5"      �� 5#      MenuItem_54��6   m� 5$      -   5        $
��_cut��5$   /   MenuItem_55��$	 Cut��6;   $
��Cu_t��5%   <   5&      m� 5'      -   5        $��_copy��5'   /   MenuItem_56��$
 Copy��6<   $��_Copy��5(   =   5)      m� 5*      -   5        $��_paste��5*   /   MenuItem_57��$ Paste��6=   $��_Paste��5+   >   5,      m� 5-      -   5        $��_find��5-      $
 Find��6)   $��_Find��5.   =   5/      51      m� 53      $��Analysis��6   .@�54      m� $��Primary��6   .@�55      m� -   5        $��
Absorbance��55      6U   m� 56      -   5        $��Aliphatic Index��56      6^   m� 57      -   5        $��Acid Composition��57      6`   m� 58      -   5        $��Atomic Composition��58      6e   m� 59      -   5        $��Chemical Formula��59      6a   m� 5:      -   5        $��Complete Analysis��5:      6b   m� 5<      -   5        $��Extiction Coefficient��5<      6k   m� 5>      -   5        $��GRAVY��5>      6K   m� 5?      -   5        $��	Half Life��5?      6R   m� 5@      -   5        $��Molecular Weight��5@      6`   m� 5A      -   5        $��Translation��5A      6W   m� 5B      -   5        $��Transcription��5B      6[   5C      m� 5D      $��	Secondary��6   .@�5E      m� -   5        $��Summary��5E      6Q   m� 5F      -   5        $��Verbose��5F      6Q   5G      5J      m� 5K      $
��Help��6   .@�5L      m� $��Documentation��6   64   m� 5M      -   5        $��About Eggplant��5M      6M   5P      5R      c� 5T      $��1��6   $��28��6#   $	��Top=�6/   $
��Left=�6G   $	��274��6b   .@�5U      �� -   5        $	��New��5U      6#   �� 5V      -   5        $��Load Sequence��5V      6-   5W        AvalonDock.DockingManager  5X   
   -    5        $��dockingManager��5X      $��2��62    J� 	AllowDrop . .��5Y        AvalonDock.ResizingPanel  	   Orientation$	 Vertical=�6   .+�5Z        $	 Vertical=�6#   .+�5[        AvalonDock.DocumentPane  5]      5_        AvalonDock.DockablePane  5`      
   ResizeHeight$	
 250 �6   .@�5a         AvalonDock.DockableContent  -!   5          Name$ 	eggoutput��5a   4     AvalonDock.ManagedContent   Title$ Output��6%   .��5b      �� -"   5        $��
textOutBox��5b   K    �� 
IsReadOnly .  �� AcceptsReturn . $ �� HorizontalScrollBarVisibility$
 Auto=�5c   $   " �� VerticalScrollBarVisibility$
 Auto=�5d   $   5e      5f      5g      5h      5j      5n      