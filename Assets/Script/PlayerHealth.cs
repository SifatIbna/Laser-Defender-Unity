using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    TextMeshProUGUI health;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        this.health = FindObjectOfType<TextMeshProUGUI>();
        this.player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        this.health.text = this.player.GetHealth().ToString();
    }
}
