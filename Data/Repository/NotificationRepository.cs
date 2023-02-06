using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace Data.Repository
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {
        }
        
    
        public string queryReadNotification = "update Notification set `Read` = 1 where UserId = ";
        public string queryDeleteNotification = "delete from Notification where Id = ";
        string queryVerifyNotification = "select * from Notification where UserId = @UserId and `Read` = false";


        public List<Notification> getNotifications(int userId)
        {
            var user = _mySqlContext.Set<UserModel>().Include(u => u.Notification).Where(u => u.Id == userId).FirstOrDefault();
            if (user != null)
            {

                return user.Notification.ToList();
            }
            return new List<Notification>();
        }

        public void readNotification(int userId)
        {
                queryReadNotification = queryReadNotification + $"{userId}";
                _mySqlContext.Database.ExecuteSqlRaw(queryReadNotification);
                _mySqlContext.SaveChanges();
        }

        public void deleteNotification(int notificationId)
        {
             queryDeleteNotification = queryDeleteNotification + $"{notificationId}";
            _mySqlContext.Database.ExecuteSqlRaw(queryDeleteNotification);
            _mySqlContext.SaveChanges();
        }

        public bool verifyNotification(int userId)
        {
           
            var result = _mySqlContext.Set<Notification>().FromSqlRaw(queryVerifyNotification, new MySqlParameter("@UserId", userId)).SingleOrDefault();
            return result == default ? false : true;
        }
    }
}
