using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
	GameObject mainCamera;
	public bool[] carrying = {false, false};
	public GameObject[] carriedObject = { null, null};
	Rigidbody[] carriedrigidbody = { null, null };

	public Transform[] objectholder;

	public float distance;
	public float smooth;
	public float throwstrength;
	// Use this for initialization
	void Start()
	{
		mainCamera = GameObject.FindWithTag("MainCamera");
	}

	// Update is called once per frame
	void Update()
	{

		for (int i = 0; i < carrying.Length; i++)
		{
			if (carrying[i])
			{
				carriedObject[i].transform.position = Vector3.Lerp(carriedObject[i].transform.position, objectholder[i].position, Time.deltaTime * smooth);
				carriedObject[i].transform.rotation = Quaternion.Lerp(carriedObject[i].transform.rotation, objectholder[i].rotation, Time.deltaTime * smooth);

				if (Input.GetMouseButtonDown(i))
					drop(i);
			}
			else
			{
				pick(i);
			}
		}
	}

	void pick(int hand)
	{
		if (Input.GetMouseButtonDown(hand))
		{
			int x = Screen.width / 2;
			int y = Screen.height / 2;
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y));
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.distance < distance)
				{
					GameObject p = hit.collider.gameObject;
					if (p.GetComponent<Pickable>() != null)
					{
						carrying[hand] = true;
						carriedObject[hand] = p.gameObject;
						carriedrigidbody[hand] = carriedObject[hand].GetComponent<Rigidbody>();
						carriedrigidbody[hand].constraints = RigidbodyConstraints.FreezeAll;
						carriedrigidbody[hand].constraints = RigidbodyConstraints.FreezeAll;

					}
				}
			}
		}
	}
	void drop(int hand)
	{
		carrying[hand] = false;
		carriedrigidbody[hand].constraints = RigidbodyConstraints.None;
		carriedrigidbody[hand].velocity = carriedObject[hand].transform.forward * throwstrength;
		float random = Random.Range(-4, 4);
		carriedrigidbody[hand].angularVelocity = new Vector3(random, random, random);
		
		carriedObject[hand] = null;
	}
}

