using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Interfaces;
using UnityEngine;

public class UIContainer : MonoBehaviour, IUIContainer, IUIContainerObjectsParents
{
    public Transform PopupContainer { get; }

    public GameObject ScreenBack { get; }

    [field: SerializeField]
    public Transform EnvironmnetParent { get; private set; }

    [field: SerializeField]
    public Transform PlayerParent { get; private set; }

}
