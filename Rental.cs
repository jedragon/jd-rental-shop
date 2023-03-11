using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoRental
{
  public class Rental
  {
        //대여 클래스 생성자
    public Rental(Movie movie, int daysRented)
    {
         //대여할 영화
        rentedMovie = movie;
        //대여할 날짜
        nDaysRented = daysRented;
    }

    public int getDaysRented() { return nDaysRented; }
    public Movie getMovie() { return rentedMovie; }

    private Movie rentedMovie;
    private int nDaysRented;
  }
}
