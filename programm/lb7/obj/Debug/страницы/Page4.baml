   M S B A M L   `   `   `  ����  lb7     lb7.страницы.Page4   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  Page4��5      
 J� Uid$ 4��6   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��418* �6   �� 5      $
��203* �6    � RowDefinitions 5   
   �� 5      $��7* �6   �� 5      $��9* �6   .+�5   
   �� -   5         ��Name$ image��5      $#��/lb7;component/media/Auto.png��6   $��1��6F   � 5   
   $��0,0,6,0q�6   $��2��6    $��2��61    5      �� 5      �� 5      $��68 �6     5      �� 5      $��0* �6#   �� 5      $	��61* �6#   �� 5      $	��21* �6#   �� 5      $
��123* �6#   .+�5!      &   System.Windows.Controls.DataGrid  -   5          Name$ dGrid��5!      $��5,25,1,2q�6&   $��2��68      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6H      AutoGenerateColumns .     EnableRowVirtualization . 	   
IsReadOnly	 . 
   RowDetailsVisibilityMode$
 VisibleWhenSelected=�5"         DataGridStyle2#���   6:   ���	#B2F0F0F0$��2��6�      HeadersVisibility$ Column=�6�   ��6�   Z�    Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      -   5        3/ColumnРегистрационный_номер��,  &System.Windows.Controls.DataGridColumn   Header$/ )Регистрационный номер��5%      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5$   O   �� *+)Регистрационный_номер+5%        5&      -   5        ColumnМарка_авто��$ Марка авто��5'       5&   C   �� *Марка_авто+5'        5(      -   5        !ColumnДата_выпуска��$ Дата выпуска��5)       5(   E   �� *Дата_выпуска+5)        5*      -   5        73ColumnВодителиТабельный_номер��$) #Табельный водителя��5+       5*   P   �� */-ВодителиТабельный_номер+5+      5-      �� 5.      $2��,Операции с автомобилями��6   $��5,0,0,0q�66   $��2��6G   $
��Left=�6W   $	��181��6r   $��25��6~   $	��Top=�6�   $��2��6�   ���	#FF5D99936�   � 5/      $��8,3,4,0q�6   $��2��6$   $��1��64   $��2��6A    50      �� 51      $
��137* �6'   �� 52      $
��151* �6'   �� 53      $
��135* �6'   .+�55      �� -   5         ��Name$ изменить_авто��55      $��Изменить��60   $��	0,0,0,2.8q�6C   ���	#FFD3CAA2
�������
�������$��1��6�     buttonSetupStyle#���  6�   $��3q�6�   �� 56      -   5        $ добавить_авто��56      $��Добавить��60   $��	0,0,4.8,3q�6C   ���	#FF89B088
�������
�������#���  6�   $��3q�6�   �� 57      -	   5        $ удалить_авто��57      $��Удалить��6/   $��5,0,0,3q�6A   ���	#FF744A4A
�������
�������$��2��6�   #���  6�   $��3q�6�   58      �� 59      -
   5        $) #Обновить_почистить��59      $#��Обновить/Чистка��61   $��5,3,14,3q�6K   ���	#FF9A92AC
�������
�������$��2��6�   $��1��6�   #���  6�   $��3,4,3,3q�6  (� 5:       (� StretchDirection$ UpOnly=�6   $��Right=�60   $��2��6L    (� Stretch$
 Fill=�6`   $��0,0,0,1q�6o   .��5;      � $
��Left=�6   $	��Top=�62   ���	#CCC1B5AE$	��158��6a   .+�5<      �� -   5         ��Name$ TbAutoNumber��5<      $��23��64   $��	5,25,14,0q�6@    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g   $��13.333(�6�    �� 	MaxLength$ 9��6�   ���	#B2FFFFFF��6  Z� �� 5=      -   5        $ tbMark��5=      $��22��6.   $��	5,66,14,0q�6:   $
 Wrap=�6M   $	��Top=�6a   $��13.333(�6�   ���	#B2FFFFFF��6�   Z� 6�   �� 5>      $"��Рег. номер авто:��6   $	��Top=�67   $��17��6O   $
��Left=�6[   $	��140��6v   ���	#FF5D9993$��5,8,0,0q�6�   $��0q�6�   $
��Bold"�6�   $��Italic$�6�   $��13.333(�6�   ���	#FF701D1D6�   (  "System.Windows.Controls.DatePicker  5?      -   5          Name$ dataPick��5?   !   $
��Left=�63   $��
4,105,0,99q�6N   $	��140��6b   $��18.667(�6n   ��6�   Z� �� 5@      $��Марка авто:��6   $	��Top=�62   $��18��6J   $
��Left=�6V   $	��124��6q   ���	#FF5D9993$��5,48,0,0q�6�   $��0q�6�   $
��Bold"�6�   $��Italic$�6�   $��13.333(�6�   ���	#FF701D1D6�   �� 5A      $��Дата выпуска:��6   $	��Top=�64   $��18��6L   $
��Left=�6X   $	��124��6s   ���	#FF5D9993$��5,87,0,0q�6�   $��0q�6�   $
��Bold"�6�   $��Italic$�6�   $��13.333(�6�   ���	#FF701D1D6�   �� 5B      $��Таб. водителя:��6   $	��Top=�65   $��18��6M   $
��Left=�6Y   $	��134��6t   ���	#FF5D9993$��	5,157,0,0q�6�   $��0q�6�   $
��Bold"�6�   $��Italic$�6�   $��13.333(�6�   ���	#FF701D1D6�   �� 5C      -   5         ��Name$ comboBox��5C      $
��Left=�61   $��	5,175,0,0q�6L   $	��Top=�6_   $	��139��6w   ��6�   Z� 5D      5E      5F      �� 5G      $��14��6   $��1��6&   ���	#CC9A92AC$��2��6N   
�������$��3,0,0,0q�6s    J� Opacity$	 0.8Q�6�   5H      5J      5K      