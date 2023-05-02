using UnityEngine;

public class DemonScript : MonoBehaviour
{
	public SkinnedMeshRenderer Face;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public UILabel DemonSubtitle;

	public UISprite Darkness;

	public UISprite Button;

	public AudioClip MouthOpen;

	public AudioClip MouthClose;

	public AudioClip[] Clips;

	public string[] Lines;

	public bool Communing;

	public bool Open;

	public float Intensity = 1f;

	public float Value;

	public Color MyColor;

	public int DemonID;

	public int Phase = 1;

	public int ID;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Yandere.Character.GetComponent<Animation>().CrossFade(Yandere.IdleAnim);
			Yandere.CanMove = false;
			Communing = true;
		}
		if (DemonID == 1)
		{
			if ((double)Vector3.Distance(Yandere.transform.position, base.transform.position) < 2.5)
			{
				if (!Open)
				{
					AudioSource.PlayClipAtPoint(MouthOpen, base.transform.position);
				}
				Open = true;
			}
			else
			{
				if (Open)
				{
					AudioSource.PlayClipAtPoint(MouthClose, base.transform.position);
				}
				Open = false;
			}
			if (Open)
			{
				Value = Mathf.Lerp(Value, 100f, Time.deltaTime * 10f);
			}
			else
			{
				Value = Mathf.Lerp(Value, 0f, Time.deltaTime * 10f);
			}
			Face.SetBlendShapeWeight(0, Value);
		}
		if (!Communing)
		{
			return;
		}
		AudioSource component = GetComponent<AudioSource>();
		if (Phase == 1)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
			if (Darkness.color.a == 1f)
			{
				DemonSubtitle.transform.localPosition = Vector3.zero;
				DemonSubtitle.text = Lines[ID];
				DemonSubtitle.color = MyColor;
				DemonSubtitle.color = new Color(DemonSubtitle.color.r, DemonSubtitle.color.g, DemonSubtitle.color.b, 0f);
				Phase++;
				if (Clips[ID] != null)
				{
					component.clip = Clips[ID];
					component.Play();
				}
			}
		}
		else if (Phase == 2)
		{
			DemonSubtitle.transform.localPosition = new Vector3(Random.Range(0f - Intensity, Intensity), Random.Range(0f - Intensity, Intensity), Random.Range(0f - Intensity, Intensity));
			DemonSubtitle.color = new Color(DemonSubtitle.color.r, DemonSubtitle.color.g, DemonSubtitle.color.b, Mathf.MoveTowards(DemonSubtitle.color.a, 1f, Time.deltaTime));
			Button.color = new Color(Button.color.r, Button.color.g, Button.color.b, Mathf.MoveTowards(Button.color.a, 1f, Time.deltaTime));
			if (DemonSubtitle.color.a > 0.9f && Input.GetButtonDown(InputNames.Xbox_A))
			{
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			DemonSubtitle.transform.localPosition = new Vector3(Random.Range(0f - Intensity, Intensity), Random.Range(0f - Intensity, Intensity), Random.Range(0f - Intensity, Intensity));
			DemonSubtitle.color = new Color(DemonSubtitle.color.r, DemonSubtitle.color.g, DemonSubtitle.color.b, Mathf.MoveTowards(DemonSubtitle.color.a, 0f, Time.deltaTime));
			if (DemonSubtitle.color.a != 0f)
			{
				return;
			}
			ID++;
			if (ID < Lines.Length)
			{
				Phase--;
				DemonSubtitle.text = Lines[ID];
				if (Clips[ID] != null)
				{
					component.clip = Clips[ID];
					component.Play();
				}
			}
			else
			{
				Phase++;
			}
		}
		else
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
			Button.color = new Color(Button.color.r, Button.color.g, Button.color.b, Mathf.MoveTowards(Button.color.a, 0f, Time.deltaTime));
			if (Darkness.color.a == 0f)
			{
				Yandere.CanMove = true;
				Communing = false;
				Phase = 1;
				ID = 0;
				SchoolGlobals.SetDemonActive(DemonID, value: true);
				StudentGlobals.FemaleUniform = 1;
				StudentGlobals.MaleUniform = 1;
				GameGlobals.Paranormal = true;
			}
		}
	}
}
