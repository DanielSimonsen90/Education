   M S B A M L   `   `   `  ����C  ?XMLintro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:XMLintroXMLintro  5   	       XMLintro.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:XMLintro     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   .+�5   
   ��  �� TextAlignment$ Center=�6   $��Center=�6+   $��1��6F   $��1��6V   
 � Tag$	 xml��6c   No file loaded6}   �� 5   
   $ Center=�6   $��Center=�6+   $��1��6F   $��2��6V   $	 xsl��6c   No file loaded6}   �� 5   
   $ Center=�6   $��Center=�6+   $��1��6F   $��3��6V   $	 xsd��6c   No file loaded6}   �� 5   
   -   5        $��2��5      $��1��6!   $	 xml��6D   .��6N   Load XML file6]   �� 5   
   -   5        $��2��5      $��2��6!   $	 xsl��6D   .��6N   Load XSL file6]   �� 5    
   -   5        $��2��5       $��3��6!   $	 xsd��6D   .��6N   Load XSD file6]   �� 5"   
   -   5         ��Name$ btnTransform��5"   g   $��2��6   $��1��6%   $��5��66   {�.  .��6}   	Transform6�   5#      5$      