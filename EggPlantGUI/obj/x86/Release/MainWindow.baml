   M S B A M L   `   `   `  ���� F  BEggPlantGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:EggplantGUIEggplantGUI  T PAvalonDock, Version=1.3.3571.0, Culture=neutral, PublicKeyToken=85a1e0ada7ec13e4;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock     EggplantGUI.MainWindow    myclr-namespace:EggplantGUI  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;ad,clr-namespace:AvalonDock;assembly=AvalonDock       � Title$  Eggplant�� J� Opacity$ 1Q� � AllowsTransparency .   � Icon$7 1/EggPlantGUI;component/Images/egg%20plant%202.png�� � WindowState$ 	Maximized=�.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� .+�o� $��0��$��0��.@�m� $
��File��.@�m� -   $��New Sequence��m� -   $��Load Sequence��m� -   $
��Save�� m� InputGestureText$ Ctrl+S��m� -   $��Save as��m� -   $��Close���� m� -   $
��Quit��m� $
��Edit��.@�m� -   $��_undo��MenuItem_52��{�.  m� Command$
 Undo��$��_Undo��m� -   $��_redo��MenuItem_53��{�. $
 Redo��$��_Redo���� MenuItem_54��m� -	   $
��_cut��MenuItem_55��$	 Cut��$
��Cu_t��m� -
   $��_copy��MenuItem_56��$
 Copy��$��_Copy��m� -   $��_paste��MenuItem_57��$ Paste��$��_Paste��m� -   $��_find��$
 Find��$��_Find��m� $��Analysis��.@�m� $��Primary��.@�m� -   $��
Absorbance��m� $��Aliphatic Index��m� -   $��Acid Composition��m� -   $��Chemical Formula��m� $��Complete Analysis��m� $��
Coposition��m� $��Extiction Coefficient��m� $��GRAVY��m� $��	Half Life��m� -   $��Molecular Weight��m� -   $��Total Number of Atoms��m� -   $��Translation��m� -   $��Transcription��m� $��	Secondary��m� $��
Comparison��.@�m� $��DNA or Primary Sequence��m� $��	Secondary���� m� $��
Show Graph��m� $
��Help��.@�m� $��Documentation��m� -   $��About Eggplant��m� $��Update��c� $��0��$��1��$��28��$	��Top=�.@��� -   $	��New���� -   $��Load Sequence��  AvalonDock.DockingManager  -   $��dockingManager��$��2��.��  AvalonDock.ResizingPanel     Orientation$ Vertical=�.+�  $ Vertical=�.+�  AvalonDock.DocumentPane    AvalonDock.DockablePane  	   ResizeHeight$		 250 �.@�   AvalonDock.DockableContent  -   
  Name$
 	eggoutput��  AvalonDock.ManagedContent   Title$ Output��.���� -   $��
textOutBox�� �� 
IsReadOnly .  �� AcceptsReturn . $ �� HorizontalScrollBarVisibility$
 Auto=�" �� VerticalScrollBarVisibility$
 Auto=�