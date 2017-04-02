namespace BrainChallenge.Common.Data.Service.Interface
{
    /// <summary>
    /// マスターテーブル以外のテーブルを扱うクラスのインターフェース
    /// </summary>
    /// <typeparam name="T">エンティティ</typeparam>
    interface IGeneralDataService <T> : IDataService<T>
    {
        bool insert(T t);
        //void update(T t);
        //int delete(object primaryKey);
    }
}
