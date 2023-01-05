using UnityEngine;

[RequireComponent(typeof(UIPopupList))]
[AddComponentMenu("NGUI/Interaction/Language Selection")]
public class LanguageSelection : MonoBehaviour
{
	private UIPopupList mList;

	private bool mStarted;

	private void Awake()
	{
		mList = GetComponent<UIPopupList>();
	}

	private void Start()
	{
		mStarted = true;
		Refresh();
		EventDelegate.Add(mList.onChange, delegate
		{
			Localization.language = UIPopupList.current.value;
		});
	}

	private void OnEnable()
	{
		if (mStarted)
		{
			Refresh();
		}
	}

	public void Refresh()
	{
		if (mList != null && Localization.knownLanguages != null)
		{
			mList.Clear();
			int i = 0;
			for (int num = Localization.knownLanguages.Length; i < num; i++)
			{
				mList.items.Add(Localization.knownLanguages[i]);
			}
			mList.value = Localization.language;
		}
	}

	private void OnLocalize()
	{
		Refresh();
	}
}
