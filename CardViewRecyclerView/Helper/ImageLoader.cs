using System;
using Android.App;
using Android.Widget;
using Square.Picasso;

namespace CardViewRecyclerView.Helper
{
    public static class ImageLoader
    {
        public static void LoadImage(string url, ImageView imageView)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                System.Diagnostics.Debug.WriteLine("LoadImage: No Image URL!");
                return;
            }

            if (imageView == null)
            {
                throw new Exception("ImageLoader.ImageLoader: imageView is null!");
            }

            // Construct URL
            imageView.ViewTreeObserver.AddOnPreDrawListener(new PreDrawListener(() =>
            {
                Picasso.With(Application.Context)
                    .Load(url)
                    .Resize(300,300)
                    .CenterInside()
                    .Into(imageView, null, null);
                return imageView;
            }));
        }
    }
}