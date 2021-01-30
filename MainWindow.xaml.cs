using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFRandomThings.Model;

namespace WPFRandomThings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BindingList<Message> RandomList;
       

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded (object sender, RoutedEventArgs e)
        {
           
            RandomList = new BindingList<Message>();

            ListText.DataContext = RandomList;

            ButtonAddToList.Click += ButtonAddToList_Click;

            ButtonRemoveFromList.Click += ButtonRemoveFromList_Click;

            ButtonRandom.Click += ButtonRandom_Click;
            
            RandomList.ListChanged += ListChange;


        }



        private void ButtonAddToList_Click(object sender, RoutedEventArgs e)
        {
           
           
            if (inputText.Text.Length > 0) 
            {
                Message message = new Message(inputText.Text);
                RandomList.Add(message);
                inputText.Clear();
               
            }
            else
            {
                
                TextMessages.Text = "Вы не ввели значение";
              
            }
            e.Handled = true;
        }

        private void ListChange(object sender, ListChangedEventArgs e)
        {
            ListText.Clear();
            foreach (Message Item in RandomList)
            {
                ListText.Text += $" {Item.Mes}\n";
            }
           
        }

        private void ButtonRemoveFromList_Click(object sender, RoutedEventArgs e)
        {
             var item = RandomList.LastOrDefault();
            RandomList.Remove(item);
            e.Handled = true;
        }

        private void ButtonRandom_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            var MaxSizeList = RandomList.Count;

            var result = rnd.Next(0, MaxSizeList);

            TextMessages.Text = $"Ваше рандомное значеие - {RandomList[result].Mes}";

            e.Handled = true;
        }
    }
}
