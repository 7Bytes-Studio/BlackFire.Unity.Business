/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;

namespace BlackFire.Unity.Business
{
    public interface IAuthorizationManager:IManager
    {
        SimpleDate ExpirationDate { get; set; }
        event EventHandler OnExpirationDate;
    }
    
    [Serializable]
    public sealed class SimpleDate
    {
        public int Year;
        public int Month;
        public int Day;
    }
}