using BrainChallenge.Common.Data.Connection;
using BrainChallenge.Common.Data.Entity.Master;
using BrainChallenge.Common.Data.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                return result.Count() != 0 ? result.ToList() : null;
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

                return result.Count() != 0 ? result.ToList() : null;
            }
        }
    }
}
