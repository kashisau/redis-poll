using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ServiceStack.Redis;

class VotingEvent {
  string actID;

  VotingEvent(string actiID) {
    actID = actID;
  }

  public async Task submitVote(Vote votes) {
    votes.actID = actID;
    // Construct the JSON object.
    JObject voteSubmission = (JObject)JObject.FromObject(votes);
    var manager = new RedisManagerPool("localhost:6379");
    using (var client = manager.GetClient())
    {
      client.Set("foo", "bar");
      Console.WriteLine("foo={0}", client.Get<string>("foo"));
    }
  }
}