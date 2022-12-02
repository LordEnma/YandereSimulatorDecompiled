using System;
using System.Collections.Generic;
using UnityEngine;

public class YanSaveStaticIdentifier : MonoBehaviour
{
	[SerializeField]
	public List<string> StaticTypeNames = new List<string>();

	[SerializeField]
	public List<KeyValuePair<Type, string>> DisabledMembers = new List<KeyValuePair<Type, string>>();

	[SerializeField]
	public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
