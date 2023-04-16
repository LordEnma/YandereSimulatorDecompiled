using UnityEngine;

public class GenericEightiesTaskScript : MonoBehaviour
{
	public Transform PropDestination;

	public Transform Destination;

	public Transform Prop;

	public StudentScript MyStudent;

	public string CompletionText;

	public PromptScript Prompt;

	public string TaskAnim;

	public float TaskTimer;

	public bool Suspicious;

	public bool Animation;

	public bool Animate;

	public Vector3 Origin;

	public int Paintings;

	public int Type;

	public Texture[] OriginalArt;

	public Texture[] FixedArt;

	public Renderer OriginalPainting;

	public Renderer FixedPainting;

	public void Start()
	{
		if (Prop != null)
		{
			Origin = Prop.transform.position;
		}
		if (!GameGlobals.Eighties)
		{
			Prompt.enabled = false;
			Prompt.Hide();
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (Prompt.Yandere.Inventory.ItemsRequested[Type] > Prompt.Yandere.Inventory.ItemsCollected[Type])
		{
			Prompt.enabled = true;
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				bool flag = false;
				if (Type == 3)
				{
					if (Prompt.Yandere.Inventory.Cloth == 0)
					{
						Prompt.Yandere.NotificationManager.CustomText = "Grab some nearby cloth first!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						flag = true;
					}
					else
					{
						Prompt.Yandere.Inventory.Cloth--;
					}
				}
				if (!flag)
				{
					if (!Animation)
					{
						CompleteTask();
					}
					else
					{
						if (Prop != null)
						{
							Prop.transform.position = PropDestination.position;
						}
						if ((bool)MyStudent)
						{
							MyStudent.Routine = false;
							MyStudent.CharacterAnimation.CrossFade("f02_giveItem_00");
							TaskTimer = 3f;
						}
						if (Type == 8)
						{
							Prompt.Yandere.Paintbrush.SetActive(value: true);
							Prompt.Yandere.Palette.SetActive(value: true);
							Paintings++;
							OriginalPainting.material.mainTexture = OriginalArt[Paintings];
							FixedPainting.material.mainTexture = FixedArt[Paintings];
							OriginalPainting.material.color = new Color(1f, 1f, 1f, 1f);
						}
						Prompt.Yandere.CanMove = false;
						Animate = true;
						if (Suspicious)
						{
							Prompt.Yandere.SuspiciousActionTimer = 5f;
						}
					}
				}
			}
		}
		else if (Prompt.enabled)
		{
			Prompt.enabled = false;
			Prompt.Hide();
		}
		if (!Animate)
		{
			return;
		}
		if (Type == 8)
		{
			FixedPainting.material.color = new Color(1f, 1f, 1f, FixedPainting.material.color.a + Time.deltaTime * 0.2f);
		}
		Prompt.Yandere.CharacterAnimation.CrossFade(TaskAnim);
		if (Destination != null)
		{
			Prompt.Yandere.transform.rotation = Quaternion.Slerp(Prompt.Yandere.transform.rotation, Destination.rotation, Time.deltaTime * 10f);
			Prompt.Yandere.MoveTowardsTarget(Destination.position);
		}
		else
		{
			Prompt.Yandere.targetRotation = Quaternion.LookRotation(new Vector3(MyStudent.Hips.transform.position.x, MyStudent.transform.position.y, MyStudent.Hips.transform.position.z) - Prompt.Yandere.transform.position);
			Prompt.Yandere.transform.rotation = Quaternion.Slerp(Prompt.Yandere.transform.rotation, Prompt.Yandere.targetRotation, 10f * Time.deltaTime);
		}
		if ((bool)MyStudent)
		{
			MyStudent.targetRotation = Quaternion.LookRotation(new Vector3(MyStudent.Yandere.Hips.transform.position.x, MyStudent.transform.position.y, MyStudent.Yandere.Hips.transform.position.z) - MyStudent.transform.position);
			MyStudent.transform.rotation = Quaternion.Slerp(MyStudent.transform.rotation, MyStudent.targetRotation, 10f * Time.deltaTime);
		}
		TaskTimer += Time.deltaTime;
		if (TaskTimer > 5f)
		{
			if (Prop != null)
			{
				Prop.transform.position = Origin;
			}
			if ((bool)MyStudent)
			{
				MyStudent.Routine = true;
			}
			Prompt.Yandere.CanMove = true;
			End();
			CompleteTask();
		}
		if (Prompt.Yandere.Noticed)
		{
			End();
		}
	}

	public void End()
	{
		Prompt.Yandere.SuspiciousActionTimer = 0f;
		Animate = false;
		TaskTimer = 0f;
		Prompt.Yandere.Paintbrush.SetActive(value: false);
		Prompt.Yandere.Palette.SetActive(value: false);
		if (Type == 8)
		{
			OriginalPainting.material.color = new Color(1f, 1f, 1f, 0f);
			FixedPainting.material.color = new Color(1f, 1f, 1f, 0f);
		}
	}

	public void CompleteTask()
	{
		Prompt.Yandere.Inventory.ItemsCollected[Type]++;
		Prompt.Yandere.NotificationManager.CustomText = CompletionText;
		Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
	}
}
