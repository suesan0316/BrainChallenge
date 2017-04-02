using SQLite;
using System.Text;

namespace BrainChallenge.Common.Data.Entity.Master
{
    /// <summary>
    /// ゲームマスターテーブルエンティティ
    /// </summary>
    [Table("GameMaster")]
    public class GameMasterEntity
    {
        /// <summary>
        /// ゲームID(PrimaryKey)
        /// </summary>
        [PrimaryKey, AutoIncrement, Column("_gameId")]
        public int GameId { get; set; }
        /// <summary>
        /// ゲーム名
        /// </summary>
        [Column("_gameName")]
        public string GameName { get; set; }
        /// <summary>
        /// ゲームタイプID
        /// </summary>
        [Column("_gameTypeId")]
        public int GameTypeId { get; set; }
        /// <summary>
        /// スコアタイプ
        /// </summary>
        [Column("_scoreType")]
        public int ScoreType { get; set; }
        /// <summary>
        /// タイトル画像
        /// </summary>
        [Column("_titleImage")]
        public string TitleImage { get; set; }
        /// <summary>
        /// アイコン画像
        /// </summary>
        [Column("_iconImage")]
        public string IconImage { get; set; }
        /// <summary>
        /// クラス
        /// </summary>
        [Column("_class")]
        public string Class { get; set; }
        /// <summary>
        /// ゲーム時間
        /// </summary>
        [Column("_gameTime")]
        public long GameTime { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            sb.Append("GameId="+GameId);
            sb.Append(",");
            sb.Append("GameName=" + GameName);
            sb.Append(",");
            sb.Append("GameTypeId=" + GameTypeId);
            sb.Append(",");
            sb.Append("ScoreType=" + ScoreType);
            sb.Append(",");
            sb.Append("TitleImage=" + TitleImage);
            sb.Append(",");
            sb.Append("IconImage=" + IconImage);
            sb.Append(",");
            sb.Append("Class=" + Class);
            sb.Append(",");
            sb.Append("GameTime=" + GameTime);
            sb.Append("]");

            return sb.ToString();
        }
    }
}
