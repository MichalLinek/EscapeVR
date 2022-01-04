using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts;

namespace Assets.Scripts
{
    public class SafeMechanism : LockMechanismAbstract
    {
        private bool isRotating= false;
        private double finalAngle;
        private double radius = 13.84615384615385;
        private Quaternion rotationTo;
        private AudioSource audioSource;

        public string Password;
        private string currentPass = string.Empty;
        private  int CurrentPosition = 0;
        private string[] letters = new string[] { "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "A" };
        public override event EventHandler LockCracked;

        public void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void Toggle()
        {
            if (!isRotating)
            { 
                Vector3 v = transform.localEulerAngles;
                var relativePoint = Camera.main.transform.InverseTransformPoint(transform.position);
                double ang = 0;
            
                Vector3 fromVector = new Vector3(relativePoint.x, relativePoint.y, 0);

                if (relativePoint.x <0)
                {
                    ang = Vector3.Angle(fromVector, Vector3.down);
                }
                else
                {
                    ang = Vector3.Angle(fromVector, Vector3.up) + 180;
                }
                int help = (int)((ang + radius/2)/ radius);
                CurrentPosition += help;
                if (currentPass.Length >= Password.Length)
                {
                    currentPass = currentPass.Substring(1, currentPass.Length -1);
                }
                currentPass += letters[CurrentPosition %26];
                finalAngle = radius * (help);
                Debug.Log(help);
                this.transform.Rotate(new Vector3((float)finalAngle, 0, 0));
                v = this.transform.localEulerAngles;
                this.transform.Rotate(new Vector3(-(float)finalAngle, 0, 0));
                rotationTo = Quaternion.Euler(v);
                isRotating = true;
                audioSource.Play();
                CrackLock();
                StartCoroutine(RotateSafeWheel());
            }
        }

        private IEnumerator RotateSafeWheel()
        {
            while (this.transform.localRotation.eulerAngles.x != rotationTo.eulerAngles.x)
            {
                this.transform.localRotation = Quaternion.RotateTowards(transform.localRotation, rotationTo, 0.5f);
                yield return null;
            }
            isRotating = false;
            audioSource.Stop();
        }

        public override void CrackLock()
        {
            if (Password.Equals(currentPass))
            {
                OnLockCracked(EventArgs.Empty);
            }
        }

        private void OnLockCracked(EventArgs e)
        {
            EventHandler handler = LockCracked;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
