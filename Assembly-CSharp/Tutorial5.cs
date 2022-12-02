using UnityEngine;

public class Tutorial5 : MonoBehaviour
{
	public void SetDurationToCurrentProgress()
	{
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].duration = Mathf.Lerp(2f, 0.5f, UIProgressBar.current.value);
		}
	}
}
