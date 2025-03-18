using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class ActivateTrigger : MonoBehaviour
	{
		public enum Mode
		{
			Trigger = 0,
			Replace = 1,
			Activate = 2,
			Enable = 3,
			Animate = 4,
			Deactivate = 5
		}

		public Mode action = Mode.Activate;

		public Object target;

		public GameObject source;

		public int triggerCount = 1;

		public bool repeatTrigger;

		private void DoActivateTrigger()
		{
			triggerCount--;
			if (triggerCount != 0 && !repeatTrigger)
			{
				return;
			}
			Object obj = target ?? base.gameObject;
			Behaviour behaviour = obj as Behaviour;
			GameObject gameObject = obj as GameObject;
			if (behaviour != null)
			{
				gameObject = behaviour.gameObject;
			}
			switch (action)
			{
			case Mode.Trigger:
				if (gameObject != null)
				{
					gameObject.BroadcastMessage("DoActivateTrigger");
				}
				break;
			case Mode.Replace:
				if (source != null && gameObject != null)
				{
					Object.Instantiate(source, gameObject.transform.position, gameObject.transform.rotation);
					Object.Destroy(gameObject);
				}
				break;
			case Mode.Activate:
				if (gameObject != null)
				{
					gameObject.SetActive(value: true);
				}
				break;
			case Mode.Enable:
				if (behaviour != null)
				{
					behaviour.enabled = true;
				}
				break;
			case Mode.Animate:
				if (gameObject != null)
				{
					gameObject.GetComponent<Animation>().Play();
				}
				break;
			case Mode.Deactivate:
				if (gameObject != null)
				{
					gameObject.SetActive(value: false);
				}
				break;
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			DoActivateTrigger();
		}
	}
}
