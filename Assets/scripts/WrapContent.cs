using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WrapContent : MonoBehaviour
{
    public RectTransform text;

    private int done;

    void Start()
    {
        done = 10;
    }

    void Update()
    {
        if (done > 0 && transform.localScale.x != text.rect.width)
        {
            --done;
            transform.localScale = new Vector3(text.rect.width / 64, text.rect.height / 64, 1);
            var theText = text.GetComponent<Text>();
            var parentRect = GetComponentInParent<RectTransform>();
            var position = transform.localPosition;

            var align = theText.alignment;
            if (align == TextAnchor.MiddleRight)
            {
                position.x = parentRect.rect.width / 2 - text.rect.width / 2;
            }
            else if (align == TextAnchor.MiddleLeft)
            {
                position.x = -parentRect.rect.width / 2 + text.rect.width / 2;
            }
            else
            {
                position.x = 0;
            }
            transform.localPosition = position;
        }
    }
}
