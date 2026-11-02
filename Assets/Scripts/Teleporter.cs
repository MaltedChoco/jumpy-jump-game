using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Collider2D player;
    public Transform exit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == player)
        {
            player.gameObject.transform.position = exit.position;
        }
    }
}
