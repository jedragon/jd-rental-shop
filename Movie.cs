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
        public const string romanticComedy = "Romantic Comedy";
        public const string thiller = "Thiller";
        public const string spaceOpera = "Space Opera";

        public Movie(string title, string genre, int priceCode = REGULAR)
        {
            movieTitle = title;
            moviePriceCode = priceCode;
            this.movieGenre = genre;
        }

        public int getPriceCode() { return moviePriceCode; }
        public void setPriceCode(int args) { moviePriceCode = args; }
        public string getTitle() { return movieTitle; }
        public string getGenre() { return this.movieGenre; }

        private string movieTitle;
        int moviePriceCode;
        string movieGenre;
    }
}
