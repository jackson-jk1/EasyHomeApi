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
        
    
        private string queryReadNotification = "update Notification set `Read` = 1 where UserId = ";
        private string queryDeleteNotification = "delete from Notification where Id = ";
        private string queryVerifyNotification = "select * from Notification where UserId = @UserId and `Read` = false LIMIT 1";
        private string queryDuplicateNotification = "delete from Notification where UserId = {0} and ContatandoId = {1} and Status = {2}";


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

        public void deleteDuplicateNotification(int userId, int contatandoId)
        {
            _mySqlContext.Database.ExecuteSqlRaw(queryDuplicateNotification, contatandoId, userId,0);
            _mySqlContext.SaveChanges();

        }

        public bool verifyNotification(int userId)
        {
           
            var result = _mySqlContext.Set<Notification>().FromSqlRaw(queryVerifyNotification, new MySqlParameter("@UserId", userId)).SingleOrDefault();
            return result == default ? false : true;
        }
    }
}
