using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_HelloWorld.Models;

namespace DotNet_HelloWorld.Data
{
    public class Seeder
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();
            context.Posts.AddAsync(new Post {Title="title1", Content="wrlwnrönwnrwnrewnr"});
            context.Posts.AddAsync(new Post {Title="title2", Content="fmemgqeqmfqmfeqföeqmö"});
            context.Posts.AddAsync(new Post {Title="title3", Content="nqfufiqvqyveuequvgqt"});
            context.Posts.AddAsync(new Post {Title="title4", Content="nqvneeqryy3yyryrwwttwt"});
            context.Posts.AddAsync(new Post {Title="title5", Content="nvjaiwovvöaöaöaöaaaua"});
            context.SaveChanges();

        }
    }
}