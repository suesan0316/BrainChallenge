using Android.Content;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;

namespace BrainChallenge.Droid.Custom
{
    public class MyPager : ViewPager
    {
        public MyPager(Context subContext) : base(subContext)
        {
        }

        public MyPager(Context subContext, IAttributeSet subIAttributeSet) : base(subContext, subIAttributeSet)
        {
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            var height = 0;
            for (var i = 0; i < ChildCount; i++)
            {
                var child = GetChildAt(i);
                child.Measure(widthMeasureSpec, MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified));
                var h = child.MeasuredHeight;
                if (h > height) height = h;
            }

            heightMeasureSpec = MeasureSpec.MakeMeasureSpec(height, MeasureSpecMode.Exactly);

            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
        }
    }
}