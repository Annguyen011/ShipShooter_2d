using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Power,
    Boom,
    Heart

}
public class Item : MonoBehaviour
{
    [SerializeField] private ItemType type;
    private Movement2D movement;

    private void Awake()
    {
        movement = GetComponent<Movement2D>();

    }

    private void Start()
    {
        movement.MoveTo(new Vector3(0, -1));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Use(collision.gameObject);

            Destroy(gameObject);
        }
    }

    public void Use(GameObject gameObject)
    {
        switch (type)
        {
            case ItemType.Power:

                gameObject.GetComponent<Weapon>().AttackLevel++;
                break;

            case ItemType.Boom:
                gameObject.GetComponent<Weapon>().BoomCount++;
                break;
            case ItemType.Heart:
                gameObject.GetComponent<PlayerHP>().CurHealth = gameObject.GetComponent<PlayerHP>().MaxHealth;
                break;
        }
    }
}
