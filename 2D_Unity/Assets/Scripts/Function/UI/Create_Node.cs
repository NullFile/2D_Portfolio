using UnityEngine;

public class Create_Node : MonoBehaviour
{
    [HideInInspector]
    public Click_Unit_Btn unitBtn;
    [HideInInspector]
    public Weapon weapon;
    [HideInInspector]
    public int cost;

    private Cost_Mgr costMgr;

    [SerializeField]
    private GameObject[] unit;

    private SpriteRenderer spriteRenderer;

    Color possibleColor = new Color(0.0f, 255.0f, 0.0f, 255.0f);
    Color impossibleColor = new Color(255.0f, 0.0f, 0.0f, 255.0f);

    bool isCreate = true;
    Vector3 vec;

    void Start()
    {
        costMgr = FindObjectOfType<Cost_Mgr>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = UnitData.Inst.weaponSprites[(int)weapon];
    }

    void Update()
    {
        Installation_Check();
        Mouse_Button();
        Mouse_Button_Up();
    }

    void Installation_Check()
    {
        if (isCreate == true)
        {
            if (spriteRenderer.color != possibleColor)
                spriteRenderer.color = possibleColor;
        }
        else
        {
            if (spriteRenderer.color != impossibleColor)
                spriteRenderer.color = impossibleColor;
        }
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
            if (isCreate == true)
            {
                if (costMgr.UseCost(cost))
                    Create();
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Water") || collision.name.Contains("RedGround"))
        {
            isCreate = false;
        }

        if (collision.name.Contains("BlueGround"))
        {
            isCreate = true;
        }
    }

    void Create()
    {
        unitBtn.Delay();

        GameObject go = Instantiate(unit[(int)weapon]);

        vec.z = vec.y;

        go.transform.position = vec;
    }
}