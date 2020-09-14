using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBoost : MonoBehaviour
{
    public int timeJump = 5;
    public Text TextTime; 
    public GameObject jumpBoostUI;
    private bool Boost_Active = false;
    public static PlayerBoost instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'une instance de Inventory dans la scéne");
            return;
        }
        
        instance = this;
    }
    public void JumpBoost(int _jumpBoost)
    {
        jumpBoostUI.SetActive(true);
        PlayerMovement.instance.SetJumpBoost(_jumpBoost);
        Boost_Active = true;
        StartCoroutine(chronoJumpBoost());
        StartCoroutine(HandleBoostDelay(_jumpBoost));
    }
    public IEnumerator chronoJumpBoost()
    {
        while (Boost_Active)
        {
            TextTime.text = timeJump.ToString();
            timeJump = timeJump -1;
            yield return new WaitForSeconds(1f);
        }
    }
    public IEnumerator HandleBoostDelay(int _jumpBoost)
    {
        yield return new WaitForSeconds(timeJump);
        PlayerMovement.instance.SetJumpBoost(-_jumpBoost);
        jumpBoostUI.SetActive(false);
        Boost_Active = false;
    }
}
