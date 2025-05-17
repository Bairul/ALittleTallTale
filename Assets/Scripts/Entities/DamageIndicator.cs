using UnityEngine;

public class DamageIndicator : MonoBehaviour
{
    public Vector2 offset;
    public GameObject prefabNormal;
    public GameObject prefabCrit;
    public float duration;

    private bool isCrit = false;
    public bool IsCrit { get => isCrit; set => isCrit = value; }

    public void ShowDamage(float damage)
    {
        Vector2 pos = new(transform.position.x, transform.position.y);
        GameObject dmgTxt;
        string txt = "";
        if (isCrit)
        {
            dmgTxt = Instantiate(prefabCrit, pos + offset, Quaternion.identity);
            txt += (int)damage + "!";
        }
        else
        {
            dmgTxt = Instantiate(prefabNormal, pos + offset, Quaternion.identity);
            txt += (int)damage;
        }

        dmgTxt.GetComponentInChildren<TextMesh>().text = txt;
        Destroy(dmgTxt, duration);
    }
}
