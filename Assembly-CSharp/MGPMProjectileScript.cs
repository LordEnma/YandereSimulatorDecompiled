using UnityEngine;

public class MGPMProjectileScript : MonoBehaviour
{
	public Transform Sprite;

	public int Angle;

	public float Speed;

	public bool Eighties;

	private void Start()
	{
		if (Eighties)
		{
			base.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		}
	}

	private void Update()
	{
		if (base.gameObject.layer == 8)
		{
			base.transform.Translate(Vector3.up * Time.deltaTime * Speed);
		}
		else
		{
			base.transform.Translate(Vector3.forward * Time.deltaTime * Speed);
		}
		if (Angle == 1)
		{
			base.transform.Translate(Vector3.right * Time.deltaTime * Speed * 0.2f);
		}
		else if (Angle == -1)
		{
			base.transform.Translate(Vector3.right * Time.deltaTime * Speed * -0.2f);
		}
		if (base.transform.localPosition.y > 300f || base.transform.localPosition.y < -300f || base.transform.localPosition.x > 134f || base.transform.localPosition.x < -134f)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
