using Canteen.Application.Enums;
using Canteen.Application.OperationModels;
using Canteen.DataAccessLayer.MongoRepositories;
using Canteen.Domain.Aggregates.MenuItemAggregate;
using Canteen.Domain.Exceptions;

public abstract class BaseMenuItemCommandHandler
{
    protected readonly IMongoGenericRepository<MenuItem> _menuItemRepository;

    protected BaseMenuItemCommandHandler(IMongoGenericRepository<MenuItem> menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
    }

    protected async Task<OperationResult<MenuItem>> HandleCommonAsync(
        Guid menuItemId,
        Func<MenuItem, Task> updateAction,
        CancellationToken cancellationToken)
    {
        var operationResult = new OperationResult<MenuItem>();

        try
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(menuItemId, cancellationToken);

            if (menuItem is null)
            {
                operationResult.IsError = true;
                operationResult.Errors.Add(new Error
                {
                    Code = ErrorCode.NotFound,
                    Message = $"Menu item with ID {menuItemId} not found"
                });
                return operationResult;
            }

            await updateAction(menuItem);
            await _menuItemRepository.UpdateAsync(menuItemId, menuItem, cancellationToken);

            operationResult.Payload = menuItem;
            return operationResult;
        }
        catch (MenuItemNotValidException ex)
        {
            operationResult.IsError = true;
            ex.validationErrors.ForEach(e =>
            {
                operationResult.Errors.Add(new Error
                {
                    Code = ErrorCode.ValidationError,
                    Message = e
                });
            });
            return operationResult;
        }
        catch (Exception ex)
        {
            operationResult.IsError = true;
            operationResult.Errors.Add(new Error
            {
                Code = ErrorCode.ServerError,
                Message = ex.Message
            });
            return operationResult;
        }
    }
}