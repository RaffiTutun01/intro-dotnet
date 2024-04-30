using System;

namespace ExtremeCarpaccio
{
    public class Biller
    {
        public decimal ComputeOrder(Order order)
        {
            var tot = 0m;
            foreach (var item in order.Items)
            {
                tot += item.Price * item.Quantity;
            }
            var reduction = tot;

            switch (order.ReductionName)
            {
                case "HalfPrice":
                    reduction = tot / 2;
                    break;
                case "PayThePrice":
                    reduction = tot;
                    break;
                default:
                    switch (tot)
                    {
                        case < 100:
                            reduction = tot;
                            break;
                        case >= 100 and < 500:
                            reduction = tot * 0.97m;
                            break;
                        case >= 500 and < 700:
                            reduction = tot * 0.95m;
                            break;
                        case >= 700 and < 1000:
                            reduction = tot * 0.93m;
                            break;
                        case >= 1000 and < 5000:
                            reduction = tot * 0.90m;
                            break;
                        case >= 5000:
                            reduction = tot * 0.85m;
                            break;
                    }
                    break;
            }
            switch (order.CountryCode)
            {
                case "FR":
                    reduction *= 1.20m;
                    break;
                case "UK":
                    reduction *= 1.21m;
                    break;
                default:
                    reduction *= 1.23m;
                    break;
            }
            return decimal.Round(reduction, 2);
        }
    }
}
