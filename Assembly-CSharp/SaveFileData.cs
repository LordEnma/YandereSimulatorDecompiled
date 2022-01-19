using System;
using System.Xml.Serialization;

// Token: 0x02000407 RID: 1031
[XmlRoot]
[Serializable]
public class SaveFileData
{
	// Token: 0x0400317A RID: 12666
	public ApplicationSaveData applicationData = new ApplicationSaveData();

	// Token: 0x0400317B RID: 12667
	public ClassSaveData classData = new ClassSaveData();

	// Token: 0x0400317C RID: 12668
	public ClubSaveData clubData = new ClubSaveData();

	// Token: 0x0400317D RID: 12669
	public CollectibleSaveData collectibleData = new CollectibleSaveData();

	// Token: 0x0400317E RID: 12670
	public ConversationSaveData conversationData = new ConversationSaveData();

	// Token: 0x0400317F RID: 12671
	public DateSaveData dateData = new DateSaveData();

	// Token: 0x04003180 RID: 12672
	public DatingSaveData datingData = new DatingSaveData();

	// Token: 0x04003181 RID: 12673
	public EventSaveData eventData = new EventSaveData();

	// Token: 0x04003182 RID: 12674
	public GameSaveData gameData = new GameSaveData();

	// Token: 0x04003183 RID: 12675
	public HomeSaveData homeData = new HomeSaveData();

	// Token: 0x04003184 RID: 12676
	public MissionModeSaveData missionModeData = new MissionModeSaveData();

	// Token: 0x04003185 RID: 12677
	public OptionSaveData optionData = new OptionSaveData();

	// Token: 0x04003186 RID: 12678
	public PlayerSaveData playerData = new PlayerSaveData();

	// Token: 0x04003187 RID: 12679
	public PoseModeSaveData poseModeData = new PoseModeSaveData();

	// Token: 0x04003188 RID: 12680
	public SaveFileSaveData saveFileData = new SaveFileSaveData();

	// Token: 0x04003189 RID: 12681
	public SchemeSaveData schemeData = new SchemeSaveData();

	// Token: 0x0400318A RID: 12682
	public SchoolSaveData schoolData = new SchoolSaveData();

	// Token: 0x0400318B RID: 12683
	public SenpaiSaveData senpaiData = new SenpaiSaveData();

	// Token: 0x0400318C RID: 12684
	public StudentSaveData studentData = new StudentSaveData();

	// Token: 0x0400318D RID: 12685
	public TaskSaveData taskData = new TaskSaveData();

	// Token: 0x0400318E RID: 12686
	public YanvaniaSaveData yanvaniaData = new YanvaniaSaveData();
}
