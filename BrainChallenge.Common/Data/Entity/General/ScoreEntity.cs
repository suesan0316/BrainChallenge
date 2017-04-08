using SQLite;
using System;
using System.Text;

namespace BrainChallenge.Common.Data.Entity.General
{
    /// <summary>
    /// スコアテーブルエンティティ
    /// </summary>
    [Table("Score")]
    public  class ScoreEntity
    {
        /// <summary>
        /// ゲームID
        /// </summary>
        [Column("_gameId")]
        public int GameId { get; set; }
        /// <summary>
        /// スコア
        /// </summary>
        [Column("_score")]
        public int Score { get; set; }
        /// <summary>
        /// 登録日時
        /// </summary>
        [Column("_registDate")]
        public DateTime RegistDate {get; set;}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            sb.Append("GameId=" + GameId);
            sb.Append(",");
            sb.Append("Score=" + Score);
            sb.Append(",");
            sb.Append("RegistDate=" + RegistDate);
            sb.Append("]");

            return sb.ToString();
        }
    }
}
