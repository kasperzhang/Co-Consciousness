using UnityEngine;

public abstract class Player : MonoBehaviour
{
    private Transform _border;
    
    protected bool IsMoving = false;
    protected Rigidbody2D Rigidbody2D;
    
    public float speed = 5f;

    protected abstract void OnInit();
    protected abstract void OnMove();
    protected abstract void OnUpdate();
    
    private void Start()
    {
        // _border = GameObject.FindWithTag("border").transform;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        
        OnInit();
    }

    private void Update()
    {
        if (GameManager.Instance.gameStatus != GameStatus.Run)
            return;

        // Border();

        Move();

        OnUpdate();
    }

    private void Move()
    {
        OnMove();
    }

    private void Border()
    {
        if (IsMoving)
            return;
        
        if (transform.position.x < _border.position.x)
        {
            transform.position = new Vector2(_border.position.x, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("obstacle"))
        {
            Destroy(gameObject);
            
            GameManager.Instance.SetCameraMove(false);

            GameManager.Instance.gameStatus = GameStatus.Over;

            GameManager.Instance.gamePanel.SetPanel(GameResult.Fail);
        }

        if (col.CompareTag("exit"))
        {
            col.GetComponent<BoxCollider2D>().enabled = false;
            
            GameManager.Instance.SetExit(1);
        }
    }
}