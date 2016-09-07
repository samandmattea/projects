using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneV2.BLL;
using CapstoneV2.Data;
using CapstoneV2.Models.Data;
using CapstoneV2.Models.Enums;
using CapstoneV2.Models.Interfaces;
using NUnit.Framework;

namespace CapstoneV2.Tests
{
    [TestFixture]
    class BlogTests
    {
        private  BlogPostOperations bops = new BlogPostOperations();

        [Test]
        public void ParseTagsTest()
        {
            var ops = new BlogPostOperations();

            string body = "This is a #test of how well my #METHOD parses #Tags.";

            string tagList = "here, Are more#tags # to# TEST #now";

            var result = ops.ParseTags(body, tagList);

            List<string> expected = new List<string> {"test", "METHOD", "Tags", "here", "Are", "more", "tags", "to", "TEST", "now"};

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PendingBlogApproval()
        {
            List<BlogEntry> pendingQueue = bops.GetUnapprovedPosts();

            foreach (var blog in pendingQueue)
            {
                Assert.AreEqual(blog.IsApproved, false);
            }
        }

        [Test]
        public void ExpiredBlogsNotIncluded()
        {
            IEnumerable<BlogEntry> blogs = bops.GetUnexpiredPosts();

            foreach (var blog in blogs)
            {
                if (blog.DateExpire != null)
                {
                    Assert.IsTrue(blog.DateExpire > DateTime.Today);
                }
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        public void FilterByTag(int tag)
        {
            var blogs = bops.BlogsByTag(tag);
            
            foreach (var blog in blogs)
            {
                IEnumerable<Tag> tags = blog.Tags.Where(r=> r.TagId == tag);
                Assert.IsTrue(tags.Count() != 0);
            }
        }
    }
}
