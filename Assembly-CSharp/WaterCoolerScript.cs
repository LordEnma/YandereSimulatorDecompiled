using UnityEngine;

public class WaterCoolerScript : MonoBehaviour
{
	public StringTrapScript Tripwire;

	public YandereScript Yandere;

	public PickUpScript PickUp;

	public PromptScript Prompt;

	public UIPanel WaterCoolerChecklist;

	public UISprite LiquidCheckmark;

	public UISprite WeaponCheckmark;

	public UISprite ThreadCheckmark;

	public UISprite TapeCheckmark;

	public Transform StringTrapParent;

	public Transform Cylinder;

	public Renderer CylinderRenderer;

	public GameObject TripwireTrap;

	public Rigidbody MyRigidbody;

	public bool BrownPaint;

	public bool Gasoline;

	public bool Water;

	public bool Blood;

	public bool TrapSet;

	public bool Empty;

	public float Timer;

	public Color[] OriginalColor;

	public bool TooCloseToWall;

	private void Start()
	{
		Cylinder.localScale = new Vector3(1f, 0f, 1f);
		TripwireTrap.SetActive(false);
		Prompt.HideButton[1] = true;
		OriginalColor[0] = Prompt.Label[1].gradientTop;
		OriginalColor[1] = Prompt.Label[1].gradientBottom;
	}

	private void Update()
	{
		if (Empty)
		{
			if (Yandere.PickUp != null)
			{
				if ((Yandere.PickUp.Bucket != null && Yandere.PickUp.Bucket.Full) || Yandere.PickUp.BrownPaint || Yandere.PickUp.JerryCan)
				{
					Prompt.HideButton[0] = false;
					if (Prompt.Circle[0].fillAmount == 0f)
					{
						if (Yandere.PickUp.Bucket == null)
						{
							BrownPaint = Yandere.PickUp.BrownPaint;
							Gasoline = Yandere.PickUp.JerryCan;
							UpdateCylinderColor();
						}
						else
						{
							if (Yandere.PickUp.Bucket.DyedBrown)
							{
								BrownPaint = true;
							}
							else if (Yandere.PickUp.Bucket.Bloodiness > 50f)
							{
								Blood = true;
							}
							else if (Yandere.PickUp.Bucket.Gasoline)
							{
								Gasoline = true;
							}
							else
							{
								Water = true;
							}
							UpdateCylinderColor();
							Yandere.PickUp.Bucket.Empty();
						}
						Empty = false;
						Timer = 1f;
						Prompt.HideButton[0] = true;
					}
				}
				else
				{
					Prompt.HideButton[0] = true;
				}
			}
			else
			{
				Prompt.HideButton[0] = true;
			}
			Prompt.HideButton[1] = true;
		}
		else
		{
			if (!TrapSet)
			{
				bool flag = false;
				if ((Yandere.Armed && Yandere.EquippedWeapon.Type == WeaponType.Knife) || (Yandere.Weapon[1] != null && Yandere.Weapon[1].Type == WeaponType.Knife) || (Yandere.Weapon[2] != null && Yandere.Weapon[2].Type == WeaponType.Knife))
				{
					flag = true;
				}
				if (Yandere.Inventory.String && Yandere.Inventory.MaskingTape && flag)
				{
					Prompt.HideButton[1] = false;
					Prompt.Label[1].applyGradient = false;
					Prompt.Label[1].color = Color.red;
					if (SchemeGlobals.GetSchemeStage(1) == 2 || SchemeGlobals.GetSchemeStage(2) == 2)
					{
						SchemeGlobals.SetSchemeStage(SchemeGlobals.CurrentScheme, SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) + 1);
						Yandere.PauseScreen.Schemes.UpdateInstructions();
					}
					if (Prompt.Circle[1].fillAmount == 0f)
					{
						Prompt.Circle[1].fillAmount = 1f;
						if (base.transform.position.y < 0.1f || (base.transform.position.y > 3.9f && base.transform.position.y < 4.1f) || (base.transform.position.y > 7.9f && base.transform.position.y < 8.1f) || (base.transform.position.y > 11.9f && base.transform.position.y < 12.1f))
						{
							CheckForWallInFront();
							if (TooCloseToWall)
							{
								Yandere.NotificationManager.CustomText = "Too close to wall!";
								Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
							}
							else
							{
								Yandere.SuspiciousActionTimer = 1f;
								Yandere.CreatingTripwireTrap = true;
								SetTrap();
							}
						}
						else
						{
							Yandere.NotificationManager.CustomText = "Set it on the ground!";
							Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
					}
				}
				else
				{
					Prompt.HideButton[1] = true;
					Prompt.Label[1].applyGradient = true;
					Prompt.Label[1].gradientTop = OriginalColor[0];
					Prompt.Label[1].gradientBottom = OriginalColor[1];
				}
			}
			else if (Prompt.Circle[1].fillAmount == 0f)
			{
				Prompt.Circle[1].fillAmount = 1f;
				Prompt.Label[1].text = "     Create Tripwire Trap";
				Prompt.Label[1].applyGradient = false;
				Prompt.Label[1].color = Color.red;
				TripwireTrap.SetActive(false);
				TrapSet = false;
				Prompt.HideButton[3] = false;
				PickUp.enabled = true;
				MyRigidbody.isKinematic = false;
			}
			if (Yandere.YandereVision && !Empty)
			{
				UpdateCylinderColor();
			}
		}
		if (Timer > 0f)
		{
			Timer = Mathf.MoveTowards(Timer, 0f, Time.deltaTime);
			if (Empty)
			{
				Cylinder.localScale = Vector3.Lerp(Cylinder.localScale, new Vector3(1f, 0f, 1f), Time.deltaTime * 10f);
			}
			else
			{
				Cylinder.localScale = Vector3.Lerp(Cylinder.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			}
		}
		if ((Prompt.enabled && Prompt.DistanceSqr < 1f) || (!Prompt.enabled && Vector3.Distance(base.transform.position, Yandere.transform.position) < 1f))
		{
			if (WaterCoolerChecklist.alpha < 1f)
			{
				WaterCoolerChecklist.alpha = Mathf.MoveTowards(WaterCoolerChecklist.alpha, 1f, Time.deltaTime * 10f);
				if (SchemeGlobals.GetSchemeStage(1) == 1 || SchemeGlobals.GetSchemeStage(2) == 1)
				{
					SchemeGlobals.SetSchemeStage(SchemeGlobals.CurrentScheme, SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) + 1);
					Yandere.PauseScreen.Schemes.UpdateInstructions();
				}
			}
			bool flag2 = false;
			if ((Yandere.Armed && Yandere.EquippedWeapon.Type == WeaponType.Knife) || (Yandere.Weapon[1] != null && Yandere.Weapon[1].Type == WeaponType.Knife) || (Yandere.Weapon[2] != null && Yandere.Weapon[2].Type == WeaponType.Knife))
			{
				flag2 = true;
			}
			WeaponCheckmark.spriteName = (flag2 ? "Yes" : "No");
			TapeCheckmark.spriteName = (Yandere.Inventory.MaskingTape ? "Yes" : "No");
			ThreadCheckmark.spriteName = (Yandere.Inventory.String ? "Yes" : "No");
			LiquidCheckmark.spriteName = ((!Empty) ? "Yes" : "No");
		}
		else if (WaterCoolerChecklist.alpha > 0f)
		{
			WaterCoolerChecklist.alpha = Mathf.MoveTowards(WaterCoolerChecklist.alpha, 0f, Time.deltaTime * 10f);
		}
	}

	public void UpdateCylinderColor()
	{
		if (BrownPaint)
		{
			CylinderRenderer.material.color = new Color(0.5f, 0.25f, 0f, 1f);
		}
		else if (Blood)
		{
			CylinderRenderer.material.color = new Color(1f, 0f, 0f, 1f);
		}
		else if (Gasoline)
		{
			CylinderRenderer.material.color = new Color(1f, 1f, 0f, 1f);
		}
		else
		{
			CylinderRenderer.material.color = new Color(0f, 1f, 1f, 1f);
		}
	}

	private void CheckForWallInFront()
	{
		StringTrapParent.localScale = new Vector3(1f, 1f, 1f);
		TooCloseToWall = false;
		Debug.Log("Checking for a wall in front of this object.");
		Transform transform = base.transform;
		Vector3 vector = base.transform.TransformDirection(base.transform.worldToLocalMatrix.MultiplyVector(base.transform.forward));
		Debug.DrawRay(transform.position + Vector3.up, vector, Color.red);
		RaycastHit hitInfo;
		if (Physics.Raycast(transform.position + Vector3.up, vector, out hitInfo, float.PositiveInfinity, Yandere.StudentManager.Students[1].OnlyDefault))
		{
			float num = Vector3.Distance(transform.position + Vector3.up, hitInfo.point);
			Debug.Log("There is a wall " + num + " meters away.");
			if (num > 3.5f)
			{
				StringTrapParent.localScale = new Vector3(1f, 1f, 1f);
			}
			else if (num > 2.5f)
			{
				StringTrapParent.localScale = new Vector3(1f, 1f, 0.75f);
			}
			else if (num > 1.5f)
			{
				StringTrapParent.localScale = new Vector3(1f, 1f, 0.5f);
			}
			else if (num > 0.5f)
			{
				StringTrapParent.localScale = new Vector3(1f, 1f, 0.25f);
			}
			else
			{
				TooCloseToWall = true;
			}
		}
	}

	public void SetTrap()
	{
		Prompt.Label[1].text = "     Remove Trap";
		Prompt.Label[1].applyGradient = true;
		Prompt.Label[1].gradientTop = OriginalColor[0];
		Prompt.Label[1].gradientBottom = OriginalColor[1];
		Prompt.Label[1].color = Color.white;
		TripwireTrap.SetActive(true);
		TrapSet = true;
		Prompt.HideButton[1] = false;
		Prompt.HideButton[3] = true;
		PickUp.enabled = false;
		MyRigidbody.isKinematic = true;
	}
}
