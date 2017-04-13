using SQLite;
using System.Text;

namespace BrainChallenge.Common.Data.Entity.Master
{
    /// <summary>
    /// ヘルプテーブルエンティティ
    /// </summary>
    [Table("HelpMaster")]
    public class HelpMasterEntity
    {
        /// <summary>
        /// ゲームID
        /// </summary>
        [Column("_gameId")]
        public int GameId { get; set; }
        /// <summary>
        /// ヘルプINDEX
        /// </summary>
        [Column("_helpIndex")]
        public int HelpIndex { get; set; }
        /// <summary>
        /// 説明
        /// </summary>
        [Column("_explain")]
        public string Explain { get; set; }
        /// <summary>
        /// 画像
        /// </summary>
        [Column("_Image")]
        public string Image { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("[");
            sb.Append("GameId=" + GameId);
            sb.Append(",");
            sb.Append("HelpIndex=" + HelpIndex);
            sb.Append(",");
            sb.Append("Explain=" + Explain);
            sb.Append(",");
            sb.Append("Image=" + Image);
            sb.Append("]");

            return sb.ToString();
        }
    }
}
