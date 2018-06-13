using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Json;
using Discount;

namespace DiscountForms
{
    internal static class Serialization
    {
        private static readonly IEnumerable<Type> TypeList = new BindingList<Type>
        {
            typeof(CouponDiscount),
            typeof(PercentDiscount),
            typeof(Product),
            typeof(CheckPosition)
        };

        private static readonly DataContractJsonSerializer Serializer =
            new DataContractJsonSerializer(typeof(BindingList<CheckPosition>), TypeList);

        public static void Save(string filename, BindingList<CheckPosition> savingList)
        {
            Serializer.WriteObject(new FileStream(filename, FileMode.Create), savingList);
        }

        public static BindingList<CheckPosition> Open(string filename)
        {
            return (BindingList<CheckPosition>) Serializer.ReadObject(new FileStream(filename, FileMode.Open));
        }
    }
}