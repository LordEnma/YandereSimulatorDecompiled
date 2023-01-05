using UnityEngine;

public class FanCoverScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public NoteWindowScript NoteWindow;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public StudentScript Rival;

	public SM_rotateThis Fan;

	public ParticleSystem BloodEffects;

	public Projector BloodProjector;

	public Rigidbody MyRigidbody;

	public Transform MurderSpot;

	public GameObject Explosion;

	public GameObject OfferHelp;

	public GameObject Smoke;

	public AudioClip RivalReaction;

	public AudioSource FanSFX;

	public Texture[] YandereBloodTextures;

	public Texture[] BloodTexture;

	public ParticleSystem[] Particles;

	public bool Reacted;

	public float Timer;

	public int RivalID = 11;

	public int Phase;

	private void Start()
	{
		if (StudentManager.Eighties || StudentManager.Students[RivalID] == null)
		{
			Prompt.Hide();
			Prompt.enabled = false;
			base.enabled = false;
		}
		else
		{
			Rival = StudentManager.Students[RivalID];
		}
	}

	private void Update()
	{
		if (Vector3.Distance(base.transform.position, Yandere.transform.position) < 2f)
		{
			if (Yandere.Armed)
			{
				if (Yandere.EquippedWeapon.WeaponID == 6 && Rival.Meeting && Rival.DistanceToDestination < 0.1f && NoteWindow.MeetID == 9)
				{
					Prompt.HideButton[0] = false;
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
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Yandere.CharacterAnimation.CrossFade("f02_fanMurderA_00");
			Rival.CharacterAnimation.CrossFade("f02_fanMurderB_00");
			Rival.OsanaHair.GetComponent<Animation>().CrossFade("fanMurderHair");
			Rival.enabled = false;
			Yandere.EmptyHands();
			Rival.OsanaHair.transform.parent = Rival.transform;
			Rival.OsanaHair.transform.localEulerAngles = Vector3.zero;
			Rival.OsanaHair.transform.localPosition = Vector3.zero;
			Rival.OsanaHair.transform.localScale = new Vector3(1f, 1f, 1f);
			Rival.OsanaHairL.enabled = false;
			Rival.OsanaHairR.enabled = false;
			Rival.Distracted = true;
			Yandere.CanMove = false;
			Rival.Meeting = false;
			Rival.Blind = true;
			FanSFX.enabled = false;
			GetComponent<AudioSource>().Play();
			base.transform.localPosition = new Vector3(-1.733f, 0.465f, 0.952f);
			base.transform.localEulerAngles = new Vector3(-90f, 165f, 0f);
			Physics.SyncTransforms();
			Rigidbody component = GetComponent<Rigidbody>();
			component.isKinematic = false;
			component.useGravity = true;
			Prompt.enabled = false;
			Prompt.Hide();
			Phase++;
			if (GameGlobals.CensorBlood)
			{
				YandereBloodTextures = Yandere.FlowerTextures;
				BloodTexture = Yandere.FlowerTextures;
				Particles[1].gameObject.GetComponent<ParticleSystemRenderer>().material.mainTexture = Yandere.FlowerTextures[1];
				Particles[2].gameObject.GetComponent<ParticleSystemRenderer>().material.mainTexture = Yandere.FlowerTextures[1];
				Particles[3].gameObject.GetComponent<ParticleSystemRenderer>().material.mainTexture = Yandere.FlowerTextures[1];
				ParticleSystem.ColorOverLifetimeModule colorOverLifetime = Particles[1].colorOverLifetime;
				colorOverLifetime.enabled = false;
				colorOverLifetime = Particles[2].colorOverLifetime;
				colorOverLifetime.enabled = false;
				colorOverLifetime = Particles[3].colorOverLifetime;
				colorOverLifetime.enabled = false;
				Yandere.Blur.enabled = true;
				Yandere.Blur.Size = 1f;
			}
		}
		if (Phase <= 0)
		{
			return;
		}
		if (PlayerGlobals.PantiesEquipped == 10)
		{
			Yandere.Sanity -= Time.deltaTime * 5f * Yandere.Numbness;
		}
		else
		{
			Yandere.Sanity -= Time.deltaTime * 10f * Yandere.Numbness;
		}
		if (Phase == 1)
		{
			Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, MurderSpot.rotation, Time.deltaTime * 10f);
			Yandere.MoveTowardsTarget(MurderSpot.position);
			if (Yandere.CharacterAnimation["f02_fanMurderA_00"].time > 3.5f && !Reacted)
			{
				AudioSource.PlayClipAtPoint(RivalReaction, Rival.transform.position + new Vector3(0f, 1f, 0f));
				Yandere.MurderousActionTimer = 999f;
				Reacted = true;
			}
			if (Yandere.CharacterAnimation["f02_fanMurderA_00"].time > 5f)
			{
				Rival.LiquidProjector.material.mainTexture = Rival.BloodTexture;
				Rival.LiquidProjector.enabled = true;
				Rival.EyeShrink = 1f;
				Yandere.BloodTextures = YandereBloodTextures;
				Yandere.Bloodiness += 20f;
				if (!Yandere.NoStainGloves)
				{
					if (Yandere.Gloved && !Yandere.Gloves.Blood.enabled)
					{
						Yandere.GloveAttacher.newRenderer.material.mainTexture = Yandere.BloodyGloveTexture;
						Yandere.Gloves.PickUp.Evidence = true;
						Yandere.Gloves.Blood.enabled = true;
						Yandere.GloveBlood = 1;
						Yandere.Police.BloodyClothing++;
					}
					if (Yandere.Mask != null && !Yandere.Mask.Blood.enabled)
					{
						Yandere.Mask.PickUp.Evidence = true;
						Yandere.Mask.Blood.enabled = true;
						Yandere.Police.BloodyClothing++;
					}
				}
				BloodProjector.gameObject.SetActive(true);
				BloodProjector.material.mainTexture = BloodTexture[1];
				BloodEffects.transform.parent = Rival.Head;
				BloodEffects.transform.localPosition = new Vector3(0f, 0.1f, 0f);
				BloodEffects.Play();
				Phase++;
			}
			if (Yandere.Blur.enabled)
			{
				Yandere.Blur.Size = Mathf.MoveTowards(Yandere.Blur.Size, 10f, Time.deltaTime * 2f);
			}
		}
		else if (Phase < 10)
		{
			if (Phase < 6)
			{
				Timer += Time.deltaTime;
				if (Timer > 1f)
				{
					Phase++;
					if (Phase - 1 < 5)
					{
						BloodProjector.material.mainTexture = BloodTexture[Phase - 1];
						Yandere.Bloodiness += 20f;
						Timer = 0f;
					}
				}
			}
			if (Rival.CharacterAnimation["f02_fanMurderB_00"].time >= Rival.CharacterAnimation["f02_fanMurderB_00"].length)
			{
				BloodProjector.material.mainTexture = BloodTexture[5];
				Yandere.Bloodiness += 20f;
				Rival.Ragdoll.Decapitated = true;
				Rival.OsanaHair.SetActive(false);
				Rival.DeathType = DeathType.Weapon;
				Rival.BecomeRagdoll();
				BloodEffects.Stop();
				Explosion.SetActive(true);
				Smoke.SetActive(true);
				Fan.enabled = false;
				Phase = 10;
			}
		}
		else if (Yandere.CharacterAnimation["f02_fanMurderA_00"].time >= Yandere.CharacterAnimation["f02_fanMurderA_00"].length)
		{
			Yandere.Blur.Size = Mathf.MoveTowards(Yandere.Blur.Size, 0f, Time.deltaTime);
			Yandere.MurderousActionTimer = 0f;
			OfferHelp.SetActive(false);
			Yandere.CanMove = true;
			Yandere.Blur.Size = 0f;
			base.enabled = false;
		}
		else if (Yandere.CharacterAnimation["f02_fanMurderA_00"].time >= Yandere.CharacterAnimation["f02_fanMurderA_00"].length - 5f && Yandere.Blur.enabled)
		{
			Yandere.Blur.Size = Mathf.MoveTowards(Yandere.Blur.Size, 0f, Time.deltaTime * 2f);
		}
	}
}
