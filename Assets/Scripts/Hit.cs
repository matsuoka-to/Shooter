using UnityEngine;
using System;

public class Hit : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    Action callback;
    bool isPlay = false;

    public void Play(Action callback)
    {
        isPlay = true;
        this.callback = callback;
        animator.Play("Play", 0, 0);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlay)
        {
            if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                isPlay = false;
                callback?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
