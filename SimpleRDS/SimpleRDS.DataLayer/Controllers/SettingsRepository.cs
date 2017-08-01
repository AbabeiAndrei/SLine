using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
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

        public Setting GetSetting(string key)
        {
            return _context.Settings.FirstOrDefault(s => s.Key == key);
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
