   M S B A M L   `   `   `  ????D  @ClientGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ClientGUI	ClientGUI  5          ClientGUI.JobsPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:ClientGUI     5        N? Title$  JobsPage??5	      .??5      ? .+?5   
   ?? $??Job List??6   $??Center=?6#   $??0,44,0,0q?6@   $	??Top=?6R   $??24(?6j   $??Montserrat Black)?6x   
???????6?   ?? 5   
   -   5         ??Name$ Id??5      $?? ??6   $
??Left=?6'   $??	33,40,0,0q?6B   $	??Top=?6U   $	??120??6m   $??24??6y   
???????6?   ?? 5   
   -   5        $
 Name??5      $?? ??6   $
??Left=?6)   $??
173,28,0,0q?6D   $	??Top=?6X   $	??120??6p   $??24??6|   
???????6?   ?? 5   
   -   5         ??Name$ Result??5      $
??Left=?6"   $??233,356,0,0q?6=    ?? TextWrapping$
 Wrap=?6R   $	??Top=?6f   $	??142??6~   $??34??6?   $??18(?6?   ?? 5   
   -   5         ??Name$ AddJob_Copy??5      $??Upload??6&   ???	#FFE69500$
??Left=?6N   $??463,365,0,0q?6i   $	??Top=?6~    J? RenderTransformOrigin$ 0.488,1.425&?6?   $??25??6?   $??96??6?   ???	#FFFFD8A7???	#FFFFF2DC$??Montserrat Black)?6  ?? 5   
   -   5        $ userToken_Copy??5      $??
Results : ??6(   $
??Left=?6=   $??
93,356,0,0q?6X   $	??Top=?6l   $??90??6?   $??33??6?   $??16(?6?   
???????$??Montserrat Black)?6?   ?? 5   
   -   5        $ AddJob_Copy1??5      $??Add Job??6'   ???	#FF8BFF00$
??Left=?6P   $??604,365,0,0q?6k   $	??Top=?6?   $ 0.488,1.425&?6?   $??25??6?   $??96??6?   ???	#FF149104???	#FFE8FFBE$??Montserrat Black)?6  ? 5   
   -   5         ?Name$ ProgressBar1??5      $
??Left=?6,   $??14??6G   $??525,410,0,0q?6S   $	??Top=?6h   $	??100??6?   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$	 job??5   /      AutoGenerateColumns .  $??Center=?6<   $	??230??6Y   $??Center=?6f   $	??668??6?   	   CanUserAddRows	 .  
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID??6%      
Visibility$ Hidden=?61      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6o   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6X   ?? *Id+6o     5      $ Description??6%    . $	 670 6l    6L   ?? *description+6l     5      $
 Name??6%   $ Hidden=?63    . $	 180 6s    6Z   ?? *name+6s   5      5!      5"      