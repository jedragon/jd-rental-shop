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
            this.movieTitle = title;
            this.moviePriceCode = priceCode;
            this.movieGenre = genre;
        }
        //[개선방향]
        //Movie 클래스 멤버함수 setPriceCode 함수 불필요 -> 삭제
        public string movieTitle { get; }
        public int moviePriceCode { get; }
        public string movieGenre { get; }
    }
}