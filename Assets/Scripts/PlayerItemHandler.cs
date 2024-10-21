using UnityEngine;

namespace Garage
{
    public class PlayerItemHandler : MonoBehaviour
    {
        [SerializeField] private Transform holdPosition;

        private Camera _camera;
        private Crosshair _crosshair;
        private float _interactionRange;

        private Item _lastCheckedItem;
        private Item _heldItem;

        public void Initialize(Camera camera, Crosshair crosshair, float interactionRange = 3f)
        {
            _camera = camera;
            _crosshair = crosshair;
            _interactionRange = interactionRange;
        }

        public void Update()
        {
            Item item = CheckForItem();

            if (item != _lastCheckedItem)
            {
                _lastCheckedItem = item;

                if (_lastCheckedItem != null)
                {
                    _crosshair.Expand();
                }
                else
                {
                    _crosshair.Shrink();
                }
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                if (_heldItem != null)
                    DropItem();
                else
                    if(item != null)
                        HoldItem(item);
            }
        }

        public Item CheckForItem()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _interactionRange, LayerMask.GetMask("Default"), QueryTriggerInteraction.Ignore))
            {
                var item = hit.collider.GetComponent<Item>();
                if (item != null)
                {
                    return item;
                }
            }
            return null;
        }

        public void HoldItem(Item item)
        {
            _heldItem = item;
            _heldItem.transform.SetParent(holdPosition);
            _heldItem.transform.localPosition = Vector3.zero;
            _heldItem.transform.localRotation = Quaternion.identity;
            _heldItem.GetComponent<Rigidbody>().isKinematic = true;
            item.Pickup();
        }

        public void DropItem()
        {
            if (_heldItem == null) return;

            _heldItem.transform.SetParent(null);
            Rigidbody itemRb = _heldItem.GetComponent<Rigidbody>();
            itemRb.isKinematic = false;

            _heldItem.Drop();
            _heldItem = null;
        }
    }
}