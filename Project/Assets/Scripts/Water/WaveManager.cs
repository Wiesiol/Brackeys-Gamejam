using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float offset;
    [SerializeField] private float amplitude;
    [SerializeField] private float length;
    private static WaveManager instance;

    public static WaveManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<WaveManager>();
            }

            return instance;
        }
    }


    private void Update()
    {
        offset += Time.deltaTime * speed;
    }

    public float GetWaveHeight(float x)
    {
        return amplitude * Mathf.Sin(x / length + offset);
    }
}
