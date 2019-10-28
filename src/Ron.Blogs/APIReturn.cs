using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using System.Threading.Tasks;

namespace Ron.Blogs
{
    public partial class APIReturn : ContentResult
    {
        public APIReturn() { }

        public APIReturn(int code) { this.SetCode(code); }

        public APIReturn(string message) { this.SetMessage(message); }

        public APIReturn(int code, string message, params object[] data) { this.SetCode(code).SetMessage(message).AppendData(data); }

        public APIReturn SetCode(int value) { this.Code = value; return this; }

        public APIReturn SetMessage(string value) { this.Message = value; return this; }

        public APIReturn SetData(params object[] value)
        {
            this.Data.Clear();
            return this.AppendData(value);
        }

        public APIReturn AppendData(params object[] value)
        {
            if (value == null || value.Length < 2 || value[0] == null) return this;
            for (int a = 0; a < value.Length; a += 2)
            {
                if (value[a] == null) continue;
                this.Data[value[a]] = a + 1 < value.Length ? value[a + 1] : null;
            }
            return this;
        }

        private void Jsonp(ActionContext context)
        {
            this.ContentType = "text/json;charset=utf-8;";
            this.Content = JsonConvert.SerializeObject(this, JsonConvert.DefaultSettings.Invoke());
        }

        public override void ExecuteResult(ActionContext context)
        {
            Jsonp(context);
            base.ExecuteResult(context);
        }

        public override Task ExecuteResultAsync(ActionContext context)
        {
            Jsonp(context);
            return base.ExecuteResultAsync(context);
        }

        /// <summary>
        /// 错误代码
        /// </summary>
        [JsonProperty("code")] public int Code { get; protected set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        [JsonProperty("message")] public string Message { get; protected set; }

        [JsonProperty("data")] public Hashtable Data { get; protected set; } = new Hashtable();

        /// <summary>
        /// 成功 0
        /// </summary>
        public static APIReturn OK => new APIReturn(0, "成功");
        /// <summary>
        /// 记录不存在 404
        /// </summary>
        public static APIReturn NotFound => new APIReturn(404, "记录不存在");
        /// <summary>
        ///  系统异常 5001000
        /// </summary>
        public static APIReturn InternalError => new APIReturn(500, "抱歉，访问出现错误了");
        /// <summary>
        ///  参数不能为空 50010
        /// </summary>
        public static APIReturn ArgumentNull => new APIReturn(50010, "参数不能为空");
    }
}