using UnityEngine;

public class ManholeScript : MonoBehaviour
{
	public GameObject BigSewerWaterSplash;

	public GameObject SewerCamera;

	public RagdollScript Corpse;

	public PromptScript Prompt;

	public AudioClip MoveCover;

	public float AnimateTimer;

	public float SewerTimer;

	public bool ForceDown;

	public bool Open;

	public int Victims;

	public int[] VictimList;

	private void Update()
	{
		if (!Open)
		{
			if (Prompt.Yandere.EquippedWeapon != null)
			{
				if (Prompt.Yandere.EquippedWeapon.WeaponID == 19 || Prompt.Yandere.EquippedWeapon.WeaponID == 29)
				{
					if (Prompt.Yandere.EquippedWeapon.WeaponID == 19)
					{
						Prompt.Text[0] = "Use Crowbar";
					}
					else
					{
						Prompt.Text[0] = "Use Tool";
					}
					if (Prompt.Circle[0].fillAmount == 0f)
					{
						Prompt.Circle[0].fillAmount = 1f;
						Prompt.Text[0] = "Dump Body";
						AudioSource.PlayClipAtPoint(MoveCover, base.transform.position);
						AnimateTimer = 1f;
						Open = true;
					}
				}
				else
				{
					Prompt.Text[0] = "Need Crowbar or Manhole Tool";
				}
			}
			else
			{
				Prompt.Text[0] = "Need Crowbar or Manhole Tool";
			}
			Prompt.Label[0].text = "     " + Prompt.Text[0];
			return;
		}
		if (AnimateTimer > 0f)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(34.1f, 0f, 24.1f), Time.deltaTime);
			AnimateTimer -= Time.deltaTime;
		}
		if (SewerTimer > 0f)
		{
			if (Corpse.Student.Hips.transform.position.y < -5f || ForceDown)
			{
				if (Corpse.Student.Hips.transform.position.y > -5f)
				{
					Debug.Log("Hey! Stay DOWN!");
					Corpse.Student.Hips.transform.position = new Vector3(Corpse.Student.Hips.transform.position.x, -5f, Corpse.Student.Hips.transform.position.z);
					MakeRigidbodiesUseGravity();
				}
				if (Corpse.AllRigidbodies[0].useGravity)
				{
					Debug.Log("This corpse just struck the water.");
					Object.Instantiate(BigSewerWaterSplash, Corpse.Student.Hips.transform.position, Quaternion.identity).transform.eulerAngles = new Vector3(-90f, 0f, 0f);
					MakeRigidbodiesUseGravity();
					ForceDown = true;
				}
				Debug.Log("The corpse is now being pushed downstream.");
				Corpse.AllRigidbodies[0].AddForce(new Vector3(-100f, -50f, 0f));
			}
			SewerTimer -= Time.deltaTime;
			if (SewerTimer <= 0f)
			{
				Debug.Log("We're done watching the corpse, and we are now returning to gameplay.");
				if (Corpse.Concealed)
				{
					Prompt.Yandere.Police.HiddenCorpses--;
				}
				Prompt.Yandere.Police.Corpses--;
				Corpse.gameObject.SetActive(value: false);
				Corpse.Student.Removed = true;
				Corpse.Disposed = true;
				if (Corpse.StudentID == Prompt.Yandere.StudentManager.RivalID)
				{
					Debug.Log("Just dumped Osana's corpse into the sewer.");
					Prompt.Yandere.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Vanished;
				}
				Victims++;
				VictimList[Victims] = Corpse.StudentID;
				SewerCamera.SetActive(value: false);
				Prompt.Yandere.StudentManager.UpdateStudents();
				ForceDown = false;
				Prompt.Yandere.CanMove = true;
				if (Corpse.Drowned)
				{
					Prompt.Yandere.Police.DrownVictims--;
				}
			}
		}
		if (Prompt.Yandere.Ragdoll != null)
		{
			Prompt.Label[0].text = "     Dump Body";
			Prompt.HideButton[0] = false;
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				Debug.Log("The player has just dumped a corpse.");
				Corpse = Prompt.Yandere.Ragdoll.GetComponent<RagdollScript>();
				Prompt.Yandere.EmptyHands();
				Corpse.Student.Hips.transform.position = base.transform.position + new Vector3(0f, -1f, 0f);
				Corpse.BloodPoolSpawner.enabled = false;
				if (Corpse.Student.Cosmetic.BurlapSack != null && Corpse.Student.Cosmetic.BurlapSack.newRenderer != null)
				{
					Corpse.Student.Cosmetic.BurlapSack.newRenderer.updateWhenOffscreen = true;
				}
				Physics.SyncTransforms();
				SewerCamera.SetActive(value: true);
				SewerTimer = 5f;
				if (Prompt.Yandere.YandereVision)
				{
					Prompt.Yandere.ResetYandereEffects();
					Prompt.Yandere.YandereVision = false;
				}
				Prompt.Yandere.CanMove = false;
			}
		}
		else if ((Prompt.Yandere.Armed && Prompt.Yandere.EquippedWeapon.Evidence) || (Prompt.Yandere.Armed && Prompt.Yandere.EquippedWeapon.Bloody) || (Prompt.Yandere.Armed && Prompt.Yandere.EquippedWeapon.MurderWeapon) || (Prompt.Yandere.PickUp != null && Prompt.Yandere.PickUp.Evidence) || (Prompt.Yandere.PickUp != null && Prompt.Yandere.PickUp.ConcealedBodyPart))
		{
			Prompt.Label[0].text = "     Dump Evidence";
			Prompt.HideButton[0] = false;
			if (Prompt.Circle[0].fillAmount != 0f)
			{
				return;
			}
			Prompt.Circle[0].fillAmount = 1f;
			if (Prompt.Yandere.Armed)
			{
				Debug.Log("Attempting to dispose of weapon.");
				WeaponScript equippedWeapon = Prompt.Yandere.EquippedWeapon;
				Prompt.Yandere.DropSpecifically = true;
				Prompt.Yandere.EmptyHands();
				Prompt.Yandere.Police.BloodyWeapons--;
				equippedWeapon.Disposed = true;
				equippedWeapon.gameObject.SetActive(value: false);
				Prompt.Yandere.DropSpecifically = false;
				return;
			}
			PickUpScript pickUp = Prompt.Yandere.PickUp;
			Prompt.Yandere.EmptyHands();
			if (pickUp.Clothing)
			{
				Prompt.Yandere.Police.BloodyClothing--;
			}
			if (pickUp.ConcealedBodyPart)
			{
				Prompt.Yandere.Police.BodyParts--;
			}
			Object.Destroy(pickUp.gameObject);
		}
		else
		{
			Prompt.HideButton[0] = true;
		}
	}

	public void MakeRigidbodiesUseGravity()
	{
		for (int i = 0; i < Corpse.AllRigidbodies.Length; i++)
		{
			Corpse.AllRigidbodies[i].useGravity = false;
		}
	}
}
