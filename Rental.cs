using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoRental
{
    public class Rental
    {
        //대여 클래스 생성자
        public Rental(Movie movie, int idaysRented, Customer customer)
        {
            //대여할 영화
            rentedMovie = movie;

            //대여할 날짜
            this.daysRented = idaysRented;

            //[개선방향]
            //6,7. 영수증 문자열 만드는 로직 Customer 클래스에서 Rental 클래스로 변경
            //금액, 포인트 계산은 Rental 생성자에서 함
            calcAmount(customer);
        }

        private Movie rentedMovie;
        private int daysRented; //변수명 nDaysRented -> daysRented 로 변경
        private double amount;
        public static int rentPoint = 0;//static 변수로 포인트 관리, 변수명 mFrequentRenterPoints -> rentPoint로 변경
        public static double totalAmount = 0.0;//static 변수로 최종금액 관리

        public int getDaysRented() { return this.daysRented; }
        public Movie getMovie() { return this.rentedMovie; }
        public double getAmount() { return this.amount; }


        //[개선방향]
        //6,7. 영수증 문자열 만드는 로직 Customer 클래스에서 Rental 클래스로 변경
        //금액, 포인트 계산은 Rental 생성자에서 함
        private void calcAmount(Customer customer)
        {
            switch (getMovie().getPriceCode())
            {
                //REGULAR는 1~2일은 2원
                //3일 부터는  2.0원 + 대여일 수 x 1.5원
                case (int)DefConst.PriceCode.REGULAR:
                    this.amount += 2.0;
                    if (getDaysRented() > 2)
                        this.amount += (getDaysRented() - 2) * 1.5;
                    break;

                //NEW_RELEASE는 대여일 * 3원 
                case (int)DefConst.PriceCode.NEW_RELEASE:
                    this.amount += getDaysRented() * 3;
                    break;

                //CHILDRENS는 1~3일까지 1.5원
                //4일 부터는  1.5원 + 대여일 수 x 1.5원
                case (int)DefConst.PriceCode.CHILDRENS:
                    this.amount += 1.5;
                    if (getDaysRented() > 3)
                        this.amount += (getDaysRented() - 3) * 1.5;
                    break;
            }

            // Add frequent renter points
            //rentPoint++;
            customer.addPoint();
            // Add bonus for a two day new release rental
            //신작 영화의 경우 2일 이상 대여시 포인트 2원 적립
            if ((getMovie().getPriceCode() == (int)DefConst.PriceCode.NEW_RELEASE) && getDaysRented() > 1)
            {
                //rentPoint++;
                customer.addPoint();
            }

            totalAmount += this.amount;
        }

        //[개선방향]
        //6, 7. 영수증 출력과 포인트, 금액계산 분리, 함수명 statement -> makeReceipt
        //기존 statement 함수는 함수명이 모호하고, 매개변수가 없어 함수 선언 수정
        public static string makeReceipt(List<Rental> customerRental, string cName, int cPoint)
        {
            StringBuilder receipt = new StringBuilder();     //구 영수증
            StringBuilder newReceipt = new StringBuilder(); //신규 영수증

            receipt.AppendLine("Rental Record for " + cName);

            IEnumerator<Rental> enumerator = customerRental.GetEnumerator();

            for (; enumerator.MoveNext();)
            {
                Rental each = enumerator.Current;

                // Show figures for this rental
                // 영화이름, 가격
                receipt.AppendLine("\t" + each.getMovie().getTitle() + "\t" + each.getAmount().ToString());
            }

            receipt.AppendLine("Amount owed is " + Rental.totalAmount);
            receipt.AppendLine("You earned " + cPoint + " frequent renter points");

            //////////////////신규 영수증 출력
            enumerator.Reset();
            newReceipt.AppendLine("\r\n");
            newReceipt.AppendLine("ㅡㅡㅡㅡㅡㅡㅡ" + "JD's Movie Rental Shop" + "ㅡㅡㅡㅡㅡㅡㅡ");
            newReceipt.AppendLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            newReceipt.AppendLine("[Genre]".PadRight(20) + "[title]".PadRight(10) + "[daysRent]".PadRight(10) + "[amount]".PadRight(10));
            newReceipt.AppendLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");

            for (; enumerator.MoveNext();)
            {
                Rental each = enumerator.Current;

                // 장르, 제목, 대여기간, 가격을 포함한 신규 영수증
                newReceipt.AppendLine(each.getMovie().getGenre().PadRight(20) + each.getMovie().getTitle().PadRight(10) +
                    String.Format("{0,-10}", each.getDaysRented()) + each.getAmount().ToString().PadRight(10));
            }

            newReceipt.AppendLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            newReceipt.AppendLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            newReceipt.AppendFormat("Total Amount : {0}\r\n".PadLeft(50), Rental.totalAmount);
            newReceipt.AppendFormat("Your Point : {0}\r\n".PadLeft(50), cPoint);

            receipt.AppendFormat("{0}", newReceipt);

            return receipt.ToString();
        }

    }
}
