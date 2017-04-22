using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrainChallenge.Common.Data.Connection;
using BrainChallenge.Common.Data.Entity.Master;
using BrainChallenge.Common.Data.Service.Interface;

namespace BrainChallenge.Common.Data.DataService.Implement
{
    public class GameMasterService : IMasterDataService<GameMasterEntity>
    {
        public List<GameMasterEntity> Select()
        {
            using (var con = ConnectionProvider.GetConnection())
            {
                var result = from record in con.Table<GameMasterEntity>() select record;

                return result.Count() != 0 ? result.ToList() : null;
            }
        }

        public List<GameMasterEntity> Select(GameMasterEntity t)
        {
            using (var con = ConnectionProvider.GetConnection())
            {
                var result = from record in con.Table<GameMasterEntity>() select record;

                if (t.GameId != -1)
                    result = result.Where(data => data.GameId == t.GameId);
                if (t.GameName != null)
                    result = result.Where(data => data.GameName.Equals(t.GameName));
                if (t.GameTypeId != -1)
                    result = result.Where(data => data.GameTypeId == t.GameTypeId);
                if (t.ScoreType != -1)
                    result = result.Where(data => data.ScoreType == t.ScoreType);
                if (t.TitleImage != null)
                    result = result.Where(data => data.TitleImage.Equals(t.TitleImage));
                if (t.IconImage != null)
                    result = result.Where(data => data.IconImage.Equals(t.IconImage));
                if (t.Class != null)
                    result = result.Where(data => data.Class.Equals(t.Class));
                if (t.GameTime != -1)
                    result = result.Where(data => data.GameTime == t.GameTime);

                return result.Count() != 0 ? result.ToList() : null;
            }
        }
    }
}
