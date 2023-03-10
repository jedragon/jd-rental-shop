using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoRental
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        //영화 장르 추가
        public const int romanticComedy = 0;
        public const int thiller = 1;
        public const int spaceOpera = 2;

        public Movie(string title, int genre, int priceCode = REGULAR)
        {
            movieTitle = title;
            moviePriceCode = priceCode;
            this.movieGenre = genre;
        }

        public int getPriceCode() { return moviePriceCode; }
        public void setPriceCode(int args) { moviePriceCode = args; }
        public string getTitle() { return movieTitle; }
        public int getGenre() { return this.movieGenre; }

        private string movieTitle;
        int moviePriceCode;
        int movieGenre;
    }
}
