using BrainChallenge.Common.Data.Connection;
using BrainChallenge.Common.Data.Entity.Master;
using BrainChallenge.Common.Data.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace BrainChallenge.Common.Data.DataService.Implement
{
    public class HelpMasterService : IMasterDataService<HelpMasterEntity>
    {
        public List<HelpMasterEntity> Select()
        {
            using (var con = ConnectionProvider.GetConnection())
            {
                var result = from record in con.Table<HelpMasterEntity>() select record;

                var helpMasterEntities = result as IList<HelpMasterEntity> ?? result.ToList();
                return helpMasterEntities.Count() != 0 ? helpMasterEntities.ToList() : null;
            }
        }

        public List<HelpMasterEntity> Select(HelpMasterEntity t)
        {
            using (var con = ConnectionProvider.GetConnection())
            {
                var result = from record in con.Table<HelpMasterEntity>() select record;

                if (t.GameId != -1)
                    result = result.Where(data => data.GameId == t.GameId);
                if (t.HelpIndex != -1)
                    result = result.Where(data => data.HelpIndex == t.HelpIndex);
                if (t.Explain != null)
                    result = result.Where(data => data.Explain.Equals(t.Explain));
                if (t.Image != null)
                    result = result.Where(data => data.Image.Equals(t.Image));

                var helpMasterEntities = result as IList<HelpMasterEntity> ?? result.ToList();
                return helpMasterEntities.Count() != 0 ? helpMasterEntities.ToList() : null;
            }
        }
    }
}
