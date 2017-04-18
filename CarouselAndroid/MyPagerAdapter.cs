using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Com.Bumptech.Glide;

namespace CarouselAndroid
{
    public class MyPagerAdapter : PagerAdapter
    {
        Context context;
        int[] listItems;
        int adapterType;

        public override int Count
        {
            get { return listItems.Length; }

        }

        public override bool IsViewFromObject(View view, Java.Lang.Object @object)
        {
            return (view == @object);
        }
        public MyPagerAdapter(Context context, int[] listItems, int adapterType)
        {
            this.context = context;
            this.listItems = listItems;
            this.adapterType = adapterType;
        }
        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            View view = LayoutInflater.From(context).Inflate(Resource.Layout.item_cover, null);
            try
            {

                LinearLayout linMain = (LinearLayout)view.FindViewById(Resource.Id.linMain);
                ImageView imageCover = (ImageView)view.FindViewById(Resource.Id.imageCover);
                linMain.Tag = position;

                switch (adapterType)
                {
                    case 1:
                        linMain.SetBackgroundResource(Resource.Drawable.shadow);
                        break;
                    case 2:
                        linMain.SetBackgroundResource(0);
                        break;
                }

                Glide.With(context)
                        .Load(listItems[position])
                        .Into(imageCover);

                container.AddView(view);

            }
            catch (Java.Lang.Exception e)
            {
                e.PrintStackTrace();
            }

            return view;
        }

        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object @object)
        {
            container.RemoveView((View)@object);
        }
    }
}