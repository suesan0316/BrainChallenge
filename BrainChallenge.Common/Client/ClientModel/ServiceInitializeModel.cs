namespace BrainChallenge.Common.Client.ClientModel
{
    /// <summary>
    /// クライアントサービスの初期化時に使用するモデルクラス
    /// </summary>
    public class ServiceInitializeModel
    {
        /// <summary>
        /// ローカルDBのパス
        /// </summary>
        public string DbPath { get; set; }
    }
}
