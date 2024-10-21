using System;
using UnityEngine;
namespace Garage
{
    public class TaskManager : MonoBehaviour
    {
        private Item[] itemsToMove;
        public Collider pickupArea;

        private int itemsInPickup = 0;

        public Action<float> onProgressChanged;
        public Action onComplete;

        private void Start()
        {
            itemsToMove = FindObjectsOfType<Item>();
            foreach (var item in itemsToMove)
            {
                item.OnItemDropped += OnItemMoved;
            }
        }

        private void OnItemMoved(Item item)
        {
            if (IsItemInPickupArea(item))
            {
                Destroy(item.gameObject);

                itemsInPickup++;
                onProgressChanged?.Invoke(((float)itemsInPickup) / itemsToMove.Length);

                CheckIfTaskCompleted();
            }
        }

        private bool IsItemInPickupArea(Item item)
        {
            return pickupArea.bounds.Intersects(item.GetComponent<Collider>().bounds);
        }

        private void CheckIfTaskCompleted()
        {
            if (itemsInPickup == itemsToMove.Length)
            {
                onComplete?.Invoke();
            }
        }

        private void OnDestroy()
        {
            foreach (var item in itemsToMove)
            {
                item.OnItemDropped -= OnItemMoved;
            }
        }
    }
}