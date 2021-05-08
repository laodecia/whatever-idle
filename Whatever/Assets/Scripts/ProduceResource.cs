using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProduceResource : MonoBehaviour
{

    [SerializeField] Resource resource;
    [SerializeField] Producer producer;

    [SerializeField] int localTime = 0;

    public static Action SomethingWasProduced;

    private void OnEnable() { TimeManager.OneSecondChanged += Produce; }
    private void OnDisable() { TimeManager.OneSecondChanged -= Produce; }

    ///How do i make the production card modular?
    ///it would need to take in a resource to make
    ///and it would need to take in base stats about the production
    ///so producer base stats would need to be it's own scriptable object
    ///I don't want to load a prefab into scene and then define variables in inspector
    ///I want to drop two so's onto a prefab -the resource to make -the production style
    ///I want to broadcast (what I usually call invoke) a resource was made



    //Implement a slider to represent production time
    void Produce()
    {
        localTime++;

        if (localTime <= producer.BaseProductionTime)
        {
            Debug.Log("Local Time Passed: " + localTime + " seconds " + resource.ResourceName + "created");

            if (localTime >= producer.BaseProductionTime)
            {
                Debug.Log("Produced: " + producer.BaseAmountProduced + " " + resource.name);

                localTime = 0;
                SomethingWasProduced?.Invoke();
            }

    }


}
    ///Something has been produced, the resource label is updated
    ///How do I get what was produced and how much was produced to pass along
    ///I'm trying to avoid passing that value into another script







    /// Could below be it's own class?
    /// How can I make this applicable to other classes with those TMP labels being unique to circumstance.
    /// I know I could name the labels the same as the variable and then iterate 
    /// through children of the game object for TMP fields with the same name.
    /// That put's a lot of stress on me to know the names of the labels



    //Producer GO TMP Fields
    [SerializeField] TextMeshProUGUI buttonNameTMP;
    [SerializeField] TextMeshProUGUI producedTMP;
    [SerializeField] TextMeshProUGUI multiplierTMP;
    [SerializeField] TextMeshProUGUI costTMP;
    [SerializeField] TextMeshProUGUI speedTMP;


    void Start()
    {
        LoadProducerUIInfo();
    }

    private void LoadProducerUIInfo()
    {
        buttonNameTMP.text = resource.ResourceName + " " + producer.ProducerName;
        producedTMP.text = "Produced: " + producer.BaseAmountProduced;
        multiplierTMP.text = "Multiplier: " + producer.BaseMultiplier;
        costTMP.text = "Cost: " + producer.BaseCost;
        speedTMP.text = "Speed: " + producer.BaseProductionTime;
    }

}

