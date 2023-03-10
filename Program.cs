using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoRental
{
    class Program
    {
        static void Main(string[] args)
        {
            //고객이 대여할 영화는 영화제목과 장르를 입력받아 작성
            //현재는 영화제목과 가격코드를 입력받아 작성 중 -> Movie 클래스에 장르 추가
            Movie regular1 = new Movie("일반 1", Movie.REGULAR);
            Movie regular2 = new Movie( "일반 2", Movie.REGULAR);
            Movie newRelease1 = new Movie( "신작 1", Movie.NEW_RELEASE );
            Movie newRelease2 = new Movie( "신작 2",Movie.NEW_RELEASE );
            Movie children1 = new Movie( "어린이 1", Movie.CHILDRENS );
            Movie children2 = new Movie( "어린이 2", Movie.CHILDRENS );
            Customer customer = new Customer("고객");

            //입력받은 영화를 원하는 날짜만큼 대여
            customer.addRental(new Rental( regular1, 2 ));
            customer.addRental(new Rental( regular2, 3 ));
            customer.addRental(new Rental( newRelease1, 1 ));
            customer.addRental(new Rental( newRelease2, 2 ));
            customer.addRental(new Rental( children1, 3 ));
            customer.addRental(new Rental( children2, 4 ));

            //영수증 출력 -> 장르, 제목, 대여기간, 가격 형식으로 영수증 출력
            Console.Write(customer.statement());
        }
    }
}
