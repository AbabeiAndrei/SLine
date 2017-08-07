using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using SimpleRDS.DataLayer.Base;
using SimpleRDS.DataLayer.Entities;

namespace SimpleRDS.DataLayer.Controllers
{
    public class SettingsRepository
    {
        private readonly IContext _context;

        public SettingsRepository(IContext context)
        {
            _context = context;
        }

        public string GetValue(string key)
        {
            var setting = GetSetting(key);
            
            return setting?.Value;
        }

        public async Task<string> GetValueAsync(string key, CancellationToken cancellationToken)
        {
            var setting = await GetSettingAsync(key, cancellationToken);

            return setting?.Value;
        }

        public async Task<string> GetValueAsync(string key, IDbConnection connection, CancellationToken cancellationToken)
        {
            var setting = await GetSettingAsync(key, connection, cancellationToken);

            return setting?.Value;
        }

        public Setting GetSetting(string key)
        {
            using (var connection = _context.Connection)
            {
                return connection.Select<Setting>(s => s.Key == key).FirstOrDefault();
            }
        }

        public async Task<Setting> GetSettingAsync(string key, CancellationToken cancellationToken)
        {
            using (var connection = _context.Connection)
            {
                return await GetSettingAsync(key, connection, cancellationToken);
            }
        }

        public async Task<Setting> GetSettingAsync(string key, IDbConnection connection, CancellationToken cancellationToken)
        {
            var result = await connection.SelectAsync<Setting>(s => s.Key == key, cancellationToken);

            return result.FirstOrDefault();
        }

        public void Save(string key, string value)
        {
            var setting = GetSetting(key) ?? new Setting
            {
                ChangedAt = DateTime.Now,
                ChangedBy = AccountRepository.User.Id,
                Key = key
            };

            setting.Value = value;
            Save(setting);
        }

        public void Save(Setting setting)
        {
            _context.Connection.Save(setting);
        }
    }
}
