using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200051F RID: 1311
public class YanSaveStaticIdentifier : MonoBehaviour
{
	// Token: 0x04004A19 RID: 18969
	[SerializeField]
	public List<string> StaticTypeNames = new List<string>();

	// Token: 0x04004A1A RID: 18970
	[SerializeField]
	public List<KeyValuePair<Type, string>> DisabledMembers = new List<KeyValuePair<Type, string>>();

	// Token: 0x04004A1B RID: 18971
	[SerializeField]
	public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
