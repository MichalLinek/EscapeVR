using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CombinationPadlockSlot : MonoBehaviour
{
    public int SlotIndex;
    public List<char> availableLetters = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

    private char currentLetter;
    private Vector3 vector;
    private bool IsMoving = false;
    private AudioSource audioSource;
    private float radius = 36.0f;
    private CombinationPadlockMechanism Parent;

    void Start()
    {
        currentLetter = availableLetters[7];
        Parent = gameObject.GetComponentInParent<CombinationPadlockMechanism>();
        Parent.Toggle(SlotIndex, currentLetter);
        vector = this.transform.localEulerAngles;
        audioSource = GetComponent<AudioSource>();
    }

    public void Toggle()
    {
        if (!IsMoving)
        {
            audioSource.Play();
            IsMoving = true;
            var relativePoint = Camera.main.transform.InverseTransformPoint(transform.position);
            int indexOfLetter = availableLetters.IndexOf(currentLetter);
            if (relativePoint.x > 0.0)
            {

                if (indexOfLetter >= availableLetters.Count - 1)
                {
                    currentLetter = availableLetters.First();
                }
                else
                {
                    currentLetter = availableLetters[indexOfLetter + 1];
                }
            }
            else
            {
                if (indexOfLetter <= 0)
                {
                    currentLetter = availableLetters.Last();
                }
                else
                {
                    currentLetter = availableLetters[indexOfLetter - 1];
                }
            }

            vector.z = (1 + availableLetters.IndexOf(currentLetter)) * radius - 288;
            Parent.Toggle(SlotIndex, currentLetter);
            StartCoroutine(SetUpCombPadlock());
        }
    }

    private IEnumerator SetUpCombPadlock()
    {
        Quaternion quaternion = Quaternion.Euler(vector);
        while (transform.localRotation != quaternion)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, quaternion, 50 * Time.deltaTime);
            yield return null;
        }
        IsMoving = false;
    }
}
