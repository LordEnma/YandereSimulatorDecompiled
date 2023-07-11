using UnityEngine;

public class WitnessCameraScript : MonoBehaviour
{
	public YandereScript Yandere;

	public Transform WitnessPOV;

	public float WitnessTimer;

	public Camera MyCamera;

	public bool Show;

	private void Start()
	{
		MyCamera.enabled = false;
		MyCamera.rect = new Rect(0f, 0f, 0f, 0f);
	}

	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			WitnessPOV = Yandere.StudentManager.Students[1].WitnessPOV;
			MyCamera.enabled = true;
			Show = true;
		}
		if (Show)
		{
			MyCamera.rect = new Rect(MyCamera.rect.x, MyCamera.rect.y, Mathf.Lerp(MyCamera.rect.width, 0.25f, Time.deltaTime * 10f), Mathf.Lerp(MyCamera.rect.height, 4f / 9f, Time.deltaTime * 10f));
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y, base.transform.localPosition.z + Time.deltaTime * 0.09f);
			WitnessTimer += Time.deltaTime;
			if (WitnessTimer > 5f)
			{
				WitnessTimer = 0f;
				Show = false;
			}
			if (Yandere.Struggling)
			{
				WitnessTimer = 0f;
				Show = false;
			}
		}
		else
		{
			MyCamera.rect = new Rect(MyCamera.rect.x, MyCamera.rect.y, Mathf.Lerp(MyCamera.rect.width, 0f, Time.deltaTime * 10f), Mathf.Lerp(MyCamera.rect.height, 0f, Time.deltaTime * 10f));
			if (MyCamera.enabled && MyCamera.rect.width < 0.1f)
			{
				MyCamera.enabled = false;
				base.transform.parent = null;
			}
		}
	}
}
