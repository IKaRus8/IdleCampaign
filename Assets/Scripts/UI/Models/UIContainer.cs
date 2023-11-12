using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Interfaces;
using UnityEngine;

public class UIContainer : MonoBehaviour, IUIContainer, IUIContainerObjectsParents, IUIPrefabs
{
    public Transform PopupContainer { get; }

    public GameObject ScreenBack { get; }

    [field: SerializeField]
    public Transform PlayerParent { get; private set; }
    
    [field: SerializeField]
    public Transform EnemyContainer { get; private set; }

    public GameObject EnemyPrefab { get; set; }
}
