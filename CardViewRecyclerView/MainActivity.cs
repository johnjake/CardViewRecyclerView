using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Widget;
using CardViewRecyclerView.Adapter;
using CardViewRecyclerView.Helper;
using CardViewRecyclerView.Model;
using Square.Picasso;
using Exception = System.Exception;
using Math = Java.Lang.Math;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace CardViewRecyclerView
{
    [Activity(Label = "Top 10 Music Album", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity, AppBarLayout.IOnOffsetChangedListener
    {

        private RecyclerView _recyclerView;
        private AlbumsAdapter _adapter;
        private List<Album> _albumList;
        private bool _isShow;
        private int _scrollRange;
        private CollapsingToolbarLayout _collapsingToolbar;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
           SetContentView(Resource.Layout.ActMain);
            var toolBar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolBar);
            InitCollapsingToolbar();

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recycler_view);
            _albumList = new List<Album>();
            _adapter = new AlbumsAdapter(this, _albumList);
            var mLayoutManager = new GridLayoutManager(this, 2);
            _recyclerView.SetLayoutManager(mLayoutManager);
            _recyclerView.AddItemDecoration(new GridSpacingItemDecoration(2, DpConvertToPx(10), true));
            _recyclerView.SetItemAnimator(new DefaultItemAnimator());
            _recyclerView.SetAdapter(_adapter);

            PopulateAlbum();
            try
            {
                var imgBackdrop = FindViewById<ImageView>(Resource.Id.backdrop);
                Picasso.With(this).Load(Resource.Drawable.cover).Into(imgBackdrop);
            }
            catch (Exception e)
            {
                Console.WriteLine($"@@@@@@@@@@@@@@@@@@@@@{e}");
            }
        }

        private void InitCollapsingToolbar()
        {
            _collapsingToolbar = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);
            var appBarLayout = FindViewById<AppBarLayout>(Resource.Id.appbar);
            appBarLayout.SetExpanded(true);
            _collapsingToolbar.Title = "";

            // hiding & showing the title when toolbar expanded & collapsed
            appBarLayout.AddOnOffsetChangedListener(this);
            _isShow = false;
            _scrollRange = -1;
        }

        public void OnOffsetChanged(AppBarLayout appBarLayout, int verticalOffset)
        {
            if (_scrollRange == -1)
            {
                _scrollRange = appBarLayout.TotalScrollRange;
            }
            if (_scrollRange + verticalOffset == 0)
            {
                _collapsingToolbar.Title = "CardView";
            }
            if (_isShow)
                _collapsingToolbar.Title = "";
                _isShow = false;
        }

        private int DpConvertToPx(int dp)
        {
            var resource = Resources;
            return Math.Round(TypedValue.ApplyDimension(ComplexUnitType.Dip, dp, resource.DisplayMetrics));
        }

        private void PopulateAlbum()
        {
            var covers = new[]
            {
                Resource.Drawable.album1,
                Resource.Drawable.album2,
                Resource.Drawable.album3,
                Resource.Drawable.album4,
                Resource.Drawable.album5,
                Resource.Drawable.album6,
                Resource.Drawable.album7,
                Resource.Drawable.album8,
                Resource.Drawable.album9,
                Resource.Drawable.album10,
                Resource.Drawable.album11
            };
             _albumList.Add(new Album
             {
                Name = "Maroon5",NumOfSongs = 13, Thumbnail = covers[0]
             });
            _albumList.Add(new Album
            {
                Name = "Sugar Ray",NumOfSongs = 8,Thumbnail = covers[1]
            });
            _albumList.Add(new Album
            {
                Name = "Bon Jovi", NumOfSongs = 11, Thumbnail = covers[2]
            });
            _albumList.Add(new Album
            {
                Name = "The Cranberries",
                NumOfSongs = 14,
                Thumbnail = covers[4]
            });
            _albumList.Add(new Album
            {
                Name = "Westlife",NumOfSongs = 1,Thumbnail = covers[5]
            });
            _albumList.Add(new Album
            {
                Name = "Black Eyed Peas",NumOfSongs = 11,Thumbnail = covers[6]
            });

            _albumList.Add(new Album
            {
                Name = "VivaLaVida",NumOfSongs = 14,Thumbnail = covers[7]
            });
            _albumList.Add(new Album
            {
                Name = "The Cardigans",NumOfSongs = 11,Thumbnail = covers[8]
            });
            _albumList.Add(new Album
            {
                Name = "Pussycat Dolls",NumOfSongs = 17,Thumbnail = covers[9]
            });

            _adapter.NotifyDataSetChanged();
        }

    }
}

