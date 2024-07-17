using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceOverlayUI : MonoBehaviour
{
    private const string shaderTestMode = "unity_GUIZTestMode";
    [SerializeField] private UnityEngine.Rendering.CompareFunction desiredUIComparison = UnityEngine.Rendering.CompareFunction.Always;
    [SerializeField] Graphic[] uiElementsToApplyEffectTo;

    private Dictionary<Material, Material> materialsMappings = new Dictionary<Material, Material>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(var graphic in uiElementsToApplyEffectTo)
        {
            Material material = graphic.materialForRendering;
            if (material == null)
            {
                Debug.Log("Target does not have rendering component");
                continue;
            }

            if (materialsMappings.TryGetValue(material, out Material materialCopy) == false)
            {
                materialCopy = new Material(material);
                materialsMappings.Add(material, materialCopy);

            }

            materialCopy.SetInt(shaderTestMode, (int)desiredUIComparison);
            graphic.material = materialCopy;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
