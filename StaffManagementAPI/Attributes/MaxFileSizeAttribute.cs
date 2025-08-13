using System.ComponentModel.DataAnnotations;

namespace StaffManagementAPI.Attributes
{
    public class MaxFileSizeAttribute: ValidationAttribute
    {
        private readonly int _maxFileSize;
        private readonly int _maxFileSizeKB;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
            _maxFileSizeKB = _maxFileSize * 1024;
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null && file.Length > _maxFileSizeKB)
            {
                return new ValidationResult($"Maximum allowed file size is {_maxFileSize} KB.");
            }
            return ValidationResult.Success;
        }
    }
}
