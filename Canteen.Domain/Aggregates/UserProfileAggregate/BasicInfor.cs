//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Canteen.Domain.Exceptions;
//using Canteen.Domain.Validators.UserProfileValidators;

//namespace Canteen.Domain.Aggregates.UserProfileAggregate
//{
//    public class BasicInfor
//    {

//        private BasicInfor()
//        {

//        }


//        public string FirstName { get; private set; }
//        public string LastName { get; private set; }
//        public string EmailAddress { get; private set; }
//        public string Phone { get; private set; }
//        public DateTime DateOfBirth { get; private set; }

//        public string CurrentCity { get; private set; }

//        /// <summary>
//        /// Creates a new BasicInfo instance
//        /// </summary>
//        /// <param name="firstName">First Name</param>
//        /// <param name="lastName">Last Name</param>
//        /// <param name="emailAddress">Email Address</param>
//        /// <param name="phone">Phone</param>
//        /// <param name="dateOfBirth">Date of Birth</param>
//        /// <param name="currentCity">Current City</param>
//        /// <returns><see cref="BasicInfor"/></returns>
//        /// <exception cref="UserProfileNotValidException">Thrown if not valid</exception>

//        //factory method
//        public static BasicInfor CreateBasicInfo(string firstName, string lastName, string emailAddress, string phone,
//            DateTime dateOfBirth, string currentCity)
//        {
//            //adding validation, error handling and error notification strategies
//            var basicInfoValidator = new BasicInformationValidator();
//            var basicInfoObjectToValidate = new BasicInfor
//            {

//                FirstName = firstName,
//                LastName = lastName,
//                EmailAddress = emailAddress,
//                Phone = phone,
//                DateOfBirth = dateOfBirth,
//                CurrentCity = currentCity
//            };

//            var validationResult = basicInfoValidator.Validate(basicInfoObjectToValidate);

//            if (validationResult.IsValid)
//            {
//                return basicInfoObjectToValidate;
//            }
//            var validationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

//            // Join all errors into a single string
//            var errorMessage = string.Join(Environment.NewLine, validationErrors);
//            var userProfileBasicInforException = new UserProfileNotValidException(errorMessage);
//            foreach (var error in validationResult.Errors)
//            {
//                userProfileBasicInforException.validationErrors.Add(error.ErrorMessage);
//            }

//            throw userProfileBasicInforException;


//        }

//        public static BasicInfor UpdateFirstName(string firstName)
//        {
//            //adding validation, error handling and error notification strategies
//            var basicInfoValidator = new BasicInformationValidator();
//            var basicInfoObjectToValidate = new BasicInfor
//            {

//                FirstName = firstName,

//            };

//            var validationResult = basicInfoValidator.Validate(basicInfoObjectToValidate);

//            if (validationResult.IsValid)
//            {
//                return basicInfoObjectToValidate;
//            }
//            var validationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

//            // Join all errors into a single string
//            var errorMessage = string.Join(Environment.NewLine, validationErrors);
//            var userProfileBasicInforException = new UserProfileNotValidException(errorMessage);
//            foreach (var error in validationResult.Errors)
//            {
//                userProfileBasicInforException.validationErrors.Add(error.ErrorMessage);
//            }

//            throw userProfileBasicInforException;


//        }
//    }
//}



using System;
using System.Collections.Generic;
using System.Linq;
using Canteen.Domain.Exceptions;
using Canteen.Domain.Validators.UserProfileValidators;
using FluentValidation;

namespace Canteen.Domain.Aggregates.UserProfileAggregate
{
    public class BasicInfor
    {
        private BasicInfor() { }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string Phone { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string CurrentCity { get; private set; }


        /// <summary>
        /// Creates a new BasicInfo instance
        /// </summary>
        /// <param name="firstName">First Name</param>
        /// <param name="lastName">Last Name</param>
        /// <param name="emailAddress">Email Address</param>
        /// <param name="phone">Phone</param>
        /// <param name="dateOfBirth">Date of Birth</param>
        /// <param name="currentCity">Current City</param>
        /// <returns><see cref="BasicInfor"/></returns>
        /// <exception cref="UserProfileNotValidException">Thrown if not valid</exception>


        // Factory method for creating new BasicInfo
        public static BasicInfor CreateBasicInfo(
            string firstName, string lastName, string emailAddress,
            string phone, DateTime dateOfBirth, string currentCity)
        {
            var basicInfo = new BasicInfor
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                Phone = phone,
                DateOfBirth = dateOfBirth,
                CurrentCity = currentCity
            };

            ValidateBasicInfo(basicInfo);
            return basicInfo;
        }

   
        private static void ValidateBasicInfo(BasicInfor basicInfo)
        {
            var validator = new BasicInformationValidator();
            var validationResult = validator.Validate(basicInfo);

            if (!validationResult.IsValid)
            {
                var validationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                var errorMessage = string.Join(Environment.NewLine, validationErrors);
                var exception = new UserProfileNotValidException(errorMessage);

                foreach (var error in validationResult.Errors)
                {
                    exception.validationErrors.Add(error.ErrorMessage);
                }

                throw exception;
            }
        }


        // Add this new method for partial updates
        public static BasicInfor CreatePartialUpdate(
            BasicInfor existingInfo,
            string firstName = null,
            string lastName = null,
            string emailAddress = null,
            string phone = null,
            DateTime? dateOfBirth = null,
            string currentCity = null)
        {
            var updatedInfo = new BasicInfor
            {
                FirstName = firstName ?? existingInfo.FirstName,
                LastName = lastName ?? existingInfo.LastName,
                EmailAddress = emailAddress ?? existingInfo.EmailAddress,
                Phone = phone ?? existingInfo.Phone,
                DateOfBirth = dateOfBirth ?? existingInfo.DateOfBirth,
                CurrentCity = currentCity ?? existingInfo.CurrentCity
            };

            // Validate only non-null fields
            var validator = new BasicInformationValidator();
            var validationResult = validator.Validate(updatedInfo, opts =>
            {
                if (firstName != null) opts.IncludeProperties(x => x.FirstName);
                if (lastName != null) opts.IncludeProperties(x => x.LastName);
                if (emailAddress != null) opts.IncludeProperties(x => x.EmailAddress);
                if (phone != null) opts.IncludeProperties(x => x.Phone);
                if (dateOfBirth != null) opts.IncludeProperties(x => x.DateOfBirth);
                if (currentCity != null) opts.IncludeProperties(x => x.CurrentCity);
            });

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                throw new UserProfileNotValidException(string.Join(", ", errors));
            }

            return updatedInfo;
        }


    }
}