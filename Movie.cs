using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoRental
{
    public class Movie
    {
        public Movie(string title, string genre, int priceCode = (int)DefConst.PriceCode.REGULAR)
        {
            //[개선방향]
            //Movie 클래스 생성자 내부 멤버변수 셋팅 시, 멤버 변수에 this 키워드 삽입
            //- 이유 : this를 사용하여 가독성 증진
            this.movieTitle = title;
            this.moviePriceCode = priceCode;
            this.movieGenre = genre;
        }

        public int getPriceCode() { return moviePriceCode; }

        //[개선방향]
        //1. Movie 클래스 멤버함수 setPriceCode 함수 불필요 -> 삭제
        public string getTitle() { return movieTitle; }
        public string getGenre() { return this.movieGenre; }

        private string movieTitle;
        int moviePriceCode;
        string movieGenre;
    }
}
