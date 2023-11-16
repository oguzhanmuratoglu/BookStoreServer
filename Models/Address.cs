using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookStoreServer.Models;

public class Address
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int? OrderId { get; set; }
    public Order? Order { get; set; }
    public string AddressType { get; set; }
    public string ContactName { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhoneNumber { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    public string AddressDescription { get; set; }
}

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(ba => ba.AddressType).IsRequired().HasMaxLength(20);
        builder.Property(ba => ba.ContactName).IsRequired().HasMaxLength(50);
        builder.Property(ba => ba.ContactEmail).IsRequired().HasMaxLength(255);
        builder.Property(ba => ba.ContactPhoneNumber).HasMaxLength(20);
        builder.Property(ba => ba.City).IsRequired().HasMaxLength(100);
        builder.Property(ba => ba.Country).IsRequired().HasMaxLength(100);
        builder.Property(ba => ba.ZipCode).IsRequired().HasMaxLength(20);

    }
}