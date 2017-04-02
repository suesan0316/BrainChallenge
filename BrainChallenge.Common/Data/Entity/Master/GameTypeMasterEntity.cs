using SQLite;
using System.Text;

namespace BrainChallenge.Common.Data.Entity.Master
{
    /// <summary>
    /// ゲームタイプマスターテーブルエンティティ
    /// </summary>
    [Table("GameTypeMaster")]
    public class GameTypeMasterEntity
    {
        /// <summary>
        /// ゲームタイプID(PK)
        /// </summary>
        [PrimaryKey, AutoIncrement, Column("_gameTypeId")]
        public int GameTypeId { get; set; }

        /// <summary>
        /// タイプ名
        /// </summary>
        [Column("_gameTypeName")]
        public string Name { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            sb.Append("GameTypeId=" + GameTypeId);
            sb.Append(",");
            sb.Append("Name=" + Name);
            sb.Append("]");

            return sb.ToString();
        }
    }
}
