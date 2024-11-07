using UnityEngine;
namespace Platformer
{
    public class WinZone : MonoBehaviour
    {

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<HZChto>(out var player))
            {
                Time.timeScale = 0f;
                
            }
        }
    }
}



