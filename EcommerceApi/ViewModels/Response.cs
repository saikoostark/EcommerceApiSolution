namespace EcommerceApi.ViewModels
{
    public class Response<T>
    {
        public string? Msg { get; set; }


        public T? Data { get; set; }


        public int ResultCode { get; set; }



        public Response(T? data, int rescode = 0, string msg = "ok")
        {
            Data = data;
            Msg = msg;
            ResultCode = rescode;
        }

    }
}