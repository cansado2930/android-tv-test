using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Leanback.App;
using AndroidX.Leanback.Widget;
using System;

namespace droidtvtest
{
    public class MainFragment : BrowseFragment, View.IOnClickListener, IOnItemViewSelectedListener
    {
        private static readonly String TAG = "MainFragment";

        private ArrayObjectAdapter mRowsAdapter;
        private DisplayMetrics mMetrics;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            Log.Info(TAG, "onCreate");
            mMetrics = new DisplayMetrics();
            this.Activity.WindowManager.DefaultDisplay.GetMetrics(mMetrics);

            BadgeDrawable = this.Activity.Resources.GetDrawable(Resource.Drawable.videos_by_google_banner);
            Title = "My Home";
            HeadersState = BrowseFragment.HeadersEnabled;
            HeadersTransitionOnBackEnabled = true;
            BrandColor = Resources.GetColor(Resource.Color.fastlane_background);
            SearchAffordanceColor = Resources.GetColor(Resource.Color.search_opaque);

            SetOnSearchClickedListener(this);
            OnItemViewSelectedListener = this;
            ItemViewClicked += (object sender, ItemViewClickedEventArgs e) => {
                var item = e.Item;
                Log.Debug(TAG, "click item");
            };
            LoadData();
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public void OnItemSelected(Presenter.ViewHolder itemViewHolder, Java.Lang.Object item, RowPresenter.ViewHolder rowViewHolder, Row row)
        {

        }

        public void OnClick(View v)
        {
            Log.Debug(TAG, "Searcher click");
        }
        private void LoadData()
        {
            mRowsAdapter = new ArrayObjectAdapter(new ListRowPresenter());
            
            var gridHeader = new HeaderItem(0, "test");
            var gridPresenter = new GridItemPresenter(this.Context);
            var gridRowAdapter = new ArrayObjectAdapter(gridPresenter);

            gridRowAdapter.Add("test");
            gridRowAdapter.Add("test2");
            gridRowAdapter.Add("test3");
            mRowsAdapter.Add(new ListRow(gridHeader, gridRowAdapter));
            var gridHeader2 = new HeaderItem(1, "testB");
            var gridPresenter2 = new GridItemPresenter(this.Context);
            var gridRowAdapter2 = new ArrayObjectAdapter(gridPresenter2);

            gridRowAdapter2.Add("test");
            gridRowAdapter2.Add("test2");
            gridRowAdapter2.Add("test3");
            mRowsAdapter.Add(new ListRow(gridHeader2, gridRowAdapter2));
            this.Adapter = mRowsAdapter;

        }
        private class GridItemPresenter : Presenter
        {
            private static int GRID_ITEM_WIDTH = 130;
            private static int GRID_ITEM_HEIGHT = 130;
            private Context mainFragment;

            public GridItemPresenter(Context mainFragment)
            {
                this.mainFragment = mainFragment;
            }

            public override void OnBindViewHolder(ViewHolder viewHolder, Java.Lang.Object item)
            {
                ((TextView)viewHolder.View).Text = (String)item;
            }

            public override ViewHolder OnCreateViewHolder(ViewGroup parent)
            {
                TextView view = new TextView(parent.Context);
                view.LayoutParameters = new ViewGroup.LayoutParams(GRID_ITEM_WIDTH, GRID_ITEM_HEIGHT);
                view.SetFocusable(ViewFocusability.Focusable);
                view.FocusableInTouchMode = true;
                view.SetBackgroundColor(new Color(30, 30, 30));
                view.SetTextColor(Color.White);
                view.SetForegroundGravity(GravityFlags.Center);
                return new ViewHolder(view);
            }

            public override void OnUnbindViewHolder(ViewHolder viewHolder)
            {

            }
        }
    }
}