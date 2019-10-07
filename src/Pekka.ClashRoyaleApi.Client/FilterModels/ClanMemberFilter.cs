﻿using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.Core.Attributes;

namespace Pekka.ClashRoyaleApi.Client.FilterModels
{
    public class ClanMemberFilter : IApiFilter
    {
        [Query("limit")]
        public int? Limit { get; set; }

        [Query("after")]
        public int? After { get; set; }

        [Query("before")]
        public int? Before { get; set; }
    }
}