using SQLite;
using System.Text;

namespace BrainChallenge.Common.Data.Entity.General
{
    [Table("Sample")]
    public class SampleEntity
    {
        /// <summary>
        /// ID(PrimaryKey)
        /// </summary>
        [PrimaryKey, Column("_id")]
        public int Id { get; set; }
        /// <summary>
        /// 名前
        /// </summary>
        [Column("_name")]
        public string Name { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            sb.Append("Id=" + Id);
            sb.Append(",");
            sb.Append("Name=" + Name);
            sb.Append("]");

            return sb.ToString();
        }
    }
}
