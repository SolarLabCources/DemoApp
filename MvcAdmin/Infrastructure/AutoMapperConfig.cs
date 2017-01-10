using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BusinessLogic.Objects;
using DataAccessLayer.Objects;
using MvcAdmin.Models;

namespace MvcAdmin.Infrastructure
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Post, PostDto>();
                cfg.CreateMap<PostDto, Post>();

                cfg.CreateMap<PostDto, PostViewModel>();
                cfg.CreateMap<PostViewModel, PostDto>();
            });
        }
    }
}