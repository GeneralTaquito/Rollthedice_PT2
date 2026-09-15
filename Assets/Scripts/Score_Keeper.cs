using TMPro;
using UnityEngine;

public class Score_Keeper : MonoBehaviour
{
    public Dice_Script dice;
    Vector3 diceVelocity;
    public TextMeshProUGUI ScoreNumber;
    public static int Scoretotal = 00;
    void Start()
    {
        Scoretotal = 0;
        UpdateScore();
    }

    public void UpdateScore()
    {
        //score stuff
        if (ScoreNumber != null)
        {
            ScoreNumber.text = "Score:" + Scoretotal.ToString();
        }
    }
    void FixedUpdate()
    {
        if (dice != null)
        {
            diceVelocity = dice.diceVelocity;
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f && dice.ScoredDice == false) //checking if dice stopped moving
        {
            switch (col.gameObject.name) //applying the number on the corresponding side
            {
                case "Side #1": //6
                    Scoretotal *= 6;
                    UpdateScore();
                    Debug.Log("Landed on 6");
                    dice.ScoredDice = true;
                    break;
                case "Side #2": //5
                    Scoretotal *= 5;
                    UpdateScore();
                    Debug.Log("Landed on 5");
                    dice.ScoredDice = true;
                    break;
                case "Side #3": //4
                    Scoretotal *= 4;
                    UpdateScore();
                    Debug.Log("Landed on 4");
                    dice.ScoredDice = true;
                    break;
                case "Side #4": //3
                    Scoretotal *= 3;
                    UpdateScore();
                    Debug.Log("Landed on 3");
                    dice.ScoredDice = true;
                    break;
                case "Side #5": //2
                    Scoretotal *= 2;
                    UpdateScore();
                    Debug.Log("Landed on 2");
                    dice.ScoredDice = true;
                    break;
                case "Side #6": //1
                    Scoretotal *= 1;
                    UpdateScore();
                    Debug.Log("Landed on 1");
                    dice.ScoredDice = true;
                    break;
            }
        }
    }
}
