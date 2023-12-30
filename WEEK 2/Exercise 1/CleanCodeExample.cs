enum EUserType{
    FirstType = 0,
    SecondType = 1,
    ThirdType = 2,
    FourthType = 3
}
public class DiscountManager
{
  public decimal CalculateDiscount(decimal amount, EUserType userType, int yearsOnSystem)
  {
    decimal priceWithDiscount = 0;
    decimal discount = (yearsOnSystem > 5) ? (decimal)5/100 : (decimal)yearsOnSystem/100; 
    if (userType == FirstType)
    {
      priceWithDiscount = amount;
    }
    else if (userType == SecondType)
    {
      priceWithDiscount = CalculateAmountDifferently(0.1m,amount) * (discount - 1m) ; # just changed formula to call a function once
    }
    else if (userType == ThirdType)
    {
      priceWithDiscount = CalculateAmount(0.7m,amount) * (discount - 1m);
    }
    else if (userType == FourthType)
    {
      priceWithDiscount = CalculateAmountDifferently(0.5m,amount) * (discount - 1m);
    }
    else 
    {
        throw new Exception("That type of user doesn't exists.");
    }
    return respriceWithDiscountult;
  }
  public decimal CalculateAmount(decimal percentage, decimal amount) # don't really know how to name these functions
  {
    return percentage * amount;
  }
  public decimal CalculateAmountDifferently(decimal percentage, decimal amount)
  {
    return amount - CalculateAmount(percentage,price);
  }
}