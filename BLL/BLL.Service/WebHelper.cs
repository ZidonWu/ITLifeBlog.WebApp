using BLL.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class WebHelper
    {
        public static TResult GetApi<TResult>(string url)
        {
            var resultTask = GetApiAsync<TResult>(url);
            resultTask.Wait();
            return resultTask.Result;
        }

        public static TResult GetApi2<TResult>(string url, string ticket)
        {
            var resultTask = GetApiAsync<TResult>(url, ticket);
            resultTask.Wait();
            return resultTask.Result;
        }

        /// <summary>
        /// 获取Cookie
        /// </summary>
        /// <param name="url">获取Cookie的地址</param>
        /// <returns>Cookie 或 null</returns>
        public static Cookie GetCookie(string url)
        {
            var uri = new Uri(url);
            var handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var resResult = client.GetAsync(uri);
                resResult.Wait();
                var res = resResult.Result;
                var operatorResultTask = res.Content.ReadAsStringAsync();
                operatorResultTask.Wait();
                var operatorResult = JsonConvert.DeserializeObject<OperResult>(operatorResultTask.Result);
                if (operatorResult.Code == 0)
                {
                    var cookies = handler.CookieContainer.GetCookies(uri);
                    if (cookies != null && cookies.Count > 0)
                        return cookies[0];
                }
                return null;
            }
        }

        public async static Task<TResult> GetApiAsync<TResult>(string url)
        {
            var uri = new Uri(url);
            var handler = new HttpClientHandler();
            //if (cookie != null)
            //    handler.CookieContainer.Add(cookie);
            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                // 请求头标
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue();  // 身份验证
                var res = await client.GetAsync(uri);
                var str = await res.Content.ReadAsStringAsync();
                Console.WriteLine(str);
                if (!res.IsSuccessStatusCode) return default(TResult);
                var result = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(result);
            }
        }

        public async static Task<TResult> GetApiAsync<TResult>(string url, string ticket)
        {
            var uri = new Uri(url);
            var handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                // 请求头标
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ticket);  // 身份验证
                var res = await client.GetAsync(uri);
                var str = await res.Content.ReadAsStringAsync();
                Console.WriteLine(str);
                if (!res.IsSuccessStatusCode) return default(TResult);
                var result = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(result);
            }
        }

        public static TResult PostApi<TResult, TObject>(string url, TObject obj, Cookie cookie = null)
        {
            var resultTask = PostApiAsync<TResult, TObject>(url, obj, cookie);
            resultTask.Wait();
            return resultTask.Result;
        }

        public static TResult PostApi<TResult, TObject>(string url, TObject obj, string ticket)
        {
            var resultTask = PostApiAsync<TResult, TObject>(url, obj, ticket);
            resultTask.Wait();
            return resultTask.Result;
        }

        public async static Task<TResult> PostApiAsync<TResult, TObject>(string url, TObject obj, Cookie cookie = null)
        {
            var uri = new Uri(url);
            var handler = new HttpClientHandler();
            if (cookie != null)
                handler.CookieContainer.Add(cookie);
            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var objString = JsonConvert.SerializeObject(obj);
                var content = new StringContent(objString);
                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var res = await client.PostAsync(uri, content);
                if (!res.IsSuccessStatusCode) return default(TResult);
                var result = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(result);
            }
        }

        public async static Task<TResult> PostApiAsync<TResult, TObject>(string url, TObject obj, string ticket)
        {
            var uri = new Uri(url);
            var handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var objString = JsonConvert.SerializeObject(obj);
                var content = new StringContent(objString);
                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var res = await client.PostAsync(uri, content);
                if (!res.IsSuccessStatusCode) return default(TResult);
                var result = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(result);
            }
        }
    }
}
