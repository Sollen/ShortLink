using System;
using System.Collections.Generic;
using ShortLink.Helpers.Abstract;
using ShortLink.Models;

namespace ShortLink.Helpers
{
    public class EntityHelper
    {
        private IRepository _repository;

        public EntityHelper(IRepository repository)
        {
            _repository = repository;
        }

        public User GetUser(string login)
        {            
            
            return _repository.GetUser(login) ?? throw new UserNotFoundExcception(login);
        }

        public List<Link> GetUserLinks(string login)
        {            
            return _repository.GetUserLinks(login) ?? throw new LinkByUserNotFoundExcception(login);
        }

        public Link GetLink(string shortUri)
        {            
            return _repository.GetLink(shortUri) ?? throw new LinkByShortUriNotFoundExcception(shortUri);
        }

        public class LinkByShortUriNotFoundExcception : Exception
        {
            public LinkByShortUriNotFoundExcception(string shortUri):base($"link {shortUri} not found")
            {
            }
        }
        public class LinkByUserNotFoundExcception : Exception
        {
            public LinkByUserNotFoundExcception(string login) : base($"links for User: {login} not found")
            {
            }
        }
        public class UserNotFoundExcception : Exception
        {
            public UserNotFoundExcception(string login) : base($"User: {login} not found")
            {
            }
        }
    }
}


