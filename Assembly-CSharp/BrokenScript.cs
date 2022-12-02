using UnityEngine;

public class BrokenScript : MonoBehaviour
{
	public DynamicBone[] HairPhysics;

	public string[] MutterTexts;

	public AudioClip[] Mutters;

	public Vector3 PermanentAngleR;

	public Vector3 PermanentAngleL;

	public Transform TwintailR;

	public Transform TwintailL;

	public AudioClip KillKillKill;

	public AudioClip Stab;

	public AudioClip DoIt;

	public GameObject VoiceClip;

	public GameObject Yandere;

	public UILabel Subtitle;

	public AudioSource MyAudio;

	public bool Hunting;

	public bool Stabbed;

	public bool Began;

	public bool Done;

	public float SuicideTimer;

	public float Timer;

	public int ID = 1;

	private void Start()
	{
		HairPhysics[0].enabled = false;
		HairPhysics[1].enabled = false;
		PermanentAngleR = TwintailR.eulerAngles;
		PermanentAngleL = TwintailL.eulerAngles;
		Subtitle = GameObject.Find("EventSubtitle").GetComponent<UILabel>();
		Yandere = GameObject.Find("YandereChan");
	}

	private void Update()
	{
		if (!Done)
		{
			float num = Vector3.Distance(Yandere.transform.position, base.transform.root.position);
			if (num < 6f)
			{
				if (num < 5f)
				{
					if (!Hunting)
					{
						Timer += Time.deltaTime;
						if (VoiceClip == null)
						{
							Subtitle.text = "";
						}
						if (Timer > 5f)
						{
							Timer = 0f;
							Subtitle.text = MutterTexts[ID];
							AudioClipPlayer.PlayAttached(Mutters[ID], base.transform.position, base.transform, 1f, 5f, out VoiceClip, Yandere.transform.position.y);
							ID++;
							if (ID == Mutters.Length)
							{
								ID = 1;
							}
						}
					}
					else if (!Began)
					{
						if (VoiceClip != null)
						{
							Object.Destroy(VoiceClip);
						}
						Subtitle.text = "Do it.";
						AudioClipPlayer.PlayAttached(DoIt, base.transform.position, base.transform, 1f, 5f, out VoiceClip, Yandere.transform.position.y);
						Began = true;
					}
					else if (VoiceClip == null)
					{
						Subtitle.text = "...kill...kill...kill...";
						AudioClipPlayer.PlayAttached(KillKillKill, base.transform.position, base.transform, 1f, 5f, out VoiceClip, Yandere.transform.position.y);
					}
					float num2 = Mathf.Abs((num - 5f) * 0.2f);
					num2 = ((num2 > 1f) ? 1f : num2);
					Subtitle.transform.localScale = new Vector3(num2, num2, num2);
				}
				else
				{
					Subtitle.transform.localScale = Vector3.zero;
				}
			}
		}
		Vector3 eulerAngles = TwintailR.eulerAngles;
		Vector3 eulerAngles2 = TwintailL.eulerAngles;
		eulerAngles.x = PermanentAngleR.x;
		eulerAngles.z = PermanentAngleR.z;
		eulerAngles2.x = PermanentAngleL.x;
		eulerAngles2.z = PermanentAngleL.z;
		TwintailR.eulerAngles = eulerAngles;
		TwintailL.eulerAngles = eulerAngles2;
	}
}
