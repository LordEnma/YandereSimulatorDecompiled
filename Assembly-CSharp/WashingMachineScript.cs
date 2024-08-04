using UnityEngine;

public class WashingMachineScript : MonoBehaviour
{
	public GameObject NewestUniform;

	public GameObject CleanUniform;

	public GameObject Colliders;

	public GameObject Panel;

	public AudioSource MyAudio;

	public AudioClip OpenSFX;

	public AudioClip ShutSFX;

	public AudioClip WashSFX;

	public PromptScript Prompt;

	public Transform Tumbler;

	public Transform Door;

	public UILabel TimeLabel;

	public UISprite Circle;

	public float AnimationTimer;

	public float WashSpeed = 1f;

	public float WashTimer;

	public float Rotation;

	public float Speed;

	public bool Washing;

	public bool Open;

	public PickUpScript[] ClothingList;

	public int ClothingInMachine;

	public int GloveID;

	private void Start()
	{
		Panel.SetActive(value: false);
	}

	private void Update()
	{
		if (!Washing)
		{
			if (Prompt != null && Prompt.Yandere != null)
			{
				if ((Prompt.Yandere.PickUp != null && Prompt.Yandere.PickUp.Clothing && Prompt.Yandere.PickUp.Evidence) || (Prompt.Yandere.PickUp != null && Prompt.Yandere.PickUp.Clothing && Prompt.Yandere.PickUp.RedPaint))
				{
					Prompt.HideButton[3] = false;
				}
				else
				{
					Prompt.HideButton[3] = true;
				}
			}
		}
		else
		{
			Tumbler.Rotate(0f, 0f, 360f * Time.deltaTime, Space.Self);
			WashTimer -= Time.deltaTime * WashSpeed;
			Circle.fillAmount = 1f - WashTimer / 60f;
			float num = Mathf.CeilToInt(WashTimer * 60f);
			float num2 = Mathf.Floor(num / 60f);
			float num3 = Mathf.RoundToInt(num % 60f);
			TimeLabel.text = $"{num2:00}:{num3:00}";
			if (WashTimer <= 0f)
			{
				Finish();
			}
		}
		if (Prompt.Circle[3].fillAmount == 0f)
		{
			Prompt.Circle[3].fillAmount = 1f;
			ClothingList[ClothingInMachine] = Prompt.Yandere.PickUp;
			Prompt.Yandere.EmptyHands();
			if (ClothingList[ClothingInMachine].gameObject.name == "Raincoat" || ClothingList[ClothingInMachine].gameObject.name == "OccultRobe")
			{
				ClothingList[ClothingInMachine].transform.position = base.transform.position + new Vector3(0f, 0.475f, 0.11f);
				ClothingList[ClothingInMachine].transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
			}
			else
			{
				ClothingList[ClothingInMachine].transform.position = base.transform.position + new Vector3(0f, 0.6f, 0.1f);
			}
			ClothingList[ClothingInMachine].MyRigidbody.isKinematic = false;
			ClothingList[ClothingInMachine].MyRigidbody.useGravity = true;
			ClothingList[ClothingInMachine].KeepGravity = true;
			ClothingInMachine++;
			Colliders.SetActive(value: true);
			AnimationTimer = 2f;
			Speed = 0f;
			Open = true;
			Prompt.HideButton[0] = false;
			MyAudio.clip = OpenSFX;
			MyAudio.loop = false;
			MyAudio.Play();
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (AnimationTimer <= 0f)
			{
				Prompt.HideButton[0] = true;
				Prompt.HideButton[3] = true;
				Panel.SetActive(value: true);
				WashTimer = 60f;
				Washing = true;
				MyAudio.clip = WashSFX;
				MyAudio.loop = true;
				MyAudio.Play();
			}
		}
		if (!(AnimationTimer > 0f))
		{
			return;
		}
		AnimationTimer -= Time.deltaTime;
		if (AnimationTimer < 1f)
		{
			Open = false;
		}
		if (Open)
		{
			Rotation = Mathf.Lerp(Rotation, 125f, Time.deltaTime * 10f);
		}
		else
		{
			Speed += Time.deltaTime * 360f;
			Rotation = Mathf.MoveTowards(Rotation, 0f, Time.deltaTime * Speed);
			if (Rotation == 0f && MyAudio.clip != ShutSFX)
			{
				MyAudio.clip = ShutSFX;
				MyAudio.loop = false;
				MyAudio.Play();
			}
		}
		Door.transform.localEulerAngles = new Vector3(0f, Rotation, 0f);
	}

	public void Finish()
	{
		for (int i = 0; i < ClothingList.Length; i++)
		{
			if (!(ClothingList[i] != null))
			{
				continue;
			}
			if (ClothingList[i].gameObject.name == "Raincoat" || ClothingList[i].gameObject.name == "OccultRobe" || ClothingList[i].gameObject.name == "SilkGloves")
			{
				ClothingList[i].transform.position = base.transform.position + new Vector3(0f, 0.6f, -0.66666f);
				ClothingList[i].transform.localScale = new Vector3(1f, 1f, 1f);
				ClothingList[i].Evidence = false;
				ClothingList[i].gameObject.GetComponent<GloveScript>().Blood.enabled = false;
				if (ClothingList[i].gameObject.name == "Raincoat" || ClothingList[i].gameObject.name == "OccultRobe")
				{
					Prompt.Yandere.CoatBloodiness[ClothingList[i].gameObject.GetComponent<GloveScript>().GloveID] = 0f;
				}
				else
				{
					Prompt.Yandere.GloveAttacher.newRenderer.material.mainTexture = Prompt.Yandere.GloveTexture;
				}
				OutlineScript component = ClothingList[i].GetComponent<OutlineScript>();
				if (component != null)
				{
					component.color = new Color(0f, 1f, 1f, 1f);
				}
			}
			else if (ClothingList[i].gameObject.name == "Mask")
			{
				ClothingList[i].transform.position = base.transform.position + new Vector3(0f, 0.6f, -0.66666f);
				ClothingList[i].transform.localScale = new Vector3(1f, 1f, 1f);
				ClothingList[i].Evidence = false;
				ClothingList[i].gameObject.GetComponent<MaskScript>().Blood.enabled = false;
			}
			else
			{
				if (ClothingList[i].RedPaint)
				{
					Prompt.Yandere.Police.RedPaintClothing--;
					ClothingList[i].RedPaint = false;
				}
				FoldedUniformScript component2 = ClothingList[i].GetComponent<FoldedUniformScript>();
				Debug.Log("FoldedUniform is: " + component2);
				if ((component2 != null && component2.Type == 2) || (component2 != null && component2.Type == 3) || (component2 != null && component2.ClubAttire))
				{
					Debug.Log("The player put something into the washing machine that was not a regular school uniform.");
					ClothingList[i].transform.position = base.transform.position + new Vector3(0f, 0.6f, -0.66666f);
					ClothingList[i].transform.localScale = new Vector3(1f, 1f, 1f);
					ClothingList[i].Evidence = false;
					component2.CleanUp();
				}
				else
				{
					NewestUniform = Object.Instantiate(CleanUniform, base.transform.position + new Vector3(0f, 0.6f, -0.66666f), Quaternion.identity);
					Object.Destroy(ClothingList[i].gameObject);
				}
				component2.gameObject.GetComponent<PickUpScript>().OriginalColor = new Color(0f, 1f, 1f, 1f);
				OutlineScript[] outline = component2.gameObject.GetComponent<PickUpScript>().Outline;
				for (int j = 0; j < outline.Length; j++)
				{
					outline[j].color = new Color(0f, 1f, 1f, 1f);
				}
			}
			Prompt.Yandere.Police.BloodyClothing--;
			ClothingList[i] = null;
		}
		Prompt.Yandere.StudentManager.OriginalUniforms += ClothingInMachine;
		ClothingInMachine = 0;
		Colliders.SetActive(value: false);
		Panel.SetActive(value: false);
		Washing = false;
		MyAudio.clip = OpenSFX;
		MyAudio.loop = false;
		MyAudio.Play();
	}
}
