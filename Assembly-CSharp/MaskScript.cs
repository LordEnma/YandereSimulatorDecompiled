using UnityEngine;

public class MaskScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public ClubManagerScript ClubManager;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public PickUpScript PickUp;

	public Projector Blood;

	public Renderer MyRenderer;

	public MeshFilter MyFilter;

	public Texture[] Textures;

	public Mesh[] Meshes;

	public bool Worn;

	public int ID;

	private void Start()
	{
		if (GameGlobals.MasksBanned)
		{
			base.gameObject.SetActive(value: false);
		}
		else
		{
			MyFilter.mesh = Meshes[ID];
			MyRenderer.material.mainTexture = Textures[ID];
		}
		base.enabled = false;
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			StudentManager.CanAnyoneSeeYandere();
			if (!StudentManager.YandereVisible && !Yandere.Chased && Yandere.Chasers == 0)
			{
				WearMask();
				return;
			}
			Yandere.NotificationManager.CustomText = "Can't put on mask in front of witnesses";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	public void WearMask()
	{
		Debug.Log("This mask is now being attached to Yandere-chan's face.");
		Rigidbody component = GetComponent<Rigidbody>();
		component.useGravity = false;
		component.isKinematic = true;
		Prompt.Hide();
		Prompt.enabled = false;
		Prompt.MyCollider.enabled = false;
		base.transform.parent = Yandere.Head;
		if (ID == 1)
		{
			base.transform.localPosition = new Vector3(0f, 0.06f, 0.14f);
		}
		else
		{
			base.transform.localPosition = new Vector3(0f, 0.033333f, 0.14f);
		}
		base.transform.localEulerAngles = Vector3.zero;
		Yandere.Mask = this;
		ClubManager.UpdateMasks();
		StudentManager.UpdateStudents();
		Worn = true;
	}

	public void Drop()
	{
		Worn = false;
		Prompt.MyCollider.isTrigger = false;
		Prompt.MyCollider.enabled = true;
		Rigidbody component = GetComponent<Rigidbody>();
		component.useGravity = true;
		component.isKinematic = false;
		Prompt.enabled = true;
		base.transform.parent = null;
		Yandere.Mask = null;
		ClubManager.UpdateMasks();
		StudentManager.UpdateStudents();
	}
}
