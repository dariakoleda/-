   M S B A M L   `   `   `  ����H  DCourseProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CourseProjectCourseProject  5   	       CourseProject.Tables   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CourseProject     5   	   -   5          � Title$  Tables��5   	    � WindowStartupLocation$ CenterScreen=�5	   	   $	��700��6.   $
��1200��6;   .��5      � .+�5   
   o� -   5         o�Name$ menuMain��5      $��20��6!   $	��Top=�6-   ��5      �� 5      .R�5      ]� $��Stretch=�6    5      .@�5      m� -   5         m�Name$ menuFile��5      $��Файл��6)   .@�5      m� -   5        $ menuReports��5      $��Отчёты��60   6@   5      m� 5      -   5        $ menuSettings��5      $��Настройки��6-   .@�5      m� -   5        $ menuSettingsRoles��5      $��Изменить роль��66   6M   5      m� 5      -   5        $ 	menuAbout��5      $��О программе��6*   .@�5      m� -   5        $ 
menuManual��5      $��Справка��6/   6@   5      m� 5      -	   5        $ menuUser��5      $
��👤��6)   $��Right=�6L   $��16(�6h   5      &   System.Windows.Controls.DataGrid  5   
   -
   5          Name$ dataGridMain��5      $��200,100,460,100q�6)   $��Stretch=�6B      AutoGenerateColumns . $	��300��6y      CanUserDeleteRows .     CanUserAddRows .  "   VerticalScrollBarVisibility$
 Auto=�6�     5   
   -   5        $ dataGridTopics��5      $��150,100,30,100q�6+   $��Right=�6C    . $	��400��6z   	   
IsReadOnly	 . 
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 * 6�   �� 5!   
   $��Год:��6   $
��Left=�6   $��	30,80,0,0q�6:   $	��Top=�6M   $��16(�6e   $��0q�6s   �� 5"   
   -   5         ��Name$ comboBoxYear��5"      $��30, 100, 0, 0q�6)   $
��Left=�6@   $	��Top=�6[   $	��150��6s   �� 5$   
   $��Месяц:��6   $
��Left=�6!   $��
30,130,0,0q�6<   $	��Top=�6P   $��16(�6h   $��0q�6v   �� 5%   
   -   5        $ comboBoxMonth��5%      $��30, 150, 0, 0q�6*   $
��Left=�6A   $	��Top=�6\   $	��150��6t   �� 5'   
   $��Группа:��6   $
��Left=�6"   $��
30,180,0,0q�6=   $	��Top=�6Q   $��16(�6i   $��0q�6w   �� 5(   
   -   5        $ comboBoxGroup��5(      $��30, 200, 0, 0q�6*   $
��Left=�6A   $	��Top=�6\   $	��150��6t   �� 5*   
   -   5         ��Name$ 
buttonShow��5*      $��30, 230, 0, 0q�6%   $
��Left=�6<   $	��Top=�6W   $	��150��6o   $��Показать��6{   6�   A� 5,   
   -   5         A�Name$ uniformGridButtons��5,      $��200,0,30, 30q�62   $��Bottom=�6H    A� Columns$ 2��6c    A� Rows$ 1��6o   $��30��6x   .+�5-      �� -   5        $ buttonSubmit��5-      $/��)Подтвердить изменения��6+   $��16(�6K   $��30��6t   $	��Top=�6�   �� 5.      -   5        $ buttonInsert��5.      $#��Добавить данные��6+   $��16(�6E   6S   5/      �� 50   
   -   5         ��Name$ labelTeacher��50      $�� ��6&   $��20(�61   $
��Left=�6?   $	��Top=�6Z   $��200, 60, 0, 0q�6r   �� 51   
   -   5        $ buttonUpdate��51      $	��⟲��6'   $��16(�63   
������ $��0q�6Z   $��Right=�6�   $	��Top=�6�   $��0, 70, 30, 0q�6�   $
��Bold"�6�   �� 52   
   -   5         ��Name$ textBoxSearch��52      $��0,70, 230,100q�6)   $��Right=�6@   $	��Top=�6\   $	��200��6t   $��16(�6�   �� 53   
   -   5        $ buttonSearch��53      $
��🔎��6'   $��0,70, 230,100q�64   $��Right=�6K   $	��Top=�6g   $��30��6   $��16(�6�   
������ $��0q�6�   6�   54      55      