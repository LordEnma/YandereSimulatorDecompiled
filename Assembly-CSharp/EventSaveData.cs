using System;

// Token: 0x02000400 RID: 1024
[Serializable]
public class EventSaveData
{
	// Token: 0x06001C2A RID: 7210 RVA: 0x0014929B File Offset: 0x0014749B
	public static EventSaveData ReadFromGlobals()
	{
		return new EventSaveData
		{
			befriendConversation = EventGlobals.BefriendConversation,
			event1 = EventGlobals.Event1,
			event2 = EventGlobals.Event2,
			kidnapConversation = EventGlobals.KidnapConversation,
			livingRoom = EventGlobals.LivingRoom
		};
	}

	// Token: 0x06001C2B RID: 7211 RVA: 0x001492D9 File Offset: 0x001474D9
	public static void WriteToGlobals(EventSaveData data)
	{
		EventGlobals.BefriendConversation = data.befriendConversation;
		EventGlobals.Event1 = data.event1;
		EventGlobals.Event2 = data.event2;
		EventGlobals.KidnapConversation = data.kidnapConversation;
		EventGlobals.LivingRoom = data.livingRoom;
	}

	// Token: 0x04003196 RID: 12694
	public bool befriendConversation;

	// Token: 0x04003197 RID: 12695
	public bool event1;

	// Token: 0x04003198 RID: 12696
	public bool event2;

	// Token: 0x04003199 RID: 12697
	public bool kidnapConversation;

	// Token: 0x0400319A RID: 12698
	public bool livingRoom;
}
