   M S B A M L   `   `   `  ����H  DFolderDetails, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:FolderDetailsFolderDetails  5   	       FolderDetails.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:FolderDetails     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      ]� -   5         ]�Name$
 Main��5	      .+�5
   
   ]� -   5        $ 	MenuPanel��5
      $	��Top=�6'   $��20��6<   .+�5      �� 
���   �$��1q�6)   ._�5      o� $
��Left=�6     n� UsesItemContainerTemplate . .@�5      m� -   5         m�Name$ 
MenuButton��5      $
��Menu��63   .@�5      m� -   5        $��Open Folder��5   #   68   m� 5      -   5        $��View Docking��5   #   69   m� 5      -   5        $��Toggle Darkmode��5   #   6<   5      5      5      5      ]� 5   
   -   5        $ StatusLinePanel��5      $��Bottom=�6-   $��32��6E   .+�5      �� 
���   �$��1q�6)   ._�5      ]� .+�5      �� -   5         ��Name$ lblPath��5      $��Path:��6-   $��18(�6=   $
��Bold"�6K   $��Center=�6]   �� 5      -	   5        $ lblItemContentPath��5      $��18(�68   $��Right=�6F   5      5      5      ]� 5   
   -
   5        $ TreeViewMenuPanel��5      $
��Left=�6/   $	��255��6E   .+�5      R� -   5         R�Name$ TreeViewContainer��5      5       5!      ]� 5"   
   -   5        $ ItemContentPanel��5"      $��Right=�6.   .+�5#      �� 
���   �$��1q�6)   ]� 5$      -   5        $ FileNamePanel��5$      $	��Top=�6/   .+�5%      �� -   5        $ lblItemContentTitle��5%      $��Name: ��65   $��25(�6F   $
��Left=�6T   $
��Bold"�6j   $��87��6|   �� 5&      -   5        $ lblItemContentName��5&      $��25(�64   $��Right=�6B   5'      ]� 5(      -   5        $ FileExtensionPanel��5(      $	��Top=�64   .+�5)      �� -   5        $" lblItemContentExtensionTitle��5)      $��Extension: ��6>   $��25(�6T   $
��Left=�6b   $
��Bold"�6x   $	��130��6�   �� 5*      -   5        $ lblItemContentExtension��5*      $��25(�69   $��Right=�6G   5+      ]� 5,      -   5        $ FileCreatedPanel��5,      $	��Top=�62   .+�5-      �� -   5        $  lblItemContentCreatedTitle��5-      $��	Created: ��6<   $��25(�6P   $
��Left=�6^   $
��Bold"�6t   $	��107��6�   �� 5.      -   5        $ lblItemContentCreated��5.      $��25(�67   $��Right=�6E   5/      ]� 50      -   5        $ FileLastModifiedPanel��50      $	��Top=�67   .+�51      �� -   5        $% lblItemContentLastModifiedTitle��51      $��Last Modified: ��6A   $��25(�6[   $
��Left=�6i   $
��Bold"�6   $	��177��6�   �� 52      -   5        $  lblItemContentLastModified��52      $��25(�6<   $��Right=�6J   53      ]� 54      -   5        $ FileSizePanel��54      $	��Top=�6/   .+�55      �� -   5        $ lblItemContentSizeTitle��55      $��Size: ��69   $��25(�6J   $
��Left=�6X   $
��Bold"�6n   $��62��6�   �� 56      -   5        $ lblItemContentSize��56      $��25(�64   $��Right=�6B   57      ]� 58      $	��Top=�6   59      5:      5;      