using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestWebNetflix_64_Vi
{
    public class PhuongThucDungChung_64_Vi
    {
        //khai báo thuộc tính là public để các UniTest dùng chung
        public IWebDriver driver_64_Vi = new ChromeDriver();

        public PhuongThucDungChung_64_Vi() { }

        //Phương thức truy cập vào trang web Netflix
        public void TruyCapTrangChu_64_Vi()
        {
            driver_64_Vi.Navigate().GoToUrl("https://www.netflix.com/login");
        }

        //Phương thức truy cập vào trang login và thực hiện đăng nhập khi đang ở trang chủ 
        public void Login_64_Vi(string username, string password)
        {
            //Truy cập trang chủ
            TruyCapTrangChu_64_Vi();
            //Nhập username
            IWebElement e_user_64_Vi = driver_64_Vi.FindElement(By.Name("userLoginId"));
            e_user_64_Vi.SendKeys(username);
            //Nhập pass 
            IWebElement e_pass_64_Vi = driver_64_Vi.FindElement(By.Name("password"));
            e_pass_64_Vi.SendKeys(password);
            //click button đăng nhập
            IWebElement e_btnlogin_64_Vi = driver_64_Vi.FindElement(By.CssSelector("#appMountPoint > div > div > div.default-ltr-cache-8hdzfz.eyojgsc0 > div > form > button.e1ax5wel2.ew97par0.default-ltr-cache-o2lwqt.e1ff4m3w2"));
            e_btnlogin_64_Vi.Click();
            Thread.Sleep(3000);
            if (driver_64_Vi.Url == "https://www.netflix.com/browse")
            {
                IWebElement e_btnprofile_64_Vi = driver_64_Vi.FindElement(By.CssSelector("#appMountPoint > div > div > div:nth-child(1) > div.bd.dark-background > div.profiles-gate-container > div > div > ul > li:nth-child(1) > div > a > div"));
                e_btnprofile_64_Vi.Click();
            }
          


        }

        public void LoginWithNoAds_64_Vi(string username, string password)
        {
            try
            {
                Login_64_Vi(username, password);
            }
            catch (NoSuchElementException)
            {
                Login_64_Vi(username, password);
            }
        }



        ///Phương thức trả về lỗi khi không đăng nhập không thành công
        public string GetAlertMessage_64_Vi()
        {
            IWebElement e_alertmess_64_Vi = driver_64_Vi.FindElement(By.Id(":r1:"));
            return e_alertmess_64_Vi.Text;
        }

        public string GetAlertMessage_pass_64_Vi()
        {
            IWebElement e_alertmess_64_Vi = driver_64_Vi.FindElement(By.Id(":r4:"));
            return e_alertmess_64_Vi.Text;
        }


        ///Phương thức tìm kiếm phim
        public void SearchFilm_64_Vi(string keywords)
        {
            ///Truy cập vào trang chủ
            TruyCapTrangChu_64_Vi();
            //click button tìm kiếm
            IWebElement e_btnsearch_64_Vi = driver_64_Vi.FindElement(By.ClassName("searchBox"));
            e_btnsearch_64_Vi.Click();
            ///Tại ô tìm kiếm, nhập vào tên bài hát cần tìm kiếm và nhấn Enter
            IWebElement e_searchbox = driver_64_Vi.FindElement(By.Id("searchInput"));
            ///Điền vào từ khóa
            e_searchbox.SendKeys(keywords);
            ///Nhấn Enter
            e_searchbox.SendKeys(Keys.Enter);
        }

        ///Phương thức trả về phim được tìm thấy
        public string FilmName_64_Vi()
        {
            IWebElement e_filmname_64_Vi = driver_64_Vi.FindElement(By.CssSelector("#appMountPoint > div > div > div:nth-child(1) > div.visually-hidden.screenReaderMessage"));
            string name_64_Vi = e_filmname_64_Vi.Text;
            return name_64_Vi;
        }

        ///Phương thức trả về kết quả thông báo không có phim mà bạn muốn tìm (Không tồn tại phim) 
        public string ResultCannotFindFilm_64_Vi()
        {
            string result_64_Vi;
            IWebElement e_result_64_Vi = driver_64_Vi.FindElement(By.ClassName("mainView"));
            ///Lấy thông báo
            result_64_Vi = e_result_64_Vi.Text;
            return result_64_Vi;
        }


    }
}
