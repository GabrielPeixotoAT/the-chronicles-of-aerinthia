using UnityEngine;

public class InstantKill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameInfo.PlayerTag))
        {
            var playerEntity = collision.gameObject.GetComponent<PlayerEntity>();

            playerEntity.Kill();
        }
    }
}

