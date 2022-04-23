using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Design_Patterns_Vol2.Chapter_03.TransactionScript
{
    public class ESaleTS
    {
        public bool Sale(int productId, int productCount, int userId)
        {
            /*
             * بررسی موجودی کالا
            var product = tblProduct.Find(productId);
            if(product.Stock<productCount){
                throw new Exception("کالا به اندازه کافی موجود نمیباشد");
            }

            * بررسی موجودی کیف پول
            var userWallet = tblUserWallet.FirstOrDefault(x=>x.UserId==userId)
            var totalPrice = productCount*product.UnitPrice;
            if(userWallet.Balance < totalPrice){
                throw new Exception("موجودی کیف پول کافی نمیباشد");
            }

            * کسر مبلغ خرید از موجودی کیف پول
            userWallet.Balance = userWallet.Balance - totalPrice;

            * کسر تعداد کالای درخواستی از تعداد کل کالای موجود
            product.Stock = product.Stock - productCount;

            * ثبت درخواست ارسال مرسوله
            DeliveryRequest request = new DeliveryRequest(item: product, count: productCount, user: userId);
            tblDeliveryRequest.Add(request);

            Save();

            */
            return true;
        }
    }
}
