using BookStoreServer.Context;
using BookStoreServer.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookStoreServer.Models;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string OrderNumber { get; set; }
    public OrderStatusEnumEn StatusEn { get; set; } = OrderStatusEnumEn.AwaitingApproval;
    public OrderStatusEnumTr StatusTr { get; set; } = OrderStatusEnumTr.OnayBekleniyor;
    public DateTime StatusDate { get; set; } = DateTime.Now;
    public PaymentTypeEnum PaymentType { get; set; }
    public DateTime OrderDate { get; set; }= DateTime.Now;
    public List<Address> DeliveryAddresses { get; set; }
    public ShippingModule ShippingModule { get; set; }

    public List<OrderItem> OrderItems { get; set; }
    public decimal TotalOrderPriceAmount { get; set; }
    public string PriceCurrency { get; set; }
    public int TotalOrderQuantity
    {
        get
        {
            return OrderItems.Sum(item => item.Quantity);
        }
    }

    public static string GetNewOrderNumber()
    {
        string initialLetter = "MRT";
        string year = DateTime.Now.Year.ToString();
        string newOrderNumber = initialLetter + year;

        BookwormDbContext context = new();
        var lastOrder = context.Orders.OrderByDescending(o => o.Id).FirstOrDefault();
        string currentOrderNumber = lastOrder?.OrderNumber;

        if (currentOrderNumber != null)
        {
            string currentYear = currentOrderNumber.Substring(3, 4);
            int startIndex = (currentYear == year) ? 7 : 0;
            GenerateUniqueOrderNumber(context, ref newOrderNumber, currentOrderNumber.Substring(startIndex));
        }
        else
        {
            newOrderNumber += "000000001";
        }

        return newOrderNumber;
    }

    private static void GenerateUniqueOrderNumber(BookwormDbContext context, ref string newOrderNumber, string currentOrderNumStr)
    {
        int currentOrderNumberInt = int.TryParse(currentOrderNumStr, out var num) ? num : 0;
        bool isOrderNumberUnique = false;

        while (!isOrderNumberUnique)
        {
            currentOrderNumberInt++;
            newOrderNumber += currentOrderNumberInt.ToString("D9");
            string checkOrderNumber = newOrderNumber;
            var order = context.Orders.FirstOrDefault(o => o.OrderNumber == checkOrderNumber);
            if (order == null)
            {
                isOrderNumberUnique = true;
            }
        }
    }
}

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(oi => oi.PriceCurrency).IsRequired().HasMaxLength(5);
        builder.HasIndex(p => p.OrderNumber).IsUnique();
    }
}
