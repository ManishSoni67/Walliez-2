using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Walliez_2
{
    class CustomUriMapper : UriMapperBase
    {
        public override Uri MapUri(Uri uri)
        {
            string tempUri = uri.ToString();
            string mappedUri;

            // Launch from the photo apps picker.
            // Incoming URI example: /MainPage.xaml?token=%7B273fea8d-134c-4764-870d-42224d13eb1a%7D
            if ((tempUri.Contains("token")) && !(tempUri.Contains("RichMediaEdit")))
            {
                // Redirect to PhotoPage.xaml.
                mappedUri = tempUri.Replace("MainPage", "Views/PicturesInfo");
                return new Uri(mappedUri, UriKind.Relative);
            }
            // Otherwise perform normal launch.
            return uri;
        }
    }
}
