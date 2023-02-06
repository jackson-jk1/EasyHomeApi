using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
        public void readNotification(int userId);
       
        void deleteNotification(int notificationId);

        public List<Notification> getNotifications(int userId);
        bool verifyNotification(int id);
    }
}
