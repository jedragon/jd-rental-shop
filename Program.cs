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
            //처음에는 영화제목과 Price Code(가격코드)를 입력받아 작성 중 -> Movie 클래스에 장르 추가하고 Price Code는 삭제
            Movie regular1 = new Movie("일반 1", DefConst.Genre.romanticComedy);
            Movie regular2 = new Movie("일반 2", DefConst.Genre.spaceOpera);
            Movie newRelease1 = new Movie("신작 1", DefConst.Genre.thiller);
            Movie newRelease2 = new Movie("신작 2", DefConst.Genre.thiller);
            Movie children1 = new Movie("어린이 1", DefConst.Genre.spaceOpera);
            Movie children2 = new Movie("어린이 2", DefConst.Genre.spaceOpera);

            Customer customer = new Customer("고객");


            //기존 Rental 클래스에서 Price Code를 기준으로 파생클래스 생성
            customer.addRental(new REGULAR(regular1, 2, customer));
            customer.addRental(new REGULAR(regular2, 3, customer));
            customer.addRental(new NEW_RELEASE(newRelease1, 1, customer));
            customer.addRental(new NEW_RELEASE(newRelease2, 2, customer));
            customer.addRental(new CHILDRENS(children1, 3, customer));
            customer.addRental(new CHILDRENS(children2, 4, customer));
            
            //렌탈 리스트를 얻음
            List<Rental> rentals = customer.getCustomerRental();

            //[개선방향]
            //영수증 문자열 만드는 로직 Customer 클래스에서 Rental 클래스로 변경
            //금액, 포인트 계산은 Rental 파생 클래스(REGULAR, NEW_RELEASE, CHILDRENS)에서 진행
            //기존 영수증 출력
            Console.Write(Rental.makeReceipt(rentals, customer.customerName, customer.rentPoint));

            //신규 영수증 출력
            Console.Write(Rental.makeReceiptNew(rentals, customer.customerName, customer.rentPoint));

        }
    }
}
