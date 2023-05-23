using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeightedObject
{
    public GameObject obj;
    public float weight = 1f;
}

public class RandomObjectSelector : MonoBehaviour
{
    public WeightedObject bomb;
    public List<WeightedObject> fruits;

    float totalWeight = 0;

    private void Start()
    {
        if (bomb.weight <= 0)
        {
            Debug.LogError("Bomb weight must be greater than 0");
        }


        totalWeight = 0;
        foreach (WeightedObject obj in fruits)
        {
            totalWeight += obj.weight;
        }

        if (totalWeight <= 0)
        {
            Debug.LogError("Total weight must be greater than 0");
        }
    }

    public GameObject GetRandomFruit()
    {
        float randomWeight = Random.Range(0, totalWeight);
        float currentWeight = 0;
        foreach (WeightedObject obj in fruits)
        {
            currentWeight += obj.weight;
            if (currentWeight >= randomWeight)
            {
                return obj.obj;
            }
        }

        return null;
    }

    public GameObject GetBomb()
    {
        return bomb.obj;
    }

    public GameObject GetRandomObject()
    {
        float randomWeight = Random.Range(0, totalWeight + bomb.weight);
        float currentWeight = 0;
        foreach (WeightedObject obj in fruits)
        {
            currentWeight += obj.weight;
            if (currentWeight >= randomWeight)
            {
                return obj.obj;
            }
        }

        return bomb.obj;
    }


}
