﻿using SendGrid.Helpers.Mail;
using System.Net;
using Domain.Models;
using System.Net.Mail;
using SendGrid;

namespace Service.Helpers
{
    public abstract class SendGridHelper
    {
        public static async void Send(UserModel user, string subject)
        {
            var apiKey = Environment.GetEnvironmentVariable("SendGridKey");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("easyhometcc2022@gmail.com", "EasyHome");

            var to = new EmailAddress(user.Email, user.Name);
            var plainTextContent = "EasyHome";
            var htmlContent = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">\r\n" +
                "<html data-editor-version=\"2\" class=\"sg-campaigns\" xmlns=\"http://www.w3.org/1999/xhtml\">\r\n    <head>\r\n" +
                "      <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\r\n" +
                "      <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1\">\r\n" +
                "      <!--[if !mso]><!-->\r\n      <meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\">\r\n" +
                "      <!--<![endif]-->\r\n      <!--[if (gte mso 9)|(IE)]>\r\n      <xml>\r\n        <o:OfficeDocumentSettings>\r\n " +
                "         <o:AllowPNG/>\r\n          <o:PixelsPerInch>96</o:PixelsPerInch>\r\n        </o:OfficeDocumentSettings>\r\n" +
                "      </xml>\r\n      <![endif]-->\r\n      <!--[if (gte mso 9)|(IE)]>\r\n  <style type=\"text/css\">\r\n" +
                "    body {width: 600px;margin: 0 auto;}\r\n    table {border-collapse: collapse;}\r\n" +
                "    table, td {mso-table-lspace: 0pt;mso-table-rspace: 0pt;}\r\n" +
                "    img {-ms-interpolation-mode: bicubic;}\r\n  </style>\r\n<![endif]-->\r\n" +
                "      <style type=\"text/css\">\r\n    body, p, div {\r\n" +
                "      font-family: arial,helvetica,sans-serif;\r\n" +
                "      font-size: 14px;\r\n    }\r\n    body {\r\n " +
                "     color: #000000;\r\n    }\r\n    body a {\r\n" +
                "      color: #1188E6;\r\n      text-decoration: none;\r\n " +
                "   }\r\n    p { margin: 0; padding: 0; }\r\n " +
                "   table.wrapper {\r\n      width:100% !important;\r\n  " +
                "    table-layout: fixed;\r\n      -webkit-font-smoothing: antialiased;\r\n" +
                "      -webkit-text-size-adjust: 100%;\r\n      -moz-text-size-adjust: 100%;\r\n " +
                "     -ms-text-size-adjust: 100%;\r\n    }\r\n    img.max-width {\r\n      max-width: 100% !important;\r\n" +
                "    }\r\n    .column.of-2 {\r\n      width: 50%;\r\n    }\r\n    .column.of-3 {\r\n      width: 33.333%;\r\n" +
                "    }\r\n    .column.of-4 {\r\n      width: 25%;\r\n    }\r\n    ul ul ul ul  {\r\n" +
                "      list-style-type: disc !important;\r\n    }\r\n    ol ol {\r\n" +
                "      list-style-type: lower-roman !important;\r\n    }\r\n    ol ol ol {\r\n" +
                "      list-style-type: lower-latin !important;\r\n    }\r\n    ol ol ol ol {\r\n " +
                "     list-style-type: decimal !important;\r\n    }\r\n    @media screen and (max-width:480px) {\r\n" +
                "      .preheader .rightColumnContent,\r\n      .footer .rightColumnContent {\r\n " +
                "       text-align: left !important;\r\n      }\r\n      .preheader .rightColumnContent div,\r\n " +
                "     .preheader .rightColumnContent span,\r\n      .footer .rightColumnContent div,\r\n " +
                "     .footer .rightColumnContent span {\r\n        text-align: left !important;\r\n   " +
                "   }\r\n      .preheader .rightColumnContent,\r\n      .preheader .leftColumnContent {\r\n " +
                "       font-size: 80% !important;\r\n        padding: 5px 0;\r\n      }\r\n " +
                "     table.wrapper-mobile {\r\n        width: 100% !important;\r\n      " +
                "  table-layout: fixed;\r\n      }\r\n      img.max-width {\r\n     " +
                "   height: auto !important;\r\n        max-width: 100% !important;\r\n  " +
                "    }\r\n      a.bulletproof-button {\r\n        display: block !important;\r\n " +
                "       width: auto !important;\r\n        font-size: 80%;\r\n        padding-left: 0 !important;\r\n " +
                "       padding-right: 0 !important;\r\n      }\r\n      .columns {\r\n  " +
                "      width: 100% !important;\r\n      }\r\n      .column {\r\n      " +
                "  display: block !important;\r\n        width: 100% !important;\r\n    " +
                "    padding-left: 0 !important;\r\n        padding-right: 0 !important;\r\n  " +
                "      margin-left: 0 !important;\r\n        margin-right: 0 !important;\r\n " +
                "     }\r\n      .social-icon-column {\r\n        display: inline-block !important;\r\n " +
                "     }\r\n    }\r\n  </style>\r\n    <style>\r\n      @media screen and (max-width:480px)" +
                " {\r\n        table\\0 {\r\n          width: 480px !important;\r\n          }\r\n" +
                "      }\r\n    </style>\r\n      <!--user entered Head Start--><!--End Head user entered-->\r\n " +
                "   </head>\r\n    <body>\r\n  " +
                "  <center class=\"wrapper\" data-link-color=\"#1188E6\" data-body-style=\"font-size:14px; font-family:arial,helvetica,sans-serif; color:#000000; background-color:#FFFFFF;\">\r\n    " +
                " <div class=\"webkit\">\r\n          <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\" class=\"wrapper\" bgcolor=\"#FFFFFF\">\r\n " +
                " <tr>\r\n              <td valign=\"top\" bgcolor=\"#FFFFFF\" width=\"100%\">\r\n" +
                " <table width=\"100%\" role=\"content-container\" class=\"outer\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">\r\n" +
                "<tr>\r\n " +
                "<td width=\"100%\">\r\n " +
                "<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">\r\n" +
                "<tr>\r\n" +
                " <td>\r\n" +
                "  <!--[if mso]>\r\n    " +
                "<center>\r\n   " +
                " <table><tr><td width=\"600\">\r\n  <![endif]-->\r\n" +
                " <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:100%; max-width:600px;\" align=\"center\">\r\n" +
                "<tr>\r\n" +
                " <td role=\"modules-container\" style=\"padding:0px 0px 0px 0px; color:#000000; text-align:left;\" bgcolor=\"#FFFFFF\" width=\"100%\" align=\"left\"><table class=\"module preheader preheader-hide\" role=\"module\" data-type=\"preheader\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"display: none !important; mso-hide: all; visibility: hidden; opacity: 0; color: transparent; height: 0; width: 0;\">\r\n" +
                "<tr>\r\n      <td role=\"module-content\">\r\n        <p></p>\r\n      </td>\r\n    </tr>\r\n  </table><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" width=\"100%\" role=\"module\" data-type=\"columns\" style=\"padding:0px 0px 0px 0px;\" bgcolor=\"#FFFFFF\" data-distribution=\"1,1\">\r\n" +
                "<tbody>\r\n" +
                "<tr role=\"module-content\">\r\n" +
                "<td height=\"100%\" valign=\"top\"><table width=\"290\" style=\"width:290px; border-spacing:0; border-collapse:collapse; margin:0px 10px 0px 0px;\" cellpadding=\"0\" cellspacing=\"0\" align=\"left\" border=\"0\" bgcolor=\"\" class=\"column column-0\">\r\n" +
                "<tbody>\r\n <tr>\r\n " +
                "<td style=\"padding:0px;margin:0px;border-spacing:0;\"><table class=\"wrapper\" role=\"module\" data-type=\"image\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"table-layout: fixed;\" data-muid=\"57nhHFvxuDpTNhDDUoQb3c\">\r\n    <tbody>\r\n      <tr>\r\n        <td style=\"font-size:6px; line-height:10px; padding:0px 0px 0px 0px;\" valign=\"top\" align=\"center\">\r\n" +
                "<img class=\"max-width\" border=\"0\" style=\"display:block; color:#000000; text-decoration:none; font-family:Helvetica, arial, sans-serif; font-size:16px; max-width:100% !important; width:100%; height:auto !important;\" width=\"290\" alt=\"\" data-proportionally-constrained=\"true\" data-responsive=\"true\" src=\"http://cdn.mcauto-images-production.sendgrid.net/f5edb73b572b6f8e/af082b26-6992-4c38-881a-b952d1917e9f/472x491.png\">\r\n" +
                " </td>\r\n      </tr>\r\n    </tbody>\r\n  </table></td>\r\n " +
                " </tr>\r\n" +
                " </tbody>\r\n </table><table width=\"290\" style=\"width:290px; border-spacing:0; border-collapse:collapse; margin:0px 0px 0px 10px;\" cellpadding=\"0\" cellspacing=\"0\" align=\"left\" border=\"0\" bgcolor=\"\" class=\"column column-1\">\r\n " +
                "<tbody>\r\n <tr>\r\n <td style=\"padding:0px;margin:0px;border-spacing:0;\"><table class=\"module\" role=\"module\" data-type=\"text\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"table-layout: fixed;\" data-muid=\"kEQh6ir2oTMLqeqGmuhxKJ\" data-mc-module-version=\"2019-10-22\">\r\n" +
                " <tbody>\r\n <tr>\r\n <td style=\"padding:18px 0px 18px 0px; line-height:40px; text-align:inherit;\" height=\"100%\" valign=\"top\" bgcolor=\"\" role=\"module-content\"><div><h1 style=\"text-align: inherit\">Recuperação de senha&nbsp;</h1>\r\n<div style=\"font-family: inherit; text-align: inherit\">" +
                "Sua nova senha é :&nbsp;" + " " + subject +
                "</div><div></div></div></td>\r\n" +
                " </tr>\r\n    </tbody>\r\n  </table></td>\r\n        </tr>\r\n      </tbody>\r\n    </table></td>\r\n      </tr>\r\n    </tbody>\r\n  </table></td>\r\n" +
                " </tr>\r\n </table>\r\n  <!--[if mso]>\r\n   </td>\r\n</tr>\r\n </table>\r\n</center>\r\n <![endif]-->\r\n </td>\r\n </tr>\r\n </table>\r\n  </td>\r\n</tr>\r\n  </table>\r\n </td>\r\n  </tr>\r\n </table>\r\n </div>\r\n </center>\r\n </body>\r\n  </html>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response.IsSuccessStatusCode ? "Email queued successfully!" : "Something went wrong!");
        }
    }
}
