using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020004A5 RID: 1189
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001F4F RID: 8015 RVA: 0x001B7048 File Offset: 0x001B5248
	public SerializableHashSet()
	{
		this.elements = new List<T>();
	}

	// Token: 0x06001F50 RID: 8016 RVA: 0x001B705C File Offset: 0x001B525C
	public void OnBeforeSerialize()
	{
		this.elements.Clear();
		foreach (T item in this)
		{
			this.elements.Add(item);
		}
	}

	// Token: 0x06001F51 RID: 8017 RVA: 0x001B70BC File Offset: 0x001B52BC
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.elements.Count; i++)
		{
			base.Add(this.elements[i]);
		}
	}

	// Token: 0x06001F52 RID: 8018 RVA: 0x001B70F8 File Offset: 0x001B52F8
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001F53 RID: 8019 RVA: 0x001B70FC File Offset: 0x001B52FC
	public void ReadXml(XmlReader reader)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		bool isEmptyElement = reader.IsEmptyElement;
		reader.Read();
		if (isEmptyElement)
		{
			return;
		}
		while (reader.NodeType != XmlNodeType.EndElement)
		{
			reader.ReadStartElement("Element");
			T item = (T)((object)xmlSerializer.Deserialize(reader));
			reader.ReadEndElement();
			base.Add(item);
			reader.MoveToContent();
		}
	}

	// Token: 0x06001F54 RID: 8020 RVA: 0x001B7160 File Offset: 0x001B5360
	public void WriteXml(XmlWriter writer)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		foreach (T t in this)
		{
			writer.WriteStartElement("Element");
			xmlSerializer.Serialize(writer, t);
			writer.WriteEndElement();
		}
	}

	// Token: 0x04004145 RID: 16709
	[SerializeField]
	private List<T> elements;

	// Token: 0x04004146 RID: 16710
	private const string XML_Element = "Element";
}
