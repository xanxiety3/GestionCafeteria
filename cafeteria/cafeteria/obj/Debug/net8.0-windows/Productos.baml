   M S B A M L   `   `   `  ����D  @cafeteria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:cafeteria	cafeteria  5   	       cafeteria.Productos   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:cafeteria     5   	     � Title$  	Productos��5   
   $	��760��6   $
��1500��6)    � Icon$ logo.png��66    � WindowStartupLocation$ CenterScreen=�6G    � 
ResizeMode$ NoResize=�6m   .��5	      � $��Center=�6   $	��Top=�6(   $	��740��6@   $
��1500��6M   $��0,10,0,0q�6Z    � ColumnDefinitions 5
   
   �� 5      $
��361* �6   �� 5      $
��552* �6   �� 5      $
��587* �6    � RowDefinitions 5   
   �� 5      $��86 �6   �� 5      $
��107* �6   �� 5      $��2* �6   .+�5   
   �� $��94��6   
���   �$��Center=�6/   ���	#FF009E00$��	10,0,10,0q�6[   $��3��6n   �� 5   
   $��Center=�6   $	��646��61   $��Center=�6>   $	��340��6Y   ���	#FF9CA4A8$��1��6v   �� 5   
   $��Ventas��6   $��Center=�6#   $��	0,181,0,0q�6@   $	��Top=�6S   $��49��6k   $	��237��6w    J� RenderTransformOrigin$ 0.496,0.578&�6�   ���	#FF009E00$��1��6�   $��20(�6�   ��6�   Z� 6�   �� 5   
   $��      Proveedores��6   $��Center=�6-   $	��Top=�6J   $��49��6b   $	��238��6n   $ 0.5,0.5&�6z    J� OpacityMask �	#FF009E00���	#FF009E00$��	0,261,0,0q�6�   $��1��6�   $��20(�6   ��6�   Z� 6   �� 5    
   -   5        $��btnprov��5    3  $��      Trabajadores��6   $��Center=�6.   $	��Top=�6K   $��49��6c   $	��238��6o   $ 0.5,0.5&�6{    �	#FF009E00���	#FF009E00$��	0,352,0,0q�6�   $��Center=�6�   $��1��6  $��20(�6%  ��6  Z� 63  �� 5"   
   $��Salir��6   $��Center=�6!   $	��Top=�6>   $��49��6V   $	��238��6b   $ 0.5,0.5&�6n    �	#FF009E00���	#FF009E00$��	0,450,0,0q�6�   $��1��6�   $��20(�6�   ��6�   Z� 6�   �� 5$   
   $��MENÚ��6   $��Black"�6   $��30��62   $
��16px(�6>   $	��Top=�6N   $��130,115,166,0q�6f   ���	#FFFFFDFD$��1��6�   �� 5%   
   $��78,-10,114,553q�6   $��2��6)   $��logo.png��6:   6N   �� 5&   
   $
��Left=�6   $��50��6+   $��
91,181,0,0q�67   $	��Top=�6K   $��46��6c   $��1��6o   $��venta 1.png��6|   �� 5'   
   $
��Left=�6   $��55��6+   $��
88,263,0,0q�67   $	��Top=�6K   $��47��6c   $��1��6o   $��proveedores.png��6|   �� 5(   
   $
��Left=�6   $��59��6+   $��	35,17,0,0q�67   $	��Top=�6J   $��62��6b   $��comestibles 1.png��6m   $��2��6�   �� 5)   
   $
��Left=�6   $��60��6+   $��
351,16,0,0q�67   $	��Top=�6K   $��62��6c   $��inventario 1.png��6n   $��1��6�   �� 5+   
   $
��Left=�6   $��60��6+   $��
92,450,0,0q�67   $	��Top=�6K   $��46��6c   $��1��6o   $��	salir.png��6|   �� 5,   
   $��
INVENTARIO��6   $��Black"�6%   $��30��68   $��18(�6D   $	��Top=�6R   $��
415,31,0,0q�6j   ���	#FFFFFDFD$��Center=�6�   $��Center=�6�   $
��Left=�6�   $	��154��6�   $��1��6  $��2��6  �� 5-   
   $��49��6   $��72,352,215,0q�6   $	��Top=�62   $��tendera 1.png��6J   $��1��6a   �� 5.   
   $��21,26,30,26q�6   $��1��6(   $��
Productos ��65   $��2,2,2,2q�6I   
���   �$��Nunito ExtraBold)�6w   $��2��6�   $��1��6�   &   System.Windows.Controls.DataGrid  5/   
   -   5          Name$ datagProductos��5/      $��35,54,51,45q�6,   $��1��6A   $��1��6N   	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 6^   
   AutoGenerateColumns$
 False��6q      CanUserAddRows$ False��6�   $��2��6�    � 	Resources 50      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Property �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�   '        '  t     �� 51      "  6   .�52      ��  � ��$ Center=�6<   �� 53       � ��$ Center=�6A   54      �� 55      "  6   .�56      ��  � ��$ Center=�6C   �� 57       � ��$
 Bold"�63   58      59         Columns 5:      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width$ * 61      
Visibility$ 	Collapsed=�6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *id+6R     5<      $ Codigo Referencia��6%   $ * 6@    6J   �� *
referencia+  5=      $ Nombre��6%   $ * 65    6?   �� *
producto+  5>      $ Precio��6%   $ * 65    6?   �� *valor+  5?      $ Cantidad��6%   $ * 67    6A   �� *
cantidad+  5@      $ Descripción��6%   $ * 6:    6D   �� *	detalle+  5A      $ Estado��6%   $ * 65    6?   �� *estado+  5B      $ 	Categoria��6%   $ * 68    6B   �� *	categoria+  5C      $ Fecha Vencimiento��6%   $ * 6@    6J   �� *fechaVencimiento+4  .System.Windows.Controls.DataGridTemplateColumn  5D      $ Gestion��6)   $	 120 6:      CellTemplate 5E      �� 5F      .R�5G      ��  �� Orientation$ 
Horizontal=�6)   .+�5H   "   ��  ��Name$ 
BtonEditar��6)   $��5q�6=   $��50��6H   $��30��6S   ��6_   �� *id+.��5I   &   �� $��editarproducto.png��6,   5J   #   �� 5K   "   $ btonEliminar��6)   $��5q�6?   $��50��6J   $��30��6U   .��5L   &   �� $��eliminar-producto63.png��6,   5M   #   5N      5O      5Q      5S      5T      5U      