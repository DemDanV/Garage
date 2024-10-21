using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Garage
{
    public class Crosshair : MonoBehaviour
    {
        public RawImage expanding; //the image that is expanded when the gun shoots

        [SerializeField] private float animationsSpeed; // how fast the recoil settles
        [SerializeField] private float crosshairMaxScale; //maximum size of the expanding crosshair

        private bool isExpanding;
        private bool isShrinking; //used to make sure crosshair returns to normal size at the right speed;

        private float crosshairOriginalScale; //stores the default crosshair size

        private void Start()
        {
            this.crosshairOriginalScale = expanding.rectTransform.localScale.x;
        }

        //used by the GUN to expand the crosshair
        public void Expand()
        {
            if (!isExpanding)
            {
                if (isShrinking)
                    isShrinking = false;

                StartCoroutine(ExpandCrosshair());
            }
        }

        private IEnumerator ExpandCrosshair()
        {
            isExpanding = true; //make sure we don't expand while expanding

            //while the crosshair is less than max size, keep expanding
            do
            {
                expanding.rectTransform.localScale = new Vector3(expanding.rectTransform.localScale.x + Time.deltaTime * animationsSpeed,
                                                                 expanding.rectTransform.localScale.y + Time.deltaTime * animationsSpeed,
                                                                 expanding.rectTransform.localScale.z + Time.deltaTime * animationsSpeed);
                if (expanding.rectTransform.localScale.x > crosshairMaxScale)
                    expanding.rectTransform.localScale = new Vector3(crosshairMaxScale, crosshairMaxScale, crosshairMaxScale);
                yield return new WaitForEndOfFrame();
            }
            while (expanding.rectTransform.localScale.x <= crosshairMaxScale && isExpanding);

            isExpanding = false;
        }

        public void SetAnimationSpeed(float AnimationsSpeed)
        {
            this.animationsSpeed = AnimationsSpeed;
        }

        public void SetMaxScale(float MaxScale)
        {
            this.crosshairMaxScale = MaxScale;
        }

        public void Shrink()
        {
            if (!isShrinking)  // slowly shrink the crosshair back to normal, if it's not already started shrinking
            {
                if (isExpanding)
                    isExpanding = false;

                StartCoroutine(ShrinkCrosshair());
            }
        }

        //shrinks the crosshair progressively over many frames - called by the ExpandCrosshair() function 
        private IEnumerator ShrinkCrosshair()
        {
            isShrinking = true; //make sure we don't shrink while shrinking

            //while the crosshair is bigger than default size, keep shrinking
            do
            {
                expanding.rectTransform.localScale = new Vector3(expanding.rectTransform.localScale.x - Time.deltaTime * animationsSpeed,
                                                                 expanding.rectTransform.localScale.y - Time.deltaTime * animationsSpeed,
                                                                 expanding.rectTransform.localScale.z - Time.deltaTime * animationsSpeed);
                if (crosshairOriginalScale < expanding.rectTransform.localScale.x)
                    expanding.rectTransform.localScale = Vector3.one * crosshairOriginalScale;

                yield return new WaitForEndOfFrame();
            }
            while (crosshairOriginalScale < expanding.rectTransform.localScale.x);

            isShrinking = false;
        }
    }
}

