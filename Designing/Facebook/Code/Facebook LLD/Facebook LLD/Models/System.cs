using Facebook_LLD.Models.MediatorPatternInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facebook_LLD.Models
{
    public class System : IMediator  //use dependency to be accessed in application
    {
        private System systeminstance;
        private System() //Singleton
        {
            
        }

        public System GetSystemInstance()
        {
            if(systeminstance == null)
            {
                systeminstance = new System();
            }

            return systeminstance;
        }



        public void NotifyAboutCommentOnPost(Post post, Comment comment)
        {
            post.Author.Notifications.Add(new Notification
            {
                text = $"You got a comment on your post {comment.Post.Text} from {comment.Author}"
            });
        }

        public void NotifyAboutPost(User reciever, Post post)
        {
            reciever.Notifications.Add(new Notification
            {
                text = $"Your friend {post.Author} made a post"
            });
        }

        public void NotifyAboutRequestAccept(Request request)
        {
            request.Sender.Notifications.Add(new Notification
            {
                Date = DateTime.Now,
                text = $"You are now friend with {request.Receiver}"
            });
        }

        public void NotifyAboutIncomingRequest(Request request)
        {
            request.Receiver.Notifications.Add(new Notification
            {
                Date = DateTime.Now,
                text = $"You got a connection request from {request.Sender}"
            });
        }

        public void AddPostInFollowersFeed(Post post) 
        {
            foreach(var follower in post.Author.Followers)
            {
                follower.NewsFeed.Add(post);
                NotifyAboutPost(follower, post);
            }
        }

        public void NotifyAboutPostLike(User whoLiked, Post post)
        {
            post.Author.Notifications.Add(new Notification
            {
                Date = DateTime.Now,
                text = $"{whoLiked.GetProfile().Name} liked your post"
            });
        }
    }
}
