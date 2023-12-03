using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    public GameObject PassedLevelMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameInfo.PlayerTag))
        {
            var playerController = collision.gameObject.GetComponent<PlayerController>();
            var playerEntity = playerController.GetComponent<PlayerEntity>();

            if (playerController != null)
                playerController.enabled = false;

            var passedClass = PassedLevelMenu.GetComponent<PassedMenu>();

            if (passedClass != null)
                if (playerEntity != null)
                    passedClass.SetLifes(playerEntity.Lifes);

            PassedLevelMenu.SetActive(true);
        }
    }
}
