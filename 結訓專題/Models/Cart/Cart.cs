using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGrease.Css.Ast;

namespace Carts.Models.Cart
{
    [Serializable] //可序列化
    public class Cart : IEnumerable<CartItem> //購物車類別
    {
        //建構值
        public Cart()
        {
            this.cartItems = new List<CartItem>();
        }

        //儲存所有商品
        private List<CartItem> cartItems;

        /// <summary>
        /// 取得購物車內商品的總數量
        /// </summary>
        public int Count
        {
            get
            {
                return this.cartItems.Count;
            }
        }

        //取得商品總價
        public int TotalAmount
        {
            get
            {
                int totalAmount = 0;
                int totalQuantity = 0;
                foreach (var cartItem in this.cartItems)
                {
                    totalAmount = totalAmount + cartItem.Amount;
                    totalQuantity += cartItem.Quantity;
                }
                int ship = Sship;

                if (totalQuantity == 0)
                    ship = 0;
                else if (totalQuantity > 5)
                    ship = Bship;

                return totalAmount + ship;
            }
        }

        public int TotalShip
        {
            get
            {
                int totalQuantity = 0;
                int ship = 0;

                foreach (var item in this.cartItems)
                {
                    totalQuantity += item.Quantity;
                }
                if (totalQuantity >0 & totalQuantity < 6)
                {
                ship = Sship;
                }
                if (totalQuantity > 5)
                {
                    ship = Bship;
                }
                return ship;
            }
        }

        public int Sship = 200;
        public int Bship = 300;

        public int checkout
        {
            get
            {
                int checkOut = 290 + TotalAmount;

                return checkOut;
            }
        }


        //新增一筆Product，使用ProductId
        public bool AddProduct(int ProductId)
        {
            var findItem = this.cartItems
                            .Where(s => s.Id == ProductId)
                            .Select(s => s)
                            .FirstOrDefault();

            //判斷相同Id的CartItem是否已經存在購物車內
            if (findItem == default(Models.Cart.CartItem))
            {   //不存在購物車內，則新增一筆
                using (OrderFoodEntities db = new OrderFoodEntities())
                {
                    var product = (from s in db.FoodProduct
                                   where s.ProductID == ProductId
                                   select s).FirstOrDefault();
                    if (product != default(FoodProduct))
                    {
                        this.AddProduct(product);
                    }
                }
            }
            else
            {   //存在購物車內，則將商品數量累加
                findItem.Quantity += 1;
            }
            return true;
        }

        public bool AddProduct(int ProductId, int quantity)
        {
            var findItem = this.cartItems
                            .Where(s => s.Id == ProductId)
                            .Select(s => s)
                            .FirstOrDefault();

            //判斷相同Id的CartItem是否已經存在購物車內
            if (findItem == default(Models.Cart.CartItem))
            {   //不存在購物車內，則新增一筆
                using (OrderFoodEntities db = new OrderFoodEntities())
                {
                    var product = (from s in db.FoodProduct
                                   where s.ProductID == ProductId
                                   select s).FirstOrDefault();
                    if (product != default(FoodProduct))
                    {
                        this.AddProduct(product, quantity);
                    }
                }
            }
            else
            {   //存在購物車內，則將商品數量累加
                findItem.Quantity += quantity;
            }
            return true;
        }

        public bool EditProduct(int ProductId, int quantity)
        {
            var findItem = this.cartItems
                            .Where(s => s.Id == ProductId)
                            .Select(s => s)
                            .FirstOrDefault();
            if (quantity == 0)
            {
                this.cartItems.Remove(findItem);
            }
            else
            {
                findItem.Quantity = quantity;
            }
            //存在購物車內，則將商品數量累加


            return true;
        }

        //新增一筆Product，使用Product物件
        private bool AddProduct(FoodProduct product)
        {
            //將Product轉為CartItem
            var cartItem = new Models.Cart.CartItem()
            {
                Id = product.ProductID,
                Name = product.ProductName,
                Price = (int)product.Price,
                Photo = product.Photo,
                Quantity = 1
            };

            //加入CartItem至購物車
            this.cartItems.Add(cartItem);
            return true;
        }

        private bool AddProduct(FoodProduct product, int quantity)
        {
            //將Product轉為CartItem
            var cartItem = new Models.Cart.CartItem()
            {
                Id = product.ProductID,
                Name = product.ProductName,
                Price = (int)product.Price,
                Photo = product.Photo,
                Quantity = quantity
            };

            //加入CartItem至購物車
            this.cartItems.Add(cartItem);
            return true;
        }

        public List<OrderDetail> ToOrderDetailList(int orderId)
        {
            var result = new List<OrderDetail>();
            foreach (var cartItem in this.cartItems)
            {
                result.Add(new OrderDetail()
                {
                    ProductName = cartItem.Name,
                    ProductID = cartItem.Id,
                    Price = cartItem.Price,
                    Amount = cartItem.Quantity,
                    OrderID = orderId
                });
            }
            return result;
        }

        #region IEnumerator

        IEnumerator<CartItem> IEnumerable<CartItem>.GetEnumerator()
        {
            return this.cartItems.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.cartItems.GetEnumerator();
        }

        #endregion
    }
}


