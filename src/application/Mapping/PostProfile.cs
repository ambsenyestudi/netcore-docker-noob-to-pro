using AutoMapper;
using MyBackgroundProcess.Application.DTO;
using MyBackgroundProcess.Domain.Posting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackgroundProcess.Application.Mapping
{
    public class PostProfile: Profile
    {
        public PostProfile()
        {
            CreateMap<PostDTO, Post>().ConvertUsing<PostConverter>();
        }
    }
}
