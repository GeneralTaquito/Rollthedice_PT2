using UnityEngine;

public class Hole2_Script : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dice"))
        {
            Score_Keeper.Scoretotal += 150;
        }
    }
}
