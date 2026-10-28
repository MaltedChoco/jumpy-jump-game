using Unity.VisualScripting;
using UnityEngine;

public class KillTheSun : MonoBehaviour
{
    public SpriteRenderer theSun;
    public PlayerController thePlayer;
    public StoryController story;
    public GameObject portalDoor;
    public bool FixTheSun = false;

    private Color32 NoSky = new(36,28,51,255);
    private Color32 ArtificialSky = new(6, 165, 55, 255);
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!FixTheSun)
        {
            theSun.color = NoSky;
            thePlayer.inHell = true;
            story.TypewriterText("t.h.e.s.u.n.i.s.d.e.a.d");
            Destroy(this.gameObject);
        } else
        {
            theSun.color = ArtificialSky;
            thePlayer.inHell = false;
            story.TypewriterText("artificial skies");
            Destroy(portalDoor);
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (FixTheSun)
        {
            Quaternion t = transform.rotation;
            if (t.z == 180)
            {
                t.z = -180;
            } else
            {
                t.z += 0.001f;
            }            
            transform.rotation = t;
        }
    }
}
