using BackendSpotify.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendSpotify.Domain.Interfaces
{
    public interface IGetMePlaylistsService
    {
        Task<ResponseDto<string>> Execute(string token);
    }
}
