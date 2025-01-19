using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using FluentValidation;
using FluentValidation.Results;

namespace AdventureAdorn.API.Core
{
    public interface IEntity
    {
    }
    public abstract class Entity<TId> : IDataErrorInfo, IEntity
    {
        private readonly IValidator _validator;

        protected Entity()
        {
            _validator = GetValidator();
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;
            IsActive = true;
        }

        public TId Id { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public void ModifiedBy(string userId)
        {
            LastModifiedBy = userId;
            LastModifiedDate = DateTime.UtcNow;
        }

        #region Validation

        [IgnoreDataMember]
        [NotMapped]
        public virtual bool IsValid
        {
            get
            {
                if (ValidationErrors != null && ValidationErrors.Any())
                    return false;
                return true;
            }
        }

        [IgnoreDataMember] [NotMapped] public IEnumerable<ValidationFailure> ValidationErrors { get; private set; }

        [IgnoreDataMember]
        public string ValidationErrorsMessage
        {
            get
            {
                var errors = new StringBuilder();

                if (ValidationErrors != null && ValidationErrors.Any())
                    foreach (var validationError in ValidationErrors)
                        errors.AppendLine(validationError.ErrorMessage);

                return errors.ToString();
            }
        }

        protected virtual IValidator GetValidator()
        {
            return null;
        }

        public void Validate()
        {
            if (_validator != null)
            {
                var context = new ValidationContext<Entity<TId>>(this);
                var results = _validator.Validate(context);
                ValidationErrors = results.Errors;
            }
        }


        #endregion

        #region IDataErrorInfo members

        string IDataErrorInfo.Error => string.Empty;

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                var errors = new StringBuilder();

                if (ValidationErrors != null && ValidationErrors.Any())
                    foreach (var validationError in ValidationErrors)
                        if (validationError.PropertyName == columnName)
                            errors.AppendLine(validationError.ErrorMessage);

                return errors.ToString();
            }
        }

        #endregion
    }
}