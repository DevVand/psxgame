using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageFadeOut : MonoBehaviour
{
    public float smooth = .5f;
    Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Lerp(image.color.a, 0, Time.deltaTime * smooth));
    }
}
