using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{

    private Menu menu;
    public UseDelegator usescript;

    public string name = "";
    private Transform pos;
    [SerializeField] float smooth = 10;

    Rigidbody rb;
    public float woobleRate = .6f;
    public float woobleIntensity = .015f;
    float woobleOffset;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        woobleOffset = Random.value;
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
        usescript = GetComponent<UseDelegator>();
        usescript.use = empty;
        StartCoroutine(nameof(wooble));
    }
    public void empty() { }
    public void goTo(Transform pos)
    {
        GetComponent<Collider>().enabled = false;
        this.pos = pos;
        StartCoroutine(nameof(lerp), 1);
    }

    IEnumerator wooble()
    {
        while (true)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + (Mathf.Sin((Time.unscaledTime / woobleRate) + woobleOffset) * woobleIntensity), rb.velocity.z);
            yield return 0.1f;
        }
    }

    IEnumerator lerp()
    {
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, pos.position, Time.deltaTime * smooth);
            transform.rotation = Quaternion.Lerp(transform.rotation, pos.rotation, Time.deltaTime * smooth);
            if (Vector3.Distance(transform.position, pos.position) < .001f)
            {
                transform.rotation = pos.rotation;
                menu.bookDone();
                StopCoroutine(nameof(lerp));
            }

            yield return null;
        }
    }
}
