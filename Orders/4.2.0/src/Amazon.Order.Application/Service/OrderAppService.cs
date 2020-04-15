using System;
using Abp.Domain.Repositories;
using Amazon.Order.Dto;
using App.SharedKernel.Model;
using System.Threading.Tasks;
using entity = Amazon.Order.Entities;
using App.SharedKernel.Extension;
using System.Linq;
using App.SharedKernel.Exception;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using App.SharedKernel.Application;
using Amazon.Order.Interface;

namespace Amazon.Order.Service
{
    public class OrderAppService : OrderAppServiceBase,IOrderAppService
    {
        IRepository<entity.Order> _orderRepository;
        IRepository<entity.CustomerInfo> _customerRepository;
        public OrderAppService(IRepository<entity.Order> orderRepository,
            IRepository<entity.CustomerInfo> customerRepository, IApplicationInjector applicationInjector) : base(applicationInjector)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public async Task<Response<OrderDto>> CreateOrder(Request<OrderDto> request)
        {
            try
            {
                var customer = await _customerRepository.GetAsync(request.UserId);
                var order = new entity.Order(customer);
                request.Item.OrderItems.ForEach(item =>
                {
                    order.AddItem(item.Id, item.Name, item.Quantity, item.UnitPrice);
                });
                request.Item.Payments.ForEach(item =>
                {
                    order.AddPayment(new entity.Payment(item.Amount, item.PaymentDoneBy));
                });
                order.SetShipping(new entity.Shipping(customer.Address, customer.Phone, customer.Email));
                var result = await _orderRepository.InsertAsync(order);
                return Response(Mapper.Map<OrderDto>(result));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Response<OrderDto>> ReadOrderByOrderId(Request<int> request)
        {
            try
            {
                var result = await _orderRepository.GetAllAsNoTraking()
                    .Include(p => p.Shipping)
                    .Include(p => p.OrderItems)
                    .Include(p => p.Payments)
                    .Include(p => p.Shipping)
                    .Where(p => p.Id == request.Item)
                    .SingleAsync();
                return Response(Mapper.Map<OrderDto>(result));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Response<List<OrderDto>>> ReadOrdersByCustomer(Request<int> request)
        {
            try
            {
                var customer = await _customerRepository.GetAsync(request.UserId);
                if (customer.IsNull() || customer.IsDeleted)
                    throw new BadRequestException($"Invalid Customer {request.UserId}".MakeThisRedable());
                var result = await _orderRepository.GetAllAsNoTraking()
                    .Where(p => p.CustomerId == customer.Id)
                    .ToListAsync();
                return Response(Mapper.Map<List<OrderDto>>(result));
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
