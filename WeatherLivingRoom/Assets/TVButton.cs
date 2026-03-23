using UnityEngine;

public class TVButton : MonoBehaviour
{
    public GameObject canvas;
    public AudioSource tvMusic;
    public Renderer buttonRenderer;
    public AudioSource clickSound;
    public Color colorOn = Color.green;
    public Color colorOff = Color.red;
    private bool isOn = true;

    void Start()
    {
        tvMusic.Stop();
        isOn = false;
        buttonRenderer.material.color = colorOff;
        canvas.SetActive(false);
    }
    public void ToggleTV()
    {
        isOn = !isOn;
        canvas.SetActive(isOn);
        buttonRenderer.material.color = isOn ? colorOn : colorOff;
        clickSound.Play();

        if (isOn)
            tvMusic.Play();
        else
            tvMusic.Stop();
    }
}
