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

        private void btnRock_Click(object sender, RoutedEventArgs e) 
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"tuneteller-289b6-firebase-adminsdk-9617w-7c72f24d65.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            db = FirestoreDb.Create("tuneteller-289b6");
            GetAllMyData_From_A_Document();
           
        }

       async void GetAllMyData_From_A_Document()
        {
            try
            {
                Google.Cloud.Firestore.DocumentReference docref = db.Collection("rock").Document("song");
                DocumentSnapshot snap = await docref.GetSnapshotAsync();

                if (snap.Exists)
                {
                    Dictionary<string, object> city = snap.ToDictionary();
                    foreach (var item in city)
                    {
                        Console.WriteLine(string.Format("{0}: {1}\n", item.Key, item.Value));
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Fuck you");
                Console.WriteLine(e.Message);
            }
        }


       
    }
}
