using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressablesManager
{
    /*
    метод вызывается один раз в начале программы,
    стоит ли его делать статик и вызывать в инсталлере
    или же создать класс принимающий интерфейс и в нем вызвать метод
    */
   public static void InitAddressables()
    {
        Addressables.InitializeAsync();
    }
}
