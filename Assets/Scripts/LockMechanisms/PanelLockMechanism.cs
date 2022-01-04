using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Assets.Scripts;

public class PanelLockMechanism : LockMechanismAbstract
{
    public string Password;
    private Text PasswordCanvas;
    public override event EventHandler LockCracked;
    
    public void Start()
    {
        PasswordCanvas = this.transform.GetChild(0).GetComponent<Text>();
    }

    public void AddSymbol(string digit)
    {
        if (PasswordCanvas.text.Length < 8)
        {
            PasswordCanvas.text += digit;
        }
    }

    public void RemoveSymbol()
    {
        if (PasswordCanvas.text.Length > 0)
        {
            PasswordCanvas.text = PasswordCanvas.text.Substring(0, PasswordCanvas.text.Length - 1);
        }
    }

    public override void CrackLock()
    {
        throw new NotImplementedException();
    }

    public bool Check()
    {
        if (PasswordCanvas.text.Equals(Password))
        {
            PasswordCanvas.text = "CORRECT";
            OnLockCracked(EventArgs.Empty);
            return true;
        }
        else
        {
            PasswordCanvas.text = string.Empty;
            return false;
        }
    }

    private void OnLockCracked(EventArgs e)
    {
        EventHandler handler = LockCracked;
        if (handler != null)
        {
            handler(this, e);
            GameObject.Destroy(gameObject);
        }
    }
}
