using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;

namespace CardViewRecyclerView.Helper
{
    public class GridSpacingItemDecoration : RecyclerView.ItemDecoration
    {
        private readonly int _spanCount;
        private readonly int _spacing;
        private readonly bool _includeEdge;

        public GridSpacingItemDecoration(int spanCount, int spacing, bool includeEdge)
        {
            _spanCount = spanCount;
            _spacing = spacing;
            _includeEdge = includeEdge;
        }


        public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state)
        {
            int position = parent.GetChildAdapterPosition(view); // item position
            int column = position % _spanCount; // item column

            if (_includeEdge)
            {
                outRect.Left = _spacing - column * _spacing / _spanCount; // spacing - column * ((1f / spanCount) * spacing)
                outRect.Right = (column + 1) * _spacing / _spanCount; // (column + 1) * ((1f / spanCount) * spacing)

                if (position < _spanCount)
                { // top edge
                    outRect.Top = _spacing;
                }
                outRect.Bottom = _spacing; // item bottom
            }
            else
            {
                outRect.Left = column * _spacing / _spanCount; // column * ((1f / spanCount) * spacing)
                outRect.Right = _spacing - (column + 1) * _spacing / _spanCount; // spacing - (column + 1) * ((1f /    spanCount) * spacing)
                if (position >= _spanCount)
                {
                    outRect.Top = _spacing; // item top
                }
            }
        }
    }
}