   M S B A M L   `   `   `  ????D  @ClientGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ClientGUI	ClientGUI  5          ClientGUI.ServerPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:ClientGUI     5        N? Title$  
ServerPage??5	      .??5      ? .+?5   
   ?? $??Servers??6   $??Center=?6"   $??0,19,0,0q?6?   $	??Top=?6Q   $??24(?6i   $??Montserrat Black)?6w   
???????6?   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ servers??5   /      AutoGenerateColumns .  $??Center=?6@   $	??245??6]   $??0,77,0,0q?6j   $	??Top=?6|   $	??780??6?      CanUserAddRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID??6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   ?? *Id+6g     5      $
 Name??6%    . $	 250 6^    6E   ?? *name+6l     5      $ 
IP Address??6%    . $	 380 6b    6K   ?? *ip+6p     5      $
 Port??6%    . $	 100 6^    6E   ?? *port+6l   5      ?? 5   
   -   5        	 ??Name$	 
goRegister??5      $??
Add Server??6%   ???	#FFE69500$??Center=?6Q   $??	0,368,0,0q?6n   $	??Top=?6?   
 J? RenderTransformOrigin$
 0.488,1.425&?6?   $??25??6?   $??96??6?   ???	#FFFFD8A7???	#FFFFF2DC$??Montserrat Black)?6  5      5      