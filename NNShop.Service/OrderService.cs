using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NNShop.Common.ViewModels;
using NNShop.Data.Infrastructure;
using NNShop.Data.Repositories;
using NNShop.Model.Models;

namespace NNShop.Service
{
    public interface IOrderService
    {
        bool Create(Order order, List<OrderDetail> orderDetails);

        void Update(Order order);

        Order Delete(int id);

        IEnumerable<Order> GetAll();

        IEnumerable<Order> GetAll(string keyword);

        IEnumerable<Order> GetAllPaging(int page, int pageSize, out int totalRow);

        Order GetById(int id);

        IEnumerable<Order> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);

        void SaveChanges();

        bool ChangeStatus(int id);

        IEnumerable<OrderGetNameByProduct> GetNameProduct(int id);
    }

    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        IOrderDetailRepository _orderDetailrepository;
        IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            this._orderRepository = orderRepository;
            this._orderDetailrepository = orderDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public bool Create(Order order, List<OrderDetail> orderDetails)
        {
            try
            {
                _orderRepository.Add(order);
                _unitOfWork.Commit();
                foreach (var orderDetail in orderDetails)
                {
                    orderDetail.OrderID = order.ID;
                    _orderDetailrepository.Add(orderDetail);
                }
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Order Delete(int id)
        {
            return _orderRepository.Delete(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public IEnumerable<Order> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            //TODO: Select all post by tag
            return _orderRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public IEnumerable<Order> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _orderRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Order order)
        {
            _orderRepository.Update(order);
        }

        public IEnumerable<Order> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _orderRepository.GetMulti(x => x.CustomerName.Contains(keyword) || x.CustomerMobile.Contains(keyword));
            else
                return _orderRepository.GetAll();
        }

        public bool ChangeStatus(int id)
        {
            var order = _orderRepository.GetSingleById(id);
            order.Status = !order.Status;
            return !order.Status;
        }

        public IEnumerable<OrderGetNameByProduct> GetNameProduct(int id)
        {
            return _orderRepository.GetByNameProduct(id);
        }
    }
}
