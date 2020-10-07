using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace TP3Allocine2.Utils
{
    public class Popup
    {
        private static Popup instance = null;

        public Popup()
        {

        }

        public static Popup Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Popup();
                }
                return instance;
            }
        }


        public async void showError(string message)
        {
            // Create the message dialog and set its content
            var messageDialog = new MessageDialog(message);
            await messageDialog.ShowAsync();
        }
    }
}
