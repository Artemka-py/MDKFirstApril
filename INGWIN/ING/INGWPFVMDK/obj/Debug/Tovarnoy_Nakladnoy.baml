   M S B A M L   `   `   `  ����A  =INGWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:INGWPFINGWPF  5   	       INGWPF.Tovarnoy_Nakladnoy   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:INGWPF     5   	   -   5        $��Tovarnoy_NakladnoyWPF��5   $     � Title$)  #Товарные накладные��6	   $	��800��6A   $	��800��6N   .��5	      �  � RowDefinitions 5
   
   �� 5      6   �� 5   
   6   �� 5   
   6   �� 5   
   6   �� 5   
   6   �� 5   
   6   �� 5   
   6   �� 5   
   6   �� 5   
   6   �� 5   
   6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� -   5        $��lblTitle��5      $)��#Товарная накладная��6    $��0��6=   $��0��6J   $��5��6Z   $��Center=�5      $��Center=�62   $��30(�6V   6f   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgTovarnoy_NakladnoyWPF��5      $��1��62      
IsReadOnly . $��0��6Q   $��4��6a   $��3��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6"      AutoGenerateColumns . 5      A� 5    
   $��4��6   $��0��6#   .+�5!      �� .+�5"      �� -   5        $ ��lblNazv_Tovarnoy_Nakladnoy��5"      $=��7Навзвание товарной накладной:��6:   $��5��6b   $��20(�6o   6   �� 5#      $��1q�6   
���   �._�5$      �� -   5        $��tbNazv_Tovarnoy_Nakladnoy��5$      $��2��6?   $��30��6L   ��5%      �� *&$SelectedItem.Nazv_Tovarnoy_Nakladnoy+ �� ElementName$ dgTovarnoy_NakladnoyWPF��5&   J   5'      5(      5)      A� 5*   
   $��4��6   $��1��6#   .+�5+      �� $��0��6   .+�5,      �� -   5        $!��lblNomer_Tovarnoy_Nakladnoy��5,      $5��/Номер товарной накладной:��6;   $��5��6_   $��20(�6l   6|   �� 5-      $��1q�6   
���   �._�5.      �� -   5        $ ��tbNomer_Tovarnoy_Nakladnoy��5.      $��2��6@   $��30��6M   ��5/      �� *'%SelectedItem.Nomer_Tovarnoy_Nakladnoy+$ dgTovarnoy_NakladnoyWPF��50   J   51      52      53      A� 54   
   $��5��6   $��1��6#   .+�55      �� $��0��6   .+�56      �� -   5        $��lblName_Sotrudnika��56      $(��"Имена сотрудников:��62   $��20(�6O   6_   �� 57      -	   5        $��cbName_Sotrudnika��57      $��30��64    �� SelectedValue 6@   �� *SelectedItem.Sotrudnika_ID+$ dgTovarnoy_NakladnoyWPF��58   A   59      5:      A� 5;   
   $��5��6   $��1��6#   $��1��67   .+�5<      �� $��0��6   .+�5=      �� -
   5        $��lblNomer_of_Dogovor��5=      $"��Номер договора:��63   $��20(�6M   6]   �� 5>      -   5        $��cbNomer_of_Dogovor��5>      $��30��65    6A   �� *SelectedItem.Dogovor_ID+$ dgTovarnoy_NakladnoyWPF��5?   A   5@      5A      A� 5B   
   $��8��6   $��3��6#   .+�5C      �� .+�5D      �� -   5        $%��btTovarnoy_NakladnayaInsertType��5D      $#��Добавить запись��6@   $��25��6Z   6�   �� 5E      -   5        $%��btTovarnoy_NakladnayaUpdateType��5E      $#��Изменить запись��6@   $��25��6Z   6�   �� 5F      -   5         ��Name$% btTovarnoy_NakladnayaDeleteType��5F      $!��Удалить запись��6B   $��25��6[   6g   5G      5H      �� 5I   
   -   5        $��btClose��5I      $��Закрыть��6    $��9��62   $��3��6?   $��50��6O   6s   A� 5J   
   $��9��6   $��2��6#   $��0��67   .+�5K      �� $��1��6   .+�5L      �� -   5        $��tbSearch��5L      $��30��6+   69   �� 5M      -   5        $��btSearch��5M      $��
Поиск��6)   $��30��69   $	��Top=�6E   6v   �� 5N      -   5        $��	chbFilter��5N      $ ��Отфильтровать��6,   $��Center=�6D   $��10(�6_   6�   5O      5P      5Q      5R      