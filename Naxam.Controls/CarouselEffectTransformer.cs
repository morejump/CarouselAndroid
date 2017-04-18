using System;
using Android.Content;
using Android.Views;
using Android.Support.V4.View;
using Android.Runtime;

namespace Naxam.Controls
{
    public class CarouselEffectTransformer : Java.Lang.Object, ViewPager.IPageTransformer
    {
        private int maxTranslateOffsetX;
        private ViewPager viewPager;

        public CarouselEffectTransformer(Context context)
        {
            this.maxTranslateOffsetX = dp2px(context, 180);
        }

        public void TransformPage(View view, float position)
        {
            if (viewPager == null)
            {
                viewPager = (ViewPager)view.Parent;
            }
            int leftInScreen = view.Left - viewPager.ScrollX;
            int centerXInViewPager = leftInScreen + view.MeasuredWidth / 2;
            int offsetX = centerXInViewPager - viewPager.MeasuredWidth / 2;
            float offsetRate = (float)offsetX * 0.1f / viewPager.MeasuredWidth;
            float scaleFactor = 1 - Math.Abs(offsetRate);
            if (scaleFactor > 0)
            {
                view.ScaleX = scaleFactor;
                view.ScaleY=scaleFactor;
                view.TranslationX=-maxTranslateOffsetX * offsetRate;
            }

        }
        private int dp2px(Context context, float dipValue)
        {
            float m = context.Resources.DisplayMetrics.Density;
            return (int)(dipValue * m + 0.5f);
        }

    }
}