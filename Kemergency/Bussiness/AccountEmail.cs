using Kemergency.Data;
using Kemergency.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Bussiness
{
    public class AccountEmail
    {
        private ApplicationDbContext _context;

        public AccountEmail(ApplicationDbContext context)
        {
            _context = context;
        }

        public AccountEmail()
        {
        }

        public List<Email> GetAllEmailSettings()
        {
            var email = _context.Emails.ToList();
            return email;
        }
        public Email GetEmailSettings()
        {
            var email = _context.Emails.FirstOrDefault();
            return email;
        }
        public Email GetMyEmailSettings()
        {
            var email = _context.Emails.SingleOrDefault();
            return email;
        }
        public Email GetEmailSettingByID(long id)
        {
            var email = _context.Emails.Where(i => i.ID == id).SingleOrDefault();
            return email;
        }

        public bool CreateEmailSetting(Email email)
        {
            try
            {
                email.CreatedOn = DateTime.Now;
                _context.Emails.Add(email);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateEmailSetting(Email email)
        {
            try
            {
                email.CreatedOn = DateTime.Now;
                _context.Entry(email).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeleteEmailSetting(long id)
        {
            try
            {
                Email email = GetEmailSettingByID(id);
                _context.Emails.Remove(email);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
