using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel;
using Common.Extensions;

namespace AppHarbor.Models
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        public Address HomeAddress { get; set; }
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
    }

    public class Address
    {
        [DisplayName("Street")]
        public string Line1         { get; set; }
        [DisplayName("Appartment Number")]
        public string Line2         { get; set; }
        public string City          { get; set; }
        public string State         { get; set; }
        [DisplayName("Postal Code")]
        public string PostalCode    { get; set; }
        public string Country       { get; set; }
    }

    public class Song
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public byte[] BinaryData
        {
            get
            {
                return this.BinaryData.Decompress();
            }
            set
            {
                this.BinaryData = value.Compress();
            }
        }
    }


    public class DefaultConnection : DbContext
    {
        public DbSet<Person> People { get; set; }

        public DbSet<Song> Songs { get; set; }
    }
}