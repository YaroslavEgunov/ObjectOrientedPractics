namespace ObjectOrientedPractics.Model.Enums
{
    /// <summary>
    /// Хранит описание заказа.
    /// </summary>
    public enum OrderStatus
    {
        New,
        Processing,
        Assembly,
        Sent,
        Delivered,
        Returned,
        Abandoned
    }
}