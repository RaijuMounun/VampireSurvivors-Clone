using UnityEngine;

public class PlayerMovement : PersistentSingleton<PlayerMovement>
{
    public int Speed { get; set; }

    float moveHorizontal;
    float moveVertical;
    Vector3 movement;


    Vector3 mousePos;
    public Vector3 worldPos;


    private void Start()
    {
        Speed = PlayerStats.Instance.Speed;
    }

    void Update()
    {
        GetAxises();
        SetMovement();
        Move();
        Rotate();
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
        transform.position += Speed * Time.deltaTime * movement;
    }

    void Rotate()
    {
        mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.y - transform.position.y;
        worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.y = transform.position.y;
        transform.LookAt(worldPos);
    }
}
