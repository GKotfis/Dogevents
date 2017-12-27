using System;

namespace Dogevents.Core.Domain
{
    public interface IViewEventModel
    {
        long Id { get; set; }
        string Name { get; set; }
        DateTime StartTime { get; set; }
    }
}