using Newtonsoft.Json;
using RestSharp;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IvanArsua.CallingaRestAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowComments();
          
        }
        private void ShowComments()
        {
            var Client = new RestClient("https://jsonplaceholder.typicode.com/comments/84");

            var request = new RestRequest("", Method.GET);

            IRestResponse response = Client.Execute(request);

            var content = response.Content;

            var data = JsonConvert.DeserializeObject<comments>(content);
            lblPostID.Content = " PostId: " + data.postId;
            lblId.Content = "Id:" + data.id;
            lblname.Content = " name: " + data.name;
            lblEmail.Content = " Email: " + data.email;
            lblBody.Content = " Body: " + data.body;
        }
        private void btnClickMe_Click(object sender, RoutedEventArgs e)
        {
            ShowComments();
        }
    }
}
