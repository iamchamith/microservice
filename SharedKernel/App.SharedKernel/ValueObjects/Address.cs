using Abp.Domain.Values;
using App.SharedKernel.Utilities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.SharedKernel.ValueObjects
{
    public class Address : ValueObject
    {
        [Required, StringLength(DataAnnotationsConst.NAME_LENGTH), Column(nameof(Number))]
        public string Number { get; }
        [Required, StringLength(DataAnnotationsConst.NAME_LENGTH), Column(nameof(Street))]
        public string Street { get; }
        [Required, StringLength(DataAnnotationsConst.NAME_LENGTH), Column(nameof(City))]
        public string City { get; }

        public Address(string city,string street,string number)
        {
            City = city;
            Street = street;
            Number = number;
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
            yield return Number;
        }
    }
}
