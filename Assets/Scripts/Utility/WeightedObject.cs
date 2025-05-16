using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class WeightedObject
{
    public ScriptableObject item;
    public float weight;

    public WeightedObject(ScriptableObject item, float weight)
    {
        this.item = item;
        this.weight = weight;
    }

    // Static methods
    public static void NormalizeWeights(IEnumerable<WeightedObject> list)
    {
        if (list == null) return;

        float totalWeight = 0f;
        foreach (WeightedObject weightedObject in list)
        {
            totalWeight += weightedObject.weight;
        }

        foreach (WeightedObject weightedObject in list)
        {
            weightedObject.weight /= totalWeight;
        }
    }

    public static WeightedObject GetRandomWeightedObject(IEnumerable<WeightedObject> list)
    {
        if (!list.Any()) return null;

        // Calculate the total weight of all loot items. If normalized, this should be 1
        float totalWeight = 0;
        foreach (WeightedObject item in list)
        {
            totalWeight += item.weight;
        }

        // Generate a random number from 0 to totalWeight
        float randomValue = Random.Range(0, totalWeight);
        float cumulativeWeight = 0;

        // Select the object based on the random weight
        foreach (WeightedObject item in list)
        {
            cumulativeWeight += item.weight;
            if (randomValue < cumulativeWeight)
            {
                return item;
            }
        }

        Debug.LogError("Bad weight");
        return null; // Fallback, this line should never be reached
    }
}