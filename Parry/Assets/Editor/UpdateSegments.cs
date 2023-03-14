using UnityEditor;
using UnityEngine;

public class UpdateSegments : Editor
{
    private static string _segmentFolderPath = "Assets/Prefabs/Segments";
    
    [MenuItem("Segments/Reload Segments")]
    public static void ReloadSegments()
    {
        var segments = AssetDatabase.LoadAllAssetsAtPath(_segmentFolderPath);
        Debug.Log(segments);
    }
}
