﻿using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.Core.Attributes;

namespace Pekka.ClashRoyaleApi.Client.FilterModels
{
    public class ClanFilter : IApiFilter
    {
        [Query("name")] public string Name { get; set; }

        [Query("locationId")] public int? LocationId { get; set; }

        [Query("minMembers")] public int? MinMembers { get; set; }

        [Query("maxMembers")] public int? MaxMembers { get; set; }

        [Query("minScore")] public int? MinScore { get; set; }

        [Query("max")] public int? Limit { get; set; }

        [Query("page")] public int? After { get; set; }
    }
}