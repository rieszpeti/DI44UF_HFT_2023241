using System;

namespace DI44UF_HFT_2023241.Models.Old
{
    public interface IApiCalledWebsite
    {
        DateTime ApiCallEndTime { get; init; }
        DateTime ApiCallStartTime { get; init; }
        TimeSpan CrawleProcessTime { get; }
        int Id { get; init; }
    }
}