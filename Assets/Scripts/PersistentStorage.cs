using System.IO;
using UnityEngine;

public class PersistentStorage : MonoBehaviour {
    string savePath;

    void Awake () {
        savePath = Path.Combine(Application.persistentDataPath, "saveFile");
    }

    public void Save (PersistableObject persistableObject, int version) {
        using (
            var writer = new BinaryWriter(File.Open(savePath, FileMode.Create))
        ) {
            writer.Write(-version);
            persistableObject.Save(new GameDataWriter(writer));
        }
    }

    public void Load (PersistableObject persistableObject)
    {
        byte[] data = File.ReadAllBytes(savePath);
        var reader = new BinaryReader(new MemoryStream(data));
        persistableObject.Load(new GameDataReader(reader, -reader.ReadInt32()));
    }
}
