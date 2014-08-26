using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.ServiceModel.Activation;
using System.Runtime.Caching;
using System.Threading;

namespace WCFBookService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    //[ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, AddressFilterMode = AddressFilterMode.Any)]
    public class Service : IService
    {
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        static volatile bool isThreadStarted = false;
        public void StartBachGroundThread()
        {
            if (!isThreadStarted)
            {
                Thread workerThread = new Thread(GetCache);
                workerThread.Start();
                while (!workerThread.IsAlive) ;
                //Thread.Sleep(1);
                isThreadStarted = true;
                StartBachGroundThread();
            }
        }
        public void GetCache()
        {
            ObjectCache cache = MemoryCache.Default;

            Book[] bkCache = (Book[])cache.Get("AllBooks");
            while (true)
            {
                if (bkCache == null)
                {
                    SqlConnection conn = new SqlConnection(ConnectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GetAllBooks", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    conn.Close();

                    bkCache = new Book[dt.Rows.Count];

                    int i = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        bkCache[i] = new Book();
                        bkCache[i].ID = Convert.ToInt32(item["ID"]);
                        bkCache[i].Name = item["Name"].ToString();
                        bkCache[i].Description = item["Description"].ToString();
                        bkCache[i].DatePublished = (DateTime)item["DatePublished"];
                        i++;
                    }
                    CacheItemPolicy policy = new CacheItemPolicy();
                    policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(300);
                    cache.Add("AllBooks", bkCache, policy);
                }
                //TimeSpan tspan = TimeSpan.FromMinutes(5);
                //Thread.Sleep(tspan);
            }
        }

          public Book[] GetBooks()
        {
            StartBachGroundThread();
            //Book[] bkCache = GetCacheData();
            ObjectCache cache = MemoryCache.Default;

            Book[] bkCache = (Book[])cache.Get("AllBooks");

            if (bkCache != null)
            {
                return bkCache;
            }

            return null;
        }

        public Book[] GetSearchedBooks(string param)
        {
            StartBachGroundThread();
            //Book[] bkCache = GetCacheData();
            ObjectCache cache = MemoryCache.Default;

            Book[] bkCache = (Book[])cache.Get("AllBooks");
            if (param != null)
            {

                if (bkCache == null)
                {
                    return bkCache;
                }

                if (bkCache != null)
                {
                    int id;
                    bool isNumeric = int.TryParse(param, out id);
                    if (isNumeric)
                    {
                        Book[] bk = bkCache.Where(item => item.ID == id).ToArray<Book>();
                        return bk;
                    }
                    else
                    {
                        Book[] bk = bkCache.Where(item => item.Name.Contains(param)).ToArray<Book>();
                        return bk;
                    }
                }
            }
            return bkCache;
        }

        public string InsertBooks(Book book)
        {
            string Message;
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("InsertBook", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", book.Name);
            cmd.Parameters.AddWithValue("@Description", book.Description);
            cmd.Parameters.AddWithValue("@DatePublished", book.DatePublished);
            int result = cmd.ExecuteNonQuery();
            if (result == 0)
            {
                Message = book.Name + " Book inserted successfully";
            }
            else
            {
                Message = book.Name + " Book not inserted successfully";
            }
            conn.Close();
            return Message;
        }
    }
}
