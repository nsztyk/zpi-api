using Microsoft.EntityFrameworkCore;
using ZPI.Core.Abstraction.Repositories;
using ZPI.Core.Domain;
using ZPI.Core.Exceptions;
using ZPI.Persistance.Entities;
using ZPI.Persistance.Mappings;
using ZPI.Persistance.ZPIDb;

namespace ZPI.Persistance.Repositories;

public class UserPreferencesRepository : IUserPreferencesRepository
{
    private readonly ZPIDbContext context;
    private readonly IPersistanceMapper mapper;
    public UserPreferencesRepository(ZPIDbContext context, IPersistanceMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<UserPreferencesModel> CreateAsync(IUserPreferencesRepository.AddUserFromAuth0 createModel)
    {
        var user = new UserPreferencesEntity()
        {
            AlertsOnEmail = false,
            PreferenceCurrency = "usd",
            UserId = createModel.UserId,
            WeeklyReports = false,
            IsDefault = true
        };

        var entry = await this.context.AddAsync(user);

        await this.context.SaveChangesAsync();
        return this.mapper.Map<UserPreferencesModel>(entry.Entity);
    }

    public async Task<UserPreferencesModel> GetAsync(IUserPreferencesRepository.GetUserPreferences getModel)
    {
        var userPreferences = await context.UserPreferences.FirstOrDefaultAsync(userPreference => userPreference.UserId == getModel.UserId);

        if (userPreferences is null)
        {
            throw new UserNotFoundException(UserNotFoundException.GenerateBaseMessage(getModel.UserId));
        }

        return mapper.Map<UserPreferencesModel>(userPreferences);
    }

    public async Task<UserPreferencesModel> UpdateAsync(IUserPreferencesRepository.UpdateUserPreferences updateModel)
    {
        var userPreferences = await context.UserPreferences.FirstOrDefaultAsync(userPreference => userPreference.UserId == updateModel.UserId);

        if (userPreferences is null)
        {
            throw new UserNotFoundException(UserNotFoundException.GenerateBaseMessage(updateModel.UserId));
        }

        mapper.Map(updateModel, userPreferences);

        userPreferences.IsDefault = false;

        await this.context.SaveChangesAsync();

        return mapper.Map<UserPreferencesModel>(userPreferences);
    }
}