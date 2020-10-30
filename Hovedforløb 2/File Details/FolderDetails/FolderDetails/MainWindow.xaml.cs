using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FolderDetails
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Obj rootObj;
        private bool ViewDocking = false,
            DarkThemeEnabled = false;
        public MainWindow() => InitializeComponent();

        #region MenuItems_Click
        private void OpenFolder_Click(object sender, RoutedEventArgs e)
        {
            TreeViewContainer.Items.Clear();
            FolderSelect();
            if (rootObj is null) return;
            rootObj.SetSubDirectories();
            TreeViewContainer.SelectedItemChanged += TreeViewContainer_SelectedItemChanged;
            TreeViewContainer.Items.Add(SetBranches(rootObj));

        }

        private void ChangeAppearance()
        {
            if (ViewDocking)
            {
                MenuButton.Background = Brushes.White;
                MenuPanel.Background = Brushes.Red;
                StatusLinePanel.Background = Brushes.Chocolate;
                TreeViewContainer.Background = Brushes.Orange;
                ItemContentPanel.Background = Brushes.Yellow;
                lblItemContentTitle.Background = Brushes.Lime;
                lblItemContentName.Background = Brushes.Green;
                lblItemContentExtensionTitle.Background = Brushes.DodgerBlue;
                lblItemContentExtension.Background = Brushes.Blue;
                lblItemContentCreatedTitle.Background = Brushes.Magenta;
                lblItemContentCreated.Background = Brushes.DarkMagenta;
                lblItemContentLastModifiedTitle.Background = Brushes.LightGray;
                lblItemContentLastModified.Background = Brushes.Gray;
                lblItemContentSizeTitle.Background = Brushes.Black;
                lblItemContentSizeTitle.Foreground = Brushes.White;
                lblItemContentSize.Background = Brushes.White;
                lblItemContentSize.Foreground = Brushes.Black;
            }
            else if (!DarkThemeEnabled)
            {
                MenuButton.Background = Brushes.White;
                MenuButton.Foreground = Brushes.Black;
                MenuPanel.Background = Brushes.White;

                foreach (MenuItem item in MenuButton.ItemContainerGenerator.Items)
                {
                    item.Background = Brushes.White;
                    item.Foreground = Brushes.Black;
                }

                StatusLinePanel.Background = Brushes.White;
                lblItemContentPath.Foreground = Brushes.Black;
                TreeViewContainer.Background = Brushes.White;
                TreeViewContainer.Foreground = Brushes.Black;
                ItemContentPanel.Background = Brushes.White;
                lblItemContentTitle.Background = Brushes.White;
                lblItemContentTitle.Foreground = Brushes.Black;
                lblItemContentName.Background = Brushes.White;
                lblItemContentName.Foreground = Brushes.Black;
                lblItemContentExtensionTitle.Background = Brushes.White;
                lblItemContentExtensionTitle.Foreground = Brushes.Black;
                lblItemContentExtension.Background = Brushes.White;
                lblItemContentExtension.Foreground = Brushes.Black;
                lblItemContentCreatedTitle.Background = Brushes.White;
                lblItemContentCreatedTitle.Foreground = Brushes.Black;
                lblItemContentCreated.Background = Brushes.White;
                lblItemContentCreated.Foreground = Brushes.Black;
                lblItemContentLastModifiedTitle.Background = Brushes.White;
                lblItemContentLastModifiedTitle.Foreground = Brushes.Black;
                lblItemContentLastModified.Background = Brushes.White;
                lblItemContentLastModified.Foreground = Brushes.Black;
                lblItemContentSizeTitle.Background = Brushes.White;
                lblItemContentSizeTitle.Foreground = Brushes.Black;
                lblItemContentSize.Background = Brushes.White;
                lblItemContentSize.Foreground = Brushes.Black;
            }
            else
            {
                var DarkOne = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                var DarkTwo = new SolidColorBrush(Color.FromRgb(51, 51, 51)); ;
                var DarkThree = new SolidColorBrush(Color.FromRgb(69, 69, 69));

                foreach (MenuItem item in MenuButton.ItemContainerGenerator.Items)
                {
                    item.Background = DarkTwo;
                    item.Foreground = Brushes.White;
                }

                MenuButton.Background = Brushes.Black;
                MenuButton.Foreground = Brushes.White;

                lblItemContentPath.Foreground = Brushes.White;
                MenuPanel.Background = DarkOne;
                StatusLinePanel.Background = DarkOne;

                TreeViewContainer.Background = DarkTwo;
                TreeViewContainer.Foreground = Brushes.White;
                ItemContentPanel.Background = DarkThree;

                lblItemContentTitle.Background = DarkThree;
                lblItemContentTitle.Foreground = Brushes.White;

                lblItemContentName.Background = DarkThree;
                lblItemContentName.Foreground = Brushes.White;

                lblItemContentExtensionTitle.Background = DarkThree;
                lblItemContentExtensionTitle.Foreground = Brushes.White;

                lblItemContentExtension.Background = DarkThree;
                lblItemContentExtension.Foreground = Brushes.White;

                lblItemContentCreatedTitle.Background = DarkThree;
                lblItemContentCreatedTitle.Foreground = Brushes.White;

                lblItemContentCreated.Background = DarkThree;
                lblItemContentCreated.Foreground = Brushes.White;

                lblItemContentLastModifiedTitle.Background = DarkThree;
                lblItemContentLastModifiedTitle.Foreground = Brushes.White;

                lblItemContentLastModified.Background = DarkThree;
                lblItemContentLastModified.Foreground = Brushes.White;

                lblItemContentSizeTitle.Background = DarkThree;
                lblItemContentSizeTitle.Foreground = Brushes.White;

                lblItemContentSize.Background = DarkThree;
                lblItemContentSize.Foreground = Brushes.White;
            }
        }
        private void ViewDocking_Click(object sender, RoutedEventArgs e)
        {
            ViewDocking ^= true;
            ChangeAppearance();
        }
        private void ToggleDarkmode_Click(object sender, RoutedEventArgs e)
        {
            DarkThemeEnabled ^= true;
            ChangeAppearance();
        }
        #endregion

        private TreeViewItem SetBranches(Obj root)
        {
            TreeViewItem temp = new TreeViewItem() { Header = root.Name };

            foreach (Obj child in root.Children)
                if (child.Children != null)
                {
                    TreeViewItem childBranches = SetBranches(child);
                    childBranches.Tag = child.Path;
                    temp.Items.Add(childBranches);
                }
            return temp;
        }

        #region SelectedItemChanged
        private void TreeViewContainer_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            string Header = (TreeViewContainer.SelectedItem as TreeViewItem).Header.ToString();
            Obj SelectedItem = rootObj.Name == Header ? rootObj : FindObj(rootObj, Header);
            if (!SelectedItem.IsFile) return;
            FileInfo selectedFile = new FileInfo(SelectedItem.Path);

            //Change display
            lblItemContentCreated.Content = selectedFile.CreationTime;
            lblItemContentName.Content = selectedFile.Name; 
            lblItemContentExtension.Content = selectedFile.Extension;
            lblItemContentLastModified.Content = selectedFile.LastWriteTime;
            lblItemContentSize.Content = selectedFile.Length / 1000 + " KB";
            lblItemContentPath.Content = SelectedItem.Path;
        }
        private Obj FindObj(Obj child, string Header)
        {
            Obj found = child.Children.Find(c => c.Name == Header);
            if (found != null)
                return found;
            foreach (var c in child.Children)
            {
                found = FindObj(c, Header);
                if (found != null)
                    return found;
            }
            return null;
        }
        #endregion

        private void FolderSelect()
        {
            using (var fbd = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = fbd.ShowDialog();

                if (result.ToString() == "OK")
                {
                    rootObj = new Obj(System.IO.Path.GetFileName(fbd.SelectedPath), fbd.SelectedPath);
                }
            }
        }
    }
}
