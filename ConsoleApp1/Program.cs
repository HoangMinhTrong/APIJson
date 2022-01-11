// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.Http;
using Nancy.Json;
using Nancy.Responses;
using Nest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net.Http.Headers;
const string url = "https://stage.hrms.nfq.asia/api/organization?userId=1";
const string token = "11c7ec6f09757214fb57bd8a7d13e935fd44461a56921a0325dde17ddae7dafc";
HttpClient client = new HttpClient();
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
var json = client.GetStringAsync(url).Result;
var response = (JObject)JsonConvert.DeserializeObject(json);
var serializer = new JavaScriptSerializer();
var objects = serializer.Deserialize<Member[]>(json);
OrgChartData data = objects["responseData"].ToObject<OrgChartData>();
Console.WriteLine(data);

public class OrgChartData
{
    public int managerId { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public int supervisorId { get; set; }
    public Manager manager { get; set; }
    public int totalMember { get; set; }
    public int subMember { get; set; }
    public Member[] children { get; set; }
};
public class Title
{
    public string name { get; set; }
    public string level { get; set; }
}

public class TeamMember
{
    public int id { get; set; }
    public int teamId { get; set; }
    public int employeeId { get; set; }
    public int positionId { get; set; }
    public int fte { get; set; }
    public string status { get; set; }
    public object leavingExpectingDate { get; set; }
    public object leavingReason { get; set; }
    public object skillId { get; set; }
    public int levelId { get; set; }
    public string positionName { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}

public class Team
{
    public string location { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string status { get; set; }
    public string department { get; set; }
    public string techRelevant { get; set; }
    public TeamMember teamMember { get; set; }
}

public class Manager
{
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string avatarUrl { get; set; }
    public string workplaceLink { get; set; }
    public Title title { get; set; }
    public List<Team> teams { get; set; }
    public object skill { get; set; }
}

public class Skill
{
    public int id { get; set; }
    public string name { get; set; }
    public object jobType { get; set; }
}

public class Member
{
    public int managerId { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public int supervisorId { get; set; }
    public Manager manager { get; set; }
    public int totalMember { get; set; }
    public int subMember { get; set; }
    public Member[] children { get; set; }
}


