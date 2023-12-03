using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class QualitySettings : MonoBehaviour
{
    TMP_Dropdown dropdown;
    [SerializeField] RenderPipelineAsset[] renderPipelineAssets;
    RenderPipelineAsset currentRenderPipelineAsset;

    private void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.value = UnityEngine.QualitySettings.GetQualityLevel();
    }

    public void ChangeQuality(int index)
    {
        if (currentRenderPipelineAsset == renderPipelineAssets[index]) return;
        UnityEngine.QualitySettings.SetQualityLevel(index);
        UnityEngine.QualitySettings.renderPipeline = renderPipelineAssets[index];
        currentRenderPipelineAsset = UnityEngine.QualitySettings.renderPipeline;
    }
}