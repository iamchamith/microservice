using Abp.Domain.Values;
using App.SharedKernel.Utilities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.SharedKernel.ValueObjects
{
    public class PersonName : ValueObject
    {
        [Required,StringLength(DataAnnotationsConst.NAME_LENGTH), Column(nameof(FirstName))]
        public string FirstName { get; private set; }
        [StringLength(DataAnnotationsConst.NAME_LENGTH), Column(nameof(MiddleName))]
        public string MiddleName { get; private set; }
        [Required, StringLength(DataAnnotationsConst.NAME_LENGTH), Column(nameof(LastName))]
        public string LastName { get; private set; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return MiddleName;
            yield return LastName;
        }
        public PersonName(string firstName,string middleName,string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }
    }
}
