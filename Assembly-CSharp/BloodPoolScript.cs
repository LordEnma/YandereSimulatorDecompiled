using UnityEngine;

public class BloodPoolScript : MonoBehaviour
{
	public PowerSwitchScript PowerSwitch;

	public float TargetSize;

	public bool Gasoline;

	public bool Brown;

	public bool Water;

	public bool Blood = true;

	public bool Grow;

	public GameObject NewElectricity;

	public GameObject Electricity;

	public Renderer MyRenderer;

	public Material BloodPool;

	public Material Flower;

	public float ElectroTimer;

	public int StudentBloodID;

	private void Start()
	{
		if (PlayerGlobals.PantiesEquipped == 11 && Blood)
		{
			TargetSize *= 0.5f;
		}
		if (GameGlobals.CensorBlood)
		{
			MyRenderer.material = Flower;
		}
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
		if (Application.loadedLevelName == "IntroScene" || Application.loadedLevelName == "NewIntroScene")
		{
			MyRenderer.material.SetColor("_TintColor", new Color(0.1f, 0.1f, 0.1f));
		}
		if (!Blood)
		{
			base.gameObject.layer = 2;
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
	}

	private void OnTriggerEnter(Collider other)
	{
		if (Water && ElectroTimer == 0f && other.gameObject.tag == "E")
		{
			NewElectricity = Object.Instantiate(Electricity, base.transform.position, Quaternion.identity);
			ElectroTimer = 1f;
			if (other.gameObject.name == "CarBattery")
			{
				Object.Instantiate(other.gameObject.GetComponent<PickUpScript>().PuddleSparks, base.transform.position, Quaternion.identity);
				other.gameObject.GetComponent<PickUpScript>().Smoke.Play();
				other.gameObject.tag = "Untagged";
			}
			if (other.gameObject.GetComponent<ElectrifiedPuddleScript>() != null && other.gameObject.GetComponent<ElectrifiedPuddleScript>().PowerSwitch != null)
			{
				PowerSwitch = other.gameObject.GetComponent<ElectrifiedPuddleScript>().PowerSwitch;
				NewElectricity.GetComponent<SM_destroyThisTimed>().enabled = false;
			}
		}
	}
}
