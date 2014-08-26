using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;

namespace WCFBookService
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Books", ResponseFormat = WebMessageFormat.Json)]
        Book[] GetBooks();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "SearchedBooks?param={param}", ResponseFormat = WebMessageFormat.Json)]
        Book[] GetSearchedBooks(string param);

        [OperationContract]
        [WebInvoke(UriTemplate = "/PlaceBook", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")] 
        string InsertBooks(Book book);
    }

    [DataContract]
    public class Book
    {
        [DataMember(Name = "ID")]
        public int ID { get; set; }
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "Description")]
        public string Description { get; set; }
        [DataMember(Name = "DatePublished")]
        public DateTime DatePublished { get; set; }
    }
}
