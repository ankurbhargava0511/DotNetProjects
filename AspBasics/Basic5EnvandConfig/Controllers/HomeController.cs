using Basic5EnvandConfig.Options;
using Basic5EnvandConfig.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Basic5EnvandConfig.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IConfiguration config, IOptions<MyConfigurationOptionsBuilder> builderOption, IWebHostEnvironment webHost, IMyhttpServices http)
        {
            Config = config;
            WebHost = webHost;
            Http = http;
            BuilderOption = builderOption.Value;
        }

        public IConfiguration Config { get; }
        public IWebHostEnvironment WebHost { get; }
        public IMyhttpServices Http { get; }
        public MyConfigurationOptionsBuilder BuilderOption { get; }

        [Route("/")]
        public IActionResult Index()
        {
            string key = Config["MyKey"];
            string keyGetValue = Config.GetValue<string>("MyKey");

            return new ContentResult() { Content = $"Testing Configuration -from Key: {key},  and from get value {keyGetValue}", ContentType = "text/plain" };
        }


        [Route("/Heriracy")]
        public IActionResult Index1()
        {
            string key = Config["Allvalue:idvalue"];
            string keyGetValue = Config.GetValue<string>("Allvalue:namevalue");

            IConfigurationSection section = Config.GetSection("Allvalue");
            string keyFromSection = section["idvalue"];
            string keyGetValueFromSection = section.GetValue<string>("namevalue");


            Config.GetSection("TestingOptions").Get<MyConfigurationOptions>();

            return new ContentResult() { Content = $"Testing Hirarcy Configuration -from Key: {key},  and from get value {keyGetValue} \n Configuration section -from keyFromSection: {keyFromSection},  and from keyGetValueFromSection {keyGetValueFromSection}", ContentType = "text/plain" };
        }

        [Route("/ConfigUsingOptions")]
        public IActionResult Index2()
        {
            MyConfigurationOptions opt = Config.GetSection("TestingOptions").Get<MyConfigurationOptions>();

            MyConfigurationOptions opt1 = new MyConfigurationOptions();

            Config.GetSection("TestingOptions").Bind(opt1);
            string va = $"Adding configution using Option pattern into option class \n val1= {opt.Val1},\n val2= {opt.Val2},\n val3= {opt.Val3},\n val4= {opt.Val4},\n val5= {opt.Val5}, ";
            va = va + $"\n Now using Bind  \n val1= {opt1.Val1},\n val2= {opt1.Val2},\n val3= {opt1.Val3},\n val4= {opt1.Val4},\n val5= {opt1.Val5}, ";
            va = va + $"\n Difference  : Bind use existing option, Get use new options";

            return new ContentResult() { Content = va, ContentType = "text/plain" };


        }

        [Route("/ConfigUsingOptionsViaServices")]
        public IActionResult Index3()
        {
            string va = $"Adding configution using Option pattern into option class \n val1= {BuilderOption.build1},\n val2= {BuilderOption.build2},\n val3= {BuilderOption.build3},\n val4= {BuilderOption.build4},\n val5= {BuilderOption.build5}, ";


            return new ContentResult() { Content = va, ContentType = "text/plain" };

            
        }

        [Route("/getEnv")]
        public IActionResult Index4()
        {
            string va = WebHost.EnvironmentName + "using Webhost from controller" ;


            return new ContentResult() { Content = va, ContentType = "text/plain" };


        }

        [Route("/getCustomeConfig")]
        public IActionResult Index5()
        {

            string key = Config["myConfig:configValue1"];
            string key2 = Config["myConfig:configValue2"];
           
            string va =$"Custome Config Json file Read: \n value 1 {key} , value2 {key2}";


            return new ContentResult() { Content = va, ContentType = "text/plain" };


        }

        [Route("/httpClient")]
        public  async Task<IActionResult> Index6()
        {

            string value= await Http.method();

            return new ContentResult() {Content= value, ContentType = "text/plain" };


        }
    }
}
