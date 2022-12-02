using System.Collections;
using UnityEngine;

public class opencloseWindow1 : MonoBehaviour
{
	public Animator openandclosewindow1;

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
		MonoBehaviour.print("you are opening the Window");
		openandclosewindow1.Play("Openingwindow 1");
		open = true;
		yield return new WaitForSeconds(0.5f);
	}

	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the Window");
		openandclosewindow1.Play("Closingwindow 1");
		open = false;
		yield return new WaitForSeconds(0.5f);
	}
}
