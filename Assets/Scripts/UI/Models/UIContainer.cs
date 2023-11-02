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

    [SerializeField]
    private Transform EnvironmnetParent;

    [SerializeField]
    private Transform PlayerParent;

    public Transform GetEnvironmnetParent()
    {
        return EnvironmnetParent;
    }
    public Transform GetPlayerParent()
    {
        return PlayerParent;
    }
}
