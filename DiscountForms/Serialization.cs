using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Json;
using Discount;

namespace DiscountForms
{
    /// <summary>
    ///     Сериализация
    /// </summary>
    internal static class Serialization
    {
        /// <summary>
        ///     Сериализованные объекты
        /// </summary>
        private static readonly IEnumerable<Type> TypeList = new BindingList<Type>
        {
            typeof(CouponDiscount),
            typeof(PercentDiscount),
            typeof(Product),
            typeof(CheckPosition)
        };

        /// <summary>
        ///     Сериализует/десереализует
        /// </summary>
        private static readonly DataContractJsonSerializer Serializer =
            new DataContractJsonSerializer(typeof(BindingList<CheckPosition>), TypeList);

        /// <summary>
        ///     Сохранение в файл
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="savingList"></param>
        public static void Save(string filename, BindingList<CheckPosition> savingList)
        {
            Serializer.WriteObject(new FileStream(filename, FileMode.Create), savingList);
        }

        /// <summary>
        ///     Загрузка файла
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static BindingList<CheckPosition> Open(string filename)
        {
            return (BindingList<CheckPosition>) Serializer.ReadObject
                (new FileStream(filename, FileMode.Open));
        }
    }
}