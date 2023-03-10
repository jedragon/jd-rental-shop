using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoRental
{
    class Customer
    {
        public Customer(string name)
        {
            customerName = name;
        }

        public void addRental(Rental arg) { customerRental.Add(arg); }
        public string getName() { return customerName; }

        //대여 시 영화별 대여금, 포인트 계산
        public string statement()
        {
            double totalAmount = 0.0;
            int frequentRenterPoints = 0;
            StringBuilder result = new StringBuilder();

            result.AppendLine("Rental Record for " + getName());


            IEnumerator<Rental> enumerator = customerRental.GetEnumerator();

            for (; enumerator.MoveNext();)
            {
                double thisAmount = 0.0;
                Rental each = enumerator.Current;

                switch (each.getMovie().getPriceCode())
                {
                    //REGULAR는 1~2일은 2원
                    //3일 부터는 1.5원
                    case Movie.REGULAR:
                        thisAmount += 2.0;
                        if (each.getDaysRented() > 2)
                            thisAmount += (each.getDaysRented() - 2) * 1.5;
                        break;

                    //NEW_RELEASE는 대여일 * 3원 
                    case Movie.NEW_RELEASE:
                        thisAmount += each.getDaysRented() * 3;
                        break;

                    //CHILDRENS는 1~3일까지 1.5원
                    //4일 부터는 1.5원?
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.getDaysRented() > 3)
                            thisAmount += (each.getDaysRented() - 3) * 1.5;
                        break;
                }

                // Add frequent renter points
                frequentRenterPoints++;

                // Add bonus for a two day new release rental
                //신작 영화의 경우 2일 이상 대여시 포인트 2원 적립
                if ((each.getMovie().getPriceCode() == Movie.NEW_RELEASE)
                        && each.getDaysRented() > 1) frequentRenterPoints++;

                // Show figures for this rental
                result.AppendLine("\t" + each.getMovie().getTitle() + "\t" + thisAmount.ToString());
                totalAmount += thisAmount;
            }

            result.AppendLine("Amount owed is " + totalAmount);
            result.AppendLine("You earned " + frequentRenterPoints + " frequent renter points");

            return result.ToString();
        }

        private string customerName;
        private List<Rental> customerRental = new List<Rental>();
    }
}
