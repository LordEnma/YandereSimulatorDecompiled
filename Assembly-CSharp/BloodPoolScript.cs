using HighlightingSystem;
using UnityEngine;

public class BloodPoolScript : MonoBehaviour
{
	public PowerSwitchScript PowerSwitch;

	public float TargetSize;

	public bool UnderInvestigation;

	public bool Gasoline;

	public bool Brown;

	public bool Water;

	public bool Blood = true;

	public bool Grow;

	public GameObject NewElectricity;

	public Texture OriginalTexture;

	public GameObject Electricity;

	public Renderer MyRenderer;

	public Material BloodPool;

	public Material Flower;

	public float ElectroTimer;

	public int StudentBloodID;

	public Material StartMat;

	private void Start()
	{
		if (PlayerGlobals.PantiesEquipped == 11 && Blood)
		{
			TargetSize *= 0.5f;
		}
		UpdateCensor();
		if (GameGlobals.EightiesTutorial)
		{
			TargetSize = 1f;
		}
		base.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		Vector3 position = base.transform.position;
		if (position.x > 125f || position.x < -125f || position.z > 200f || position.z < -100f)
		{
			Object.Destroy(base.gameObject);
		}
		if (position.z > 100f && position.x < 20.5f && position.x > -20.5f)
		{
			YandereScript component = GameObject.Find("YandereChan").GetComponent<YandereScript>();
			component.NotificationManager.CustomText = "The liquid evaporated.";
			component.NotificationManager.DisplayNotification(NotificationType.Custom);
			Object.Destroy(base.gameObject);
		}
		if (Application.loadedLevelName == "IntroScene" || Application.loadedLevelName == "NewIntroScene")
		{
			MyRenderer.material.SetColor("_TintColor", new Color(0.1f, 0.1f, 0.1f));
		}
		if (!Blood)
		{
			base.gameObject.layer = 2;
		}
		if (MyRenderer != null)
		{
			StartMat = MyRenderer.material;
		}
	}

	private void Update()
	{
		if (Grow)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(TargetSize, TargetSize, TargetSize), Time.deltaTime);
			if (base.transform.localScale.x > TargetSize * 0.99f)
			{
				Grow = false;
			}
		}
		if (Water && ElectroTimer > 0f)
		{
			ElectroTimer = Mathf.MoveTowards(ElectroTimer, 0f, Time.deltaTime);
			if (PowerSwitch != null && PowerSwitch.On)
			{
				ElectroTimer = 0.1f;
			}
			if (ElectroTimer == 0f)
			{
				Object.Destroy(NewElectricity);
			}
		}
		if (MyRenderer != null && MyRenderer.material != StartMat)
		{
			base.gameObject.GetComponent<OutlineScript>().enabled = false;
			base.gameObject.GetComponent<Highlighter>().enabled = false;
			base.gameObject.GetComponent<OutlineScript>().enabled = true;
			base.gameObject.GetComponent<Highlighter>().enabled = true;
			StartMat = MyRenderer.material;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!Water || ElectroTimer != 0f || !(other.gameObject.tag == "E"))
		{
			return;
		}
		NewElectricity = Object.Instantiate(Electricity, base.transform.position, Quaternion.identity);
		ElectroTimer = 1f;
		if (other.gameObject.name.Contains("CarBattery"))
		{
			PickUpScript component = other.gameObject.GetComponent<PickUpScript>();
			bool flag = false;
			Debug.Log("A car battery collided with this puddle.");
			if (component.Yandere.Police.Show && component.Yandere.Police.Timer < 1f)
			{
				flag = true;
				Debug.Log("The police are almost here, so we shouldn't do anything.");
			}
			if (!flag)
			{
				Debug.Log("Spawning electricity.");
				Object.Instantiate(component.PuddleSparks, base.transform.position, Quaternion.identity);
				other.gameObject.tag = "Untagged";
				component.Broken = true;
				component.Smoke.Play();
			}
		}
		if (other.gameObject.GetComponent<ElectrifiedPuddleScript>() != null && other.gameObject.GetComponent<ElectrifiedPuddleScript>().PowerSwitch != null)
		{
			PowerSwitch = other.gameObject.GetComponent<ElectrifiedPuddleScript>().PowerSwitch;
			NewElectricity.GetComponent<SM_destroyThisTimed>().enabled = false;
		}
	}

	public void UpdateCensor()
	{
		if (MyRenderer != null)
		{
			if (GameGlobals.CensorBlood)
			{
				MyRenderer.material = Flower;
			}
			else
			{
				MyRenderer.material = BloodPool;
			}
		}
	}
}
