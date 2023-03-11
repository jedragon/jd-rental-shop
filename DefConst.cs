using System;

//[개선방향]
//3. 상수클래스 DefConst 클래스 생성
namespace VideoRental
{
    public class DefConst
    {
        //[개선방향]
        //4. 가격코드는 열거형으로 처리
        public enum PriceCode { REGULAR, NEW_RELEASE, CHILDRENS }

        //[개선방향]
        //4. 상수클래스 내부 클래스 추가
        public static class Genre
        {
            public const string romanticComedy = "Romantic Comedy";
            public const string thiller = "Thiller";
            public const string spaceOpera = "Space Opera";
        }
    }
}
