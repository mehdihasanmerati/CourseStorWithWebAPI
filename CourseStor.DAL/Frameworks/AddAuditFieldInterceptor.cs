using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStor.DAL.Frameworks
{
    public class AddAuditFieldInterceptor: SaveChangesInterceptor
    {
        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            SetShadowProperties(eventData);

            return base.SavedChanges(eventData, result);
        }

        private static void SetShadowProperties(SaveChangesCompletedEventData eventData)
        {
            var changeTracker = eventData.Context.ChangeTracker;
            var addetEntities = changeTracker.Entries().Where(c => c.State == Microsoft.EntityFrameworkCore.EntityState.Added);
            var modifiedEntries = changeTracker.Entries().Where(c => c.State == Microsoft.EntityFrameworkCore.EntityState.Modified);

            var now = DateTime.Now;
            foreach (var item in addetEntities)
            {
                item.Property("CreateBy").CurrentValue = "1";
                item.Property("UpdateBy").CurrentValue = "1";
                item.Property("CreateDate").CurrentValue = now;
                item.Property("UpdateDate").CurrentValue = now;
            }

            foreach (var item in modifiedEntries)
            {
                item.Property("UpdateBy").CurrentValue = "1";
                item.Property("UpdateDate").CurrentValue = now;
            }
        }

        public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            SetShadowProperties(eventData);
            return base.SavedChangesAsync(eventData, result, cancellationToken);
        }
    }
}
