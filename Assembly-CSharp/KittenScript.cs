using UnityEngine;

public class KittenScript : MonoBehaviour
{
	public Animation MyAnimator;

	public YandereScript Yandere;

	public GameObject Character;

	public Renderer MyRenderer;

	public string[] AnimationNames;

	public Transform Target;

	public Transform Head;

	public string CurrentAnim = string.Empty;

	public string IdleAnim = string.Empty;

	public Texture EightiesCat;

	public bool Wait;

	public float Timer;

	public AudioClip[] MyLines;

	public AudioClip[] MemeLines;

	public AudioClip[] NormalLines;

	public AudioSource MyAudio;

	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			MyRenderer.material.mainTexture = EightiesCat;
		}
	}

	private void LateUpdate()
	{
		if (!(Vector3.Distance(base.transform.position, Yandere.transform.position) < 5f))
		{
			return;
		}
		if (Vector3.Distance(base.transform.position, Yandere.transform.position) < 1f)
		{
			Timer += Time.deltaTime;
			if (Timer > 5f)
			{
				int num = Random.Range(1, 101);
				if (num == 1)
				{
					int num2 = Random.Range(0, MyLines.Length);
					MyAudio.clip = MyLines[num2];
				}
				else if (num <= 10)
				{
					int num3 = Random.Range(0, MemeLines.Length);
					MyAudio.clip = MemeLines[num3];
				}
				else
				{
					int num4 = Random.Range(0, NormalLines.Length);
					MyAudio.clip = NormalLines[num4];
				}
				MyAudio.Play();
				Timer = 0f;
			}
		}
		if (Yandere.StudentManager.Eighties && Yandere.StudentManager.Week > 2 && Yandere.StudentManager.Students[11] != null && Yandere.StudentManager.Students[11].Routine && Vector3.Distance(base.transform.position, Yandere.StudentManager.Students[11].transform.position) < 1f)
		{
			MyAnimator.CrossFade("beingPet");
			return;
		}
		MyAnimator.CrossFade("B_idle");
		if (!Yandere.Aiming)
		{
			Vector3 b = ((Yandere.Head.transform.position.x < base.transform.position.x) ? Yandere.Head.transform.position : (base.transform.position + base.transform.forward + base.transform.up * 0.139854f));
			Target.position = Vector3.Lerp(Target.position, b, Time.deltaTime * 5f);
			Head.transform.LookAt(Target);
		}
		else
		{
			Head.transform.LookAt(Yandere.transform.position + Vector3.up * Head.position.y);
		}
	}
}
