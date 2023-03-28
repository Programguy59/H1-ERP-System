﻿using H1_ERP_System.sales;

namespace H1_ERP_System.db;

public partial class Database
{
	private static readonly List<Order> Orders = new();
	private static readonly List<OrderLine> OrderLines = new();
	
	private static int _nextOrderId = 1;
	
	public static Order? GetOrderById(int id)
	{
		return Orders.FirstOrDefault(order => order.Id == id);
	}

	public static List<Order> GetAllOrders()
	{
		return Orders;
	}

	public static void InsertOrder(Order order)
	{
		order.Id = _nextOrderId++;

		Orders.Add(order);
	}

	public static bool UpdateOrder(Order order, int id)
	{
		var existingOrder = GetOrderById(id);
		if (existingOrder == null)
		{
			return false;
		}

		existingOrder.CreatedAt = order.CreatedAt;
		existingOrder.CompletedAt = order.CompletedAt;

		existingOrder.CustomerId = order.CustomerId;
		
		existingOrder.OrderStatus = order.OrderStatus;
		
		existingOrder.TotalPrice = order.TotalPrice;
		
		return true;
	}

	public static bool DeleteOrderById(int id)
	{
		var orderToDelete = GetOrderById(id);

		if (orderToDelete == null)
		{
			return false;
		}

		Orders.Remove(orderToDelete);

		return true;
	}

	public static void ClearOrders()
	{
		Orders.Clear();
	}
	
	public static OrderLine? GetOrderLineById(int id)
	{
		return OrderLines.FirstOrDefault(orderLine => orderLine.Id == id);
	}
	
	public static List<OrderLine> GetAllOrderLines()
	{
		return OrderLines;
	}
	
	public static void InsertOrderLine(OrderLine orderLine)
	{
		orderLine.Id = _nextOrderId++;

		OrderLines.Add(orderLine);
	}
	
	public static bool UpdateOrderLine(OrderLine orderLine, int id)
	{
		var existingOrderLine = GetOrderLineById(id);
		if (existingOrderLine == null)
		{
			return false;
		}

		existingOrderLine.ProductId = orderLine.ProductId;
		existingOrderLine.Quantity = orderLine.Quantity;
		
		return true;
	}
	
	public static bool DeleteOrderLineById(int id)
	{
		var orderLineToDelete = GetOrderLineById(id);
		if (orderLineToDelete == null)
		{
			return false;
		}

		OrderLines.Remove(orderLineToDelete);

		return true;
	}
	
	public static void ClearOrderLines()
	{
		OrderLines.Clear();
	}
}
