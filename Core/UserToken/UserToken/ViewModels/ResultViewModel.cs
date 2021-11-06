using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserToken.ViewModels
{
    public class ResultViewModel
    {
        public bool IsSuccess { get; set; } = true;
        public string Massage { get; set; }
        public object Data { get; set; }
    }
}
