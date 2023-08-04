﻿using BackendSpotify.Common.Dtos;
using BackendSpotify.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BackendSpotify.Domain.Implementations
{
    public class GetFeaturedPlaylistsService : IGetFeaturedPlaylistsService
    {
        private readonly IConfiguration _configuration;

        public GetFeaturedPlaylistsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ResponseDto<string>> Execute(string token)
        {
            ResponseDto<string> response = new ResponseDto<string>();

            try
            {
                string spotifyUrl = _configuration.GetSection("UrlSpotify").Value;
                string endPoint = _configuration.GetSection("EndPointFeaturedPlaylists").Value;

                var client = new RestClient(spotifyUrl);
                var request = new RestRequest(endPoint);
                request.AddHeader("Authorization", "Bearer " + token);

                var responseClient = await client.GetAsync(request);

                if (responseClient != null && responseClient.StatusCode == HttpStatusCode.OK)
                {
                    response.Result = responseClient.Content;
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                return response;
            }

            return response;
        }
    }
}
