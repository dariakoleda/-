   M S B A M L   `   `   `  ����H  DCourseProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CourseProjectCourseProject  5   	   &     CourseProject.Inserts.InsertNote   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CourseProject     5   	     � Title$"  Запись в журнал��5   	   $	��440��6!   $	��300��6.    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      � .+�5   
   �� $��Студент: ��6   $
��Left=�6%   $��	30,30,0,0q�6@   $	��Top=�6S   $��16(�6k   $��0q�6y   �� 5   
   -   5         ��Name$ comboBoxStudent��5      $��
30,50,30,0q�6,   $	��Top=�6@   $��14(�6X    �� 
IsReadOnly . 6f   �� 5   
   $��
Дата: ��6   $
��Left=�6"   $��	30,80,0,0q�6=   $	��Top=�6P   $��16(�6h   $��0q�6v   �� 5   
   -   5        $ comboBoxDate��5      $��30,100,30,0q�6)   $	��Top=�6>   $��14(�6V    . 6d   �� 5   
   $��Отметка: ��6   $
��Left=�6%   $��
30,130,0,0q�6@   $	��Top=�6T   $��16(�6l   $��0q�6z   �� 5   
   -   5         ��Name$ textBoxMark��5      $��30,150,30,0q�6'   $	��Top=�6<   $��14(�6T    �� 	MaxLength$ 2��6b   �� 5   
   -   5         ��Name$ buttonInsert��5      $��Добавить��6'   $��Bottom=�6:   $��30, 0, 30, 30q�6U   $��18(�6l    �� 	IsDefault . 6�   5      5      