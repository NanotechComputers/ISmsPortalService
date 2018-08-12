using System;
using Microsoft.Extensions.DependencyInjection;

namespace SmsPortal.Extensions
{
     // ReSharper disable once UnusedMember.Global
    public static class SmsPortalServiceCollectionExtensions
    {
        // ReSharper disable once UnusedMember.Global
        public static IServiceCollection AddSmsPortal(this IServiceCollection collection, Action<SmsPortalServiceOptions> setupAction)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));

            collection.Configure(setupAction);

            return collection.AddScoped<ISmsPortalService, SmsPortalService>();
        }
    }
}