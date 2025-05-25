using System.Collections;
using UnityEngine;

namespace ZENGAME
{
    public class AttentionPointView : MonoBehaviour
    {
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color blinkColor;
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        [SerializeField] private float blinkTime = 0.2f;

        private Coroutine _timerCoroutine;

        private void OnValidate()
        {
            spriteRenderer.color = defaultColor;
        }
        
        public void Blink()
        {
            if (_timerCoroutine != null) 
                StopCoroutine(_timerCoroutine);
            
            _timerCoroutine = StartCoroutine(BlinkTimer());
        }

        private IEnumerator BlinkTimer()
        {
            WaitForSeconds waitForSeconds = new(blinkTime);

            spriteRenderer.color = blinkColor;

            yield return waitForSeconds;
            
            spriteRenderer.color = defaultColor;
        }
    }
}