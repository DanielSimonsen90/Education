using DanhoLibrary.Extensions;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Xsl;

namespace XMLintro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Dictionary<string, string> Files = new Dictionary<string, string>();
        private readonly Dictionary<string, TextBlock> TextBlocks = new Dictionary<string, TextBlock>();

        public MainWindow()
        {
            InitializeComponent();
            SetDictionary<Button, string>(Files, btn => string.Empty);
            SetDictionary<TextBlock, TextBlock>(TextBlocks, tb => tb);

            AllowDrop = true;
        }

        private void SetDictionary<ClassType, DictionaryOutput>
            (Dictionary<string, DictionaryOutput> dictionary, 
            Func<ClassType, DictionaryOutput> initialValue) 
            where ClassType : FrameworkElement
        {
            ((Grid)Content).Children //Grid's elements
                .OfType<ClassType>() //Sorted by ClassType
                .ToList() //List<ClassType>
                .Filter(element => !string.IsNullOrEmpty(element.Tag?.ToString())) //Since ClassType is a FrameworkElement, filter all those ClassTypes that have a .Tag
                .ForEach(element => dictionary.Add(element.Tag.ToString(), initialValue(element))); //Add element.Tag as dictionary item's key, and put dictionary item's value to initialValue callback value
        }

        protected override void OnDrop(DragEventArgs e)
        {
            string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
            List<string> files = new List<string>();

            foreach (string uri in data)
            {
                string[] split = uri.Split('\\');
                string file = split.Last();
                files.Add(file);

                string extension = file.Split('.')[1];

                Files.Set(extension, uri);
                TextBlocks[extension].Text = file;
            }

            UpdateTransformButton();

            StringBuilder sb = new StringBuilder();
            files.ForEach(file => sb.Append(file + "\n"));

            e.Handled = true;
            MessageBox.Show($"Following file{(files.Count > 1 ? "s" : "")} added:\n{sb}");
        }
        private void FileLoadClick(object sender, RoutedEventArgs e)
        {
            Button senderObj = (Button)sender;
            string senderTag = senderObj.Tag.ToString();

            OpenFileDialog dlg = new OpenFileDialog
            {
                DefaultExt = $".{senderTag}",
                Filter = $"{senderTag.ToUpper()} Files (*.{senderTag})|*.{senderTag}",
            };

            // Display OpenFileDialog by calling ShowDialog method 
            string fileResult = string.Empty, 
                text = "No file loaded";

            if (dlg.ShowDialog() == true)
            {
                fileResult = dlg.FileName;
                text = dlg.SafeFileName;
            }

            Files.Set(senderTag, fileResult);

            //Convert this.Content to Grid, find all TextBlocks as List<TextBlock>, find an item whose .Tag.ToString() matches senderObj.Tag.ToString()
            TextBlocks[senderTag].Text = text;

            UpdateTransformButton();
        }

        private bool Transformable
        {
            get
            {
                foreach (var kvp in Files)
                    if (string.IsNullOrEmpty(kvp.Value))
                        return false;
                return true;
            }
        }
        private void UpdateTransformButton() => btnTransform.IsEnabled = Transformable;
        private void Transform(object sender, RoutedEventArgs e)
        {
            // Enable XSLT debugging. 
            XslCompiledTransform xslt = new XslCompiledTransform(true);

            // Compile the style sheet.
            xslt.Load(Files["xsl"]);

            SaveFileDialog dlg = new SaveFileDialog()
            {
                DefaultExt = $".xml",
                Filter = $"XML Files (*.xml)|*.xml| HTML Files (*.html)|*.html",
                FileName = "result.xml"
            };

            bool? result = dlg.ShowDialog();
            if (!result.HasValue)
            {
                MessageBox.Show("Unable to get result! Please try again.", "Transformation Error");
                return;
            }

            // Execute the XSLT transform.
            FileStream outputStream = new FileStream(dlg.FileName, FileMode.Create); // Bemærk at Create overskriver!
            xslt.Transform(Files["xml"], null, outputStream);
            outputStream.Close();

            Validate(dlg);

            Process.Start(Files["xml"]);
        }
        private void Validate(SaveFileDialog outputFile)
        {
            XmlSchemaSet schema = new XmlSchemaSet();
            try { schema.Add("", Files["xsd"]); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            XmlReader reader = XmlReader.Create(outputFile.FileName);
            XDocument doc = XDocument.Load(reader);
            doc.Validate(schema, new ValidationEventHandler((sender, e) =>
            {
                XmlSeverityType type = XmlSeverityType.Warning;
                if (Enum.TryParse<XmlSeverityType>("Error", out type))
                {
                    if (type == XmlSeverityType.Error)
                    {
                        MessageBox.Show(e.Message, "Validation Error");
                        throw new Exception(e.Message);
                    }
                    MessageBox.Show("Validation successful");
                }
            }));
        }
    }
}
