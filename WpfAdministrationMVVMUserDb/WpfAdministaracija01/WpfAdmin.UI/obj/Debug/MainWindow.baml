   M S B A M L   `   `   `  ����J  FAdmin.ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:Admin.ViewModel;assembly=Admin.ViewModelAdmin.ViewModel  5   	   F BWpfAdmin.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAdmin.UIWpfAdmin.UI 5   	      WpfAdmin.UI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   M
view_model6clr-namespace:Admin.ViewModel;assembly=Admin.ViewModel     5   	   +localclr-namespace:WpfAdmin.UI     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5      � .+�5   
   �� $��User:��6   $
��Left=�6"   $��	78,80,0,0q�6=   $	��Top=�6P   $	��195��6h   $	��163��6u   .��5      �� .+�5      �� $��	User name��6   $
��Left=�6,   $	��Top=�6G   �� 5      $
��Left=�6c   $	��Top=�6~   $	��145��6�   $
��Bold"�6�   ��6   �� *CurrentUser.UserName+" �� ValidatesOnNotifyDataErrors .  6�   �� 5      $��User password��6   $
��Left=�60   $	��Top=�6K   �� 5      $
��Left=�6c   $	��Top=�6~   $	��145��6�   $
��Bold"�6�   ��6   �� *CurrentUser.UserPass+ .  6�   �� 5      $��Is Admin��6   $
��Left=�6+   $	��Top=�6F   �� 5      $
��Bold"�6c   ��6   �� *CurrentUser.IsAdmin+ .  .��6u   5      5      5      �� 5   
   $��Center=�6�   $	��210��6�   $��Center=�6�   $	��347��6�   $��306,80,139,129q�6�   $��2q�6  
���   ���6   �� *
UserList+ .   �� SelectedItem 6V   �� *CurrentUser+ .  ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� ��6    ��  �� Path$ UserName�6D   �� 5      ��6    �� $ UserPass�6D   5      5      5       �� 5!   
   -   5         ��Name$ 
ButtonEdit��5!      $
��Edit��6%   $
��Left=�64   $��306,337,0,0q�6O   $	��Top=�6d   $��75��6|   6�   �� 5"   
   -   5        $ 	ButtonNew��5"      $	��New��6$   $
��Left=�62   $��442,337,0,0q�6M   $	��Top=�6b   $��75��6z   6�   �� 5#   
   -   5        $ ButtonDelete��5#   3   $��Delete��6I   $
��Left=�6Z   $��578,337,0,0q�6u   $	��Top=�6�   $��75��6�   ��6   �� *DeleteCommand+6�   5%      5&      