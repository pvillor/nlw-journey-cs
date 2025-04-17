using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Activities.Complete;

public class CompleteActivityUseCase
{
    public void Execute(Guid tripId, Guid activityId)
    {
        var dbContext = new JourneyDbContext();

        var activity = dbContext
            .Activities
            .FirstOrDefault(a => a.Id == activityId && a.TripId == tripId);

        if (activity is null)
        {
            throw new NotFoundException(ResourceErrorMessages.TRIP_NOT_FOUND);
        }

        activity.Status = ActivityStatus.Done;

        dbContext.Activities.Update(activity);
        dbContext.SaveChanges();
    }
}
