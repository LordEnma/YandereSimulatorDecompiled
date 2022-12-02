using UnityEngine;

public class BucketPourScript : MonoBehaviour
{
	public SplashCameraScript SplashCamera;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public string PourHeight = string.Empty;

	public float PourDistance;

	public float PourTime;

	public int ID;

	private void Start()
	{
	}

	private void Update()
	{
		if (Yandere.PickUp != null)
		{
			if (Yandere.PickUp.Bucket != null)
			{
				if (Yandere.PickUp.Bucket.Full)
				{
					if (!Prompt.enabled)
					{
						Prompt.Label[0].text = "     Pour";
						Prompt.enabled = true;
					}
				}
				else if (Yandere.PickUp.Bucket.Dumbbells == 5)
				{
					if (!Prompt.enabled)
					{
						Prompt.Label[0].text = "     Drop";
						Prompt.enabled = true;
					}
				}
				else if (Prompt.enabled)
				{
					Prompt.Hide();
					Prompt.enabled = false;
				}
			}
			else if (Prompt.enabled)
			{
				Prompt.Hide();
				Prompt.enabled = false;
			}
		}
		else if (Prompt.enabled)
		{
			Prompt.Hide();
			Prompt.enabled = false;
		}
		if (Prompt.Circle[0] != null && Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (!Yandere.Chased && Yandere.Chasers == 0)
			{
				if (Yandere.PickUp.Bucket.Dumbbells == 5)
				{
					Yandere.CharacterAnimation.CrossFade("f02_bucketDrop_00");
					Yandere.MyController.radius = 0f;
					Yandere.BucketDropping = true;
					Yandere.DropSpot = base.transform;
					Yandere.CanMove = false;
				}
				else
				{
					Yandere.Stool = base.transform;
					Yandere.CanMove = false;
					Yandere.Pouring = true;
					Yandere.PourDistance = PourDistance;
					Yandere.PourHeight = PourHeight;
					Yandere.PourTime = PourTime;
				}
			}
		}
		if (Yandere.Pouring)
		{
			if (Input.GetButtonDown("B") && Prompt.DistanceSqr < 1f)
			{
				SplashCamera.Show = true;
				SplashCamera.MyCamera.enabled = true;
				if (ID == 1)
				{
					SplashCamera.transform.position = new Vector3(32.1f, 0.8f, 26.9f);
					SplashCamera.transform.eulerAngles = new Vector3(0f, -45f, 0f);
				}
				else
				{
					SplashCamera.transform.position = new Vector3(1.1f, 0.8f, 32.1f);
					SplashCamera.transform.eulerAngles = new Vector3(0f, -135f, 0f);
				}
			}
		}
		else if (Yandere.BucketDropping && Input.GetButtonDown("B") && Prompt.DistanceSqr < 1f)
		{
			SplashCamera.Show = true;
			SplashCamera.MyCamera.enabled = true;
			if (ID == 1)
			{
				SplashCamera.transform.position = new Vector3(32.1f, 0.8f, 26.9f);
				SplashCamera.transform.eulerAngles = new Vector3(0f, -45f, 0f);
			}
			else
			{
				SplashCamera.transform.position = new Vector3(1.1f, 0.8f, 32.1f);
				SplashCamera.transform.eulerAngles = new Vector3(0f, -135f, 0f);
			}
		}
	}
}
