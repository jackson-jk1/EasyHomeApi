using Domain.Interfaces;
using Domain.Request.Auth;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Helpers;
using Domain.ViewModels.Request;
using Service.Services;
using Microsoft.AspNetCore.Http;

namespace Application.Controllers
{
    [Authorize]
    public class NotificationController : ControllerBase
    {
        
        private readonly INotificationService _notificationService;


        public NotificationController(INotificationService notificationService, IlogService logService) : base(logService , "NotificationController")
        {
            _notificationService = notificationService;
        }
        [HttpPost("v1/notification/sendInvitation/{id}")]
        public async Task<IActionResult> sendInvitation(int id)
        {
            _stopwatch.Start();
            var data = await _notificationService.sendInvitation(HttpContext, id);
            return Json(new { data = data.Data });

        }


        [HttpPost("v1/notification/recuseInvitation/{id}/{notId}")]
        public async Task<IActionResult> recuseInvitation(int id, int notId)
        {
            _stopwatch.Start();
            var data = await _notificationService.recuseInvitation(HttpContext, id, notId);
            return Json(new { data = data.Data });

        }

        [HttpGet("v1/notification/verifyNotification/")]
        public async Task<IActionResult> verifyNotification()
        {
            _stopwatch.Start();

            var data = await _notificationService.verifyNotification(HttpContext);

            return Json(new { data = data.Data });

        }

        [HttpGet("v1/notification/listNotification")]
        public async Task<IActionResult> listNotification()
        {
            _stopwatch.Start();
            var data = await _notificationService.listNotifications(HttpContext);
            return Json(new { data = data.Data });

        }

        [HttpPut("v1/notification/addNotification/")]
        public async Task<IActionResult> addNotification([FromBody] NotificationRequest not)
        {
            _stopwatch.Start();
            var data = await _notificationService.addNotification(HttpContext, not);
            return Json(new { data = data.Data });

        }


     
        [HttpPut("v1/notification/readNotification/")]
        public void readNotification()
        {
            _stopwatch.Start();
            _notificationService.readNotification(HttpContext);

        }

        
        [HttpDelete("v1/notification/removeNotification/")]
        public void removeNotification(int id)
        {
            _stopwatch.Start();
            _notificationService.deleteNotification(HttpContext,id);
        }


    }
}
