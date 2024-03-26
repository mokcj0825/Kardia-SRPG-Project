using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourBase : MonoBehaviour
{
    protected virtual void Awake()
    {
        // Perform any checks or setups necessary before the game starts
    }

    protected virtual void Start()
    {
        // Initialization logic that subclasses might use
    }

    protected virtual void Update()
    {
        // Common update logic, if necessary
    }

    // Example of a common coroutine for a delayed action
    protected IEnumerator DelayedAction(float delay, System.Action action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }

    // Utility method for safely logging messages only in debug mode
    protected void DebugLog(string message)
    {
        #if DEBUG
        Debug.Log(message);
        #endif
    }

    // Example utility for checking if the component is enabled and active in the scene
    protected bool IsActiveAndEnabled()
    {
        return isActiveAndEnabled;
    }
}
