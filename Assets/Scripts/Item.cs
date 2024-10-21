using System;
using UnityEngine;

namespace Garage
{
    [RequireComponent(typeof(Rigidbody))]
    public class Item : MonoBehaviour
    {
        public Action<Item> OnItemDropped;

        private void OnValidate()
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }

        public void Pickup()
        {
            Debug.Log("Item picked up!");
        }

        public void Drop()
        {
            Debug.Log("Item dropped!");
            OnItemDropped?.Invoke(this);
        }
    }
}
