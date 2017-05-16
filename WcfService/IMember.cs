using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using WcfService.Model;
using System.Web.Services;
using System.ServiceModel.Web;

namespace WcfService
{
    // 注意: 如果更改此处的接口名称 "IMember"，也必须更新 Web.config 中对 "IMember" 的引用。
    [ServiceContract]
    public interface IMember
    {
        [OperationContract]
        [WebGet(UriTemplate = "User/{id}", ResponseFormat = WebMessageFormat.Json)]
        User GetUser(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "User/{name}/{password}", ResponseFormat = WebMessageFormat.Xml,Method = "POST")]
        int AddUser(string name,string password);


    }
}
