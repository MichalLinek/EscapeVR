using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class LockMechanismAbstract : MonoBehaviour
    {
        public abstract event EventHandler LockCracked;
        public abstract void CrackLock();
    }
}
