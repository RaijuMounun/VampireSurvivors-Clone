using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int Speed { get; set; }

    float moveHorizontal;
    float moveVertical;
    Vector3 movement;


    private void Awake()
    {
        Speed = PlayerStats.Instance.Speed;
    }

    void Update()
    {
        GetAxises();
        SetMovement();
        Move();

        print(Speed);
    }

    void GetAxises()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
    }

    void SetMovement()
    {
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
    }

    void Move()
    {
        transform.position += movement * Speed * Time.deltaTime;
    }
}
