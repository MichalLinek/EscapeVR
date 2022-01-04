using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public interface ICollectibleItem
    {
        //method used to change the transform of the object to FPS Controller
        void SetUpItem();

        void TriggerAction();

        event EventHandler PickUp;

        void Activate();

        void Deactivate();
    }
}
