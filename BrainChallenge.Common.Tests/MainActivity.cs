using System.Reflection;
using Android.App;
using Android.OS;
using Xamarin.Android.NUnitLite;
using BrainChallenge.Common.Data.Connection;
using BrainChallenge.Common.Data.Entity.Master;
using BrainChallenge.Common.Data.Entity.Master;
using System;

namespace BrainChallenge.Common.Tests
{
    [Activity(Label = "BrainChallenge.Common.Tests", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : TestSuiteActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            // tests can be inside the main assembly
            AddTest(Assembly.GetExecutingAssembly());
            // or in any reference assemblies
            // AddTest (typeof (Your.Library.TestClass).Assembly);

            var dbPath = GetLocalFilePath("brainchallenge.db3");
            initDataBase(dbPath);

            // Once you called base.OnCreate(), you cannot add more assemblies.
            base.OnCreate(bundle);
        }
        public static string GetLocalFilePath(string filename)
        {
            //指定されたファイルのパスを取得します。なければ作成してそのパスを返却します
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename);
        }
        private void initDataBase(string dbPath)
        {
            ConnectionProvider.dbPath = dbPath;
            using (var con = ConnectionProvider.getConnection())
            {

                try
                {
                    con.DropTable<GameTypeMasterEntity>();
                    con.DropTable<GameMasterEntity>();
                    con.DropTable<HelpMasterEntity>();
                    con.DropTable<ScoreEntity>();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                con.CreateTable<GameTypeMasterEntity>();
                con.CreateTable<GameMasterEntity>();
                con.CreateTable<HelpMasterEntity>();
                con.CreateTable<ScoreEntity>();

                con.Insert(new GameTypeMasterEntity { Name = "記憶力" });
                con.Insert(new GameTypeMasterEntity { Name = "柔軟性" });
                con.Insert(new GameTypeMasterEntity { Name = "スピード" });
                con.Insert(new GameTypeMasterEntity { Name = "問題解決能力" });

                con.Insert(new GameMasterEntity { GameName = "迷子を探せ!!", GameTypeId = 0, ScoreType = 0, TitleImage = "detective_game_title", IconImage = "detective_game_icon", Class = "DetectiveGameController", GameTime = 1L });
                con.Insert(new GameMasterEntity { GameName = "記憶力ゲーム2", GameTypeId = 0, ScoreType = 1, TitleImage = "memory2_game_title", IconImage = "memory2_game_icon", Class = "MemoryGame2Controller", GameTime = 2L });
                con.Insert(new GameMasterEntity { GameName = "記憶力ゲーム3", GameTypeId = 0, ScoreType = 0, TitleImage = "memory3_game_title", IconImage = "memory3_game_icon", Class = "MemoryGame3Controller", GameTime = 3L });
                con.Insert(new GameMasterEntity { GameName = "記憶力ゲーム4", GameTypeId = 0, ScoreType = 1, TitleImage = "memory4_game_title", IconImage = "memory4_game_icon", Class = "MemoryGame4Controller", GameTime = 4L });

                con.Insert(new GameMasterEntity { GameName = "柔軟性ゲーム1", GameTypeId = 1, ScoreType = 0, TitleImage = "flexibility1_game_title", IconImage = "flexibility1_game_icon", Class = "FlexibilityGame1Controller", GameTime = 1L });
                //con.Insert(new GameMasterEntity { GameName = "柔軟性ゲーム2", GameTypeId = 1, ScoreType = 1, TitleImage = "flexibility2_game_title", IconImage = "flexibility2_game_icon", Class = "FlexibilityGame2Controller", GameTime = 2L });
                //con.Insert(new GameMasterEntity { GameName = "柔軟性ゲーム3", GameTypeId = 1, ScoreType = 0, TitleImage = "flexibility3_game_title", IconImage = "flexibility3_game_icon", Class = "FlexibilityGame3Controller", GameTime = 3L });
                //con.Insert(new GameMasterEntity { GameName = "柔軟性ゲーム4", GameTypeId = 1, ScoreType = 1, TitleImage = "flexibility4_game_title", IconImage = "flexibility4_game_icon", Class = "FlexibilityGame4Controller", GameTime = 4L });

                con.Insert(new GameMasterEntity { GameName = "スピードゲーム1", GameTypeId = 2, ScoreType = 0, TitleImage = "speed1_game_title", IconImage = "speed1_game_icon", Class = "SpeedGame1Controller", GameTime = 1L });
                con.Insert(new GameMasterEntity { GameName = "スピードゲーム2", GameTypeId = 2, ScoreType = 1, TitleImage = "speed2_game_title", IconImage = "speed2_game_icon", Class = "SpeedGame2Controller", GameTime = 2L });
                //con.Insert(new GameMasterEntity { GameName = "スピードゲーム3", GameTypeId = 2, ScoreType = 0, TitleImage = "speed3_game_title", IconImage = "speed3_game_icon", Class = "SpeedGame3Controller", GameTime = 3L });
                //con.Insert(new GameMasterEntity { GameName = "スピードゲーム4", GameTypeId = 2, ScoreType = 1, TitleImage = "speed4_game_title", IconImage = "speed4_game_icon", Class = "SpeedGame4Controller", GameTime = 4L });

                con.Insert(new GameMasterEntity { GameName = "問題解決能力ゲーム1", GameTypeId = 3, ScoreType = 0, TitleImage = "computational1_game_title", IconImage = "computational1_game_icon", Class = "ComputationalGame1Controller", GameTime = 1L });
                con.Insert(new GameMasterEntity { GameName = "問題解決能力ゲーム2", GameTypeId = 3, ScoreType = 1, TitleImage = "computational2_game_title", IconImage = "computational2_game_icon", Class = "ComputationalGame2Controller", GameTime = 2L });
                con.Insert(new GameMasterEntity { GameName = "問題解決能力ゲーム3", GameTypeId = 3, ScoreType = 0, TitleImage = "computational3_game_title", IconImage = "computational3_game_icon", Class = "ComputationalGame3Controller", GameTime = 3L });
                con.Insert(new GameMasterEntity { GameName = "問題解決能力ゲーム4", GameTypeId = 3, ScoreType = 1, TitleImage = "computational4_game_title", IconImage = "computational4_game_icon", Class = "ComputationalGame4Controller", GameTime = 4L });

                var model = (from s in con.Table<GameMasterEntity>() where
                            s.GameId == 100
                            select s);
                //model.GameName = "ABC";


                //var re= con.Update(model);

                var model2 = (from s in con.Table<GameMasterEntity>()
                             where
                                s.GameId == 1
                             select s).First();

                var res = con.Delete<GameMasterEntity>("AA");
                var res2 = con.Delete<GameMasterEntity>(1);
            }
        }
    }
}

