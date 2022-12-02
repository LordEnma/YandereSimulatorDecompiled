using UnityEngine;

public class MGPMPickUpScript : MonoBehaviour
{
	public float Speed;

	private void Update()
	{
		base.transform.Translate(Vector3.up * Time.deltaTime * Speed * -1f);
		if (base.transform.localPosition.y < -300f)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
