using UnityEngine;

public class SwordCutsceneScript : MonoBehaviour
{
	public Animation YandereAnimation;

	public Animation SwordAnimation;

	public Transform SecondAngle;

	public Transform HeartSegment;

	public Transform[] Segments;

	public float Intensity;

	private void Start()
	{
		Segments = HeartSegment.gameObject.GetComponentsInChildren<Transform>();
		base.transform.position = new Vector3(0.5f, 1.25f, -1.9f);
		base.transform.eulerAngles = new Vector3(0f, -45f, 0f);
	}

	private void Update()
	{
		Debug.Log(YandereAnimation["f02_swordPull_00"].time);
		if (Input.GetKeyDown("space"))
		{
			YandereAnimation["f02_swordPull_00"].time = 15f;
			SwordAnimation["Sword_Pull"].time = 15f;
		}
		if (YandereAnimation["f02_swordPull_00"].time > 33f)
		{
			if (base.transform.position.x != 0f)
			{
				base.transform.position = new Vector3(0f, 1f, 0f);
				base.transform.eulerAngles = new Vector3(0f, 180f, 0f);
			}
			else
			{
				base.transform.position += new Vector3(0f, 0f, Time.deltaTime * 0.1f);
			}
		}
		else if (YandereAnimation["f02_swordPull_00"].time > 15.5f)
		{
			base.transform.position = new Vector3(0.66666f, 1.25f, -1.75f);
			base.transform.eulerAngles = new Vector3(0f, -45f, 0f);
		}
		else if (YandereAnimation["f02_swordPull_00"].time > 10.5f)
		{
			base.transform.position = SecondAngle.position;
			base.transform.eulerAngles = SecondAngle.eulerAngles;
		}
	}

	private void LateUpdate()
	{
		if (YandereAnimation["f02_swordPull_00"].time > 16.5f && YandereAnimation["f02_swordPull_00"].time < 22.5f)
		{
			Intensity += Time.deltaTime;
			Transform[] segments = Segments;
			for (int i = 0; i < segments.Length; i++)
			{
				segments[i].transform.position += new Vector3(Random.Range(-0.001f * Intensity, 0.001f * Intensity), Random.Range(-0.001f * Intensity, 0.001f * Intensity), Random.Range(-0.001f * Intensity, 0.001f * Intensity));
			}
		}
	}
}
