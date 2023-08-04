using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendSpotify.Common.Dtos
{
    public class ResponseDto<T>
    {
        public bool HasErrors => Errors is { Count: > 0 };
        public List<string> Errors { get; set; } = new();
        public T Result { get; set; }
    }
}
