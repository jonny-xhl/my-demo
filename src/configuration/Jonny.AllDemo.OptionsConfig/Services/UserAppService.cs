using Jonny.AllDemo.OptionsConfig.Entity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jonny.AllDemo.OptionsConfig.Services
{
    public class UserAppService : IUserAppService
    {
        protected readonly IdentityClientOption _identityMonitor;
        protected readonly IdentityClientOption _identitySnapshot;
        protected readonly IdentityClientOption _identity;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsMonitor">只要Option值一变，那么获取的时候就会变</param>
        /// <param name="optionsSnapshot">同一个Scope中更改Option时值时不会变的</param>
        /// <param name="options"></param>
        public UserAppService(IOptionsMonitor<IdentityClientOption> optionsMonitor,
            IOptionsSnapshot<IdentityClientOption> optionsSnapshot,
            IOptions<IdentityClientOption> options)
        {
            _identityMonitor = optionsMonitor?.CurrentValue;
            _identitySnapshot = optionsSnapshot?.Value;
            _identity = options?.Value;
            Console.WriteLine($"Monitor:\t{_identityMonitor?.ToString()}");
            Console.WriteLine($"Snapshot:\t{_identitySnapshot?.ToString()}");
            Console.WriteLine($"Options:\t{_identity?.ToString()}");
        }
        public List<AppUser> GetUsers()
        {
            return new List<AppUser>
            {
                new AppUser
                {
                    Name="Jonny",
                    Age=25,
                    Gender=Gender.Male
                }
            };
        }
    }
}
