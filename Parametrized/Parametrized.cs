using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using NUnit.Framework;

namespace Parametrized
{
    public class Parametrized
    {
        [TestCase(1984, "George Orwell")]
        [TestCase(42, "Douglas Adams")]
        [TestCase(22, "Joseph Heller")]
        public void BooksWithNumbers(int number, string author)
        {
            Assert.Multiple(() =>
            {
                Assert.That(number, Is.GreaterThan(0));
                Assert.That(author.Length, Is.GreaterThan(0));
            });
        }

        [TestCaseSource(typeof(ReadCsvFile),"ReadData")]
        public void ShareTrades(AksjeData info)
        {
            Assert.That(info.Price.Length, Is.GreaterThan(0));
        }

    }






    public class ReadCsvFile
    {
        public static IEnumerable ReadData
        {
            get
            {
                var lines = GrabData().SkipLast(2400);
                foreach (var line in lines)
                {
                    yield return new TestCaseData(line);
                }
            }
        }


        public static IEnumerable<AksjeData> GrabData()
        {
            using (var reader = new StreamReader("Dnb.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AksjeData>().ToList();
                return records;
            }

        }
    }

    /// <summary>
    /// Date,Buyer,Seller,Price,Volume,TradeType
    /// </summary>
    public class AksjeData
    {
        public string Date { get; set; }
        public string Buyer { get; set; }
        public string Seller { get; set; }
        public string Price { get; set; }
        public string Volume { get; set; }
        public string TradeType { get; set; }


    }

}
