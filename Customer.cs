﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoRental
{
    public class Customer
    {
        public Customer(string name)
        {
            customerName = name;
        }

        public void addRental(Rental arg) { customerRental.Add(arg); }
        public string customerName { get; private set; }
        private List<Rental> customerRental = new List<Rental>();

        //[개선방향]
        //5.고객이 빌린 영화정보(customerRendtal)에 접근 할 수 있도록 getter 함수 추가
        public List<Rental> getCustomerRental() { return this.customerRental;}
        //[개선방향]
        //8. 포인트의 경우 고객 포인트 정보이므로 Customer 클래스에 적용
        //변수명 mFrequentRenterPoints -> rentPoint로 변경
        public int rentPoint { get; private set; }
        public void addPoint() { this.rentPoint++; }
    }
}
