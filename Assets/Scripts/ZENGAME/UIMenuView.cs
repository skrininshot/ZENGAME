using TMPro;
using UnityEngine;

namespace ZENGAME
{
    public class UIMenuView  : MonoBehaviour
    {
        [SerializeField] private RectTransform menuRect;
        [SerializeField] private TMP_Text text;
        [SerializeField] private string defaultText;

        private void OnValidate()
        {
            defaultText = text?.text;
        }

        public void Show(string score, string bestScore)
        {
            menuRect.gameObject?.SetActive(true);
            text.text = defaultText
                .Replace("{score}", score)
                .Replace("{best_score}", bestScore);
        }

        public void Hide()
        {
            menuRect.gameObject?.SetActive(false);
        }
    }
}