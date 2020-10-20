using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITIES;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;

namespace BL
{
    class UserManager : IDisposable
    {

        //constructor
        public UserManager() { }

        public User Login(int id, string password)
        {
            User user=new User();
            string query = "select * from user where id=" + id + " and password="+password;
            using (DALiditZugit dal = new DALiditZugit())
            {
                MySqlDataReader dataReader = dal.ExecuteReader(query);
                while (dataReader.Read())
                {
                    var thisid = (int)dataReader["id"];
                    var thispassword = (string)dataReader["password"];
                    var firstName = (string)dataReader["firstName"];
                    var lastName = (string)dataReader["category"];
                    var email = (string)dataReader["email"];

                    user = new User(thisid, thispassword, firstName, lastName, email);

                   

                   
                }
            }
            return user;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    
    }
}
        //public List<FoodItem> GetAllFoodItems()
        //{
        //    List<FoodItem> foodList = new List<FoodItem>();
        //    string query = "select * from food where isActive=1";
        //    using (DALsweets dal = new DALsweets())
        //    {
        //        MySqlDataReader dataReader = dal.ExecuteReader(query);
        //        while (dataReader.Read())
        //        {
        //            FoodItem item = new FoodItem()
        //            {
        //                _id = (int)utils.Nz(dataReader["idfood"], 0),
        //                foodName = (string)utils.Nz(dataReader["name"], ""),
        //                price = (float)utils.Nz(dataReader["price"], 0),
        //                category = (int)utils.Nz(dataReader["category"], 0),
        //                description = (string)utils.Nz(dataReader["desc"], ""),
        //                imageUrl = (string)utils.Nz(dataReader["img"], ""),
        //                productVisibility = Convert.ToBoolean(utils.Nz(dataReader["isActive"], 0))
        //            };

        //            foodList.Add(item);
        //        }

        //    }
        //    return foodList;
        //}