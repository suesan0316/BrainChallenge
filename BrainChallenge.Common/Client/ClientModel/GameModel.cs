using System.Text;

namespace BrainChallenge.Common.Client.ClientModel
{
    /// <summary>
    /// メニュー一覧で使用するモデル
    /// </summary>
    public class GameModel
    {
        /// <summary>
        /// ゲームID
        /// </summary>
        public int GameId { get; set; }
        /// <summary>
        /// ゲーム名
        /// </summary>
        public string GameName { get; set; }
        /// <summary>
        /// ゲームアイコン画像名
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// コントローラクラス名
        /// </summary>
        public string Class { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("[");
            sb.Append("GameId=" + GameId);
            sb.Append(",");
            sb.Append("GameName=" + GameName);
            sb.Append(",");
            sb.Append("Icon=" + Icon);
            sb.Append(",");
            sb.Append("Class=" + Class);
            sb.Append("]");

            return sb.ToString();
        }
    }
}
