using System;
using System.IO;

namespace Encoding
{
    class Program
    {
        static void Main(string[] args)
        {
            //EF=239,BB=187,BF=191
            var content1 = "﻿INSERT INTO oms.merchant_customer(merchant_id,customer_type) SELECT id,1 FROM oms.merchant where id not in (select id from oms.merchant_customer);";
            var content2 = "INSERT INTO oms.merchant_customer(merchant_id,customer_type) SELECT id,1 FROM oms.merchant where id not in (select id from oms.merchant_customer);";
            byte[] bytes1 = System.Text.Encoding.UTF8.GetBytes(content1);
            byte[] bytes2 = System.Text.Encoding.UTF8.GetBytes(content2);

            Console.ReadKey();
        }
    }
}
