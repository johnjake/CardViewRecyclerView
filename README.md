
Sample Project on Xamarin Android How to create Collapsible AppBar (Toolbar) with CardView as a content of RecyclerView. 

If you would like to use url instead of Image in Drawable just change the method PopulateAlbum(); using


         private static async Task<MusicData> RawMusic()
         {
            const string url = "myapimusic.json";
            var httpCleint = new HttpClient();
            var data = await httpCleint.GetStringAsync(url);
            return JsonConvert.DeserializeObject<MusicData>(data);
         }
         
 Then Add to _albumlist
 
 ![Alt text](https://github.com/johnjake/CardViewRecyclerView/blob/master/cardview.gif?raw=true "Rotating TextView")
 
        
        
