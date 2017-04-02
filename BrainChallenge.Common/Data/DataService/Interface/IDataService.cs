using System.Collections.Generic;

namespace BrainChallenge.Common.Data.Service.Interface
{
    /// <summary>
    /// データベース操作を行うクラスのベースとなるインターフェース
    /// </summary>
    /// <typeparam name="T">エンティティ</typeparam>
    interface IDataService<T>
    {
        List<T> select();
        List<T> select(T t);
    }
}
