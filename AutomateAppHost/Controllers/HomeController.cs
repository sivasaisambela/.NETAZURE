using AutomateAppHost.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation.Runspaces;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Text;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace AutomateAppHost.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        static HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public  ActionResult AutoMigrate(IFormCollection form)
        {
            //  ProcessStartInfo startInfo = new ProcessStartInfo();

            string _endUserRepository = Convert.ToString(form["txtRepo"]);
            string _repoToken = Convert.ToString(form["txtRepoToken"]);
            string _appSvcName = Convert.ToString(form["txtAppName"]);
            string _resGroupName = Convert.ToString(form["txtRGName"]);
            string _sourceBranch = Convert.ToString(form["txtSourceName"]);

            string _resGroupName1 = Convert.ToString(form["txtRGName"]);
            string _sourceBranch2 = Convert.ToString(form["txtSourceName"]);

            string _repo = Convert.ToString(form["txtRepo"]);
            string _repTok = Convert.ToString(form["txtRepoToken"]);
            string _orgName = Convert.ToString(form["txtOrgName"]);
            string _orgPAT = Convert.ToString(form["txtPAT"]);
            string _orgProj = Convert.ToString(form["txtAzProject"]);
            string _ProjID = Convert.ToString(form["txtAzProjectId"]);
            
            string _repoName = Convert.ToString(form["txtAzRepo"]);
            var scriptfile = "";
            string _repoId = "";
            if (string.IsNullOrEmpty(_sourceBranch))
            {
           
             scriptfile = @".\wwwroot\lib\Automate_CICDAzure.ps1";
                
            }
            else
            {
            
             scriptfile = @".\wwwroot\lib\Automate_deployinAzure1.ps1";
            }



          //  PowerShell powershell = PowerShell.Create();

            //RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
            //Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration)
            try
            {
                //using (Runspace runspace = RunspaceFactory.CreateRunspace())
                //{
                    //runspace.Open();
                    ////RunspaceInvoke scriptInvoker = new RunspaceInvoke(runspace);
                    ////scriptInvoker.Invoke("Set-ExecutionPolicy Unrestricted");
                    //powershell.Runspace = runspace;
                    ////powershell.Commands.AddScript("Add-PsSnapin Microsoft.SharePoint.PowerShell");
                    //System.IO.StreamReader sr = new System.IO.StreamReader(scriptfile);
                    //StringBuilder st = new StringBuilder();
                    //st.Append(sr.ReadToEnd());
                    //st.Replace("stry", _endUserRepository);
                    //st.Replace("isat", _repoToken);
                    //st.Replace("svcname", _appSvcName);
                    //st.Replace("resgroup", _resGroupName);
                    //st.Replace("sourcebrnch", _sourceBranch);

                    //st.Replace("azorg", string.Concat("https://dev.azure.com/" + _orgName));
                    //st.Replace("aztoken", _orgPAT);
                    //st.Replace("azrepon", _repoName);
                    //st.Replace("azprjc", _orgProj);

                    //powershell.AddScript(st.ToString());

                    

                    //try
                    //{
                      
                    //     //  var results = powershell.Invoke();
                    //    //if (powershell.Streams.Error.Count > 1)
                    //    //{

                    //    //    ViewBag.Result = "Failed to Host your application in Azure." + 2 + (powershell.Streams.Error[0]).Exception.Message.ToString(); ;
                    //    //}
                    //    //ViewBag.Result = results.ToString();
                    //}
                    //catch (Exception ex)
                    //{
                    //    ViewBag.Result = ex.Message+1;
                    //}
                  
                    if (!string.IsNullOrEmpty(_orgName) && !string.IsNullOrEmpty(_orgProj))
                    {


                    var res = Task.Run(() => CreateRepo(_orgName, _orgProj, _ProjID, _orgPAT, _repoName));
                    Thread.Sleep(5000);

                    if (res.Result != "")
                    {
                        _repoId = res.Result;
                        var outpt = Task.Run(() => ImportRepo(_orgName, _orgProj, _orgPAT, _repoId, _repoName, _endUserRepository));
                        Thread.Sleep(5000);
                    }

                    var t = Task.Run(() => GetRepositoryId(_orgName, _orgProj, _repoName, _orgPAT));
                    Thread.Sleep(5000);
                    string numericPipId = "";
                        string PipelineId = "";
                        dynamic t1 = "";
                        string commitId = "";
                        string repoID = t.Result;
                        string refBranch = "";
                        if (!string.IsNullOrEmpty(repoID))
                        {
                            var x = Task.Run(() => GetLastCommitId(_orgName, _orgProj, _repoName, _orgPAT));
                         //x.Wait(1000);
                        // t.Wait(10000);

                        commitId = x.Result ;
                        }
                        if (!string.IsNullOrEmpty(commitId) && !string.IsNullOrEmpty(repoID))
                        {
                            var x1 = Task.Run(() => GetRefBranch(_orgName, _orgProj, _repoName, _orgPAT));

                            //if (!string.IsNullOrEmpty(x1.Result))
                            {
                                refBranch = x1.Result;
                                var x = Task.Run(() => AddFileToRepository(_orgName, _orgProj, _repoName, commitId, _orgPAT, refBranch));
                            Thread.Sleep(5000); string s12 = "";
                            }

                        }

                        //if (t.Result != "")
                        {
                            t1 = Task.Run(() => CreatePipeline(_orgProj, t.Result, _orgName, _orgPAT));//creating pipeline
                        Thread.Sleep(5000);                                                                        //  t1.Wait(5000);
                        PipelineId = t1.Result;

                            //executing pipeline
                        }
                        if (PipelineId != "")
                        {
                            PipelineId = PipelineId;
                            string s11 = PipelineId.ToString().Substring(PipelineId.ToString().IndexOf("pipelines"));
                            string s12 = s11.Substring(s11.IndexOf('/'));
                            string des = s12.Substring(0, s12.IndexOf('?'));
                            numericPipId = new String(des.Where(Char.IsDigit).ToArray());
                            if (!string.IsNullOrEmpty(numericPipId))
                            {
                                var t23 = Task.Run(() => ExecutePipeline(_orgProj, numericPipId, _orgName, _orgPAT, refBranch));
                            }
                        }
                    }

                //}
            }
            catch (Exception ex)
            {
                ViewBag.Result = ex.Message+3;
            }

             return View();
            //}
        }

        private async Task<string> CreateRepo(string Org,string projectName, string ProjectId,string projAccessToken,string repoName)
        {
            string url = "https://dev.azure.com/" + Org + "/" + projectName + "/_apis/git/repositories?api-version=6.0";
        
            string repoId = "";
            try
            {
                // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                C1 rt = new C1();
                rt.name = repoName;
                rt.project = new Project();
                rt.project.id = ProjectId;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                   
                 
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var cred = "SivaSaiSambela@godevsuite149.onmicrosoft.com" + ":" + projAccessToken;
                    //Encoding.UTF8.GetBytes()
                    Encoding.UTF8.GetBytes(cred);
                    var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes(cred));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authString);
                    //  client.DefaultRequestHeaders.Add("Authorization", "Basic hno7tsogxvzgilkiohj2i2ovtvkk7exhbjff5axkja42szrbye4q");
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(cred));
                    //client.DefaultRequestHeaders.Authorization = System.Net.Http.Headers.AuthenticationHeaderValue.Parse("Basic " + credentials);


                    var json = JsonConvert.SerializeObject(rt);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, data);

                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();
                        
                        repoId = JObject.Parse(rawResponse)["id"].ToString();
                    }
                    else
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();
                    }

                }
            }
            catch (Exception ex)
            {
                ViewBag.Result = ex.Message + 2;
            }
            return repoId;

        }


        private async Task<string> ImportRepo(string Org, string projectName, string projAccessToken,string repoId, string repoName,string endUserRepoURI)
        {
            string url = "https://dev.azure.com/" + Org + "/" + projectName + "/_apis/git/repositories/"+ repoId + "/importRequests?api-version=6.0-preview.1";

   
            string res = "";
            try
            {
                // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Root rt = new Root();
                rt.parameters = new Parameters();
                rt.parameters.gitSource = new GitSource();
                rt.parameters.gitSource.url = endUserRepoURI;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var credted = "SivaSaiSambela@godevsuite149.onmicrosoft.com" + ":" + projAccessToken;
                   
                    Encoding.UTF8.GetBytes(credted);
                    var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes(credted));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authString);

                    var json = JsonConvert.SerializeObject(rt);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, data);

                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();
                        var s = JObject.Parse(rawResponse).ToString();
                    }
                    else
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();
                    }

                }
            }
            catch (Exception ex)
            {
                ViewBag.Result = ex.Message + 2;
            }
            return res;

        }
        public class GitSource
        {
            public string url { get; set; }
        }

        public class Parameters
        {
            public GitSource gitSource { get; set; }
        }

        public class Root
        {
            public Parameters parameters { get; set; }
        }


        public class Project
        {
            public string id { get; set; }
        }

        public class C1
        {
            public string name { get; set; }
            public Project project { get; set; }
        }

        public IActionResult Index()
        {
            return View("Automate");
        }
        private  async Task<string> CreatePipeline(string Project,string RepoId,string Org, string projAccessToken)
        {
            string url = "https://dev.azure.com/" + Org + "/" + Project + "/_apis/pipelines?api-version=6.0-preview.1";

            string pipelineID = "";
            try
            {
                // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                C3 rt = new C3();
                rt.folder = null;
                Guid myuuid = Guid.NewGuid();
                rt.name = "sivapipeline" + myuuid;
                //Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                rt.configuration = new Configuration();
                rt.configuration.type = "yaml";
                rt.configuration.path = "/azure-pipelines.yml";
                rt.configuration.repository = new Repository();
                rt.configuration.repository.id = RepoId;
                rt.configuration.repository.name = Project;
                rt.configuration.repository.type = "azureReposGit";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var credt = "SivaSaiSambela@godevsuite149.onmicrosoft.com" + ":" + projAccessToken;
                    //Encoding.UTF8.GetBytes()
                    Encoding.UTF8.GetBytes(credt);
                    var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes(credt));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authString);

                    var json = JsonConvert.SerializeObject(rt);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, data);

                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();
                        var s = JObject.Parse(rawResponse).ToString();

                        dynamic stuff = JsonConvert.DeserializeObject(s);
                        Newtonsoft.Json.Linq.JToken a1 = (((Newtonsoft.Json.Linq.JContainer)stuff).First);
                        List<Newtonsoft.Json.Linq.JToken> res1 = a1.ToList();
                        foreach (var item in res1)
                        {
                            if (item.ToString().Contains("href"))
                            {
                                string s34 = item.ToString();
                                pipelineID = JObject.Parse(s34)["self"].First().ToString();
                            }
                        }

                    }
                    else
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();
                    }

                }
            }
            catch(Exception ex)
            {
                ViewBag.Result = ex.Message + 2;
            }
            return pipelineID;
            
        }

        private async Task<string> ExecutePipeline(string Project, string PipelineId, string Org, string projAccessToken,string refBranch)
        {
            string outputCode = "";
            try
            {
                string url = "https://dev.azure.com/" + Org + "/" + Project + "/_apis/pipelines/" + PipelineId + "/runs?api-version=6.0-preview.1";
                C2 rt1 = new C2();
                rt1.resources = new Resources();
                rt1.resources.repositories = new Repositories();
                rt1.resources.repositories.self = new Self();
                rt1.resources.repositories.self.refName = refBranch;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var cred = "SivaSaiSambela @godevsuite149.onmicrosoft.com" + ":" + projAccessToken;
                    //Encoding.UTF8.GetBytes()
                    Encoding.UTF8.GetBytes(cred);
                    var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes(cred));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authString);

                    var json = JsonConvert.SerializeObject(rt1);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, data);

                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();
                        var s = JObject.Parse(rawResponse).ToString();

                    }
                    else
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();
                    }


                }
            }
            catch(Exception ex)
            {
                ViewBag.Result = ex.Message;
            }
            return outputCode;

            
        }
        public class Repositories
        {
            public Self self { get; set; }
        }

        public class Resources
        {
            public Repositories repositories { get; set; }
        }

        public class C2
        {
            public Resources resources { get; set; }
        }

        public class Self
        {
            public string refName { get; set; }
        }

        public async Task<string> GetRepositoryId(string orgName, string projName,string repoName,string projAccessToken)
        {
            string azurerepId="";

            try
            {
                string url = "https://dev.azure.com/" + orgName + "/" + projName + "/_apis/git/repositories/" + repoName + "?api-version=6.0";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var s = "SivaSaiSambela@godevsuite149.onmicrosoft.com" + ":" + projAccessToken;
                    //Encoding.UTF8.GetBytes()
                    Encoding.UTF8.GetBytes(s);
                    var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authString);
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();
                        azurerepId = JObject.Parse(rawResponse)["id"].ToString();
                        //azurerepId = JObject.Parse(rawResponse)["value"].First()["id"].Value<string>();

                    }
                    else
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();

                    }

                }
            }
            catch(Exception ex)
            {
                ViewBag.Result = ex.Message;
            }
            return azurerepId;


        }

        public class Refs
        {
            public string name { get; set; }
            public string objectId { get; set; }

            public string oldObjectId { get; set; }

            public Creator creator { get; set; }
            public string url { get; set; }
        }

        public class Creator
        {
        }
        public class Change
        {
            public string changeType { get; set; }
            public Item item { get; set; }
            public Newcontent newContent { get; set; }
        }

        public class CommitToAdd
        {
            public string comment { get; set; }
            public ChangeToAdd[] changes { get; set; }
        }

        public class ChangeToAdd
        {
            public string changeType { get; set; }
            public ItemBase item { get; set; }
            public Newcontent newContent { get; set; }
        }
        public class ItemBase
        {
            public string path { get; set; }
        }

        public class Newcontent
        {
            public string content { get; set; }
            public string contentType { get; set; }
        }

        public async Task<string> GetRefBranch(string orgName, string projName, string repoName, string projAccessToken)
        {
            string commitrefBranch = "";

            try
            {
                string url = "https://dev.azure.com/" + orgName + "/" + projName + "/_apis/git/repositories/" + repoName + "?api-version=6.0";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var s = "SivaSaiSambela@godevsuite149.onmicrosoft.com" + ":" + projAccessToken;
                    //Encoding.UTF8.GetBytes()
                    Encoding.UTF8.GetBytes(s);
                    var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authString);
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();

                        commitrefBranch = JObject.Parse(rawResponse)["defaultBranch"].ToString();
                        // JObject.Parse(rawResponse)["value"].First()["commitId"].Value<string>();
                        //commitrefBranch = JObject.Parse(rawResponse)["value"].First()["defaultBranch"].Value<string>();
                        // commitId = JObject.Parse(rawResponse)["commitId"].ToString();
                        //azurerepId = JObject.Parse(rawResponse)["value"].First()["id"].Value<string>();

                    }
                    else
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();
                    }

                }
            }
            catch(Exception ex)
            {
                ViewBag.Result = ex.Message;
            }
            return commitrefBranch;


        }

        public async Task<string> GetLastCommitId(string orgName, string projName, string repoName, string projAccessToken)
        {
            string commitId = "";

            try
            {

                string url = "https://dev.azure.com/" + orgName + "/" + projName + "/_apis/git/repositories/" + repoName + "/commits?api-version=6.0";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var s = "SivaSaiSambela@godevsuite149.onmicrosoft.com" + ":" + projAccessToken;
                    //Encoding.UTF8.GetBytes()
                    Encoding.UTF8.GetBytes(s);
                    var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authString);
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();
                        JObject.Parse(rawResponse)["value"].First()["commitId"].Value<string>();
                        commitId = JObject.Parse(rawResponse)["value"].First()["commitId"].Value<string>();
                        // commitId = JObject.Parse(rawResponse)["commitId"].ToString();
                        //azurerepId = JObject.Parse(rawResponse)["value"].First()["id"].Value<string>();

                    }
                    else
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();
                    }

                }
            }
            catch(Exception ex)
            {
                ViewBag.Result = ex.Message;
            }
            return commitId;


        }

        public async Task AddFileToRepository(string orgName,string projectName, string repositoryId,string commitId, string projAccessToken,string refBranch)
        {
            
            string brch = @""+refBranch;
            try
            {
                var refs = new List<Refs>() { new Refs { oldObjectId = commitId, name = brch } };
                //string s232 = System.IO.Directory.g();
                
                string path1 = "";
            
                //if (s232.Contains("wwwroot"))
                //{
                    path1 = Path.GetFullPath(@".\wwwroot\az-pipelines.yml");
                //}
                //else
                {
                    path1 = Path.GetFullPath(@".\wwwroot\az-pipelines.yml");
                  //  path1 = Path.GetFullPath(@".\wwwroot\lib\az-pipelines.yml");
                }
                var changes = new List<ChangeToAdd>();
               
                System.IO.StreamReader sr = new System.IO.StreamReader(path1);

                var jsonContent = sr.ReadToEnd();

                ChangeToAdd changeJson = new ChangeToAdd()
                {
                    changeType = "add",
                    item = new ItemBase() { path = string.Concat(@"azure-pipelines.yml") },
                    newContent = new Newcontent()
                    {
                        contentType = "rawtext",
                        content = jsonContent
                    }
                };
                changes.Add(changeJson);




                CommitToAdd commit = new CommitToAdd();
                commit.comment = "commit from code by siva";
                commit.changes = changes.ToArray();

                var content = new List<CommitToAdd>() { commit };
                var request = new
                {
                    refUpdates = refs,
                    commits = content
                };

                var uri = "https://dev.azure.com/" + orgName + "/" + projectName + "/_apis/git/repositories/" + repositoryId + "/pushes?api-version=6.0";

                using (var client = new HttpClient())
                {

                    var s = "SivaSaiSambela@godevsuite149.onmicrosoft.com" + ":" + projAccessToken;
                    //Encoding.UTF8.GetBytes()
                    Encoding.UTF8.GetBytes(s);
                    var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authString);


                    var json = JsonConvert.SerializeObject(request);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");


                    var response = await client.PostAsync(uri, data);

                    if (!response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();
                        //throw new Exception(ApplicationMessages.FailedToAddFilesToRepository);
                    }
                    else
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();
                    }
                }
            }
            catch(Exception ex)
            {
                ViewBag.Result = ex.Message;
            }
            }
        
        public class Inputs
        {
            public string Password;
          //  public string name;
         //   public string AppComments;
            public string UserName;
          //  public string AppKey;
        }
        public class Configuration
        {
            public string type { get; set; }
            public string path { get; set; }
            public Repository repository { get; set; }
        }

        public class Repository
        {
            public string id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
        }

        public class C3
        {
            public string folder { get; set; }
            public string name { get; set; }
            public Configuration configuration { get; set; }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public void PushFile()
        //{
        //    var changes = new List<ChangeToAdd>();
        //    //Add Files

        //    //System.IO.StreamReader sr = new System.IO.StreamReader("");

        //    StreamReader sr = new StreamReader(@"C:\Users\sivasaisambela\Automate_CICDAzure.ps1");
        //    string jsonString = sr.ReadToEnd();
        //    //pnp_structure.yml
        //    var jsonContent = jsonString;

        //    ChangeToAdd changeJson = new ChangeToAdd()
        //    {
        //        changeType = "add",
        //        item = new ItemBase() { path = string.Concat(@"C:\Users\sivasaisambela\Automate_CICDAzure.ps1") },
        //        newContent = new Newcontent()
        //        {
        //            contentType = "rawtext",
        //            content = jsonContent
        //        }
        //    };
        //    changes.Add(changeJson);


        //    CommitToAdd commit = new CommitToAdd();
        //    commit.comment = "commit from code";
        //    commit.changes = changes.ToArray();

        //    var content = new List<CommitToAdd>() { commit };
        //    var request = new
        //    {
        //        refUpdates = refs,
        //        commits = content
        //    };

        //    var personalaccesstoken = _configuration["azure-devOps-configuration-token"];

        //    var authorization = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", personalaccesstoken)));

        //    _logger.LogInformation($"[HTTP REQUEST] make a http call with uri: {uri} ");

        //    //here I making http client call 
        //    // https://dev.azure.com/{orgnizationName}/{projectName}/_apis/git/repositories/{repositoryId}/pushes{?api-version}
        //    var result = _httpClient.SendHttpWebRequest(uri, method, data, authorization);
        //}
    }

    public class Item
    {
    }

    internal class CommitToAdd
    {
        internal string comment;
        internal ChangeToAdd[] changes;
    }

    internal class ChangeToAdd
    {
        internal ItemBase item;
        internal Newcontent newContent;

        public string changeType { get; set; }
        public ItemBase itembase { get; set; }


    }
    internal class Newcontent
    {
        internal string contentType;
        internal string content;
    }
    public class ItemBase
    {
        internal string path;
              
    }

    
}
