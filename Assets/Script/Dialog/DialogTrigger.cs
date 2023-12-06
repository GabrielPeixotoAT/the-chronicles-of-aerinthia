using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public GameObject DialogMenu;

    private bool trigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!trigger)
            if (collision.gameObject.CompareTag(GameInfo.PlayerTag))
            {
                var dialogComponent = DialogMenu.GetComponent<DialogMenu>();

                if (dialogComponent != null)
                {
                    dialogComponent.SetNextDialog(DialogManager.NextDialog());
                }

                DialogMenu.SetActive(true);

                var playerController = collision.gameObject.GetComponent<PlayerController>();

                if (playerController != null)
                {
                    playerController.Stop();
                    playerController.enabled = false;
                }

               trigger = true;
            }
    }
}
