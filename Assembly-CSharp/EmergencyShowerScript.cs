using UnityEngine;

public class EmergencyShowerScript : MonoBehaviour
{
	public FoldedUniformScript CleanUniform;

	public SkinnedMeshRenderer Curtain;

	public TallLockerScript TallLocker;

	public GameObject CensorSteam;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Transform BatheSpot;

	public float OpenValue;

	public float Timer;

	public int Phase = 1;

	public bool Bathing;

	public AudioSource MyAudio;

	public AudioClip CurtainClose;

	public AudioClip CurtainOpen;

	public AudioClip ClothRustle;

	private void Update()
	{
		if ((Yandere.Schoolwear == 2 && Yandere.Bloodiness > 0f) || (Yandere.Schoolwear != 2 && Yandere.Bloodiness > 0f && Yandere.PickUp != null && Yandere.PickUp.Clothing && !Yandere.PickUp.Evidence && Yandere.PickUp.Gloves == null && Yandere.PickUp.GetComponent<FoldedUniformScript>() != null && !Yandere.PickUp.GetComponent<FoldedUniformScript>().ClubAttire))
		{
			Prompt.HideButton[0] = false;
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				if (!Yandere.Chased && Yandere.Chasers == 0)
				{
					Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
					Yandere.CannotBeSprayed = true;
					Yandere.CanMove = false;
					if (Yandere.PickUp != null)
					{
						CleanUniform = Yandere.PickUp.gameObject.GetComponent<FoldedUniformScript>();
						Yandere.EmptyHands();
						CleanUniform.transform.position = base.transform.position + base.transform.up + base.transform.forward * 1.5f;
					}
					AudioSource.PlayClipAtPoint(CurtainClose, base.transform.position);
					Bathing = true;
					Phase = 1;
					Timer = 0f;
				}
			}
		}
		else
		{
			Prompt.HideButton[0] = true;
		}
		if (!Bathing)
		{
			return;
		}
		Timer += Time.deltaTime;
		if (Phase == 1)
		{
			Yandere.MoveTowardsTarget(BatheSpot.position);
			Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, BatheSpot.rotation, 10f * Time.deltaTime);
			OpenValue = Mathf.Lerp(OpenValue, 0f, Time.deltaTime * 10f);
			Curtain.SetBlendShapeWeight(1, OpenValue);
			if (!(Timer > 1f))
			{
				return;
			}
			if (Yandere.Schoolwear != 2)
			{
				PickUpScript component;
				if (Yandere.ClubAttire)
				{
					Debug.Log("Player was wearing club attire when entered shower.");
					component = Object.Instantiate(TallLocker.BloodyClubUniform[(int)Yandere.Club], Yandere.transform.position + Yandere.transform.forward + Yandere.transform.right * -0.5f, Quaternion.identity).GetComponent<PickUpScript>();
					Yandere.StudentManager.ChangingBooths[(int)Yandere.Club].CannotChange = true;
					Yandere.StudentManager.ChangingBooths[(int)Yandere.Club].CheckYandereClub();
				}
				else
				{
					component = Object.Instantiate(TallLocker.BloodyUniform[Yandere.Schoolwear], Yandere.transform.position + Yandere.transform.forward + Yandere.transform.right * -0.5f, Quaternion.identity).GetComponent<PickUpScript>();
				}
				AudioSource.PlayClipAtPoint(ClothRustle, base.transform.position);
				if (Yandere.RedPaint)
				{
					component.RedPaint = true;
				}
			}
			else
			{
				Timer += 1f;
			}
			Phase++;
		}
		else if (Phase == 2)
		{
			if (Timer > 2f)
			{
				CensorSteam.SetActive(true);
				MyAudio.Play();
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			if (Timer > 6.5f)
			{
				if (Yandere.Schoolwear != 2)
				{
					CleanUniform.Prompt.Hide();
					Object.Destroy(CleanUniform.gameObject);
					Yandere.StudentManager.NewUniforms--;
					Yandere.ClubAttire = false;
					Yandere.Schoolwear = 1;
					Yandere.ChangeSchoolwear();
					AudioSource.PlayClipAtPoint(ClothRustle, base.transform.position);
				}
				else
				{
					Yandere.Police.BloodyClothing--;
					Timer += 1f;
				}
				Yandere.Bloodiness = 0f;
				Phase++;
			}
		}
		else if (Phase == 4)
		{
			if (Timer > 7.5f)
			{
				AudioSource.PlayClipAtPoint(CurtainOpen, base.transform.position);
				Phase++;
			}
		}
		else
		{
			OpenValue = Mathf.Lerp(OpenValue, 100f, Time.deltaTime * 10f);
			Curtain.SetBlendShapeWeight(1, OpenValue);
			if (Timer > 8.5f)
			{
				Debug.Log("As of now, # of OriginalUniforms is: " + Yandere.StudentManager.OriginalUniforms + " and # of NewUniforms is: " + Yandere.StudentManager.NewUniforms);
				CensorSteam.SetActive(false);
				Yandere.CannotBeSprayed = false;
				Yandere.CanMove = true;
				Bathing = false;
			}
		}
	}
}
