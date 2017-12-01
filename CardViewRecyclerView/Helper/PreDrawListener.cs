using System;
using Android.Views;

namespace CardViewRecyclerView.Helper
{
    public class PreDrawListener : Java.Lang.Object, ViewTreeObserver.IOnPreDrawListener
    {
        private readonly Func<View> _preDrawListener;

        public PreDrawListener(Func<View> mapReadyListener)
        {
            _preDrawListener = mapReadyListener;
        }

        public bool OnPreDraw()
        {
            var view = _preDrawListener?.Invoke();
            if (view != null)
            {
                view.ViewTreeObserver.RemoveOnPreDrawListener(this);
            }

            return true;
        }
    }
}