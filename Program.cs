using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace VideoRental
{
    class Program
    {
        static void Main(string[] args)
        {
            //고객이 대여할 영화는 영화제목과 장르를 입력받아 작성
            //처음에는 영화제목과 가격코드를 입력받아 작성 중 -> Movie 클래스에 장르 추가
            Movie regular1 = new Movie("일반 1", DefConst.Genre.romanticComedy, (int)DefConst.PriceCode.REGULAR);
            Movie regular2 = new Movie("일반 2", DefConst.Genre.spaceOpera, (int)DefConst.PriceCode.REGULAR);
            Movie newRelease1 = new Movie("신작 1", DefConst.Genre.thiller, (int)DefConst.PriceCode.NEW_RELEASE);
            Movie newRelease2 = new Movie("신작 2", DefConst.Genre.thiller, (int)DefConst.PriceCode.NEW_RELEASE);
            Movie children1 = new Movie("어린이 1", DefConst.Genre.spaceOpera, (int)DefConst.PriceCode.CHILDRENS);
            Movie children2 = new Movie("어린이 2", DefConst.Genre.spaceOpera, (int)DefConst.PriceCode.CHILDRENS);

            Customer customer = new Customer("고객");
            
            //입력받은 영화를 원하는 날짜만큼 대여
            //customer 클래스 내부에 포인트 멤버변수가 선언되어 있고, Rental 클래스 생성자에서 포인트 계산을 하므로
            //Rental 클래스에 customer 클래스를 넘겨줘서 포인트 계산
            customer.addRental(new Rental(regular1, 2, customer));
            customer.addRental(new Rental(regular2, 3, customer));
            customer.addRental(new Rental(newRelease1, 1, customer));
            customer.addRental(new Rental(newRelease2, 2, customer));
            customer.addRental(new Rental(children1, 3, customer));
            customer.addRental(new Rental(children2, 4, customer));
            
            //렌탈 리스트를 얻음
            List<Rental> rentals = customer.getCustomerRental();

            //[개선방향]
            //6,7. 영수증 문자열 만드는 로직 Customer 클래스에서 Rental 클래스로 변경
            //금액, 포인트 계산은 Rental 생성자에서 함
            Console.Write(Rental.makeReceipt(rentals, customer.getName(), customer.getRentPoint()));
            
            Console.ReadKey();
        }
    }
}
