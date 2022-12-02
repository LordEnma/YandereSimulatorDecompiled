using UnityEngine;

public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	public GameObject Fire;

	public Vector3 Rotation;

	public float Value;

	private void Start()
	{
		Rigidbody component = GetComponent<Rigidbody>();
		component.AddForce(base.transform.up * 100f);
		component.AddForce(base.transform.right * 100f);
		Value = Random.Range(-1f, 1f);
	}

	private void Update()
	{
		Rotation += new Vector3(Value, Value, Value);
		base.transform.localEulerAngles = Rotation;
		if (base.transform.localPosition.y < 0.23f)
		{
			Object.Instantiate(Fire, base.transform.position, Quaternion.identity);
			Object.Destroy(base.gameObject);
		}
	}
}
