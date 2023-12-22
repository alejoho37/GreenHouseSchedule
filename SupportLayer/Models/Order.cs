﻿using System;
using System.Collections.Generic;

namespace SupportLayer.Models;

public partial class Order
{
    public short Id { get; set; }

    public short ClientId { get; set; }

    public byte ProductId { get; set; }

    public int AmountofWishedSeedlings { get; set; }

    public int AmountofAlgorithmSeedlings { get; set; }

    public DateOnly WishDate { get; set; }

    public DateOnly DateOfRequest { get; set; }

    public DateOnly EstimateSowDate { get; set; }

    public DateOnly EstimateDeliveryDate { get; set; }

    public DateOnly? RealSowDate { get; set; }

    public DateOnly? RealDeliveryDate { get; set; }

    public bool Complete { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<OrderLocation> OrderLocations { get; set; } = new List<OrderLocation>();

    public virtual Product Product { get; set; } = null!;
}
