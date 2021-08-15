using Bwr.Web.Models.Polls;
using System.Collections.Generic;

namespace Bwr.Web.Factories.Mobile
{
    public interface IHomepagePollsMobFactory
    {
        List<PollModel> GetHomePagePolls();
    }
}
