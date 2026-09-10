using UnityEngine;

public class Dice_Script : MonoBehaviour
{
    [Header ("Config throwing")]
    bool Holding = false;
    public float throwforce = 400f;
    float MaxDistance = 3f;
    float distance;

    TempParent_Script TempParent;
    Rigidbody rb;

    Vector3 objectpos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        TempParent = TempParent_Script.Instance;
    }

    void Update()
    {
        if (Holding)
        {
            Hold();
        }

    }

    private void OnMouseDown()
    {
        if (TempParent != null)
        {
            distance = Vector3.Distance(this.transform.position, TempParent.transform.position);
            if (distance <= MaxDistance)
            {
                Holding = true;
                rb.useGravity = false;
                rb.detectCollisions = true;

                this.transform.SetParent(TempParent.transform);
            }
        }
        else
        {
            Debug.Log("Temp player??");
        }
    }

    private void OnMouseUp()
    {
        Drop();
    }
    private void OnMouseExit()
    {
        Drop();
    }

    void Hold()
    {
        distance = Vector3.Distance(this.transform.position, TempParent.transform.position);

        if (distance >= MaxDistance)
        {
            Drop();
        }

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if (Input.GetMouseButtonDown(1))
        {
            rb.AddForce(TempParent.transform.forward * throwforce);
            Drop();
        }
    }
    void Drop()
    {
        if (Holding)
        {
            Holding = false;
            objectpos = this.transform.position;
            this.transform.position = objectpos;
            this.transform.SetParent(null);
            rb.useGravity = true;
        }
    }
}