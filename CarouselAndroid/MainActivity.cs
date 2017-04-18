using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.View;
using System;
using Android.Views;
using Android.Runtime;
using Java.Interop;
using Naxam.Controls;

namespace CarouselAndroid
{
    [Activity(Label = "CarouselAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ViewPager viewpagerTop, viewPagerBackground;
        public static readonly int ADAPTER_TYPE_TOP = 1;
        public static readonly int ADAPTER_TYPE_BOTTOM = 2;
        private int[] listItems = {Resource.Mipmap.img1,
            Resource.Mipmap.img2, Resource.Mipmap.img3, Resource.Mipmap.img4,
            Resource.Mipmap.img5, Resource.Mipmap.img6, Resource.Mipmap.img7,
            Resource.Mipmap.img8, Resource.Mipmap.img9, Resource.Mipmap.img10};


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            init();
            SetupViewPager();
        }

        //Initialize all required variables
        private void init()
        {
            viewpagerTop = (ViewPager)FindViewById(Resource.Id.viewpagerTop);
            viewPagerBackground = (ViewPager)FindViewById(Resource.Id.viewPagerbackground);

            viewpagerTop.SetClipChildren(false);
            viewpagerTop.PageMargin = Resources.GetDimensionPixelOffset(Resource.Dimension.pager_margin);
            viewpagerTop.OffscreenPageLimit = 3;
            viewpagerTop.SetPageTransformer(false, new CarouselEffectTransformer(this)); // Set transformer

        }
        //Setup viewpager and it's events
        private void SetupViewPager()
        {
            // Set Top ViewPager Adapter
            MyPagerAdapter adapter = new MyPagerAdapter(this, listItems, ADAPTER_TYPE_TOP);
            viewpagerTop.Adapter = adapter;

            // Set Background ViewPager Adapter
            MyPagerAdapter adapterBackground = new MyPagerAdapter(this, listItems, ADAPTER_TYPE_BOTTOM);
            viewPagerBackground.Adapter = adapterBackground;

            // continute this function after implementing class 
            viewpagerTop.AddOnPageChangeListener(new MyInterface(viewpagerTop, viewPagerBackground));

        }
        //Handle all click event of activity
        [Export("clickEvent")]
        public void clickEvent(View view)
        {
            switch (view.Id)
            {
                case Resource.Id.linMain:
                    if (view.Tag != null)
                    {
                        int poisition = Int32.Parse(view.Tag.ToString());
                        Toast.MakeText(ApplicationContext, "Poistion: " + poisition, ToastLength.Long).Show();
                    }
                    break;
            }
        }
        public class MyInterface : Java.Lang.Object, ViewPager.IOnPageChangeListener
        {
            private int index = 0;
            private ViewPager viewpagerTop, viewPagerBackground;

            public MyInterface(ViewPager viewpagerTop, ViewPager viewPagerBackground)
            {
                this.viewpagerTop = viewpagerTop;
                this.viewPagerBackground = viewPagerBackground;
            }
            
            public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
            {
                int width = viewPagerBackground.Width;
                viewPagerBackground.ScrollTo((int)(width * position + width * positionOffset), 0);
            }

            public void OnPageScrollStateChanged(int state)
            {
                if (state == ViewPager.ScrollStateIdle)
                {
                    viewPagerBackground.SetCurrentItem(index, true);
                }

            }

            public void OnPageSelected(int position)
            {
                index = position;

            }
        }
    }

}

