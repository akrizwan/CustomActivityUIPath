using Newtonsoft.Json;
using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity
{
    [Activity]
    [Designer(typeof(LUISCallDesigner))]
    public class LUISCall : NativeActivity
    {
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> LUIS_URL { get; set; }

        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<string> Expression { get; set; }

        
        public OutArgument<List<Intent>> Intent_List { get; set; }

        public OutArgument<List<Entity>> Entity_List { get; set; }


        protected override void Execute(NativeActivityContext context)
        {
            //Intent_List.Set(context, new List<string>() { "Greeting" });
            //Entity_List.Set(context, new List<string>());
            Rootobject Data = new Rootobject();
            List<Intent> intentList = new List<Intent>();
            List<Entity> entityList = new List<Entity>();
            //var Data = await GetEntityFromLUIS(Expression.Get(context), LUIS_URL.Get(context), context).ConfigureAwait(true);
            string croppedExpression = Expression.Get(context);
            if (Expression.Get(context).Length > 500)
            {
                croppedExpression = Expression.Get(context).Substring(0, 500);
            }

            string url = LUIS_URL.Get(context) + "&q=" + croppedExpression;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";

            using (WebResponse response = httpWebRequest.GetResponse())
            {
                HttpWebResponse httpResponse = response as HttpWebResponse;
                using (StreamReader reader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var json = reader.ReadToEnd();
                    Data = JsonConvert.DeserializeObject<Rootobject>(json);
                }
            }

            intentList = Data.intents.ToList();
            entityList = Data.entities.ToList();

            Intent_List.Set(context, intentList);
            Entity_List.Set(context, entityList);
        }





        //public async Task<Rootobject> GetEntityFromLUIS(string Query, string LUISURL, NativeActivityContext context)
        //{
        //    Query = Uri.EscapeDataString(Query);
        //    Rootobject Data = new Rootobject();
        //    using (HttpClient client = new HttpClient())
        //    {
        //        string RequestURI = LUISURL + "&q=" + Query;
        //        client.BaseAddress = new Uri(RequestURI);

        //        HttpResponseMessage msg = await client.GetAsync(RequestURI);

        //        if (msg.IsSuccessStatusCode)
        //        {
        //            var JsonDataResponse = await msg.Content.ReadAsStringAsync();
        //            Data = JsonConvert.DeserializeObject<Rootobject>(JsonDataResponse);
        //        }
        //    }
        //    Console.WriteLine(Data.intents[0].intent);
        //    return Data;
        //}

        //protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        //{
        //    Intent_List.Set(context, new List<string>());
        //    Entity_List.Set(context, new List<string>());
        //    var Data = GetEntityFromLUIS(Expression.Get(context), LUIS_URL.Get(context));
        //    Data.Wait(5000);
        //    return Data;
        //}

        //protected override void EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        //{
        //    Rootobject data = new Rootobject();
        //    data = result as Rootobject;
        //    Intent_List.Set(context, new List<string>() { data.intents[0].intent });
        //}
    }

    public class Rootobject
    {
        public string query { get; set; }
        public Topscoringintent topScoringIntent { get; set; }
        public Intent[] intents { get; set; }
        public Entity[] entities { get; set; }
    }

    public class Topscoringintent
    {
        public string intent { get; set; }
        public float score { get; set; }
    }

    public class Intent
    {
        public string intent { get; set; }
        public float score { get; set; }
    }

    public class Entity
    {
        public string entity { get; set; }
        public string type { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
        public float score { get; set; }
    }

}
