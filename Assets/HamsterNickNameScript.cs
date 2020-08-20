using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class HamsterNickNameScript : MonoBehaviour
{
    [SerializeField] Move hamsterScript;

    [SerializeField] Text hamsterNamingName;
    [SerializeField] GameObject warningPrefap;
    [SerializeField] WarningScript warning;
    [SerializeField] ButtenUiManagerScript buttenUiManager;

    [SerializeField] Text areYouSureHamsterName;
    [SerializeField] GameObject areYouSure;
    [SerializeField] GameObject parents;

    [SerializeField] dongScript manager;

    private bool IsNickNameCurrectExact()//닉네임 확인
    {
        return Regex.IsMatch(hamsterNamingName.text,"^[0-9a-zA-Z가-힣]*$");
    }
    public void MakingNickName()
    {
        if (IsNickNameCurrectExact() == false || hamsterNamingName.text == "") 
        {
            Debug.Log("X");
            warning.InputWord = "띄어쓰기 또는 특수문자는 사용할 수 없습니다.";
            Instantiate(warningPrefap, new Vector3(0, 0, 0), Quaternion.identity);

        }
        else
        {
            areYouSureHamsterName.text = hamsterNamingName.text;
            areYouSure.SetActive(true);
        }
    }
    public void Sure()
    {
        hamsterScript.isNamed = true;
        buttenUiManager.canActive = true;
        hamsterScript.name = hamsterNamingName.text;
        parents.SetActive(false);
        manager.canActive_Name = true;

    }
    public void No()
    {

        areYouSure.SetActive(false);
    }
}
