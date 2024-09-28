using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook_LLD.Models.MediatorPatternInterfaces
{
    public interface IMediator //system is mediator
    {
        System GetSystemInstance();
        void NotifyAboutPost(User reciever, Post post);
        void NotifyAboutCommentOnPost(Post post, Comment comment); //commenter is comment author, post author is in post
        void NotifyAboutRequestAccept(Request request); //sender and reciever both info is in request
        void NotifyAboutIncomingRequest(Request request); //sender and reciever both info is in request
        void NotifyAboutPostLike(User whoLiked, Post post);
        void AddPostInFollowersFeed(Post post);
    }
}
