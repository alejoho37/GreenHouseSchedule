﻿using DataAccess.Contracts;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class OrderRepository : GenericRepository, IOrderRepository
    {

        public OrderRepository(SowScheduleDBEntities dbContex) : base(dbContex)
        {
        }

        public OrderRepository()
        {
        }

        public IEnumerable<Order> GetAll()
        {
            return _sowScheduleDB.Orders;
        }

        public bool Insert(Order entity)
        {
            try
            {
                _sowScheduleDB.Orders.Add(entity);
                _sowScheduleDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(int pId)
        {
            try
            {
                Order order = _sowScheduleDB.Orders.Find(pId);
                _sowScheduleDB.Orders.Remove(order);
                _sowScheduleDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Order entity)
        {
            Order order = _sowScheduleDB.Orders.Find(entity.ID);
            if (order != null)
            {
                order.ID = entity.ID;
                order.ClientId = entity.ClientId;
                order.ProductId = entity.ProductId;
                order.AmountofWishedSeedlings = entity.AmountofWishedSeedlings;
                order.AmountofAlgorithmSeedlings = entity.AmountofAlgorithmSeedlings;
                order.WishDate = entity.WishDate;
                order.DateOfRequest = entity.DateOfRequest;
                order.EstimateSowDate = entity.EstimateSowDate;
                order.EstimateDeliveryDate = entity.EstimateDeliveryDate;
                order.RealSowDate = entity.RealSowDate;
                order.RealDeliveryDate = entity.RealDeliveryDate;
                order.Complete = entity.Complete;
                _sowScheduleDB.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
