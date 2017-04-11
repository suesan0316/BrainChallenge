using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string dbPath { get; set; }
    }
}
