using UnityEngine;

public class HenshinScript : MonoBehaviour
{
	public RiggedAccessoryAttacher MiyukiCostume;

	public SkinnedMeshRenderer MiyukiRenderer;

	public Renderer WhiteMiyukiRenderer;

	public Renderer MiyukiHairRenderer;

	public Renderer White;

	public Animation WhiteMiyukiAnim;

	public Animation MiyukiAnim;

	public GameObject HenshinSparkleBlast;

	public GameObject MiyukiHair;

	public ParticleSystem HenshinSparkles;

	public ParticleSystem SpinSparkles;

	public ParticleSystem Sparkles;

	public AudioListener Listener;

	public YandereScript Yandere;

	public GameObject[] Cameras;

	public Camera MiyukiCamera;

	public Transform RightHand;

	public Transform Miyuki;

	public Transform Wand;

	public Transform TV;

	public float Rotation;

	public float Timer;

	public int Phase;

	public Texture MiyukiFace;

	public Texture MiyukiSkin;

	public Mesh NudeMesh;

	public Texture OriginalBody;

	public Texture OriginalFace;

	public Mesh OriginalMesh;

	public bool TransformingYandere;

	public bool Debugging;

	public Quaternion OriginalRotation;

	public Vector3 OriginalPosition;

	public AudioSource MyAudio;

	public AudioClip Catchphrase;

	public void TransformYandere()
	{
		TransformingYandere = true;
		Cameras[1].SetActive(value: false);
		Cameras[2].SetActive(value: false);
		Cameras[3].SetActive(value: false);
		Cameras[4].SetActive(value: false);
		Cameras[5].SetActive(value: false);
		Cameras[6].SetActive(value: false);
		MiyukiCamera.targetTexture = null;
		MiyukiCamera.enabled = true;
		Listener.enabled = true;
		OriginalPosition = Yandere.transform.position;
		OriginalRotation = Yandere.transform.rotation;
		Yandere.CharacterAnimation.Play("f02_henshin_00");
		Yandere.transform.parent = Miyuki;
		Yandere.enabled = false;
		Yandere.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		Yandere.transform.localPosition = new Vector3(0f, 0f, 0f);
		Yandere.Accessories[Yandere.AccessoryID].SetActive(value: false);
		Physics.SyncTransforms();
		AudioSource.PlayClipAtPoint(Catchphrase, base.transform.position);
		MyAudio.Play();
		Start();
	}

	private void Start()
	{
		if (OriginalMesh == null)
		{
			OriginalMesh = MiyukiRenderer.sharedMesh;
			OriginalFace = MiyukiRenderer.materials[0].mainTexture;
			OriginalBody = MiyukiRenderer.materials[1].mainTexture;
		}
		MiyukiRenderer.sharedMesh = OriginalMesh;
		MiyukiRenderer.materials[0].mainTexture = OriginalFace;
		MiyukiRenderer.materials[1].mainTexture = OriginalBody;
		MiyukiRenderer.materials[2].mainTexture = OriginalBody;
		MiyukiHairRenderer.material.color = new Color(1f, 1f, 1f, 0f);
		WhiteMiyukiRenderer.materials[0].color = new Color(1f, 1f, 1f, 0f);
		WhiteMiyukiRenderer.materials[1].color = new Color(1f, 1f, 1f, 0f);
		WhiteMiyukiRenderer.materials[2].color = new Color(1f, 1f, 1f, 0f);
		Wand.gameObject.SetActive(value: true);
		Wand.transform.parent = base.transform.parent;
		Wand.localPosition = new Vector3(0f, -0.6538f, 0.04405f);
		White.material.color = new Color(1f, 1f, 1f, 1f);
		Miyuki.gameObject.SetActive(value: false);
		if (MiyukiCostume.newRenderer != null)
		{
			MiyukiCostume.newRenderer.enabled = false;
		}
		HenshinSparkleBlast.SetActive(value: false);
		HenshinSparkles.emissionRate = 1f;
		HenshinSparkles.Clear();
		HenshinSparkles.Stop();
		SpinSparkles.Clear();
		SpinSparkles.Stop();
		Sparkles.emissionRate = 1f;
		Sparkles.startSize = 0.1f;
		Sparkles.Clear();
		Sparkles.Stop();
		Rotation = 3600f;
		Timer = 0f;
		Phase = 1;
		if (Debugging)
		{
			Time.timeScale = 1f;
		}
	}

	private void Update()
	{
		if (TransformingYandere && Input.GetKeyDown("="))
		{
			MyAudio.pitch++;
			Time.timeScale += 1f;
		}
		if (TransformingYandere || Vector3.Distance(Yandere.transform.position, TV.position) < 15f)
		{
			MiyukiCamera.enabled = true;
			if (Phase < 3)
			{
				Wand.localPosition = Vector3.Lerp(Wand.localPosition, new Vector3(0f, -0.2833333f, 1f), Time.deltaTime);
				Rotation = Mathf.Lerp(Rotation, 0f, Time.deltaTime * 2f);
				Wand.localEulerAngles = new Vector3(-90f, 0f, Rotation);
			}
			if (Phase == 1)
			{
				White.material.color -= new Color(0f, 0f, 0f, Time.deltaTime);
				Timer += Time.deltaTime;
				if (Timer > 3f)
				{
					White.material.color = new Color(1f, 1f, 1f, 0f);
					Timer = 0f;
					Phase++;
				}
			}
			else if (Phase == 2)
			{
				if (!Sparkles.isPlaying)
				{
					Sparkles.Play();
				}
				Sparkles.startSize += Time.deltaTime * 0.25f;
				Sparkles.emissionRate += Time.deltaTime * 5f;
				Timer += Time.deltaTime;
				if (!(Timer > 3f))
				{
					return;
				}
				White.material.color += new Color(1f, 1f, 1f, Time.deltaTime);
				if (White.material.color.a >= 1f)
				{
					Miyuki.localEulerAngles = new Vector3(0f, 180f, 45f);
					Miyuki.localPosition = new Vector3(0f, 0f, 0.5f);
					Miyuki.gameObject.SetActive(value: true);
					Wand.gameObject.SetActive(value: false);
					if (TransformingYandere)
					{
						MiyukiHairRenderer.enabled = false;
						MiyukiRenderer.enabled = false;
						MiyukiHair.SetActive(value: false);
						Yandere.CharacterAnimation.Play("f02_henshin_00");
					}
					Sparkles.emissionRate = 1f;
					Sparkles.startSize = 0.1f;
					Sparkles.Clear();
					Sparkles.Stop();
					Timer = 0f;
					Phase++;
				}
			}
			else if (Phase == 3)
			{
				White.material.color -= new Color(0f, 0f, 0f, Time.deltaTime);
				Miyuki.localPosition -= new Vector3(Time.deltaTime * 0.1f, Time.deltaTime * 0.1f, 0f);
				Rotation += Time.deltaTime;
				Miyuki.Rotate(0f, Rotation * 360f * Time.deltaTime, 0f);
				Timer += Time.deltaTime;
				if (Timer > 2f)
				{
					if (!TransformingYandere)
					{
						float a = Timer - 2f;
						MiyukiHairRenderer.material.color = new Color(1f, 1f, 1f, a);
						WhiteMiyukiRenderer.materials[0].color = new Color(1f, 1f, 1f, a);
						WhiteMiyukiRenderer.materials[1].color = new Color(1f, 1f, 1f, a);
						WhiteMiyukiRenderer.materials[2].color = new Color(1f, 1f, 1f, a);
					}
					if (Timer > 5f)
					{
						Miyuki.localEulerAngles = new Vector3(0f, 180f, 0f);
						Miyuki.localPosition = new Vector3(0f, -0.795f, 2f);
						Timer = 0f;
						Phase++;
					}
				}
			}
			else if (Phase == 4)
			{
				Miyuki.Rotate(0f, Rotation * 360f * Time.deltaTime, 0f);
				Timer += Time.deltaTime;
				if (!(Timer > 1f))
				{
					return;
				}
				if (!HenshinSparkles.isPlaying)
				{
					HenshinSparkles.Play();
				}
				HenshinSparkles.emissionRate += Time.deltaTime * 100f;
				if (Timer > 5f)
				{
					Wand.gameObject.SetActive(value: true);
					Wand.parent = RightHand;
					Wand.localEulerAngles = new Vector3(0f, 0f, 90f);
					Wand.localPosition = new Vector3(0f, 0f, 0f);
					if (TransformingYandere)
					{
						MiyukiRenderer.enabled = true;
						Yandere.gameObject.SetActive(value: false);
					}
					MiyukiCostume.gameObject.SetActive(value: true);
					MiyukiHair.SetActive(value: true);
					if (MiyukiCostume.newRenderer != null)
					{
						MiyukiCostume.newRenderer.enabled = true;
					}
					MiyukiRenderer.sharedMesh = NudeMesh;
					MiyukiRenderer.materials[0].mainTexture = MiyukiFace;
					MiyukiRenderer.materials[1].mainTexture = MiyukiSkin;
					MiyukiRenderer.materials[2].mainTexture = MiyukiSkin;
					MiyukiHairRenderer.material.color = new Color(1f, 1f, 1f, 0f);
					WhiteMiyukiRenderer.materials[0].color = new Color(1f, 1f, 1f, 0f);
					WhiteMiyukiRenderer.materials[1].color = new Color(1f, 1f, 1f, 0f);
					WhiteMiyukiRenderer.materials[2].color = new Color(1f, 1f, 1f, 0f);
					Miyuki.localEulerAngles = new Vector3(15f, -135f, 15f);
					WhiteMiyukiAnim.Play("f02_miyukiPose_00");
					MiyukiAnim.Play("f02_miyukiPose_00");
					HenshinSparkleBlast.SetActive(value: true);
					HenshinSparkles.emissionRate = 1f;
					HenshinSparkles.Clear();
					HenshinSparkles.Stop();
					SpinSparkles.Clear();
					SpinSparkles.Stop();
					Timer = 0f;
					Phase++;
				}
			}
			else
			{
				if (Phase != 5)
				{
					return;
				}
				Timer += Time.deltaTime;
				if (!(Timer > 1f))
				{
					return;
				}
				White.material.color += new Color(0f, 0f, 0f, Time.deltaTime);
				if (White.material.color.a >= 1f)
				{
					if (TransformingYandere)
					{
						Cameras[1].SetActive(value: true);
						Cameras[2].SetActive(value: true);
						Cameras[3].SetActive(value: true);
						Cameras[4].SetActive(value: true);
						Cameras[5].SetActive(value: true);
						Cameras[6].SetActive(value: true);
						base.gameObject.SetActive(value: false);
						Yandere.transform.parent = null;
						Yandere.gameObject.SetActive(value: true);
						Yandere.transform.position = OriginalPosition;
						Yandere.transform.rotation = OriginalRotation;
						Yandere.Stance.Current = StanceType.Standing;
						Yandere.WeaponManager.Weapons[19].AnimID = 0;
						Yandere.SetAnimationLayers();
						Yandere.enabled = true;
						Yandere.CanMove = true;
						Yandere.Miyuki();
						base.transform.parent.gameObject.SetActive(value: false);
						Time.timeScale = 1f;
					}
					else
					{
						Start();
					}
				}
			}
		}
		else
		{
			MiyukiCamera.enabled = false;
		}
	}
}
