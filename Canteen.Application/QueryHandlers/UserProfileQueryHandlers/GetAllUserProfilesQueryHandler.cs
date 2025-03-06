//using System;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using Canteen.Application.Enums;
//using Canteen.Application.OperationModels;
//using Canteen.Application.Queries.UserProfileQueries;
//using Canteen.DataAccessLayer.Data;
//using Canteen.Domain.Aggregates.UserProfileAggregate;
//using MediatR;
//using MongoDB.Driver;

//namespace Canteen.Application.QueryHandlers.UserProfileQueryHandlers
//{
//    public class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfiles, OperationResult<IEnumerable<UserProfile>>>
//    {
//        private readonly MongoDbContext _mongoDbContext;

//        public GetAllUserProfilesQueryHandler(MongoDbContext mongoDbContext)
//        {
//            _mongoDbContext = mongoDbContext;
//        }

//        public async Task<OperationResult<IEnumerable<UserProfile>>> Handle(GetAllUserProfiles request, CancellationToken cancellationToken)
//        {
//            var operationResult = new OperationResult<IEnumerable<UserProfile>>();

//            try
//            {
//                var userProfiles = await _mongoDbContext.UserProfiles.Find(_ => true).ToListAsync(cancellationToken);
//                operationResult.Payload = userProfiles;
//            }
//            catch (Exception e)
//            {
//                operationResult.IsError = true;
//                var error = new Error
//                {
//                    Code = ErrorCode.UnknownError,
//                    Message = $"{e.Message}"
//                };
//                operationResult.Errors.Add(error);
//            }

//            return operationResult;
//        }
//    }
//}


//updated code using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Canteen.Application.Enums;
using Canteen.Application.OperationModels;
using Canteen.Application.Queries.UserProfileQueries;
using Canteen.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Canteen.DataAccessLayer.MongoRepositories;  // Ensure to import your repository namespace

namespace Canteen.Application.QueryHandlers.UserProfileQueryHandlers
{
    public class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfiles, OperationResult<IEnumerable<UserProfile>>>
    {
        private readonly IMongoGenericRepository<UserProfile> _userProfileRepository;

        
        public GetAllUserProfilesQueryHandler(IMongoGenericRepository<UserProfile> userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<OperationResult<IEnumerable<UserProfile>>> Handle(GetAllUserProfiles request, CancellationToken cancellationToken)
        {
            var operationResult = new OperationResult<IEnumerable<UserProfile>>();

            try
            {
               
                var userProfiles = await _userProfileRepository.GetAllAsync(cancellationToken);
                operationResult.Payload = userProfiles;
            }
            catch (Exception e)
            {
                operationResult.IsError = true;
                var error = new Error
                {
                    Code = ErrorCode.UnknownError,
                    Message = $"{e.Message}"
                };
                operationResult.Errors.Add(error);
            }

            return operationResult;
        }
    }
}
