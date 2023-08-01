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
		if (Yandere.StudentManager.Students[11] != null)
		{
			if (Vector3.Distance(base.transform.position, Yandere.StudentManager.Students[11].transform.position) < 1f && Yandere.StudentManager.Students[11].Routine)
			{
				MyAnimator.CrossFade("beingPet");
			}
			else
			{
				MyAnimator.CrossFade("B_idle");
			}
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
