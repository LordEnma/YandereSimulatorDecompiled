using UnityEngine;

public class YanvaniaJarShardScript : MonoBehaviour
{
	public float MyRotation;

	public float Rotation;

	private void Start()
	{
		Rotation = Random.Range(-360f, 360f);
		GetComponent<Rigidbody>().AddForce(Random.Range(-100f, 100f), Random.Range(0f, 100f), Random.Range(-100f, 100f));
	}

	private void Update()
	{
		MyRotation += Rotation;
		base.transform.eulerAngles = new Vector3(MyRotation, MyRotation, MyRotation);
		if (base.transform.position.y < 6.5f)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
