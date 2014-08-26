using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;

namespace WCFBookService
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            RouteTable.Routes.Add(new ServiceRoute("soapService", new SoapServiceHostFactory(), typeof(Service)));
            RouteTable.Routes.Add(new ServiceRoute("xmlService", new CustomWebServiceHostFactory(WebMessageFormat.Xml), typeof(Service)));
            RouteTable.Routes.Add(new ServiceRoute("jsonService", new CustomWebServiceHostFactory(WebMessageFormat.Json), typeof(Service)));

        }
    }


    public class SoapServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            ServiceHost host = base.CreateServiceHost(serviceType, baseAddresses);
            host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
            host.AddServiceEndpoint(serviceType, new BasicHttpBinding(), "soap");
            return host;

        }

    }

    public class CustomWebServiceHostFactory : WebServiceHostFactory
    {

        private WebMessageFormat response_format;
        public CustomWebServiceHostFactory(WebMessageFormat response_format)
        {
            this.response_format = response_format;
        }




        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            WebServiceHost host = (WebServiceHost)base.CreateServiceHost(serviceType, baseAddresses);
            host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
            host.AddServiceEndpoint(serviceType, new WebHttpBinding(), "web");
            ServiceEndpoint endpoint = host.AddServiceEndpoint(serviceType, new WebHttpBinding(), "");
            endpoint.Behaviors.Add(new WebHttpBehavior { DefaultBodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Wrapped, HelpEnabled = true, DefaultOutgoingResponseFormat = response_format });
            return host;

        }

    }

}