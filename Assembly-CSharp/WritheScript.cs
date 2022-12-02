using UnityEngine;

public class WritheScript : MonoBehaviour
{
	public float Rotation;

	public float StartTime;

	public float Duration;

	public float StartValue;

	public float EndValue;

	public int ID;

	public bool SpecialCase;

	private void Start()
	{
		StartTime = Time.time;
		Duration = Random.Range(1f, 5f);
	}

	private void Update()
	{
		if (Rotation == EndValue)
		{
			StartValue = EndValue;
			EndValue = Random.Range(-45f, 45f);
			StartTime = Time.time;
			Duration = Random.Range(1f, 5f);
		}
		float t = (Time.time - StartTime) / Duration;
		Rotation = Mathf.SmoothStep(StartValue, EndValue, t);
		switch (ID)
		{
		case 1:
			base.transform.localEulerAngles = new Vector3(Rotation, base.transform.localEulerAngles.y, base.transform.localEulerAngles.z);
			break;
		case 2:
			if (SpecialCase)
			{
				Rotation += 180f;
			}
			base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, Rotation, base.transform.localEulerAngles.z);
			break;
		case 3:
			base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, Rotation);
			break;
		}
	}
}
