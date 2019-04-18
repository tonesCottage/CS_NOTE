using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;

namespace Test.test.C_test
{
    //多条permission or的关系
    //[PrincipalPermission(SecurityAction.Demand,Role =@"Administrator")]
    public sealed class One_Instance
    {
        static One_Instance instance = null;
        static readonly object padLock = new object();
        One_Instance() { }
        //双锁定
        public static One_Instance Instance
        {
            get
            {
                if (instance==null)
                {
                    lock (padLock)
                    {
                        if (instance == null)
                        {
                            instance = new One_Instance();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
