using System.Text;

namespace BrainChallenge.Common.Client.ClientModel
{
    class DetectiveGameModel
    {
        /// <summary>
        /// レベル(PrimaryKey)
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// ポイント
        /// </summary>
        public int Point { get; set; }
        /// <summary>
        /// タイル総数
        /// </summary>
        public int Tile { get; set; }
        /// <summary>
        /// 正解タイル数
        /// </summary>
        public int CollectTile { get; set; }
        /// <summary>
        /// フェイクタイルフラグ
        /// </summary>
        public bool? FakeFlg { get; set; }
        /// <summary>
        /// フェイクタイル数
        /// </summary>
        public int FakeTile { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("[");
            sb.Append("Level=" + Level);
            sb.Append(",");
            sb.Append("Point=" + Point);
            sb.Append(",");
            sb.Append("Tile=" + Tile);
            sb.Append(",");
            sb.Append("CollectTile=" + CollectTile);
            sb.Append(",");
            sb.Append("FakeFlg=" + FakeFlg);
            sb.Append(",");
            sb.Append("FakeTile=" + FakeTile);
            sb.Append("]");

            return sb.ToString();
        }
    }
}
