using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Google.Cloud.Firestore;




namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for SelectionWindow.xaml
    /// </summary>
    public partial class SelectionWindow : Window
    {

        Google.Cloud.Firestore.FirestoreDb db;
        public SelectionWindow()
        {
            InitializeComponent();
            
            
            
        }
        
        private void SelectionWindow_Load(Object sender, EventArgs e)
        {
            SelectionWindow GenreSelection = new SelectionWindow();
            GenreSelection.Show();
            
            
        }
        //possible check method to see if all the songs have been recommended -- can then tell them to select another genre
        /*string exhausted_table(string[] songList)
        {
            string all_strings = "";
            for (int i = 0; i < songList.Length - 1; i++){
                all_strings += songList[i] + "/nm";
            }
            return all_strings;
        }*/

        private void Rock_Click(object sender, RoutedEventArgs e) 
        {
            
            string rock_table = "rock";
            string path = AppDomain.CurrentDomain.BaseDirectory + @"tuneteller-289b6-firebase-adminsdk-9617w-7c72f24d65.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            db = FirestoreDb.Create("tuneteller-289b6");
            
            
            
            GetData_From_Document(rock_table);
           
        }
        
        

       async void GetData_From_Document(string table_name)
        {
            try
            {
                Google.Cloud.Firestore.DocumentReference docref = db.Collection(table_name).Document("songs");



                DocumentSnapshot snap = await docref.GetSnapshotAsync();
                
                




                if (snap.Exists)
                {
                    //convert document field songArray into string array
                    //set new random object, get next rand int in bounds.
                    //unfinished
                    string[] songList = snap.GetValue<string[]>("songArray");
                    Random initial_selector = new Random();

                    
                    
                    
                    
                    
                    
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("song not found");
                Console.WriteLine(e.Message);
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Rap_Click(object sender, RoutedEventArgs e)
        {
            string rap_table = "rap";
            string path = AppDomain.CurrentDomain.BaseDirectory + @"tuneteller-289b6-firebase-adminsdk-9617w-7c72f24d65.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            db = FirestoreDb.Create("tuneteller-289b6");



            GetData_From_Document(rap_table);


        }

        private void Country_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RnB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EDM_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Pop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Jazz_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Blues_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Indie_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
