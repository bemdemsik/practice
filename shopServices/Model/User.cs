// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopServices.Model
{
    class User
    {
        public int id { get; set;  }
        public string name { get; set; } = string.Empty;
        public string surname { get; set; } = string.Empty;
        public string lastname { get; set; } = null;
        public string happy { get; set; } = null;
        public string telephone { get; set; } = null;
        public string login { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
    }
}
