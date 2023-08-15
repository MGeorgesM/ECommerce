using Core.Entities.OrderAggregate;

namespace Core.Specifications
{
    public class OrdersWithItemsAndSortingSpecification : BaseSpecification<Order>
    {
        public OrdersWithItemsAndSortingSpecification(string buyerEmail) : base(o => o.BuyerEmail == buyerEmail)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.DeliveryMethod);
            AddOrderByDescending(o => o.OrderDate);
        }

        public OrdersWithItemsAndSortingSpecification(int id, string buyerEmail) : base(o => o.Id == id && o.BuyerEmail == buyerEmail)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.DeliveryMethod);
        }
    }
}