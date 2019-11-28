using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginManager : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_InputField User;
    [SerializeField]
    private TMPro.TMP_InputField Pass;

    public void CheckCredentials()
    {
        if (User.text == GplayConfig.Instance.User && Pass.text == GplayConfig.Instance.Pass)
        {
            GplayConfig.Instance.IsLogin = false;
            AudioManager.Instance.PlaySFX(0);
            GplayConfig.Instance.EnterSubmenu(1);
        }
    }
}
