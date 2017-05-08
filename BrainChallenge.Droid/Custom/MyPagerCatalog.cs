namespace BrainChallenge.Droid.Custom
{
    // TreePage: contains image resource ID and caption for a tree:
    public class MyPagerPage
    {
        // Caption text for this image:
        public string caption;

        // Image ID for this tree image:
        public int imageId;

        // Returns the ID of the image:
        public int ImageID => imageId;

        // Returns the caption text for the image:
        public string Caption => caption;
    }

    // Tree catalog: holds image resource IDs and caption text:
    public class MyPagerCatalog
    {

        private readonly MyPagerPage[] myPagerPages;

        public MyPagerCatalog(MyPagerPage[] page)
        {
            myPagerPages = page;
        }

        // Built-in tree catalog (could be replaced with a database)
        /*private  MyPagerPage[] myPagerBuiltInCatalog =
        {
            new MyPagerPage
            {
                imageId = Resource.Drawable.detective_game_title,
                caption = "No.1"
            },
            new MyPagerPage
            {
                imageId = Resource.Drawable.detective_game_title,
                caption = "No.2"
            },
            new MyPagerPage
            {
                imageId = Resource.Drawable.detective_game_title,
                caption = "No.3"
            },
            new MyPagerPage
            {
                imageId = Resource.Drawable.detective_game_title,
                caption = "No.4"
            },
            new MyPagerPage
            {
                imageId = Resource.Drawable.detective_game_title,
                caption = "No.5"
            }
        };

        // Array of tree pages that make up the catalog:
        private readonly MyPagerPage[] myPagerPages;

        // Create an instance copy of the built-in tree catalog:
        public MyPagerCatalog()
        {
            myPagerPages = myPagerBuiltInCatalog;
        }*/

        // Indexer (read only) for accessing a tree page:
        public MyPagerPage this[int i] => myPagerPages[i];

        // Returns the number of tree pages in the catalog:
        public int NumTrees => myPagerPages.Length;
    }
}