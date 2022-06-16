using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> Portfolio;
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }
        public int Count { get { return Portfolio.Count; } }
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock);
            }

        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!Portfolio.Any(x => x.CompanyName == companyName))
            {
                return $"{companyName} does not exist.";
            }
            else if (Portfolio.First(x => x.CompanyName == companyName).PricePerShare > sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }
            else
            {
                Portfolio.RemoveAll(x => x.CompanyName == companyName);
                MoneyToInvest += sellPrice;
                return $"{companyName} was sold.";
            }
        }
        public Stock FindStock(string companyName)
        {
            return Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        }
        public Stock FindBiggestCompany()
        {
            if (Portfolio.Count > 0)
            {
                return Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");

            foreach (var item in Portfolio)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().TrimStart().TrimEnd();
        }
    }
}
