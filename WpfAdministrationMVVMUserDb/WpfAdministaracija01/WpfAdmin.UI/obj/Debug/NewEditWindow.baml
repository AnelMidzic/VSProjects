   M S B A M L   `   `   `  ����F  BWpfAdmin.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAdmin.UIWpfAdmin.UI  5   	       WpfAdmin.UI.NewEditWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfAdmin.UI     5   	   -   5        $	��300��5   '   $	��300��64     � Title  6	   �� *WindowTitle+.��5
      �� $��Center=�6   $��Center=�6.   .+�5   
   �� -   5         ��Name$ label��5      $��Username��6   �� 5   
   -   5         ��Name$ firstNameTxtBox��5   Z   $
��Left=�6s   $��23��6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��165��6�   $��0q�6�   $��0,0,0,10q�6�   ��6   �� *CurrentUser.UserName+" �� ValidatesOnNotifyDataErrors . .��6�   5      �� 5   
   -   5        $ label1��5      $��Password��6    �� 5   
   -   5        $ lastNameTxtBox��5   Z   $
��Left=�6r   $��23��6�   $
 Wrap=�6�   $	��Top=�6�   $	��165��6�   $��0,0,0,10q�6�   ��6   �� *CurrentUser.UserPass+ . 6�   �� 5   
   -   5        $ label2��5      $��Is Administrator��6    �� 5   
   -   5         ��Name$ 	CheckBox1��5      $��CheckBox��6&   6U   �� 5   
   -   5        $��TextBoxAdmin��5      $
��Left=�6m   $	��Top=�6�   $��23��6�   $	��165��6�   $��0,0,0,10q�6�   ��6&   �� *CurrentUser.IsAdmin+ . 6�   �� 5   
   -	   5         ��Name$ button��5   1   $
��Save��6A   $��Center=�6P   $	��Top=�6m   $��75��6�   ��6   �� *SaveCommand+6�   5      5      