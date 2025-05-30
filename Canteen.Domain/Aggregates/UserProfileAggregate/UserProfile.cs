﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Canteen.Domain.Aggregates.UserProfileAggregate
{
    public class UserProfile
    {
        [BsonId]  
        [BsonRepresentation(BsonType.String)] 
        public Guid UserProfileId { get; set; } = Guid.NewGuid(); 

        public string? IdentityId { get; set; }

        public BasicInfor? BasicInfor { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime LastModified { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public string? DeletedBy { get; private set; }

        // Factory method to create the user
        public static UserProfile CreateUserProfile(string identityId, BasicInfor basicInfor)
        {
            return new UserProfile
            {
                IdentityId = identityId,
                BasicInfor = basicInfor,
                DateCreated = DateTime.UtcNow,
                LastModified = DateTime.UtcNow
            };
        }

        // Public method to update Basic Information
        public void UpdateBasicInfor(BasicInfor newBasicInfor)
        {
            BasicInfor = newBasicInfor;
            LastModified = DateTime.UtcNow;
        }

      

        public void SoftDelete(string deletedBy = null)
        {
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
            DeletedBy = deletedBy;
            LastModified = DateTime.UtcNow;
        }

        public void Restore()
        {
            IsDeleted = false;
            DeletedAt = null;
            DeletedBy = null;
            LastModified = DateTime.UtcNow;
        }
    }
}
