using System;
using System.Collections.Generic;
using PU_Application.Model;
using PU_Application.ViewModel;

using Xamarin.Forms;

namespace PU_Application.View
{
	public partial class WebViewPage : ContentPage
	{

		WebViewViewModel viewModel;
		public WebViewPage(WebViewViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = this.viewModel = viewModel;
		    Browser.Source = new HtmlWebViewSource {Html = testHtml};
		    //Browser.Source = "https://use.mazemap.com/?v=1&campusid=1&left=10.3800201&right=10.4280424&top=63.4249667&bottom=63.4100644";
		}

		private void backClicked(object sender, EventArgs e)
		{
			// Check to see if there is anywhere to go back to
			if (Browser.CanGoBack)
			{
				Browser.GoBack();
			}
			else
			{ // If not, leave the view
				Navigation.PopAsync();
			}
		}

                
	    private string testHtml = @"<html>
<head>
<title></title>
<script src=""https://api.mazemap.com/iframe-api/v1.0.0/iframe-api.js""></script>
</head>
<body>

<iframe width=""100%"" height=""100%"" 
src=""https://api.mazemap.com/iframe-api/v1.0.0/iframe-api.html"">
</iframe>
<script>
window.iFrameApiParent = true; //Only needed if your custom page is within another iframe. Inception.

var mazeMapOptions = {

    //Turning of functionality and gui components
    positioningOutdoors: false,
    header: false,
    campusCollectionList : false,
    zoomControl: 'bottomright',
    infoPanel: 'bottom',

    initialState: {
        campuses: 'ntnu',
        campusid: 1,
        sharepoitype: 'poi',
        sharepoiname: 'Office of International Relations',
        sharepoi: 73289,
        zoom: 18,
        wheelzoom: false, /* for webpage integrations where user is expected to scroll down the page, this is sometimes a good idea to disable */
        lang: 'nb'
    },

    basemapClicks: false,
    poiClicks: false
};

//This is the main function which initializes the map with the custom configuration, and returns an instance with a set of functions for you to play with
iframeApi(mazeMapOptions).then(function(mazeMapInstance){

    mazeMapInstance.waitUntilReady().then(function(){

        console.log('MazeMap IFrame at your service. Your command?');

    });

}, function(err){
     console.error('MazeMap init error:', err);
});
</script>

</body>
</html>
	
";

        //src=""https://use.mazemap.com/embed.html?v&#x3D;1&amp;campusid&#x3D;1&amp;desttype&#x3D;poi&amp;dest&#x3D;593&amp;left&#x3D;10.3983343&amp;right&#x3D;10.4079795&amp;top&#x3D;63.4179294&amp;bottom&#x3D;63.4149815&amp;utm_medium&#x3D;iframe""


        private void forwardClicked(object sender, EventArgs e)
		{
			if (Browser.CanGoForward)
			{
				Browser.GoForward();
			}
		}
	}
}



