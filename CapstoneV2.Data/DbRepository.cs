using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CapstoneV2.Models.Data;
using CapstoneV2.Models.Enums;
using CapstoneV2.Models.Interfaces;

namespace CapstoneV2.Data
{
    public class DbRepository : IRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString;

        #region Helpers

        private Beer PopulateBeerFromReader(SqlDataReader dr)
        {
            Beer beer = new Beer()
            {
                BeerId = int.Parse(dr["BeerId"].ToString()),
                Name = dr["BeerName"].ToString(),
                ABV = double.Parse(dr["ABV"].ToString()),
                ReleaseDate = DateTime.Parse(dr["ReleaseDate"].ToString()),
                Description = dr["BeerDescription"].ToString(),
                IsAvailable = bool.Parse(dr["IsAvailable"].ToString()),
                IsFlagship = bool.Parse(dr["IsFlagship"].ToString()),
                ImgPath = dr["ImgPath"].ToString(),
                Style = PopulateStyleFromReader(dr)
                //Img = PopulateImageFromReader(dr)
            };
            
            if (dr["Season"] != DBNull.Value)
            {
                beer.Season = dr["Season"].ToString();
            }
            if (dr["IBU"] != DBNull.Value)
            {
                beer.IBU = int.Parse(dr["IBU"].ToString());
            }
            if (dr["UntappdRating"] != DBNull.Value)
            {
                beer.UntappdRating = double.Parse(dr["UntappdRating"].ToString());
            }

            if (dr["SeriesId"] != DBNull.Value)
            {
                beer.Series = PopulateSeriesFromReader(dr);
            }
            if (dr["CollaboratorId"] != DBNull.Value)
            {
                beer.Collaborator = PopulateCollaboratorFromReader(dr);
            }
            return beer;
        }

        private Series PopulateSeriesFromReader(SqlDataReader dr)
        {
            Series series = new Series()
            {
                SeriesId = int.Parse(dr["SeriesId"].ToString()),
                Name = dr["SeriesName"].ToString(),
                Description = dr["SeriesDescription"].ToString()
            };

            return series;
        }

        private Style PopulateStyleFromReader(SqlDataReader dr)
        {
            Style style = new Style()
            {
                StyleId = int.Parse(dr["StyleId"].ToString()),
                Name = dr["StyleName"].ToString(),
                Description = dr["StyleDescription"].ToString()
            };

            return style;
        }

        private Collaborator PopulateCollaboratorFromReader(SqlDataReader dr)
        {
            Collaborator collaborator = new Collaborator()
            {
                CollaboratorId = int.Parse(dr["CollaboratorId"].ToString()),
                Name = dr["CollaboratorName"].ToString(),
                Description = dr["CollaboratorDescription"].ToString(),
                //Img = PopulateImageFromReader(dr),
                Contact = PopulateContactFromReader(dr),
                //Images = new List<string>()
                ImgPath = dr["CollaboratorImgPath"].ToString()
            };

            return collaborator;
        }

        private BlogEntry PopulateBlogFromReader(SqlDataReader dr)
        {
            BlogEntry blog = new BlogEntry()
            {
                Body = dr["BlogBody"].ToString(),
                EntryId = int.Parse(dr["EntryId"].ToString()),
                Title = dr["BlogTitle"].ToString(),
                DatePosted = DateTime.Parse(dr["BlogPostDate"].ToString()),
                User = PopulateUserFromReader(dr),
                IsApproved = bool.Parse(dr["IsApproved"].ToString()),
                //Images = new List<Image>(),
                Tags = new List<Tag>()
            };

            //conditional items - event, beer, expiry
            if (dr["BlogExpireDate"] != DBNull.Value)
            {
                blog.DateExpire = DateTime.Parse(dr["BlogExpireDate"].ToString());
            }
            //if (dr["EventId"] != DBNull.Value)
            //{
            //    blog.Event = PopulateEventFromReader(dr);
            //}
            //if (dr["BeerId"] != DBNull.Value)
            //{
            //    blog.Beer = PopulateBeerFromReader(dr);
            //}
            //Populate Lists - images, tags
            return blog;
        }

        private User PopulateUserFromReader(SqlDataReader dr)
        {
            User user = new User()
            {
                UserId = dr["AspUserId"].ToString(),
                Id = int.Parse(dr["UserId"].ToString()),
                FirstName = dr["FirstName"].ToString(),
                LastName = dr["LastName"].ToString(),
                Username = dr["UserName"].ToString(),
                JobTitle = dr["JobTitle"].ToString(),
                AccessLevel = (AccessLevel)int.Parse(dr["AccessLevel"].ToString()),
                Contact = PopulateContactFromReader(dr), 
                //Img = PopulateImageFromReader(dr),
                Bio = dr["Bio"].ToString(),
                IsEmployee = bool.Parse(dr["IsEmployee"].ToString())
                
            };
            if (dr["UserImgPath"] != DBNull.Value)
            {
                user.ImgPath = dr["UserImgPath"].ToString();
            }
            else
            {
                user.ImgPath = "";
            }
            

            return user;
        }

        private Event PopulateEventFromReader(SqlDataReader dr)
        {
            Event brewEvent = new Event()
            {
                EventId = int.Parse(dr["EventId"].ToString()),
                Name = dr["EventName"].ToString(),
                Description = dr["EventDescription"].ToString(),
                StartDate = DateTime.Parse(dr["EventStartDate"].ToString()),
                EndDate = DateTime.Parse(dr["EventEndDate"].ToString()),
                Venue = PopulateVenueFromReader(dr),
                //Images = new List<Image>()
                ImgPath = dr["EventImgPath"].ToString()
            };

            //if (dr["EventStartTime"] != DBNull.Value)
            //{
            //    brewEvent.StartTime = DateTime.Parse(dr["EventStartTime"].ToString());
            //}
            //if (dr["EventEndTime"] != DBNull.Value)
            //{
            //    brewEvent.EndTime = DateTime.Parse(dr["EventEndTime"].ToString());
            //}
            //if (dr["EventEndDate"] != DBNull.Value)
            //{
            //    brewEvent.EndDate = DateTime.Parse(dr["EventEndDate"].ToString());
            //}

            //populate Image List
            return brewEvent;
        }

        private Venue PopulateVenueFromReader(SqlDataReader dr)
        {
            Venue venue = new Venue()
            {
                VenueId = int.Parse(dr["VenueId"].ToString()),
                Contact = PopulateContactFromReader(dr),
                //Img = PopulateImageFromReader(dr),
                Name = dr["VenueName"].ToString(),
                ImgPath = dr["VenueImgPath"].ToString()
            };
            
            return venue;
        }

        private ContactInfo PopulateContactFromReader(SqlDataReader dr)
        {
            ContactInfo contact = new ContactInfo();
            contact.ContactId = int.Parse(dr["ContactId"].ToString());
            contact.StreetAddress = dr["StreetAddress"] != DBNull.Value ? dr["StreetAddress"].ToString() : null;
            contact.City = dr["City"] != DBNull.Value ? dr["City"].ToString() : null;
            contact.Zip = dr["ZipCode"] != DBNull.Value ? dr["ZipCode"].ToString() : null;
            contact.State = dr["State"] != DBNull.Value ? dr["State"].ToString() : null;
            contact.Email = dr["Email"] != DBNull.Value ? dr["Email"].ToString() : null;
            contact.Phone = dr["Phone"] != DBNull.Value ? dr["Phone"].ToString() : null;
            
            return contact;
        }

        //private Image PopulateImageFromReader(SqlDataReader dr)
        //{
        //    Image image = new Image()
        //    {
        //        ImgId = int.Parse(dr["ImageId"].ToString()),
        //        ImgPath = dr["ImagePath"].ToString(),
        //        Caption = dr["Caption"].ToString(),
        //        Tags = new List<Tag>()
        //    };
        //    return image;
        //}

        private StaticPage PopulateStaticPageFromReader(SqlDataReader dr)
        {
            StaticPage page = new StaticPage()
            {
                PageId = int.Parse(dr["PageId"].ToString()),
                Title = dr["Title"].ToString(),
                Body = dr["Body"].ToString(),
                DateCreated = DateTime.Parse(dr["DateCreated"].ToString())
            };

            if (dr["DateUpdated"] != DBNull.Value)
                page.DateUpdated = DateTime.Parse(dr["DateUpdated"].ToString());
            else page.DateUpdated = page.DateCreated;

            return page;
        }

        private Tag PopulateTagFromReader(SqlDataReader dr)
        {
            Tag tag = new Tag()
            {
                TagId = int.Parse(dr["TagId"].ToString()),
                Name = dr["TagName"].ToString()
            };

            return tag;
        }

        private ContactForm PopulateContactFormFromReader(SqlDataReader dr)
        {
            ContactForm form = new ContactForm
            {
                ContactFormId = (int) dr["ContactFormId"],
                Name = dr["ContactFormName"].ToString(),
                Message = dr["ContactFormMessage"].ToString(),
                Email = dr["ContactFormEmail"].ToString(),
                DateSent = DateTime.Parse(dr["DateSent"].ToString()),
                IsAnswered = bool.Parse(dr["IsAnswered"].ToString())
            };

            return form;
        }

        #endregion

        #region Beers
        //TODO ALTER QUERY TO ACCOUNT FOR EXPIRY DATE
        public List<Beer> GetAllBeers()
        {
            List<Beer> beers = new List<Beer>();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT B.*, SE.SeriesDescription, SE.SeriesName, 
	                                    ST.StyleDescription, ST.StyleName,
	                                    COL.CollaboratorName, COL.CollaboratorDescription, COL.CollaboratorImgPath, C.*
                                    FROM Beers B
	                                    LEFT OUTER JOIN Series SE
	                                    ON B.SeriesId = SE.SeriesId
	                                    LEFT OUTER JOIN Styles ST
	                                    ON B.StyleId = ST.StyleId
	                                    LEFT OUTER JOIN Collaborators COL
	                                    ON B.CollaboratorId = COL.CollaboratorId
	                                    LEFT OUTER JOIN Contacts C
	                                    ON  COL.ContactId = C.ContactId";

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        beers.Add(PopulateBeerFromReader(dr));

                        //if beer has collaborator, get list of images
                    }
                }
            }


            return beers;
        }

        public Beer GetBeerById(int id)
        {
            Beer beer = new Beer();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT B.*, SE.SeriesDescription, SE.SeriesName, 
	                                    ST.StyleDescription, ST.StyleName,
	                                    COL.CollaboratorName, COL.CollaboratorDescription, COL.CollaboratorImgPath, C.*
                                    FROM Beers B
	                                    LEFT OUTER JOIN Series SE
	                                    ON B.SeriesId = SE.SeriesId
	                                    LEFT OUTER JOIN Styles ST
	                                    ON B.StyleId = ST.StyleId
	                                    LEFT OUTER JOIN Collaborators COL
	                                    ON B.CollaboratorId = COL.CollaboratorId
	                                    LEFT OUTER JOIN Contacts C
	                                    ON  COL.ContactId = C.ContactId
                                    WHERE B.BeerId = @BeerId";

                cmd.Parameters.AddWithValue("@BeerId", id);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        beer = PopulateBeerFromReader(dr);

                        //if beer has collaborator, get list of images
                    }
                }
            }

            return beer;
        }

        //have return beer so we can get beer id?
        public void AddBeer(Beer beer)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.AddNewBeer", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", beer.Name);
                cmd.Parameters.AddWithValue("@ABV", beer.ABV);
                cmd.Parameters.AddWithValue("@ReleaseDate", beer.ReleaseDate);
                cmd.Parameters.AddWithValue("@Description", beer.Description);
                cmd.Parameters.AddWithValue("@IsAvailable", beer.IsAvailable);
                cmd.Parameters.AddWithValue("@IsFlagship", beer.IsFlagship);
                cmd.Parameters.AddWithValue("@StyleId", beer.Style.StyleId);

                if (beer.IBU == null)
                    cmd.Parameters.AddWithValue("@IBU", DBNull.Value);
                else cmd.Parameters.AddWithValue("@IBU", beer.IBU);
                
                if (string.IsNullOrEmpty(beer.Season))
                    cmd.Parameters.AddWithValue("@Season", DBNull.Value);
                else cmd.Parameters.AddWithValue("@Season", beer.Season);
                
                if (beer.UntappdRating == null)
                    cmd.Parameters.AddWithValue("@UntappdRating", DBNull.Value);
                else cmd.Parameters.AddWithValue("@UntappdRating", beer.UntappdRating);

                if (beer.Series == null)
                    cmd.Parameters.AddWithValue("@SeriesId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@SeriesId", beer.Series.SeriesId);

                if (beer.Collaborator == null)
                    cmd.Parameters.AddWithValue("@CollaboratorId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@CollaboratorId", beer.Collaborator.CollaboratorId);

                if (string.IsNullOrEmpty(beer.ImgPath))
                    cmd.Parameters.AddWithValue("@ImgPath", DBNull.Value);
                else cmd.Parameters.AddWithValue("@ImgPath", beer.ImgPath);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
        public void EditBeer(Beer beer)
        {
            if(GetStyleById(beer.Style.StyleId) == null)
                beer.Style = AddStyle(beer.Style);

            if(beer.Series != null)
                if (GetSeriesById(beer.Series.SeriesId) == null)
                    beer.Series = AddSeries(beer.Series);
            
            if(beer.Collaborator != null)
                if (GetCollaboratorById(beer.Collaborator.CollaboratorId) == null)
                    beer.Collaborator = AddCollaborator(beer.Collaborator);

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.EditBeer", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BeerId", beer.BeerId);
                cmd.Parameters.AddWithValue("@BeerName", beer.Name);
                cmd.Parameters.AddWithValue("@ABV", beer.ABV);
                cmd.Parameters.AddWithValue("@ReleaseDate", beer.ReleaseDate);
                cmd.Parameters.AddWithValue("@BeerDescription", beer.Description);
                cmd.Parameters.AddWithValue("@IsAvailable", beer.IsAvailable);
                cmd.Parameters.AddWithValue("@IsFlagship", beer.IsFlagship);
                cmd.Parameters.AddWithValue("@StyleId", beer.Style.StyleId);

                if (beer.IBU == null)
                    cmd.Parameters.AddWithValue("@IBU", DBNull.Value);
                else cmd.Parameters.AddWithValue("@IBU", beer.IBU);

                if (string.IsNullOrEmpty(beer.Season))
                    cmd.Parameters.AddWithValue("@Season", DBNull.Value);
                else cmd.Parameters.AddWithValue("@Season", beer.Season);

                if (beer.UntappdRating == null)
                    cmd.Parameters.AddWithValue("@UntappdRating", DBNull.Value);
                else cmd.Parameters.AddWithValue("@UntappdRating", beer.UntappdRating);

                if (beer.Series == null)
                    cmd.Parameters.AddWithValue("@SeriesId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@SeriesId", beer.Series.SeriesId);

                if (beer.Collaborator == null)
                    cmd.Parameters.AddWithValue("@CollaboratorId", DBNull.Value);
                else cmd.Parameters.AddWithValue("@CollaboratorId", beer.Collaborator.CollaboratorId);

                if (string.IsNullOrEmpty(beer.ImgPath))
                    cmd.Parameters.AddWithValue("@ImgPath", DBNull.Value);
                else cmd.Parameters.AddWithValue("@ImgPath", beer.ImgPath);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteBeer(int id)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.DeleteBeer", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BeerId", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region Entries
        public IEnumerable<BlogEntry> GetAllBlogEntries()
        {
            List<BlogEntry> blogs = new List<BlogEntry>();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetAllBlogs", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlCommand tagCmd = new SqlCommand("dbo.GetBlogTags", cn);
                tagCmd.CommandType = CommandType.StoredProcedure;


                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        blogs.Add(PopulateBlogFromReader(dr));
                    }
                }

                foreach (var blog in blogs)
                {
                    tagCmd.Parameters.Clear();
                    tagCmd.Parameters.AddWithValue("@EntryId", blog.EntryId);
                    List<Tag> tags = new List<Tag>();
                    using (var dr = tagCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tags.Add(PopulateTagFromReader(dr));
                        }
                    }

                    blog.Tags = tags;
                }

            }
            
            return blogs.Distinct();
        }

        public BlogEntry GetBlogEntryById(int id)
        {
            BlogEntry blog = new BlogEntry();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetBlogById", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BlogId", id);

                SqlCommand tagCmd = new SqlCommand("dbo.GetBlogTags", cn);
                tagCmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        blog = PopulateBlogFromReader(dr);
                    }
                }

                tagCmd.Parameters.AddWithValue("@EntryId", blog.EntryId);
                List<Tag> tags = new List<Tag>();
                using (var dr = tagCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        tags.Add(PopulateTagFromReader(dr));
                    }
                }

                blog.Tags = tags;
            }

            return blog;
        }

        public void AddBlogEntry(BlogEntry blog)
        {
            //TODO ADD BLOG TAGS
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                //Adding Blog Entry
                SqlCommand cmd = new SqlCommand("dbo.AddBlogEntry", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", blog.User.Id);
                cmd.Parameters.AddWithValue("@BlogTitle", blog.Title);
                cmd.Parameters.AddWithValue("@BlogBody", blog.Body);
                cmd.Parameters.AddWithValue("@IsApproved", blog.IsApproved);
                cmd.Parameters.AddWithValue("@BlogPostDate", DateTime.Now);
                
                if (blog.Event == null)
                {
                    cmd.Parameters.AddWithValue("@EventId", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@EventId", blog.Event.EventId);
                }

                if (blog.Beer == null)
                {
                    cmd.Parameters.AddWithValue("@BeerId", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@BeerId", blog.Beer.BeerId);
                }

                if (blog.DateExpire == null)
                {
                    cmd.Parameters.AddWithValue("@BlogExpireDate", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@BlogExpireDate", blog.DateExpire);
                }

                cn.Open();
                cmd.ExecuteNonQuery();

                SqlCommand addTagCmd = new SqlCommand("dbo.AddTag", cn);
                addTagCmd.CommandType = CommandType.StoredProcedure;

                SqlCommand bridgeCmd = new SqlCommand("dbo.UpdateBridgeTags", cn);
                bridgeCmd.CommandType = CommandType.StoredProcedure;
                
                SqlCommand tagExistCmd = new SqlCommand("dbo.GetTagByName", cn);
                tagExistCmd.CommandType = CommandType.StoredProcedure;

                foreach (var tag in blog.Tags)
                {
                    Tag newTag = new Tag();
                    tagExistCmd.Parameters.Clear();
                    tagExistCmd.Parameters.AddWithValue("@TagName", tag.Name);
                    bridgeCmd.Parameters.Clear();
                    bridgeCmd.Parameters.AddWithValue("@BlogId", 1);
                    bool tagExists = false;
                    
                    using (var dr = tagExistCmd.ExecuteReader())
                    {
                        //if tag exists
                        if (dr.Read())
                        {
                            tagExists = true;
                            newTag = PopulateTagFromReader(dr);
                        }
                    }

                    //add tag to db
                    if (tagExists == false)
                    {
                        addTagCmd.Parameters.AddWithValue("@tagName", tag.Name);
                        using (var dr = addTagCmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                newTag = PopulateTagFromReader(dr);
                            }
                        }
                    }

                    bridgeCmd.Parameters.AddWithValue("@TagId", newTag.TagId);
                    bridgeCmd.ExecuteNonQuery();
                }
            }
        }

        public void EditBlogEntry(BlogEntry blog)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.EditBlogEntry", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EntryId", blog.EntryId);
                cmd.Parameters.AddWithValue("@UserId", blog.User.Id);
                cmd.Parameters.AddWithValue("@BlogTitle", blog.Title);
                cmd.Parameters.AddWithValue("@BlogBody", blog.Body);
                cmd.Parameters.AddWithValue("@BlogPostDate", blog.DatePosted);

                if (blog.Event == null)
                {
                    cmd.Parameters.AddWithValue("@EventId", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@EventId", blog.Event.EventId);
                }

                if (blog.Beer == null)
                {
                    cmd.Parameters.AddWithValue("@BeerId", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@BeerId", blog.Beer.BeerId);
                }

                if (blog.DateExpire == null)
                {
                    cmd.Parameters.AddWithValue("@BlogExpireDate", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@BlogExpireDate", blog.DateExpire);
                }

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteBlogEntry(int id)
        {
            //TODO REMOVE BLOG REFERENCES IN BRIDGE TABLE
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.DeleteBlogEntry", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EntryId", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region Collaborators
        public List<Collaborator> GetAllCollaborators()
        {
            List<Collaborator> collabs = new List<Collaborator>();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetAllCollaborators", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        collabs.Add(PopulateCollaboratorFromReader(dr));
                    }
                }
            }

            return collabs;
        }

        public Collaborator GetCollaboratorById(int id)
        {
            Collaborator collab = new Collaborator();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetCollaboratorById", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CollaboratorId", id);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        collab = PopulateCollaboratorFromReader(dr);
                    }
                }
            }

            return collab;
        }

        public Collaborator AddCollaborator(Collaborator collab)
        {
            Collaborator newCollab = new Collaborator();
            collab.Contact = AddContact(collab.Contact);
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.AddCollaborator", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CollaboratorName", collab.Name);
                cmd.Parameters.AddWithValue("@ContactId", collab.Contact.ContactId);
                cmd.Parameters.AddWithValue("@CollaboratorDescription", collab.Description);
                if (string.IsNullOrEmpty(collab.ImgPath))
                    cmd.Parameters.AddWithValue("@CollaboratorImgPath", DBNull.Value);
                else cmd.Parameters.AddWithValue("@CollaboratorImgPath", collab.ImgPath);

                cn.Open();
                
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        newCollab = PopulateCollaboratorFromReader(dr);
                    }
                }
            }

            return newCollab;
        }

        public void EditCollaborator(Collaborator collab)
        {
            EditContact(collab.Contact);
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.EditCollaborator", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CollaboratorId", collab.CollaboratorId);
                cmd.Parameters.AddWithValue("@CollaboratorName", collab.Name);
                cmd.Parameters.AddWithValue("@ContactId", collab.Contact.ContactId);
                cmd.Parameters.AddWithValue("@CollaboratorDescription", collab.Description);
                if (string.IsNullOrEmpty(collab.ImgPath))
                    cmd.Parameters.AddWithValue("@CollaboratorImgPath", DBNull.Value);
                else cmd.Parameters.AddWithValue("@CollaboratorImgPath", collab.ImgPath);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCollaborator(int id)
        {
            Collaborator collab = GetCollaboratorById(id);
            DeleteContact(collab.Contact.ContactId);
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.DeleteCollaborator", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CollaboratorId", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region Events

        public void DeleteContact(ContactInfo contact)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetAllEvents", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        events.Add(PopulateEventFromReader(dr));
                    }
                }
            }

            return events;
        }

        public Event GetEventById(int id)
        {
            Event e = new Event();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetEventById", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EventId", id);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        e = PopulateEventFromReader(dr);
                    }
                }
            }

            return e;
        }

        public void AddEvent(Event e)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.AddEvent", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EventName", e.Name);
                cmd.Parameters.AddWithValue("@EventDescription", e.Description);
                cmd.Parameters.AddWithValue("@VenueId", e.Venue.VenueId);
                cmd.Parameters.AddWithValue("@EventStartDate", e.StartDate);
                cmd.Parameters.AddWithValue("@EventEndDate", e.EndDate);
                cmd.Parameters.AddWithValue("@EventImgPath", DBNull.Value);

                cn.Open();
                cmd.ExecuteNonQuery();


                //if (e.StartTime == null)
                //{
                //    cmd.Parameters.AddWithValue("@EventStartTime", DBNull.Value);
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@EventStartTime", e.StartTime);
                //}
                //if (e.StartDate == null)
                //{
                //    cmd.Parameters.AddWithValue("@EventStartDate", DBNull.Value);
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@EventStartDate", e.StartDate);
                //}
                //if (e.EndTime == null)
                //{
                //    cmd.Parameters.AddWithValue("@EventEndTime", DBNull.Value);
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@EventEndTime", e.EndTime);
                //}
                //if (e.EndDate == null)
                //{
                //    cmd.Parameters.AddWithValue("@EventEndDate", DBNull.Value);
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@EventEndDate", e.EndDate);
                //}


            }
        }

        public void EditEvent(Event e)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.EditEvent", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EventId", e.EventId);
                cmd.Parameters.AddWithValue("@EventName", e.Name);
                cmd.Parameters.AddWithValue("@EventDescription", e.Description);
                cmd.Parameters.AddWithValue("@EventStartDate", e.StartDate);
                cmd.Parameters.AddWithValue("@EventEndDate", e.EndDate);
                cmd.Parameters.AddWithValue("@EventImgPath", DBNull.Value);
                //cmd.Parameters.AddWithValue("@EventStartTime", e.StartTime);
                cmd.Parameters.AddWithValue("@VenueId", e.Venue.VenueId);

                cn.Open();
                cmd.ExecuteNonQuery();

                //if (e.StartTime == null)
                //{
                //    cmd.Parameters.AddWithValue("@EventStartDate", DBNull.Value);
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@EventStartDate", e.StartDate);
                //}
                //if (e.EndTime == null)
                //{
                //    cmd.Parameters.AddWithValue("@EventEndTime", DBNull.Value);
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@EventEndTime", e.EndTime);
                //}
                //if (e.EndDate == null)
                //{
                //    cmd.Parameters.AddWithValue("@EventEndDate", DBNull.Value);
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@EventEndDate", e.EndDate);
                //}


            }
        }

        public void DeleteEvent(int id)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.DeleteEvent", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EventId", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region Series
        public List<Series> GetAllSeries()
        {
            List<Series> series = new List<Series>();
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetAllSeries", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        series.Add(PopulateSeriesFromReader(dr));
                    }
                }
            }


            return series;
        }

        public Series GetSeriesById(int id)
        {
            Series series = new Series();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetSeriesById", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SeriesId", id);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        series = PopulateSeriesFromReader(dr);
                    }
                }
            }

            return series;
        }

        public Series AddSeries(Series series)
        {
            Series newSeries = new Series();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.AddSeries", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SeriesName", series.Name);
                cmd.Parameters.AddWithValue("@SeriesDescription", series.Description);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        newSeries = PopulateSeriesFromReader(dr);
                    }
                }
                
            }

            return newSeries;
        }

        public void EditSeries(Series series)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.EditSeries", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SeriesName", series.Name);
                cmd.Parameters.AddWithValue("@SeriesDescription", series.Description);
                cmd.Parameters.AddWithValue("@SeriesId", series.SeriesId);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSeries(int id)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.   DeleteSeries", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SeriesId", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        
        #region Users
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetAllUsers", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        users.Add(PopulateUserFromReader(dr));
                    }
                }
            }
            
            return users;
        }

        public User GetUserbyId(int id)
        {
            User user = new User();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetUserById", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", id);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        user = PopulateUserFromReader(dr);
                    }
                }
            }

            return user;
        }

        public User GetUserbyId(string id)
        {
            throw new NotImplementedException();
        }


        public void AddUser(User user)
        {
            user.Contact = AddContact(user.Contact);
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.AddUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AspUserId", user.UserId);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                if (string.IsNullOrEmpty(user.JobTitle))
                {
                    cmd.Parameters.AddWithValue("@JobTitle", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@JobTitle", user.JobTitle);
                }
                
                cmd.Parameters.AddWithValue("@AccessLevel", (int)user.AccessLevel);
                cmd.Parameters.AddWithValue("@ContactId", user.Contact.ContactId);
                
                if (string.IsNullOrEmpty(user.Bio))
                {
                    cmd.Parameters.AddWithValue("@Bio", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Bio", user.Bio);
                }
                
                cmd.Parameters.AddWithValue("@IsEmployee", user.IsEmployee.ToString());

                if (string.IsNullOrEmpty(user.ImgPath))
                    cmd.Parameters.AddWithValue("@UserImgPath", DBNull.Value);
                else cmd.Parameters.AddWithValue("@UserImgPath", user.ImgPath);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

           
        }

        public void EditUser(User user)
        {
            EditContact(user.Contact);
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.EditUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", user.Id);
                cmd.Parameters.AddWithValue("@AspUserId", user.UserId);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                if (string.IsNullOrEmpty(user.JobTitle))
                {
                    cmd.Parameters.AddWithValue("@JobTitle", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@JobTitle", user.JobTitle);
                }

                cmd.Parameters.AddWithValue("@AccessLevel", (int)user.AccessLevel);
                cmd.Parameters.AddWithValue("@ContactId", user.Contact.ContactId);
                
                if (string.IsNullOrEmpty(user.Bio))
                {
                    cmd.Parameters.AddWithValue("@Bio", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Bio", user.Bio);
                }

                cmd.Parameters.AddWithValue("@IsEmployee", user.IsEmployee.ToString());

                if (string.IsNullOrEmpty(user.ImgPath))
                    cmd.Parameters.AddWithValue("@UserImgPath", DBNull.Value);
                else cmd.Parameters.AddWithValue("@UserImgPath", user.ImgPath);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteUser(int id)
        {
            User user = GetUserbyId(id);
            DeleteContact(user.Contact.ContactId);
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.DeleteUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
        public List<User> GetAllEmployees()
        {
            List<User> users = new List<User>();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetAllEmployees", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        users.Add(PopulateUserFromReader(dr));
                    }
                }
            }

            return users;
        }

        public User GetUserbyAspId(string id)
        {
            User user = new User();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetUserByAspId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AspUserId", id);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        user = PopulateUserFromReader(dr);
                    }
                }
            }

            return user;
        }

        public void AddUserRole(int userId, int roleId)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.AddUserRole", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@RoleId", roleId);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        #endregion

        #region Contactforms
        public List<ContactForm> GetAllContactForms()
        {
            List<ContactForm> forms = new List<ContactForm>();
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetAllContactForms", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        forms.Add(PopulateContactFormFromReader(dr));
                    }
                }
            }
            return forms;
        }

        public ContactForm GetContactForm(int id)
        {
            var form = new ContactForm();
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetContactFormById", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContactFormId", id);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        form = PopulateContactFormFromReader(dr);
                    }
                }
            }
            return form;
        }

        public void AddContactForm(ContactForm form)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.AddContactForm", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContactFormName", form.Name);
                cmd.Parameters.AddWithValue("@ContactFormEmail", form.Email);
                cmd.Parameters.AddWithValue("@ContactFormMessage", form.Message);
                cmd.Parameters.AddWithValue("@DateSent", form.DateSent);
                cmd.Parameters.AddWithValue("@IsAnswered", form.IsAnswered);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditContactForm(ContactForm form)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.EditContactForm", cn);
                //We only use IsAnswered and Id as params, since we never edit the content of forms
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContactFormId", form.ContactFormId);
                cmd.Parameters.AddWithValue("@IsAnswered", form.IsAnswered);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region StaticPages

        public List<StaticPage> GetAllStaticPages()
        {
            List<StaticPage> pages = new List<StaticPage>();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetAllStaticPages", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        pages.Add(PopulateStaticPageFromReader(dr));
                    }
                }

            }

            return pages;
        }

        public StaticPage GetStaticPage(int id)
        {
            StaticPage page = new StaticPage();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetStaticPageById", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        page = PopulateStaticPageFromReader(dr);
                    }
                }
            }

            return page;
        }

        public void AddStaticPage(StaticPage page)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.AddStaticPage", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", page.Title);
                cmd.Parameters.AddWithValue("@Body", page.Body);
                cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);
                cmd.Parameters.AddWithValue("@DateUpdated", DateTime.Now);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditStaticPage(StaticPage page)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.EditStaticPage", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", page.PageId);
                cmd.Parameters.AddWithValue("@Title", page.Title);
                cmd.Parameters.AddWithValue("@Body", page.Body);
                cmd.Parameters.AddWithValue("@DateCreated", page.DateCreated);
                cmd.Parameters.AddWithValue("@DateUpdated", DateTime.Now);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStaticPage(int id)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.DeleteStaticPage", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        

        #endregion
        
        #region Venues
        public List<Venue> GetAllVenues()
        {
            var venues = new List<Venue>();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetAllVenues", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        venues.Add(PopulateVenueFromReader(dr));
                    }
                }
            }


            return venues;
        }

        public Venue GetVenueById(int id)
        {
            var venue = new Venue();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetVenueById", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VenueId", id);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        venue = PopulateVenueFromReader(dr);
                    }
                }
            }

            return venue;
        }

        public Venue AddVenue(Venue venue)
        {
            venue.Contact = AddContact(venue.Contact);
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.AddVenue", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VenueName", venue.Name);
                cmd.Parameters.AddWithValue("@ContactId", venue.Contact.ContactId);

                if (!string.IsNullOrEmpty(venue.ImgPath))
                    cmd.Parameters.AddWithValue("@VenueImgPath", venue.ImgPath);
                else cmd.Parameters.AddWithValue("@VenueImgPath", DBNull.Value);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        venue = PopulateVenueFromReader(dr);
                    }
                }
            }

            return venue;
        }

        public void EditVenue(Venue venue)
        {
            EditContact(venue.Contact);
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.EditVenue", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VenueId", venue.VenueId);
                cmd.Parameters.AddWithValue("@VenueName", venue.Name);
                cmd.Parameters.AddWithValue("@ContactId", venue.Contact.ContactId);
                if (!string.IsNullOrEmpty(venue.ImgPath))
                    cmd.Parameters.AddWithValue("@VenueImgPath", venue.ImgPath);
                else cmd.Parameters.AddWithValue("@VenueImgPath", DBNull.Value);

                cn.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void DeleteVenue(int id)
        {
            Venue venue = GetVenueById(id);
            DeleteContact(venue.Contact.ContactId);
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.DeleteVenue", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VenueId", id);

                cn.Open();
                cmd.ExecuteNonQuery();

            }
        }
        #endregion
        
        #region Styles
        public List<Style> GetAllStyles()
        {
            List<Style> styles = new List<Style>();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM Styles";

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        styles.Add(PopulateStyleFromReader(dr));
                    }
                }
            }
            return styles;
        }

        public Style GetStyleById(int id)
        {
            Style style = new Style();

            using (var cn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT * FROM Styles
                                WHERE StyleId = @StyleId";

                cmd.Parameters.AddWithValue("@StyleId", id);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        style = PopulateStyleFromReader(dr);
                    }
                }
            }
            return style;
        }

        public Style AddStyle(Style style)
        {
            Style newStyle = new Style();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.AddStyle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StyleName", style.Name);
                cmd.Parameters.AddWithValue("@StyleDescription", style.Description);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        newStyle = PopulateStyleFromReader(dr);
                    }
                }
            }
            
            return newStyle;
        }

        public void EditStyle(Style style)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.EditStyle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StyleId", style.StyleId);
                cmd.Parameters.AddWithValue("@StyleName", style.Name);
                cmd.Parameters.AddWithValue("@StyleDescription", style.Description);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStyle(int id)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.DeleteStyle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StyleId", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region Images: COMMENTED OUT

        ////TODO populate img tags
        //public List<Image> GetAllImages()
        //{
        //    List<Image> images = new List<Image>();

        //    using (SqlConnection cn = new SqlConnection(_connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandText = @"SELECT * FROM Images";

        //        SqlCommand tagCmd = new SqlCommand("dbo.GetImageTags", cn);
        //        tagCmd.CommandType = CommandType.StoredProcedure;

        //        cn.Open();

        //        using (var dr = cmd.ExecuteReader())
        //        {
        //            while (dr.Read())
        //            {
        //                images.Add(PopulateImageFromReader(dr));
        //            }
        //        }

        //        foreach (var image in images)
        //        {
        //            tagCmd.Parameters.AddWithValue("@ImageId", image.ImgId);
        //            List<Tag> tags = new List<Tag>();
        //            using (var dr = tagCmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    tags.Add(PopulateTagFromReader(dr));
        //                }

        //                image.Tags = tags;
        //            }
        //        }
        //    }
        //    return images;
        //}

        //public Image GetImgById(int id)
        //{
        //    Image image = new Image();

        //    using (SqlConnection cn = new SqlConnection(_connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandText = @"SELECT * FROM Images
        //                            WHERE ImageId = @ImageId";

        //        cmd.Parameters.AddWithValue("@ImageId", id);

        //        SqlCommand tagCmd = new SqlCommand("dbo.GetImageTags", cn);
        //        tagCmd.CommandType = CommandType.StoredProcedure;
        //        tagCmd.Parameters.AddWithValue("@ImageId", image.ImgId);

        //        cn.Open();

        //        using (var dr = cmd.ExecuteReader())
        //        {
        //            while (dr.Read())
        //            {
        //                image = PopulateImageFromReader(dr);
        //            }
        //        }

        //        List<Tag> tags = new List<Tag>();
        //        using (var dr = tagCmd.ExecuteReader())
        //        {
        //            while (dr.Read())
        //            {
        //                tags.Add(PopulateTagFromReader(dr));
        //            }

        //            image.Tags = tags;
        //        }
        //    }
        //    return image;
        //}

        ////TODO ADD TAGS
        //public void AddImg(Image img)
        //{
        //    using (SqlConnection cn = new SqlConnection(_connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("dbo.AddImage", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@ImagePath", img.ImgPath);
        //        cmd.Parameters.AddWithValue("@ImageCaption", img.Caption);

        //        cn.Open();
        //        cmd.ExecuteNonQuery();

        //        SqlCommand tagCmd = new SqlCommand("dbo.AddTagsToimage", cn);
        //        tagCmd.CommandType = CommandType.StoredProcedure;

        //        SqlCommand bridgeCmd = new SqlCommand("dbo.UpdateBridgeTableImage", cn);
        //        bridgeCmd.CommandType = CommandType.StoredProcedure;

        //        SqlCommand tagExistCmd = new SqlCommand("dbo.GetTagByName", cn);

        //        foreach (var tag in img.Tags)
        //        {
        //            tagExistCmd.Parameters.AddWithValue("@TagName", tag.Name);
        //            using (var dr = tagExistCmd.ExecuteReader())
        //            {
        //                if (!dr.Read())
        //                {
        //                    tagCmd.Parameters.AddWithValue("@tagName", tag.Name);
        //                    tagCmd.ExecuteNonQuery();
        //                }
        //                else
        //                {
        //                    Tag newTag = PopulateTagFromReader(dr);
        //                    bridgeCmd.Parameters.AddWithValue("@TagId", newTag.TagId);
        //                    bridgeCmd.ExecuteNonQuery();
        //                }
        //            }

        //        }
        //    }
        //}
        
        //public void EditImg(Image img)
        //{
        //    using (SqlConnection cn = new SqlConnection(_connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("dbo.EditImage", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@ImageId", img.ImgId);
        //        cmd.Parameters.AddWithValue("@ImagePath", img.ImgPath);
        //        cmd.Parameters.AddWithValue("@ImageCaption", img.Caption);

        //        cn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}

        ////TODO DELETE REFERENCES IN BRIDGE TABLE
        //public void DeleteImg(int id)
        //{
        //    using (SqlConnection cn = new SqlConnection(_connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("dbo.DeleteImage", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@ImageId", id);

        //        cn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}

        #endregion

        #region Contact
        public List<ContactInfo> GetAllContacts()
        {
            List<ContactInfo> contacts = new List<ContactInfo>();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT * FROM Contacts";

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        contacts.Add(PopulateContactFromReader(dr));
                    }
                }
            }
            
            return contacts;
        }
        
        public ContactInfo GetContactById(int id)
        {
            ContactInfo contact = new ContactInfo();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT * FROM Contacts
                                    WHERE ContactId = @ContactId";

                cmd.Parameters.AddWithValue("@ContactId", cn);
                
                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        contact = PopulateContactFromReader(dr);
                    }
                }
            }
            return contact;
        }

        public ContactInfo AddContact(ContactInfo contact)
        {
            ContactInfo cont = new ContactInfo();

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.AddContact", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (contact.StreetAddress == null)
                {
                    cmd.Parameters.AddWithValue("@StreetAddress", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@StreetAddress", contact.StreetAddress);
                }
                if (contact.City == null)
                {
                    cmd.Parameters.AddWithValue("@City", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@City", contact.City);
                }
                if (contact.State == null)
                {
                    cmd.Parameters.AddWithValue("@State", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@State", contact.State);
                }
                if (contact.Zip == null)
                {
                    cmd.Parameters.AddWithValue("@ZipCode", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ZipCode", contact.Zip);
                }
                if (contact.Phone == null)
                {
                    cmd.Parameters.AddWithValue("@Phone", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Phone", contact.Phone);
                }
                if (contact.Email == null)
                {
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Email", contact.Email);
                }

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cont = PopulateContactFromReader(dr);
                    }
                }
            }
            return cont;
        }

        public void EditContact(ContactInfo contact)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.EditContact", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContactId", contact.ContactId);
                if (contact.StreetAddress == null)
                {
                    cmd.Parameters.AddWithValue("@StreetAddress", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@StreetAddress", contact.StreetAddress);
                }
                if (contact.City == null)
                {
                    cmd.Parameters.AddWithValue("@City", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@City", contact.City);
                }
                if (contact.State == null)
                {
                    cmd.Parameters.AddWithValue("@State", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@State", contact.State);
                }
                if (contact.Zip == null)
                {
                    cmd.Parameters.AddWithValue("@ZipCode", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ZipCode", contact.Zip);
                }
                if (contact.Phone == null)
                {
                    cmd.Parameters.AddWithValue("@Phone", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Phone", contact.Phone);
                }
                if (contact.Email == null)
                {
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Email", contact.Email);
                }

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteContact(int id)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.DeleteContact", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContactId", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region Tags

        public List<Tag> GetAllTags()
        {
            var tags = new List<Tag>();
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.GetAllTags", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        tags.Add(PopulateTagFromReader(dr));
                    }
                }
            }
            return tags;
        }

        public void AddTag(Tag tag)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.AddTag", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TagName", tag.Name);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTag(int id)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("dbo.DeleteTag", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TagId", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        #endregion
    }
}
