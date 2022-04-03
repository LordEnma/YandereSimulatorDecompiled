using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200051C RID: 1308
public class YanSaveStaticIdentifier : MonoBehaviour
{
	// Token: 0x040049BD RID: 18877
	[SerializeField]
	public List<string> StaticTypeNames = new List<string>();

	// Token: 0x040049BE RID: 18878
	[SerializeField]
	public List<KeyValuePair<Type, string>> DisabledMembers = new List<KeyValuePair<Type, string>>();

	// Token: 0x040049BF RID: 18879
	[SerializeField]
	public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
