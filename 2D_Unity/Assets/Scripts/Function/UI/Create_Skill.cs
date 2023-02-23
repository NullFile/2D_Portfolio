using UnityEngine;

public class Create_Skill : MonoBehaviour
{
    [HideInInspector]
    public Click_Skill_Btn skillBtn;
    [HideInInspector]
    public Skill skill;

    [SerializeField]
    private Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    bool isSkill = false;
    Vector3 vec;

    private GameObject target;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[(int)skill];
    }

    void Update()
    {
        Mouse_Button();
        Mouse_Button_Up();
    }

    void Mouse_Button()
    {
        if (Input.GetMouseButton(0))
        {
            vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0.0f;

            transform.position = vec;
        }
    }

    void Mouse_Button_Up()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (isSkill == true)
            {
                Skill();
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (target == null)
        {
            if (isSkill != true)
                isSkill = true;

            target = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (target != null)
        {
            if (isSkill != false)
                isSkill = false;

            target = null;
        }
    }

    void Skill()
    {
        if (target != null)
        {
            bool b = target.TryGetComponent(out Unit outUnit);

            if (b == true)
            {
                if (outUnit.Buff_or_Nerf(skill))
                {
                    skillBtn.Delay();
                }
            }
        }
    }
}
