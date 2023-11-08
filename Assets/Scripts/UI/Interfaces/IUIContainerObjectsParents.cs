using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UI.Interfaces
{
    public interface IUIContainerObjectsParents
    {
        Transform EnvironmnetParent { get;}

        Transform PlayerParent { get;}
    }
}
