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
    //Kiểm tra chức năng Đăng Nhập
    [TestClass]
    public class ChucNang1_Login_64_Vi
    {

        public PhuongThucDungChung_64_Vi method = new PhuongThucDungChung_64_Vi();

        ///Tạo đối tượng TestConText và khai báo phương thức get set
        public MTestContext TestContext { get; set; }


        //TestCase 1.1: Đăng nhập thành công với username và password đúng
        ///Khai báo DataSource, file dữ liệu đầu vào 
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\LoginData_64_Vi\DataTestCase1Cham1_64_Vi.csv",
            "DataTestCase1Cham1_64_Vi#csv", DataAccessMethod.Sequential)]


        [TestMethod, Order(1)]///Testcase sẽ chạy đầu tiên trong UnitTest
        public void TC1_1_Login_Thanh_Cong_64_Vi()
        {
            ///Đọc dữ liệu đầu vào
            string username = TestContext.DataRow[0].ToString();
            string password = TestContext.DataRow[1].ToString();
            ///Thực hiện đăng nhập và điền tự động username, password vừa mới đọc
            method.LoginWithNoAds_64_Vi(username, password);
            ///Lấy url thực tế là url sau khi click button Đăng nhập
            string actualurl = method.driver_64_Vi.Url;
            ///đặt Url kì vọng theo đặc tả
            string expectedurl = "https://www.netflix.com/browse";
            ///So sánh Url kì vọng so với thực tế
            if (expectedurl.Contains(actualurl))
            {
                Console.WriteLine("Pass! (Test Case: TC1)"); 
            }
            else
            {
                Console.WriteLine("Fail! (Test Case: TC1)");
            }
            // Dừng 6 giây rồi đóng Chrome
            Thread.Sleep(6000);
            // Đóng trình duyệt sau khi thực hiện xong test case
            method.driver_64_Vi.Quit();
        }



        //TestCase 1.2: Đăng nhập không thành công do không nhập username        
        ///Khai báo DataSource, file dữ liệu đầu vào 
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\LoginData_64_Vi\DataTestCase1Cham2_64_Vi.csv",
            "DataTestCase1Cham2_64_Vi#csv", DataAccessMethod.Sequential)]

        [TestMethod, Order(2)]///Testcase sẽ chạy thứ 2 trong UnitTest
        public void TC1_2_Login_That_Bai_Khong_Nhap_UserName_64_Vi()
        {
            ///Đọc dữ liệu đầu vào
            string username = TestContext.DataRow[0].ToString();
            string password = TestContext.DataRow[1].ToString();
            ///Thực hiện đăng nhập và điền tự động username, password vừa mới đọc
            method.LoginWithNoAds_64_Vi(username, password);
            ///Cảnh báo thực tế: Cảnh báo sau khi nhấn button Đăng nhập
            string actalert = method.GetAlertMessage_64_Vi();
            ///Cảnh báo kỳ vọng
            string expectalert = "Please enter a valid email or phone number.";
            ///So sánh cảnh báo kỳ vọng và cảnh báo thực tế
            MAssert.AreEqual(expectalert, actalert);
            /// Dừng 6 giây rồi đóng Chrome
            Thread.Sleep(6000);
            /// Đóng trình duyệt sau khi thực hiện xong test case
            method.driver_64_Vi.Quit();
        }



        //TestCase 1.3: Đăng nhập không thành công do không nhập password       
        ///Khai báo DataSource, file dữ liệu đầu vào 
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\LoginData_64_Vi\DataTestCase1Cham3_64_Vi.csv",
            "DataTestCase1Cham3_64_Vi#csv", DataAccessMethod.Sequential)]
      
        [TestMethod, Order(3)]///Testcase sẽ chạy thứ 3 trong UnitTest
        public void TC1_3_Login_That_Bai_Khong_Nhap_PassWord_64_Vi()
        {
            ///Đọc dữ liệu đầu vào
            string username = TestContext.DataRow[0].ToString();
            string password = TestContext.DataRow[1].ToString();
            ///Thực hiện đăng nhập và điền tự động username, password vừa mới đọc
            method.LoginWithNoAds_64_Vi(username, password);
            ///Cảnh báo thực tế: Cảnh báo sau khi nhấn button Đăng nhập
            string actalert = method.GetAlertMessage_pass_64_Vi();
            ///Cảnh báo kỳ vọng
            string expectalert = "Your password must contain between 4 and 60 characters.";
            MAssert.AreEqual(expectalert, actalert);
            // Dừng 6 giây rồi đóng Chrome
            Thread.Sleep(6000);
            /// Đóng trình duyệt sau khi thực hiện xong test case
            method.driver_64_Vi.Quit();
        }


        ////TestCase 1.4: Đăng nhập không thành công với username chưa đăng ký 
        /////Khai báo DataSource, file dữ liệu đầu vào 
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\LoginData_64_Vi\DataTestCase1Cham4_64_Vi.csv",
        //    "DataTestCase1Cham4_64_Vi#csv", DataAccessMethod.Sequential)]

        //[TestMethod, Order(4)]///Testcase sẽ chạy thứ 4 trong UnitTest
        //public void TC1_4_Login_That_Bai_UserName_Chua_Dang_Ky()
        //{
        //    ///Đọc dữ liệu đầu vào
        //    string username = TestContext.DataRow[0].ToString();
        //    string password = TestContext.DataRow[1].ToString();
        //    ///Thực hiện đăng nhập và điền tự động username, password vừa mới đọc
        //    method.LoginWithNoAds_64_Vi(username, password);
        //    ///Cảnh báo thực tế: Cảnh báo sau khi nhấn button Đăng nhập
        //    string actalert = method.GetAlertMessage_user_64_Vi();
        //    ///Cảnh báo kỳ vọng
        //    string expectalert = "Sorry, we couldn't find any accounts with this email address. Please try again or ";
        //    MAssert.AreEqual(expectalert, actalert);
        //    /// Dừng 3 giây rồi đóng Chrome
        //    Thread.Sleep(3000);
        //    /// Đóng trình duyệt sau khi thực hiện xong test case
        //    method.driver_64_Vi.Quit();
        //}


        ////TestCase 1.5: Đăng nhập không thành công với password sai
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\LoginData_64_Vi\DataTestCase1Cham4_64_Vi.csv",
        //    "DataTestCase1Cham4_64_Vi#csv", DataAccessMethod.Sequential)]
        //[TestMethod, Order(5)]///Testcase sẽ chạy thứ 5 trong UnitTest
        //public void TC1_5_Login_That_Bai_UserNameDung_MatKhauSai()
        //{
        //    ///Đọc dữ liệu đầu vào
        //    string username = TestContext.DataRow[0].ToString();
        //    string password = TestContext.DataRow[1].ToString();
        //    ///Thực hiện đăng nhập và điền tự động username, password vừa mới đọc
        //    method.LoginWithNoAds_64_Vi(username, password);
        //    ///Cảnh báo thực tế: Cảnh báo sau khi nhấn button Đăng nhập
        //    string actalert = method.GetAlertMessage_passfaile_64_Vi();
        //    ///Cảnh báo kỳ vọng
        //    string expectalert = "Incorrect password";
        //    MAssert.AreEqual(expectalert, actalert);
        //    /// Dừng 3 giây rồi đóng Chrome
        //    Thread.Sleep(3000);
        //    /// Đóng trình duyệt sau khi thực hiện xong test case
        //    method.driver_64_Vi.Quit();
        //}


















    }

}
