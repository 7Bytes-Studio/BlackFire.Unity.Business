/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using BlackFire.Unity.Business;

namespace BlackFire.Unity
{
    public sealed partial class App
    {
        private static IAuthorizationManager s_Authorization = null;

        public static IAuthorizationManager Authorization
        {
            get { return s_Authorization = (s_Authorization ?? GetManager<IAuthorizationManager>()); }
        }

    }
}