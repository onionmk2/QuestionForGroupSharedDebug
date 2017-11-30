using UnityEngine;

public class Test : MonoBehaviour
{
    public ComputeShader shader;
    private ComputeBuffer result;

    private void Start()
    {
        result = new ComputeBuffer(8, sizeof(int));
    }

    private void Update()
    {
        var id = shader.FindKernel("CSMain");
        shader.SetBuffer(id, "result", result);

        shader.Dispatch(kernelIndex: id, threadGroupsX: 4, threadGroupsY: 4, threadGroupsZ: 1);

        var resultArray = new int[8];
        result.GetData(resultArray);

        for (var index = 0; index < resultArray.Length; index++)
        {
            print("Time.frameCount: " + Time.frameCount + "resultIndex: " + index + "resultValue: " + resultArray[index]);
        }
    }

    private void OnDestroy()
    {
        result.Release();
    }
}