using System.Collections.Generic;

namespace BrainChallenge.Common.Data.Service.Interface
{
    /// <summary>
    /// データベース操作を行うクラスのベースとなるインターフェース
    /// </summary>
    /// <typeparam name="T">エンティティ</typeparam>
    interface IDataService<T>
    {
        List<T> Select();
        List<T> Select(T t);
    }
}
