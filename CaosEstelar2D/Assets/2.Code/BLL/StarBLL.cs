using System.Collections;
using UnityEngine;
using BE;

namespace BLL
{
    public class StarBLL : MonoBehaviour
    {
        private StarBE _starBEObject;
        private SpriteRenderer _starSpriteRenderer;
        private ConstellationBLL _constellationBLL;

        private static readonly Color CustomColor = new Color32(0x58, 0x4B, 0x4B, 0xFF);

        public StarBE StarBEObject
        {
            get => _starBEObject;
            set => _starBEObject = value;
        }

        public SpriteRenderer StarSpriteRenderer
        {
            get => _starSpriteRenderer;
            private set => _starSpriteRenderer = value;
        }

        public int RandomValue { get; private set; }

        private void Awake()
        {
            StarSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _constellationBLL = FindObjectOfType<ConstellationBLL>();
        }

        private void Start()
        {
            InitializeStar();
        }

        private void InitializeStar()
        {
            RandomValue = Random.Range(1, 101);
            StarBEObject = new StarBE(RandomValue);
            Debug.Log($"Star created with random value: {RandomValue}");
        }

        public void TocarEstrella()
        {
            if (StarBEObject.IsTouched) return;

            Debug.Log($"Estrella {RandomValue} tocada");
            StarBEObject.IsTouched = true;

            if (_constellationBLL.VerifySequence(gameObject))
            {
                StartCoroutine(ChangeStarColorWhenTouched());
            }
        }

        private IEnumerator ChangeStarColorWhenTouched()
        {
            yield return LerpColor(StarSpriteRenderer.color, Color.white, 1.0f);
        }

        private IEnumerator LerpColor(Color from, Color to, float duration)
        {
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                StarSpriteRenderer.color = Color.Lerp(from, to, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            StarSpriteRenderer.color = to; // Ensure the final color is set
        }

        public void ResetColor()
        {
            StarSpriteRenderer.color = CustomColor;
            StarBEObject.IsTouched = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!StarBEObject.IsTouched)
            {
                TocarEstrella();
            }
        }
    }
}
