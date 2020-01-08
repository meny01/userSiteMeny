using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserSite.Data;
using UserSite.Models;

namespace UserSite.Services
{
    public class UsersService : IUsersService
    {
        private readonly UsersDbContext _context;
        public UsersService(UsersDbContext context)
        {
            _context = context;
        }
        public List<UsersViewModel> GetUsers()
        {
            var users = _context.Users.Select(x => new UsersViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Mail = x.EmailAddress,
                Birthday = x.Birthday,
                PhoneNumber = x.PhoneNumber,
                Gender = x.Gender

            }).ToList();
            return users;
        }
        public UsersViewModel GetForEdit(string id)
        {
            return _context.Users.Where(x => x.Id == id)
                .Select(x => new UsersViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Mail = x.EmailAddress,
                    Birthday = x.Birthday,
                    PhoneNumber = x.PhoneNumber,
                    Gender = x.Gender

                }).FirstOrDefault();
        }
        private void AddUser(UsersViewModel model)
        {
            Users user = new Users {
                Id = model.Id,
                Name = model.Name,
                EmailAddress = model.Mail,
                Birthday = model.Birthday,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender

            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        private void EditUser(UsersViewModel model)
        {

            Users user = _context.Users.First(x => x.Id == model.Id);
            user.Name = model.Name;
            user.EmailAddress = model.Mail;
            user.Birthday = model.Birthday;
            user.PhoneNumber = model.PhoneNumber;
            user.Gender = model.Gender;

            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public void DeleteUser(string id)
        {
            var user = _context.Users.First(x => x.Id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public void Update(UsersViewModel model)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == model.Id);
            if(user == null)
            {
                AddUser(model);
            }
            else
            {
                EditUser(model);
            }
        }
    }
    public interface IUsersService
    {
        List<UsersViewModel> GetUsers();
        UsersViewModel GetForEdit(string id);
        void Update(UsersViewModel model);
        void DeleteUser(string id);
    }
}
