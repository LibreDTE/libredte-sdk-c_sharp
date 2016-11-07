using LibreSDK.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace LibreSDK
{
    public class Rest
    {
        private String url;

        private String auth = null;

        private int status;

        private RestResponse result;

        private byte[] bytes;

        public Rest(String url)
        {
            this.url = url;
        }

        public void SetAuth(String token)
        {
            var message = Encoding.UTF8.GetBytes(token + ":X");
            this.auth = Convert.ToBase64String(message);
        }

        public void SetAuth(string user, string password)
        {
            var message = Encoding.UTF8.GetBytes(string.Format("{0}:{1}", user, password));
            this.auth = Convert.ToBase64String(message);
        }

        public int getStatus()
        {
            return this.status;
        }

        public RestResponse getResult()
        {
            return this.result;
        }

        public T getResponse<T>()
        {
            return (T)this.result.Response;
        }

        public bool getIsSuccess()
        {
            return this.result.IsSuccess;
        }

        public string getMessage()
        {
            return this.result.Message;
        }

        public byte[] getBytes()
        {
            return this.bytes;
        }

        public void Consume<T>(String resource, String method, String data = null, String contentType = "application/json")
        {
            string url = null;
            HttpWebRequest request = null;
            try
            {
                url = this.url + resource;
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;
                request.ContentType = contentType;
                request.Accept = "application/json";

                if (!string.IsNullOrEmpty(this.auth))
                {
                    request.Headers["Authorization"] = "Basic " + this.auth;
                }

                if (data != null)
                {
                    var dataBytes = Encoding.UTF8.GetBytes(data);
                    request.ContentLength = dataBytes.Length;
                    var requestStream = request.GetRequestStream();
                    requestStream.Write(dataBytes, 0, (int)dataBytes.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                if (method == "GET")
                {
                    var pdfResponse = string.Empty;

                    using (Stream streamResponse = response.GetResponseStream())
                    {
                        using (StreamReader streamRead = new StreamReader(streamResponse))
                        {
                            var stream = streamRead.BaseStream;
                            byte[] b;

                            using (MemoryStream ms = new MemoryStream())
                            {
                                stream.CopyTo(ms);
                                b = ms.ToArray();
                            }

                           pdfResponse = Convert.ToBase64String(b);
                        }
                    }

                    this.result = new RestResponse
                    {
                        Response = new InvoiceResponse() { PdfData = pdfResponse, Success = true },
                        IsSuccess = true
                    };
                }
                else
                {
                    string jsonResponse = null;
                    using (Stream streamResponse = response.GetResponseStream())
                    {
                        using (StreamReader streamRead = new StreamReader(streamResponse))
                        {
                            jsonResponse = streamRead.ReadToEnd();
                        }
                    }

                    this.result = new RestResponse
                    {
                        Response = (IResponse)JsonConvert.DeserializeObject<T>(jsonResponse),
                        IsSuccess = true
                    };
                }

            }
            catch (WebException ex)
            {
                try
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        this.result = new RestResponse
                        {
                            Message = reader.ReadToEnd(),
                            IsSuccess = false
                        };
                    }
                }
                catch (Exception e)
                {
                    this.result = new RestResponse
                    {
                        Message = ex.Message + e.Message,
                        IsSuccess = false
                    };
                }

            }
            catch (Exception ex)
            {
                this.status = 500;

                this.result = new RestResponse
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
            }
        }
    }
}