using UnityEngine;

public class SewingMachineScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Quaternion targetRotation;

	public PickUpScript Uniform;

	public Collider Chair;

	public bool Eighties;

	public bool MoveAway;

	public bool Sewing;

	public bool Check;

	public float Timer;

	private void Start()
	{
		if (StudentManager.TaskManager.TaskStatus[30] == 1)
		{
			Check = true;
		}
		else if (StudentManager.TaskManager.TaskStatus[30] > 2)
		{
			base.enabled = false;
		}
		Eighties = GameGlobals.Eighties;
	}

	private void Update()
	{
		if (Check)
		{
			if ((!Eighties && Yandere.PickUp != null && Yandere.PickUp.Clothing) || (Eighties && Yandere.Inventory.PinkCloth))
			{
				Prompt.enabled = true;
				if (!Eighties)
				{
					if (Yandere.PickUp.GetComponent<FoldedUniformScript>().Clean && Yandere.PickUp.GetComponent<FoldedUniformScript>().Type == 1)
					{
						Prompt.HideButton[0] = false;
					}
				}
				else if (Yandere.Inventory.PinkCloth)
				{
					Prompt.HideButton[1] = false;
				}
			}
			else
			{
				Prompt.Hide();
				Prompt.enabled = false;
			}
		}
		if (Prompt.Circle[0].fillAmount == 0f || Prompt.Circle[1].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			Prompt.Circle[1].fillAmount = 1f;
			if (!Yandere.Chased && Yandere.Chasers == 0)
			{
				Yandere.CharacterAnimation.CrossFade("f02_sewing_00");
				Yandere.MyController.radius = 0.1f;
				Yandere.CanMove = false;
				Chair.enabled = false;
				Sewing = true;
				GetComponent<AudioSource>().Play();
				if (!Eighties)
				{
					Uniform = Yandere.PickUp;
					Yandere.EmptyHands();
					Uniform.transform.parent = Yandere.RightHand;
					Uniform.transform.localPosition = new Vector3(0.1f, -0.03f, -0.1f);
					Uniform.transform.localEulerAngles = new Vector3(0f, -25f, -5f);
					Uniform.MyRigidbody.useGravity = false;
					Uniform.MyCollider.enabled = false;
				}
			}
		}
		if (!Sewing)
		{
			return;
		}
		Timer += Time.deltaTime;
		if (Timer < 5f)
		{
			targetRotation = Quaternion.LookRotation(base.transform.parent.transform.parent.position - Yandere.transform.position);
			Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, targetRotation, Time.deltaTime * 10f);
			Yandere.MoveTowardsTarget(Chair.transform.position);
			return;
		}
		if (!MoveAway)
		{
			Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
			if (Eighties)
			{
				Yandere.Inventory.PinkSocks = true;
			}
			else
			{
				Yandere.Inventory.ModifiedUniform = true;
				StudentManager.Students[30].TaskPhase = 5;
				StudentManager.TaskManager.TaskStatus[30] = 2;
				Object.Destroy(Uniform.gameObject);
			}
			MoveAway = true;
			Check = false;
			return;
		}
		Yandere.MoveTowardsTarget(Chair.gameObject.transform.position + new Vector3(-0.5f, 0f, 0f));
		if (Timer > 6f)
		{
			Yandere.MyController.radius = 0.2f;
			Yandere.CanMove = true;
			Chair.enabled = true;
			base.enabled = false;
			Sewing = false;
			Prompt.Hide();
			Prompt.enabled = false;
		}
	}
}
