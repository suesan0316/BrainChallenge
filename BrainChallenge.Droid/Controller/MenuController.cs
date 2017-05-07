using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using BrainChallenge.Common.Client.ClientModel;
using BrainChallenge.Common.Client.ClientService.Implement;
using Environment = System.Environment;

namespace BrainChallenge.Droid.Controller
{
    [Activity(MainLauncher = true)]
    public class MenuController : Activity
    {
        private readonly MenuService _service = new MenuService();
        private TableLayout _menuTable;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            // ���ʂ̃e�[�}��K�p
            SetTheme(AppConst.targetTheme);

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Menu);

            // �T�[�r�X�̏����������s
            ServiceIinitializer.Initialize(
                new ServiceInitializeModel {DbPath = GetLocalFilePath("brainchallenge.db3")});

            _menuTable = FindViewById<TableLayout>(Resource.Id.menuTable);

            // �Q�[���̈ꗗ�����擾
            var gameModels = _service.GetGameList();

            // �Q�[���̎�ʂ��Ƃɐ����X�N���[���ɃQ�[���̈ꗗ����\�����܂�
            foreach (var type in gameModels)
            {
                // �Q�[�����3�𖞂��Ȃ��ꍇ�A��������ImgaeButton��ݒ肷��
                var min = 3;

                // �Q�[����ʂ̃��I�i�[
                var gameListTitleLinear = Util.GenerateView<LinearLayout>(this, "GameListTitleLinear");
                // �Q�[����ʂ̃^�C�g��
                var gameTypeListTitle = Util.GenerateView<TextView>(this, "GameTypeListTitle");

                gameTypeListTitle.Text = type.Key;
                gameListTitleLinear.AddView(gameTypeListTitle);
                _menuTable.AddView(gameListTitleLinear);

                // �Q�[���ꗗ�̐����X�N���[��
                var gameListScroll = Util.GenerateView<HorizontalScrollView>(this, "GameListScroll");
                // �Q�[���ꗗ�̃��C�i�[
                var gameListLinaer = Util.GenerateView<LinearLayout>(this, "GameListLinaer");

                foreach (var gameModel in type.Value)
                {
                    // �Q�[�����̃��C�i�[
                    var gameLinaer = Util.GenerateView<LinearLayout>(this, "GameLinaer");
                    // �Q�[���̃C���[�W�{�^��
                    var gameButton = Util.GenerateView<ImageButton>(this, "GameButton");
                    gameButton.SetBackgroundResource((int) typeof(Resource.Drawable).GetField(gameModel.Icon)
                        .GetValue(null));

                    //�@�Q�[���̃{�^���̃N���b�N�A�N�V������ݒ�
                    gameButton.Click += delegate
                    {
                        // �Q�[���X�^�[�g��ʂ֑J��
                        var next = new Intent(this, typeof(GameStartController));
                        next.PutExtra("MyData", gameModel.GameId);
                        StartActivity(next);
                    };

                    //�Q�[���̃^�C�g��
                    var gameTitle = Util.GenerateView<TextView>(this, "GameTitle");
                    gameTitle.Text = gameModel.GameName;

                    gameLinaer.AddView(gameButton);
                    gameLinaer.AddView(gameTitle);
                    gameListLinaer.AddView(gameLinaer);

                    min--;
                }

                // �Q�[���̈ꗗ��3�ȏ�ɂȂ�܂ŁA�������{�^����ݒ肷��
                for (var i = 0; i < min; i++)
                {
                    var gameLinaer = Util.GenerateView<LinearLayout>(this, "GameLinaer");

                    var gameButton = Util.GenerateView<ImageButton>(this, "NoOpenGameButton");
                    gameButton.SetBackgroundResource(Resource.Drawable.noopen);

                    var gameTitle = Util.GenerateView<TextView>(this, "NoOpenGameTitle");

                    gameLinaer.AddView(gameButton);
                    gameLinaer.AddView(gameTitle);

                    gameListLinaer.AddView(gameLinaer);
                }

                gameListScroll.AddView(gameListLinaer);

                _menuTable.AddView(gameListScroll);
            }
        }

        private static string GetLocalFilePath(string filename)
        {
            //�w�肳�ꂽ�t�@�C���̃p�X���擾���܂��B�Ȃ���΍쐬���Ă��̃p�X��ԋp���܂�
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}