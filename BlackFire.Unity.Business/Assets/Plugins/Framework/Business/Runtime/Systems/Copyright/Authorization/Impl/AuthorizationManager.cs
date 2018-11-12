/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using UnityEngine;

namespace BlackFire.Unity.Business
{
    public sealed class AuthorizationManager : ManagerBase, IAuthorizationManager
    {
        [SerializeField] private SimpleDate m_ExpirationDate;

        public SimpleDate ExpirationDate
        {
            get { return m_ExpirationDate; }
            set { m_ExpirationDate = value; }
        }


        private DateTime? m_LocalDate;


        public event EventHandler OnExpirationDate;
        
        
        protected override void OnStart()
        {
            base.OnStart();
            CheckExpirationDate();
        }


        private void CheckExpirationDate()
        {
            Utility.Date.AcquireNetDateTime(
                netDate =>
                {
                    var s = netDate.Split(',');
                    var gmt = string.Format("{0},{1}",s[s.Length-2],s[s.Length-1]);
                    m_LocalDate = Utility.Date.GMT2Local(gmt);
                    Debug.Log( m_LocalDate );

                    if (CheckExpirationDateCondition())
                    {
                        Log.Info("过期了。");
                        if (null!=OnExpirationDate)
                        {
                            OnExpirationDate.Invoke(this,null);
                        }
                    }
                },
                () =>
                {
                    Log.Info("网络错误。");
                    m_LocalDate = DateTime.Now;
                    if (CheckExpirationDateCondition())
                    {
                        Log.Info("过期了。");
                        if (null!=OnExpirationDate)
                        {
                            OnExpirationDate.Invoke(this,null);
                        }
                    }
                });
        }


        private bool CheckExpirationDateCondition()
        {
            var fixedDate = new DateTime(m_ExpirationDate.Year,m_ExpirationDate.Month,m_ExpirationDate.Day);

            return m_LocalDate>=fixedDate;
        }

    }


    

}