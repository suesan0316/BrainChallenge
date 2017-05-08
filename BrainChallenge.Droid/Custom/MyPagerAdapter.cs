using System;
using Android.Content;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Object = Java.Lang.Object;
using String = Java.Lang.String;

namespace BrainChallenge.Droid.Custom
{
    internal class MyPagerAdapter : PagerAdapter
    {
        private readonly Context _context;

        // Underlying data (tree catalog):
        public MyPagerCatalog MyPagerCatalog;

        // Load the adapter with the tree catalog at construction time:
        public MyPagerAdapter(Context context, MyPagerCatalog myPagerCatalog)
        {
            _context = context;
            MyPagerCatalog = myPagerCatalog;
        }

        // Return the number of trees in the catalog:
        public override int Count => MyPagerCatalog.NumTrees;

        // Create the tree page for the given position:
        [Obsolete("deprecated")]
        public override Object InstantiateItem(View container, int position)
        {
            // Instantiate the ImageView and give it an image:
            var imageView = new ImageView(_context);
            imageView.SetImageResource(MyPagerCatalog[position].imageId);

            // Add the image to the ViewPager:
            var viewPager = container.JavaCast<ViewPager>();
            viewPager.AddView(imageView);
            return imageView;
        }

        // Remove a tree page from the given position.
        [Obsolete("deprecated")]
        public override void DestroyItem(View container, int position, Object view)
        {
            var viewPager = container.JavaCast<ViewPager>();
            viewPager.RemoveView(view as View);
        }

        // Determine whether a page View is associated with the specific key object
        // returned from InstantiateItem (in this case, they are one in the same):
        public override bool IsViewFromObject(View view, Object obj)
        {
            return view == obj;
        }

        // Display a caption for each Tree page in the PagerTitleStrip:
        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return new String(MyPagerCatalog[position].caption);
        }
    }
}