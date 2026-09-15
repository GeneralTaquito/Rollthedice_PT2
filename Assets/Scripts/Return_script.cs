using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    void OnTriggerEnter(Collider other) // Returning Dice after falling into deadzone
    {
        if (other.CompareTag("Dice"))
        {
            other.gameObject.transform.position = new Vector3(4, 6, 0);
            other.attachedRigidbody.linearVelocity = Vector3.zero;
            Score_Keeper.Scoretotal = 0;
            Debug.Log("Dice Returned");
        }
    }
}
