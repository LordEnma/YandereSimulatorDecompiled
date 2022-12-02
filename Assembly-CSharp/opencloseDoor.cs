using System.Collections;
using UnityEngine;

public class opencloseDoor : MonoBehaviour
{
	public Animator openandclose;

	public bool open;

	public Transform Player;

	private void Start()
	{
		open = false;
	}

	private void OnMouseOver()
	{
		if (!Player || !(Vector3.Distance(Player.position, base.transform.position) < 15f))
		{
			return;
		}
		if (!open)
		{
			if (Input.GetMouseButtonDown(0))
			{
				StartCoroutine(opening());
			}
		}
		else if (open && Input.GetMouseButtonDown(0))
		{
			StartCoroutine(closing());
		}
	}

	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		openandclose.Play("Opening");
		open = true;
		yield return new WaitForSeconds(0.5f);
	}

	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		openandclose.Play("Closing");
		open = false;
		yield return new WaitForSeconds(0.5f);
	}
}
