using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using mshtml;
using System.Windows.Navigation;
namespace Heart_ID_Csharp
{
    /// <summary>
    /// Interaction logic for Browser.xaml
    /// </summary>
    public partial class Browser : Window
    {
        public Browser()
        {
            InitializeComponent();
            webBrowser1.Navigate("https://www.google.com/accounts/ServiceLogin?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F%3Fui%3Dhtml%26zy%3Dl&bsv=llya694le36z&ss=1&scc=1&ltmpl=default&ltmplcache=2&hl=en");
        }

        private string username;
        private string password;
        static IHTMLElementCollection m_hec;

        public void browser_fill()
        {
            if (webBrowser1.IsLoaded)
            {
                m_hec = (webBrowser1.Document as HTMLDocumentClass).getElementsByTagName("input");
                List<string> lstInput = new List<string>();
                foreach (HTMLInputElementClass he in m_hec)
                {
                    if (he.getAttribute("name").ToString() == "Email")
                    {

                        if (he.getAttribute("value") != null)
                        {
                            lstInput.Add(he.getAttribute("value").ToString());
                        }

                        else
                        {
                            lstInput.Add("");
                            he.setAttribute("value", username);
                        }
                    }

                    if (he.getAttribute("name").ToString() == "Passwd")
                    {

                        if (he.getAttribute("value") != null)
                        {
                            lstInput.Add(he.getAttribute("value").ToString());
                        }

                        else
                        {
                            lstInput.Add("");
                            he.setAttribute("value", password);
                        }
                    }

                }
            }
        }

        public void SetUserPass(string user, string pass)
        {
            username = user;
            password = pass;
        }

        private void go_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                webBrowser1.Navigate(address_field.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
