using Restaurant.DataAccess.Entities;
using Restaurant.DataAccess.Repositories;
using Restaurant.Domain.Models;

namespace Restaurant.Domain.Services
{
    public class OrderService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IRestaurantTableRepository _restaurantTableRepository;
        private readonly ITableOrderRepository _tableOrderRepository;
        private readonly ITableOrderItemRepository _tableOrderItemRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(
            IRestaurantRepository restaurantRepository,
            IRestaurantTableRepository restaurantTableRepository,
            ITableOrderRepository tableOrderRepository,
            ITableOrderItemRepository tableOrderItemRepository,
            IUserRepository userRepository,
            IProductRepository productRepository) 
        {
            _restaurantRepository = restaurantRepository;
            _restaurantTableRepository = restaurantTableRepository;
            _tableOrderRepository = tableOrderRepository;
            _tableOrderItemRepository = tableOrderItemRepository;
            _userRepository = userRepository;            _productRepository = productRepository;
        }

        public async Task<Dictionary<int, RestaurantTable?>> GetTablesInfo()
        {
            var restaurant = await this._restaurantRepository.GetRestaurantAsync();
            var tables = await this._restaurantTableRepository.GetByRestaurantIdAsync(restaurant.Id);

            Dictionary<int, RestaurantTable?> result = new();

            for (int i = 1; i  <= restaurant.NumberOfTables; i++)
            {
                if (tables.Any(x => x.TableNumber == i))
                {
                    var table = tables.First(x => x.TableNumber == i);
                    table.Restaurant = restaurant;
                    result.Add(i, table);
                }
                else
                {
                    result.Add(i, null);
                }
            }

            return result;
        }

        public async Task<DbUser?> GetOrderOwner(int tableNumber)
        {
            var restaurant = await this._restaurantRepository.GetRestaurantAsync();
            var table = await this._restaurantTableRepository.GetByIdAsync(restaurant.Id, tableNumber);
            if (table == null)
            {
                return null;
            }

            var order = await _tableOrderRepository.GetActiveOrderByTableNumber(restaurant.Id, table.TableNumber);
            if (order == null)
            {
                return null;
            }

            var user = await _userRepository.GetUserAsync(order.TableOwner);
            return user;
        }

        public async Task<OrderDetails?> GetTableOrderDetails(int tableNumber)
        {
            var restaurant = await this._restaurantRepository.GetRestaurantAsync();
            var table = await this._restaurantTableRepository.GetByIdAsync(restaurant.Id, tableNumber);
            if (table == null)
            {
                return null;
            }
            
            var order = await _tableOrderRepository.GetActiveOrderByTableNumber(restaurant.Id, table.TableNumber);
            if (order == null)
            {
                return null;
            }

            List<TableOrderItem> orderItems = await _tableOrderItemRepository.GetByTableOrder(order.Id);
            return new OrderDetails(order, orderItems);
        }

        public async Task<TableOrderItem> AddTableOrder(DbUser owner, int tableNumber, int productId, double quantity)
        {
            var restaurant = await this._restaurantRepository.GetRestaurantAsync();
            var table = await this._restaurantTableRepository.GetByIdAsync(restaurant.Id, tableNumber);
            var hasActiveOrder = false;

            if (table == null)
            {
                table = new RestaurantTable()
                {
                    Restaurant = restaurant,
                    RestaurantId = restaurant.Id,
                    HasActiveOrder = true,
                    TableNumber = tableNumber,
                };
                await _restaurantTableRepository.InsertAsync(table);
                hasActiveOrder = false;
            } 
            else
            {
                hasActiveOrder = table.HasActiveOrder;
                await _restaurantTableRepository.OpenOrder(table);
            }

            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                throw new ArgumentException("Provided product is invalid.");
            }

            TableOrder? order;
            if (hasActiveOrder)
            {
                order = await _tableOrderRepository.GetActiveOrderByTableNumber(restaurant.Id, table.TableNumber);
                if (order == null)
                {
                    throw new Exception("Data inconsistency");
                }
            }
            else
            {
                await _restaurantTableRepository.OpenOrder(table);
                
                order = new TableOrder()
                {
                    RestaurantId = restaurant.Id,
                    TableNumber = table.TableNumber,
                    RestaurantTable = table,
                    TableOwner = owner.Id,
                    User = owner,
                    ClosedOrder = false
                };
                await _tableOrderRepository.InsertAsync(order);
            }

            TableOrderItem item = new TableOrderItem()
            {
                TableOrderId = order.Id,
                TableOrder = order,
                ProductId = product.Id,
                Product = product,
                ProductPrice = product.Price,
                ProductQuantity = quantity,
                ItemSum = product.Price * quantity
            };
            await _tableOrderItemRepository.InsertAsync(item);

            return item;
        }

        public async Task CloseOrder(int tableNumber)
        {
            var restaurant = await this._restaurantRepository.GetRestaurantAsync();
            var table = await this._restaurantTableRepository.GetByIdAsync(restaurant.Id, tableNumber);

            if (table == null)
            {
                throw new ArgumentException("No orders available for this table");
            }

            var order = await _tableOrderRepository.GetActiveOrderByTableNumber(restaurant.Id, table.TableNumber);
            if (order == null)
            {
                throw new ArgumentException("No active orders available for this table");
            }

            await _restaurantTableRepository.CloseOrder(table);
            await _tableOrderRepository.CloseOrder(order);
        }
    }
}
