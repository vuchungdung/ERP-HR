﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.EmailSender
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
