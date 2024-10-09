using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PD_311_AsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random random = new Random();    
        public MainWindow()
        {
            InitializeComponent();
        }
        //async - allow method to use await keyword
        //await - wait task without freezing
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //int value = GenerateValue();//freeze

            //Task<int> task = Task.Run(GenerateValue);

            //task.Wait();//freeze
            // list.Items.Add(task.Result);  //freeze

            //int value = await task;
            //int value = await Task.Run(GenerateValue);
            //int value = await GenerateValueAsync();
            //MessageBox.Show("Complete in button click!!!!");
            //list.Items.Add(value);  
            // GenerateValueAsync();
            //await GenerateValueAsync();
            //await GenerateValueAsync();
            //await GenerateValueAsync();

            list.Items.Add(await GenerateValueAsync());      
          
        }

        int GenerateValue()
        {
            Thread.Sleep(random.Next(5000));
            //MessageBox.Show("Complete!!!!");
            return random.Next(1000);
        }
        Task<int> GenerateValueAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(random.Next(5000));
                //MessageBox.Show("Complete!!!!");
                return random.Next(1000);
            });
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            //dialog.InitialDirectory = "C:\\Users";
            //dialog.IsFolderPicker = true;
            //dialog.Multiselect = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {

                MessageBox.Show("You selected: " + dialog.FileName);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            //dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            //dialog.Multiselect = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {

                MessageBox.Show("You selected: " + dialog.FileName);
            }
        }
    }
}