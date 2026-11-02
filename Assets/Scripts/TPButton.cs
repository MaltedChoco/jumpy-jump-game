using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TPButton : MonoBehaviour
{
    public Transform player;
    public KeyCode press;
    void Update()
    {
        if (Input.GetKeyDown(press) && Application.isEditor)
        {
            player.position = transform.position;
        }
    }
}
