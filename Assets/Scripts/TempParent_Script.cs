using UnityEngine;

public class TempParent_Script : MonoBehaviour
{
    public static TempParent_Script Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
