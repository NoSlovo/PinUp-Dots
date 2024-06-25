using UnityEditor;
using UnityEngine;

public class ScriptCreator : EditorWindow
{
    [SerializeField] private string _nameScript;

    private string _pathCreate;


    [MenuItem("Tools/ScritsCreate")]
    private static void CreateScripts() => GetWindow<ScriptCreator>("ScreptCreator");


    public void OnGUI()
    {
        CreateLabels();
        GetDataCreate();
        GetPathCreate();

        if (GUILayout.Button("Create Script"))
        {
            GetPathCreate();
            CreateNewScript(_nameScript, _pathCreate);
        }
    }

    private void GetDataCreate() => _nameScript = EditorGUILayout.TextField("Script Name", _nameScript);


    private void GetPathCreate()
    {
        string selectedPath = GetActivePath();

        if (!string.IsNullOrEmpty(selectedPath))
        {
            if (selectedPath.StartsWith(Application.dataPath))
                _pathCreate = "Assets" + selectedPath.Substring(Application.dataPath.Length);
            else
                _pathCreate = selectedPath;
        }
    }

    private string GetActivePath()
    {
        if (Selection.activeObject != null)
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);

            if (System.IO.Directory.Exists(path))
                return path;
        }

        return "Assets/Scripts";
    }

    private static void CreateLabels()
    {
        GUILayout.Label("CreateScreeps", EditorStyles.boldLabel);
        GUILayout.Label("Create New Script", EditorStyles.boldLabel);
    }

    private void CreateNewScript(string name, string path)
    {
        string fullPath = path + "/" + name + ".cs";
        if (System.IO.File.Exists(fullPath))
        {
            EditorUtility.DisplayDialog("Error", "Script already exists!", "OK");
            return;
        }

        string template = @"using UnityEngine;

public class " + name + @" : MonoBehaviour
{
    
}";

        System.IO.File.WriteAllText(fullPath, template);
        AssetDatabase.Refresh();
        EditorUtility.DisplayDialog("Success", "Script created successfully!", "OK");
    }
}