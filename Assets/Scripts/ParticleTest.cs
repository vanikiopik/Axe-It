using UnityEngine;

public class ParticleTest : MonoBehaviour
{
    [SerializeField] private ParticleSystem PS;
    private void Start() => PS = GetComponent<ParticleSystem>();

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) PS.Play();
    }
}
