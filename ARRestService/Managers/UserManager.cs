using ARRestService.Context;
using ARRestService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ARRestService.Managers
{
    public class UserManager
    {
        private readonly ARContext _context;

        public UserManager(ARContext context)
        {
            _context = context;
        }
        public UserManager()
        {

        }

        //GETBYUserId
        public Users GetByUserId(string userId)
        {
            return _context.Users.Find(userId);
        }

        //GETBYEmail
        public Users GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.email == email);
        }

        //ADD
        public IEnumerable<Users> Add(Users users)
        {
            _context.Users.Add(users);
            _context.SaveChanges();

            return new List<Users>();
        }

        //GET
        public IEnumerable<Users> GetAll()
        {
            IEnumerable<Users> users = from user in _context.Users
                                             select user;

            return users;

        }

        //DELETE


        public Users Delete(string userId)
        {
            Users userIdToBeDeleted = GetByUserId(userId);
            _context.Users.Remove(userIdToBeDeleted);
            _context.SaveChanges();
            return userIdToBeDeleted;
        }

        //UPDATE
        public Users Update(string userId, Users updates)
        {
            Users usersToBeUpdated = GetByUserId(userId);
            usersToBeUpdated.firstName = updates.firstName;
            usersToBeUpdated.lastName = updates.lastName;
            usersToBeUpdated.country = updates.country;
            usersToBeUpdated.email = updates.email;

            _context.SaveChanges();

            return usersToBeUpdated;
        }


    }

}
