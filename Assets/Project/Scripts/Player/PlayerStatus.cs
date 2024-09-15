using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;

    [Header("Player Status")]
    public SerializedDictionary<string, int> playerResouces = new SerializedDictionary<string, int>();

    [Header("UI")]
    [SerializeField] private TMP_Text soulsTXT;
    [SerializeField] private TMP_Text woodsTXT;
    [SerializeField] private TMP_Text stonesTXT;
    private string[] text_souls, text_woods, text_stone;

    private void Awake()
    {
        instance = this;

        playerResouces.Add("Soul", 0);
        playerResouces.Add("Wood", 0);
        playerResouces.Add("Stone", 0);
    }

    private void Start()
    {
        text_souls = soulsTXT.text.Split(';');
        soulsTXT.text = text_souls[0] + " " + playerResouces["Soul"];

        text_woods = woodsTXT.text.Split(';');
        woodsTXT.text = text_woods[0] + " " + playerResouces["Wood"];

        text_stone = stonesTXT.text.Split(';');
        stonesTXT.text = text_stone[0] + " " + playerResouces["Stone"];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) AdddResource("Soul", 20);
    }

    public void AdddResource(string _resourceName, int _amount)
    {
        playerResouces[_resourceName] += _amount;
        UpdateResourceText();
    }

    public void RemoveResource(string _resourceName, int _amount)
    {
        playerResouces[_resourceName] = Mathf.Max(playerResouces[_resourceName] - _amount, 0);
        UpdateResourceText();
    }

    private void UpdateResourceText()
    {
        soulsTXT.text = text_souls[0] + " " + playerResouces["Soul"].ToString();

        woodsTXT.text = text_woods[0] + " " + playerResouces["Wood"].ToString();

        stonesTXT.text = text_stone[0] + " " + playerResouces["Stone"].ToString();
    }

}