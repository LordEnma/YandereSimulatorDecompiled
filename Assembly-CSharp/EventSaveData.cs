using System;

// Token: 0x020003FF RID: 1023
[Serializable]
public class EventSaveData
{
	// Token: 0x06001C20 RID: 7200 RVA: 0x00148BA7 File Offset: 0x00146DA7
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

	// Token: 0x06001C21 RID: 7201 RVA: 0x00148BE5 File Offset: 0x00146DE5
	public static void WriteToGlobals(EventSaveData data)
	{
		EventGlobals.BefriendConversation = data.befriendConversation;
		EventGlobals.Event1 = data.event1;
		EventGlobals.Event2 = data.event2;
		EventGlobals.KidnapConversation = data.kidnapConversation;
		EventGlobals.LivingRoom = data.livingRoom;
	}

	// Token: 0x04003188 RID: 12680
	public bool befriendConversation;

	// Token: 0x04003189 RID: 12681
	public bool event1;

	// Token: 0x0400318A RID: 12682
	public bool event2;

	// Token: 0x0400318B RID: 12683
	public bool kidnapConversation;

	// Token: 0x0400318C RID: 12684
	public bool livingRoom;
}
