using UI.Interfaces;
using UnityEngine.AddressableAssets;


public class AddressablesManager
{
    public AddressablesManager()
    {
        Addressables.InitializeAsync();
    }
}
