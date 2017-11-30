using System;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace CardViewRecyclerView.Helper
{
    public class AlbumViewHolder: RecyclerView.ViewHolder
    {
        public TextView Title, Count;
        public ImageView Thumbnail, Overflow;
        public AlbumViewHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {

        }

        public AlbumViewHolder(View itemView) : base(itemView)
        {
            Title = itemView.FindViewById<TextView>(Resource.Id.title);
            Count = itemView.FindViewById<TextView>(Resource.Id.count);
            Thumbnail = itemView.FindViewById<ImageView>(Resource.Id.thumbnail);
            Overflow = itemView.FindViewById<ImageView>(Resource.Id.overflow);
        }
    }
}