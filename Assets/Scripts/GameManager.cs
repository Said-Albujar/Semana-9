using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, ISubject
{
    private static GameManager instance;

    private List<IObserver> observers;

    [SerializeField]
    private float timer;

    [SerializeField]
    private int progression;

    public int Progression { get { return progression; } }

    private void Awake()
    {
        observers = new List<IObserver>();
        instance = this;
    }

    public static GameManager GetInstance()
    {
        return instance;
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= progression)
        {
            progression++;
            Notify();
        }
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (IObserver observer in observers)
        {
            observer.Execute(this);
        }
    }
}
