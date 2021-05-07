using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpdateResources : MonoBehaviour
{
    public TMPro.TextMeshProUGUI resourceLabel;

    ///How can this be made dynamic?
    ///Make an add new resource method
    ///Any time something was produced, check to see if it exists in list
    ///If it doesn't add it to the resources list
    public List<Resource> resources;

    private void OnEnable() { ProduceResource.SomethingWasProduced += UpdateResourceLabel; }
    private void OnDisable() { ProduceResource.SomethingWasProduced -= UpdateResourceLabel; }


    void Start() => UpdateResourceLabel();

    public void UpdateResourceLabel()
    {
        resourceLabel.text =  "";

        for (int i = 0; i < resources.Count; i++)
            resourceLabel.text += resources[i].name + ": " + resources[i].ResourceAmount + "  |  ";
        
    }

}
