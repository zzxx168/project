using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carts.Models.Cart
{
    [Serializable] //可序列化
    public class CartItem  //購物車內單一商品類別
    {
        //商品編號
        public int Id { get; set; }

        //商品名稱
        public string Name { get; set; }

        //商品購買時價格
        public int Price { get; set; }

        //商品購買數量
        public int Quantity { get; set; }
        //商品圖片
        public string Photo { get; set; }
        //商品小計
        public int Amount { 
            get{
                return this.Price * this.Quantity;
            } 
        }
    }

}

