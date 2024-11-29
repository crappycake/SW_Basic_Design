using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedSetting : MonoBehaviour
{
    public static SpeedSetting instance;

    [SerializeField] private float originalRotationSpeed;
    private float rotateSpeed;
    private float[] speedMultipliers = { 1f, 1.25f, 1.50f, 1.75f, 2f };
    private string[] shownMultipler = {"1", "1.5", "2", "2.5", "3"};
    private int speedMultiplierIndex;

    public TextMeshProUGUI speedButton;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        speedMultiplierIndex = 0;
        rotateSpeed = originalRotationSpeed;
    }

    public void ChangeSpeedMultipler()
    {
        speedMultiplierIndex++;
        speedMultiplierIndex %= speedMultipliers.Length;

        rotateSpeed = (int)(originalRotationSpeed * speedMultipliers[speedMultiplierIndex]);

        Debug.Log(rotateSpeed);

        string text = "X" + shownMultipler[speedMultiplierIndex];
        speedButton.SetText(text);
    }

    public float RotateSpeed()
    {
        return rotateSpeed;
    }
}
