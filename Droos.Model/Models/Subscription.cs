using System;
using System.Collections.Generic;

namespace Droos.Models;

public partial class Subscription
{
    public Guid SubscriptionId { get; set; }

    public Guid? SubscriptionOwner { get; set; }

    public int? SubscriptionType { get; set; }

    public bool? PaymentConfirmed { get; set; }

    public Guid? PayableItemId { get; set; }

    public Guid? PaymentConfirmedBy { get; set; }

    public virtual PayableItem? PayableItem { get; set; }
}
