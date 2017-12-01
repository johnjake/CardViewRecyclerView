using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using PopupMenu = Android.Support.V7.Widget.PopupMenu;

namespace CardViewRecyclerView.Helper
{
    public class PopUpMenuItemClickListener: PopupMenu.IOnMenuItemClickListener
    {
        private readonly Context _mContext;

        public PopUpMenuItemClickListener(Context mContext)
        {
            _mContext = mContext;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IntPtr Handle { get; }
        public bool OnMenuItemClick(IMenuItem menuItem)
        {
            switch (menuItem.ItemId)
            {
                case Resource.Id.action_add_favourite:
                    Toast.MakeText(_mContext, "Add to favourite", ToastLength.Long).Show();
                    return true;
                case Resource.Id.action_play_next:
                    Toast.MakeText(_mContext, "Play next", ToastLength.Long).Show();
                    return true;
                default:
                    return false;
            }
        }
    }
}