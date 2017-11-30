using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using CardViewRecyclerView.Helper;
using CardViewRecyclerView.Model;
using Square.Picasso;

namespace CardViewRecyclerView.Adapter
{
    public class AlbumsAdapter: RecyclerView.Adapter, PopupMenu.IOnMenuItemClickListener
    {
        private readonly Context _mContext;
        private readonly List<Album> _albumList;
        private View _mainView;
        private PopupMenu _popUp;

        public AlbumsAdapter(Context mContext, List<Album> albumList)
        {
            _mContext = mContext;
            _albumList = albumList;
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.album_card, parent, false);
            var albumViewHolder = new AlbumViewHolder(itemView);
            _mainView = itemView;
            return albumViewHolder;
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewholder, int position)
        {
            var holder = new AlbumViewHolder(_mainView);
            var album = new Album
            {
                Name = _albumList[position].Name,
                Thumbnail = _albumList[position].Thumbnail,
                NumOfSongs = _albumList[position].NumOfSongs
            };
            holder.Title.Text = album.Name;
            holder.Count.Text = album.NumOfSongs+ " songs";
            Picasso.With(_mContext).Load(album.Thumbnail).Into(holder.Thumbnail);
            holder.Overflow.Click += delegate
            {
                ShowPopupMenu(holder.Overflow);
            };
        }

        public override int ItemCount => _albumList.Count;

        private void ShowPopupMenu(View view)
        {
            _popUp = new PopupMenu(_mContext, view);
            var inflater = _popUp.MenuInflater;
            inflater.Inflate(Resource.Menu.menu_album, _popUp.Menu);
            _popUp.SetOnMenuItemClickListener(this);
        }


        public bool OnMenuItemClick(IMenuItem item)
        {
            _popUp.Show();
            return true;
        }
    }
}