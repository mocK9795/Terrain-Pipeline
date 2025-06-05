using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TerrainPipeline))]
public class TPipelineEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		var script = target as TerrainPipeline;
		if (GUILayout.Button("Render Pipeline")) script.RenderPipeline();
	}
}
