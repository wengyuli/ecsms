using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECSMS.Channel
{
    public enum SmsStatus
    {
        等待发送=0,
        发送成功=1,
        待发状态=2,
        定时待发= 3,
        发送失败=-1
    }
}
