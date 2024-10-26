using System.Collections;
using TMPro;
using UnityEngine;

public class CurentFrameCounter : MonoBehaviour
{
	public GameObject CurrentFrame;

	public float Frame;

	private int IsRunning;

	public float SecondsWaited;

	private TextMeshProUGUI Text_Ui;

	private void Start()
	{
		Frame = 1f;
		IsRunning = 1;
		Text_Ui = CurrentFrame.GetComponent<TextMeshProUGUI>();
	}

	private void Update()
	{
		Text_Ui.text = Frame.ToString();
		if (IsRunning == 1)
		{
			StartCoroutine(Wait());
		}
	}

	public IEnumerator Wait()
	{
		Debug.Log("Wait Called");
		IsRunning = 0;
		yield return new WaitForSeconds(SecondsWaited);
		Debug.Log("Increased");
		Frame += 1f;
		IsRunning = 1;
	}
}
