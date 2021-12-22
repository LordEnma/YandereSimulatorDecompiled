using System;
using UnityEngine;

// Token: 0x020002DB RID: 731
public class GenericBentoScript : MonoBehaviour
{
	// Token: 0x060014D0 RID: 5328 RVA: 0x000CDAE8 File Offset: 0x000CBCE8
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f || this.Prompt.Circle[1].fillAmount == 0f || this.Prompt.Circle[2].fillAmount == 0f || this.Prompt.Circle[3].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
			if (!this.Prompt.Yandere.StudentManager.YandereVisible)
			{
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					if (this.Prompt.Yandere.Inventory.EmeticPoison)
					{
						this.Prompt.Yandere.Inventory.EmeticPoison = false;
						this.Prompt.Yandere.PoisonType = 1;
					}
					else
					{
						this.Prompt.Yandere.Inventory.RatPoison = false;
						this.Prompt.Yandere.PoisonType = 3;
					}
					this.Emetic = true;
					this.ShutOff();
					return;
				}
				if (this.Prompt.Circle[1].fillAmount == 0f)
				{
					if (this.Prompt.Yandere.Inventory.Sedative)
					{
						this.Prompt.Yandere.Inventory.Sedative = false;
					}
					else
					{
						this.Prompt.Yandere.Inventory.Tranquilizer = false;
					}
					this.Prompt.Yandere.PoisonType = 4;
					this.Tranquil = true;
					this.ShutOff();
					return;
				}
				if (this.Prompt.Circle[2].fillAmount == 0f)
				{
					if (this.Prompt.Yandere.Inventory.LethalPoison)
					{
						this.Prompt.Yandere.Inventory.LethalPoisons--;
						if (this.Prompt.Yandere.Inventory.LethalPoisons == 0)
						{
							this.Prompt.Yandere.Inventory.LethalPoison = false;
						}
						this.Prompt.Yandere.PoisonType = 2;
					}
					else
					{
						this.Prompt.Yandere.Inventory.ChemicalPoison = false;
						this.Prompt.Yandere.PoisonType = 2;
					}
					this.Lethal = true;
					this.ShutOff();
					return;
				}
				if (this.Prompt.Circle[3].fillAmount == 0f)
				{
					this.Prompt.Yandere.Inventory.HeadachePoison = false;
					this.Prompt.Yandere.PoisonType = 5;
					this.Headache = true;
					this.ShutOff();
					return;
				}
			}
			else
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				this.Prompt.Circle[1].fillAmount = 1f;
				this.Prompt.Circle[2].fillAmount = 1f;
				this.Prompt.Circle[3].fillAmount = 1f;
				this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
				this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
	}

	// Token: 0x060014D1 RID: 5329 RVA: 0x000CDE3C File Offset: 0x000CC03C
	private void ShutOff()
	{
		Debug.Log("Shutting off a bento. This bento should be inaccessible from now on...");
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, base.transform.position, Quaternion.identity);
		this.PoisonSpot = gameObject.transform;
		this.PoisonSpot.position = new Vector3(this.PoisonSpot.position.x, this.Prompt.Yandere.transform.position.y, this.PoisonSpot.position.z);
		this.PoisonSpot.LookAt(this.Prompt.Yandere.transform.position);
		this.PoisonSpot.Translate(Vector3.forward * 0.25f);
		this.Prompt.Yandere.CharacterAnimation["f02_poisoning_00"].speed = 2f;
		this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
		this.Prompt.Yandere.StudentManager.UpdateAllBentos();
		this.Prompt.Yandere.TargetBento = this;
		this.Prompt.Yandere.Poisoning = true;
		this.Prompt.Yandere.CanMove = false;
		this.Tampered = true;
		base.enabled = false;
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x060014D2 RID: 5330 RVA: 0x000CDFAC File Offset: 0x000CC1AC
	public void UpdatePrompts()
	{
		if (!this.Tampered)
		{
			this.Prompt.HideButton[0] = true;
			this.Prompt.HideButton[1] = true;
			this.Prompt.HideButton[2] = true;
			this.Prompt.HideButton[3] = true;
			if (this.Prompt.Yandere.Inventory.EmeticPoison || this.Prompt.Yandere.Inventory.RatPoison)
			{
				this.Prompt.HideButton[0] = false;
			}
			if (this.Prompt.Yandere.Inventory.Tranquilizer || this.Prompt.Yandere.Inventory.Sedative)
			{
				this.Prompt.HideButton[1] = false;
			}
			if (this.Prompt.Yandere.Inventory.LethalPoison || this.Prompt.Yandere.Inventory.ChemicalPoison)
			{
				this.Prompt.HideButton[2] = false;
			}
			if (this.Prompt.Yandere.Inventory.HeadachePoison)
			{
				this.Prompt.HideButton[3] = false;
			}
			this.Prompt.Yandere.EmptyHands();
		}
	}

	// Token: 0x040020DB RID: 8411
	public GameObject EmptyGameObject;

	// Token: 0x040020DC RID: 8412
	public GameObject Lid;

	// Token: 0x040020DD RID: 8413
	public Transform PoisonSpot;

	// Token: 0x040020DE RID: 8414
	public PromptScript Prompt;

	// Token: 0x040020DF RID: 8415
	public bool Emetic;

	// Token: 0x040020E0 RID: 8416
	public bool Tranquil;

	// Token: 0x040020E1 RID: 8417
	public bool Headache;

	// Token: 0x040020E2 RID: 8418
	public bool Lethal;

	// Token: 0x040020E3 RID: 8419
	public bool Tampered;

	// Token: 0x040020E4 RID: 8420
	public int StudentID;
}
