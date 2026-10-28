using UnityEngine;

public class SideCollider : MonoBehaviour
{
    public Transform followTarget;

    public ContactFilter2D ContactFilter;

    public float offsetX;
    public bool mapCollide = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()

    {
        transform.position = new Vector3(followTarget.position.x + offsetX, followTarget.position.y, followTarget.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            mapCollide = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            mapCollide = false;
        }
    }
}
