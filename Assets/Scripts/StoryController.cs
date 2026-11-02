using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Properties;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    public TextMeshProUGUI storyText;
    public Stack<string> storyBuf = new Stack<string>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        storyText.text = "";
        StartCoroutine(textTicker());
    }

    IEnumerator<WaitForSeconds> textTicker()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            if (storyBuf.Count > 0)
            {
                storyText.text = storyBuf.Pop();
            } else
            {
                storyText.text = "";
            }
        }
    }

    public void TypewriterText(string text)
    {
        string prior = "";
        foreach(char c in text)
        {
            storyBuf.Push(prior + c);
            prior = prior + c;
        }
        storyBuf.Push(text); storyBuf.Push(text); storyBuf.Push(text);
        while (prior.Length > 0)
        {
            prior = prior.Substring(0, prior.Length - 1);
            storyBuf.Push(prior);
        }
    }
}
