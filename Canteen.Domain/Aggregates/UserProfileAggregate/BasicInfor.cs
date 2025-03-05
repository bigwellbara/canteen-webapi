using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen.Domain.Exceptions;
using Canteen.Domain.Validators.UserProfileValidators;

namespace Canteen.Domain.Aggregates.UserProfileAggregate
{
    public class BasicInfor
    {

        private BasicInfor()
        {

        }


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

        //factory method
        public static BasicInfor CreateBasicInfo(string firstName, string lastName, string emailAddress, string phone, DateTime dateOfBirth, string currentCity)
        {
            //adding validation, error handling and error notification strategies
            var basicInfoValidator = new BasicInformationValidator();
            var basicInfoObjectToValidate = new BasicInfor
            {

                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                Phone = phone,
                DateOfBirth = dateOfBirth,
                CurrentCity = currentCity
            };

            var validationResult = basicInfoValidator.Validate(basicInfoObjectToValidate);

            if (validationResult.IsValid)
            {
                return basicInfoObjectToValidate;
            }

            var userProfileBasicInforException = new UserProfileNotValidException("The user profile is not valid.");
            foreach (var error in validationResult.Errors)
            {
                userProfileBasicInforException.validationErrors.Add(error.ErrorMessage);
            }

            throw userProfileBasicInforException;


        }
    }
}
