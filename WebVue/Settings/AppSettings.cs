using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLRepository.Client;

namespace WebVue.Settings
{
    public class AppSettings
    {
        public string SQLRepositoryUrl { get; set; }

        public SQLRepositoryClientSettings SqlRepositoryClientSettings { get; set; }
    }
}
