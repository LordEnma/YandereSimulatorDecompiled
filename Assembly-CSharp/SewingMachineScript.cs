using UnityEngine;

public class SewingMachineScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public TallLockerScript TallLocker;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Quaternion targetRotation;

	public PickUpScript Uniform;

	public Collider Chair;

	public bool Eighties;

	public bool MoveAway;

	public bool Bikini;

	public bool Sewing;

	public bool Apron;

	public bool Check;

	public float Timer;

	private void Start()
	{
		if (GameGlobals.EightiesTutorial)
		{
			Prompt.enabled = false;
			Prompt.Hide();
			base.enabled = false;
		}
		else
		{
			Eighties = GameGlobals.Eighties;
			Prompt.enabled = true;
			base.enabled = true;
			Check = true;
		}
	}

	private void Update()
	{
		if (Check)
		{
			if ((!Eighties && Yandere.PickUp != null && Yandere.PickUp.FoldedUniform != null) || (!Eighties && Apron) || (Eighties && Yandere.Inventory.PinkCloth) || (Eighties && Yandere.Inventory.Cloth > 0))
			{
				Prompt.enabled = true;
				if (!Eighties)
				{
					if (StudentManager.TaskManager.TaskStatus[30] > 0 && Yandere.PickUp != null && Yandere.PickUp.FoldedUniform.Clean && Yandere.PickUp.FoldedUniform.Type == 1)
					{
						Prompt.HideButton[0] = false;
					}
					else
					{
						Prompt.HideButton[0] = true;
					}
					if (Yandere.Inventory.PinkCloth && Apron)
					{
						Prompt.HideButton[1] = false;
					}
					else
					{
						Prompt.HideButton[1] = true;
					}
				}
				else
				{
					if (Yandere.Inventory.PinkCloth && !Yandere.Inventory.PinkSocks)
					{
						Prompt.HideButton[1] = false;
					}
					else
					{
						Prompt.HideButton[1] = true;
					}
					if (Yandere.Inventory.Cloth > 0 && !Yandere.Inventory.Bikini)
					{
						Prompt.HideButton[2] = false;
					}
					else
					{
						Prompt.HideButton[2] = true;
					}
				}
			}
			else
			{
				Prompt.Hide();
				Prompt.enabled = false;
			}
		}
		if (Prompt.Circle[0].fillAmount == 0f || Prompt.Circle[1].fillAmount == 0f || Prompt.Circle[2].fillAmount == 0f)
		{
			if (Prompt.Circle[2].fillAmount == 0f)
			{
				Prompt.Yandere.Inventory.Cloth--;
				Bikini = true;
			}
			Prompt.Circle[0].fillAmount = 1f;
			Prompt.Circle[1].fillAmount = 1f;
			Prompt.Circle[2].fillAmount = 1f;
			if (!Yandere.Chased && Yandere.Chasers == 0)
			{
				if (Yandere.PickUp != null && Yandere.PickUp.FoldedUniform == null)
				{
					Yandere.EmptyHands();
				}
				Yandere.CharacterAnimation.CrossFade("f02_sewing_00");
				Yandere.MyController.radius = 0.1f;
				Yandere.CanMove = false;
				Chair.enabled = false;
				Sewing = true;
				GetComponent<AudioSource>().Play();
				if (!Eighties && !Apron)
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
				if (Bikini)
				{
					Yandere.Inventory.Bikini = true;
					Prompt.HideButton[2] = true;
					TallLocker.Bikini = true;
					Bikini = false;
				}
				else
				{
					Yandere.Inventory.PinkCloth = false;
					Yandere.Inventory.PinkSocks = true;
					Prompt.HideButton[1] = true;
				}
			}
			else if (Apron)
			{
				Yandere.Inventory.PinkCloth = false;
				Yandere.Inventory.PinkApron = true;
				Prompt.HideButton[2] = true;
				Apron = false;
			}
			else
			{
				Yandere.Inventory.ModifiedUniform = true;
				StudentManager.Students[30].TaskPhase = 5;
				StudentManager.TaskManager.TaskStatus[30] = 2;
				Object.Destroy(Uniform.gameObject);
			}
			MoveAway = true;
			return;
		}
		Yandere.MoveTowardsTarget(Chair.gameObject.transform.position + new Vector3(-0.5f, 0f, 0f));
		if (Timer > 5.5f)
		{
			Yandere.MyController.radius = 0.2f;
			Yandere.CanMove = true;
			Chair.enabled = true;
			MoveAway = false;
			Sewing = false;
			Timer = 0f;
			if (!Eighties)
			{
				Prompt.Hide();
				Prompt.enabled = false;
			}
			if (Eighties && !Yandere.Inventory.PinkCloth && Yandere.Inventory.Cloth == 0)
			{
				Prompt.Hide();
				Prompt.enabled = false;
			}
		}
	}
}
