using BrainChallenge.Common.Data.Connection;
using BrainChallenge.Common.Data.Entity.Master;
using BrainChallenge.Common.Data.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace BrainChallenge.Common.Data.DataService.Implement
{
    public class GameTypeMasterService : IMasterDataService<GameTypeMasterEntity>
    {

        public List<GameTypeMasterEntity> Select()
        {

            //throw new NotImplementedException();

            using (var con = ConnectionProvider.GetConnection())
            {
                var result = from record in con.Table<GameTypeMasterEntity>() select record;

                var gameTypeMasterEntities = result as IList<GameTypeMasterEntity> ?? result.ToList();
                return gameTypeMasterEntities.Count() != 0 ? gameTypeMasterEntities.ToList() : null;
            }
        }

        public List<GameTypeMasterEntity> Select(GameTypeMasterEntity t)
        {
            //throw new NotImplementedException();

            using (var con = ConnectionProvider.GetConnection())
            {
                var result = from record in con.Table<GameTypeMasterEntity>() select record;

                if (t.GameTypeId != -1)
                    result = result.Where(data => data.GameTypeId == t.GameTypeId);
                if (t.Name != null)
                    result = result.Where(data => data.Name.Equals(t.Name));

                var gameTypeMasterEntities = result as IList<GameTypeMasterEntity> ?? result.ToList();
                return gameTypeMasterEntities.Count() != 0 ? gameTypeMasterEntities.ToList() : null;
            }
        }
    }
}
