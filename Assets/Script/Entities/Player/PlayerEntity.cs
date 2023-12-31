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

        Lifes = GameMenager.PlayerLifes;

        lifesList = new List<GameObject>();
        for (int i = 0; i < Lifes; i++)
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
            Destroy(lifesList.Last());
            lifesList.Remove(lifesList.Last());
            controller.TriggerHitAnimation();
        }
        else
        {
            Die();
        }
    }

    public void Kill()
    {
        Lifes = 0;
        Die();
    }

    public void RestoreOneLife()
    {
        if (Lifes < MaxLifes)
        {
            Lifes++;
            GameMenager.PlayerLifes = Lifes;

            ResetLifesGrid();
        }
    }

    public void RestoreLifes()
    {
        Lifes = 3;
        GameMenager.PlayerLifes = 3;

        ResetLifesGrid();
    }

    private void ResetLifesGrid()
    {
        ClearLifes();
        FillLifes();
    }

    private void FillLifes()
    {
        for (int i = 0; i < Lifes; i++)
        {
            if (LifesGrid && LifeObject)
                lifesList.Add(Instantiate(LifeObject, LifesGrid.transform));
        }
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
        ClearLifes();
        Destroy(gameObject);
    }

    private void GameOver()
    {
        GameOverMenu.SetActive(true);
        AudioListener.volume = 0;
    }
}
