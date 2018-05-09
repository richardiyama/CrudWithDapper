using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using CrudWithDapper.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CrudWithDapper.Controllers
{
    public class FriendController : Controller
    {
        // GET: Friend
        public ActionResult Index()
        {
            List<Friend> FriendList = new List<Friend>();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))
            {

                FriendList = db.Query<Friend>("Select * From tblFriends").ToList();
            }
            return View(FriendList);
        }


            // GET: Friend/Details/5
            public ActionResult Details(int id)
        {
            Friend _friend = new Friend();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))
            {
                _friend = db.Query<Friend>("Select * From tblFriends " +
                                       "WHERE FriendID =" + id, new { id }).SingleOrDefault();
            }
            return View(_friend);
        }

        // GET: Friend/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Friend/Create
        [HttpPost]
        public ActionResult Create(Friend _friend)
        {
            
             using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))

            {

                string sqlQuery = "Insert Into tblFriends (FriendName,City,PhoneNumber) Values('" + _friend.FriendName + "','" + _friend.City + "','" + _friend.PhoneNumber + "')";

                int rowsAffected = db.Execute(sqlQuery);
            }
            return RedirectToAction("Index");
        }

        // GET: Friend/Edit/5
        public ActionResult Edit(int id)
        {
            Friend _friend = new Friend();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))
            {
                _friend = db.Query<Friend>("Select * From tblFriends " +
                                       "WHERE FriendID =" + id, new { id }).SingleOrDefault();
            }
            return View(_friend);
        }

        // POST: Friend/Edit/5
        [HttpPost]
        public ActionResult Edit(Friend _friend)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))

            {

                string sqlQuery = "update tblFriends set FriendName='" + _friend.FriendName + "',City='" + _friend.City + "',PhoneNumber='" + _friend.PhoneNumber + "' where friendid=" + _friend.FriendID;

                int rowsAffected = db.Execute(sqlQuery);
            }

            return RedirectToAction("Index");
        }

        // GET: Friend/Delete/5
        public ActionResult Delete(int id)
        {
            Friend _friend = new Friend();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))
            {
                _friend = db.Query<Friend>("Select * From tblFriends " +
                                       "WHERE FriendID =" + id, new { id }).SingleOrDefault();
            }
            return View(_friend);
        }

        // POST: Friend/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using(IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))
          {
                string sqlQuery = "Delete From tblFriends WHERE FriendID = " + id;

                int rowsAffected = db.Execute(sqlQuery);


            }
            return RedirectToAction("Index");
        }
    }
}
