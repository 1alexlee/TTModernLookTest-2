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
        
        
        private void Rock_Click(object sender, RoutedEventArgs e) 
        {
            
            string rock_table = "rock";
            string path = AppDomain.CurrentDomain.BaseDirectory + @"tuneteller-289b6-firebase-adminsdk-9617w-7c72f24d65.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            db = FirestoreDb.Create("tuneteller-289b6");
            
            
            
            GetData_From_Document(rock_table);
           
        }

        //NOT FUNCTIONING PROPERLY
        //recursive check on the array for the given genre and the outputbox to see if a genre has been recommended in its entirety. 
        private bool Table_Exhausted(string[] songList, int index)
        {
            if (index == songList.Length)
            {
                if (outputBox.Text.Contains(songList[index]))
                {
                    return true;
                }
            }
            if (outputBox.Text.Contains(songList[index]))
            {   
                return Table_Exhausted(songList, index + 1);
            }
            else
            { 
                return false; 
            }
            
        }

       //NOT FUNCTIONING PROPERLY
       /*************************************************
        * almost functions properly, but once all songs have been recommended it will still repeat a couple songs before printing the wesorry.tm message.
        * 
        * if you press the button too fast the songs will repeat before all have been recommended. might be that the previous calls to Table_Exhausted and song_selector havent finished and returned yet?
        
        *************************************************/
        //calls the Table_Exhausted method in see if the genre is exhausted, if it is then weSorry.tm

        //if its not, then check the nextRec against the outputBox to see if its recommended already. If it is, get a different one and return it. if its not, just return the og rec.
        private string  Song_Selector(string[] songList)
        {
          
        Random randSongSelector = new Random();
            int nextRecIndex = randSongSelector.Next(0, songList.Length);
            string nextRec = songList.ElementAt(nextRecIndex);
            int newNextRecIndex = -1;
            string weSorryMessage = "Sorry, we are out of recommendations for that genre. Try a different one\nor come back later when we've added more!";
            


            if (Table_Exhausted(songList, 0))
            {
                return weSorryMessage;
            }
            else if(outputBox.Text.Contains(nextRec + "\n"))
            {
                do
                {
                    newNextRecIndex = randSongSelector.Next(0, songList.Length);
                } while (newNextRecIndex == nextRecIndex);

                return songList[newNextRecIndex];
            }
            else
            {
                return nextRec;
            }
            
                
        }
        

       async void GetData_From_Document(string table_name)
        {
            try
            {
                Google.Cloud.Firestore.DocumentReference docref = db.Collection(table_name).Document("songs");
                DocumentSnapshot snap = await docref.GetSnapshotAsync();
                if (snap.Exists)
                {
                    //copy array from db doc and send it to the song_selector to select a random song, adding the song to the output box
                    string[] songList = snap.GetValue<string[]>("songArray");
                    outputBox.Text += Song_Selector(songList) + "\n";
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
