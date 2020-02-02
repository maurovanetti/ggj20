using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "GGJ 2020/GameEvent", order = 0)]
public class GameEvent : ScriptableObject 
{
    public List<GameEventListener> Listeners = new List<GameEventListener>();

    public void AddListener(GameEventListener listener)
    {
        Listeners.Add(listener);
    }

    public void RemoveListener(GameEventListener listener)
    {
        Listeners.Remove(listener);
    }

    public void RaiseEvent()
    {
        for (int i = Listeners.Count - 1; i >= 0; i--)
        {
            Listeners[i].OnGameEventRaised();
        }
    }
}