using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
// Các phương thức định nghĩa _64_Vi
using MAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using MTestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;

namespace TestWebNetflix_64_Vi
{
 
    // Kiểm thử chức năng tìm kiếm
    [TestClass]
    public class ChucNang2_Search_64_Vi
    {

        public PhuongThucDungChung_64_Vi method = new PhuongThucDungChung_64_Vi();

        ///Tạo đối tượng TestConText và khai báo phương thức get set
        public MTestContext TestContext { get; set; }


        

        //TestCase 2.1: Tìm kiếm phim thành công
        ///Khai báo DataSource, file dữ liệu đầu vào 
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\SearchData_64_Vi\DataTestCase2Cham1_64_Vi.csv",
            "DataTestCase2Cham1_64_Vi#csv", DataAccessMethod.Sequential)]
             
        [TestMethod, Order(1)]///Testcase sẽ chạy đầu tiên trong Unittest
        public void TC2_1_Tim_Kiem_Thanh_Cong_64_Vi()
        {
            // đăng nhập vào netflix
            string username = "opdlnf01@gmail.com";
            string password = "0phim23@";
            ///Thực hiện đăng nhập và điền tự động username, password vừa mới đọc
            method.LoginWithNoAds_64_Vi(username, password);
            
            ///Đọc dữ liệu đầu vào
            string keywords = TestContext.DataRow[0].ToString();
            /// Tìm bài hát tên là: Happy new year
            method.SearchFilm_64_Vi(keywords);
            ///Kiểm tra xem bài hát trả về có tên giống như keywords hay không
            MAssert.IsNotNull(method.FilmName_64_Vi());
            /// Dừng 6 giây rồi đóng Chrome
            Thread.Sleep(6000);
            // đóng trình duyệt sau khi thực hiện xong test case
            method.driver_64_Vi.Quit();
        }


        //TestCase 2.2: Tìm kiếm phim thất bại vì phim không tồn tại
        ///Khai báo DataSource, file dữ liệu đầu vào 
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\SearchData_64_Vi\DataTestCase2Cham2_64_Vi.csv",
            "DataTestCase2Cham2_64_Vi#csv", DataAccessMethod.Sequential)]

        [TestMethod, Order(2)]///Testcase sẽ chạy thứ 2 trong Unittest
        public void TC2_2_Tim_Kiem_That_Bai_Vi_Bai_Hat_Khong_Ton_Tai()
        {
            // đăng nhập vào netflix
            string username = "opdlnf01@gmail.com";
            string password = "0phim23@";
            ///Thực hiện đăng nhập và điền tự động username, password vừa mới đọc
            method.LoginWithNoAds_64_Vi(username, password);
           
            ///Đọc dữ liệu đầu vào
            string keywords = TestContext.DataRow[0].ToString();
            /// Tìm bài hát tên là: Happy new year
            method.SearchFilm_64_Vi(keywords);
            string resultactual = method.ResultCannotFindFilm_64_Vi();
            string resultexxpected = "";
            MAssert.AreEqual(resultexxpected, resultactual);
            /// Dừng 6 giây rồi đóng Chrome
            Thread.Sleep(6000);
            // đóng trình duyệt sau khi thực hiện xong test case
            method.driver_64_Vi.Quit();
        }




    }
}
