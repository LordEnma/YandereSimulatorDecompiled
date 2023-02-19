using UnityEngine;

public class ShortPromoCameraMovementScript : MonoBehaviour
{
	public AudioSource PromoMusic;

	public Transform Destination;

	public Camera MyCamera;

	public UITexture Logo;

	public Vector3 Origin;

	public float RealTime;

	public float Rotation;

	public float Timer;

	public bool Go;

	private void Start()
	{
		Origin = base.transform.position;
	}

	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			if (!MyCamera.enabled)
			{
				MyCamera.enabled = true;
			}
			else if (!Go)
			{
				PromoMusic.Play();
				Go = true;
			}
			else
			{
				base.transform.eulerAngles = new Vector3(90f, 0f, 0f);
				base.transform.position = Origin;
				PromoMusic.Stop();
				Logo.alpha = 0f;
				Rotation = 90f;
				RealTime = 0f;
				Timer = 0f;
				Go = false;
			}
		}
		if (Go)
		{
			if (RealTime < 25f)
			{
				RealTime += Time.deltaTime;
				Timer += Time.deltaTime * 0.0166666f;
				base.transform.position = Vector3.Lerp(base.transform.position, Destination.position, Time.deltaTime * Timer);
				Rotation = Mathf.Lerp(Rotation, -17.5f, Time.deltaTime * Timer);
				base.transform.eulerAngles = new Vector3(Rotation, 0f, 0f);
				Debug.Log("Seconds Passed: " + RealTime);
			}
			else
			{
				Logo.alpha = Mathf.MoveTowards(Logo.alpha, 1f, Time.deltaTime);
			}
		}
	}
}
