/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.Collections.Generic;

namespace BlackFire.Unity.Business
{
    [Serializable]
    public sealed class CommandList
    {
        public List<string> Commands = new List<string>();
    }
}