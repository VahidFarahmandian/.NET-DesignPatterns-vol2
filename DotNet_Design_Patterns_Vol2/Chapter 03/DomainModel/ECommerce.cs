using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Design_Patterns_Vol2.Chapter_03.DomainModel
{
    public class Customer
    {
        public int CustomerId { get; private set; }
        public string Name { get; private set; }
        public string MobileNumber { get; private set; }
        public Customer(int customerId, string name)
        {
            if (customerId <= 0)
                throw new ArgumentException("شناسه مشتری نامعتبر است");
            CustomerId = customerId;

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("نام مشتری الزامی است");
            Name = name;
        }
        public Customer(int customerId, string name, string mobileNumber) : this(customerId, name)
        {
            if (string.IsNullOrWhiteSpace(mobileNumber))
                throw new ArgumentException("ورود شماره تلفن همراه الزامی است");
            if (mobileNumber.Length > 11 && mobileNumber.Length < 10)
                throw new ArgumentException("شماره تلفن همراه حداکثر بایستی 11 و حداقل 10 رقم باشد");
            if (int.TryParse(mobileNumber, out _))
                throw new ArgumentException("شماره تلفن همراه بایستی فقط شامل اعداد باشد");
            MobileNumber = mobileNumber;
        }
        public string GetMobileNumber()
        {
            string maskedMobileNumber;
            if (MobileNumber.Length == 10)
                maskedMobileNumber = "0" + MobileNumber;
            maskedMobileNumber = MobileNumber;

            maskedMobileNumber = maskedMobileNumber.Substring(0, 4) + "***" + maskedMobileNumber.Substring(7, 4);

            return maskedMobileNumber;
        }
    }
}
