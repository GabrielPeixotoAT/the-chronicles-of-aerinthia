using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerEntity : Entity
{
    public GameObject GameOverMenu;

    public GameObject LifesGrid;
    public GameObject LifeObject;

    private List<GameObject> lifesList;
    private PlayerController controller;

    void Awake()
    {
        controller = GetComponent<PlayerController>();

        lifesList = new List<GameObject>();
        for (int i = 1; i < Lifes; i++)
        {
            if (LifesGrid && LifeObject)
                lifesList.Add(Instantiate(LifeObject, LifesGrid.transform));
        }
    }

    public void TakeDamage()
    {
        if (Lifes > 1)
        {
            Lifes--;
            controller.TriggerHitAnimation();
            Destroy(lifesList.First());
        }
        else
        {
            Die();
        }
    }

    public void Kill()
    {
        Lifes = 0;
        ClearLifes();
        Die();
    }

    private void ClearLifes()
    {
        if (lifesList.Any())
            foreach (GameObject item in lifesList)
                Destroy(item);
    }

    private void Die()
    {
        GameOver();
        Destroy(gameObject);
    }

    private void GameOver()
    {
        if (GameOverMenu)
            Instantiate(GameOverMenu);
    }
}
