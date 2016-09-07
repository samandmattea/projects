using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CapstoneV2.Data;
using CapstoneV2.Models.Data;
using CapstoneV2.Models.Enums;
using CapstoneV2.Models.Interfaces;

namespace CapstoneV2.BLL
{
    public class BlogPostOperations
    {
        private IRepository _repo = RepositoryFactory.CreateRepository();

        public List<string> ParseTags(string body, string tagList)
        {
            var output = new List<string>();
            string[] separators = {" ", ",", ", ", "|", "#"};

            MatchCollection bodyTags = Regex.Matches(body, @"#\w+");
            foreach (Match tag in bodyTags)
            {
                output.Add(tag.Value.Substring(1));
            }

            if (!string.IsNullOrEmpty(tagList))
            {
                var listTags = tagList.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                foreach (var tag in listTags)
                {
                    output.Add(tag);
                }
            }
            
            // Ensures it wont' return duplicates
            return output.Distinct().ToList();
        }

        public List<BlogEntry> GetUnapprovedPosts()
        {
            return _repo.GetAllBlogEntries().Where(b => b.IsApproved == false).ToList();
        }

        public IEnumerable<BlogEntry> GetUnexpiredPosts()
        {
            return _repo.GetAllBlogEntries().OrderBy(b => b.DatePosted)
                .Where(b => !b.DateExpire.HasValue || b.DateExpire.Value > DateTime.Today);
        }

        public IEnumerable<BlogEntry> BlogsByTag(int? id)
        {
            return GetUnexpiredPosts().Where(b => b.Tags.Any(t => t.TagId == id));
        }

        public IEnumerable<BlogEntry> GetBlogArchives(int? id)
        {
            return _repo.GetAllBlogEntries().Where(b => b.IsApproved);
        }
    }
}
