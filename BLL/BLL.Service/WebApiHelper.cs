using BLL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class WebApiHelper
    {
        public static IEnumerable<T> GetEntitys<T>(string url, string ticket)
        {
            return GetFromWebApi<IEnumerable<T>>(url, ticket);
        }

        public static T GetEntity<T>(string url, string ticket)
        {
            return GetFromWebApi<T>(url, ticket);
        }

        private static T GetFromWebApi<T>(string url, string ticket)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // 请求头标
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", ticket);  // 身份验证
                var resTask = client.GetAsync(url);
                resTask.Wait();
                var res = resTask.Result;
                if (!res.IsSuccessStatusCode) return default(T);
                var resultTask = res.Content.ReadAsAsync<T>();
                resultTask.Wait();
                return resultTask.Result;
            }
        }

        public static OperResult PostEntity<T>(string url, T item, string ticket)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // 请求头标
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", ticket);  // 身份验证
                var resTask = client.PostAsJsonAsync(url, item);
                resTask.Wait();
                var res = resTask.Result;
                if (!res.IsSuccessStatusCode)
                    return new OperResult { Flag = false, Message = "处理失败，未能连接到API服务！" };
                var resultTask = res.Content.ReadAsAsync<OperResult>();
                resultTask.Wait();
                return resultTask.Result;
            }
        }



        #region no ticket
        public static IEnumerable<T> GetEntitys<T>(string url)
        {
            return GetFromWebApi<IEnumerable<T>>(url);
        }

        public static T GetEntity<T>(string url)
        {
            return GetFromWebApi<T>(url);
        }

        private static T GetFromWebApi<T>(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var resTask = client.GetAsync(url);
                resTask.Wait();
                var res = resTask.Result;
                if (!res.IsSuccessStatusCode) return default(T);
                var resultTask = res.Content.ReadAsAsync<T>();
                resultTask.Wait();
                return resultTask.Result;
            }
        }

        public static OperResult PostEntity<T>(string url, T item)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var resTask = client.PostAsJsonAsync(url, item);
                resTask.Wait();
                var res = resTask.Result;
                if (!res.IsSuccessStatusCode)
                    return new OperResult { Flag = false, Message = "处理失败，未能连接到API服务！" };
                var resultTask = res.Content.ReadAsAsync<OperResult>();
                resultTask.Wait();
                return resultTask.Result;
            }
        }
        #endregion
    }
}
