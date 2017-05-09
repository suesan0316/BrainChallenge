namespace BrainChallenge.Droid.Custom
{
    public class MyPagerPage
    {
        public string Caption;
        public int ImageId;
    }

    public class MyPagerCatalog
    {
        private readonly MyPagerPage[] _myPagerPages;

        public MyPagerCatalog(MyPagerPage[] page)
        {
            _myPagerPages = page;
        }

        public MyPagerPage this[int i] => _myPagerPages[i];

        public int NumTrees => _myPagerPages.Length;
    }
}