﻿using System.Collections.Generic;
using Bwr.Web.Framework.Models;

namespace Bwr.Web.Models.Boards
{
    public partial  class ForumGroupModel : BaseNopModel
    {
        public ForumGroupModel()
        {
            Forums = new List<ForumRowModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SeName { get; set; }

        public IList<ForumRowModel> Forums { get; set; }
    }
}