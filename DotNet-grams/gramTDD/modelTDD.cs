using DotNet_grams.Data;
using DotNet_grams.Models;
using DotNet_grams.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace gramTDD
{
    public class modelTDD
    {/// <summary>
    /// getter setter tests
    /// </summary>
        [Fact]
        public void getID()
        {
            Post p = new Post();
            p.ID = 1;
            Assert.True(p.ID == 1);
        }


        [Fact]
        public void setID()
        {
            Post p = new Post();
            p.ID = 1;
            p.ID = 11;
            Assert.True(p.ID == 11);
        }


        /// <summary>
        /// getter-postername
        /// </summary>
        [Fact]
        public void getname()
        {
            Post p = new Post();
            p.PosterName = "Poster";
            Assert.True(p.PosterName== "Poster");
        }
        [Fact]
        public void setname()
        {
            Post p = new Post();
            p.PosterName = "Poster";
            p.PosterName = "tester";
            Assert.True(p.PosterName == "tester");
        }



        [Fact]
        public void getDes()
        {
            Post p = new Post();
            p.Description = "Posterposter";
            Assert.True(p.Description == "Posterposter");
        }


        [Fact]
        public void setDes()
        {
            Post p = new Post();
            p.Description = "Posterposter";
            p.Description = "testertester";
            Assert.True(p.Description == "testertester");
        }




        [Fact]
        public void getURL()
        {
            Post p = new Post();
            p.URL = "www.pp.com";
            Assert.True(p.URL == "www.pp.com");
        }



        [Fact]
        public void setURL()
        {
            Post p = new Post();
            p.URL = "www.pp.com";
            p.URL = "www.qq.com";
            Assert.True(p.URL == "www.qq.com");
        }

       


    }
}
