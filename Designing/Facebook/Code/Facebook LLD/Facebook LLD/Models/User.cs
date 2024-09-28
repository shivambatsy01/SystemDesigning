using Facebook_LLD.Models.MediatorPatternInterfaces;
using Facebook_LLD.Models.ObserverPatternInterfaces;
using FacebookSystem = Facebook_LLD.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook_LLD.Models
{
    public class User 
    {
        private IMediator systemInstance;
        private Profile Profile;
        private bool isLoggedIn = false;
        private List<User> Friends;
        private List<Post> Posts;
        //if we want to go with centralised approach,
        //all these can be contained inside syatem using complex data structure to hold and manage


        //public as these should be accessed by system
        public List<Notification> Notifications;
        public List<User> Followers;
        public List<Post> NewsFeed;



        public User()
        {
            Friends = new List<User>();
            Posts = new List<Post>();
            Notifications = new List<Notification>();   
    
        }

        public Profile GetProfile()
        {
            return Profile; //return in other model to hide password
        }

        public bool Login(string username, string password)
        {
            if(Profile.Account.Password == password)
            {
                isLoggedIn = true;
                return true;
            }
            else return false;
        }

        public bool Logout(string username)
        {
            isLoggedIn = false; 
            return true;
        }

        public void CheckoutProfile(User user)
        {
            user.GetProfile();
        }

        public void CreatePost(string text)
        {
            Post post = new Post
            {
                Text = text,
                Author = this,
                Date = DateTime.Now,
            };

            Posts.Add(post);
            systemInstance.AddPostInFollowersFeed(post); //same method will take care of notifications
        }

        public void LikePost(Post post)
        {
            post.LikesCount++;
            systemInstance.NotifyAboutPostLike(this, post);
        }

        public void CommentOnPost(Post post, string commentText)
        {
            var comment = new Comment
            {
                Text = commentText,
                Author = this,
                Post = post
            };
            post.Comments.Add(comment);

            systemInstance.NotifyAboutCommentOnPost(post, comment);
        }

        public void SendRequest(User user)
        {
            var request = new Request
            {
                Date = DateTime.Now,
                Sender = this,
                Receiver = user
            };

            systemInstance.NotifyAboutIncomingRequest(request);
        }

        public void AcceptRequest(Request request)
        {
            Friends.Add(request.Sender);
            Followers.Add(request.Sender);
            systemInstance.NotifyAboutRequestAccept(request);
        }

    }
}
