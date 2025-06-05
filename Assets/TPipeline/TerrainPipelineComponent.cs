using UnityEngine;

public abstract class TerrainPipelineComponent : MonoBehaviour
{
    public float[,] cashedData = null;
    
    [HideInInspector]
    public bool dataCashed = false;
    public abstract void CreateData(int mapXSize, int mapZSize, float maxMapHeight);

    /// <summary>
    /// inData is normalized elevation map
    /// </summary>
    /// <param name="inData"></param>
    /// <returns></returns>
    public abstract float[,] ManipulateData(float[,] inData);
}
