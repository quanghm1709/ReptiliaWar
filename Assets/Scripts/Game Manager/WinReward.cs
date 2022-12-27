using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WinReward : MonoBehaviour
{
    [System.Serializable]
    public class Reward
    {
        public int unlockIndex;
        public bool isMap;
    }

    public List<Reward> reward;

    public void Unlock()
    {
        foreach(Reward r in reward)
        {
            if (r.isMap)
            {
                MapSelect.instance.isActiveMap[r.unlockIndex] = true;
            }
            else
            {
                CharacterManager.instance.isActive[r.unlockIndex] = true;
            }
        }
        
    }
}
