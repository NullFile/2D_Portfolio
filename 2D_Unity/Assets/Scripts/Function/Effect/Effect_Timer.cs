using UnityEngine;

public class Effect_Timer : MonoBehaviour
{
    private float curTimer = 0.0f;
    [SerializeField]
    private float endTimer;

    private void OnEnable()
    {
        curTimer = 0.0f;
    }

    private void Update()
    {
        if (curTimer < endTimer)
        {
            curTimer += Time.deltaTime;

            if (endTimer <= curTimer)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
